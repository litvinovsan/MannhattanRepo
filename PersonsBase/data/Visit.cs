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
      private Trener _trener;

      public List<Tuple<string, string>> SummaryAbonInfo;

      public TypeWorkout TypeWorkout { get => _typeWorkout; }
      public DateTime DateTimeVisit { get => _dateTimeVisit; }
      public Trener Trener { get => _trener; }

      // Конструкторы
      public Visit(AbonementBasic abon, TypeWorkout typeWorkout)
      {
         _dateTimeVisit = DateTime.Now;
         _typeWorkout = typeWorkout;
         SummaryAbonInfo = abon.GetShortInfoList();
      }
   }
}
