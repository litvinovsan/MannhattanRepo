using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBase
{
    [Serializable]
    public class ScheduleNote // Одна запись в планировщике
    {
        private MyTime _time;
        private string _nameWorkout;
        private string _timeAndName;

        #region /// ПУБЛИЧНЫЕ ///

        public MyTime Time
        {
            get { return _time; }
            set
            {
                _time = value;
            }
        }
        public string WorkoutsName
        {
            get { return _nameWorkout; }
            set
            {
                _nameWorkout = value;
            }
        }

        #endregion

        #region /// КОНСТРУКТОР ///

        public ScheduleNote(MyTime time, string nameWorkout)
        {
            _time = time;
            _nameWorkout = nameWorkout;
            _timeAndName = $"{_time.HourMinuteTime} - {_nameWorkout}";
        }

        #endregion

        #region /// MEТОДЫ ///
        /// <summary>
        /// Возвращает время и имя в записи расписания в формате "08:30 - ИмяТренировки"
        /// </summary>
        public string GetTimeAndNameStr()
        {
            return _timeAndName;
        }

        /// <summary>
        /// Задает новые время и имя в записи расписания в формате "08:30 - Имя"
        /// </summary>
        public void SetTimeAndNameString(string timeAndName)
        {
            if (string.IsNullOrEmpty(timeAndName)) return;
            // Заново парсим строку, на всякий случай чтобы привести время к формату
            var args = timeAndName.Split('-');
            var timeArg = args[0].Trim();
            var nameArg = args[1].Trim();
            var time = timeArg.Split(':');

            _time = new MyTime(int.Parse(time[0].Trim()), int.Parse(time[1].Trim()));
            _nameWorkout = nameArg.Trim();
            _timeAndName = $"{_time.HourMinuteTime} - {_nameWorkout}";
        }
        #endregion
    }

}
