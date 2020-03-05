using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly DataBaseLevel _dataB = DataBaseLevel.GetInstance();// Создаем все обьекты
        private readonly DailyVisits _dailyVisits = DailyVisits.GetInstance();
        private readonly Timer _time = new Timer();
        private static SortedList<string, Person> PersonsList
        {
            get { return DataBaseLevel.GetPersonsList(); }
        }
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
            DataBaseLevel.PersonsListChangedEvent += UpdateFindComboBoxMenu; // Список клиентов в окне Поиска. Автоматически,когда изменяется самая главная коллекция с клиентами.
            DataBaseLevel.PersonsListChangedEvent += SetNumberTotalPersons; // Счетчик пользователей
            DataBaseLevel.PersonsListChangedEvent += UpdateBirthDateComboBox; // Поле Сегодняшних Дней рождений

            DataBaseLevel.OnListChanged(); // Событие запускающееся при изменении количества Клиентов в списке.
            PwdForm.LockChangedEvent += PwdForm_LockChangedEvent;

            // События для Колонок и  т д
            DailyVisits.NumberDailyPersonsEvent += DailyVisits_NumberDailyPersonsEvent;// Счетчик пользователей
            DailyVisits.GymListChangedEvent += DailyVisits_GymCollectionChanged;       // Тренажерка
            DailyVisits.PersonalListChangedEvent += DailyVisits_PersonalListChangedEvent; // Персоналки
            DailyVisits.AerobListChangedEvent += DailyVisits_AerobListChangedEvent;       // Аэробный
            DailyVisits.MiniGroupListChangedEvent += DailyVisits_MiniGroupListChangedEvent; // Минигруппы

            _dailyVisits.LoadLastSession();

            // Изменение размера приводит к увеличению последней колонки до максимума
            MyListViewEx.MaximizeLastColumn(listView_Gym_Zal);
            MyListViewEx.MaximizeLastColumn(listView_Group);
            MyListViewEx.MaximizeLastColumn(listView_Personal);
            MyListViewEx.MaximizeLastColumn(listView_MiniGroup);

            // Показать окно выбора Администратора
            Logic.SelectCurentAdmin();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options.SaveProperties(); // Сохранение пользовательских настроек

            _dailyVisits.SaveCurentSession();// Сериализация текущих списков посещений 
            //Сохранение в Эксель
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
            var daily = _dailyVisits.GymList;
            if (daily == null || daily.Count == 0) return;

            var item = daily.Last();

            MyListViewEx.AddNote(listView_Gym_Zal, item.Time, item.Name);
        }
        private void DailyVisits_PersonalListChangedEvent()
        {
            var dailyList = _dailyVisits.PersonalList;
            if (dailyList == null || dailyList.Count == 0) return;

            var lastVisit = dailyList.Last();
            var newGroupName = string.IsNullOrEmpty(lastVisit.TrenerName) ? "Имя неизвестно" : lastVisit.TrenerName;

            MyListViewEx.AddItemAndGroup(listView_Personal, newGroupName, lastVisit.NamePerson, false);
        }
        private void DailyVisits_AerobListChangedEvent()
        {
            var dailyList = _dailyVisits.AerobList;
            if (dailyList == null || dailyList.Count == 0) return;

            var lastVisit = dailyList.Last();
            var newGroupName = string.IsNullOrEmpty(lastVisit.GroupTimeName) ? "Имя неизвестно" : lastVisit.GroupTimeName;

            MyListViewEx.AddItemAndGroup(listView_Group, newGroupName, lastVisit.NamePerson, false);
        }
        private void DailyVisits_MiniGroupListChangedEvent()
        {
            var dailyList = _dailyVisits.MiniGroupList;
            if (dailyList == null || dailyList.Count == 0) return;

            var lastVisit = dailyList.Last();
            var newGroupName = string.IsNullOrEmpty(lastVisit.TrenerName) ? "Имя неизвестно" : lastVisit.TrenerName;

            MyListViewEx.AddItemAndGroup(listView_MiniGroup, newGroupName, lastVisit.NamePerson, false);
        }
        #endregion

        #region /// ОБРАБОТЧИКИ ///

        /// <summary>
        /// Записывает в текстовое поле число с текущим ежедневным количеством посетивших Клиентов.
        /// Потокобезопасный метод.
        /// </summary>
        /// <param name="numPersons"></param>
        private void SetNumberDailyPersons(int numPersons)
        {
            void MyDelegate() => label_PeopleForDay.Text = numPersons.ToString();
            if (InvokeRequired)
            {
                Invoke((Action)MyDelegate);
            }
            else
            {
                MyDelegate();
            }
        }

        private void SetNumberTotalPersons(EventArgs arg)
        {
            label_Total_persons.Text = DataBaseLevel.GetNumberOfPersons().ToString();
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

        private void UpdateBirthDateComboBox(EventArgs e)
        {
            comboBox_BDay.SelectedIndexChanged -= comboBox_BDay_SelectedIndexChanged_1;
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
            comboBox_BDay.SelectedIndexChanged += comboBox_BDay_SelectedIndexChanged_1;
        }

        private void UpdateFindComboBoxMenu(EventArgs arg)
        {
            void MyDelegate()
            {
                сomboBox_PersonsList.Items.Clear();

                try
                {
                    if (PersonsList != null)
                        сomboBox_PersonsList.Items.AddRange(PersonsList?.Values.Select(c => c.Name).ToArray<object>());
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
        }

        private void удалитьКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.AccessRootUser();
            if (PwdForm.IsPassUnLocked())
            {
                Logic.RemovePerson();
            }
            PwdForm.LockPassword();
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
            DataBaseLevel.SerializeObjects();
        }

        private void сканироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.BarCodeOpen();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.CreateReport();
        }
        private void comboBox_BDay_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Logic.OpenPersonCard(comboBox_BDay.SelectedItem.ToString());
        }

        private void администраторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.SelectCurentAdmin();
        }


        #endregion


        private void listView_Gym_Zal_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyData == Keys.Delete) // Если нажат 
            {
                Logic.AccessRootUser();
                var timeName = MyListViewEx.GetSelectedText((ListView)sender);
                // Удаление из журнала
                DailyVisits.GetInstance().RemoveFromVisitsLog(timeName[1], TypeWorkout.Тренажерный_Зал, timeName[0]); // itemSel[0] -тут это время
                // Удаление с экрана
                MyListViewEx.RemoveSelectedItem((ListView)sender);
                Logic.AccessRootUser();
            }
        }
    }
}
