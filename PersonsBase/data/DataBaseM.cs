using System;
using System.Collections.Generic;
using System.Linq;
using PBase;

namespace PersonsBase.data
{
    [Serializable]
    public static class DataBaseM
    {
        #region /// ПОИСК ДУБЛИКАТОВ ///////////////
        /// <summary>
        /// Полная и сама долгая проверка.
        /// Проверяются все значимые поля для создания персоны по базе.Возвращает статус Success/Duplicate или указывает на повторяющееся поле.
        /// </summary>
        public static bool IsContainsCopyOfValues(SortedList<string, Person> inputDict, Person person, out ResponseCode response)
        {
            bool containsCopy = false;
            response = ResponseCode.NoDuplicate;
            //Если пустая коллекция
            if (inputDict.Count == 0)
            {
                response = ResponseCode.NoDuplicate;
                return false;
            }

            //быстрая Проверка на Ключ/Имя клиента    
            if (inputDict.ContainsKey(person.Key))
            {
                containsCopy = true;
                response = ResponseCode.KeyExist;
            }
            else
            {
                //Ищем по Значению: Tel, Passp, Drive, ID,
                foreach (var item in inputDict)
                {
                    ResponseCode tempResponse;
                    if (item.Value.Equals(person, out tempResponse))
                    {
                        containsCopy = true;
                        response = tempResponse;
                        break;
                    }
                }
            }
            return containsCopy;
        }

        // Быстрая проверка по Ключу и ссылке на обьект
        public static bool IsContainsKeyOrVal(SortedList<string, Person> inputDict, Person person)
        {
            return inputDict.ContainsKey(person.Key) && inputDict.ContainsValue(person);
        }
        #endregion

        #region /// ПОИСК, РЕДАКТИРОВАНИЕ /////////////

        // Index in List
        public static Person FindByIndexInBase(SortedList<string, Person> inputCollection, int index)
        {
            if (inputCollection == null || inputCollection.Count <= 0 || index > inputCollection.Count - 1)
                return null;
            var keyValPair = inputCollection.ElementAt(index);
            var findedPerson = keyValPair.Value;
            return findedPerson;
        }

        // Driver ID
        public static Person FindByDriveId(SortedList<string, Person> inputCollection, string driveLic)
        {
            Person findedPerson;
            if (inputCollection == null || driveLic == null || inputCollection.Count <= 0) return null;
            try
            {
                findedPerson = inputCollection.First((p => (p.Value.DriverIdNum == driveLic))).Value;
            }
            catch
            {
                findedPerson = null;
            }
            return findedPerson;
        }
        public static bool EditDriveId(ref Person person, string newDriverId)
        {
            bool result = false;
            if (person == null) return false;
            try
            {
                person.DriverIdNum = newDriverId;
                result = true;
            }
            catch (Exception)
            {
                // ignored
            }
            return result;
        }

        // Personal Number
        public static Person FindByPersonalNumber(SortedList<string, Person> inputCollection, int number)
        {
            Person result = null;
            if (inputCollection != null && number != 0 && inputCollection.Count > 0)
            {
                try
                {
                    result = inputCollection.Values.Single(x => x.PersonalNumber == number);
                }
                catch
                {
                    // ignored
                }
            }
            return result;
        }
        public static bool EditPersonalNumber(ref Person person, int newNumber)
        {
            bool result = false;
            if (person != null && newNumber > 0)
            {
                try
                {
                    person.PersonalNumber = newNumber;
                    result = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        // Name 
        public static Person FindByName(SortedList<string, Person> inputCollection, string fullName)
        {
            Person result = null;
            if (inputCollection != null && !string.IsNullOrEmpty(fullName) && inputCollection.Count > 0)
            {
                string fname = Methods.PrepareName(fullName);
                try
                {
                    result = inputCollection.Values.Single(x => x.Name == fname);
                }
                catch
                {
                    throw;
                }
            }
            return result;
        }
        public static bool EditName(SortedList<string, Person> inputCollection, string key, string newFullName)
        {
            bool result = false;
            string newName = Methods.PrepareName(newFullName);

            if (inputCollection != null && inputCollection.Count > 0 && !string.IsNullOrEmpty(newName) && newName != "")
            {
                string localKey = Methods.PrepareName(key);
                // Копируем данные текущей персоны
                Person personForEdit; // Копия текущей персоны                                                                        
                result = inputCollection.TryGetValue(localKey, out personForEdit);
                if (result)
                {
                    personForEdit.Name = newName;
                    inputCollection.Remove(localKey);
                    inputCollection.Add(personForEdit.Key, personForEdit);
                }
            }
            return result;
        }

        // Passport
        public static Person FindByPassport(SortedList<string, Person> inputCollection, string passp)
        {
            Person result;
            if (inputCollection == null || string.IsNullOrEmpty(passp) || inputCollection.Count <= 0) return null;
            try
            {
                result = inputCollection.Values.Single(x => x.Passport == passp);
            }
            catch
            {
                result = null;
            }
            return result;
        }
        public static bool EditPassport(ref Person person, string newPassport)
        {
            bool result = false;
            if (person != null && !string.IsNullOrEmpty(newPassport) && !string.IsNullOrWhiteSpace(newPassport))
            {
                try
                {
                    person.Passport = newPassport;
                    result = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        // Phone
        public static Person FindByPhone(SortedList<string, Person> inputCollection, string telnumber)
        {
            Person result;
            if (inputCollection == null || string.IsNullOrEmpty(telnumber) || inputCollection.Count <= 0) return null;
            try
            {
                result = inputCollection.Values.Single(x => x.Phone == telnumber);
            }
            catch
            {
                result = null;
            }
            return result;
        }
        public static bool EditPhone(ref Person person, string newPhone)
        {
            bool result = false;
            if (person != null && !string.IsNullOrEmpty(newPhone) && !string.IsNullOrWhiteSpace(newPhone))
            {
                try
                {
                    person.Passport = newPhone;
                    result = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        #endregion

        #region /// ВЫБОРКА клиентов ////////////////////
        public static IEnumerable<Person> SelectByGender(IEnumerable<Person> inputCollection, Gender gender)
        {
            var result = from n in inputCollection
                         where n.GenderType == gender
                         select n;
            return result;
        }

        public static IEnumerable<Person> SelectByStatus(IEnumerable<Person> inputCollection, StatusPerson status)
        {
            var persons = inputCollection.Where(c => c.Status == status).Select(c => c);
            return persons;
        }

        public static IEnumerable<Person> SelectBDateToday(IEnumerable<Person> inputCollection)
        {
            var persons = inputCollection.Where(c => c.BirthDate.Equals(DateTime.Now.Date));
            return persons;
        }


        /*      // Добавляет в список тех людей, абонементы которых заканчиваются через  daysLeft  дней.
          public static IEnumerable<Person> SelectEndInXdays(IEnumerable<Person> inputCollection, int daysLeft)
          {
             var today = DateTime.Now;
             var lefts = today.AddDays(daysLeft);
             var persons = inputCollection.Where(c => c.FinishDate.Date.Equals(lefts.Date));
             return persons;
          }

          public static IEnumerable<Person> SelectTimeForVisit(IEnumerable<Person> inputCollection, TimeForTr td)
          {
             var persons = inputCollection.Where(c => c.TimeForVisit == td).Select(c => c);
             return persons;
          }

        public static IEnumerable<Person> SelectTypeOfTraining(IEnumerable<Person> inputCollection, TypeWorkout typetr)
          {
            var persons = inputCollection.Where(c => c.TypeTraining == typetr).Select(c => c);
             return persons;
          }

          public static IEnumerable<Person> SelectWithPackets(IEnumerable<Person> inputCollection)
          {
             var persons = inputCollection.Where(c => c.Packets != 0).Select(c => c);
             return persons;
          }
    */

        #endregion
    }
}
