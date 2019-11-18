using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PBase;
using PersonsBase.data;
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
        private Person.PersonalDataStruct _dataStruct;

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
            _dataStruct = new Person.PersonalDataStruct();

            // Изменилось какое - либо поле данных
            PersonalDataStateEvent += VariablesHandler;
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
            textBox_Name.BackColor = Color.Pink;
            maskedTextBox_PhoneNumber.BackColor = Color.Pink;
            maskedTextBox_Passport.BackColor = Color.Pink;

        }

        #endregion

        #region /// МЕТОДЫ ///

        public string GetName()
        {
            return _dataStruct.Name;
        }

        private bool IsDataStatesOk()
        {
            bool result = (_dataStateOk.Name) && (_dataStateOk.BDate) && (_dataStateOk.Gender) && (_dataStateOk.Phone) && (_dataStateOk.DriveId || _dataStateOk.Passport);
            return result;
        }

        /// <summary>
        /// Обработчик. Запускается когда изменяется структура с bool результатами по всем полям
        /// </summary>
        private void VariablesHandler()
        {
            ButtonAddEneble(IsDataStatesOk());
        }

        /// <summary>
        /// Включает-Выключает Кнопку Добавить Персону. 
        /// </summary>
        private void ButtonAddEneble(bool enableButton)
        {
            button_Add_New_Person.Enabled = enableButton;
        }

        /// <summary>
        /// Запускает функцию обработки если пройдена первичная проверка.
        /// </summary>
        private void ProcessTextBox(string value, Control tbBox, Func<bool> processFunc)
        {
            if (string.IsNullOrEmpty(value))
            {
                tbBox.BackColor = Color.Pink;
                return;
            }
            var result = processFunc();

            tbBox.BackColor = result ? Color.PaleGreen : Color.Pink;
        }

        // Проверка полей на валидность

        private void ProcessMaskedTextBox(string emptyMask, MaskedTextBox maskedTextBox, Func<bool> processFunc)
        {
            if (string.IsNullOrEmpty(maskedTextBox.Text) || maskedTextBox.Text.Equals((emptyMask)))
            {
                maskedTextBox.BackColor = Color.Pink;
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

            if (!_dataStateOk.Phone) return false;
            _dataStruct.Phone = text;

            return true;
        }

        private bool IsPassportOk(string text)
        {
            var person = DataBaseM.FindByPassport(_persons, text);
            _dataStateOk.Passport = (person == null);

            if (!_dataStateOk.Passport) return false;
            _dataStruct.Passport = text;

            return true;
        }

        private bool IsDriveIdOk(string text)
        {
            var person = DataBaseM.FindByDriveId(_persons, text);
            _dataStateOk.DriveId = (person == null);

            if (!_dataStateOk.Passport) return false;
            _dataStruct.DriveId = text;

            return true;
        }

        private bool IsNameOk(string name)
        {
            var nameToCheck = Methods.PrepareName(name);
            _dataStateOk.Name = !DataBaseLevel.ContainsNameKey(nameToCheck);

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

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {
            ProcessTextBox(textBox_Name.Text, textBox_Name, () => IsNameOk(textBox_Name.Text));
        }

        private void button_Add_New_Person_Click(object sender, EventArgs e)
        {
            var p = Person.CreateNewPerson(_dataStruct);
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
    }
}
