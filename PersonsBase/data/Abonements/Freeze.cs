using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PBase;

namespace PersonsBase.data.Abonements
{
    [Serializable]
    public class FreezePeriod
    {
        private readonly DateTime _startDate;

        /// <summary>
        /// Дата начала заморозки
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate.Date; }
        }

        /// <summary>
        /// Заморозить на Н дней
        /// </summary>
        public int DaysToFreeze { get; }


        // Конструктор
        public FreezePeriod(DateTime startDate, int daysToFreeze)
        {
            _startDate = startDate.Date;
            DaysToFreeze = daysToFreeze;
        }
        public FreezePeriod()
        {
            _startDate = DateTime.Now;
            DaysToFreeze = 0;
        }
        // Методы

        /// <summary>
        /// Получить дату окончания заморозки
        /// </summary>
        /// <returns></returns>
        public DateTime GetEndDate()
        {
            return StartDate.AddDays(DaysToFreeze).Date;
        }

        public bool IsFreezedNow()
        {
            var endDate = GetEndDate();
            var result = (DaysToFreeze > 0) && (DateTime.Now.CompareTo(_startDate) >= 0) && (DateTime.Now.CompareTo(endDate) <= 0);

            return result;
        }

        /// <summary>
        /// Текущая заморозка будет в будущем. Сравнение по дате с текущим днем
        /// </summary>
        /// <returns></returns>
        public bool IsFreezeInFuture()
        {
            return (DateTime.Now.Date.CompareTo(StartDate.Date) <= 0);// Дата заморозки в будущем
        }
    }

    [Serializable]
    public class FreezeClass
    {
        #region/// ПРИВАТНЫЕ ПОЛЯ ////////////

        private const int MaxDaysFor3Month = 30;
        private const int MaxDaysFor6Month = 30;
        private const int MaxDaysMonth12 = 45;
        private int _totalDaysFreezed;         // Счетчик использованных дней заморозки

        #endregion

        #region/// ПУБЛИЧНЫЕ ПОЛЯ ////////////

        /// <summary>
        /// Список всех заморозок
        /// </summary>
        public List<FreezePeriod> AllFreezes;

        /// <summary>
        /// Максимальное количество дней заморозки для текущего периода клубной карты
        /// </summary>
        public readonly int MaxDaysAvailable;

        #endregion

        #region/// КОНСТРУКТОРЫ.  ////////////
        public FreezeClass(PeriodClubCard period)
        {
            AllFreezes = new List<FreezePeriod>();

            MaxDaysAvailable = GetMaxDaysForPeriod(period);

            _totalDaysFreezed = 0;
        }
        public FreezeClass()
        {
            AllFreezes = new List<FreezePeriod>();
            MaxDaysAvailable = 0;
            _totalDaysFreezed = 0;
        }

        #endregion

        #region/// МЕТОДЫ  ///////////////////

        /// <summary>
        ///  Осталось дней для заморозки в абонементе
        /// </summary>
        /// <returns></returns>
        public int GetAvailableDays()
        {
            return MaxDaysAvailable - _totalDaysFreezed;
        }

        /// <summary>
        /// Сколько использовано дней заморозки уже
        /// </summary>
        /// <returns></returns>
        public int GetSpentDays() // 
        {
            return _totalDaysFreezed;
        }

        /// <summary>
        /// Возвращает true если Клиент в Заморозке на сегодняшнюю дату
        /// </summary>
        public bool IsFreezedNow()
        {
            try
            {
                var periodFreeze = AllFreezes.Find(x => x.IsFreezedNow()); // Ищем любой замороженный сейчас
                return periodFreeze != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Удаляет последнюю заморозку из списка
        /// </summary>
        public void RemoveLast()
        {
            var lastElement = AllFreezes.LastOrDefault();

            if (lastElement == null) return;
            _totalDaysFreezed -= lastElement.DaysToFreeze;
            if (_totalDaysFreezed < 0) _totalDaysFreezed = 0;
            AllFreezes.Remove(lastElement);

            MessageBox.Show(@"Удалена последняя запись о заморозке!");
        }

        /// <summary>
        /// Заморозка настроена и ожидается в будущем
        /// </summary>
        public bool IsConfiguredForFuture()
        {
            try
            {
                var periodFreeze = GetFutureFreeze();
                return periodFreeze != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Запланировано дней в ближайшей будущей заморозке
        /// </summary>
        /// <returns></returns>
        public int GetDaysToFreeze() // Сколько Дней запланировано
        {
            return GetFutureFreeze().DaysToFreeze;
        }

        /// <summary>
        /// Попытка установить заморозку. Проверяются остаточные дни и дата
        /// </summary>
        /// <param name="numDays"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public bool TrySetFreeze(int numDays, DateTime startDate)
        {
            if (!IsPossibleToFreeze(numDays, startDate)) return false;

            AllFreezes.Add(new FreezePeriod(startDate, numDays));
            _totalDaysFreezed += numDays;
            return true;
        }

        public FreezePeriod GetFutureFreeze()
        {
            var periodFreeze = AllFreezes.Find(x => (x.IsFreezedNow() == false && x.IsFreezeInFuture()));
            return periodFreeze;
        }

        /// <summary>
        /// Возвращает максимально доступное количество дней для периода абонемента
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        private int GetMaxDaysForPeriod(PeriodClubCard period)
        {
            int result;
            switch (period)
            {
                case PeriodClubCard.На_1_Месяц:
                    {
                        result = 0;
                        break;
                    }
                case PeriodClubCard.На_3_Месяца:
                    {
                        result = MaxDaysFor3Month;
                        break;
                    }
                case PeriodClubCard.На_6_Месяцев:
                    {
                        result = MaxDaysFor6Month;
                        break;
                    }
                case PeriodClubCard.На_12_Месяцев:
                    {
                        result = MaxDaysMonth12;
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(period), period, null);
            }

            return result;
        }

        private bool IsPossibleToFreeze(int numDaysToFreeze, DateTime dateStart)
        {
            if (numDaysToFreeze == 0) return false;
            var dateCmpr = (DateTime.Now.Date.CompareTo(dateStart.Date) <= 0);// Дата заморозки в будущем
            return IsPossibleToFreeze(numDaysToFreeze) && dateCmpr;
        }
        private bool IsPossibleToFreeze(int numDaysToFreeze)
        {
            if (numDaysToFreeze == 0) return false;
            var temp = numDaysToFreeze + _totalDaysFreezed;
            return (temp <= MaxDaysAvailable) && (_totalDaysFreezed <= MaxDaysAvailable);
        }

        #endregion
    }
}
// Если +, то DateTime.Now.CompareTo позднее _endDate
// Если 0, то даты совпали
// Если -, то DateTime.Now раньше Конца абонемента
