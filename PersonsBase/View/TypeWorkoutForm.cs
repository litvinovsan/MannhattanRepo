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
               radioButton_aerob.Checked = false;
               radioButton_tren.Checked = false;
            }
            else if (radioButton.Name == radioButton_aerob.Name)
            {
               SelectedTypeWorkout = TypeWorkout.Аэробный_Зал;
               radioButton_personal.Checked = false;
               radioButton_tren.Checked = false;
            }
            else
            {
               SelectedTypeWorkout = TypeWorkout.Тренажерный_Зал;
               radioButton_personal.Checked = false;
               radioButton_aerob.Checked = false;
            }
         }
      }
   }
}
