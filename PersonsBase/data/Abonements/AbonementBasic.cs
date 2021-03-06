﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace PersonsBase.data.Abonements
{

   [Serializable]
   public abstract class AbonementBasic
   {
      #region /// СОБЫТИЯ
      [field: NonSerialized]
      public event EventHandler EndDateChanged;
      private void OnEndDateChanged()
      {
         EndDateChanged?.Invoke(this, EventArgs.Empty);
      }

      [field: NonSerialized]
      public event EventHandler ValuesChanged;

      protected void OnValuesChanged()
      {
         ValuesChanged?.Invoke(this, EventArgs.Empty);
      }

      #endregion

      // ПОЛЯ и СВОЙСТВА
      public abstract string AbonementName { get; }
      public abstract string InfoMessageEnd { get; }

      public abstract int NumAerobicTr { get; set; }

      public abstract int NumPersonalTr { get; set; }
      // Количество Персональных тренировок. Могут быть добавлены к Клубному абонементу.

      public int NumMiniGroup
      {
         get { return _numMiniGroup; }
         set
         {
            _numMiniGroup = (value >= 0) ? value : 0;
            OnValuesChanged();
         }
      }

      public SpaService Spa;               // Услуги спа
      public Pay PayStatus;                // Оплачен?
      public TimeForTr TimeTraining;       // Время занятий
      public TypeWorkout TypeWorkout;    // Доступные тренировки
      /// <summary>
      /// Фактически это ДАТА АКТИВАЦИИ СЕЙЧАС
      /// </summary>
      public DateTime BuyActivationDate;             //  Дата активации
      public FreezeClass Freeze;
      //  FIXME Добавить событие, если изменился статус активации, то нужно сбросить дату окончиния и подумать о валидации
      public bool IsActivated;             // Активирован? Дата окончания отсчитывается с момента
      protected int DaysLeft { get; set; }  //Дней до конца абонемента, от активации,т.е. с первого посещения. 

      private DateTime _endDate;             // Дата завершения абонемента. 
      private int _numMiniGroup;
      private DateTime _buyDate;

      public DateTime EndDate
      {
         get
         {
            return _endDate;
         }
         set
         {
            if (_endDate.Date.CompareTo(value.Date) == 0) return;
            _endDate = value;
            OnEndDateChanged();
         }
      }

      public DateTime BuyDate
      {
         get
         {

            if (_buyDate.CompareTo(DefaultDateTime) == 0)
            {
               return BuyActivationDate;
            }
            else
            {
               return _buyDate;
            }
         }
         private set { _buyDate = value; }
      } // Дата покупки

      private static readonly DateTime DefaultDateTime = DateTime.Parse("01.01.0001");

      // КОНСТРУКТОР
      protected AbonementBasic(Pay payStatus, TimeForTr time, TypeWorkout tr, SpaService spa)
      {
         this.PayStatus = payStatus;
         TimeTraining = time;
         TypeWorkout = tr;
         this.Spa = spa;
         IsActivated = false;
         BuyActivationDate = DateTime.Now.Date;
         BuyDate = DateTime.Now.Date;
      }
      protected AbonementBasic()
      {
         this.PayStatus = Pay.Не_Оплачено;
         TimeTraining = TimeForTr.Весь_День;
         TypeWorkout = TypeWorkout.Тренажерный_Зал;
         this.Spa = SpaService.Спа;
         IsActivated = false;
         BuyActivationDate = DateTime.Now.Date;
         BuyDate = DateTime.Now.Date;
      }

      //МЕТОДЫ АБСТРАКТНЫЕ

      /// <summary>
      /// Абонемент не кончился по Дате или Посещениям?
      /// </summary>
      public abstract bool IsValid();
      /// <summary>
      /// Активация абонемента. Устанавливается дата окончания.
      /// </summary>
      public abstract void TryActivate(DateTime newDate);
      /// <summary>
      /// Отметить и Учесть посещение в абонементе
      /// </summary>
      public abstract bool CheckInWorkout(TypeWorkout type);
      /// <summary>
      ///  Добавление Персональных или Аэробных тренировок к текущему абонементу.  
      /// </summary>
      public abstract bool AddTrainingsToAbon(TypeWorkout type, int numberToAdd);
      public abstract IEnumerable<Tuple<string, string>> GetShortInfoList();
      /// <summary>
      /// Получить оставшиеся в абонементе дни
      /// Получить оставшиеся в абонементе дни
      /// </summary>
      /// <returns></returns>
      public abstract int GetRemainderDays(); // Осталось дней
      /// <summary>
      /// Возвращает Тип Абонемента/Карты.
      /// Для Клубной Карты это длительность в месяцах
      /// Для Абонемента - Тип тренировок Минигруппа, Персоналка и т д
      /// </summary>
      /// <returns></returns>
      public abstract string GetAbonementType();

   }
}
