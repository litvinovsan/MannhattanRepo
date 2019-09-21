using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBase;

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

        private struct PersonalDataStruct
        {
            public string Name;
            public string Phone;
            public string Passport;
            public string DriveId;
            public string PathToPhoto;
            public string SpecialNotes;
            public int PersonalNumber;
            public Gender Gender;
            public DateTime BDate;
        }
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
            public bool PathToPhoto;
            public bool SpecialNotes;
            public bool PersonalNumber;
            //Приватные поля
            private bool _name;
            private bool _phone;
            private bool _passport;
            private bool _driveId;
            private bool _gender;
            private bool _bDate;
        }

        private PersonalDataState _dataStateOk = new PersonalDataState();
        private PersonalDataStruct _personDataStruct = new PersonalDataStruct();

        #endregion


        #region /// КОНСТРУКТОРЫ ///

        public CreatePersonForm()
        {
            InitializeComponent();
            PersonalDataStateEvent += StateHandler;

        }

        #endregion

        #region /// МЕТОДЫ ///

        public string GetName()
        {
            return _personDataStruct.Name;
        }
       
        private bool IsDataStatesOk()
        {
            bool result = (_dataStateOk.Name) && (_dataStateOk.BDate) && (_dataStateOk.Gender) && (_dataStateOk.Phone) && (_dataStateOk.DriveId || _dataStateOk.Passport);
            return result;
        }

        /// <summary>
        /// Обработчик. Запускается когда изменяется структура с bool результатами по всем полям
        /// </summary>
        private void StateHandler()
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
        /// <param name="value"></param>
        /// <param name="tbBox"></param>
        /// <param name="procFunc"></param>
        private void ProcessTextBox(string value, TextBox tbBox, Action procFunc)
        {
            if (string.IsNullOrEmpty(value))
            {
                tbBox.BackColor = Color.Pink;
                return;
            }

            procFunc();
        }
        // Проверка полей на валидность
        private void ProcessName(string name, TextBox tbBox)
        {
            var nameToCheck = Methods.PrepareName(name);
            _dataStateOk.Name = IsNameNotExist(nameToCheck);

            if (_dataStateOk.Name)
            {
                _personDataStruct.Name = nameToCheck;
                tbBox.BackColor = Color.PaleGreen;
            }
            else
            {
                tbBox.BackColor = Color.Pink;
            }
        }
        private bool IsNameNotExist(string name)
        {
            return !DataBaseClass.ContainsNameKey(name);
        }

        #endregion

        /// ОБРАБОТЧИКИ ///
        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {
            ProcessTextBox(textBox_Name.Text, textBox_Name, () => ProcessName(textBox_Name.Text, textBox_Name));
        }

        private void button_Add_New_Person_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
        }

        private void button_add_foto_Click(object sender, EventArgs e)
        {
            Image img;
            string pathDummy;
            var success = Photo.OpenPhoto(out img, out pathDummy);
            if (success)
            {
                //       _person.PathToPhoto = Photo.SaveToPicturesFolder(img, _person.Name);
            }
        }
    }
}
