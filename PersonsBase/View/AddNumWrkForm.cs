using System;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class NumWorkoutForm : Form
    {
        private readonly AbonementBasic _abonement;
        private TypeWorkout _selectedTypeWorkout;
        private int _selectedValue;

        public NumWorkoutForm(AbonementBasic abonement)
        {
            InitializeComponent();

            _abonement = abonement;
            _selectedValue = 1;
            _selectedTypeWorkout = TypeWorkout.Персональная;

            var numbersAvailable = Options.NumAvailTrenToBuy;// 1,5,10 тренировок
            MyComboBox.Initialize(comboBox_num, numbersAvailable, numbersAvailable[0]);

            radioButton_mini.Visible = (abonement is ClubCardA);
        }

        public void ApplyChanges()
        {
            if (_abonement == null) return;
            switch (_selectedTypeWorkout)
            {
                case TypeWorkout.Персональная:
                    _abonement.NumPersonalTr += _selectedValue;
                    break;
                case TypeWorkout.Тренажерный_Зал:
                    break;
                case TypeWorkout.Аэробный_Зал:
                    _abonement.NumAerobicTr += _selectedValue;
                    break;
                case TypeWorkout.МиниГруппа:
                    _abonement.NumMiniGroup += _selectedValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // _selectedValue = Int32.Parse(comboBox_num.SelectedItem.ToString());
            //   var tmp = comboBox_num.SelectedValue.ToString();
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            var radioB = (RadioButton)sender;

            var numbersAvailable = Options.NumAvailTrenToBuy;// 1,5,10 тренировок по умолчанию


            if (radioB.Name == radioButton_personal.Name)
            {
                _selectedTypeWorkout = TypeWorkout.Персональная;
            }
            if (radioB.Name == radioButton_aerob.Name)
            {
                _selectedTypeWorkout = TypeWorkout.Аэробный_Зал;

            }
            if (radioB.Name == radioButton_mini.Name)
            {
                _selectedTypeWorkout = TypeWorkout.МиниГруппа;
                numbersAvailable = Options.NumAvailMiniGroup;//1, 8 
            }
            // Сколько тренировок доступно для конкретного типа трени
            MyComboBox.Initialize(comboBox_num, numbersAvailable, numbersAvailable[0]);
        }

        private void comboBox_num_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedValue = int.Parse(comboBox_num.SelectedItem.ToString());
        }


    }
}
