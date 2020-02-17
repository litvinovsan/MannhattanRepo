using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class AdminSelectForm : Form
    {
        private readonly ManhattanInfo _manhattanInfo = DataBaseLevel.GetManhattanInfo();
        private readonly List<Administrator> _administrators;

        public AdminSelectForm()
        {
            InitializeComponent();
            _administrators = _manhattanInfo?.Admins;
            var curenAdministrator = _manhattanInfo?.CurrentAdmin;
            label_Name.Text = curenAdministrator?.Name;

            // Заполняем именами Админов
            if (_administrators?.Count > 0)
            {
                MyComboBox.Initialize(comboBox_all_admins, _administrators.Select(x => x.Name).ToArray<object>());
            }

            // Выбираем активного админа в комбобоксе
            try
            {
                if (_administrators == null || _administrators.Count <= 0) return;

                var isNameExist = curenAdministrator != null && _administrators.Select(x => x.Name).Contains(curenAdministrator.Name);
                comboBox_all_admins.SelectedItem = isNameExist ? curenAdministrator.Name : "Нет";
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

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
