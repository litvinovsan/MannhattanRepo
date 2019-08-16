using System;
using System.Windows.Forms;
using PBase;
using PersonsBase.data;

namespace PersonsBase.View
{
   public partial class WorkoutForm : Form
   {
      //private TypeWorkout _selectedTypeWorkout;
      //private Trener _selectedTrener;
      public CWorkoutOptions SelectedOptions;

      public WorkoutForm(AbonementBasic abonement)
      {
         InitializeComponent();
         SelectedOptions = new CWorkoutOptions();

         if (abonement.NumAerobicTr == 0)
         {
            panel_aero.Visible = false;
            this.Height = this.Height - panel_aero.Height;
         }
         if (abonement.NumPersonalTr == 0)
         {
            panel_personal.Visible = false;
            this.Height = this.Height - panel_personal.Height;
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
               //Показать
            }
            else if (radioButton.Name == radioButton_aerob.Name)
            {
               SelectedOptions.TypeWorkout = TypeWorkout.Аэробный_Зал;
               radioButton_personal.Checked = false;
               radioButton_tren.Checked = false;
               //Показать
            }
            else
            {
               SelectedOptions.TypeWorkout = TypeWorkout.Тренажерный_Зал;
               radioButton_personal.Checked = false;
               radioButton_aerob.Checked = false;
            }
         }
      }
      private void button_Cancel_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
