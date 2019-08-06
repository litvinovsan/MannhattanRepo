using System;
using System.Windows.Forms;

namespace PBase
{
   [Serializable]
   public class FreezeClass
   {
      // Поля и Свойства
      private int _freezeDays;
      private int _totalDays;         // Счетчик дней заморозки

      private readonly int _maxDaysAvailable;
      private readonly DateTime _dateDefault;

      private DateTime _freezeStartDate;

      private const int MaxDaysMonth36 = 30;
      private const int MaxDaysMonth12 = 45;

      public DateTime FreezeEndDate;
      public DateTime FreezeStartDate
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
         get { return _freezeDays; }
         set
         {
            if (IsPossibleToFreeze(value))
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

      // Конструктор
      public FreezeClass(PeriodClubCard period)
      {
         _maxDaysAvailable = GetMaxDays(period);
         _totalDays = 0;
         _dateDefault = DateTime.Parse("11.11.1111").Date;

         FreezeDays = 0;
         FreezeStartDate = _dateDefault;
         FreezeEndDate = _dateDefault;
      }

      /// <summary>
      /// Возвращает true если Клиент в Заморозке на сегодняшнюю дату
      /// </summary>
      public bool IsFreezedNow()
      {
         bool result = (FreezeDays > 0) && (DateTime.Now.CompareTo(FreezeStartDate) >= 0) && (DateTime.Now.CompareTo(FreezeEndDate) <= 0);

         return result;
      }
      /// <summary>
      /// Заморозка настроена успешно
      /// </summary>
      public bool IsConfigured()
      {
         return (FreezeDays != 0) && (FreezeStartDate != _dateDefault) && (FreezeEndDate != _dateDefault);
      }
      public int GetRemainDays() // Сколько осталось дней заморозки в абонементе
      {
         return _maxDaysAvailable - _totalDays;
      }
      public int GetSpentDays() // Сколько использовано дней заморозки уже
      {
         return _totalDays;
      }
      public int GetDaysToFreeze() // Сколько Дней запланировано
      {
         return FreezeDays;
      }
      public bool TryConfigure(int numDays, DateTime startDate)
      {
         bool result = false;

         if (IsPossibleToFreeze(numDays, startDate))
         {
            FreezeDays = numDays;
            FreezeStartDate = startDate;
            FreezeEndDate = FreezeStartDate.AddDays(numDays);
            result = true;
         }
         return result;
      }
      public void Remove()
      {
         _totalDays = 0;
         FreezeDays = 0;
         FreezeStartDate = _dateDefault;
         FreezeEndDate = _dateDefault;
         MessageBox.Show("Удалены все заморозки!");
      }

      private int GetMaxDays(PeriodClubCard period)
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
      private bool IsPossibleToFreeze(int numDays, DateTime dateStart)
      {
         if (numDays == 0) return false;
         var temp = numDays + _totalDays;
         var dateCmpr = (DateTime.Now.Date.CompareTo(dateStart.Date) <= 0);// Дата заморозки в будущем
         return (temp <= _maxDaysAvailable) && (_totalDays <= _maxDaysAvailable) && dateCmpr;
      }
      private bool IsPossibleToFreeze(int numDays)
      {
         if (numDays == 0) return false;
         int temp = numDays + _totalDays;
         return (temp <= _maxDaysAvailable) && (_totalDays <= _maxDaysAvailable);
      }
   }
}
// Если +, то DateTime.Now.CompareTo позднее _endDate
// Если 0, то даты совпали
// Если -, то DateTime.Now раньше Конца абонемента
