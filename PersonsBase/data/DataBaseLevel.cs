using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PersonsBase.myStd;

namespace PersonsBase.data
{
    [Serializable]
    public class DataBaseLevel
    {
        #region/// ОБЬЕКТЫ Приватные //////////////////////////////

        [NonSerialized]
        private readonly object _locker = new object(); // блокировка коллекции на время сериализации.

        [NonSerialized]
        private static DataBaseLevel _dbInstance;  //Singleton.

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
        public static DataBaseLevel GetInstance()
        {
            return _dbInstance ?? (_dbInstance = new DataBaseLevel());
        }
        #endregion

        #region/// КОНСТРУКТОР и ДЕСТРУКТОР //////////////////////
        private DataBaseLevel()
        {// FIXME Вытащить имена файлов сериализации в настройки или ресурсы
            // FIXME Засунуть всю сериализацию в один метод
            // База Клиентов
            _dataBaseList = new SortedList<string, Person>(StringComparer.OrdinalIgnoreCase);
            lock (_locker) { SerializeClass.DeSerialize(ref _dataBaseList, "ClientsDataBase.bin"); }

            // База Тренеров
            _trenersList = new List<Trener>();
            SerializeClass.DeSerialize(ref _trenersList, "TrenersDataBase.bin");

            // База Администраторов 
            _adminsList = new List<Administrator>();
            SerializeClass.DeSerialize(ref _adminsList, "AdminsDataBase.bin");

            // Текущий Администратор на Ресепшн
            _adminCurrent = new Administrator();
            SerializeClass.DeSerialize(ref _adminCurrent, "adminToday.bin");

            // Список ежедневных Групповых Тренировок
            _groupScheduleList = new List<ScheduleNote>();
            SerializeClass.DeSerialize(ref _groupScheduleList, "GroupSchedule.bin");

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
            // База Клиентов
            lock (_locker)
            { SerializeClass.Serialize(_dataBaseList, "ClientsDataBase.bin"); }

            // База Тренеров
            SerializeClass.Serialize(_trenersList, "TrenersDataBase.bin");
            // База Администраторов 
            SerializeClass.Serialize(_adminsList, "AdminsDataBase.bin");
            // Текущий Администратор на Ресепшн
            SerializeClass.Serialize(_adminCurrent, "adminToday.bin");
            // Список ежедневных Групповых Тренировок
            SerializeClass.Serialize(_groupScheduleList, "GroupSchedule.bin");
            // Сохранение в Excel
            DataBaseM.ExportToExcel(DataBaseM.GetPersonsTable(), false);

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
            ResponseCode response;

            lock (_locker)
            {
                bool containsCopy = DataBaseM.IsContainsCopyOfValues(_dataBaseList, person, out response);
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
        public ResponseCode PersonRemove(string nameKey)
        {
            var result = ResponseCode.Fail;

            lock (_locker)
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
        public bool PersonEditName(string lastName, string newName)
        {
            var result = DataBaseM.EditName(_dataBaseList, lastName, newName);
            if (result) OnListChanged();
            return result;
        }
        /// Returns numberof elements in collection
        public static int GetNumberOfPersons()
        {
            return _dataBaseList.Count;
        }
        public static bool ContainsNameKey(string personName)
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
