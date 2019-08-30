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
        public string TrainingsName { get; set; }
        public string Notes { get; set; }
        public Trener Trener { get; set; }
        public MyTime StartTime { get; set; }
        public string TimeName
        {
            get { return timeName; }
            set
            {
                timeName = value;
            }
        }

        private string timeName;

        public Group(string nameTraining, MyTime startTime)
        {
            TrainingsName = nameTraining;
            StartTime = startTime;
        }
        public Group()
        {
            TrainingsName = "Dummy";
            StartTime = new MyTime(8, 0);
        }
        public string GetTimeName()
        {
            TimeName = $"{StartTime.SelectedTime} - {TrainingsName}";
            return TimeName;
        }

        public void SetTimeName(string timeName)
        {
            if (string.IsNullOrEmpty(timeName)) return;
            // Заново парсим строку, на всякий случай чтобы привести время к формату
            var Args = timeName.Split('-');
            var timeArg = Args[0].Trim();
            var nameArg = Args[1].Trim();
            var time = timeArg.Split(':');

            StartTime = new MyTime(int.Parse(time[0].Trim()), int.Parse(time[1].Trim()));
            TrainingsName = nameArg.Trim();

            TimeName = $"{StartTime.SelectedTime} - {TrainingsName}";
        }
    }

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
