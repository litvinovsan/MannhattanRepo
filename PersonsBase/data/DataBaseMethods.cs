﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBase
{
   [Serializable]
   public static class DataMethods
   {
      /// <summary>
      /// Полная и сама долгая проверка.
      /// Проверяются все значимые поля для создания персоны по базе.Возвращает статус Success/Duplicate или указывает на повторяющееся поле.
      /// </summary>
      /// <param name="person"></param>
      /// <returns></returns>
      public static bool IsContainsCopyOfValues(SortedList<string, Person> inputDict, Person person, out ResponseCode response)
      {
         bool containsCopy = false;
         response = ResponseCode.NoDuplicate;
         //Если пустая коллекция
         if (inputDict.Count == 0)
         {
            containsCopy = false;
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

            foreach (KeyValuePair<string, Person> item in inputDict)
            {
               var tempResponse = ResponseCode.NoDuplicate;
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


      /*************** Выборка, Поиск, редактирование    ****************/

      /// <summary>
      /// Find by index in List. Method for tests
      /// </summary>
      /// <param name="inputCollection"></param>
      /// <param name="index"></param>
      /// <returns></returns>
      public static Person FindByIndexInBase(SortedList<string, Person> inputCollection, int index)
      {
         Person findedPerson = null;
         if (inputCollection != null && inputCollection.Count > 0 && index <= inputCollection.Count - 1)
         {
            var keyValPair = inputCollection.ElementAt(index);
            findedPerson = keyValPair.Value;
         }
         return findedPerson;
      }
      public static Person FindByDriveId(SortedList<string, Person> inputCollection, string driveLic)
      {
         Person findedPerson = null;
         if (inputCollection != null && driveLic != null && inputCollection.Count > 0)
         {
            foreach (var item in inputCollection)
            {
               if (driveLic == item.Value.DriverIdNum)
               {
                  findedPerson = item.Value;
                  break;
               }
            }
         }
         return findedPerson;
      }

      public static bool EditDriveId(ref Person person, string newDriverId)
      {
         bool result = false;
         if (person != null)
         {
            try
            {
               person.DriverIdNum = newDriverId;
               result = true;
            }
            catch (Exception e)
            {
            }
         }
         return result;
      }

      public static Person FindByPersonalNumber(SortedList<string, Person> inputCollection, int number)
      {
         Person result = null;
         if (inputCollection != null && number != 0 && inputCollection.Count > 0)
         {
            try
            {
               result = (Person)inputCollection.Values.Single(x => x.PersonalNumber == number);
            }
            catch { }
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
            catch (Exception e) { }
         }
         return result;
      }

      public static Person FindByName(SortedList<string, Person> inputCollection, string fullName)
      {
         Person result = null;
         if (inputCollection != null && !string.IsNullOrEmpty(fullName) && inputCollection.Count > 0)
         {
            string fname = HelperMethods.prepareName(fullName);
            try
            {
               result = (Person)inputCollection.Values.Single(x => x.Name == fname);
            }
            catch { }
         }
         return result;
      }

      /// <summary>
      /// Обновляет ключ, устанавливает новое имя. Удаляет и создает заново персону.
      /// </summary>
      public static bool EditName(SortedList<string, Person> inputCollection, string key, string newFullName)
      {
         bool result = false;
         string newName = HelperMethods.prepareName(newFullName);

         if (inputCollection != null && inputCollection.Count > 0 && !string.IsNullOrEmpty(newName) && newName != "")
         {
            string localKey = HelperMethods.prepareName(key);
            // Копируем данные текущей персоны
            Person personForEdit = null; // Копия текущей персоны                                                                        
            result = inputCollection.TryGetValue(localKey, out personForEdit);
            if (result)
            {
               personForEdit.Name = newName;
               inputCollection.Remove(localKey);
               inputCollection.Add(personForEdit.Key, personForEdit);
               result = true;
            }
            else
            {
               result = false;
            }
         }
         return result;
      }

      public static Person FindByPassport(SortedList<string, Person> inputCollection, string passp)
      {
         Person result = null;
         if (inputCollection != null && !string.IsNullOrEmpty(passp) && inputCollection.Count > 0)
         {
            try
            {
               result = (Person)inputCollection.Values.Single(x => x.Passport == passp);
            }
            catch { }
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
            catch (Exception e) { }
         }
         return result;
      }

      public static Person FindByPhone(SortedList<string, Person> inputCollection, string telnumber)
      {
         Person result = null;
         if (inputCollection != null && !string.IsNullOrEmpty(telnumber) && inputCollection.Count > 0)
         {
            try
            {
               result = (Person)inputCollection.Values.Single(x => x.Phone == telnumber);
            }
            catch { }
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
            catch (Exception e) { }
         }
         return result;
      }

      // Выборки нескольких клиентов
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

      //FIXME:
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
   }
}