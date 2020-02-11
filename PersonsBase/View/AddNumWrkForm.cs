using System;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.data.Abonements;

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

            var numAvailTrenToBuy = Options.NumAvailTrenToBuy;
            comboBox_num.Items.AddRange(numAvailTrenToBuy); // 1,5,8,10 тренировок
            comboBox_num.SelectedItem = numAvailTrenToBuy[0];

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
                    _abonement.NumPersonalTr += _selectedValue;
                    break;
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

            }
        }

        private void comboBox_num_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedValue = Int32.Parse(comboBox_num.SelectedItem.ToString());
        }


    }
}
