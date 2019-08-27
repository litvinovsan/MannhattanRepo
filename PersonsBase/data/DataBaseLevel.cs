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
        private static List<Tuple<MyTime, string>> _groupTrainingsList;

        #endregion

        #region/// КОНСТРУКТОР и ДЕСТРУКТОР //////////////////////
        private DataBaseClass()
        {
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
            _adminCurrent = new Administrator("Dummy");
            Methods.DeSerialize(ref _adminCurrent, "adminToday.bin");

            // Список ежедневных Групповых Тренировок
            _groupTrainingsList = new List<Tuple<MyTime, string>>();
            Methods.DeSerialize(ref _groupTrainingsList, "GroupSchedule.bin");
        }

        ~DataBaseClass()
        {
            // База Клиентов
            lock (locker) 
            {
                Methods.Serialize(_dataBaseList, "ClientsDataBase.bin");
            }

            // База Тренеров
            Methods.Serialize(_trenersList, "TrenersDataBase.bin");
            // База Администраторов 
            Methods.Serialize(_adminsList, "AdminsDataBase.bin");
            // Текущий Администратор на Ресепшн
            Methods.Serialize(_adminCurrent, "adminToday.bin");
            // Список ежедневных Групповых Тренировок
            Methods.Serialize(_groupTrainingsList, "GroupSchedule.bin");
        }
        #endregion

        #region/// Синглтон ///////////////////////////
        public static DataBaseClass GetInstance()
        {
            return _dbInstance ?? (_dbInstance = new DataBaseClass());
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
        public SortedList<string, Person> GetPersonsList()
        {
            return _dataBaseList;
        }
        public Administrator GetCurrentAdmin()
        {
            return _adminCurrent;
        }
        public List<Administrator> GetAdmins()
        {
            return _adminsList;
        }
        public List<Trener> GetTreners()
        {
            return _trenersList;
        }
        public List<Tuple<MyTime, string>> GetGroupTrainings()
        {
            return _groupTrainingsList;
        }

        /// Возвращает ответ Базы Данных об успешности Добавления новой персоны.
        /// Возвращает Success если Клиента добавили и Код Поля- ошибки или Fail в непонятных случаях.
        public ResponseCode AddPerson(Person person)
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
        public ResponseCode RemovePerson(string key)
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
        public bool EditName(string lastName, string newName)
        {
            bool result = DataMethods.EditName(_dataBaseList, lastName, newName);
            if (result) OnListChanged();
            return result;
        }
        /// Returns numberof elements in collection
        public int GetNumberOfPersons()
        {
            return _dataBaseList.Count;
        }
        public bool ContainsKey(string key)
        {
            return _dataBaseList.ContainsKey(key);
        }
        public void AddTestCollection()
        {
            AddPerson(new Person("Гомер Симпсон")
            {
                PersonalNumber = 1,
                Status = StatusPerson.Активный,
                BirthDate = DateTime.Now,
                Passport = "7605898456",
                SpecialNotes = "Тестовый Гусь. Активный клиент.",
                Phone = "9144071960"

            });


            AddPerson(new Person("Мардж Симпсон")
            {
                Name = "Мардж Симпсон",
                PersonalNumber = 2,
                Status = StatusPerson.Нет_Карты,
                BirthDate = DateTime.Parse("22.02.2002"),
                Passport = "7505898456",
                SpecialNotes = "Тестовый Гусь. Не Активный клиент.",
                Phone = "9115555960"
            });

            AddPerson(new Person("Барт Симпсон")
            {
                Name = "Барт Симпсон",
                PersonalNumber = 3,
                Status = StatusPerson.Заморожен,
                BirthDate = DateTime.Parse("3.03.2003"),
                Passport = "7105878456",
                SpecialNotes = "Тестовый Гусь. Заморожен клиент.",
                Phone = "9124070970"
            });
        }
        #endregion
    }
}
