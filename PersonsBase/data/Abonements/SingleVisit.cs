using System;
using System.Collections.Generic;

namespace PersonsBase.data.Abonements
{

   [Serializable]
   public class SingleVisit : AbonementBasic
   {
      // Конструктор
      public SingleVisit(TypeWorkout typeTr, SpaService spa, Pay payStatus, TimeForTr time)
         : base(payStatus, time, typeTr, spa)
      {
         _numAerobicTr = 0;
         _numPersonalTr = 0;
         DaysLeft = 1;
         EndDate = DateTime.Now.Date;
      }

      // Свойства
      private int _numAerobicTr;
      private int _numPersonalTr;
      public sealed override int NumAerobicTr
      {
         get
         {
            return _numAerobicTr;
         }
         set
         {
            if (_numAerobicTr >= 0) _numAerobicTr = value;
            OnValuesChanged();
         }
      }
      public sealed override int NumPersonalTr { get { return _numPersonalTr; } set { if (_numPersonalTr >= 0) _numPersonalTr = value; OnValuesChanged(); } }
      public const string NameAbonement = "Разовое Занятие";
      public override string AbonementName
      {
         get { return NameAbonement; }
      }

      public override string InfoMessageEnd
      {
         get { return "Нет активных разовых посещений!"; }
      }

      // Методы
      public override void TryActivate(DateTime newDate)
      {
         if (IsActivated) return; // Уже Активирован.
         IsActivated = true;
         EndDate = newDate;
         OnValuesChanged();
      }

      public override bool CheckInWorkout(TypeWorkout type)
      {
         if (DaysLeft <= 0) return false;
         DaysLeft--;
         //  OnValuesChanged();
         return true;
      }

      public override bool IsValid()
      {
         return (DaysLeft > 0);
      }

      public override IEnumerable<Tuple<string, string>> GetShortInfoList()
      {
         // Информация о текущем состоянии Абонемента. Добавляем всё что должно выводиться для Пользователя
         var result = new List<Tuple<string, string>>
          {
              new Tuple<string, string>("Тип: ", AbonementName),
              new Tuple<string, string>("Доступные Тренировки ", TypeWorkout.ToString()),
              new Tuple<string, string>("Услуги", Spa.ToString()),
              new Tuple<string, string>("Дата Покупки",BuyDate.ToShortDateString()),
              new Tuple<string, string>("Дата Активации",BuyActivationDate.ToShortDateString())
          };

         if (NumPersonalTr > 0) { result.Add(new Tuple<string, string>("Осталось Персональных", NumPersonalTr.ToString())); }
         if (NumAerobicTr > 0) { result.Add(new Tuple<string, string>("Осталось Аэробных", NumAerobicTr.ToString())); }
         if (PayStatus == Pay.Не_Оплачено) { result.Add(new Tuple<string, string>("Статус Оплаты ", PayStatus.ToString())); }

         return result;
      }

      public override int GetRemainderDays()
      {
         return DaysLeft;
      }

      public override bool AddTrainingsToAbon(TypeWorkout type, int numberToAdd)
      {
         return false; //  Заглушка
      }

      public override string GetAbonementType()
      {
         return TypeWorkout.ToString();
      }
   }
}
