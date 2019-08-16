using PBase;
using System;
using System.Collections.Generic;

namespace PersonsBase.data
{
   [Serializable]
   public class Visit
   {
      private TypeWorkout _typeWorkout;
      private DateTime _dateTimeVisit;

      public TypeWorkout TypeWorkout
      {
         get
         {
            return _typeWorkout;
         }
      }
      public DateTime DateTimeVisit
      {
         get
         {
            return _dateTimeVisit;
         }
      }

      public readonly List<Tuple<string, string>> SummaryAbonInfo;
      public readonly CGroupTraining GroupTrainingValues;
      public readonly Trener PTrener;

      // Конструкторы
      public Visit(AbonementBasic abon, CWorkoutOptions workoutOptions)
      {
         _typeWorkout = workoutOptions.TypeWorkout;
         _dateTimeVisit = DateTime.Now;

         SummaryAbonInfo = abon.GetShortInfoList();

         GroupTrainingValues = workoutOptions.GroupTraining;

         PTrener = workoutOptions.PersonalTrener;
      }
   }
}
