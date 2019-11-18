using System;
using System.Collections.Generic;

namespace PBase
{

    [Serializable]
    public class SingleVisit : AbonementBasic
    {
        // Конструктор
        public SingleVisit(TypeWorkout typeTr, SpaService spa, Pay payStatus, TimeForTr time)
           : base(payStatus, time, typeTr, spa)
        {
            _numAerobicTr = 0;
            _numPersonalTr = 0;
            DaysLeft = 1;
            EndDate = DateTime.Now.Date;
        }

        // Свойства
        private int _numAerobicTr;
        private int _numPersonalTr;
        public sealed override int NumAerobicTr { get { return _numAerobicTr; } set { if (_numAerobicTr >= 0) _numAerobicTr = value; } }
        public sealed override int NumPersonalTr { get { return _numPersonalTr; } set { if (_numPersonalTr >= 0) _numPersonalTr = value; } }
        public override string AbonementName
        {
            get { return "Разовое Занятие"; }
        }

        public override string InfoMessageEnd
        {
            get { return "Нет активных разовых посещений!"; }
        }

        // Методы
        public override void TryActivate()
        {
            if (isActivated) return; // Уже Активирован.
            isActivated = true;
            EndDate = DateTime.Now.Date;
        }

        public override bool CheckInWorkout(TypeWorkout type)
        {
            if (DaysLeft <= 0) return false;
            DaysLeft--;
            return true;
        }

        public override bool IsValid()
        {
            return (DaysLeft > 0);
        }

        public override List<Tuple<string, string>> GetShortInfoList()
        {
            // Информация о текущем состоянии Абонемента. Добавляем всё что должно выводиться для Пользователя
            var result = new List<Tuple<string, string>>
          {
              new Tuple<string, string>("Тип: ", AbonementName),
              new Tuple<string, string>("Доступные Тренировки ", trainingsType.ToString()),
              new Tuple<string, string>("Услуги", spa.ToString())
          };

            if (NumPersonalTr > 0) { result.Add(new Tuple<string, string>("Осталось Персональных", NumPersonalTr.ToString())); }
            if (NumAerobicTr > 0) { result.Add(new Tuple<string, string>("Осталось Аэробных", NumAerobicTr.ToString())); }
            if (payStatus == Pay.Не_Оплачено) { result.Add(new Tuple<string, string>("Статус Оплаты ", payStatus.ToString())); }

            return result;
        }

        public override int GetRemainderDays()
        {
            return DaysLeft;
        }

        public override bool AddTrainingsToAbon(TypeWorkout type, int numberToAdd)
        {
            return false; //  Заглушка
        }
    }
}
