using System;
using System.Collections.Generic;
using System.IO;
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
        {
            // База Клиентов
            _dataBaseList = new SortedList<string, Person>(StringComparer.OrdinalIgnoreCase);

            DeSerializeObjects();
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

        #region/// CОБЫТИЯ ///////////////////////////
        // Список Клиентов
        public delegate void MyEventDelegate(object sender, EventArgs e);
        /// <summary>
        /// Событие возникает когда изменяется количество клиентов в базе.
        /// </summary>
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

        /// <summary>
        /// Сериализация всех обьектов Базы данных. Клиенты, Администраторы, Тренеры, Расписание груповых тренировок
        /// </summary>
        public void SerializeObjects()
        {
            MyExportFile.CreateFolder(Options.DataBaseFolderName);
            var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.DataBaseFolderName;

            lock (_locker)
            {
                SerializeClass.Serialize(_dataBaseList, currentPath + "\\" + Options.PersonsDbFile);
            }

            // База Тренеров
            SerializeClass.Serialize(_trenersList, currentPath + "\\" + Options.TrenersDbFile);
            // База Администраторов 
            SerializeClass.Serialize(_adminsList, currentPath + "\\" + Options.AdminsDbFile);
            // Текущий Администратор на Ресепшн
            SerializeClass.Serialize(_adminCurrent, currentPath + "\\" + Options.AdminCurrFile);
            // Список ежедневных Групповых Тренировок
            SerializeClass.Serialize(_groupScheduleList, currentPath + "\\" + Options.GroupSchFile);
        }

        /// <summary>
        /// ДеСериализация всех обьектов Базы данных. Клиенты, Администраторы, Тренеры, Расписание груповых тренировок
        /// </summary>
        public void DeSerializeObjects()
        {
            MyExportFile.CreateFolder(Options.DataBaseFolderName);
            var currentPath = Directory.GetCurrentDirectory() + "\\" + Options.DataBaseFolderName;

            lock (_locker)
            {
                SerializeClass.DeSerialize(ref _dataBaseList, currentPath + "\\" + Options.PersonsDbFile);
            }

            // База Тренеров
            _trenersList = new List<Trener>();
            SerializeClass.DeSerialize(ref _trenersList, currentPath + "\\" + Options.TrenersDbFile);

            // База Администраторов 
            _adminsList = new List<Administrator>();
            SerializeClass.DeSerialize(ref _adminsList, currentPath + "\\" + Options.AdminsDbFile);

            // Текущий Администратор на Ресепшн
            _adminCurrent = new Administrator();
            SerializeClass.DeSerialize(ref _adminCurrent, currentPath + "\\" + Options.AdminCurrFile);

            // Список ежедневных Групповых Тренировок
            _groupScheduleList = new List<ScheduleNote>();
            SerializeClass.DeSerialize(ref _groupScheduleList, currentPath + "\\" + Options.GroupSchFile);
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
