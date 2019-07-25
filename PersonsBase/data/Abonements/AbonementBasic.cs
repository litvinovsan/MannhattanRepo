using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBase
{

   // Или интерфейс
   [Serializable]
   public abstract class AbonementBasic
   {
      abstract public string AbonementName { get; }
      abstract public string InfoWhenEnd { get; }
      abstract public int NumAerobicTr { get; set; } // Количество Аэробных тренировок. 10 в клубн карте,каждый месяц
      abstract public int NumPersonalTr { get; set; } // Количество Персональных тренировок. Могут быть добавлены к Клубному абонементу.
      public SpaService spa;               // Услуги спа
      public Pay payStatus;                // Оплачен?
      public TimeForTr timeTraining;       // Время занятий
      public TypeWorkout trainingsType;    // Доступные тренировки
      public DateTime buyDate;             // Дата покупки
      public DateTime endDate;             // Дата завершения абонемента. 
      public bool isActivated;             // Активирован? Дата окончания отсчитывается с момента
      public int DaysLeft { get; set; }  //Дней до конца абонемента, от активации,т.е. с первого посещения. 

      // Конструктор
      public AbonementBasic(Pay payStatus, TimeForTr time, TypeWorkout tr, SpaService spa)
      {
         this.payStatus = payStatus;
         this.timeTraining = time;
         this.trainingsType = tr;
         this.spa = spa;
         this.isActivated = false;
         this.buyDate = DateTime.Now.Date;
      }

      //Методы
      /// <summary>
      /// Абонемент не кончился по Дате или Посещениям?
      /// </summary>
      abstract public bool isValid(); // FIXME. Для всех методов дописать проверку на непустую очередь абонементов.
      /// <summary>
      /// Активация абонемента. Устанавливается дата окончания.
      /// </summary>
      abstract public void TryActivate();
      /// <summary>
      /// Отметить и Учесть посещение в абонементе
      /// </summary>
      abstract public bool CheckInWorkout(TypeWorkout type);
      /// <summary>
      ///  Добавление Персональных или Аэробных тренировок к текущему абонементу.  
      /// </summary>
      abstract public bool AddTrainingsToAbon(TypeWorkout type, int numberToAdd);
      abstract public List<Tuple<string, string>> GetShortInfoList();
      /// <summary>
      /// Получить оставшиеся в абонементе дни
      /// </summary>
      /// <returns></returns>
      abstract public int GetRemainderDays(); // Осталось дней
   }
}
