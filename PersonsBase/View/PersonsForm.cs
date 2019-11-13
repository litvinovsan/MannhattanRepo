using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBase;
using PersonsBase.data;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class PersonsForm : Form
    {
        #region /// СОБЫТИЯ ///

        [field: NonSerialized]
        public event EventHandler SelectedNameСhanged;
        public void OnSelectedNameChanged()
        {
            SelectedNameСhanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region /// ОСНОВНЫЕ ОБЬЕКТЫ ///
        private string _selectedName;
        public string SelectedName
        {
            get { return _selectedName; }
            set
            {
                _selectedName = value;
                OnSelectedNameChanged();
            }
        }

        #endregion

        #region /// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ///

        public PersonsForm(string headerName)
        {
            InitializeComponent();
            this.Text = headerName;
        }

        private void PersonsListForm_Load(object sender, EventArgs e)
        {
            // Инициализация всех контролов

            //ComboBox Persons
            var objects = DataBaseLevel.GetListPersons().Values.Select(c => c.Name).ToArray<object>();
            MyComboBox.Initialize(comboBox_Names, objects);

            // Пол
            var gendRange = Enum.GetNames(typeof(Gender)).ToArray<object>();
            MyComboBox.Initialize(comboBox_Gender, gendRange, Gender.Неизвестен);

            // ListBox
            listBox_persons.Items.AddRange(objects);

            // Подписка на событие
            SelectedNameСhanged += NameProcessing;
        }


        #endregion

        #region /// МЕТОДЫ ///

        public string GetName()
        {
            return SelectedName;
        }

        /// <summary>
        /// Обработчик запускает обновление всех полей на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameProcessing(object sender, EventArgs e)
        {
            if (!listBox_persons.SelectedItem.ToString().Equals(SelectedName))
            {
                listBox_persons.SelectedItem = SelectedName;
            }

            UpdatePersonalContols();
        }

        private void UpdatePersonalContols()
        {
            // Получили Персону
            var person = DataBaseO.GetPersonLink(SelectedName);

            // Телефон
            maskedTextBox_PhoneNumber.Text = person.Phone;
            // Пол
            MyComboBox.SetComboBoxValue(comboBox_Gender, person.GenderType.ToString());
            // ДР
            //  написать тут эти блоки
            // Пасспорт

            // Права

            // Фото
            Logic.TryLoadPhoto(pictureBox_Client, person.PathToPhoto);
        }

        #endregion

        private void comboBox_Names_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedName = MyComboBox.GetComboBoxValue((ComboBox)sender);
        }

        private void listBox_persons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_persons.SelectedItems.Count == 0) return;

            comboBox_Names.SelectedItem = listBox_persons.SelectedItem.ToString();
        }

        private void button_Ok_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

