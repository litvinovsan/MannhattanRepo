using System;
using System.Windows.Forms;
using PBase;

namespace PersonsBase.View
{
   public partial class WorkoutForm : Form
   {
      public TypeWorkout SelectedTypeWorkout;
      public Trener SelectedTrener;

      public WorkoutForm(AbonementBasic abonement)
      {
         InitializeComponent();

         SelectedTrener = new Trener();

         if (abonement.NumAerobicTr == 0)
         {
            radioButton_aerob.Visible = false;
            pictureBox_aero.Visible = false;
         }
         if (abonement.NumPersonalTr == 0)
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
   }
}
