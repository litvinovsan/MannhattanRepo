using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PBase;
using PersonsBase.data;
using System.Linq;

namespace PersonsBase.View
{
    public partial class TypeWorkoutForm : Form
    {
        private Person _person;
        private AbonementBasic _abonement;
        private List<Trener> _treners;
        private List<EntryInSchedule> _schedule; // 8:00 - Беговая
        private ManhattanInfo _manhattanInfo;
        private string selectedTrenerName;
        private string selectedGroupTimeName;

        // Итоговые Выбранные Данные
        public WorkoutOptions SelectedOptions;

        public TypeWorkoutForm(string personName)
        {
            InitializeComponent();
            SelectedOptions = new WorkoutOptions();// Обьект по умолчанию

            _manhattanInfo = DataObjects.GetManhattanInfo();
            _person = DataObjects.GetPersonLink(personName);
            _abonement = _person.AbonementCurent;
            _treners = _manhattanInfo.Treners;
            _schedule = _manhattanInfo.Schedule;

            // Скрываем Панели с РадиоБатоннами
            panel_aero.Visible = (_abonement.trainingsType == TypeWorkout.Аэробный_Зал || (_abonement.NumAerobicTr != 0)) ? true : false;
            panel_personal.Visible = (_abonement.trainingsType == TypeWorkout.Персональная || (_abonement.NumPersonalTr != 0)) ? true : false;

        }

        private void TypeWorkoutForm_Load(object sender, EventArgs e)
        {
            List<string> ActualTrenersNames = _treners.Select(x => x.Name).ToList<string>();
            List<string> ActualGroupTimeNames = _schedule.Select(x => $"{x.Time.SelectedTime} - {x.NameWorkout}").ToList<string>();

            // Смотрим Прошлый визит Клиента
            Visit lastVisit = null;
            string lastTrener = "";
            string lastGroupTimeName = "";

            if (_person.JournalVisits != null && _person.JournalVisits.Count > 0)
            {
                lastVisit = _person.JournalVisits.Last();
                switch (lastVisit.TypeWorkout)
                {
                    case TypeWorkout.Аэробный_Зал:
                        {
                            if (lastVisit.GroupWorkout.Trener != null)
                                lastTrener = (ActualTrenersNames.Contains(lastVisit.GroupWorkout.Trener.Name)) ? lastVisit.GroupWorkout.Trener.Name : "";
                            if (lastVisit.GroupWorkout != null)
                                lastGroupTimeName = (ActualGroupTimeNames.Contains(lastVisit.GroupWorkout.GetTimeAndNameStr())) ? lastVisit.GroupWorkout.GetTimeAndNameStr() : "";
                            break;
                        }
                    case TypeWorkout.Персональная:
                        {
                            if (lastVisit.Trener != null)
                                lastTrener = (ActualTrenersNames.Contains(lastVisit.Trener.Name)) ? lastVisit.Trener.Name : "";
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
                comboBox_treners.Items.AddRange(ActualTrenersNames.ToArray<object>());  // Заполняем комбобокс
                comboBox_treners.SelectedItem = lastTrener;
            }

            // Список с Расписанием Групповых тренировок
            if (_schedule.Count > 0)
            {
                comboBox_Time_Name_Workout.Items.Clear();
                comboBox_Time_Name_Workout.Items.AddRange(ActualGroupTimeNames.ToArray<object>());
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
            selectedTrenerName = combo.SelectedItem.ToString();
        }

        private void comboBox_Time_Name_Workout_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            selectedGroupTimeName = combo.SelectedItem.ToString();
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
                SelectedOptions.GroupTraining.Trener = _treners.Find(x => x.Name == selectedTrenerName);
                SelectedOptions.GroupTraining.SetTimeAndNameString(selectedGroupTimeName);
            }
            else
            {
                SelectedOptions.PersonalTrener = _treners.Find(x => x.Name == selectedTrenerName);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
