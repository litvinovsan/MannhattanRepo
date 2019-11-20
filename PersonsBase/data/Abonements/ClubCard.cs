﻿using System;
using System.Collections.Generic;
using PersonsBase.data.Abonements;

namespace PBase
{
    [Serializable]
    public class ClubCardA : AbonementBasic //Безлимитный Абонемент
    {
        // Свойства
        private int _numberMonths;
        private int _numAerobicTr;

        private PeriodClubCard _periodAbonem;
        public PeriodClubCard PeriodAbonem
        {
            get
            {
                return _periodAbonem;
            }
            set
            {
                _periodAbonem = value;
                _numberMonths = (int)_periodAbonem;
                _numAerobicTr = _numberMonths * 10;
                SetNewEndDate();
            }
        }
        public override string AbonementName => "Клубная Карта";
        public override string InfoMessageEnd => "Клубная Карта Закончилась!";

        public override int NumAerobicTr
        {
            get
            {
                return _numAerobicTr;
            }
            set
            {
                if (value >= 0 && value <= _numberMonths * 10)
                { _numAerobicTr = value; }
            }
        }
        public sealed override int NumPersonalTr { get; set; }

        public FreezeClass Freeze;

        // Конструктор
        public ClubCardA(Pay payStatus, TimeForTr time, TypeWorkout typeTr, SpaService spa, PeriodClubCard periodInMonths)
           : base(payStatus, time, typeTr, spa)
        {
            _numberMonths = (int)periodInMonths;
            _numAerobicTr = _numberMonths * 10;
            NumPersonalTr = 0;
            _periodAbonem = periodInMonths;

            EndDateChanged += CalculateDaysLeft;
            EndDate = DateTime.Now.AddMonths(_numberMonths).Date;
        }

        private void CalculateDaysLeft(object sender, EventArgs e)
        {
            int numFreezDays = 0;
            if (Freeze != null) numFreezDays = Freeze.GetSpentDays(); //Вычитаем дни заморозки
            DaysLeft = (EndDate.Date - DateTime.Now.Date).Days - numFreezDays;
        }

        // Методы
        public override bool IsValid()
        {
            // Если +, то DateTime.Now позднее _endDate
            // Если 0, то даты совпали
            // Если -, то DateTime.Now раньше Конца абонемента
            var checkDate = (DateTime.Now.Date.CompareTo(EndDate.Date) <= 0);
            return checkDate;
        }

        public override void TryActivate()
        {
            if (isActivated) return; // Уже Активирован.
            isActivated = true;
            SetNewEndDate();
        }

        public override bool CheckInWorkout(TypeWorkout type)
        {
            var result = false;

            if (!IsValid()) return false;
            switch (type)
            {
                case TypeWorkout.Аэробный_Зал:
                    {
                        if (NumAerobicTr > 0)
                        {
                            --NumAerobicTr;
                            result = true;
                        }
                        break;
                    }
                case TypeWorkout.Персональная:
                    {
                        if (NumPersonalTr > 0)
                        {
                            --NumPersonalTr;
                            result = true;
                        }
                        break;
                    }
                case TypeWorkout.Тренажерный_Зал:
                    {
                        result = true;
                        break;
                    }
            }
            return result;
        }

        /// <summary>
        /// Добавить Блок Персональных или Аэробных тренировок к Клубной Карте
        /// </summary>
        public override bool AddTrainingsToAbon(TypeWorkout type, int numberToAdd)
        {
            bool result;

            switch (type)
            {
                case TypeWorkout.Аэробный_Зал:
                    {
                        NumAerobicTr += numberToAdd;
                        result = true;
                        break;
                    }
                case TypeWorkout.Персональная:
                    {
                        NumPersonalTr += numberToAdd;
                        result = true;
                        break;
                    }
                case TypeWorkout.Тренажерный_Зал:
                    {
                        result = false;
                        break;
                    }
                default:
                    {
                        result = false;
                        break;
                    }
            }
            return result;
        }

        public override List<Tuple<string, string>> GetShortInfoList()
        {
            // Информация о текущем состоянии Абонемента. Добавляем всё что должно выводиться для Пользователя
            var result = new List<Tuple<string, string>>
              {
              new Tuple<string, string>("Тип: ", AbonementName),
              new Tuple<string, string>("Доступные Тренировки ", trainingsType.ToString()),
              new Tuple<string, string>("Время Тренировок ", timeTraining.ToString()),
              new Tuple<string, string>("Услуги", spa.ToString()),
              new Tuple<string, string>("Срок Клубной Карты", _numberMonths +"  мес."),
              new Tuple<string, string>("Дата Окончания Карты", EndDate.Date.ToString("d")),
              new Tuple<string, string>("Осталось Дней", GetRemainderDays().ToString())
              };
            if (NumPersonalTr > 0) { result.Add(new Tuple<string, string>("Осталось Персональных", NumPersonalTr.ToString())); }
            if (NumAerobicTr > 0) { result.Add(new Tuple<string, string>("Осталось Аэробных", NumAerobicTr.ToString())); }
            if (payStatus == Pay.Не_Оплачено) { result.Add(new Tuple<string, string>("Статус Оплаты ", payStatus.ToString())); }

            if (Freeze != null)
            {
                result.Add(new Tuple<string, string>("Осталось дней Заморозки", Freeze.GetAvailableDays().ToString()));
            }

            return result;
        }

        public override int GetRemainderDays()
        {
            return DaysLeft;
        }

        private void SetNewEndDate()
        {
            var date = DateTime.Now.AddMonths(_numberMonths).Date;
            if (EndDate.Date.CompareTo(date) != 0)
                EndDate = DateTime.Now.AddMonths(_numberMonths).Date;
        }

        public PeriodClubCard GetTypeClubCard()
        {
            return PeriodAbonem;
        }

        public void SetTypeClubCard(PeriodClubCard newTypeCc)
        {
            PeriodAbonem = newTypeCc;
        }
    }
}
