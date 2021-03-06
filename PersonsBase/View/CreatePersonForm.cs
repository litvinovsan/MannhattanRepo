﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.control;
using PersonsBase.myStd;
using System.IO;

namespace PersonsBase.View
{
    public partial class CreatePersonForm : Form
    {
        #region /// СОБЫТИЯ ///
        private static event Action PersonalDataStateEvent;
        private static void OnPersonalDataStateChanged()
        {
            PersonalDataStateEvent?.Invoke();
        }
        #endregion

        #region /// ПОЛЯ ///

        private readonly string _maskPhone;
        private readonly string _maskPassport;
        private readonly string _maskDriverId;
        private readonly SortedList<string, Person> _persons;


        private struct PersonalDataState
        {
            public bool Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnPersonalDataStateChanged();
                }
            }
            public bool Phone
            {
                get { return _phone; }
                set
                {
                    _phone = value;
                    OnPersonalDataStateChanged();
                }
            }
            public bool Passport
            {
                get { return _passport; }
                set
                {
                    _passport = value;
                    OnPersonalDataStateChanged();
                }
            }
            public bool DriveId
            {
                get { return _driveId; }
                set
                {
                    _driveId = value;
                    OnPersonalDataStateChanged();
                }
            }
            public bool Gender
            {
                get { return _gender; }
                set
                {
                    _gender = value;
                    OnPersonalDataStateChanged();
                }
            }
            public bool BDate
            {
                get { return _bDate; }
                set
                {
                    _bDate = value;
                    OnPersonalDataStateChanged();
                }
            }

            //Приватные поля
            private bool _name;
            private bool _phone;
            private bool _passport;
            private bool _driveId;
            private bool _gender;
            private bool _bDate;
        }

        private PersonalDataState _dataStateOk;
        private PersonalDataStruct _dataStruct;

        #endregion

        #region /// КОНСТРУКТОРЫ ///

        public CreatePersonForm()
        {
            InitializeComponent();

            _maskPhone = maskedTextBox_PhoneNumber.Text;
            _maskPassport = maskedTextBox_Passport.Text;
            _maskDriverId = maskedTextBox_DriverID.Text;

            _persons = DataBaseLevel.GetPersonsList();
            _dataStateOk = new PersonalDataState();
            _dataStruct = new PersonalDataStruct();

            // Изменилось какое - либо поле данных
            PersonalDataStateEvent += PersDataStateHandler;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(maskedTextBox_number, "Кликните мышью на этом поле и считайте номер карты Считывателем. Либо введите номер вручную.");
        }

        private void CreatePersonForm_Load(object sender, EventArgs e)
        {
            // Инициализация полей по - умолчанию
            // Пол
            var gendRange = Enum.GetNames(typeof(Gender)).ToArray<object>();
            MyComboBox.Initialize(comboBox_Gender, gendRange, Gender.Неизвестен.ToString());

            // День Рождения
            dateTimePicker_birthDate.Value = new DateTime(1990, 01, 01);

            //Вызов для подсветки по-умолчанию
            comboBox_Names.BackColor = Color.Pink;
            maskedTextBox_PhoneNumber.BackColor = Color.Pink;

            //ComboBox Persons
            var objects = _persons.Values.Select(c => c.Name).ToArray<object>();
            MyComboBox.Initialize(comboBox_Names, objects);
        }

        #endregion

        #region /// МЕТОДЫ ///

        public string GetName()
        {
            return _dataStruct.Name;
        }

        private bool IsDataStatesOk()
        {
            var passportAndDriveStatus = (_dataStateOk.DriveId || _dataStateOk.Passport);
            var result = (_dataStateOk.Name) && (_dataStateOk.BDate) && (_dataStateOk.Gender) && (_dataStateOk.Phone);

            if (Options.CheckPasspAndDriveId) result = result && passportAndDriveStatus;

            return result;
        }

        /// <summary>
        /// Обработчик. Запускается когда изменяется структура с bool результатами по всем полям
        /// </summary>
        private void PersDataStateHandler()
        {
            ButtonAddEnable(IsDataStatesOk());
        }

        /// <summary>
        /// Включает-Выключает Кнопку Добавить Персону. 
        /// </summary>
        private void ButtonAddEnable(bool enableButton)
        {
            if (enableButton) button_Add_New_Person.BackColor = Color.LightGreen;

            button_Add_New_Person.Enabled = enableButton;
        }

        /// <summary>
        /// Запускает функцию поиска совпадений по имени. Задает цвет розовый если совпадает имя и зеленый, если нет
        /// </summary>
        private void StartTextVerification(string value, Control control, Func<bool> processFunc)
        {
            if (string.IsNullOrEmpty(value))
            {
                control.BackColor = Color.Pink;
                ButtonAddEnable(false);
                return;
            }
            var result = processFunc();

            control.BackColor = result ? Color.PaleGreen : Color.Pink;
            ButtonAddEnable(IsDataStatesOk());
        }

        // Проверка полей на валидность

        private void ProcessMaskedTextBox(string emptyMask, Control textBox, Func<bool> processFunc)
        {
            if (string.IsNullOrEmpty(textBox.Text) || textBox.Text.Equals((emptyMask)) || string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.BackColor = Color.Pink;
                processFunc();
                return;
            }
            var result = processFunc();

            textBox.BackColor = result ? Color.PaleGreen : Color.Pink;
        }

        private void ProcessDateTime(DateTime dateTime)
        {
            _dataStateOk.BDate = true;
            _dataStruct.BDate = dateTime.Date;
        }

        private void ProcessComboBox(ComboBox cmbox)
        {
            if (cmbox.SelectedItem == null) return;
            var gender = MyComboBox.GetComboBoxValue<Gender>(cmbox);

            if (gender == Gender.Неизвестен)
            {
                _dataStateOk.Gender = false;
                cmbox.BackColor = Color.Pink;
            }
            else
            {
                _dataStateOk.Gender = true;
                _dataStruct.Gender = gender;
                cmbox.BackColor = Color.PaleGreen;
            }
        }

        /// <summary>
        /// Проверка на наличие телефонного номера в базе
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool IsPhoneExists(string text)
        {
            var person = DataBaseM.FindByPhone(_persons, text);
            _dataStateOk.Phone = (person == null);

            if (!_dataStateOk.Phone)
            {
                _dataStruct.Phone = "";
                return false;
            }
            _dataStruct.Phone = text;

            return true;
        }

        private bool IsPassportOk(string text)
        {
            var person = DataBaseM.FindByPassport(_persons, text);
            _dataStateOk.Passport = (person == null) && !string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text) && !text.Equals(_maskPassport);

            if (!_dataStateOk.Passport)
            {
                _dataStruct.Passport = "";
                return false;
            }
            _dataStruct.Passport = text;

            return true;
        }

        private bool IsDriveIdOk(string text)
        {
            var person = DataBaseM.FindByDriveId(_persons, text);
            _dataStateOk.DriveId = (person == null) && !string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text) && !text.Equals(_maskDriverId);

            if (_dataStateOk.DriveId)
            {
                _dataStruct.DriveId = text;
                return true;
            }
            _dataStruct.DriveId = "";
            return false;
        }

        private bool IsNameOk(string name)
        {
            var nameToCheck = Logic.PrepareName(name);
            _dataStateOk.Name = !DataBaseLevel.ContainsNameKey(nameToCheck) && !string.IsNullOrEmpty(nameToCheck) && !string.IsNullOrWhiteSpace(nameToCheck) && nameToCheck != " ";

            if (!_dataStateOk.Name) return false;
            _dataStruct.Name = nameToCheck;
            return true;
        }
        private bool IsPersonNumberOk(string number)
        {
            var isExist = DataBaseM.FindByPersonalNumber(DataBaseLevel.GetPersonsList(), number, out var person);
            if (!isExist)
            {
                _dataStruct.IdString = Logic.NormalizeBarCodeNumber(number);
            }
            return !isExist;
        }
        #endregion

        /// ОБРАБОТЧИКИ ///
        private void button_add_foto_Click(object sender, EventArgs e)
        {
            var success = Photo.OpenPhoto(out var img);

            if (!success) return;

            if (string.IsNullOrEmpty(_dataStruct.Name))
            {
                MessageBox.Show(@"Сначала укажите имя Клиента");
            }
            else
            {
                _dataStruct.photoName = Path.GetFileName(Photo.SaveToPhotoDir(img, _dataStruct.Name));
                Logic.TryLoadPhoto(pictureBox_Client, _dataStruct.photoName, _dataStruct.Gender);
            }
        }

        private void button_Add_New_Person_Click(object sender, EventArgs e)
        {
            if (!IsNameOk(comboBox_Names.Text) || comboBox_Names.Text.Length < 3)
            {
                ButtonAddEnable(false);
                return;
            }

            var p = Logic.CreateNewPerson(_dataStruct);
            var result = DataBaseLevel.PersonAdd(p);
            if (result == ResponseCode.Success)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DataBaseM.ExplainResponse(result);
            }
        }

        private void maskedTextBox_PhoneNumber_KeyUp(object sender, KeyEventArgs e)
        {
            ProcessMaskedTextBox(_maskPhone, maskedTextBox_PhoneNumber, () => IsPhoneExists(maskedTextBox_PhoneNumber.Text));
        }

        private void maskedTextBox_Passport_KeyUp(object sender, KeyEventArgs e)
        {
            ProcessMaskedTextBox(_maskPassport, maskedTextBox_Passport, () => IsPassportOk(maskedTextBox_Passport.Text));
        }

        private void maskedTextBox_DriverID_KeyUp(object sender, KeyEventArgs e)
        {
            ProcessMaskedTextBox(_maskDriverId, maskedTextBox_DriverID, () => IsDriveIdOk(maskedTextBox_DriverID.Text));
        }

        private void dateTimePicker_birthDate_ValueChanged(object sender, EventArgs e)
        {
            ProcessDateTime(dateTimePicker_birthDate.Value);
        }

        private void comboBox_Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessComboBox(comboBox_Gender);
            dateTimePicker_birthDate.Focus();
        }

        private void textBox_Notes_TextChanged(object sender, EventArgs e)
        {
            _dataStruct.SpecialNotes = textBox_Notes.Text;
        }

        private void comboBox_Names_TextChanged(object sender, EventArgs e)
        {
            var valueToCheck = comboBox_Names.Text;
            StartTextVerification(valueToCheck, comboBox_Names, () => IsNameOk(valueToCheck));
        }
        private void maskedTextBox_Personal_Number_TextChanged(object sender, EventArgs e)
        {
            ProcessMaskedTextBox("", maskedTextBox_number, () => IsPersonNumberOk(maskedTextBox_number.Text));
        }
        private void maskedTextBox_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logic.CheckForDigits(e);
        }

        private void maskedTextBox_PhoneNumber_Click(object sender, EventArgs e)
        {
            if (maskedTextBox_PhoneNumber.Text.Equals("8(   )    -  -"))
                maskedTextBox_PhoneNumber.SelectionStart = 0;
        }

        private void maskedTextBox_Passport_Click(object sender, EventArgs e)
        {
            maskedTextBox_Passport.SelectionStart = 0;
        }

        private void maskedTextBox_DriverID_Click(object sender, EventArgs e)
        {
            maskedTextBox_DriverID.SelectionStart = 0;
        }

        private void button_Get_Photo_WebCam_Click(object sender, EventArgs e)
        {
            // Открывает форму для получения снимка. 
            var isPictOk = Logic.GetWebCamBmp(out Bitmap picture);

            if (!isPictOk || picture == null) return;

            // Прописывает в персону имя файла фотки. Сохраняет копию изображения
            var path = Photo.SaveToPhotoDir(picture, _dataStruct.Name);
            _dataStruct.photoName = Path.GetFileName(path);

            Logic.TryLoadPhoto(pictureBox_Client, _dataStruct.photoName, _dataStruct.Gender);
        }
    }
}
