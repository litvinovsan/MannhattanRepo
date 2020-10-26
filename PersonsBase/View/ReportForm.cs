﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly SortedList<string, Person> _personsAll = DataBaseLevel.GetPersonsList();
        private List<Person> _toShowList;

        // ВЫБОРКИ по параметрам
        private Func<Person, bool> _reqStatuses;
        private Func<Person, bool> _reqLastVisit;
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
            //InitDateVisit();
            //InitCheckedListBoxPay();
            //InitCheckedListBoxAge();
            //InitCheckedListBoxGender();
            //InitCheckedListBoxTypeAbon();
            //InitCheckedListBoxTimeTren();
            //InitCheckedListBoxActivation();


        }
        private async void ReportForm_Load(object sender, EventArgs e)
        {
            _toShowList = _personsAll.Values.ToList();

            MyDataGridView.ImplementStyle(dataGridView_Persons);
            UpdateDataGrid(_toShowList);
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
                _reqStatuses = p => p.Status == StatusPerson.Гостевой ||
                                    p.Status == StatusPerson.Активный ||
                                    p.Status == StatusPerson.Заморожен ||
                                    p.Status == StatusPerson.Запрещён ||
                                    p.Status == StatusPerson.Нет_Карты;
            }
            else
            {
                var status = MyComboBox.GetComboBoxValue<StatusPerson>(comboBox_Status);
                _reqStatuses = p => p.Status == status;
            }
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
        private async void comboBox_LastVisit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lVisit = MyComboBox.GetComboBoxValue(comboBox_LastVisit);
            // Если последний визит не важен -выходим
            if (lVisit.Equals(_lastVisits[0]))
            {
                // Любое значение допустимо. То есть должны попасть все
                _reqLastVisit = person => person.Name.Length !=0;
            }
            else
            {
                var dataInPast = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0)).Date;//Вычитаем 30 дней
                var fullJournal = DataBaseLevel.GetPersonsVisitDict();
                var resultByCondition = fullJournal.Where(x => x.Value?.Last().DateTimeVisit.CompareTo(dataInPast) <= 0);
                var resultConverted = resultByCondition.Select(y => new KeyValuePair<string, Person>(y.Key, PersonObject.GetLink(y.Key)));
                _reqLastVisit = resultConverted.ToList();
            }
            var result = await GetUpdatedRequestsAsync();
            ShowPersons(result);
        }
        #endregion

        #region /// МЕТОДЫ. ДАТА ПОСЕЩЕНИЯ КОНКРЕТНАЯ
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitDateVisit()
        {
            dateTimePicker_Visit.Value = DateTime.Now.Date;
        }
        private async void dateTimePicker_Visit_ValueChanged(object sender, EventArgs e)
        {
            var lVisit = dateTimePicker_Visit.Value.Date;
            if (lVisit.CompareTo(DateTime.Now.Date) > 0)
            {
                dateTimePicker_Visit.Value = DateTime.Now;
                return;
            }

            // Если последний визит не важен -выходим
            if (lVisit.CompareTo(DateTime.Now.Date) == 0)
            {
                _reqLastVisit = _personsAll;
            }
            else
            {
                var fullJournal = DataBaseLevel.GetPersonsVisitDict();
                var resultByCondition = fullJournal.Where(x => x.Value.Any(y => y.DateTimeVisit.Date.CompareTo(lVisit) == 0));
                var resultConverted = resultByCondition.Select(y => new KeyValuePair<string, Person>(y.Key, PersonObject.GetLink(y.Key)));
                _reqLastVisit = resultConverted.ToList();
            }
            var result = await GetUpdatedRequestsAsync();
            ShowPersons(result);
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

        private async void checkedListBox_Pay_SelectedIndexChanged(object sender, EventArgs e)
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
            var result = await GetUpdatedRequestsAsync();
            ShowPersons(result);
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

        private async void checkedListBox_Age_SelectedIndexChanged(object sender, EventArgs e)
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
            var result = await GetUpdatedRequestsAsync();
            ShowPersons(result);
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
                    r1 = _personsAll.Where(x => x.Value.GenderType == Gender.Мужской);
                }
                // Женщины
                if (MyCheckedListBox.IsChecked(checkedListBox_Gender, 1))
                {
                    r2 = _personsAll.Where(x => (x.Value.GenderType == Gender.Женский));
                }
                // Неизвестно
                if (MyCheckedListBox.IsChecked(checkedListBox_Gender, 2))
                {
                    r3 = _personsAll.Where(x => (x.Value.GenderType == Gender.Неизвестен));
                }
                _reqGender = r1.Union(r2).Union(r3);
            }
            else
            {
                _reqGender = _personsAll; //  Если не нужна выборка по этому признаку
            }

            MyCheckedListBox.ClearSelection(checkedListBox_Gender);
            var result = GetUpdatedRequestsAsync();
            ShowPersons(result.Result);
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

        private async void checkedListBox_TypeAbon_SelectedIndexChanged(object sender, EventArgs e)
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
            var result = await GetUpdatedRequestsAsync();
            ShowPersons(result);
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

        private async void checkedListBox_TimeTren_SelectedIndexChanged(object sender, EventArgs e)
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
            var result = await GetUpdatedRequestsAsync();
            ShowPersons(result);
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

        private async void checkedListBox_Activation_SelectedIndexChanged(object sender, EventArgs e)
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
            var result = await GetUpdatedRequestsAsync();
            ShowPersons(result);
        }

        #endregion


        private void UpdateDataGrid(List<Person> listToShow)
        {
            var columns = from t in listToShow
                          orderby t.Name
                          select new
                          {
                              ID = t.PersonalNumber,
                              Name = t.Name,
                              AbonName = t?.AbonementCurent?.AbonementName,
                              Status = t.Status,
                              Date_Activation = t?.AbonementCurent?.BuyActivationDate,
                              Date_Finish = t?.AbonementCurent?.EndDate,
                              Spa = t?.AbonementCurent?.Spa
                          };

            dataGridView_Persons.DataSource = columns.ToList();
            dataGridView_Persons.Refresh();
        }



        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_Click_SaveExcel(object sender, EventArgs e)
        {
            if (DataBaseLevel.GetNumberOfPersons() == 0) MessageBox.Show(@"В Базе нет клиентов");

            //var table = DataBaseM.CreatePersonsTable(personsSelected, DataBaseM.GetPersonFieldsFull);
            // MyFile.ExportToExcel(table, true);
        }

        private void button_resetDate_Click(object sender, EventArgs e)
        {
            dateTimePicker_Visit.Value = DateTime.Now;
        }
    }
}
