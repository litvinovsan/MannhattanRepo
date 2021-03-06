﻿using System;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.myStd;

namespace PersonsBase.View
{

    public partial class BossForm : Form
    {
        private readonly ManhattanInfo _manhattanInfo;
        private Employee _employee;


        #region /// КОНСТРУКТОР. ЗАГРУЗКА. ЗАКРЫТИЕ /// 
        public BossForm()
        {
            InitializeComponent();
            _manhattanInfo = DataBaseLevel.GetManhattanInfo();
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

            // Заполнение вкладки Настроек
            checkBox_Passp_Drive.Checked = Options.CheckPasspAndDriveId;
            checkBox_SimpsonPhoto.Checked = Options.SimpsonsPhoto;
            checkBox_CorrectOnCreateAbon.Checked = Options.AbonIsCorrectable;

            // Период действия абонемента в месяцах.
          //  var nums = Enumerable.Range(1, 12).Select(x => (object)x).ToArray(); // отображаются в комбобоксе
          //  comboBox_months.Items.AddRange(nums);
          //  comboBox_months.SelectedIndex = --Options.ValidPeriodInMonth; // декремент т.к. у нас массив начинается с 1

        }
        private void BossForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PwdForm.LockPassword();
            Logic.SaveEverithing();
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
                MessageBox.Show(@"Введите Название!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var time = new MyTime($"{comboBox_time_H.Text}:{comboBox_time_M.Text}");
            var sch = new ScheduleNote(time, textBox_nameTren.Text);
            var isSuccess = Logic.SchedulesAdd2DataBase(time, sch);
            if (isSuccess) MyListViewEx.AddScheduleNote(listView_schedule, sch);
        }

        private void listView_schedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedListViewItem = new ListView.SelectedListViewItemCollection(listView_schedule);

            var isSuccess = MyListViewEx.GetSelectedItems(listView_schedule, ref selectedListViewItem);

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

            var selectedTime = itemRow[0];
            var name = itemRow[1];

            Logic.SchedulesRemoveDataBase(selectedTime, name);
            MyListViewEx.RemoveSelectedItem(listView_schedule);
        }
        private void button_AddEmploee_Click(object sender, EventArgs e)
        {
            // Входная проверка
            if (string.IsNullOrEmpty(textBox_FiO.Text) || string.IsNullOrWhiteSpace(textBox_FiO.Text))
            {
                MessageBox.Show(@"Введите Имя работника", @"Не корректные данные", MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }

            var empl = GetCurrentEmploeeInfo();
            var isSuccess = Logic.EmployeeAdd2DataBase(empl);

            if (!isSuccess) return; // Если не добаавили в базу работника(Уже существует). Выходим

            // В какой лист добавлять. Тренер или Админ
            var lv = empl.IsTrener ? listView_Tren : listView_Admins;
            // Добавляем в список
            MyListViewEx.AddNote(lv, empl.Name);
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
            var ph = _manhattanInfo.Treners.Find(x => x.Name.Equals(textBox_FiO.Text)).Phone;
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
            var ph = _manhattanInfo.Admins.Find(x => x.Name.Equals(textBox_FiO.Text)).Phone;
            maskedTextBox_phone.Text = ph;
        }

        private void button_Remove_Trener_Click(object sender, EventArgs e)
        {
            var itemRow = MyListViewEx.GetSelectedText(listView_Tren);
            if (itemRow == null) return;

            var name = itemRow[0];

            Logic.EmployeeRemoveDataBase(name, true);
            MyListViewEx.RemoveSelectedItem(listView_Tren);
        }

        private void button_Remove_Admin_Click(object sender, EventArgs e)
        {
            var itemRow = MyListViewEx.GetSelectedText(listView_Admins);
            if (itemRow == null) return;

            var name = itemRow[0];

            Logic.EmployeeRemoveDataBase(name, false);
            MyListViewEx.RemoveSelectedItem(listView_Admins);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            GetRadioBstate();
        }
        private void groupBox_Tren_Leave(object sender, EventArgs e)
        {
            button_Remove_Trener.Enabled = false;
            listView_Tren.SelectedIndices.Clear();
        }

        private void groupBox_Admin_Leave(object sender, EventArgs e)
        {
            button_Remove_Admin.Enabled = false;
            listView_Admins.SelectedIndices.Clear();
        }
        private void checkBox_Passp_Drive_CheckedChanged(object sender, EventArgs e)
        {
            Options.CheckPasspAndDriveId = checkBox_Passp_Drive.Checked;
        }

        private void checkBox_SimpsonPhoto_CheckedChanged(object sender, EventArgs e)
        {
            Options.SimpsonsPhoto = checkBox_SimpsonPhoto.Checked;
        }

        private void checkBox_CorrectOnCreateAbon_CheckedChanged(object sender, EventArgs e)
        {
            Options.AbonIsCorrectable = checkBox_CorrectOnCreateAbon.Checked;
        }

        private void comboBox_months_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_months.SelectedItem == null) return;
            var comboB = (ComboBox)sender;
            var months = int.Parse(comboB.SelectedItem.ToString());
        //    Options.ValidPeriodInMonth = months;
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
            _employee.Name = string.IsNullOrEmpty(Logic.PrepareName(textBox_FiO.Text)) ? textBox_FiO.Text : Logic.PrepareName(textBox_FiO.Text);

            _employee.Phone = maskedTextBox_phone.Text;
            // Обновляем имя на форме если оно написано с ошибками
            if (!_employee.Name.Equals(textBox_FiO.Text)) textBox_FiO.Text = _employee.Name;

            return _employee;
        }



        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            // Способ 1. Для проверки вручную.
            // var persons = DataBaseLevel.GetPersonsList().Values;
            // Dictionary<string, List<AbonementBasic>> resultDictionary = new Dictionary<string, List<AbonementBasic>>();
            //// Перебираем все абонементы и очередь абонементов. Добавляем в Коллекцию с архивом абонементов
            //foreach (var person in persons)
            //{
            //    resultDictionary.Add(person.Name, new List<AbonementBasic>());

            //    if (person.AbonementCurent != null)
            //        resultDictionary[person.Name].Add(person.AbonementCurent);

            //    if (person.AbonementsQueue != null && person?.AbonementsQueue.Count != 0)
            //    {
            //        foreach (var abonement in person?.AbonementsQueue)
            //        {
            //            // Do work
            //            resultDictionary[person.Name].Add(abonement);
            //        }
            //    }
            //}


            // Способ 2. Конвертер

            //// Очистка очереди
            //foreach (var person in persons)
            //{
               
            //    if (person.AbonementsQueue != null && person?.AbonementsQueue.Count != 0)
            //    {
            //        person.AbonementsQueue.Clear();
            //    }
            //}
        }

    }
}
