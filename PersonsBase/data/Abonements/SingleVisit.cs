using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBase
{

   [Serializable]
   public class SingleVisit : AbonementBasic
   {
      // Конструктор
      public SingleVisit(TypeWorkout typeTr, SpaService spa, Pay payStatus, TimeForTr time)
         : base(payStatus, time, typeTr, spa)
      {
         numAerobicTr = 0;
         numPersonalTr = 0;
         DaysLeft = 1;
         endDate = DateTime.Now.Date;
      }

      // Свойства
      private int numAerobicTr;
      private int numPersonalTr;
      public sealed override int NumAerobicTr { get { return numAerobicTr; } set { if (numAerobicTr >= 0) numAerobicTr = value; } }
      public sealed override int NumPersonalTr { get { return numPersonalTr; } set { if (numPersonalTr >= 0) numPersonalTr = value; } }
      public override string AbonementName => "Разовое Занятие";
      public override string InfoWhenEnd => "Нет активных разовых посещений!";

      // Методы
      public override void TryActivate()
      {
         if (isActivated) return; // Уже Активирован.
         isActivated = true;
         endDate = DateTime.Now.Date;
      }

      public override bool CheckInWorkout(TypeWorkout type)
      {
         if (DaysLeft > 0)
         {
            DaysLeft--;
            return true;
         }
         else return false;
      }



      public override bool isValid()
      {
         return (DaysLeft > 0);
      }

      /// <summary>
      /// Неиспользуется тут.
      /// </summary>
      public override bool AddTrainingsToAbon(TypeWorkout type, int numberToAdd)
      { // FIXME. Протестировать, может быть этот метод тут и нужен.
         return false;
      }

      public override List<Tuple<string, string>> GetShortInfoList()
      {
         // Информация о текущем состоянии Абонемента. Добавляем всё что должно выводиться для Пользователя
         List<Tuple<string, string>> result = new List<Tuple<string, string>>
          {
              new Tuple<string, string>("Тип: ", AbonementName),
              new Tuple<string, string>("Доступные Тренировки ", this.trainingsType.ToString()),
              new Tuple<string, string>("Услуги", this.spa.ToString())
          };

         if (NumPersonalTr > 0) { result.Add(new Tuple<string, string>("Осталось Персональных", NumPersonalTr.ToString())); }
         if (NumAerobicTr > 0) { result.Add(new Tuple<string, string>("Осталось Аэробных", NumAerobicTr.ToString())); }
         if (payStatus == Pay.Не_Оплачено) { result.Add(new Tuple<string, string>("Статус Оплаты ", this.payStatus.ToString())); }

         return result;
      }

      public override int GetRemainderDays()
      {
         return DaysLeft;
      }
   }
}
