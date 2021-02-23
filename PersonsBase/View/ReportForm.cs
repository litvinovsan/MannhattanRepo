using System;
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

        // Список названий тренировок
        private readonly List<string> _listOfNamesSchedule = DataBaseLevel.GetManhattanInfo().Schedule.Select(x => x.GetTimeAndNameStr()).ToList();

        // Список аэробных посещений 
        private readonly List<AerobItem> _aerobVisits = DailyVisits.GetInstance().AerobList;

        // ВЫБОРКИ по параметрам
        private IEnumerable<Person> _reqStatuses;
        private IEnumerable<Person> _reqLastVisit;
        private IEnumerable<Person> _reqPay;
        private IEnumerable<Person> _reqAge;
        private IEnumerable<Person> _reqGender;
        private IEnumerable<Person> _reqAbonType;
        private IEnumerable<Person> _reqTimeTren;
        private IEnumerable<Person> _reqActivation;
        private IEnumerable<Person> _reqTrenName;


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
            InitDateVisit();
            InitCheckedListBoxPay();
            InitCheckedListBoxAge();
            InitCheckedListBoxGender();
            InitCheckedListBoxTypeAbon();
            InitCheckedListBoxTimeTren();
            InitCheckedListBoxActivation();
            InitCheckedListBoxTrenName();

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
                _reqStatuses = _personsAll.Values;
            }
            else
            {
                var status = MyComboBox.GetComboBoxValue<StatusPerson>(comboBox_Status);
                _reqStatuses = _personsAll.Where(x => x.Value?.Status == status).Select(x => x.Value);
            }

            var result = GetUpdatedRequestsAsync();
            ShowPersons(result.Result);
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
                _reqLastVisit = _personsAll.Values;
            }
            else
            {
                var dataInPast = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0)).Date;//Вычитаем 30 дней
                var fullJournal = DataBaseLevel.GetPersonsVisitDict();
                var resultByCondition = fullJournal.Where(x => x.Value?.Last().DateTimeVisit.CompareTo(dataInPast) <= 0).Select(x => x.Key);
                var resultConverted = resultByCondition.Select(PersonObject.GetLink);
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
                _reqLastVisit = _personsAll.Values;
            }
            else
            {
                var fullJournal = DataBaseLevel.GetPersonsVisitDict();
                var resultByCondition = fullJournal.Where(x => x.Value.Any(y => y.DateTimeVisit.Date.CompareTo(lVisit) == 0)).Select(x => x.Key);
                var resultConverted = resultByCondition.Select(PersonObject.GetLink);
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
                _reqPay = _personsAll.Values;
            }
            else
            {
                var payment = (MyCheckedListBox.IsChecked(checkedListBox_Pay, 0)) ? Pay.Не_Оплачено : Pay.Оплачено;
                _reqPay = _personsAll.Where(x => x.Value?.AbonementCurent?.PayStatus == payment).Select(x => x.Value);
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

            IEnumerable<Person> r1 = new List<Person>();
            IEnumerable<Person> r2 = new List<Person>();
            IEnumerable<Person> r3 = new List<Person>();

            if ((checkedIndexes.Count != 3) && (checkedIndexes.Count != 0))
            {
                // До 30
                if (MyCheckedListBox.IsChecked(checkedListBox_Age, 0))
                {
                    var data = DateTime.Now.AddYears(-30); // Дата проверки для 30 летних
                    r1 = _personsAll.Where(x => x.Value?.BirthDate.Date.CompareTo(data) >= 0).Select(x => x.Value);
                }

                // 30 - 40
                if (MyCheckedListBox.IsChecked(checkedListBox_Age, 1))
                {
                    var dataFrom = DateTime.Now.AddYears(-40);
                    var dataTo = DateTime.Now.AddYears(-30);
                    r2 = _personsAll.Where(x => (x.Value?.BirthDate.Date.CompareTo(dataFrom) >= 0
                                                     && x.Value?.BirthDate.Date.CompareTo(dataTo) <= 0)).Select(x => x.Value);
                }

                // От 40
                if (MyCheckedListBox.IsChecked(checkedListBox_Age, 2))
                {
                    var data = DateTime.Now.AddYears(-40);
                    r3 = _personsAll.Where(x => x.Value?.BirthDate.Date.CompareTo(data) <= 0).Select(x => x.Value);

                }
                _reqAge = r1.Union(r2).Union(r3);
            }
            else
            {
                _reqAge = _personsAll.Values; //  Если не нужна выборка по этому признаку
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
            var genderNames = Enum.GetNames(typeof(Gender)).Where(x => !x.Contains(Gender.Неизвестен.ToString())).ToArray<object>();
            checkedListBox_Gender.Items.AddRange(genderNames);
        }

        private void checkedListBox_Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkedIndexes = checkedListBox_Gender.CheckedIndices;

            IEnumerable<Person> r1 = new List<Person>();
            IEnumerable<Person> r2 = new List<Person>();

            if ((checkedIndexes.Count != 2) && (checkedIndexes.Count != 0))
            {
                // Мужчины
                if ((MyCheckedListBox.IsChecked(checkedListBox_Gender, 0)))
                {
                    r1 = _personsAll.Where(x => x.Value.GenderType == Gender.Мужской).Select(x => x.Value);
                }
                // Женщины
                if (MyCheckedListBox.IsChecked(checkedListBox_Gender, 1))
                {
                    r2 = _personsAll.Where(x => (x.Value.GenderType == Gender.Женский)).Select(x => x.Value);
                }
                _reqGender = r1.Union(r2);
            }
            else
            {
                _reqGender = _personsAll.Values; //  Если не нужна выборка по этому признаку
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

            IEnumerable<Person> r1 = new List<Person>();
            IEnumerable<Person> r2 = new List<Person>();
            IEnumerable<Person> r3 = new List<Person>();

            if ((checkedIndexes.Count != 3) && (checkedIndexes.Count != 0))
            {
                if ((MyCheckedListBox.IsChecked(checkedListBox_TypeAbon, 0)))
                {
                    r1 = _personsAll.Where(x => x.Value?.AbonementCurent?.AbonementName == AbonementByDays.NameAbonement).Select(x => x.Value);
                }
                if (MyCheckedListBox.IsChecked(checkedListBox_TypeAbon, 1))
                {
                    r2 = _personsAll.Where(x => x.Value?.AbonementCurent?.AbonementName == ClubCardA.NameAbonement).Select(x => x.Value);
                }
                if (MyCheckedListBox.IsChecked(checkedListBox_TypeAbon, 2))
                {
                    r3 = _personsAll.Where(x => x.Value?.AbonementCurent?.AbonementName == SingleVisit.NameAbonement).Select(x => x.Value);
                }
                _reqAbonType = r1.Union(r2).Union(r3);
            }
            else
            {
                _reqAbonType = _personsAll.Values; //  Если не нужна выборка по этому признаку
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
                _reqTimeTren = _personsAll.Values;
            }
            else
            {
                var timeTren = (MyCheckedListBox.IsChecked(checkedListBox_TimeTren, 0)) ? TimeForTr.Утро : TimeForTr.Весь_День;
                _reqTimeTren = _personsAll.Where(x => x.Value?.AbonementCurent?.TimeTraining == timeTren).Select(x => x.Value);
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
                _reqActivation = _personsAll.Values;
            }
            else
            {
                var activation = MyCheckedListBox.IsChecked(checkedListBox_Activation, 0);
                _reqActivation = _personsAll.Where(x => x.Value?.AbonementCurent?.IsActivated == activation).Select(x => x.Value);
            }

            MyCheckedListBox.ClearSelection(checkedListBox_Activation);
            var result = await GetUpdatedRequestsAsync();
            ShowPersons(result);
        }

        #endregion

        #region /// МЕТОДЫ. НАЗВАНИЕ ТРЕНИРОВКИ ГРУППОВОЙ
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCheckedListBoxTrenName()
        {
            checkedListBox_Tren_Name.Items.Clear();
            checkedListBox_Tren_Name.Items.AddRange(_listOfNamesSchedule.ToArray<object>());
        }

        private void checkedListBox_Tren_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkedIndexes = checkedListBox_Tren_Name.CheckedIndices;

            var pList = new List<Person>();
            _reqTrenName = _personsAll.Values;
            if (checkedIndexes.Count != 0)
            {
                foreach (var item in checkedIndexes)
                {
                    var checkedItemString = checkedListBox_Tren_Name.Items[(int)item].ToString();
                    var indexOfBrace = checkedItemString.IndexOf('(');

                    string trimmedCheckedItemString;
                    if (indexOfBrace > 0)
                    {
                        trimmedCheckedItemString = checkedItemString.Substring(0, checkedItemString.IndexOf('(')).Trim();
                    }
                    else
                    {
                        trimmedCheckedItemString = checkedItemString;
                    }

                    var r2 = _aerobVisits.Where(x =>
                    {
                        string groupTrName= x.GroupTimeName;
                        if (groupTrName.Contains("("))
                        {
                            groupTrName= groupTrName.Substring(0, x.GroupTimeName.IndexOf('(')).Trim();
                        }
                        return groupTrName == trimmedCheckedItemString;
                    }).Select(y => y.NamePerson).Distinct().ToList();

                    foreach (var name in r2)
                    {
                        pList.Add(PersonObject.GetLink(name));
                    }

                    _reqTrenName = _reqTrenName.Intersect(pList).Distinct();
                }
            }
            else
            {
                _reqTrenName = _personsAll.Values; //  Если не нужна выборка по этому признаку
            }

            MyCheckedListBox.ClearSelection(checkedListBox_Tren_Name);
            var result = GetUpdatedRequestsAsync();
            ShowPersons(result.Result);
        }

        #endregion

        /// <summary>
        /// Функция пробегает по всем запросам со всех полей и обьединяет в единый итоговый запрос-список.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Person> GetUpdatedRequests()
        {
            var personsSelected = _personsAll.Select(x => x.Value);

            personsSelected = ProcessRequest(personsSelected, _reqStatuses, _reqLastVisit, _reqPay, _reqAge, _reqGender,
                _reqAbonType, _reqTimeTren, _reqActivation, _reqTrenName);

            return personsSelected;
        }

        private async Task<IEnumerable<Person>> GetUpdatedRequestsAsync()
        {
            return await Task.Run(() => GetUpdatedRequests()).ConfigureAwait(false);
        }

        /// <summary>
        /// Выводит в DataGrid всех Клиентов из коллекции которую подавать на вход надо
        /// </summary>
        /// <param name="personsToShow"></param>
        private async void ShowPersons(IEnumerable<Person> personsToShow)
        {
            var dt = await Task.Run(() => DataBaseM.CreatePersonsTable(personsToShow, DataBaseM.GetPersonFieldsShort));
            MyDataGridView.SetSourceDataGridView(dataGridView_Persons, dt);
        }

        /// <summary>
        /// Хелп функция, нужна только для функции GetUpdatedRequests. Просто оборачивает вызов обьединения запросов через Intersect
        /// </summary>
        /// <param name="allPersons"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static IEnumerable<Person> ProcessRequest(IEnumerable<Person> allPersons, params IEnumerable<Person>[] parameters)
        {
            if (parameters != null && parameters.Length != 0)
            {
                allPersons = parameters.Where(item => item != null).Aggregate(allPersons, (current, item) => current.Intersect(item));
            }
            return allPersons;
        }

        /// <summary>
        /// Инициализация ДатаГрид. Выводится стартовый список клиентов тоже тут.
        /// </summary>
        private void InitDataGridView()
        {
            var dt = DataBaseM.CreatePersonsTable(_personsAll.Values, DataBaseM.GetPersonFieldsShort);
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
            MyFile.ExportToExcel(table, true);
        }

        private void button_resetDate_Click(object sender, EventArgs e)
        {
            dateTimePicker_Visit.Value = DateTime.Now;

            InitCBoxStatus();
            InitCBoxLastVisit();
            InitDateVisit();
            InitCheckedListBoxPay();
            InitCheckedListBoxAge();
            InitCheckedListBoxGender();
            InitCheckedListBoxTypeAbon();
            InitCheckedListBoxTimeTren();
            InitCheckedListBoxActivation();
            InitCheckedListBoxTrenName();

            GetUpdatedRequests();
        }

        private async void ReportForm_Load(object sender, EventArgs e)
        {
            await Task.Run((() => InitDataGridView()));
        }

        private void dataGridView_Persons_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var dg = (DataGridView)sender;
            var isSelected = dg.SelectedRows.Count > 0;
            if (isSelected)
            {
                int rowindex = dg.CurrentCell.RowIndex;
                // В Cell[0] Находится имя клиента
                var resultName = dg.Rows[rowindex].Cells[0].Value.ToString();

                if (string.IsNullOrEmpty(resultName)) return;
                FormsRunner.RunClientForm(resultName);
            }

        }


    }
}
