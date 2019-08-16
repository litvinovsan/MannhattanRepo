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
     

      public List<Tuple<string, string>> SummaryAbonInfo;

      public TypeWorkout TypeWorkout { get => _typeWorkout; }
      public DateTime DateTimeVisit { get => _dateTimeVisit; }
      

      // Конструкторы
      public Visit(AbonementBasic abon, TypeWorkout typeWorkout)
      {
         _dateTimeVisit = DateTime.Now;
         _typeWorkout = typeWorkout;
         SummaryAbonInfo = abon.GetShortInfoList();
      }
   }
}
