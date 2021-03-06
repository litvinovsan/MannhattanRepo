﻿using System;
using System.Collections.Generic;

namespace PersonsBase.data.Abonements
{
   [Serializable]
   public class AbonementByDays : AbonementBasic //Абонемент на несколько занятий
   {
      private DaysInAbon _typeAbonement;
      private int _numAerobicTr1;
      private int _numPersonalTr1;
      private int _validityPeriod;
      public const string NameAbonement = "Абонемент";

      // Конструктор
      public AbonementByDays(Pay payStatus, TimeForTr time, TypeWorkout typeTr, SpaService spa, DaysInAbon numDays)
          : base(payStatus, time, typeTr, spa)
      {
         DaysLeft = (int)numDays;
         _typeAbonement = numDays;
         NumAerobicTr = 0;
         NumPersonalTr = 0;
         _validityPeriod = (typeTr == TypeWorkout.Персональная || typeTr == TypeWorkout.МиниГруппа)
             ? Options.ValidPeriod12Month: Options.ValidPeriodInMonth;
         // 12 месяцев - длительность абонемента с персональными тренировками
         EndDate = CalculateEndDate(DateTime.Now, _validityPeriod);
      }


      // Свойства
      public override string AbonementName
      {
         get { return NameAbonement; }
      }

      public override string InfoMessageEnd
      {
         get { return "Абонемент Закончился!"; }
      }

      public sealed override int NumAerobicTr
      {
         get { return _numAerobicTr1; }
         set { _numAerobicTr1 = value; }
      }

      public sealed override int NumPersonalTr
      {
         get { return _numPersonalTr1; }
         set { _numPersonalTr1 = value; }
      }

      public DaysInAbon TypeAbonement
      {
         get { return _typeAbonement; }
         set
         {
            _typeAbonement = value;
            OnValuesChanged();
         }
      }

      // Методы
      public override void TryActivate(DateTime newDate)
      {
         // Если +, то DateTime.Now позднее newDate
         // Если 0, то даты совпали
         // Если -, то DateTime.Now раньше newDate

         if (IsActivated) return; // Уже Активирован.
         IsActivated = true;

         if (_validityPeriod == 0) _validityPeriod = Options.ValidPeriodInMonth;
         var date = newDate.AddMonths(_validityPeriod).Date;
         if (EndDate.Date.CompareTo(date) != 0)
         {
            EndDate = date;
            BuyActivationDate = newDate;
            OnValuesChanged();
         }
      }

      public override bool CheckInWorkout(TypeWorkout type)
      {
         bool result = false;
         if (IsValid())
         {
            DaysLeft--;
            result = true;
         }
         return result;
      }

      public override bool IsValid()
      {
         // Если +, то DateTime.Now позднее _endDate
         // Если 0, то даты совпали
         // Если -, то DateTime.Now раньше Конца абонемента

         DateTime finishDate = (TypeWorkout == TypeWorkout.Персональная || TypeWorkout == TypeWorkout.МиниГруппа) ?
             CalculateEndDate(BuyActivationDate, Options.ValidPeriod12Month) :
             CalculateEndDate(BuyActivationDate, Options.ValidPeriodInMonth);

         return ((DateTime.Now.Date.CompareTo(finishDate.Date) <= 0) && (GetRemainderDays() > 0));
      }

      public override bool AddTrainingsToAbon(TypeWorkout type, int numberToAdd)
      {
         DaysLeft += numberToAdd;
         OnValuesChanged();
         return true;
      }

      public override IEnumerable<Tuple<string, string>> GetShortInfoList()
      {
         // Информация о текущем состоянии Абонемента. Добавляем всё что должно выводиться для Пользователя
         var result = new List<Tuple<string, string>>
          {
              new Tuple<string, string>("Тип: ", AbonementName),
              new Tuple<string, string>("Доступные Тренировки ", TypeWorkout.ToString()),
              new Tuple<string, string>("Время Тренировок ", TimeTraining.ToString()),
              new Tuple<string, string>("Осталось Занятий", GetRemainderDays().ToString()),
              new Tuple<string, string>("Услуги", Spa.ToString()),
              new Tuple<string, string>("Дата Покупки", BuyDate.ToString("d")),
              new Tuple<string, string>("Дата Активации", BuyActivationDate.ToString("d")),
              new Tuple<string, string>("Дата Окончания", CalculateEndDate(BuyActivationDate, Options.ValidPeriodInMonth).ToString("d"))
          };
         if (PayStatus == Pay.Не_Оплачено) { result.Add(new Tuple<string, string>("Статус Оплаты ", PayStatus.ToString())); }
         return result;
      }

      public override int GetRemainderDays()
      {
         return (DaysLeft > 0) ? DaysLeft : 0;
      }

      public DaysInAbon GetTypeAbonementByDays()
      {
         return TypeAbonement;
      }

      public void SetDaysLeft(int numberDaysLeft)
      {
         DaysLeft = numberDaysLeft;
         OnValuesChanged();
      }

      public void SetNewEndDate(int numberMonths, DateTime dateEndNew)
      {
         if (numberMonths <= 0) return;
         if (_validityPeriod.Equals(numberMonths)) return;
         EndDate = dateEndNew;
         _validityPeriod = numberMonths;
      }

      /// <summary>
      /// Вычисляет дату окончания. Складывает число месяцев с стартовой датой
      /// </summary>
      /// <param name="startDate"></param>
      /// <param name="months"></param>
      /// <returns></returns>
      private static DateTime CalculateEndDate(DateTime startDate, int months)
      {
         return startDate.AddMonths(months).Date;
      }

      public override string GetAbonementType()
      {
         return TypeWorkout.ToString();
      }
   }
}
