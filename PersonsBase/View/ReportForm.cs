using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class ReportForm : Form
    {
        // Список всех персон. Исходная коллекция со всеми клиентами
        private readonly SortedList<string, Person> _personsAll = DataBaseLevel.GetListPersons();

        // СПИСОК выбранных по параметрам Клиентов
        private SortedList<string, Person> _personsSelected = new SortedList<string, Person>();

        #region /// ПОЛЯ ИСПОЛЬЗУЕМЫЕ В КОНТРОЛАХ КАК ПЕРЕЧИСЛЕНИЯ ЗНАЧЕНИЙ

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
            "Не важно",
            "Больше 1 месяца"
        };
        #endregion

        public ReportForm()
        {
            InitializeComponent();

            // Инициализация всех группбоксов стартовыми значениями
            InitCheckedListBoxAge();
            InitCheckedListBoxPay();
            InitCheckedListBoxGender();
            InitCheckedListBoxActivation();
            InitCheckedListBoxTypeAbon();
            InitCheckedListBoxLastVisit();
            InitCheckedListBoxStatus();
            InitCheckedListBoxTimeTren();

            InitDataGridView();
        }

        private void InitDataGridView()
        {
            var dt = DataBaseM.CreatePersonsTable(_personsAll, DataBaseM.GetPersonFieldsShort);
            MyDataGridView.SetSourceDataGridView(dataGridView_Persons, dt);
            MyDataGridView.ImplementStyle(dataGridView_Persons);
        }

        #region /// МЕТОДЫ. СТАТУС КЛИЕНТА
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCheckedListBoxStatus()
        {
            var statuses = Enum.GetNames(typeof(StatusPerson)).ToArray<object>();
            MyComboBox.Initialize(comboBox_Status, statuses);
        }

        private void comboBox_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            for (var i = 0; i < checkedListBox_Age.Items.Count; i++)
            {
                checkedListBox_Age.SetItemChecked(i, true);
            }
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
            for (var i = 0; i < checkedListBox_Pay.Items.Count; i++)
            {
                checkedListBox_Pay.SetItemChecked(i, true);
            }
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
            for (var i = 0; i < checkedListBox_Gender.Items.Count; i++)
            {
                checkedListBox_Gender.SetItemChecked(i, true);
            }
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
            for (var i = 0; i < checkedListBox_Activation.Items.Count; i++)
            {
                checkedListBox_Activation.SetItemChecked(i, true);
            }
        }



        #endregion

        #region /// МЕТОДЫ. ТИП АБОНЕМЕНТА
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCheckedListBoxTypeAbon()
        {
            checkedListBox_TypeAbon.Items.Clear();
            var workoutNames = Enum.GetNames(typeof(TypeWorkout)).ToArray<object>();
            checkedListBox_TypeAbon.Items.AddRange(workoutNames);
            for (var i = 0; i < checkedListBox_TypeAbon.Items.Count; i++)
            {
                checkedListBox_TypeAbon.SetItemChecked(i, true);
            }
        }



        #endregion

        #region /// МЕТОДЫ. ПОСЛЕДНЕЕ ПОСЕЩЕНИЕ
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCheckedListBoxLastVisit()
        {
            comboBox_LastVisit.Items.Clear();
            MyComboBox.Initialize(comboBox_LastVisit, _lastVisits, _lastVisits[0]);
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
            for (var i = 0; i < checkedListBox_TimeTren.Items.Count; i++)
            {
                checkedListBox_TimeTren.SetItemChecked(i, true);
            }
        }



        #endregion

        #region /// ОБЩИЕ МЕТОДЫ для РАБОТЫ С КОНТРОЛАМИ
        /// <summary>
        /// Возвращает bool массив. Установлено true если чекбокс с соответствующим индексом Отмечен
        /// </summary>
        /// <param name="listBox"></param>
        /// <returns></returns>
        private bool[] GetCheckedListBoxIndexes(CheckedListBox listBox)
        {
            var counts = listBox.Items.Count;
            var itemsState = new bool[counts];
            for (var i = 0; i < counts; i++)
            {
                itemsState[i] = listBox.GetItemChecked(i);
            }

            return itemsState;
        }
        #endregion

        /// <summary>
        /// Выводит в DataGrid всех Клиентов из коллекции которую подавать на вход надо
        /// </summary>
        /// <param name="personsToShow"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPersonsInDataGrid(IEnumerable<KeyValuePair<string, Person>> personsToShow)
        {
            var dt = DataBaseM.CreatePersonsTable(personsToShow, DataBaseM.GetPersonFieldsShort);
            MyDataGridView.SetSourceDataGridView(dataGridView_Persons, dt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Click_SaveExcel(object sender, EventArgs e)
        {
            if (DataBaseLevel.GetNumberOfPersons() == 0) MessageBox.Show(@"В Базе нет клиентов");

            var table = DataBaseM.CreatePersonsTable(_personsSelected, DataBaseM.GetPersonFieldsFull);
            DataBaseM.ExportToExcel(table, true);
        }






        /*
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



                #endregion
            */
    }
}
