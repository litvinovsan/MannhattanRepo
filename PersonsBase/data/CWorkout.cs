using PBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsBase.data
{
    [Serializable]
    public class Group
    {
        public string WorkoutName { get; set; }
        public Trener Trener { get; set; }
        public MyTime StartTime { get; set; }
        public string Notes { get; set; }
        public string TimeAndNameString
        {
            get { return timeAndName; }
            set
            {
                timeAndName = value;
            }
        }
        private string timeAndName;

        // Конструкторы
        public Group(string nameTraining, MyTime startTime)
        {
            WorkoutName = nameTraining;
            StartTime = startTime;
        }
        public Group()
        {
            WorkoutName = "";
            StartTime = new MyTime(0, 0);
        }

        // Методы
        public string GetTimeAndNameStr()
        {
            TimeAndNameString = $"{StartTime.SelectedTime} - {WorkoutName}";
            return TimeAndNameString;
        }

        public void SetTimeAndNameString(string timeAndName)
        {
            if (string.IsNullOrEmpty(timeAndName)) return;
            // Заново парсим строку, на всякий случай чтобы привести время к формату
            var Args = timeAndName.Split('-');
            var timeArg = Args[0].Trim();
            var nameArg = Args[1].Trim();
            var time = timeArg.Split(':');

            StartTime = new MyTime(int.Parse(time[0].Trim()), int.Parse(time[1].Trim()));
            WorkoutName = nameArg.Trim();

            TimeAndNameString = $"{StartTime.SelectedTime} - {WorkoutName}";
        }
    }

    /// <summary>
    ///  Класс для передачи выбранных параметров Тренировки во время Отмечания тренировки. 
    /// </summary>
    [Serializable]
    public class WorkoutOptions
    {
        public TypeWorkout TypeWorkout { get; set; }
        public Trener PersonalTrener { get; set; }
        public Group GroupTraining { get; set; }

        public WorkoutOptions()
        {
            TypeWorkout = new TypeWorkout();
            PersonalTrener = new Trener();
            GroupTraining = new Group();
        }
    }
}
