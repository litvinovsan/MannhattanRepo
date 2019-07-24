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
      public TypeWorkout SelectedTypeWorkout;

      public WorkoutForm(AbonementBasic abonement)
      {
          InitializeComponent();
         var abonement1 = abonement;
         if (abonement1.NumAerobicTr == 0)
         {
            radioButton_aerob.Visible = false;
            pictureBox_aero.Visible = false;
         }
         if (abonement1.NumPersonalTr == 0)
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
               SelectedTypeWorkout = TypeWorkout.Персональная;
            }
            else if (radioButton.Name == radioButton_aerob.Name)
            {
               SelectedTypeWorkout = TypeWorkout.Аэробный_Зал;
            }
            else
            {
               SelectedTypeWorkout = TypeWorkout.Тренажерный_Зал;
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
