using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class AbonementForm : Form
    {
        ///////////////// ОСНОВНЫЕ ОБЬЕКТЫ и Поля ////////////////////////////////
        private readonly Person _person;

        private readonly bool _isReadOnlyForm; // Можно ли изменять значения на форме.Зависит от пароля 

        // Абонементы
        private string _selectedAbonementName;
        private DaysInAbon _daysInAbon;
        private PeriodClubCard _periodClubCard;

        // Опции
        private TypeWorkout _typeWorkout;
        private TimeForTr _timeTren;
        private SpaService _spa;
        private Pay _pay;


        ///////////////// КОНСТРУКТОР. МЕТОДЫ ////////////////////////////////
        public AbonementForm(string nameKey)
        {
            InitializeComponent();
            _person = PersonObject.GetLink(nameKey); // Получаем ссылку на обьект персоны
            _isReadOnlyForm = false;
        }

        /// <summary>
        /// Нужен для отображения параметров текущего абонемента из очереди абонементов
        /// </summary>
        /// <param name="abonToShow"></param>
        public AbonementForm(ref AbonementBasic abonToShow)
        {
            InitializeComponent();
            _person = new Person("Temp") { AbonementCurent = abonToShow };
            _isReadOnlyForm = true;
            button_Aplly.Enabled = false;
            button_Aplly.Visible = false;
            button2_Cancel.Text = @"Закрыть";
            this.Text = @"Режим ЧТЕНИЯ";
            groupBox_Correctable.Visible = false;
            tableLayoutPanel2.Enabled = false;
            tableLayoutPanel2.Visible = false;
            tableLayoutPanel3.Visible = false;
            groupBox_Details.Visible = true;

            Logic.LoadShortInfo(groupBox_Details, _person);

        }

        private void AbonementForm_Load(object sender, EventArgs e)
        {
            SetInitialValues();
            LoadDefaultValues();

            // Не выключено ли в настройках разрешение на корректировку абонементов при создании их
            groupBox_Correctable.Enabled = Options.AbonIsCorrectable;

            // Гостевой визит Радиобатон показывается если не были посещения
            var lastVisits = PersonObject.GetVisitsList(_person.Name);
            radioButton_guest.Visible = lastVisits == null || lastVisits.Count == 0;
            pictureBox8.Visible = lastVisits == null || lastVisits.Count == 0;
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
                _typeWorkout = _person.AbonementCurent.TypeWorkout;
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

            if (comboBox_TypeTren.Items.Count == 0)
            {
                //var array = Enum.GetNames(typeof(TypeWorkout)).Where(x => (x != TypeWorkout.МиниГруппа.ToString()))
                //    .Select(x => x).ToArray<object>();

                var array = Enum.GetNames(typeof(TypeWorkout)).Select(x => x).ToArray<object>();
                comboBox_TypeTren.Items.AddRange(array); // Записываем Поля в Комбобокс
                comboBox_TypeTren.SelectedItem = _typeWorkout.ToString(); // Выбор по умолчанию
            }


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
            // comboBox_Pay.SelectedItem = _pay.ToString();                       // Выбор по умолчанию
            if (_isReadOnlyForm) comboBox_Pay.SelectedItem = _pay.ToString();
            comboBox_Pay.SelectedIndexChanged += ComboBox_Pay_SelectedIndexChanged;

            // Количество Дней в Абонементе
            comboBox_Abonem.Items.AddRange(Enum.GetNames(typeof(DaysInAbon)).ToArray<object>()); // Записываем Поля в Комбобокс
            comboBox_Abonem.SelectedItem = _daysInAbon.ToString();               // Выбор по умолчанию
            comboBox_Abonem.SelectedIndexChanged += ComboBox_Abonem_SelectedIndexChanged;

            // Длительность Клубной Карты
            comboBox_ClubCard.Items.AddRange(Enum.GetNames(typeof(PeriodClubCard)).ToArray<object>()); // Записываем Поля в Комбобокс
            comboBox_ClubCard.SelectedItem = _periodClubCard.ToString();                               // Выбор по умолчанию
            comboBox_ClubCard.SelectedIndexChanged += ComboBox_ClubCard_SelectedIndexChanged;

            // Дата Активации
            dateTimePicker_ActivationDate.Value = DateTime.Now;
            dateTimePicker_ActivationDate.MinDate = new DateTime(2019, 1, 1);
            // Тренажерный зал
            comboBox_Tren.Items.AddRange(Enumerable.Range(0, 11).Select(x => (object)x).ToArray());
            comboBox_Tren.SelectedItem = 3;
            // Персональные трени
            comboBox_Personal.Items.AddRange(Enumerable.Range(0, 31).Select(x => (object)x).ToArray());
            comboBox_Personal.SelectedItem = 3;
            // Аэробные
            comboBox_Aerob.Items.AddRange(Enumerable.Range(0, 121).Select(x => (object)x).ToArray());
            comboBox_Aerob.SelectedItem = 3;
            // Заморозки
            comboBox_freez.Items.AddRange(Enumerable.Range(0, 46).Select(x => (object)x).ToArray());
            comboBox_freez.SelectedItem = 45;
        }

        /// <summary>
        ///  Вызывать этот метод для задания абонемента пользователю.
        /// Тут сохраняется новый абонемент в историю абонементов
        /// </summary>
        public void ApplyChanges()
        {
            AbonementBasic abonementNew = null;
            switch (_selectedAbonementName)
            {
                case "Клубная Карта":
                    {
                        abonementNew = new ClubCardA(_pay, _timeTren, TypeWorkout.Тренажерный_Зал, _spa, _periodClubCard);
                        break;
                    }
                case "Абонемент":
                    {
                        abonementNew = new AbonementByDays(_pay, _timeTren, _typeWorkout, _spa, _daysInAbon);
                        break;
                    }
                case "Разовое Занятие":
                    {
                        abonementNew = new SingleVisit(_typeWorkout, _spa, _pay, _timeTren);
                        break;
                    }
                case "Гостевой визит":
                    {
                        abonementNew = new SingleVisit(_typeWorkout, _spa, Pay.Не_Оплачено, _timeTren);
                        _person.AbonementCurent = abonementNew;
                        _person.AbonementCurent.TryActivate();
                        var selectedOptions = new WorkoutOptions();
                        var dlgResult = FormsRunner.RunWorkoutOptionsForm(ref selectedOptions, _person.Name);
                        if (dlgResult == DialogResult.Cancel) return;

                        bool isSuccess = _person.AbonementCurent.CheckInWorkout(_person.AbonementCurent.TypeWorkout);

                        if (!isSuccess) return;
                        PersonObject.SaveCurentVisit(_person, selectedOptions); // Сохраняет текущий визит 
                        DailyVisits.GetInstance().AddToLog(_person.Name, selectedOptions); // Cобытие для добавления текущего посещения на главную форму
                        _person.Status = StatusPerson.Гостевой;
                        _person.SpecialNotes +=
                            $"\n\r Гостевой визит был: {DateTime.Now.ToString(new DateTimeFormatInfo().LongDatePattern)} ";
                        _person.AbonementCurent = null;
                        //тут добавить абонемент в список истории абонементов. Для гостевого визита.Ибо дальше выход
                        PersonObject.SaveAbonementToHistory(_person, abonementNew);
                        return;
                    }
            }

            if (_person.Status == StatusPerson.Гостевой) _person.Status = StatusPerson.Активный;

            ApplyCorrectedValues(ref abonementNew);//  Корректировка абонемента по дате, количеству оставшихся посещений
            _person.AbonementCurent = abonementNew;

            //тут добавить абонемент в список истории абонементов.
            PersonObject.SaveAbonementToHistory(_person, abonementNew);
        }

        private void ApplyCorrectedValues(ref AbonementBasic abonement)
        {
            if (!checkBox_Activated.Checked) return;

            var abonementCurent = abonement;
            var trenZalNum = int.Parse(comboBox_Tren.Text);
            var personNum = int.Parse(comboBox_Personal.Text);
            var aerobNum = int.Parse(comboBox_Aerob.Text);
            var freezeNum = int.Parse(comboBox_freez.Text);

            switch (abonementCurent.AbonementName)
            {
                case SingleVisit.NameAbonement:
                    return;
                case ClubCardA.NameAbonement:
                    {
                        (abonementCurent as ClubCardA)?.Freeze?.SetAvailableDays(freezeNum);
                        abonementCurent.NumAerobicTr = aerobNum;
                        abonementCurent.NumPersonalTr = personNum;

                        // Принудительно активируем. Дата в прошлом или в будущем допускается
                        abonementCurent.TryActivate(dateTimePicker_ActivationDate.Value);

                        break;
                    }
                case AbonementByDays.NameAbonement:
                    {
                        var nums = 0;
                        switch (((AbonementByDays)abonementCurent).TypeWorkout)
                        {
                            case TypeWorkout.Тренажерный_Зал:
                                nums = trenZalNum;
                                break;
                            case TypeWorkout.Аэробный_Зал:
                                nums = aerobNum;
                                break;
                            case TypeWorkout.Персональная:
                                nums = personNum;
                                break;
                            case TypeWorkout.МиниГруппа:
                                //     nums = personNum;
                                break;
                        }

                        ((AbonementByDays)abonementCurent).SetDaysLeft(nums);
                        break;
                    }
            }

            if (dateTimePicker_ActivationDate.Value.Date.CompareTo(DateTime.Now.Date) < 0)
            {
                abonementCurent.TryActivate(dateTimePicker_ActivationDate.Value);
            }
        }

        ///////////////// ОБРАБОТЧИКИ ////////////////////////////////
        private void button_Cancel(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton_Abonement_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _selectedAbonementName = AbonementByDays.NameAbonement;

                comboBox_Abonem.Visible = true;
                comboBox_ClubCard.Visible = false;

                radioButton_ClubCard.Checked = false;
                radioButton_Single.Checked = false;
                radioButton_guest.Checked = false;

                comboBox_Abonem.SelectedItem = _daysInAbon.ToString();
            }
            else
            {
                comboBox_Abonem.Visible = false;
            }
            UpdateCorrectFieldsEn();

            // RemoveItem(radioButton_Abonement);
        }

        private void RemAddMiniGroupItem(RadioButton button)
        {
            // Удаляем Мини группы из списка для всех кроме абонемента
            if (button.Checked)
            {
                if (!comboBox_TypeTren.Items.Contains(TypeWorkout.МиниГруппа.ToString())) return;

                comboBox_TypeTren.Items.Clear();
                var array = Enum.GetNames(typeof(TypeWorkout)).Where(x => (x != TypeWorkout.МиниГруппа.ToString()))
                    .Select(x => x);
                comboBox_TypeTren.Items.AddRange(array.ToArray<object>());
            }
            else
            {
                if (comboBox_TypeTren.Items.Contains(TypeWorkout.МиниГруппа.ToString())) return;

                comboBox_TypeTren.Items.Clear();
                comboBox_TypeTren.Items.AddRange(Enum.GetNames(typeof(TypeWorkout))
                    .ToArray<object>()); // Записываем Поля в Комбобокс
            }


        }

        private void radioButton_ClubCard_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _selectedAbonementName = ClubCardA.NameAbonement;

                comboBox_ClubCard.Visible = true;
                comboBox_Abonem.Visible = false;

                radioButton_Abonement.Checked = false;
                radioButton_Single.Checked = false;
                radioButton_guest.Checked = false;

                comboBox_ClubCard.SelectedItem = _periodClubCard.ToString();
                comboBox_TypeTren.SelectedItem = TypeWorkout.Тренажерный_Зал.ToString();
                comboBox_TypeTren.Enabled = false;
            }
            else
            {
                comboBox_ClubCard.Visible = false;
                comboBox_TypeTren.Enabled = true;
            }
            UpdateCorrectFieldsEn();
        }

        private void radioButton_Single_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _selectedAbonementName = "Разовое Занятие";
                RemAddMiniGroupItem(radioButton);
                comboBox_Abonem.Visible = false;
                comboBox_ClubCard.Visible = false;
                comboBox_TypeTren.SelectedItem = TypeWorkout.Тренажерный_Зал.ToString();
                radioButton_Abonement.Checked = false;
                radioButton_ClubCard.Checked = false;
                radioButton_guest.Checked = false;
            }
            else
            {
                RemAddMiniGroupItem(radioButton);
            }
            UpdateCorrectFieldsEn();
        }

        private void radioButton_guest_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                _selectedAbonementName = "Гостевой визит";
                //
                comboBox_Abonem.Visible = false;
                comboBox_ClubCard.Visible = false;
                comboBox_TypeTren.SelectedItem = TypeWorkout.Тренажерный_Зал.ToString();
                radioButton_Abonement.Checked = false;
                radioButton_ClubCard.Checked = false;
                radioButton_Single.Checked = false;
                groupBox_Correctable.Enabled = false;
            }


        }

        private void UpdateCorrectFieldsEn()
        {
            // Выходим если не нужна корректировка
            if (!checkBox_Activated.Checked) return;

            comboBox_Tren.Enabled = false;
            comboBox_Personal.Enabled = false;
            comboBox_Aerob.Enabled = false;
            comboBox_freez.Enabled = false;

            if (radioButton_Abonement.Checked)
            {
                if (comboBox_TypeTren.SelectedItem != null)
                {
                    _typeWorkout = MyComboBox.GetComboBoxValue<TypeWorkout>(comboBox_TypeTren);

                    switch (_typeWorkout)
                    {
                        case TypeWorkout.Тренажерный_Зал:
                            comboBox_Tren.Enabled = true;
                            break;
                        case TypeWorkout.Аэробный_Зал:
                            comboBox_Aerob.Enabled = true;
                            break;
                        case TypeWorkout.Персональная:
                            comboBox_Personal.Enabled = true;
                            break;
                        case TypeWorkout.МиниГруппа:
                            comboBox_Personal.Enabled = true;
                            break;
                    }
                    comboBox_freez.Enabled = true;
                }
            }

            if (radioButton_ClubCard.Checked)
            {
                comboBox_Personal.Enabled = true;
                comboBox_freez.Enabled = true;
                comboBox_Aerob.Enabled = true;
            }

        }

        private void ComboBox_time_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _timeTren = MyComboBox.GetComboBoxValue<TimeForTr>(combo);
        }
        private void ComboBox_spa_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _spa = MyComboBox.GetComboBoxValue<SpaService>(combo);
        }
        private void ComboBox_Pay_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _pay = MyComboBox.GetComboBoxValue<Pay>(combo);
        }
        private void ComboBox_Abonem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _daysInAbon = MyComboBox.GetComboBoxValue<DaysInAbon>(combo);
        }
        private void ComboBox_ClubCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _periodClubCard = MyComboBox.GetComboBoxValue<PeriodClubCard>(combo);
        }

        private void button_Aplly_Click(object sender, EventArgs e)
        {
            if (radioButton_Abonement.Checked && _daysInAbon == 0)
            {
                comboBox_Abonem.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox_Abonem.BackColor = Color.Pink;
                MessageBox.Show(@"Выберите Количество посещений!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (radioButton_ClubCard.Checked && _periodClubCard == 0)
            {
                comboBox_ClubCard.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox_ClubCard.BackColor = Color.Pink;

                MessageBox.Show(@"Выберите Длительность Клубной Карты!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (comboBox_TypeTren.SelectedItem == null)
            {
                comboBox_TypeTren.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox_TypeTren.BackColor = Color.Pink;
                MessageBox.Show(@"Выберите Тип тренировки!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (comboBox_Pay.SelectedItem == null)
            {
                comboBox_Pay.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox_Pay.BackColor = Color.Pink;
                MessageBox.Show(@"Уточните статус оплаты!", @"Оплата", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void comboBox_TypeTren_SelectedValueChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            try
            {
                _typeWorkout = MyComboBox.GetComboBoxValue<TypeWorkout>(combo);

            }
            catch (Exception)
            {
                MessageBox.Show(@"Exception 2");
            }

            UpdateCorrectFieldsEn();
        }

        private void checkBox_Activated_MouseClick(object sender, MouseEventArgs e)
        {
            Logic.AccessRootUser();
            if (PwdForm.IsPassUnLocked())
            {
                checkBox_Activated.CheckState = CheckState.Checked;

                flowLayoutPanel2.Enabled = true;
                if (checkBox_Activated.Checked) UpdateCorrectFieldsEn();
            }
            else
            {
                checkBox_Activated.CheckState = CheckState.Unchecked;
                flowLayoutPanel2.Enabled = false;
            }
        }
    }
}
