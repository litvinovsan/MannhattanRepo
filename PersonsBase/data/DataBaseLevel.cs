using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PBase
{/// <summary>
 ///  Пользовательская База Данных. Автоматическое сохранение коллекции в файл.
 /// </summary>

   [Serializable]
   public class DataBaseClass
   {
      ///////////////////////////// ОБЬЕКТЫ ///////////////////////////
      [NonSerialized]
      private object locker = new object();               // блокировка коллекции на время сериализации.
      private static SortedList<string, Person> _dataBase; //Хранение клиентской базы
      [NonSerialized]
      private static DataBaseClass _dbInstance;                 //Singleton. DataBase dataBase = DataBase.getInstance();      

      /////////////////////////// КОНСТРУКТОР ///////////////////////////
      private DataBaseClass()
      {
         _dataBase = new SortedList<string, Person>(StringComparer.OrdinalIgnoreCase);
         Methods.DeSerialize(ref _dataBase, "ClientsDataBase.bin");
      }

      ~DataBaseClass()
      {
         Methods.Serialize(_dataBase, "ClientsDataBase.bin");
      }

      public static DataBaseClass GetInstance()
      {
         return _dbInstance ?? (_dbInstance = new DataBaseClass());
      }

      /// /////////////////////////// CОБЫТИЯ ///////////////////////////

      // Список Клиентов
      public delegate void MyEventDelegate(object sender, EventArgs e);
      public event MyEventDelegate ListChangedEvent;
      public void OnListChanged()
      {
         ListChangedEvent?.Invoke(this, EventArgs.Empty);
      }

      /*/////////////////////////// МЕТОДЫ     ///////////////////////////*/

      public SortedList<string, Person> GetCollectionRw()
      {
         return _dataBase;
      }
      
      /// <summary>
      /// Возвращает ответ Базы Данных об успешности Добавления новой персоны.
      /// Возвращает Success если Клиента добавили и Код Поля- ошибки или Fail в непонятных случаях.
      /// </summary>
      public ResponseCode AddPerson(Person person)
      {
         ResponseCode response = ResponseCode.Fail;

         lock (locker)
         {
            bool containsCopy = DataMethods.IsContainsCopyOfValues(_dataBase, person, out response);
            if (containsCopy == false && (!string.IsNullOrEmpty(person.Key)))
            {
               try
               {
                  _dataBase.Add(person.Key, person);
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
            if (_dataBase.TryGetValue(key, out tempPerson))
            {
               try
               {
                  if (_dataBase.Remove(key))
                  {
                     result = ResponseCode.Success;
                     OnListChanged();
                  }
               }
               catch
               {
                  //TODO Логи
                  result = ResponseCode.Fail;
               }
            }
         }
         return result;
      }


      public bool EditName(string lastName, string newName)
      {
         bool result = DataMethods.EditName(_dataBase, lastName, newName);
         if (result) OnListChanged();
         return result;
      }

      /// <summary>
      /// Returns numberof elements in collection
      /// </summary>
      /// <returns></returns>
      public int GetNumberOfPersons()
      {
         return _dataBase.Count;
      }

      public bool ContainsKey(string key)
      {
         return _dataBase.ContainsKey(key);
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
   }
}
