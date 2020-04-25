using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

            // Всплывающие подсказки
            toolTip1.SetToolTip(tableLayoutPanel1, "Для удаления записы, выделите и нажмите клавишу Delete на клавиатуре");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options.SaveProperties(); // Сохранение пользовательских настроек

            _dailyVisits.SaveCurentSession();// Сериализация текущих списков посещений 

            // База клиентов сохраняется автоматически, в деструкторе класса DataBaseLevel

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
            if (DataBaseLevel.GetNumberOfPersons() == 0)
            {
                MessageBox.Show(@"В Базе нет клиентов");
                return;
            }

            //Сохраним и Базу данных
            Logic.SaveEverithing();
            // Сохранение в Excel
            var table = DataBaseM.CreatePersonsTable();
            MyFile.ExportToExcel(table, true);
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
        private void listView_Gym_Zal_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DelSelectedItem(sender, e, TypeWorkout.Тренажерный_Зал);
        }

        private void listView_Personal_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DelSelectedItem(sender, e, TypeWorkout.Персональная);
        }

        private void listView_Group_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DelSelectedItem(sender, e, TypeWorkout.Аэробный_Зал);
        }

        private void listView_MiniGroup_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DelSelectedItem(sender, e, TypeWorkout.МиниГруппа);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Изменять номер сборки тут
            // C:\Work\MBase\MFClub\PersonsBase\Properties\AssemblyInfo.cs

            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName();

            Version version = assemblyName.Version;

            MessageBox.Show($@"Major Version: {version.Major} " + "\r\n" +
                            $@"Minor Version: {version.Minor} " + "\r\n" +
                            $@"Build Number: {version.Build}" + "\r\n" +
                            $@"Revision: {version.Revision}" + "\r\n");

            // // Или так ещё можно
            //Assembly thisAssem = typeof(MainForm).Assembly;
            //AssemblyName thisAssemName = thisAssem.GetName();
            //Version ver = thisAssemName.Version;
            //MessageBox.Show($"This is version {ver} of {thisAssemName.Name}.");

        }

        /// <summary>
        /// Проверяет если введен пароль.
        /// Удаляет посещение из списков на экране
        /// Удаляет посещение из сохраненной базы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="typeWorkout"></param>
        private static void DelSelectedItem(object sender, PreviewKeyDownEventArgs e, TypeWorkout typeWorkout)
        {
            if (e.KeyData != Keys.Delete) return;
            Logic.AccessRootUser();
            if (!PwdForm.IsPassUnLocked()) return;
            var name = MyListViewEx.GetSelectedText((ListView)sender);
            // Удаление из журнала
            DailyVisits.GetInstance().RemoveFromVisitsLog(name[1], typeWorkout);
            // Удаление с экрана
            MyListViewEx.RemoveSelectedItem((ListView)sender);
            PwdForm.LockPassword();
        }

        // Открытие карточки клиента по двойной мышке
        private static void OpenSelectedItem(object sender)
        {
            try
            {
                var selectedItem = MyListViewEx.GetSelectedText((ListView)sender);
                // Состоит из 2х элементов. Первый либо время либо пусто
                var name = selectedItem[1];
                Logic.OpenPersonCard(name);
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Нельзя открыть карточку клиента. {e.Message}", @"Ошибка открытия", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView_Gym_Zal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenSelectedItem(sender);
        }

        private void listView_Personal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenSelectedItem(sender);
        }

        private void listView_Group_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenSelectedItem(sender);
        }

        private void listView_MiniGroup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenSelectedItem(sender);
        }




        #endregion

        #region /// Контекстное Меню

        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic.AccessRootUser();
            if (!PwdForm.IsPassUnLocked()) return;

            try
            {
                var control = contextMenuStrip1.SourceControl;
                var selectedItem = MyListViewEx.GetSelectedText((ListView)control);
                // Состоит из 2х элементов. Первый либо время либо пусто
                var name = selectedItem[1];

                var typeW = TypeWorkout.Тренажерный_Зал;
                switch (control.Name)
                {
                    case "listView_Gym_Zal":
                        typeW = TypeWorkout.Тренажерный_Зал;
                        break;
                    case "listView_Personal":
                        typeW = TypeWorkout.Персональная;
                        break;
                    case "listView_Group":
                        typeW = TypeWorkout.Аэробный_Зал;
                        break;
                    case "listView_MiniGroup":
                        typeW = TypeWorkout.МиниГруппа;
                        break;
                    default:
                        break;
                }

                // Удаление из журнала
                DailyVisits.GetInstance().RemoveFromVisitsLog(name, typeW);
                // Удаление с экрана
                MyListViewEx.RemoveSelectedItem((ListView)control);
                Logic.SaveEverithing();
                PwdForm.LockPassword();
            }
            catch (Exception)
            {
                MessageBox.Show($@"Нельзя удалить посещение клиента. ", @"Ошибка удаления в MainForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void открытьКарточкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var control = contextMenuStrip1.SourceControl;
                var selectedItem = MyListViewEx.GetSelectedText((ListView)control);
                // Состоит из 2х элементов. Первый либо время либо пусто
                var name = selectedItem[1];
                Logic.OpenPersonCard(name);
            }
            catch (Exception)
            {
                MessageBox.Show($@"Нельзя открыть карточку клиента. ", @"Ошибка открытия в MainForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void listView_Gym_Zal_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = listView_Gym_Zal.GetItemAt(e.X, e.Y);
                if (item == null) return;
                item.Selected = true;
                contextMenuStrip1.Show(listView_Gym_Zal, e.Location);
            }
        }

        private void listView_Personal_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = listView_Personal.GetItemAt(e.X, e.Y);
                if (item == null) return;
                item.Selected = true;
                contextMenuStrip1.Show(listView_Personal, e.Location);
            }
        }

        private void listView_Group_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = listView_Group.GetItemAt(e.X, e.Y);
                if (item == null) return;
                item.Selected = true;
                contextMenuStrip1.Show(listView_Group, e.Location);
            }
        }

        private void listView_MiniGroup_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = listView_MiniGroup.GetItemAt(e.X, e.Y);
                if (item == null) return;
                item.Selected = true;
                contextMenuStrip1.Show(listView_MiniGroup, e.Location);
            }
        }
        #endregion
    }
}
