using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.control;
using PersonsBase.myStd;

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

            _persons = DataBaseLevel.GetListPersons();
            _dataStateOk = new PersonalDataState();
            _dataStruct = new PersonalDataStruct();

            // Изменилось какое - либо поле данных
            PersonalDataStateEvent += PersDataStateHandler;
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

            if (Options.IsPasspDriveCheckEnable()) result = result && passportAndDriveStatus;

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

        private void ProcessMaskedTextBox(string emptyMask, MaskedTextBox maskedTextBox, Func<bool> processFunc)
        {
            if (string.IsNullOrEmpty(maskedTextBox.Text) || maskedTextBox.Text.Equals((emptyMask)) || string.IsNullOrWhiteSpace(maskedTextBox.Text))
            {
                maskedTextBox.BackColor = Color.Pink;
                processFunc();
                return;
            }
            var result = processFunc();

            maskedTextBox.BackColor = result ? Color.PaleGreen : Color.Pink;
        }
        private void ProcessDateTime(DateTime dateTime)
        {
            _dataStateOk.BDate = true;
            _dataStruct.BDate = dateTime.Date;
        }

        private void ProcessComboBox(ComboBox cmbox)
        {
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

        private bool IsPhoneOk(string text)
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
            _dataStateOk.Passport = (person == null);

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
            var nameToCheck = Methods.PrepareName(name);
            _dataStateOk.Name = !DataBaseLevel.ContainsNameKey(nameToCheck) && !string.IsNullOrEmpty(nameToCheck) && !string.IsNullOrWhiteSpace(nameToCheck) && nameToCheck != " ";

            if (!_dataStateOk.Name) return false;
            _dataStruct.Name = nameToCheck;
            return true;
        }

        #endregion

        /// ОБРАБОТЧИКИ ///
        private void button_add_foto_Click(object sender, EventArgs e)
        {
            Image img;
            var success = Photo.OpenPhoto(out img);

            if (!success) return;

            if (string.IsNullOrEmpty(_dataStruct.Name))
            {
                MessageBox.Show(@"Сначала укажите имя Клиента");
            }
            else
            {
                _dataStruct.PathToPhoto = Photo.SaveToPicturesFolder(img, _dataStruct.Name);
                Logic.TryLoadPhoto(pictureBox_Client, _dataStruct.PathToPhoto);
            }
        }

        private void button_Add_New_Person_Click(object sender, EventArgs e)
        {
            if (!IsNameOk(comboBox_Names.Text) || comboBox_Names.Text.Length < 3)
            {
                ButtonAddEnable(false);
                return;
            }
            var p = Methods.CreateNewPerson(_dataStruct);
            var result = DataBaseLevel.GetInstance().PersonAdd(p);
            if (result == ResponseCode.Success)
                DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show(result.ToString());
            }
        }

        private void maskedTextBox_PhoneNumber_KeyUp(object sender, KeyEventArgs e)
        {
            ProcessMaskedTextBox(_maskPhone, maskedTextBox_PhoneNumber, () => IsPhoneOk(maskedTextBox_PhoneNumber.Text));
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

        private void maskedTextBox_number_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(maskedTextBox_number.Text, out _dataStruct.PersonalNumber);
        }

        private void comboBox_Names_TextChanged(object sender, EventArgs e)
        {
            var valueToCheck = comboBox_Names.Text;
            StartTextVerification(valueToCheck, comboBox_Names, () => IsNameOk(valueToCheck));
        }
    }
}
