using System;
using System.Collections.Generic;

namespace PBase
{
   [Serializable]
   public class ClubCardA : AbonementBasic //Безлимитный Абонемент
   {
      // Свойства
      private int numberMonths;
      private int numAerobicTr;
      private PeriodClubCard periodAbonem;
      public PeriodClubCard PeriodAbonem
      {
         get
         {
            return periodAbonem;
         }
         set
         {
            periodAbonem = value;
            numberMonths = (int)periodAbonem;
            numAerobicTr = numberMonths * 10;
         }
      }
      public override string AbonementName => "Клубная Карта";
      public override string InfoWhenEnd => "Клубная Карта Закончилась!";

      public override int NumAerobicTr
      {
         get
         {
            return numAerobicTr;
         }
         set
         {
            if (value >= 0 && value <= numberMonths * 10)
            { numAerobicTr = value; }
         }
      }
      public sealed override int NumPersonalTr { get; set; }
      public Freeze Freeze;

      // Конструктор
      public ClubCardA(Pay payStatus, TimeForTr time, TypeWorkout typeTr, SpaService spa, PeriodClubCard periodInMonths)
         : base(payStatus, time, typeTr, spa)
      {
         numberMonths = (int)periodInMonths;
         numAerobicTr = numberMonths * 10;
         NumPersonalTr = 0;
         periodAbonem = periodInMonths;
         endDate = DateTime.Now.AddMonths(numberMonths).Date;
         UpdateDaysLeft();
      }

      // Методы
      public override bool isValid()
      {
         // Если +, то DateTime.Now позднее endDate
         // Если 0, то даты совпали
         // Если -, то DateTime.Now раньше Конца абонемента
         var checkDate = (DateTime.Now.Date.CompareTo(endDate.Date) <= 0);
         return checkDate;
      }

      public override void TryActivate()
      {
         if (isActivated) return; // Уже Активирован.
         isActivated = true;
         endDate = DateTime.Now.AddMonths(numberMonths).Date;
         UpdateDaysLeft();
      }

      private void UpdateDaysLeft()
      {
         DaysLeft = (endDate.Date - DateTime.Now.Date).Days;
      }

      public override bool CheckInWorkout(TypeWorkout type)
      {
         bool result = false;

         if (isValid()) // Карта не кончилась по дням и есть занятия персональные или Аэробные
         {
            switch (type)
            {
               case TypeWorkout.Аэробный_Зал:
                  {
                     if (NumAerobicTr > 0)
                     {
                        --NumAerobicTr;
                        result = true;
                     }
                     break;
                  }
               case TypeWorkout.Персональная:
                  {
                     if (NumPersonalTr > 0)
                     {
                        --NumPersonalTr;
                        result = true;
                     }
                     break;
                  }
               default:
                  {
                     result = true;
                     break;
                  }
            }
         }
         return result;
      }

      /// <summary>
      /// Добавить Блок Персональных или Аэробных тренировок к Клубной Карте
      /// </summary>
      public override bool AddTrainingsToAbon(TypeWorkout type, int numberToAdd)
      {
         bool result;

         switch (type)
         {
            case TypeWorkout.Аэробный_Зал:
               {
                  NumAerobicTr += numberToAdd;
                  result = true;
                  break;
               }
            case TypeWorkout.Персональная:
               {
                  NumPersonalTr += numberToAdd;
                  result = true;
                  break;
               }
            default:
               {
                  result = false;
                  break;
               }
         }
         return result;
      }

      public override List<Tuple<string, string>> GetShortInfoList()
      {
         // Информация о текущем состоянии Абонемента. Добавляем всё что должно выводиться для Пользователя
         List<Tuple<string, string>> result = new List<Tuple<string, string>>
          {
              new Tuple<string, string>("Тип: ", AbonementName),
              new Tuple<string, string>("Доступные Тренировки ", trainingsType.ToString()),
              new Tuple<string, string>("Время Тренировок ", timeTraining.ToString()),
              new Tuple<string, string>("Услуги", spa.ToString()),
              new Tuple<string, string>("Срок Клубной Карты", numberMonths +"  мес."),
              new Tuple<string, string>("Дата Окончания Карты", endDate.Date.ToString("d")),
              new Tuple<string, string>("Осталось Дней", GetRemainderDays().ToString())
          };
         if (NumPersonalTr > 0) { result.Add(new Tuple<string, string>("Осталось Персональных", NumPersonalTr.ToString())); }
         if (NumAerobicTr > 0) { result.Add(new Tuple<string, string>("Осталось Аэробных", NumAerobicTr.ToString())); }
         if (payStatus == Pay.Не_Оплачено) { result.Add(new Tuple<string, string>("Статус Оплаты ", payStatus.ToString())); }

         return result;
      }

      public override int GetRemainderDays()
      {
         UpdateDaysLeft();
         return DaysLeft;
      }

      public void UpdateEndDate()
      {
         endDate = DateTime.Now.AddMonths(numberMonths).Date;
         UpdateDaysLeft();
      }

      public PeriodClubCard GetTypeClubCard()
      {
         return PeriodAbonem;
      }

      public void SetTypeClubCard(PeriodClubCard newTypeCC)
      {
         PeriodAbonem = newTypeCC;
      }
   }

}
