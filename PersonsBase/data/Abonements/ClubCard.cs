using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBase
{
   [Serializable]
   public class ClubCardAbonement : AbonementBasic //Безлимитный Абонемент
   {
      // Конструктор
      public ClubCardAbonement(Pay payStatus, TimeForTr time, TypeWorkout typeTr, SpaService spa, PeriodClubCard periodInMonths)
         : base(payStatus, time, typeTr, spa)
      {
         numberMonths = (int)periodInMonths;
         numAerobicTr = numberMonths * 10;
         NumPersonalTr = 0;
         periodAbonem = periodInMonths;

         endDate = DateTime.Now.AddMonths(numberMonths).Date;
         UpdateDaysLeft();
      }

      // Свойства
      private int numberMonths;
      private int numAerobicTr;
      private PeriodClubCard periodAbonem;
      private PeriodClubCard PeriodAbonem
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

      // Методы
      public override bool isValid()
      {
         // Если +, то DateTime.Now позднее endDate
         // Если 0, то даты совпали
         // Если -, то DateTime.Now раньше Конца абонемента
         var checkDate = (DateTime.Now.Date.CompareTo(endDate.Date) <= 0);
         var checkWorkouts = (NumAerobicTr > 0 || NumPersonalTr > 0);

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
         DaysLeft = (int)(endDate.Date - DateTime.Now.Date).Days;
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
              new Tuple<string, string>("Доступные Тренировки ", this.trainingsType.ToString()),
              new Tuple<string, string>("Время Тренировок ", this.timeTraining.ToString()),
              new Tuple<string, string>("Услуги", this.spa.ToString()),
              new Tuple<string, string>("Срок Клубной Карты", this.numberMonths.ToString() +"  мес."),
              new Tuple<string, string>("Дата Окончания Карты", this.endDate.Date.ToString("d")),
              new Tuple<string, string>("Осталось Дней", GetRemainderDays().ToString())
          };
         if (NumPersonalTr > 0) { result.Add(new Tuple<string, string>("Осталось Персональных", NumPersonalTr.ToString())); }
         if (NumAerobicTr > 0) { result.Add(new Tuple<string, string>("Осталось Аэробных", NumAerobicTr.ToString())); }
         if (this.payStatus == Pay.Не_Оплачено) { result.Add(new Tuple<string, string>("Статус Оплаты ", this.payStatus.ToString())); }

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
         //numberMonths = (int)newTypeCC;
      }
      public bool ShowSelectWindow()
      {
         bool result = (NumAerobicTr > 0 && NumPersonalTr > 0);

         return result;
      }
   }

}
