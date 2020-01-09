using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class ReportForm : Form
    {
        // Наблюдаемая коллекция, СПИСОК выбранных по параметрам Клиентов
        public ObservableCollection<KeyValuePair<string, Person>> PersonsSelected;

        public ReportForm()
        {
            InitializeComponent();
            // Наблюдаемая коллекция, СПИСОК выбранных по параметрам Клиентов
            PersonsSelected = new ObservableCollection<KeyValuePair<string, Person>>();
            PersonsSelected.CollectionChanged += PersonsSelected_CollectionChanged;

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

        private void PersonsSelected_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DataTable dt = DataBaseM.CreatePersonsTable(PersonsSelected, DataBaseM.GetPersonFieldsShort);
            MyDataGridView.SetSourceDataGridView(dataGridView_Persons, dt);

        }

        private void InitDataGridView()
        {
            // DataTable dt = DataBaseM.CreatePersonsTable(PersonsSelected, DataBaseM.GetPersonFieldsShort);
            DataTable dt = DataBaseM.CreatePersonsTable(DataBaseLevel.GetListPersons(), DataBaseM.GetPersonFieldsShort);

            MyDataGridView.SetSourceDataGridView(dataGridView_Persons, dt);
            MyDataGridView.ImplementStyle(dataGridView_Persons);
        }

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
            "Не учитывать",
            "Больше 1 месяца"
        };
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

        #region /// МЕТОДЫ. СТАТУС
        /// <summary>
        /// Устанавливает стартовые значения CheckedListBox при загрузке формы. Список строк и галочку.
        /// </summary>
        private void InitCheckedListBoxStatus()
        {
            var statuses = Enum.GetNames(typeof(StatusPerson)).ToArray<object>();
            MyComboBox.Initialize(comboBox_Status, statuses, StatusPerson.Активный.ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Click_SaveExcel(object sender, EventArgs e)
        {
            if (DataBaseLevel.GetNumberOfPersons() == 0) MessageBox.Show(@"В Базе нет клиентов");

            var table = DataBaseM.CreatePersonsTable(PersonsSelected, DataBaseM.GetPersonFieldsShort);
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
