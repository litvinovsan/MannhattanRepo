using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PersonsBase.data.Abonements
{
    [DataContract]
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
        [DataMember]
        public abstract string AbonementName { get; }

        [DataMember]
        public abstract string InfoMessageEnd { get; }

        [DataMember]
        public abstract int NumAerobicTr { get; set; }

        [DataMember]
        public abstract int NumPersonalTr { get; set; }
        // Количество Персональных тренировок. Могут быть добавлены к Клубному абонементу.

        [DataMember]
        public int NumMiniGroup
        {
            get { return _numMiniGroup; }
            set
            {
                _numMiniGroup = (value >= 0) ? value : 0;
                OnValuesChanged();
            }
        }

        [DataMember]
        public SpaService Spa;               // Услуги спа

        [DataMember]
        public Pay PayStatus;                // Оплачен?

        [DataMember]
        public TimeForTr TimeTraining;       // Время занятий

        [DataMember]
        public TypeWorkout TypeWorkout;    // Доступные тренировки

        [DataMember]
        public DateTime BuyActivationDate;             // Дата покупки// Дата активации

        [DataMember]
        public FreezeClass Freeze;

        [DataMember]
        public bool IsActivated;             // Активирован? Дата окончания отсчитывается с момента

        [DataMember]
        protected int DaysLeft { get; set; }  //Дней до конца абонемента, от активации,т.е. с первого посещения. 

        private DateTime _endDate;             // Дата завершения абонемента. 
        private int _numMiniGroup;

        [DataMember]
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

        // КОНСТРУКТОР
        protected AbonementBasic(Pay payStatus, TimeForTr time, TypeWorkout tr, SpaService spa)
        {
            this.PayStatus = payStatus;
            TimeTraining = time;
            TypeWorkout = tr;
            this.Spa = spa;
            IsActivated = false;
            BuyActivationDate = DateTime.Now.Date;
        }
        protected AbonementBasic()
        {
            this.PayStatus = Pay.Не_Оплачено;
            TimeTraining = TimeForTr.Весь_День;
            TypeWorkout = TypeWorkout.Тренажерный_Зал;
            this.Spa = SpaService.Спа;
            IsActivated = false;
            BuyActivationDate = DateTime.Now.Date;
        }

        //МЕТОДЫ АБСТРАКТНЫЕ

        /// <summary>
        /// Абонемент не кончился по Дате или Посещениям?
        /// </summary>
        public abstract bool IsValid();
        /// <summary>
        /// Активация абонемента. Устанавливается дата окончания.
        /// </summary>
        public abstract void TryActivate();
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
    }
}
