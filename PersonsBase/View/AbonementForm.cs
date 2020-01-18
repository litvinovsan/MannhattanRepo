using System;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.data.Abonements;

namespace PersonsBase.View
{
    public partial class AbonementForm : Form
    {
        ///////////////// ОСНОВНЫЕ ОБЬЕКТЫ и Поля ////////////////////////////////
        private readonly Person _person;

        // Абонементы
        private string _selectedAbonementName;
        private DaysInAbon _daysInAbon;
        private PeriodClubCard _periodClubCard;

        // Опции
        private TypeWorkout _typeWorkout;
        private TimeForTr _timeTren;
        private SpaService _spa;
        private Pay _pay;
        private DateTime defaultForActivation = new DateTime(2020, 1, 1);

        ///////////////// КОНСТРУКТОР. МЕТОДЫ ////////////////////////////////
        public AbonementForm(string nameKey)
        {
            InitializeComponent();
            _person = DataBaseO.GetPersonLink(nameKey); // Получаем ссылку на обьект персоны
        }

        private void AbonementForm_Load(object sender, EventArgs e)
        {
            SetInitialValues();

            LoadDefaultValues();
        }

        private void SetInitialValues()
        {
            if (_person.AbonementCurent == null)
            {
                _selectedAbonementName = "Абонемент";// Вид Абонемента по Умолчанию
                radioButton_Abonement.Checked = true;
                _typeWorkout = TypeWorkout.Тренажерный_Зал;
                _timeTren = TimeForTr.Весь_День;
                _spa = SpaService.Спа;
                _pay = Pay.Оплачено;
                _daysInAbon = DaysInAbon.На_12_посещений;
                _periodClubCard = PeriodClubCard.На_1_Месяц;
            }
            else // Абонемент Существует
            {
                _selectedAbonementName = _person.AbonementCurent.AbonementName;
                _typeWorkout = _person.AbonementCurent.TrainingsType;
                _timeTren = _person.AbonementCurent.TimeTraining;
                _spa = _person.AbonementCurent.Spa;
                _pay = _person.AbonementCurent.PayStatus;
                switch (_person.AbonementCurent)
                {
                    case AbonementByDays days:
                        _daysInAbon = days.GetTypeAbonementByDays();
                        radioButton_Abonement.Checked = true;
                        break;
                    case ClubCardA abonement:
                        _periodClubCard = abonement.GetTypeClubCard();
                        radioButton_ClubCard.Checked = true;
                        break;
                    case SingleVisit _:
                        radioButton_Single.Checked = true;
                        break;
                }
            }
        }

        private void LoadDefaultValues()
        {

            // Тип Тренировки

            comboBox_TypeTren.Items.AddRange(Enum.GetNames(typeof(TypeWorkout)).ToArray<object>()); // Записываем Поля в Комбобокс
            comboBox_TypeTren.SelectedItem = _typeWorkout.ToString(); // Выбор по умолчанию
            comboBox_TypeTren.SelectedIndexChanged += ComboBox_TypeTren_SelectedIndexChanged;

            // Время Тренировки
            comboBox_time.Items.AddRange(Enum.GetNames(typeof(TimeForTr)).ToArray<object>()); // Записываем Поля в Комбобокс
            comboBox_time.SelectedItem = _timeTren.ToString();                           // Выбор по умолчанию
            comboBox_time.SelectedIndexChanged += ComboBox_time_SelectedIndexChanged;

            // Услуги Спа
            comboBox_spa.Items.AddRange(Enum.GetNames(typeof(SpaService)).ToArray<object>()); // Записываем Поля в Комбобокс
            comboBox_spa.SelectedItem = _spa.ToString();                           // Выбор по умолчанию
            comboBox_spa.SelectedIndexChanged += ComboBox_spa_SelectedIndexChanged;

            // Оплата
            comboBox_Pay.Items.AddRange(Enum.GetNames(typeof(Pay)).ToArray<object>()); // Записываем Поля в Комбобокс
            comboBox_Pay.SelectedItem = _pay.ToString();                       // Выбор по умолчанию
            comboBox_Pay.SelectedIndexChanged += ComboBox_Pay_SelectedIndexChanged;

            // Количество Дней в Абонементе
            comboBox_Abonem.Items.AddRange(Enum.GetNames(typeof(DaysInAbon)).ToArray<object>()); // Записываем Поля в Комбобокс
            comboBox_Abonem.SelectedItem = _daysInAbon.ToString();               // Выбор по умолчанию
            comboBox_Abonem.SelectedIndexChanged += ComboBox_Abonem_SelectedIndexChanged;

            // Длительность Клубной Карты
            comboBox_ClubCard.Items.AddRange(Enum.GetNames(typeof(PeriodClubCard)).ToArray<object>()); // Записываем Поля в Комбобокс
            comboBox_ClubCard.SelectedItem = _periodClubCard.ToString();                    // Выбор по умолчанию
            comboBox_ClubCard.SelectedIndexChanged += ComboBox_ClubCard_SelectedIndexChanged;

            // Дата Активации
            dateTimePicker1.Value = defaultForActivation;
            dateTimePicker1.MinDate = new DateTime(2019, 1, 1);
        }

        public void ApplyChanges()
        {
            switch (_selectedAbonementName)
            {
                case "Клубная Карта":
                    {
                        _person.AbonementCurent = new ClubCardA(_pay, _timeTren, TypeWorkout.Тренажерный_Зал, _spa, _periodClubCard);
                        break;
                    }
                case "Абонемент":
                    {
                        _person.AbonementCurent = new AbonementByDays(_pay, _timeTren, _typeWorkout, _spa, _daysInAbon);
                        break;
                    }
                case "Разовое Занятие":
                    {
                        _person.AbonementCurent = new SingleVisit(_typeWorkout, _spa, _pay, _timeTren);
                        break;
                    }
            }
            // Если введена дата Активации в прошлом
            if ((_person.AbonementCurent.AbonementName != SingleVisit.NameAbonement) &&
                checkBox_Activated.Checked &&
                dateTimePicker1.Value.Date.CompareTo(defaultForActivation.Date) != 0)
            {
                _person.AbonementCurent.TryActivate(dateTimePicker1.Value);
            }
        }

        private static T GetVarFromCombo<T>(ComboBox cmbx)
        {
            var tempVar = (T)Enum.Parse(typeof(T), cmbx.SelectedItem.ToString());
            return tempVar;
        }

        ///////////////// ОБРАБОТЧИКИ ////////////////////////////////
        private void button_Cancel(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton_Abonement_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _selectedAbonementName = "Абонемент";

                comboBox_Abonem.Visible = true;
                comboBox_ClubCard.Visible = false;

                radioButton_ClubCard.Checked = false;
                radioButton_Single.Checked = false;

                comboBox_Abonem.SelectedItem = _daysInAbon.ToString();
            }
            else
            {
                comboBox_Abonem.Visible = false;
            }
        }

        private void radioButton_ClubCard_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _selectedAbonementName = "Клубная Карта";

                comboBox_Abonem.Visible = false;
                comboBox_ClubCard.Visible = true;

                radioButton_Abonement.Checked = false;
                radioButton_Single.Checked = false;

                comboBox_ClubCard.SelectedItem = _periodClubCard.ToString();
                comboBox_TypeTren.SelectedItem = TypeWorkout.Тренажерный_Зал.ToString();
                comboBox_TypeTren.Enabled = false;
            }
            else
            {
                comboBox_ClubCard.Visible = false;
                comboBox_TypeTren.Enabled = true;
            }
        }

        private void radioButton_Single_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _selectedAbonementName = "Разовое Занятие";

                comboBox_Abonem.Visible = false;
                comboBox_ClubCard.Visible = false;

                radioButton_Abonement.Checked = false;
                radioButton_ClubCard.Checked = false;
            }
        }

        private void ComboBox_TypeTren_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _typeWorkout = GetVarFromCombo<TypeWorkout>(combo);
        }
        private void ComboBox_time_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _timeTren = GetVarFromCombo<TimeForTr>(combo);
        }
        private void ComboBox_spa_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _spa = GetVarFromCombo<SpaService>(combo);
        }
        private void ComboBox_Pay_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _pay = GetVarFromCombo<Pay>(combo);
        }
        private void ComboBox_Abonem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _daysInAbon = GetVarFromCombo<DaysInAbon>(combo);
        }
        private void ComboBox_ClubCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _periodClubCard = GetVarFromCombo<PeriodClubCard>(combo);
        }

        private void button_Aplly_Click(object sender, EventArgs e)
        {
            if (radioButton_Abonement.Checked && _daysInAbon == 0)
            {
                MessageBox.Show(@"Выберите Количество посещений!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (radioButton_ClubCard.Checked && _periodClubCard == 0)
            {
                MessageBox.Show(@"Выберите Длительность Клубной Карты!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;

            }
            DialogResult = DialogResult.OK;// Cancel;
        }

        private void checkBox_Activated_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = checkBox_Activated.Checked;
        }
    }
}
