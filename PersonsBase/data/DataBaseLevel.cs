using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PBase
{
    [Serializable]
    public class DataBaseClass
    {
        #region/// ОБЬЕКТЫ Приватные //////////////////////////////

        [NonSerialized]
        private object locker = new object(); // блокировка коллекции на время сериализации.

        [NonSerialized]
        private static DataBaseClass _dbInstance;  //Singleton.

        // База Клиентов
        private static SortedList<string, Person> _dataBaseList;

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

        #region/// Синглтон ///////////////////////////
        public static DataBaseClass GetInstance()
        {
            return _dbInstance ?? (_dbInstance = new DataBaseClass());
        }
        #endregion

        #region/// КОНСТРУКТОР и ДЕСТРУКТОР //////////////////////
        private DataBaseClass()
        {// FIXME Вытащить имена файлов сериализации в настройки или ресурсы
            // FIXME Засунуть всю сериализацию в один метод
            // База Клиентов
            _dataBaseList = new SortedList<string, Person>(StringComparer.OrdinalIgnoreCase);
            lock (locker) { Methods.DeSerialize(ref _dataBaseList, "ClientsDataBase.bin"); }

            // База Тренеров
            _trenersList = new List<Trener>();
            Methods.DeSerialize(ref _trenersList, "TrenersDataBase.bin");

            // База Администраторов 
            _adminsList = new List<Administrator>();
            Methods.DeSerialize(ref _adminsList, "AdminsDataBase.bin");

            // Текущий Администратор на Ресепшн
            _adminCurrent = new Administrator("Dummy","");
            Methods.DeSerialize(ref _adminCurrent, "adminToday.bin");

            // Список ежедневных Групповых Тренировок
            _groupScheduleList = new List<ScheduleNote>();
            Methods.DeSerialize(ref _groupScheduleList, "GroupSchedule.bin");

            // Cтруктура для удобства доступа
            _manhattanInfo = new ManhattanInfo
            {
                Admins = _adminsList,
                Treners = _trenersList,
                Schedule = _groupScheduleList,
                CurrentAdmin = _adminCurrent
            };
        }

        ~DataBaseClass()
        {
            // База Клиентов
            lock (locker)
            { Methods.Serialize(_dataBaseList, "ClientsDataBase.bin"); }

            // База Тренеров
            Methods.Serialize(_trenersList, "TrenersDataBase.bin");
            // База Администраторов 
            Methods.Serialize(_adminsList, "AdminsDataBase.bin");
            // Текущий Администратор на Ресепшн
            Methods.Serialize(_adminCurrent, "adminToday.bin");
            // Список ежедневных Групповых Тренировок
            Methods.Serialize(_groupScheduleList, "GroupSchedule.bin");
        }
        #endregion

        #region/// CОБЫТИЯ ///////////////////////////
        // Список Клиентов
        public delegate void MyEventDelegate(object sender, EventArgs e);
        public event MyEventDelegate ListChangedEvent;
        public void OnListChanged()
        {
            ListChangedEvent?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region/// МЕТОДЫ ///////////////////////////

        // Доступ к Коллекциям и Спискам Клиентов, Тренеров, Администраторов, Тренировок
        public static SortedList<string, Person> GetListPersons()
        {
            return _dataBaseList;
        }
        public static ManhattanInfo GetManhattanInfo()
        {
            return _manhattanInfo;
        }

        /// Возвращает ответ Базы Данных об успешности Добавления новой персоны.Success если успех. Код Поля- ошибки или Fail в непонятных случаях.
        public ResponseCode PersonAdd(Person person)
        {
            ResponseCode response = ResponseCode.Fail;

            lock (locker)
            {
                bool containsCopy = DataMethods.IsContainsCopyOfValues(_dataBaseList, person, out response);
                if (containsCopy == false && (!string.IsNullOrEmpty(person.Key)))
                {
                    try
                    {
                        _dataBaseList.Add(person.Key, person);
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
        public ResponseCode PersonRemove(string key)
        {
            ResponseCode result = ResponseCode.Fail;

            lock (locker)
            {
                Person tempPerson;
                if (_dataBaseList.TryGetValue(key, out tempPerson))
                {
                    try
                    {
                        if (_dataBaseList.Remove(key))
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
            }
            return result;
        }
        public bool PersonEditName(string lastName, string newName)
        {
            bool result = DataMethods.EditName(_dataBaseList, lastName, newName);
            if (result) OnListChanged();
            return result;
        }
        /// Returns numberof elements in collection
        public static int GetNumberOfPersons()
        {
            return _dataBaseList.Count;
        }
        public static bool ContainsKey(string personName)
        {
            return _dataBaseList.ContainsKey(personName);
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
