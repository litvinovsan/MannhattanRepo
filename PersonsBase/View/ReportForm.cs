using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class ReportForm : Form
    {
        #region /// ПОЛЯ 
        // Список всех персон. Исходная коллекция со всеми клиентами
        private readonly SortedList<string, Person> _personsAll = DataBaseLevel.GetListPersons();

        // ВЫБОРКИ по параметрам
        private IEnumerable<KeyValuePair<string, Person>> _reqStatuses;
        private IEnumerable<KeyValuePair<string, Person>> _reqLastVisit;
        private IEnumerable<KeyValuePair<string, Person>> _reqPay;
        private IEnumerable<KeyValuePair<string, Person>> _reqAge;
        private IEnumerable<KeyValuePair<string, Person>> _reqGender;
        private IEnumerable<KeyValuePair<string, Person>> _reqAbonType;
        private IEnumerable<KeyValuePair<string, Person>> _reqTimeTren;
        private IEnumerable<KeyValuePair<string, Person>> _reqActivation;

        private const string NotMatter = "Не Важно";

        private readonly object[] _ages =
        {
            "До 30 лет",
            "От 30 до 40 лет",
            "От 40 лет"
        };

        private readonly object[] _activation =
        {
            "Активирован",
            "Не Активирован"
        };

        private readonly object[] _lastVisits =
        {
            NotMatter,
            "Больше 1 месяца"
        };
        #endregion

        public ReportForm()
        {
            InitializeComponent();

            // Инициализация всех группбоксов стартовыми значениями
            InitCBoxStatus();
            InitCBoxLastVisit();
            InitCheckedListBoxPay();
            InitCheckedListBoxAge();
            InitCheckedListBoxGender();
            InitCheckedListBoxTypeAbon();
            InitCheckedListBoxTimeTren();
            InitCheckedListBoxActivation();

            InitDataGridView();
        }

        #region /// МЕТОДЫ. СТАТУС КЛИЕНТА
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCBoxStatus()
        {
            var statuses = Enum.GetNames(typeof(StatusPerson)).ToArray<object>().ToList();
            statuses.Add(NotMatter);

            MyComboBox.Initialize(comboBox_Status, statuses.ToArray(), NotMatter);
        }

        private void comboBox_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Status.SelectedItem.ToString().Equals(NotMatter)) // Если не важен статус выводим всех элементов
            {
                _reqStatuses = _personsAll;
            }
            else
            {
                var status = MyComboBox.GetComboBoxValue<StatusPerson>(comboBox_Status);
                _reqStatuses = _personsAll.Where(x => x.Value?.Status == status);
            }

            ShowPersons(GetUpdatedRequests());
        }

        #endregion

        #region /// МЕТОДЫ. ПОСЛЕДНЕЕ ПОСЕЩЕНИЕ
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCBoxLastVisit()
        {
            comboBox_LastVisit.Items.Clear();
            MyComboBox.Initialize(comboBox_LastVisit, _lastVisits, _lastVisits[0]);
        }
        private void comboBox_LastVisit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lVisit = MyComboBox.GetComboBoxValue(comboBox_LastVisit);
            // Если последний визит не важен -выходим
            if (lVisit.Equals(_lastVisits[0]))
            {
                _reqLastVisit = _personsAll;
            }
            else
            {
                var dataInPast = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0)).Date;//Вычитаем 30 дней

                //Выборка из тех кто уже был в зале хоть один раз
                var personsWasInGym = _personsAll.Where(x => x.Value.JournalVisits.Count != 0);

                _reqLastVisit = personsWasInGym.Where(x =>
                    x.Value?.JournalVisits?.Last().DateTimeVisit.CompareTo(dataInPast) <= 0).ToList();
            }
            ShowPersons(GetUpdatedRequests());
        }
        #endregion

        #region /// МЕТОДЫ. ОПЛАТА
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCheckedListBoxPay()
        {
            checkedListBox_Pay.Items.Clear();
            var payNames = Enum.GetNames(typeof(Pay)).ToArray<object>();
            checkedListBox_Pay.Items.AddRange(payNames);
        }

        private void checkedListBox_Pay_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkedIndexes = checkedListBox_Pay.CheckedIndices;

            // Сортировка по этому признаку не важна. Содержит 2 поля(Оплачено, Не оплачено)
            if ((checkedIndexes.Count == 2) || (checkedIndexes.Count == 0))
            {
                _reqPay = _personsAll;
            }
            else
            {
                var payment = (MyCheckedListBox.IsChecked(checkedListBox_Pay, 0)) ? Pay.Не_Оплачено : Pay.Оплачено;
                _reqPay = _personsAll.Where(x => x.Value?.AbonementCurent?.PayStatus == payment);
            }

            MyCheckedListBox.ClearSelection(checkedListBox_Pay);
            ShowPersons(GetUpdatedRequests());
        }
        #endregion

        #region /// МЕТОДЫ. ВОЗРАСТ
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCheckedListBoxAge()
        {
            checkedListBox_Age.Items.Clear();
            checkedListBox_Age.Items.AddRange(_ages);
        }

        private void checkedListBox_Age_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkedIndexes = checkedListBox_Age.CheckedIndices;

            IEnumerable<KeyValuePair<string, Person>> r1 = new List<KeyValuePair<string, Person>>();
            IEnumerable<KeyValuePair<string, Person>> r2 = new List<KeyValuePair<string, Person>>();
            IEnumerable<KeyValuePair<string, Person>> r3 = new List<KeyValuePair<string, Person>>();

            if ((checkedIndexes.Count != 3) && (checkedIndexes.Count != 0))
            {
                // До 30
                if (MyCheckedListBox.IsChecked(checkedListBox_Age, 0))
                {
                    var data = DateTime.Now.AddYears(-30); // Дата проверки для 30 летних
                    r1 = _personsAll.Where(x => x.Value?.BirthDate.Date.CompareTo(data) >= 0);
                }

                // 30 - 40
                if (MyCheckedListBox.IsChecked(checkedListBox_Age, 1))
                {
                    var dataFrom = DateTime.Now.AddYears(-40);
                    var dataTo = DateTime.Now.AddYears(-30);
                    r2 = _personsAll.Where(x => (x.Value?.BirthDate.Date.CompareTo(dataFrom) >= 0
                                                     && x.Value?.BirthDate.Date.CompareTo(dataTo) <= 0));
                }

                // От 40
                if (MyCheckedListBox.IsChecked(checkedListBox_Age, 2))
                {
                    var data = DateTime.Now.AddYears(-40);
                    r3 = _personsAll.Where(x => x.Value?.BirthDate.Date.CompareTo(data) <= 0);

                }
                _reqAge = r1.Union(r2).Union(r3);
            }
            else
            {
                _reqAge = _personsAll; //  Если не нужна выборка по этому признаку
            }

            MyCheckedListBox.ClearSelection(checkedListBox_Age);
            ShowPersons(GetUpdatedRequests());
        }

        #endregion

        #region /// МЕТОДЫ. ПОЛ
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCheckedListBoxGender()
        {
            checkedListBox_Gender.Items.Clear();
            var genderNames = Enum.GetNames(typeof(Gender)).ToArray<object>();
            checkedListBox_Gender.Items.AddRange(genderNames);
        }

        private void checkedListBox_Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkedIndexes = checkedListBox_Gender.CheckedIndices;

            IEnumerable<KeyValuePair<string, Person>> r1 = new List<KeyValuePair<string, Person>>();
            IEnumerable<KeyValuePair<string, Person>> r2 = new List<KeyValuePair<string, Person>>();
            IEnumerable<KeyValuePair<string, Person>> r3 = new List<KeyValuePair<string, Person>>();

            if ((checkedIndexes.Count != 3) && (checkedIndexes.Count != 0))
            {
                // Мужчины
                if ((MyCheckedListBox.IsChecked(checkedListBox_Gender, 0)))
                {
                    r1 = _personsAll.Where(x => x.Value?.GenderType == Gender.Мужской);
                }
                // Женщины
                if (MyCheckedListBox.IsChecked(checkedListBox_Gender, 1))
                {
                    r2 = _personsAll.Where(x => (x.Value?.GenderType == Gender.Женский));
                }
                // Неизвестно
                if (MyCheckedListBox.IsChecked(checkedListBox_Gender, 2))
                {
                    r3 = _personsAll.Where(x => (x.Value?.GenderType == Gender.Неизвестен));
                }
                _reqGender = r1.Union(r2).Union(r3);
            }
            else
            {
                _reqGender = _personsAll; //  Если не нужна выборка по этому признаку
            }

            MyCheckedListBox.ClearSelection(checkedListBox_Gender);
            ShowPersons(GetUpdatedRequests());
        }
        #endregion

        #region /// МЕТОДЫ. ТИП АБОНЕМЕНТА
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCheckedListBoxTypeAbon()
        {
            checkedListBox_TypeAbon.Items.Clear();
            object[] abbonNames = { AbonementByDays.NameAbonement, ClubCardA.NameAbonement, SingleVisit.NameAbonement };
            checkedListBox_TypeAbon.Items.AddRange(abbonNames);
        }

        private void checkedListBox_TypeAbon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkedIndexes = checkedListBox_TypeAbon.CheckedIndices;

            IEnumerable<KeyValuePair<string, Person>> r1 = new List<KeyValuePair<string, Person>>();
            IEnumerable<KeyValuePair<string, Person>> r2 = new List<KeyValuePair<string, Person>>();
            IEnumerable<KeyValuePair<string, Person>> r3 = new List<KeyValuePair<string, Person>>();

            if ((checkedIndexes.Count != 3) && (checkedIndexes.Count != 0))
            {
                if ((MyCheckedListBox.IsChecked(checkedListBox_TypeAbon, 0)))
                {
                    r1 = _personsAll.Where(x => x.Value?.AbonementCurent?.AbonementName == AbonementByDays.NameAbonement);
                }
                if (MyCheckedListBox.IsChecked(checkedListBox_TypeAbon, 1))
                {
                    r2 = _personsAll.Where(x => x.Value?.AbonementCurent?.AbonementName == ClubCardA.NameAbonement);
                }
                if (MyCheckedListBox.IsChecked(checkedListBox_TypeAbon, 2))
                {
                    r3 = _personsAll.Where(x => x.Value?.AbonementCurent?.AbonementName == SingleVisit.NameAbonement);
                }
                _reqAbonType = r1.Union(r2).Union(r3);
            }
            else
            {
                _reqAbonType = _personsAll; //  Если не нужна выборка по этому признаку
            }

            MyCheckedListBox.ClearSelection(checkedListBox_TypeAbon);
            ShowPersons(GetUpdatedRequests());
        }

        #endregion

        #region /// МЕТОДЫ. ВРЕМЯ ПОСЕЩЕНИЙ
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCheckedListBoxTimeTren()
        {
            checkedListBox_TimeTren.Items.Clear();
            var timeTrenNames = Enum.GetNames(typeof(TimeForTr)).ToArray<object>();
            checkedListBox_TimeTren.Items.AddRange(timeTrenNames);
        }

        private void checkedListBox_TimeTren_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkedIndexes = checkedListBox_TimeTren.CheckedIndices;

            // Сортировка по этому признаку не важна. Содержит 2 поля(Оплачено, Не оплачено)
            if ((checkedIndexes.Count == 2) || (checkedIndexes.Count == 0))
            {
                _reqTimeTren = _personsAll;
            }
            else
            {
                var timeTren = (MyCheckedListBox.IsChecked(checkedListBox_TimeTren, 0)) ? TimeForTr.Утро : TimeForTr.Весь_День;
                _reqTimeTren = _personsAll.Where(x => x.Value?.AbonementCurent?.TimeTraining == timeTren);
            }

            MyCheckedListBox.ClearSelection(checkedListBox_TimeTren);
            ShowPersons(GetUpdatedRequests());
        }

        #endregion

        #region /// МЕТОДЫ. АКТИВАЦИЯ
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCheckedListBoxActivation()
        {
            checkedListBox_Activation.Items.Clear();
            checkedListBox_Activation.Items.AddRange(_activation);
        }

        private void checkedListBox_Activation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkedIndexes = checkedListBox_Activation.CheckedIndices;

            // Сортировка по этому признаку не важна. Содержит 2 поля(Оплачено, Не оплачено)
            if ((checkedIndexes.Count == 2) || (checkedIndexes.Count == 0))
            {
                _reqActivation = _personsAll;
            }
            else
            {
                var activation = MyCheckedListBox.IsChecked(checkedListBox_Activation, 0);
                _reqActivation = _personsAll.Where(x => x.Value?.AbonementCurent?.IsActivated == activation);
            }

            MyCheckedListBox.ClearSelection(checkedListBox_Activation);
            ShowPersons(GetUpdatedRequests());
        }

        #endregion

        /// <summary>
        /// Функция пробегает по всем запросам со всех полей и обьединяет в единый итоговый запрос-список.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<KeyValuePair<string, Person>> GetUpdatedRequests()
        {
            var personsSelected = (IEnumerable<KeyValuePair<string, Person>>)_personsAll;

            // Статусы
            personsSelected = ProcessRequest(personsSelected, _reqStatuses);
            // Последний Визит
            personsSelected = ProcessRequest(personsSelected, _reqLastVisit);
            // Оплата
            personsSelected = ProcessRequest(personsSelected, _reqPay);
            // Возраст
            personsSelected = ProcessRequest(personsSelected, _reqAge);
            // Пол
            personsSelected = ProcessRequest(personsSelected, _reqGender);
            // Тип Абонемента
            personsSelected = ProcessRequest(personsSelected, _reqAbonType);
            // Время Тренировок
            personsSelected = ProcessRequest(personsSelected, _reqTimeTren);
            // Активация
            personsSelected = ProcessRequest(personsSelected, _reqActivation);

            return personsSelected;
        }

        /// <summary>
        /// Выводит в DataGrid всех Клиентов из коллекции которую подавать на вход надо
        /// </summary>
        /// <param name="personsToShow"></param>
        private void ShowPersons(IEnumerable<KeyValuePair<string, Person>> personsToShow)
        {
            var dt = DataBaseM.CreatePersonsTable(personsToShow, DataBaseM.GetPersonFieldsShort);
            MyDataGridView.SetSourceDataGridView(dataGridView_Persons, dt);
        }

        /// <summary>
        /// Хелп функция, нужна только для функции GetUpdatedRequests. Просто оборачивает вызов обьединения запросов через Intersect
        /// </summary>
        /// <param name="allPersons"></param>
        /// <param name="inputRequest"></param>
        /// <returns></returns>
        private static IEnumerable<KeyValuePair<string, Person>> ProcessRequest(IEnumerable<KeyValuePair<string, Person>> allPersons, IEnumerable<KeyValuePair<string, Person>> inputRequest)
        {
            if (inputRequest != null) allPersons = allPersons.Intersect(inputRequest);
            return allPersons;
        }

        /// <summary>
        /// Инициализация ДатаГрид. Выводится стартовый список клиентов тоже тут.
        /// </summary>
        private void InitDataGridView()
        {
            var dt = DataBaseM.CreatePersonsTable(_personsAll, DataBaseM.GetPersonFieldsShort);
            MyDataGridView.SetSourceDataGridView(dataGridView_Persons, dt);
            MyDataGridView.ImplementStyle(dataGridView_Persons);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_Click_SaveExcel(object sender, EventArgs e)
        {
            if (DataBaseLevel.GetNumberOfPersons() == 0) MessageBox.Show(@"В Базе нет клиентов");
            var personsSelected = GetUpdatedRequests();
            var table = DataBaseM.CreatePersonsTable(personsSelected, DataBaseM.GetPersonFieldsFull);
            DataBaseM.ExportToExcel(table, true);
        }
    }
}
