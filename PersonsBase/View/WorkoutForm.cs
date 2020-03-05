using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PersonsBase.data;
using System.Linq;
using PersonsBase.data.Abonements;

namespace PersonsBase.View
{
    public partial class WorkoutForm : Form
    {
        private readonly Person _person;
        private readonly List<Trener> _treners;
        private readonly List<ScheduleNote> _schedule; // 8:00 - Беговая
        private string _selectedTrenerName;
        private string _selectedGroupTimeName;

        // Итоговые Выбранные Данные
        public readonly WorkoutOptions SelectedOptions;

        public WorkoutForm(string personName)
        {
            InitializeComponent();
            SelectedOptions = new WorkoutOptions();// Обьект по умолчанию

            _person = PersonObject.GetLink(personName);
            var abonement = _person.AbonementCurent;
            var manhattanInfo = DataBaseLevel.GetManhattanInfo();
            _treners = manhattanInfo.Treners;
            _schedule = manhattanInfo.Schedule;

            // Скрываем Панели с РадиоБатоннами
            panel_tren.Visible = false;
            panel_aero.Visible = false;
            panel_personal.Visible = false;
            panel_miniGroup.Visible = false;

            switch (abonement)
            {
                case ClubCardA clubCardA:
                    {
                        panel_tren.Visible = true;
                        panel_aero.Visible = (clubCardA.NumAerobicTr != 0);
                        panel_personal.Visible = clubCardA.NumPersonalTr != 0;
                        panel_miniGroup.Visible = clubCardA.NumMiniGroup > 0;
                        break;
                    }
                case AbonementByDays byDays:
                    {
                        panel_tren.Visible = byDays.TypeWorkout == TypeWorkout.Персональная ||
                                             byDays.TypeWorkout == TypeWorkout.МиниГруппа ||
                                             byDays.TypeWorkout == TypeWorkout.Тренажерный_Зал;

                        panel_aero.Visible = (byDays.TypeWorkout == TypeWorkout.Аэробный_Зал);
                        panel_personal.Visible = byDays.TypeWorkout == TypeWorkout.Персональная;
                        panel_miniGroup.Visible = byDays.GetRemainderDays() > 0 && byDays.TypeWorkout == TypeWorkout.МиниГруппа;

                        break;
                    }
                case SingleVisit singleVisit:
                    {
                        panel_tren.Visible = false;
                        panel_aero.Visible = (singleVisit.TypeWorkout == TypeWorkout.Аэробный_Зал);
                        panel_personal.Visible = singleVisit.TypeWorkout == TypeWorkout.Персональная;
                        panel_miniGroup.Visible = false;

                        break;
                    }
            }
        }

        private void WorkoutForm_Load(object sender, EventArgs e)
        {
            var actualTrenersNames = _treners.Select(x => x.Name).ToList();
            var actualSchedule = _schedule.Select(x => $"{x.Time.HourMinuteTime} - {x.WorkoutsName}").ToList();

            // Смотрим Прошлый визит Клиента
            var lastTrener = actualTrenersNames.FirstOrDefault();
            var lastGroupTimeName = actualSchedule.FirstOrDefault();
            var vi = PersonObject.GetVisitsList(_person.Name);
            if (vi != null && vi.Count > 0)
            {
                var lastVisit = vi.Last();
                switch (lastVisit.TypeWorkoutToday)
                {
                    case TypeWorkout.Аэробный_Зал:
                        {
                            if (lastVisit.GroupInfo?.ScheduleNote != null)
                            {
                                var timeNameString = lastVisit.GroupInfo.ScheduleNote.GetTimeAndNameStr();
                                lastGroupTimeName = (actualSchedule.Contains(timeNameString)) ? timeNameString : "Имя неизвестно";

                                lastTrener = (actualTrenersNames.Contains(lastVisit.GroupInfo.TrenerName)) ? lastVisit.GroupInfo.TrenerName : "Имя неизвестно";
                            }
                            break;
                        }
                    case TypeWorkout.Персональная:
                        {
                            if (lastVisit.PeronalTrenerName != null)
                                lastTrener = (actualTrenersNames.Contains(lastVisit.PeronalTrenerName)) ? lastVisit.PeronalTrenerName : "Имя неизвестно";
                            break;
                        }
                    case TypeWorkout.Тренажерный_Зал:
                        break;
                    case TypeWorkout.МиниГруппа:
                        {
                            if (lastVisit.PeronalTrenerName != null)
                                lastTrener = (actualTrenersNames.Contains(lastVisit.PeronalTrenerName)) ? lastVisit.PeronalTrenerName : "Имя неизвестно";
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            // Список тренеров 
            if (_treners.Count > 0)
            {
                comboBox_treners.Items.Clear();
                comboBox_treners.Items.AddRange(actualTrenersNames.ToArray<object>());  // Заполняем комбобокс
                comboBox_treners.SelectedItem = lastTrener != null && lastTrener.Equals("Имя неизвестно") ? actualTrenersNames.FirstOrDefault() : lastTrener;
            }

            // Список с Расписанием Групповых тренировок
            if (_schedule.Count > 0)
            {
                comboBox_Time_Name_Workout.Items.Clear();
                comboBox_Time_Name_Workout.Items.AddRange(actualSchedule.ToArray<object>());
                comboBox_Time_Name_Workout.SelectedItem = lastGroupTimeName != null && lastGroupTimeName.Equals("Имя неизвестно") ? actualSchedule.FirstOrDefault() : lastGroupTimeName;
            }
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;

            if (!radioButton.Checked) return;

            groupBox_TrenerName.Enabled = false;
            groupBox_SelectWorkout.Enabled = false;


            if (radioButton.Name == radioButton_tren.Name) // Тренажерный Зал
            {
                SelectedOptions.TypeWorkout = TypeWorkout.Тренажерный_Зал;
                radioButton_tren.Checked = true;

                radioButton_aerob.Checked = false;
                radioButton_personal.Checked = false;
                radioButton_miniGr.Checked = false;
            }
            else if (radioButton.Name == radioButton_aerob.Name) // Аэробные трени
            {
                SelectedOptions.TypeWorkout = TypeWorkout.Аэробный_Зал;
                groupBox_SelectWorkout.Enabled = true;
                groupBox_TrenerName.Enabled = true;
                radioButton_aerob.Checked = true;

                radioButton_tren.Checked = false;
                radioButton_personal.Checked = false;
                radioButton_miniGr.Checked = false;
            }
            else if (radioButton.Name == radioButton_personal.Name) // Персональные трени
            {
                SelectedOptions.TypeWorkout = TypeWorkout.Персональная;
                groupBox_TrenerName.Enabled = true;
                radioButton_personal.Checked = true;

                radioButton_tren.Checked = false;
                radioButton_aerob.Checked = false;
                radioButton_miniGr.Checked = false;
            }
            else if (radioButton.Name == radioButton_miniGr.Name) // Мини Группы
            {
                SelectedOptions.TypeWorkout = TypeWorkout.МиниГруппа;
                groupBox_TrenerName.Enabled = true;
                radioButton_miniGr.Checked = true;

                radioButton_tren.Checked = false;
                radioButton_aerob.Checked = false;
                radioButton_personal.Checked = false;
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
            if ((radioButton_tren.Checked == false && radioButton_aerob.Checked == false && radioButton_personal.Checked == false && radioButton_miniGr.Checked == false))
            {
                MessageBox.Show(@"Выберите один из вариантов");
                return;
            }

            switch (SelectedOptions.TypeWorkout)
            {
                case TypeWorkout.Аэробный_Зал:
                    {
                        SelectedOptions.GroupInfo.TrenerName = string.IsNullOrEmpty(_selectedTrenerName) ? "Имя неизвестно" : _selectedTrenerName;
                        SelectedOptions.GroupInfo.ScheduleNote.SetTimeAndNameString(_selectedGroupTimeName);
                        break;
                    }
                case TypeWorkout.Тренажерный_Зал:
                    break;
                case TypeWorkout.Персональная:
                    SelectedOptions.PersonalTrener = _treners?.Find(x => x.Name == _selectedTrenerName);
                    break;
                case TypeWorkout.МиниГруппа:
                    SelectedOptions.PersonalTrener = _treners?.Find(x => x.Name == _selectedTrenerName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            DialogResult = DialogResult.OK;
        }
    }
}
