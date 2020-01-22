using System;
using System.Collections.Generic;
using System.IO;
using PersonsBase.myStd;
using PersonsBase.Properties;

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
        private static void OnGymListChanged()
        {
            GymListChangedEvent?.Invoke();
        }

        [field: NonSerialized]
        public static event Action PersonalListChangedEvent;
        private static void OnPersonalListChanged()
        {
            PersonalListChangedEvent?.Invoke();
        }

        [field: NonSerialized]
        public static event Action AerobListChangedEvent;
        private static void OnAerobListChanged()
        {
            AerobListChangedEvent?.Invoke();
        }

        #endregion ///

        #region /// КОНСТРУКТОР ///

        private DailyVisits()
        {
            _methodSelectCollection = new Dictionary<TypeWorkout, MyListViewDelegate>
            {
                {TypeWorkout.Аэробный_Зал, AddToGroupList},
                {TypeWorkout.Персональная, AddToPersonalnList},
                {TypeWorkout.Тренажерный_Зал, AddToGymList}
            };
        }
        private static DailyVisits _dailyVisits;
        public static DailyVisits GetInstance()
        {
            return _dailyVisits ?? (_dailyVisits = new DailyVisits());
        }

        #endregion

        #region /// ПОЛЯ ///

        private int _totalPersonToday;
        private int TotalPersonToday
        {
            get { return _totalPersonToday; }
            set
            {
                _totalPersonToday = value;
                OnNumberChanged(value);
            }
        }
        private readonly Dictionary<TypeWorkout, MyListViewDelegate> _methodSelectCollection; // Каждому типу назначен свой метод

        // Списки с посещениями по разным типам. Тренажерка, Аэробный и Персоналки
        public readonly List<GymItem> GymList = new List<GymItem>();
        public readonly List<PersonalItem> PersonalList = new List<PersonalItem>();
        public readonly List<AerobItem> AerobList = new List<AerobItem>();

        #endregion


        // Главный метод. Запускает  1 из 3х методов.
        public void AddToDailyLog(string name, WorkoutOptions arg)
        {
            TotalPersonToday++; // Счетчик посетителей за день
            _methodSelectCollection[arg.TypeWorkout].Invoke(name, arg);
        }

        #region /// ВИЗИТЫ ТРЕНАЖЕРНОГО ЗАЛА ///
        /// <summary>
        /// Добавляет персону в список Тренажерного зала
        /// </summary>
        private void AddToGymList(string namePerson, WorkoutOptions arg)
        {
            var item = CreateGymItem(namePerson);
            GymList.Add(item);
            OnGymListChanged();
        }

        private static GymItem CreateGymItem(string personName)
        {
            var personNameTemp = string.IsNullOrEmpty(personName) ? "Имя неизвестно" : personName;
            var time = DateTime.Now.ToString("HH:mm");
            return new GymItem(time, personNameTemp);
        }
        #endregion

        #region /// ВИЗИТЫ АЭРОБНЫХ ТРЕНИРОВОК ///
        private void AddToGroupList(string namePerson, WorkoutOptions arg)
        {
            if (arg.GroupInfo.ScheduleNote == null) return;

            var groupTimeName = arg.GroupInfo.ScheduleNote.GetTimeAndNameStr();
            var item = CreateAerobItem(namePerson, groupTimeName);
            AerobList.Add(item);
            OnAerobListChanged();
        }
        private static AerobItem CreateAerobItem(string personName, string groupTimeName)
        {
            var personNameTemp = string.IsNullOrEmpty(personName) ? "Имя неизвестно" : personName;
            return new AerobItem(groupTimeName, personNameTemp);
        }
        #endregion

        #region /// ВИЗИТЫ ПЕРСОНАЛЬНЫХ ТРЕНИРОВК ///
        private void AddToPersonalnList(string namePerson, WorkoutOptions arg)
        {
            if (namePerson == null || arg == null) return;

            var persTrenerName = (arg.PersonalTrener != null) ? arg.PersonalTrener.Name : "Имя неизвестно";
            var item = CreatePersonalItem(namePerson, persTrenerName);
            PersonalList.Add(item);
            OnPersonalListChanged();
        }
        private static PersonalItem CreatePersonalItem(string personName, string trenerName)
        {
            return new PersonalItem(personName, trenerName);
        }
        #endregion

        #region /// CОХРАНЕНИЕ и ЗАГРУЗКА Посещений ///

        public void SaveCurentSession()
        {
            var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.FolderNameDataBase;

            SerializeClass.Serialize(GymList, currentPath + "\\" + Options.DailyVisitGymFile);
            SerializeClass.Serialize(PersonalList, currentPath + "\\" + Options.DailyVisitPersonalsFile);
            SerializeClass.Serialize(AerobList, currentPath + "\\" + Options.DailyVisitAerobFile);

        }
        /// <summary>
        /// Загрузка Посетивших клиентов в прошлую сессию если не было смены даты.
        /// Программа считает что закрытие было не корректным если день не сменился
        /// </summary>
        public void LoadLastSession()
        {
            if (IsDateChanged()) return;
            var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.FolderNameDataBase;

            // Тренажерка
            var dailyGymVisits = new List<GymItem>();
            SerializeClass.DeSerialize(ref dailyGymVisits, currentPath + "\\" + Options.DailyVisitGymFile);
            foreach (var item in dailyGymVisits)
            {
                GymList.Add(item);
                OnGymListChanged();
            }

            // Аэробный залл
            var dailyAerobVisits = new List<AerobItem>();
            SerializeClass.DeSerialize(ref dailyAerobVisits, currentPath + "\\" + Options.DailyVisitAerobFile);
            foreach (var item in dailyAerobVisits)
            {
                AerobList.Add(item);
                OnAerobListChanged();
            }
            // Персональные тренировки
            var dailyPersonalVisits = new List<PersonalItem>();
            SerializeClass.DeSerialize(ref dailyPersonalVisits, currentPath + "\\" + Options.DailyVisitPersonalsFile);
            foreach (var item in dailyPersonalVisits)
            {
                PersonalList.Add(item);
                OnPersonalListChanged();
            }

            // Посещений в день
            TotalPersonToday = dailyGymVisits.Count + dailyAerobVisits.Count + dailyPersonalVisits.Count;
        }

        /// <summary>
        ///  Возвращает True если дата сохраненная в настройках при прошлом выходе совпадает с текущей датой.
        /// Значит программа запущена в тот же день и надо восстанавливать настройки
        /// </summary>
        private static bool IsDateChanged()
        {
            var dateNow = DateTime.Now.Date.ToString("MM/dd/yyyy");
            var oldDate = Settings.Default.curentDate;

            return !dateNow.Equals(oldDate);
        }
        #endregion

    }
}
