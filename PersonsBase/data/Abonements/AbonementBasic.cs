using System;
using System.Collections.Generic;

namespace PersonsBase.data.Abonements
{

    [Serializable]
    public abstract class AbonementBasic
    {
        // СОБЫТИЯ
        [field: NonSerialized]
        public event EventHandler EndDateChanged;
        private void OnEndDateChanged()
        {
            EndDateChanged?.Invoke(this, EventArgs.Empty);
        }
        // FIXME. Обьединить даты в одну структуру

        // ПОЛЯ и СВОЙСТВА
        public abstract string AbonementName { get; }
        public abstract string InfoMessageEnd { get; }
        public abstract int NumAerobicTr { get; set; } // Количество Аэробных тренировок. 10 в клубн карте,каждый месяц
        public abstract int NumPersonalTr { get; set; } // Количество Персональных тренировок. Могут быть добавлены к Клубному абонементу.
        public SpaService Spa;               // Услуги спа
        public Pay PayStatus;                // Оплачен?
        public TimeForTr TimeTraining;       // Время занятий
        public TypeWorkout TypeWorkout;    // Доступные тренировки
        public DateTime BuyActivationDate;             // Дата покупки// Дата активации

        public bool IsActivated;             // Активирован? Дата окончания отсчитывается с момента
        protected int DaysLeft { get; set; }  //Дней до конца абонемента, от активации,т.е. с первого посещения. 

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
        public abstract void TryActivate(DateTime startDate);

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
