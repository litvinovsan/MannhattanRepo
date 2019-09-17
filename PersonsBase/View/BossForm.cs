using PBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonsBase.View
{

    public partial class BossForm : Form
    {
        private Options _options;
        private DataBaseClass _dataBase;
        private readonly ManhattanInfo _manhattanInfo;
        private Employee _employee;


        #region /// КОНСТРУКТОР. ЗАГРУЗКА. ЗАКРЫТИЕ /// 
        public BossForm()
        {
            InitializeComponent();
            _options = Options.GetInstance();
            _dataBase = DataBaseClass.GetInstance();
            _manhattanInfo = DataObjects.GetManhattanInfo();
        }

        private void BossForm_Load(object sender, EventArgs e)
        {
            // Заполнение Комбо бокс Время
            comboBox_time_H.Items.AddRange(MyTime.Hours.ToArray<object>());
            comboBox_time_M.Items.AddRange(MyTime.Minutes.ToArray<object>());
            comboBox_time_H.SelectedIndex = 0;
            comboBox_time_M.SelectedIndex = 0;

            //Заполнение Лист Вью Расписание
            MyListViewEx.MaximizeLastColumn(listView_schedule);
            MyListViewEx.AddScheduleNotes(listView_schedule, _manhattanInfo.Schedule);

            //Заполнение Лист Вью Список Тренеров
            MyListViewEx.MaximizeFirstColumn(listView_Tren);
            MyListViewEx.AddNotes(listView_Tren, _manhattanInfo.Treners.Select(x => x.Name).ToList());

            //Заполнение Лист Вью Список Админов
            MyListViewEx.MaximizeFirstColumn(listView_Admins);
            MyListViewEx.AddNotes(listView_Admins, _manhattanInfo.Admins.Select(x => x.Name).ToList());
        }
        private void BossForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PwdForm.LockPassword();
        }

        #endregion

        #region /// ОБРАБОТЧИКИ ///
        private void BossForm_SizeChanged(object sender, EventArgs e)
        {
            MyListViewEx.MaximizeLastColumn(listView_schedule);
            MyListViewEx.MaximizeFirstColumn(listView_Tren);
            MyListViewEx.MaximizeFirstColumn(listView_Admins);
        }

        private void button_add_sched_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_nameTren.Text))
            {
                MessageBox.Show("Введите Название!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var time = new MyTime($"{comboBox_time_H.Text}:{comboBox_time_M.Text}");
            var sch = new ScheduleNote(time, textBox_nameTren.Text);
            bool isSuccess = Logic.SchedulesAdd2DataBase(time, sch);
            if (isSuccess) MyListViewEx.AddScheduleNote(listView_schedule, sch);
        }


        private void listView_schedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedListViewItem = new ListView.SelectedListViewItemCollection(listView_schedule);

            bool isSuccess = MyListViewEx.GetSelectedItems(listView_schedule, ref selectedListViewItem);

            // ДеАктивация/Активация кнопки Удалить из расписания
            button_remove_sched.Enabled = isSuccess;

            if (!isSuccess) return; //выход Если ничего не выбрано

            var itemRow = MyListViewEx.GetSelectedText(listView_schedule);
            if (itemRow == null) return;
            // Отображаем выбранный элемент в окне редактирования
            comboBox_time_H.Text = itemRow[0].Split(':')[0];
            comboBox_time_M.Text = itemRow[0].Split(':')[1];
            textBox_nameTren.Text = itemRow[1];
        }

        private void button_remove_sched_Click(object sender, EventArgs e)
        {
            var itemRow = MyListViewEx.GetSelectedText(listView_schedule);
            if (itemRow == null) return;

            string selectedTime = itemRow[0];
            string name = itemRow[1];

            Logic.SchedulesRemoveDataBase(selectedTime, name);
            MyListViewEx.RemoveSelectedItem(listView_schedule);
        }
        private void button_AddEmploee_Click(object sender, EventArgs e)
        {
            // Входная проверка
            if (string.IsNullOrEmpty(textBox_FiO.Text) || string.IsNullOrWhiteSpace(textBox_FiO.Text))
            {
                MessageBox.Show("Введите Имя работника", "Не корректные данные", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            var empl = GetCurrentEmploeeInfo();
            bool isSuccess = Logic.EmployeeAdd2DataBase(empl);

            if (!isSuccess) return; // Если не добаавили в базу работника(Уже существует). Выходим

            // В какой лист добавлять. Тренер или Админ
            ListView lv = (empl.IsTrener) ? listView_Tren : listView_Admins;
            // Добавляем в список
            MyListViewEx.AddNote(lv, empl.Name);
        }

        private void maskedTextBox_phone_TextChanged(object sender, EventArgs e)
        {
            //var tb = (MaskedTextBox)sender;
            //_editedPhone = tb.Text;
            //  Methods.SetControlBackColor(tb, _editedPhone, _person.Phone);
        }

        private void listView_Tren_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedListViewItem = new ListView.SelectedListViewItemCollection((ListView)sender);

            var isSuccess = MyListViewEx.GetSelectedItems((ListView)sender, ref selectedListViewItem);

            // ДеАктивация/Активация кнопки Удалить из расписания
            button_Remove_Trener.Enabled = isSuccess;

            if (!isSuccess) return; //выход Если ничего не выбрано

            var itemRow = MyListViewEx.GetSelectedText((ListView)sender);
            if (itemRow == null) return;

            // Отображаем выбранный элемент в окне редактирования
            radioButton_tren.Checked = true;
            textBox_FiO.Text = itemRow[0];
            var ph = _manhattanInfo.Treners.Find((x => x.Name.Equals(textBox_FiO.Text))).Phone;
            maskedTextBox_phone.Text = ph;
        }

        private void listView_Admin_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedListViewItem = new ListView.SelectedListViewItemCollection((ListView)sender);

            var isSuccess = MyListViewEx.GetSelectedItems((ListView)sender, ref selectedListViewItem);

            // ДеАктивация/Активация кнопки Удалить из расписания
            button_Remove_Admin.Enabled = isSuccess;

            if (!isSuccess) return; //выход Если ничего не выбрано

            var itemRow = MyListViewEx.GetSelectedText((ListView)sender);
            if (itemRow == null) return;
          
            // Отображаем выбранный элемент в окне редактирования
            radioButton_adm.Checked = true;
            textBox_FiO.Text = itemRow[0];
            var ph = _manhattanInfo.Admins.Find((x => x.Name.Equals(textBox_FiO.Text))).Phone;
            maskedTextBox_phone.Text = ph;
        }

        private void button_Remove_Trener_Click(object sender, EventArgs e)
        {
            var itemRow = MyListViewEx.GetSelectedText(listView_Tren);
            if (itemRow == null) return;

            string name = itemRow[0];

            Logic.EmployeeRemoveDataBase(name,true);
            MyListViewEx.RemoveSelectedItem(listView_Tren);
        }

        private void button_Remove_Admin_Click(object sender, EventArgs e)
        {
            var itemRow = MyListViewEx.GetSelectedText(listView_Admins);
            if (itemRow == null) return;

            string name = itemRow[0];

            Logic.EmployeeRemoveDataBase(name, false);
            MyListViewEx.RemoveSelectedItem(listView_Admins);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            GetRadioBstate();
        }
       
        #endregion

        #region /// МЕТОДЫ ///
        private bool GetRadioBstate()
        {
            _employee.IsTrener = radioButton_tren.Checked;
            return _employee.IsTrener;
        }
        private Employee GetCurrentEmploeeInfo()
        {
            // Сбор информации о текущем Работнике
            _employee.IsTrener = GetRadioBstate();
            _employee.Name = string.IsNullOrEmpty(Methods.PrepareName(textBox_FiO.Text))?textBox_FiO.Text: Methods.PrepareName(textBox_FiO.Text);
           
            _employee.Phone = maskedTextBox_phone.Text;
            // Обновляем имя на форме если оно написано с ошибками
            if (!_employee.Name.Equals(textBox_FiO.Text)) textBox_FiO.Text = _employee.Name;

            return _employee;
        }


        #endregion

        private void groupBox_Tren_Leave(object sender, EventArgs e)
        {
            button_Remove_Trener.Enabled = false;
        }

        private void groupBox_Admin_Leave(object sender, EventArgs e)
        {
            button_Remove_Admin.Enabled = false;
        }
    }
}
