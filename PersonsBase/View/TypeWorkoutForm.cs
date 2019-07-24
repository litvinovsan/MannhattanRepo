using PBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonsBase.View
{
   public partial class WorkoutForm : Form
   {
      public TypeWorkout selectedTypeWorkout;

      private AbonementBasic _abonement;
      public WorkoutForm(AbonementBasic abonement)
      {
         InitializeComponent();
         _abonement = abonement;
         if (_abonement.NumAerobicTr == 0)
         {
            radioButton_aerob.Visible = false;
            pictureBox_aero.Visible = false;
         }
         if (_abonement.NumPersonalTr == 0)
         {
            radioButton_personal.Visible = false;
            pictureBox_person.Visible = false;
         }
      }

      private void button_Cancel_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void radioButtons_CheckedChanged(object sender, EventArgs e)
      {
         // приводим отправителя к элементу типа RadioButton
         RadioButton radioButton = (RadioButton)sender;
         if (radioButton.Checked)
         {
            if (radioButton.Name == radioButton_personal.Name)
            {
               selectedTypeWorkout = TypeWorkout.Персональная;
            }
            else if (radioButton.Name == radioButton_aerob.Name)
            {
               selectedTypeWorkout = TypeWorkout.Аэробный_Зал;
            }
            else
            {
               selectedTypeWorkout = TypeWorkout.Тренажерный_Зал;
            }
         }
      }

      private void WorkoutForm_Load(object sender, EventArgs e)
      {

      }

      private void button_Ok_Click(object sender, EventArgs e)
      {

      }
   }
}
