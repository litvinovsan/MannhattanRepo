using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PersonsBase.myStd;

namespace PersonsBase.data
{
    public delegate void MyListViewDelegate(string namePerson, WorkoutOptions workoutOptions);
    public delegate void MyListViewDelegateRemove(string namePerson, TypeWorkout typeWorkout);

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
        public event EventHandler<DateTime> GymListChangedEvent;
        private void OnGymListChanged(DateTime dateToShow)
        {
            GymListChangedEvent?.Invoke(this, dateToShow);
        }

        [field: NonSerialized]
        public event EventHandler<DateTime> PersonalListChangedEvent;
        private void OnPersonalListChanged(DateTime dateToShow)
        {
            PersonalListChangedEvent?.Invoke(this, dateToShow);
        }

        [field: NonSerialized]
        public event EventHandler<DateTime> MiniGroupListChangedEvent;
        private void OnMiniGroupListChanged(DateTime dateToShow)
        {
            MiniGroupListChangedEvent?.Invoke(this, dateToShow);
        }

        [field: NonSerialized]
        public event EventHandler<DateTime> AerobListChangedEvent;
        private void OnAerobListChanged(DateTime dateToShow)
        {
            AerobListChangedEvent?.Invoke(this,dateToShow);
        }

        #endregion ///

        #region /// КОНСТРУКТОР ///

        private DailyVisits()
        {
            _methodsCollection = new Dictionary<TypeWorkout, MyListViewDelegate>
            {
                {TypeWorkout.Аэробный_Зал, AddToGroupList},
                {TypeWorkout.Персональная, AddToPersonalnList},
                {TypeWorkout.Тренажерный_Зал, AddToGymList},
                {TypeWorkout.МиниГруппа, AddToMiniGroupList}
            };

            _methodsDelCollection = new Dictionary<TypeWorkout, MyListViewDelegateRemove>
            {
                {TypeWorkout.Аэробный_Зал, RemoveGrouplList },
                {TypeWorkout.Персональная, RemovePersonalList},
                {TypeWorkout.Тренажерный_Зал, RemoveGymList},
                {TypeWorkout.МиниГруппа, RemoveMiniGroupList}
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
        private readonly Dictionary<TypeWorkout, MyListViewDelegate> _methodsCollection; // Каждому типу назначен свой метод
        private readonly Dictionary<TypeWorkout, MyListViewDelegateRemove> _methodsDelCollection; // Каждому типу назначен свой метод

        // Списки с посещениями по разным типам. Тренажерка, Аэробный и Персоналки
        public List<GymItem> GymList = new List<GymItem>();
        public List<StandartItem> PersonalList = new List<StandartItem>();
        public List<StandartItem> MiniGroupList = new List<StandartItem>();
        public List<AerobItem> AerobList = new List<AerobItem>();

        #endregion


        // Главный метод. Запускает  1 из 3х методов.
        public void AddToLog(string name, WorkoutOptions arg)
        {
            TotalPersonToday++; // Счетчик посетителей за день
            _methodsCollection[arg.TypeWorkout].Invoke(name, arg);
        }

        public void RemoveFromLog(string name, TypeWorkout arg)
        {
            TotalPersonToday--; // Счетчик посетителей за день
            _methodsDelCollection[arg].Invoke(name, arg);
        }

        #region /// ВИЗИТЫ ТРЕНАЖЕРНОГО ЗАЛА ///
        /// <summary>
        /// Добавляет персону в список Тренажерного зала
        /// </summary>
        private void AddToGymList(string namePerson, WorkoutOptions arg)
        {
            var item = CreateGymItem(namePerson);
            GymList.Add(item);
            OnGymListChanged(DateTime.Now);
        }

        private void RemoveGymList(string namePerson, TypeWorkout arg)
        {
            var gymItem = GymList?.FindLastIndex((x => x.Name.Equals(namePerson)));
            if (gymItem == null) return;
            GymList.RemoveAt((int)gymItem);
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
            OnAerobListChanged(DateTime.Now);
        }

        private void RemoveGrouplList(string namePerson, TypeWorkout arg)
        {
            var item = AerobList?.FindIndex((x => x.NamePerson.Equals(namePerson)));
            if (item == null) return;
            AerobList.RemoveAt((int)item);
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
            var item = CreateItem(namePerson, persTrenerName);
            PersonalList.Add(item);
            OnPersonalListChanged(DateTime.Now);
        }

        private void RemovePersonalList(string namePerson, TypeWorkout arg)
        {
            var item = PersonalList?.FindIndex((x => x.NamePerson.Equals(namePerson)));
            if (item == null) return;
            PersonalList.RemoveAt((int)item);
        }

        private static StandartItem CreateItem(string personName, string trenerName)
        {
            return new StandartItem(personName, trenerName);
        }
        #endregion

        #region /// ВИЗИТЫ МИНИ ГРУПП ///
        private void AddToMiniGroupList(string namePerson, WorkoutOptions arg)
        {
            if (namePerson == null || arg == null) return;

            var persTrenerName = (arg.PersonalTrener != null) ? arg.PersonalTrener.Name : "Имя неизвестно";

            var item = CreateItem(namePerson, persTrenerName);
            MiniGroupList.Add(item);
            OnMiniGroupListChanged(DateTime.Now);
        }

        private void RemoveMiniGroupList(string namePerson, TypeWorkout arg)
        {
            var item = MiniGroupList?.FindIndex((x => x.NamePerson.Equals(namePerson)));
            if (item == null) return;
            MiniGroupList.RemoveAt((int)item);
        }
        #endregion



        #region /// CОХРАНЕНИЕ и ЗАГРУЗКА Посещений ///

        /// <summary>
        /// Сериализует списки(Аэробн,ТренЗал,Персон,Мини) на диск. Списки со всеми посещениями за все дни
        /// </summary>
        public void Serialize()
        {
            var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.FolderNameDataBase;

            SerializeClass.Serialize(GymList, currentPath + "\\" + Options.DailyVisitGymFile);
            SerializeClass.Serialize(PersonalList, currentPath + "\\" + Options.DailyVisitPersonalsFile);
            SerializeClass.Serialize(AerobList, currentPath + "\\" + Options.DailyVisitAerobFile);
            SerializeClass.Serialize(MiniGroupList, currentPath + "\\" + Options.DailyMiniGroupFile);
        }

        /// <summary>
        /// ДеСериализует списки(Аэробн,ТренЗал,Персон,Мини) с диска. Списки со всеми посещениями за все дни
        /// </summary>
        public void DeSerialize()
        {
            var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.FolderNameDataBase;

            // Тренажерка
            SerializeClass.DeSerialize(ref GymList, currentPath + "\\" + Options.DailyVisitGymFile);
            // Аэробный залл
            SerializeClass.DeSerialize(ref AerobList, currentPath + "\\" + Options.DailyVisitAerobFile);
            // Персональные тренировки
            SerializeClass.DeSerialize(ref PersonalList, currentPath + "\\" + Options.DailyVisitPersonalsFile);
            // Мини Группы
            SerializeClass.DeSerialize(ref MiniGroupList, currentPath + "\\" + Options.DailyMiniGroupFile);
        }

        /// <summary>
        /// FIXME. Метод не доделан. Проверить отображение на главной форме. Как добавляются в списки там
        /// Загружает в MainForm в 4 списка посетивших людей на указанную дату
        /// </summary>
        public void ShowVisits(DateTime dateToLoad)
        {
            // Тренажерка
            var visitsGym = GymList.FindAll(x => x.VisitDateTime.Date.Equals(dateToLoad.Date));
            OnGymListChanged(dateToLoad);

            // Аэробный залл
            var visitsAerob = AerobList.FindAll(x => x.VisitDateTime.Date.Equals(dateToLoad.Date));
            OnAerobListChanged(dateToLoad);
            // Персональные тренировки
            var visitsPersonal = PersonalList.FindAll(x => x.VisitDateTime.Date.Equals(dateToLoad.Date));
            OnPersonalListChanged(dateToLoad);

            // Мини Группы
            var visitsMini = MiniGroupList.FindAll(x => x.VisitDateTime.Date.Equals(dateToLoad.Date));
            OnMiniGroupListChanged(dateToLoad);

            // Посещений в день
            TotalPersonToday = visitsGym.Count() + visitsAerob.Count() + visitsPersonal.Count() + visitsMini.Count();
        }

        #endregion

    }
}
