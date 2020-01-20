﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class MainForm : Form
    {
        #region /// ОСНОВНЫЕ ОБЬЕКТЫ ///

        private readonly DataBaseLevel _dataB = DataBaseLevel.GetInstance();
        private SortedList<string, Person> PersonsList
        {
            get { return DataBaseLevel.GetListPersons(); }
        }
        private readonly Timer _time = new Timer();
        private readonly Logic _logic = Logic.GetInstance();
        #endregion

        #region /// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ///

        public MainForm()
        {
            InitializeComponent();
            Options.LoadProperties(); // Загрузка пользовательских настроек
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartTimer(); // Инициализация Таймера для Часов

            // Подписка на события в пользовательской Базе Данных
            _dataB.ListChangedEvent += UpdateFindComboBoxMenu; // Список клиентов в окне Поиска. Автоматически,когда изменяется самая главная коллекция с клиентами.
            _dataB.ListChangedEvent += SetNumberTotalPersons; // Счетчик пользователей
            _dataB.ListChangedEvent += UpdateBirthDateComboBox; // Поле Сегодняшних Дней рождений

            _dataB.OnListChanged(); // Событие запускающееся при изменении количества Клиентов в списке.

            comboBox_BDay.SelectedIndexChanged += comboBox_BDay_SelectedIndexChanged;// Открытие карточки клиента
            PwdForm.LockChangedEvent += PwdForm_LockChangedEvent;

            DailyVisits.NumberDailyPersonsEvent += DailyVisits_NumberDailyPersonsEvent;// Счетчик пользователей
            DailyVisits.GymListChangedEvent += DailyVisits_GymCollectionChanged;

           // _logic.LoadLastSession();

            // Изменение размера приводит к увеличению последней колонки до максимума
            MyListViewEx.MaximizeLastColumn(listView_Gym_Zal);
            MyListViewEx.MaximizeLastColumn(listView_Group);
            MyListViewEx.MaximizeLastColumn(listView_Personal);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options.SaveProperties(); // Сохранение пользовательских настроек
            _logic.SaveCurentSession();// Сериализация текущих списков посещений 

            MyFile.ExportToExcel(DataBaseM.CreatePersonsTable(), false); // Автоматическое Сохранение в Excel всей базы на всякий случай
            if (MessageBox.Show(@"Вы хотите закрыть приложение?", @"Завершение работы", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region /// МЕТОДЫ ///
        private void StartTimer()
        {
            _time.Interval = 1000;
            _time.Tick += _time_ClockTick;
            _time.Start();
        }
        public void ClearFindCombo()
        {
            void MyDelegate() => сomboBox_PersonsList.SelectedText = "";
            if (InvokeRequired)
            {
                Invoke((Action)MyDelegate);
            }
            else
            {
                MyDelegate();
            }
        }

        private void DailyVisits_NumberDailyPersonsEvent(object sender, int e)
        {
            SetNumberDailyPersons(e);
        }

        private void DailyVisits_GymCollectionChanged()
        {
            var daily = _logic?.GetDailyVisitsObj().ListViewGymList;
            if (daily == null || daily.Count == 0) return;

            var item = daily.Last();

            MyListViewEx.AddNote(listView_Gym_Zal, item.Time, item.Name);
        }


        #endregion

        #region /// ОБРАБОТЧИКИ ///

        /// <summary>
        /// Записывает в текстовое поле число с текущим ежедневным количеством посетивших Клиентов.
        /// Потокобезопасный метод.
        /// </summary>
        /// <param name="numPersons"></param>
        public void SetNumberDailyPersons(int numPersons)
        {
            void MyDelegate() => textBox_PeopleForDay.Text = numPersons.ToString();
            if (InvokeRequired)
            {
                Invoke((Action)MyDelegate);
            }
            else
            {
                MyDelegate();
            }
        }

        private void SetNumberTotalPersons(object sender, EventArgs arg)
        {
            textBox_Total_persons.Text = DataBaseLevel.GetNumberOfPersons().ToString();
            Invalidate();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            MyListViewEx.MaximizeLastColumn(listView_Gym_Zal);
            MyListViewEx.MaximizeLastColumn(listView_Group);
            MyListViewEx.MaximizeLastColumn(listView_Personal);
        }

        private void PwdForm_LockChangedEvent()
        {
            // MessageBox.Show("Изменен Пароль В гл Форме");
        }

        private void UpdateBirthDateComboBox(object sender, EventArgs e)
        {
            void MyDelegate()
            {
                comboBox_BDay.Items.Clear();
                label4.Text = @"Дней Рождения: 0";
                var array = PersonsList.Values.Where(c => c.BirthDate.ToString("M") == DateTime.Today.ToString("M"))
                    .Select(c => c.Name)
                    .ToArray<object>();
                if (array.Length != 0)
                {
                    comboBox_BDay.Items.AddRange(array);
                    comboBox_BDay.SelectedIndex = 0;
                    label4.Text = @"Дней Рождения: " + array.Length.ToString();
                }

                Invalidate();
            }

            if (InvokeRequired) Invoke((Action)MyDelegate);
            else MyDelegate();
        }

        private void UpdateFindComboBoxMenu(object sender, EventArgs arg)
        {
            void MyDelegate()
            {
                сomboBox_PersonsList.Items.Clear();

                try
                {
                    сomboBox_PersonsList.Items.AddRange(PersonsList.Values.Select(c => c.Name).ToArray<object>());
                    Invalidate();
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            if (InvokeRequired) Invoke((Action)MyDelegate);
            else MyDelegate();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сomboBox_PersonsListSelectedIndexChanged(object sender, EventArgs e)
        {
            Logic.OpenPersonCard(сomboBox_PersonsList.SelectedItem.ToString());
        }

        private void comboBox_BDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logic.OpenPersonCard(comboBox_BDay.SelectedItem.ToString());
        }

        private void _time_ClockTick(object sender, EventArgs e)
        {
            label_Time.Text = Logic.ClockFormating();
        }

        private void добавитьКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.CreatePerson();
        }

        private void руководительToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Logic.AccessRootUser();
            if (PwdForm.IsPassUnLocked())
            {
                FormsRunner.CreateBossForm();
            }

            // FIXME  Выбор текущего администратора
        }

        private void удалитьКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.RemovePerson();
        }

        private void списокКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.SelectPerson();
        }

        private void продатьАбонементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.SellAbonement();
        }

        private void SellButtonMenuItem_Click(object sender, EventArgs e)
        {
            Logic.SellAbonement();
        }

        private void списокКлиентовToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Logic.SelectPerson();
        }

        private void сохранитьВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataBaseLevel.GetNumberOfPersons() == 0) MessageBox.Show(@"В Базе нет клиентов");

            var table = DataBaseM.CreatePersonsTable();
            MyFile.ExportToExcel(table, true);
            //Сохраним и Базу данных
            DataBaseLevel.GetInstance().SerializeObjects();
        }

        private void сканироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.BarCodeOpen();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.CreateReport();
        }
        #endregion

    }
}
