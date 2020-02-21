using System;
using System.Collections.Generic;

namespace PersonsBase.data.Abonements
{
    [Serializable]
    public class AbonementByDays : AbonementBasic //Абонемент на несколько занятий
    {
        private DaysInAbon _typeAbonement;
        private int _numAerobicTr1;
        private int _numPersonalTr1;
        private int ValidityPeriod = 2;
        public const string NameAbonement = "Абонемент";

        // Конструктор
        public AbonementByDays(Pay payStatus, TimeForTr time, TypeWorkout typeTr, SpaService spa, DaysInAbon numDays)
            : base(payStatus, time, typeTr, spa)
        {
            DaysLeft = (int)numDays;
            _typeAbonement = numDays;
            NumAerobicTr = 0;
            NumPersonalTr = 0;
            EndDate = DateTime.Now.AddMonths(2).Date;
        }

        // Свойства
        public override string AbonementName
        {
            get { return NameAbonement; }
        }

        public override string InfoMessageEnd
        {
            get { return "Абонемент Закончился!"; }
        }

        public sealed override int NumAerobicTr
        {
            get { return _numAerobicTr1; }
            set { _numAerobicTr1 = value; }
        }

        public sealed override int NumPersonalTr
        {
            get { return _numPersonalTr1; }
            set { _numPersonalTr1 = value; }
        }

        public DaysInAbon TypeAbonement
        {
            private get { return _typeAbonement; }
            set
            {
                _typeAbonement = value;
                OnValuesChanged();
            }
        }

        // Методы
        public override void TryActivate()
        {
            if (IsActivated) return; // Уже Активирован.
            IsActivated = true;
            var date = DateTime.Now.AddMonths(ValidityPeriod).Date;
            if (EndDate.Date.CompareTo(date) != 0)
                EndDate = date;
            BuyActivationDate = DateTime.Now.Date;
            OnValuesChanged();
        }

        public override void TryActivate(DateTime startDate)
        {
            // Если +, то DateTime.Now позднее startDate
            // Если 0, то даты совпали
            // Если -, то DateTime.Now раньше startdate
            if (DateTime.Now.Date.CompareTo(startDate) < 0) return;

            if (IsActivated) return; // Уже Активирован.
            IsActivated = true;
            BuyActivationDate = startDate;
            var date = startDate.AddMonths(ValidityPeriod).Date;
            if (EndDate.Date.CompareTo(date) != 0)
                EndDate = date;
            OnValuesChanged();
        }

        public override bool CheckInWorkout(TypeWorkout type)
        {
            bool result = false;
            if (IsValid())
            {
                DaysLeft--;
                result = true;
            }
           // OnValuesChanged();
            return result;
        }

        public override bool IsValid()
        {
            // Если +, то DateTime.Now позднее _endDate
            // Если 0, то даты совпали
            // Если -, то DateTime.Now раньше Конца абонемента
            return ((DateTime.Now.Date.CompareTo(EndDate.Date) <= 0) && (GetRemainderDays() > 0));
        }

        public override bool AddTrainingsToAbon(TypeWorkout type, int numberToAdd)
        {
            DaysLeft += numberToAdd;
            OnValuesChanged();
            return true;
        }

        public override IEnumerable<Tuple<string, string>> GetShortInfoList()
        {
            // Информация о текущем состоянии Абонемента. Добавляем всё что должно выводиться для Пользователя
            var result = new List<Tuple<string, string>>
          {
              new Tuple<string, string>("Тип: ", AbonementName),
              new Tuple<string, string>("Доступные Тренировки ", TypeWorkout.ToString()),
              new Tuple<string, string>("Время Тренировок ", TimeTraining.ToString()),
              new Tuple<string, string>("Осталось Занятий", GetRemainderDays().ToString()),
              new Tuple<string, string>("Услуги", Spa.ToString()),
              new Tuple<string, string>("Дата Активации", BuyActivationDate.ToString("d")),
              new Tuple<string, string>("Дата Окончания", EndDate.ToString("d"))
          };
            if (PayStatus == Pay.Не_Оплачено) { result.Add(new Tuple<string, string>("Статус Оплаты ", PayStatus.ToString())); }
            return result;
        }

        public override int GetRemainderDays()
        {
            return (DaysLeft > 0) ? DaysLeft : 0;
        }

        public DaysInAbon GetTypeAbonementByDays()
        {
            return TypeAbonement;
        }

        public void SetDaysLeft(int numberDaysLeft)
        {
            DaysLeft = numberDaysLeft;
            OnValuesChanged();
        }
    }
}
