using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBase
{
   [Serializable]
   public class AbonementByDays : AbonementBasic //Абонемент на несколько занятий
   {
      // Конструктор
      public AbonementByDays(Pay payStatus, TimeForTr time, TypeWorkout typeTr, SpaService spa, DaysInAbon numDays)
          : base(payStatus, time, typeTr, spa)
      {
         DaysLeft = (int)numDays;
         typeAbonement = numDays;
         NumAerobicTr = 0;  // Нужны тут только из-за абстракции. 
         NumPersonalTr = 0; // Нужны тут только из-за абстракции. 
         endDate = DateTime.Now.AddMonths(2).Date;
      }

      // Свойства
      public sealed override int NumAerobicTr { get; set; }
      public sealed override int NumPersonalTr { get; set; }
      public override string AbonementName { get { return "Абонемент"; } }
      public override string InfoWhenEnd => "Абонемент Закончился!";
      private DaysInAbon typeAbonement { get; set; }

      // Методы
      public override void TryActivate()
      {
         if (isActivated) return; // Уже Активирован.
         isActivated = true;
         endDate = DateTime.Now.AddMonths(2).Date;
      }

      public override bool CheckInWorkout(TypeWorkout type)
      {
         bool result = false;
         if (isValid())
         {
            this.DaysLeft--;
            result = true;
         }
         return result;
      }

      public override bool isValid()
      {
         // Если +, то DateTime.Now позднее endDate
         // Если 0, то даты совпали
         // Если -, то DateTime.Now раньше Конца абонемента
         return ((DateTime.Now.Date.CompareTo(endDate.Date) <= 0) && (GetRemainderDays() > 0));
      }

      public override bool AddTrainingsToAbon(TypeWorkout type, int numberToAdd)
      {
         DaysLeft += numberToAdd;
         return true;
      }

      public override List<Tuple<string, string>> GetShortInfoList()
      {
         // Информация о текущем состоянии Абонемента. Добавляем всё что должно выводиться для Пользователя
         var result = new List<Tuple<string, string>>
          {
              new Tuple<string, string>("Тип: ", AbonementName),
              new Tuple<string, string>("Доступные Тренировки ", trainingsType.ToString()),
              new Tuple<string, string>("Время Тренировок ", timeTraining.ToString()),
              new Tuple<string, string>("Осталось Занятий", GetRemainderDays().ToString()),
              new Tuple<string, string>("Услуги", spa.ToString()),
              new Tuple<string, string>("Дата Окончания", endDate.ToString("d"))
          };
         if (payStatus == Pay.Не_Оплачено) { result.Add(new Tuple<string, string>("Статус Оплаты ", this.payStatus.ToString())); }
         return result;
      }

      public override int GetRemainderDays()
      {
         return (this.DaysLeft > 0) ? this.DaysLeft : 0;
      }

      public DaysInAbon GetTypeAbonementByDays()
      {
         return typeAbonement;
      }

      public void SetTypeAbonementByDays(DaysInAbon numberDaysType)
      {
         this.typeAbonement = numberDaysType;
         DaysLeft = (int)numberDaysType;
      }
   }
}
