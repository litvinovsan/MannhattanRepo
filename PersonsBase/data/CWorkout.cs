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
        #region /// ПУБЛИЧНЫЕ ///

        // public MyTime StartTime { get; set; }
        // public string WorkoutName { get; set; }
        public ScheduleNote scheduleNote;
        public Trener Trener { get; set; }
        public string Notes { get; set; }
        #endregion

        #region /// КОНСТРУКТОР ///
        public Group(string workoutName, MyTime startTime)
        {
            scheduleNote = new ScheduleNote(startTime, workoutName);
        }
        public Group()
        {
            scheduleNote = new ScheduleNote(new MyTime(0, 0), "");
        }
        #endregion
    }

    /// <summary>
    ///  Класс для передачи выбранных параметров Тренировки во время Отмечания тренировки. 
    /// </summary>
    [Serializable]
    public class WorkoutOptions
    {
        public TypeWorkout TypeWorkout { get; set; }
        public Trener PersonalTrener { get; set; }
        public Group GroupInfo { get; set; }

        public WorkoutOptions()
        {
            TypeWorkout = new TypeWorkout();
            PersonalTrener = new Trener();
            GroupInfo = new Group();
        }
    }
}
