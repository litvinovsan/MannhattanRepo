using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PersonsBase.myStd;

namespace PersonsBase.data
{
    public delegate void MyListViewDelegate(string namePerson, WorkoutOptions workoutOptions);

    [Serializable]
    public class DailyVisits
    {
        #region /// CОБЫТИЯ ///

        // События по Счетчику клиентов за день
        [field: NonSerialized]
        public static event EventHandler<int> NumberDailyPersonsEvent;
        private void OnNumberChanged(int number)   // Запускатор события
        {
            NumberDailyPersonsEvent?.Invoke(this, number);
        }

        [field: NonSerialized]
        public static event Action GymListChangedEvent;
        public void OnGymListChanged()
        {
            GymListChangedEvent?.Invoke();
        }

        #endregion ///

        #region /// ПОЛЯ ///

        private int _totalPersonToday;
        private readonly Dictionary<TypeWorkout, MyListViewDelegate> _visitorsListSelect; // Каждому типу назначен свой метод
        public int TotalPersonToday
        {
            get { return _totalPersonToday; }
            set
            {
                _totalPersonToday = value;
                OnNumberChanged(value);
            }
        }

        [Serializable] // FIXME Перенести в Тайпс
        public struct GymItem
        {
            public string Time;
            public string Name;

            public GymItem(string t, string n)
            {
                Time = t;
                Name = n;
            }
        }
        public List<GymItem> ListViewGymList = new List<GymItem>();

        #endregion

        /// Конструктор
        public DailyVisits()
        {
            _visitorsListSelect = new Dictionary<TypeWorkout, MyListViewDelegate>
            {
                //   {TypeWorkout.Аэробный_Зал, AddToGroupList},
                // {TypeWorkout.Персональная, AddToPersonalnList},
                {TypeWorkout.Тренажерный_Зал, AddToGymList}
            };
        }

        // Запускаем метод по добавлению в 1 из 3х столбцов.Метод в коллекции.
        public void AddToDailyLog(string name, WorkoutOptions arg)
        {
            TotalPersonToday++; // Счетчик посетителей за день
            _visitorsListSelect[arg.TypeWorkout].Invoke(name, arg);
        }
        /// <summary>
        /// Добавляет персону в список Тренажерного зала
        /// </summary>
        private void AddToGymList(string namePerson, WorkoutOptions arg)
        {
            var item = CreateGymItem(namePerson);
            ListViewGymList.Add(item);
            OnGymListChanged();
        }

        private GymItem CreateGymItem(string personName)
        {
            var personNameTemp = string.IsNullOrEmpty(personName) ? "Имя неизвестно" : personName;
            var time =  DateTime.Now.ToString("HH:mm");
            return new GymItem(time, personNameTemp);
        }



        // Добавляет в список Групповых тренировок
        private static void AddToGroupList(string namePerson, WorkoutOptions arg)
        {
            if (arg.GroupInfo.ScheduleNote == null) return;
            var groupName = arg.GroupInfo.ScheduleNote.GetTimeAndNameStr();
            //          MyListViewEx.AddNameTime(listView_Group, groupName, namePerson, false);
        }

        private static void AddToPersonalnList(string namePerson, WorkoutOptions arg)
        {
            string persTrenerName = (arg.PersonalTrener != null) ? arg.PersonalTrener.Name : "Имя неизвестно";
            //        MyListViewEx.AddNameTime(listView_Personal, persTrenerName, namePerson, true);
        }
    }
}
