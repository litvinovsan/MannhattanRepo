using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    // FIXME добавить пиктограммы и иконки везде в менюхах и на формах
    // FIXME использовать паттерн Мементо для сохранения списков посещений. https://shwanoff.ru/memento/#more-682

    public delegate void MyListViewDelegate(string namePerson, WorkoutOptions workoutOptions);

    public partial class MainForm : Form
    {
        #region /// ОСНОВНЫЕ ОБЬЕКТЫ ///

        private readonly DataBaseLevel _dataB = DataBaseLevel.GetInstance();

        private SortedList<string, Person> PersonsList
        {
            get { return DataBaseLevel.GetListPersons(); }
        }

        private readonly Dictionary<TypeWorkout, MyListViewDelegate> _visitorsListViewSelector; // Для заполнения 1 из 3х списков с Клиентами

        private Options _options; // Хранятся локальные настройки и параметры программы.
        private readonly Logic _logic;       // Логика и управляющие методы программы.
        private readonly Timer _time = new Timer();
        private int _totalPersonToday;

        #endregion

        #region /// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ///


        public MainForm()
        {
            InitializeComponent();
            _options = Options.GetInstance();
            _logic = Logic.GetInstance();

            // В зависимости от типа тренировки запускаются разные методы записи в один из трех столбцов
            _visitorsListViewSelector = new Dictionary<TypeWorkout, MyListViewDelegate>
            {
                { TypeWorkout.Аэробный_Зал, AddToGroupList },
                { TypeWorkout.Персональная, AddToPersonalnList },
                { TypeWorkout.Тренажерный_Зал, AddToGymList }
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SerializeClass.DeSerialize(ref _options, "Option.bin");

            // Подписка на события в пользовательской Базе Данных
            _dataB.ListChangedEvent += UpdateFindComboBoxMenu;  // Список клиентов в окне Поиска. Автоматически,когда изменяется самая главная коллекция с клиентами.
            _dataB.ListChangedEvent += UpdateUsersCountTextBox; // Счетчик пользователей
            _dataB.ListChangedEvent += UpdateBirthDateComboBox; // Поле Сегодняшних Дней рождений

            _dataB.OnListChanged(); // Событие запускающееся при изменении количества Клиентов в списке.

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

            SerializeClass.Serialize(_options, "Option.bin");
        }


        #endregion

        #region /// МЕТОДЫ ///

        private void StartTimer()
        {
            _time.Interval = 1000;
            _time.Tick += _time_ClockTick;
            _time.Start();
        }

        /// <summary>
        /// Добавляет персону в список Тренажерного зала
        /// </summary>
        /// <param name="namePerson"></param>
        /// <param name="arg"></param>
        private void AddToGymList(string namePerson, WorkoutOptions arg)
        {
            MyListViewEx.AddNameTime(listView_Gym_Zal, namePerson, true);
            // MyListViewEx.AlternateColors(listView_Gym_Zal); // Убрано пока чтобы небыло полосатости
        }
        // Добавляет в список Групповых тренировок
        private void AddToGroupList(string namePerson, WorkoutOptions arg)
        {
            if (arg.GroupInfo.ScheduleNote == null) return;
            var groupName = arg.GroupInfo.ScheduleNote.GetTimeAndNameStr();
            MyListViewEx.AddNameTime(listView_Group, groupName, namePerson, false);
        }
        private void AddToPersonalnList(string namePerson, WorkoutOptions arg)
        {
            string persTrenerName = (arg.PersonalTrener != null) ? arg.PersonalTrener.Name : "Имя неизвестно";
            MyListViewEx.AddNameTime(listView_Personal, persTrenerName, namePerson, true);
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
            _visitorsListViewSelector[arg.TypeWorkout].Invoke(name, arg);
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
                var array = PersonsList.Values.Where(c => c.BirthDate.ToString("M") == DateTime.Today.ToString("M")).Select(c => c.Name).ToArray<object>();
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
            void MyDelegate()
            {
                сomboBox_PersonsList.Items.Clear();

                сomboBox_PersonsList.Items.AddRange(PersonsList.Values.Select(c => c.Name).ToArray<object>());
                Invalidate();
            }

            if (InvokeRequired) Invoke((Action)MyDelegate);
            else MyDelegate();
        }
        public void ClearFindCombo()
        {
            Action myDelegate = () => сomboBox_PersonsList.SelectedText = "";
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
            textBox1.Text = DataBaseLevel.GetNumberOfPersons().ToString();
            Invalidate();
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
            label_Time.Text = Methods.ClockFormating();
        }
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void конфигураторОтчетовToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region MyRegion ПРИМЕР
            /*
                     /* СОЗДАНИЕ ОЧЕРЕДЕЙ ЗАПРОСОВ/ВЫБОРКИ
         
            IEnumerable<KeyValuePair<string, MergedRequirenments>> query;
            if (checkBox_fb_approved.Checked)
            {
                query =
                      from reqt in _mergedRequirenments
                      where !reqt.Value.FB_Status_New.Equals(reqt.Value.FB_Status_Old)
                      select reqt;
            }
            else
            {
                query = _mergedRequirenments.Select(c => c).OrderBy(x => x.Key);
            }

            //Approved only in new Ver Fb
            if (checkBox_fb_approvedNew.Checked)
            {
                query =
                    from reqt in query
                    where reqt.Value.FB_Status_New.Contains("Approved")
                    select reqt;
            }
            else
            {
                query =
                    from reqt in query
                    where !reqt.Value.FB_Text_Old.Equals(reqt.Value.FB_Text_New)
                    select reqt;
            }

            // Text fb Old != New
            if (checkBox_fbText_old_eq_new.Checked)
            {
                query =
                    from reqt in query
                    where reqt.Value.FB_Text_Old.Equals(reqt.Value.FB_Text_New)
                    select reqt;
            }
            else
            {
                query =
                    from reqt in query
                    where !reqt.Value.FB_Text_Old.Equals(reqt.Value.FB_Text_New)
                    select reqt;
            }

            var list = query.ToDictionary((x => x.Key), (c => c.Value));


               
                 */
            #endregion
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
                var result = FormsRunner.CreateBossForm();
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

        #endregion

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
    }
}
