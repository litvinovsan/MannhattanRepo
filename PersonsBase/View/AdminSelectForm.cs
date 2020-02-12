﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class AdminSelectForm : Form
    {
        private readonly ManhattanInfo _manhattanInfo = DataBaseLevel.GetManhattanInfo();
        private List<Administrator> _administrators;
        private Administrator _curenAdministrator;
        public AdminSelectForm()
        {
            InitializeComponent();
            _administrators = _manhattanInfo.Admins;
            _curenAdministrator = _manhattanInfo.CurrentAdmin;
            label_Name.Text = _curenAdministrator.Name;

            // Заполняем именами Админов
            if (_administrators?.Count > 0)
            {
                MyComboBox.Initialize(comboBox_all_admins, _administrators.Select(x => x.Name).ToArray<object>());
            }

            // Выбираем активного админа в комбобоксе
            try
            {
                if (_administrators == null || _administrators.Count <= 0) return;

                var isNameExist = _administrators.Select(x => x.Name).Contains(_curenAdministrator.Name);
                comboBox_all_admins.SelectedItem = isNameExist ? _curenAdministrator.Name : "Нет";
            }
            catch (Exception)
            {
                MessageBox.Show(@"Exception admins select");
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedName = MyComboBox.GetComboBoxValue(comboBox_all_admins);
                _manhattanInfo.CurrentAdmin = _administrators.Find(x => x.Name.Equals(selectedName));
            }
            catch (Exception)
            {
                MessageBox.Show(@"Exception admins select");
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
