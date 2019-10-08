﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBase;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class PersonListForm : Form
    {
        #region /// ОСНОВНЫЕ ОБЬЕКТЫ ///
        private string _selectedName;

        #endregion

        #region /// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ///

        public PersonListForm(string headerName)
        {
            InitializeComponent();
            this.Text = headerName;
        }

        public string SelectedName
        {
            get { return _selectedName; }
            set
            {
                _selectedName = value;
                //  FIXME  тут запускатор СОБЫТИЯ
            }
        }

        private void PersonListForm_Load(object sender, EventArgs e)
        {
            // Инициализация всех контролов

            //ComboBox
            var objects = DataBaseLevel.GetListPersons().Values.Select(c => c.Name).ToArray<object>();
            MyComboBox.Initialize(comboBox_Names, objects);

            // ListBox
            listBox_persons.Items.AddRange(objects);
        }
        #endregion

        #region /// МЕТОДЫ ///

        public string GetName()
        {
            return SelectedName;
        }

        #endregion

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void comboBox_Names_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FIXME
            /// При выборе имени в контролах обновить переменную _selectedName
            /// На эту переменную сделать событие что она изменилась.
            /// По событию обновлять выбранный элемент и подгружать данные в окно информации справа
            /// Не забыть про проверку if (lv.SelectedItems.Count != 0)
            ///
            SelectedName = MyComboBox.GetComboBoxValue((ComboBox)sender);
        }

        private void listBox_persons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_persons.SelectedItems.Count != 0)
                SelectedName = listBox_persons.SelectedItem.ToString();
        }
    }
}
