using PersonsBase.data;
using PersonsBase.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PBase
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


        // ПОЛЯ и СВОЙСТВА
        public abstract string AbonementName { get; }
        public abstract string InfoMessageEnd { get; }
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

        // КОНСТРУКТОР
        protected AbonementBasic(Pay payStatus, TimeForTr time, TypeWorkout tr, SpaService spa)
        {
            this.payStatus = payStatus;
            timeTraining = time;
            trainingsType = tr;
            this.spa = spa;
            isActivated = false;
            buyDate = DateTime.Now.Date;
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
    }
}
