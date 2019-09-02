using PersonsBase.data;
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
        readonly DataBaseClass _db = DataBaseClass.GetInstance();
        private SortedList<string, Person> UserList => _db.GetListPersons();
        private Options _options; // Хранятся локальные настройки и параметры программы.
        private Logic _logic;       // Логика и управляющие методы программы.
        private Photo _photo;
        private Timer _time = new Timer();

        private Dictionary<TypeWorkout, MyListViewDelegate> ListViewSelector; // Для заполнения 1 из 3х списков с Клиентами

        #endregion

        #region /// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ///


        public MainForm()

        {
            InitializeComponent();
            _options = Options.GetInstance();
            _logic = Logic.GetInstance();
            _photo = new Photo();

            ListViewSelector = new Dictionary<TypeWorkout, MyListViewDelegate>
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

            // Инициализация Таймера для Часов
            StartTimer();

            #region Temp
            // FIXME временная инициализация полей
            //var admins = _db.GetManhattanInfo().Admins;
            //var treners = _db.GetManhattanInfo().Treners;
            //var schedule = _db.GetManhattanInfo().Schedule;
            //var curAdmin = _db.GetManhattanInfo().CurrentAdmin;

            //curAdmin = new Administrator("Администратор 1");
            ////
            //admins.Add(new Administrator("Администрато 1"));
            //admins.Add(new Administrator("Администрато 2"));
            //admins.Add(new Administrator("Администрато 3"));
            //admins.Add(new Administrator("Администрато 4"));

            ////
            //treners.Add(new Trener("Трене 1"));
            //treners.Add(new Trener("Трене 2"));
            //treners.Add(new Trener("Трене 3"));
            //treners.Add(new Trener("Трене 4"));


            //schedule.Add(new EntryInSchedule(new MyTime(8, 0), "Беговая"));
            //schedule.Add(new EntryInSchedule(new MyTime(11, 30), "Йога"));
            //schedule.Add(new EntryInSchedule(new MyTime(15, 0), "Растяжка"));
            //schedule.Add(new EntryInSchedule(new MyTime(20, 10), "Пампинг"));
            #endregion
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

        #endregion

        #region /// ОБРАБОТЧИКИ ///


        private void AddToGymList(string namePerson, WorkoutOptions arg)
        {
            MyListView.AddTextToList(listView_Gym_Zal, namePerson, true);
        }
        private void AddToGroupList(string namePerson, WorkoutOptions arg)
        {
            MyListView.AddTextToList(listView_Group, namePerson, true);

        }
        private void AddToPersonalnList(string namePerson, WorkoutOptions arg)
        {
            var currentGroups = MyListView.GetGroupsDict(listView_Personal);
            if (currentGroups.ContainsKey(arg.PersonalTrener.Name))
            {
                MyListView.AddTextToList(listView_Personal, currentGroups[arg.PersonalTrener.Name], namePerson, true);
            }
            else
            {

            }


        }

        private void AddPersonToTable(string name, PersonsBase.data.WorkoutOptions arg)
        {
            ListViewSelector[arg.TypeWorkout].Invoke(name, arg);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            listView_Gym_Zal.Items.Add("08:20");
            listView_Gym_Zal.Items.Add("  ");
            listView_Gym_Zal.Items.Add("Кроссфит");
            listView_Gym_Zal.Items.Add("ddddd");

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
            textBox1.Text = _db.GetNumberOfPersons().ToString();
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
            _db.PersonAdd(new Person("Трактирщик Мо"));
            _db.PersonAdd(new Person("Гомер Симпсон"));
        }

        private void руководительToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _logic.AccessRoot();
            // FIXME Создать форму Руководителя. Создание расписания 08:30 - Беговая
            // FIXME в форме руководителя Списки Тренеров и Администраторов
            // FIXME  Выбор текущего администратора
        }

        #endregion


    }
}
