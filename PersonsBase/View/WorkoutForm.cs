using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PBase;
using PersonsBase.data;
using System.Linq;

namespace PersonsBase.View
{
    public partial class WorkoutForm : Form
    {
        private readonly Person _person;
        private AbonementBasic _abonement;
        private readonly List<Trener> _treners;
        private readonly List<ScheduleNote> _schedule; // 8:00 - Беговая
        private readonly ManhattanInfo _manhattanInfo;
        private string _selectedTrenerName;
        private string _selectedGroupTimeName;

        // Итоговые Выбранные Данные
        public readonly WorkoutOptions SelectedOptions;

        public WorkoutForm(string personName)
        {
            InitializeComponent();
            SelectedOptions = new WorkoutOptions();// Обьект по умолчанию

            _manhattanInfo = DataObjects.GetManhattanInfo();
            _person = DataObjects.GetPersonLink(personName);
            _abonement = _person.AbonementCurent;
            _treners = _manhattanInfo.Treners;
            _schedule = _manhattanInfo.Schedule;

            // Скрываем Панели с РадиоБатоннами
            panel_tren.Visible = (!(_abonement is SingleVisit)) || ((_abonement.NumAerobicTr != 0) || (_abonement.NumPersonalTr != 0));
            panel_aero.Visible = (_abonement.trainingsType == TypeWorkout.Аэробный_Зал || (_abonement.NumAerobicTr != 0)) ? true : false;
            panel_personal.Visible = (_abonement.trainingsType == TypeWorkout.Персональная || (_abonement.NumPersonalTr != 0)) ? true : false;
        }

        private void WorkoutForm_Load(object sender, EventArgs e)
        {
            List<string> actualTrenersNames = _treners.Select(x => x.Name).ToList<string>();
            List<string> actualSchedule = _schedule.Select(x => $"{x.Time.HourMinuteTime} - {x.WorkoutsName}").ToList<string>();

            // Смотрим Прошлый визит Клиента
            string lastTrener = "";
            string lastGroupTimeName = "";

            if (_person.JournalVisits != null && _person.JournalVisits.Count > 0)
            {
                var lastVisit = _person.JournalVisits.Last();
                switch (lastVisit.TypeWorkout)
                {
                    case TypeWorkout.Аэробный_Зал:
                        {
                            if (lastVisit.GroupInfo != null)
                            {
                                var timeNameString = lastVisit.GroupInfo.scheduleNote.GetTimeAndNameStr();
                                lastGroupTimeName = (actualSchedule.Contains(timeNameString)) ? timeNameString : "";

                                if (lastVisit.GroupInfo.Trener != null)
                                    lastTrener = (actualTrenersNames.Contains(lastVisit.GroupInfo.Trener.Name)) ? lastVisit.GroupInfo.Trener.Name : "";
                            }
                            break;
                        }
                    case TypeWorkout.Персональная:
                        {
                            if (lastVisit.TrenerIfPersonal != null)
                                lastTrener = (actualTrenersNames.Contains(lastVisit.TrenerIfPersonal.Name)) ? lastVisit.TrenerIfPersonal.Name : "";
                            break;
                        }
                    default:
                        break;
                }
            }

            // Список тренеров 
            if (_treners.Count > 0)
            {
                comboBox_treners.Items.Clear();
                comboBox_treners.Items.AddRange(actualTrenersNames.ToArray<object>());  // Заполняем комбобокс
                comboBox_treners.SelectedItem = lastTrener;
            }

            // Список с Расписанием Групповых тренировок
            if (_schedule.Count > 0)
            {
                comboBox_Time_Name_Workout.Items.Clear();
                comboBox_Time_Name_Workout.Items.AddRange(actualSchedule.ToArray<object>());
                comboBox_Time_Name_Workout.SelectedItem = lastGroupTimeName;
            }
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked)
            {
                if (radioButton.Name == radioButton_personal.Name)
                {
                    SelectedOptions.TypeWorkout = TypeWorkout.Персональная;
                    radioButton_aerob.Checked = false;
                    radioButton_tren.Checked = false;
                    groupBox_SelectWorkout.Enabled = false;
                    groupBox_TrenerName.Enabled = true;
                }
                else if (radioButton.Name == radioButton_aerob.Name)
                {
                    SelectedOptions.TypeWorkout = TypeWorkout.Аэробный_Зал;
                    radioButton_personal.Checked = false;
                    radioButton_tren.Checked = false;
                    groupBox_SelectWorkout.Enabled = true;
                    groupBox_TrenerName.Enabled = true;
                }
                else
                {
                    SelectedOptions.TypeWorkout = TypeWorkout.Тренажерный_Зал;
                    radioButton_personal.Checked = false;
                    radioButton_aerob.Checked = false;
                    groupBox_SelectWorkout.Enabled = false;
                    groupBox_TrenerName.Enabled = false;
                }
            }
        }

        private void comboBox_treners_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _selectedTrenerName = combo.SelectedItem.ToString();
        }

        private void comboBox_Time_Name_Workout_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            _selectedGroupTimeName = combo.SelectedItem.ToString();
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if (radioButton_tren.Checked == false && radioButton_aerob.Checked == false && radioButton_personal.Checked == false)
            {
                MessageBox.Show("Выберите один из вариантов");
                return;
            }
            if (SelectedOptions.TypeWorkout == TypeWorkout.Аэробный_Зал)
            {
                SelectedOptions.GroupInfo.Trener = _treners.Find(x => x.Name == _selectedTrenerName);
                SelectedOptions.GroupInfo.scheduleNote.SetTimeAndNameString(_selectedGroupTimeName);
            }
            else
            {
                SelectedOptions.PersonalTrener = _treners.Find(x => x.Name == _selectedTrenerName);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
