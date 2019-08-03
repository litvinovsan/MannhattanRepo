using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PBase
{
   [Serializable]
   public class ClubCardA : AbonementBasic //Безлимитный Абонемент
   {
      // Свойства
      private int _numberMonths;
      private int _numAerobicTr;
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
            _numberMonths = (int)periodAbonem;
            _numAerobicTr = _numberMonths * 10;
         }
      }
      public override string AbonementName => "Клубная Карта";
      public override string InfoWhenEnd => "Клубная Карта Закончилась!";

      public override int NumAerobicTr
      {
         get
         {
            return _numAerobicTr;
         }
         set
         {
            if (value >= 0 && value <= _numberMonths * 10)
            { _numAerobicTr = value; }
         }
      }
      public sealed override int NumPersonalTr { get; set; }

      public FreezeClass Freeze;
      //public 
      // Конструктор
      public ClubCardA(Pay payStatus, TimeForTr time, TypeWorkout typeTr, SpaService spa, PeriodClubCard periodInMonths)
         : base(payStatus, time, typeTr, spa)
      {
         _numberMonths = (int)periodInMonths;
         _numAerobicTr = _numberMonths * 10;
         NumPersonalTr = 0;
         periodAbonem = periodInMonths;
         endDate = DateTime.Now.AddMonths(_numberMonths).Date;
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
         endDate = DateTime.Now.AddMonths(_numberMonths).Date;
         UpdateDaysLeft();
      }

      private void UpdateDaysLeft()
      {
         int numFreezDays = 0;
         if (Freeze != null) numFreezDays = Freeze.GetSpentDays(); //Вычитаем дни заморозки
         DaysLeft = (endDate.Date - DateTime.Now.Date).Days - numFreezDays;
      }

      public override bool CheckInWorkout(TypeWorkout type)
      {
         bool result = false;

         if (!isValid()) return false;
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
         var result = new List<Tuple<string, string>>
          {
              new Tuple<string, string>("Тип: ", AbonementName),
              new Tuple<string, string>("Доступные Тренировки ", trainingsType.ToString()),
              new Tuple<string, string>("Время Тренировок ", timeTraining.ToString()),
              new Tuple<string, string>("Услуги", spa.ToString()),
              new Tuple<string, string>("Срок Клубной Карты", _numberMonths +"  мес."),
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
         endDate = DateTime.Now.AddMonths(_numberMonths).Date;
         UpdateDaysLeft();
      }

      public PeriodClubCard GetTypeClubCard()
      {
         return PeriodAbonem;
      }

      public void SetTypeClubCard(PeriodClubCard newTypeCc)
      {
         PeriodAbonem = newTypeCc;
      }
      public bool TryFreezeClubCard(int numDays, DateTime startDate)
      {
         bool result = false;

         if (Freeze == null)
         {
            Freeze = new FreezeClass(PeriodAbonem);
         }

         bool isConfigured = Freeze.TryConfigure(numDays, startDate);

         if (isConfigured)
         {
            MessageBox.Show($"Заморозка начинается c {startDate.ToString("d")}.\n\rОсталось дней: {Freeze.GetRemainDays()} ");

            endDate = endDate.AddDays(numDays);
            result = true;
         }
         else
         {
            MessageBox.Show($"Ошибка! Возможно, не хватает дней или не корректная дата.\n\rОсталось дней: {Freeze.GetRemainDays()}");
         }
         return result;
      }
   }

}
