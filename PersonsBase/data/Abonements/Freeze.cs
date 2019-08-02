using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBase
{
   [Serializable]
   public class Freeze
   {
      private int _freezeDays;
      private int _maxDaysAvailable;

      private DateTime _freezeStartDate;

      private const int _maxDaysMonth_3_6 = 30;
      private const int _maxDaysMonth_12 = 45;

      private readonly DateTime _dateDefault = DateTime.Parse("11.11.1111");
      private readonly PeriodClubCard _period;

      public static int _totalDays = 0;         // Потрачено дней заморозки

      public DateTime FreezeEndDate;

      public DateTime FreezeStartDate
      {
         get => _freezeStartDate;
         set
         {
            // Дата заморозки ещё в будущем 
            if (DateTime.Now.CompareTo(value) <= 0)
            {
               _freezeStartDate = value;
            }
            else
            {
               _freezeStartDate = _dateDefault;
            }
         }
      }

      public int FreezeDays
      {
         get => _freezeDays;
         set
         {
            if (IsPossibleFreezing(value))
            {
               _totalDays += value;
               _freezeDays = value;
            }
            else
            {
               _freezeDays = 0;
            }
         }
      }
      public bool IsPossibleFreezing(int numDays,DateTime dateStart)
      {
         if (numDays == 0) return false;
         var temp = numDays + _totalDays;
         return (temp <= _maxDaysAvailable) && (_totalDays <= _maxDaysAvailable)&& (DateTime.Now.CompareTo(dateStart) <= 0);
      }
      public bool IsPossibleFreezing(int numDays)
      {
         if (numDays == 0) return false;
         var temp = numDays + _totalDays;
         return (temp <= _maxDaysAvailable) && (_totalDays <= _maxDaysAvailable);
      }

      public Freeze(PeriodClubCard period, int numDays, DateTime startDate)
      {
         _period = period;
         _maxDaysAvailable = GetMaxDaysForFreeze(period);

         if (IsPossibleFreezing(numDays, startDate))
         {
            FreezeDays = numDays;
            FreezeStartDate = startDate;
            FreezeEndDate = startDate;
            FreezeEndDate.AddDays(numDays);
         }
         else
         {
            FreezeDays = 0;
            FreezeStartDate = _dateDefault;
            FreezeEndDate = _dateDefault;
            _totalDays = 0;
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

      private int GetMaxDaysForFreeze(PeriodClubCard period)
      {
         var per12 = PeriodClubCard.На_12_Месяцев;
         var per6 = PeriodClubCard.На_6_Месяцев;
         var per3 = PeriodClubCard.На_3_Месяца;

         int result = 0;
         if (period == per12)
         {
            result = _maxDaysMonth_12;
         }
         if (period == per6 || period == per3)
         {
            result = _maxDaysMonth_3_6;
         }
         return result;
      }
   }
}
// Если +, то DateTime.Now.CompareTo позднее endDate
// Если 0, то даты совпали
// Если -, то DateTime.Now раньше Конца абонемента
