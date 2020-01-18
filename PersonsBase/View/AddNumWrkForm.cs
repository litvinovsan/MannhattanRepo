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
            comboBox_num.Items.AddRange(numAvailTrenToBuy); // 1,5,10 тренировок
            comboBox_num.SelectedItem = numAvailTrenToBuy[0];
        }

        public void ApplyChanges()
        {
            if (_abonement == null) return;
            if (_selectedTypeWorkout == TypeWorkout.Персональная)
            {
                _abonement.NumPersonalTr += _selectedValue;
            }
            else
            {
                _abonement.NumAerobicTr += _selectedValue;
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
            _selectedTypeWorkout = radioButton_personal.Checked ? TypeWorkout.Персональная : TypeWorkout.Аэробный_Зал;
        }

        private void comboBox_num_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedValue = Int32.Parse(comboBox_num.SelectedItem.ToString());
        }
    }
}
