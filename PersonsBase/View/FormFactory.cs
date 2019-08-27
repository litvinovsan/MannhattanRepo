using PBase;
using PersonsBase.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonsBase.View
{
   public class FormFactory
   {
      private Options _options;
      private Person _person;

      public FormFactory(Options _opt, Person person)
      {
         _options = _opt;
      }

      public DialogResult RunWorkout(out CWorkoutOptions optionsWorkout)
      {
         DialogResult dlgReult = DialogResult.Cancel;
         optionsWorkout = new CWorkoutOptions();
         var workoutForm = new WorkoutForm(_person.AbonementCurent);

         dlgReult = workoutForm.ShowDialog();
         if (dlgReult == DialogResult.OK)
         {
            optionsWorkout = workoutForm.SelectedOptions;

         }
         return dlgReult;
      }


   }
}
