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
        private static event Action DataStateEvent;
        private static void OnDataStateChanged()
        {
            DataStateEvent?.Invoke();
        }
        #endregion

        #region /// ПОЛЯ ///

        private struct PDataStruct
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
        private struct DataStateStruct
        {

            public bool Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    OnDataStateChanged();
                }
            }
            public bool Phone
            {
                get { return _phone; }
                set
                {
                    _phone = value;
                    OnDataStateChanged();
                }
            }
            public bool Passport
            {
                get { return _passport; }
                set
                {
                    _passport = value;
                    OnDataStateChanged();
                }
            }
            public bool DriveId
            {
                get { return _driveId; }
                set
                {
                    _driveId = value;
                    OnDataStateChanged();
                }
            }
            public bool Gender
            {
                get { return _gender; }
                set
                {
                    _gender = value;
                    OnDataStateChanged();
                }
            }
            public bool BDate
            {
                get { return _bDate; }
                set
                {
                    _bDate = value;
                    OnDataStateChanged();
                }
            }
            public bool PathToPhoto;
            public bool SpecialNotes;
            public bool PersonalNumber;
            private bool _name;
            private bool _phone;
            private bool _passport;
            private bool _driveId;
            private bool _gender;
            private bool _bDate;
        }

        private static DataStateStruct _pDatStateStruct = new DataStateStruct();
        private PDataStruct _personDataStruct = new PDataStruct();

        #endregion


        #region /// КОНСТРУКТОРЫ ///

        public CreatePersonForm()
        {
            InitializeComponent();
            DataStateEvent += StateHandler;

            _pDatStateStruct.Name = true;
            _pDatStateStruct.Gender = true;
        }

        #endregion

        #region /// МЕТОДЫ ///

        public string GetName()
        {
            return _personDataStruct.Name;
        }

        private void ButtonAddEneble(bool enableButton)
        {
            button_Add_New_Person.Enabled = enableButton;
        }

        private static bool IsDataStatesOk()
        {
            bool result = (_pDatStateStruct.Name) && (_pDatStateStruct.BDate) && (_pDatStateStruct.Gender) && (_pDatStateStruct.Phone) && (_pDatStateStruct.DriveId || _pDatStateStruct.Passport);
            return result;
        }

        private void StateHandler()
        {
            ButtonAddEneble(IsDataStatesOk());
        }
        #endregion

        /// ОБРАБОТЧИКИ ///
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
