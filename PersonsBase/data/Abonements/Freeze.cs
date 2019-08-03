﻿using System;

namespace PBase
{
   [Serializable]
   public class Freeze
   {
      private int _freezeDays;
      private readonly int _maxDaysAvailable;

      private DateTime _freezeStartDate;

      private const int MaxDaysMonth36 = 30;
      private const int MaxDaysMonth12 = 45;

      private readonly DateTime _dateDefault = DateTime.Parse("11.11.1111").Date;

      public static int TotalDays;         // Потрачено дней заморозки

      public DateTime FreezeEndDate;

      private DateTime FreezeStartDate
      {
         get
         {
            return _freezeStartDate;
         } 
         set
         {
            // Дата заморозки ещё в будущем 
            if (DateTime.Now.Date.CompareTo(value.Date) <= 0)
            {
               _freezeStartDate = value;
               FreezeEndDate = value;
            }
            else
            {
               _freezeStartDate = _dateDefault;
            }
         }
      }

      private int FreezeDays
      {
         get
         {
             return _freezeDays;
         }
         set
         {
            if (IsPossibleFreezing(value))
            {
               TotalDays += value;
               _freezeDays = value;
            }
            else
            {
               _freezeDays = 0;
            }
         }
      }

      private bool IsPossibleFreezing(int numDays, DateTime dateStart)
      {
         if (numDays == 0) return false;
         var temp = numDays + TotalDays;
         var dateCmpr = (DateTime.Now.Date.CompareTo(dateStart.Date) <= 0);// Дата заморозки в будущем
         return (temp <= _maxDaysAvailable) && (TotalDays <= _maxDaysAvailable) && dateCmpr;
      }

      private bool IsPossibleFreezing(int numDays)
      {
         if (numDays == 0) return false;
         int temp = numDays + TotalDays;
         return (temp <= _maxDaysAvailable) && (TotalDays <= _maxDaysAvailable);
      }

      public Freeze(PeriodClubCard period, int numDays, DateTime startDate)
      {
          _maxDaysAvailable = GetMaxDaysForFreeze(period);

         if (IsPossibleFreezing(numDays, startDate))
         {
            FreezeDays = numDays;
            FreezeStartDate = startDate;
            FreezeEndDate = FreezeStartDate.AddDays(numDays);
         }
         else
         {
            FreezeDays = 0;
            FreezeStartDate = _dateDefault;
            FreezeEndDate = _dateDefault;
         }
      }

      /// <summary>
      /// Возвращает true если Клиент в Заморозке на сегодняшнюю дату
      /// </summary>
      /// <returns></returns>
      public bool IsFreezedNow()
      {
         bool result = (FreezeDays > 0) && (DateTime.Now.CompareTo(FreezeStartDate) >= 0) && (DateTime.Now.CompareTo(FreezeEndDate) <= 0);

         return result;
      }
      public bool IsConfigured()
      {
         return (FreezeDays != 0) && (FreezeStartDate != _dateDefault) && (FreezeEndDate != _dateDefault);
      }
      public int GetRemainDays()
      {
         return _maxDaysAvailable - TotalDays;
      }
      private int GetMaxDaysForFreeze(PeriodClubCard period)
      {
         var per12 = PeriodClubCard.На_12_Месяцев;
         var per6 = PeriodClubCard.На_6_Месяцев;
         var per3 = PeriodClubCard.На_3_Месяца;

         int result = 0;
         if (period == per12)
         {
            result = MaxDaysMonth12;
         }
         if (period == per6 || period == per3)
         {
            result = MaxDaysMonth36;
         }
         return result;
      }

   }
}
// Если +, то DateTime.Now.CompareTo позднее endDate
// Если 0, то даты совпали
// Если -, то DateTime.Now раньше Конца абонемента
