﻿using System;
using System.Windows.Forms;

namespace PBase
{
    public partial class NumWorkoutForm : Form
    {
        private readonly AbonementBasic _abonement;
        private TypeWorkout _selectedTypeWorkout;
        private int _selectedValue;
        // FIXME вытащить в настройки или общие ресурсы этот массив
        private readonly object[] _numberToAdd = { "1", "5", "10" };


        public NumWorkoutForm(AbonementBasic abonement)
        {
            InitializeComponent();

            _abonement = abonement;
            _selectedValue = 1;
            _selectedTypeWorkout = TypeWorkout.Персональная;

            comboBox_num.Items.AddRange(_numberToAdd);
            comboBox_num.SelectedItem = _numberToAdd[0];
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
