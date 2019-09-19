﻿using PersonsBase.data;
using PersonsBase.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PBase
{
    // FIXME добавить пиктограммы и иконки везде в менюхах и на формах

    public delegate void MyListViewDelegate(string namePerson, WorkoutOptions workoutOptions);

    public partial class MainForm : Form
    {
        #region /// ОСНОВНЫЕ ОБЬЕКТЫ ///

        private readonly DataBaseClass _db = DataBaseClass.GetInstance();

        private SortedList<string, Person> UserList => DataBaseClass.GetListPersons();
        private readonly Dictionary<TypeWorkout, MyListViewDelegate> _listViewSelector; // Для заполнения 1 из 3х списков с Клиентами

        private Options _options; // Хранятся локальные настройки и параметры программы.
        private readonly Logic _logic;       // Логика и управляющие методы программы.
        private Photo _photo;
        private readonly Timer _time = new Timer();
        private int _totalPersonToday;

        #endregion

        #region /// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ///


        public MainForm()
        {
            InitializeComponent();
            _options = Options.GetInstance();
            _logic = Logic.GetInstance();
            _photo = new Photo();

            _listViewSelector = new Dictionary<TypeWorkout, MyListViewDelegate>
            {
                { TypeWorkout.Аэробный_Зал,AddToGroupList },
                { TypeWorkout.Персональная,AddToPersonalnList },
                { TypeWorkout.Тренажерный_Зал,AddToGymList }
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Methods.DeSerialize(ref _options, "Option.bin");

            // Подписка на события в пользовательской Базе Данных
            _db.ListChangedEvent += UpdateFindComboBoxMenu;  // Список клиентов в окне Поиска. Автоматически,когда изменяется самая главная коллекция с клиентами.
            _db.ListChangedEvent += UpdateUsersCountTextBox; // Счетчик пользователей
            _db.ListChangedEvent += UpdateBirthDateComboBox; // Поле Сегодняшних Дней рождений

            _db.OnListChanged(); // Событие запускающееся при изменении количества Клиентов в списке.

            comboBox_BDay.SelectedIndexChanged += comboBox_BDay_SelectedIndexChanged;
            PwdForm.LockChangedEvent += PwdForm_LockChangedEvent;

            _logic.VisitEvent += AddPersonToTable;
            _logic.VisitEvent += UpdateDailyCounter;

            // Инициализация Таймера для Часов
            StartTimer();

            // Инициализация 3х Списков Клиентов
            //   Изменение размера приводит к увеличению последней колонки до максимума
            MyListViewEx.MaximizeLastColumn(listView_Gym_Zal);
            MyListViewEx.MaximizeLastColumn(listView_Group);
            MyListViewEx.MaximizeLastColumn(listView_Personal);
         
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Сохраняем настройки. 

            Methods.Serialize(_options, "Option.bin");
        }


        #endregion

        #region /// МЕТОДЫ ///

        private void StartTimer()
        {
            _time.Interval = 1000;
            _time.Tick += _time_ClockTick;
            _time.Start();
        }

        private void AddToGymList(string namePerson, WorkoutOptions arg)
        {
            MyListViewEx.AddNameTime(listView_Gym_Zal, namePerson, true);
            MyListViewEx.AlternateColors(listView_Gym_Zal);
        }
        private void AddToGroupList(string namePerson, WorkoutOptions arg)
        {
            var groupName = arg.GroupInfo.scheduleNote.GetTimeAndNameStr();
            MyListViewEx.AddNameTime(listView_Group, groupName, namePerson, false);
        }
        private void AddToPersonalnList(string namePerson, WorkoutOptions arg)
        {
            MyListViewEx.AddNameTime(listView_Personal, arg.PersonalTrener.Name, namePerson, true);
        }

        #endregion

        #region /// ОБРАБОТЧИКИ ///

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            MyListViewEx.MaximizeLastColumn(listView_Gym_Zal);
            MyListViewEx.MaximizeLastColumn(listView_Group);
            MyListViewEx.MaximizeLastColumn(listView_Personal);
        }

        private void AddPersonToTable(string name, WorkoutOptions arg)
        {
            _listViewSelector[arg.TypeWorkout].Invoke(name, arg);
        }
        private void UpdateDailyCounter(string arg1, WorkoutOptions arg2)
        {
            _totalPersonToday++;
            textBox_PeopleForDay.Text = _totalPersonToday.ToString();
        }

        private void PwdForm_LockChangedEvent()
        {
            // MessageBox.Show("Изменен Пароль В гл Форме");
        }
        private void UpdateBirthDateComboBox(object sender, EventArgs e)
        {
            Action myDelegate = delegate
            {
                comboBox_BDay.Items.Clear();
                label4.Text = "Дней Рождения: 0";
                var array = UserList.Values.Where(c => c.BirthDate.ToString("M") == DateTime.Today.ToString("M")).Select(c => c.Name).ToArray<object>();
                if (array.Length != 0)
                {
                    comboBox_BDay.Items.AddRange(array);
                    comboBox_BDay.SelectedIndex = 0;
                    label4.Text = "Дней Рождения: " + array.Length.ToString();
                }
                Invalidate();
            };

            if (InvokeRequired) Invoke(myDelegate);
            else myDelegate();
        }
        private void UpdateFindComboBoxMenu(object sender, EventArgs arg)
        {
            Action myDelegate = delegate
            {
                сomboBox_UserList.Items.Clear();

                сomboBox_UserList.Items.AddRange(UserList.Values.Select(c => c.Name).ToArray<object>());
                Invalidate();
            };

            if (InvokeRequired) Invoke(myDelegate);
            else myDelegate();
        }
        public void ClearFindCombo()
        {
            Action myDelegate = () => сomboBox_UserList.SelectedText = "";
            if (InvokeRequired)
            {
                Invoke(myDelegate);
            }
            else
            {
                myDelegate();
            }
        }
        private void UpdateUsersCountTextBox(object sender, EventArgs arg)
        {
            textBox1.Text = DataBaseClass.GetNumberOfPersons().ToString();
            Invalidate();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            FormsRunner.RunClientForm(сomboBox_UserList.SelectedItem.ToString());

        }
        private void comboBox_BDay_SelectedIndexChanged(object sender, EventArgs e)
        {

            FormsRunner.RunClientForm(comboBox_BDay.SelectedItem.ToString());

        }
        private void _time_ClockTick(object sender, EventArgs e)
        {
            label_Time.Text = Methods.ClockFormating();
        }
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void конфигураторОтчетовToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void добавитьКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.CreatePerson();
            //_db.PersonAdd(new Person("Трактирщик Мо"));
            //_db.PersonAdd(new Person("Гомер Симпсон"));
        }

        private void руководительToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Logic.AccessRoot();
            if (PwdForm.IsPassUnLocked())
            {
                var result = FormsRunner.CreateBossForm();
            }


            // FIXME  Выбор текущего администратора
        }



        #endregion

        private void listView_Gym_Zal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
