using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using PersonsBase.data.Abonements;
using PersonsBase.myStd;

namespace PersonsBase.data
{
    [Serializable]
    public class DataBaseLevel
    {
        #region/// ОБЬЕКТЫ Базы Данных. Списки и Коллекции///

        [NonSerialized]
        private static readonly object Locker = new object(); // блокировка коллекции на время сериализации.
        [NonSerialized]
        private static DataBaseLevel _dbInstance;  //Singleton.

        // База Клиентов
        private static SortedList<string, Person> _dataBaseList;
        // База с Журналом посещений
        private static Dictionary<string, List<Visit>> _visitsDictionary;
        // База с История абонементов клиента
        private static Dictionary<string, List<AbonHistory>> _abonHistoryDictionary;
        // База Администраторов 
        private static List<Administrator> _adminsList;
        // База Тренеров
        private static List<Trener> _trenersList;
        // Текущий Администратор на Ресепшн
        private static Administrator _adminCurrent;
        // Список ежедневных Групповых Тренировок
        private static List<ScheduleNote> _groupScheduleList;
        // Данные вспомогательные. Списки тренеров, Админов и т д
        private static ManhattanInfo _manhattanInfo;

        #endregion

        #region/// Синглтон ////
        public static DataBaseLevel GetInstance()
        {
            return _dbInstance ?? (_dbInstance = new DataBaseLevel());
        }
        #endregion

        #region/// КОНСТРУКТОР и ДЕСТРУКТОР /////

        private DataBaseLevel()
        {
            MyFile.CreateFolder(Options.FolderNameDataBase);
            MyFile.CreateFolder(Options.FolderNameUserPhoto);

            DeSerializeObjects(); // Там же сразу создаются обьекты базы

            // Cтруктура для удобства доступа
            _manhattanInfo = new ManhattanInfo
            {
                Admins = _adminsList,
                Treners = _trenersList,
                Schedule = _groupScheduleList,
                CurrentAdmin = _adminCurrent
            };
        }

        ~DataBaseLevel()
        {
            SerializeObjects();
        }
        #endregion

        #region/// CОБЫТИЯ ////
        // Список Клиентов
        public delegate void MyEventDelegate(EventArgs e);
        /// <summary>
        /// Событие возникает когда изменяется количество клиентов в базе.
        /// </summary>
        public static event MyEventDelegate PersonsListChangedEvent;
        public static void OnListChanged()
        {
            PersonsListChangedEvent?.Invoke(EventArgs.Empty);
        }
        #endregion

        #region /// МЕТОДЫ ////

        // Доступ к Коллекциям и Спискам Клиентов, Тренеров, Администраторов, Тренировок
        public static SortedList<string, Person> GetPersonsList()
        {
            lock (Locker)
            {
                return _dataBaseList;
            }
        }

        /// Возвращает Коллекцию с журналами посещений всех пользователей
        public static Dictionary<string, List<Visit>> GetPersonsVisitDict()
        {
            return _visitsDictionary;
        }
        /// Возвращает Коллекцию c историей абонементов клиента
        public static Dictionary<string, List<AbonHistory>> GetPersonsAbonHistDict()
        {
            return _abonHistoryDictionary;
        }

        public static ManhattanInfo GetManhattanInfo()
        {
            return _manhattanInfo;
        }

        /// Возвращает ответ Базы Данных об успешности Добавления новой персоны.Success если успех. Код Поля- ошибки или Fail в непонятных случаях.
        public static ResponseCode PersonAdd(Person person)
        {
            ResponseCode response;

            lock (Locker)
            {
                var containsCopy = DataBaseM.IsContainsCopyOfValues(_dataBaseList, person, out response);
                if (containsCopy == false && (!string.IsNullOrEmpty(person.Name)))
                {
                    try
                    {
                        _dataBaseList.Add(person.Name, person);
                        response = ResponseCode.Success;
                        OnListChanged();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

            return response;
        }
        public static ResponseCode PersonRemove(string nameKey)
        {
            var result = ResponseCode.Fail;

            lock (Locker)
            {
                if (!_dataBaseList.ContainsKey(nameKey)) return result;

                try
                {
                    if (_dataBaseList.Remove(nameKey))
                    {
                        result = ResponseCode.Success;
                        OnListChanged();
                    }
                }
                catch
                {
                    result = ResponseCode.Fail;
                }
            }
            return result;
        }

        public static bool PersonEditName(string curentName, string newName)
        {
            lock (Locker)
            {
                var result = _dataBaseList != null && DataBaseM.EditName(_dataBaseList, curentName, newName);
                if (result) OnListChanged();
                return result;
            }
        }
        /// Returns numberof elements in collection
        public static int GetNumberOfPersons()
        {
            lock (Locker)
            {
                return _dataBaseList.Count;
            }
        }
        public static bool ContainsNameKey(string personName)
        {
            lock (Locker)
            {
                return _dataBaseList.ContainsKey(personName);
            }
        }

        /// <summary>
        /// Сериализация всех обьектов Базы данных. Клиенты, Администраторы, Тренеры, Расписание груповых тренировок
        /// </summary>
        public static void SerializeObjects()
        {
            MyFile.CreateFolder(Options.FolderNameDataBase);
            var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.FolderNameDataBase;

            lock (Locker)
            {
                SerializeClass.Serialize(_dataBaseList, currentPath + "\\" + Options.PersonsDbFile);
            }
            // Журнал посещений
            SerializeClass.Serialize(_visitsDictionary, currentPath + "\\" + Options.PersonVisitsDbFile);

            // История Абонементов
            SerializeClass.Serialize(_abonHistoryDictionary, currentPath + "\\" + Options.PersonAbonHistDbFile);


            // База Тренеров
            SerializeClass.Serialize(_trenersList, currentPath + "\\" + Options.TrenersDbFile);
            // База Администраторов 
            SerializeClass.Serialize(_adminsList, currentPath + "\\" + Options.AdminsDbFile);
            // Текущий Администратор на Ресепшн
            SerializeClass.Serialize(_manhattanInfo.CurrentAdmin, currentPath + "\\" + Options.AdminCurrFile);
            // Список названий всех ежедневных Групповых Тренировок
            SerializeClass.Serialize(_groupScheduleList, currentPath + "\\" + Options.GroupSchFile);
            // Сериализация списков посещений. Списки отображаются на главной форме(4 колонки)
            DailyVisits.GetInstance().SerializeDailyVisits();
        }

        /// <summary>
        /// ДеСериализация всех обьектов Базы данных. Клиенты, Администраторы, Тренеры, Расписание груповых тренировок
        /// </summary>
        private static void DeSerializeObjects()
        {
            var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.FolderNameDataBase + "\\";

            // База Клиентов
            _dataBaseList = new SortedList<string, Person>(StringComparer.OrdinalIgnoreCase);
            lock (Locker)
            {
                SerializeClass.DeSerialize(ref _dataBaseList, currentPath + Options.PersonsDbFile);
            }

            // Журнал посещений клиентов
            _visitsDictionary = new Dictionary<string, List<Visit>>();
            SerializeClass.DeSerialize(ref _visitsDictionary, currentPath + Options.PersonVisitsDbFile);

            // История Абонементов клиента
            _abonHistoryDictionary = new Dictionary<string, List<AbonHistory>>();
            SerializeClass.DeSerialize(ref _abonHistoryDictionary, currentPath + Options.PersonAbonHistDbFile);

            // База Тренеров
            _trenersList = new List<Trener>();
            SerializeClass.DeSerialize(ref _trenersList, currentPath + Options.TrenersDbFile);

            // База Администраторов 
            _adminsList = new List<Administrator>();
            SerializeClass.DeSerialize(ref _adminsList, currentPath + Options.AdminsDbFile);

            // Текущий Администратор на Ресепшн
            _adminCurrent = new Administrator();
            SerializeClass.DeSerialize(ref _adminCurrent, currentPath + Options.AdminCurrFile);

            // Список ежедневных Групповых Тренировок
            _groupScheduleList = new List<ScheduleNote>();
            SerializeClass.DeSerialize(ref _groupScheduleList, currentPath + Options.GroupSchFile);
         
            // Списки посещений по группам. Отображаются на главной форме.
            DailyVisits.GetInstance().DeSerializeDailyVisits();
        }

        #endregion
    }
    [Serializable]
    public class ManhattanInfo
    {
        public List<Trener> Treners;
        public List<ScheduleNote> Schedule;
        public List<Administrator> Admins;
        public Administrator CurrentAdmin;
    }
}
