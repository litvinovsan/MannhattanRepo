using PBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsBase.data
{
   [Serializable]
   public class CGroupTraining
   {
      public string TrainingsName { get; set; }
      public string Notes { get; set; }
      public Trener Trener { get; set; }
      public MyTime StartTime { get; set; }

      public CGroupTraining(string nameTraining, MyTime startTime)
      {
         TrainingsName = nameTraining;
         StartTime = startTime;
      }
      public CGroupTraining()
      {
         TrainingsName = "Dummy";
      }
   }

   [Serializable]
   public class CWorkoutOptions
   {
      public TypeWorkout TypeWorkout { get; set; }
      public Trener PersonalTrener { get; set; }
      public CGroupTraining GroupTraining { get; set; }

   }
}
