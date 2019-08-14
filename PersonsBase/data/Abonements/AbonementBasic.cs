﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PBase
{

   // Или интерфейс
   [Serializable]
   public abstract class AbonementBasic
   {
      [field: NonSerialized]
      public event EventHandler EndDateChanged;
      public void OnEndDateChanged()
      {
         EndDateChanged?.Invoke(this, EventArgs.Empty);
      }

      public abstract string AbonementName { get; }
      public abstract string InfoWhenEnd { get; }
      public abstract int NumAerobicTr { get; set; } // Количество Аэробных тренировок. 10 в клубн карте,каждый месяц
      public abstract int NumPersonalTr { get; set; } // Количество Персональных тренировок. Могут быть добавлены к Клубному абонементу.
      public SpaService spa;               // Услуги спа
      public Pay payStatus;                // Оплачен?
      public TimeForTr timeTraining;       // Время занятий
      public TypeWorkout trainingsType;    // Доступные тренировки
      public DateTime buyDate;             // Дата покупки
      public bool isActivated;             // Активирован? Дата окончания отсчитывается с момента
      public int DaysLeft { get; set; }  //Дней до конца абонемента, от активации,т.е. с первого посещения. 

      private DateTime _endDate;             // Дата завершения абонемента. 
      public DateTime EndDate
      {
         get
         {
            return _endDate;
         }
         set
         {
            _endDate = value;
            OnEndDateChanged();
         }
      }

      // Конструктор
      public AbonementBasic(Pay payStatus, TimeForTr time, TypeWorkout tr, SpaService spa)
      {
         this.payStatus = payStatus;
         timeTraining = time;
         trainingsType = tr;
         this.spa = spa;
         isActivated = false;
         buyDate = DateTime.Now.Date;
      }

      //Методы
      /// <summary>
      /// Абонемент не кончился по Дате или Посещениям?
      /// </summary>
      public abstract bool IsValid();
      /// <summary>
      /// Активация абонемента. Устанавливается дата окончания.
      /// </summary>
      public abstract void TryActivate();
      /// <summary>
      /// Отметить и Учесть посещение в абонементе
      /// </summary>
      public abstract bool CheckInWorkout(TypeWorkout type);
      /// <summary>
      ///  Добавление Персональных или Аэробных тренировок к текущему абонементу.  
      /// </summary>
      public abstract bool AddTrainingsToAbon(TypeWorkout type, int numberToAdd);
      public abstract List<Tuple<string, string>> GetShortInfoList();
      /// <summary>
      /// Получить оставшиеся в абонементе дни
      /// </summary>
      /// <returns></returns>
      public abstract int GetRemainderDays(); // Осталось дней

      //public bool TrySelectWorkoutType(out TypeWorkout typeWrk)
      //{
      //   bool result = false;

      //   if (NumAerobicTr == 0 && NumPersonalTr == 0)
      //   {
      //      typeWrk = trainingsType;
      //   }
      //   else
      //   {
      //      using (var workoutForm = new WorkoutForm(AbonementCurent))
      //      {
      //         if (workoutForm.ShowDialog() == DialogResult.OK)
      //         {
      //            typeWrk = workoutForm.SelectedTypeWorkout;
      //         }
      //      }
      //   }

      //   return result;
      //}
   }
}
