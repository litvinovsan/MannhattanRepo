using System;

namespace PersonsBase.data
{
    [Serializable]
    public class Group
    {
        #region /// ПУБЛИЧНЫЕ ///

        public readonly ScheduleNote ScheduleNote;
        public string TrenerName { get; set; }
        public string Notes { get; set; }
        #endregion

        #region /// КОНСТРУКТОР ///
        public Group(string workoutName, MyTime startTime)
        {
            ScheduleNote = new ScheduleNote(startTime, workoutName);
        }
        public Group()
        {
            ScheduleNote = new ScheduleNote(new MyTime(0, 0), "");
            TrenerName = "Имя неизвестно";
            Notes = "";
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
