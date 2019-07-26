using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
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
      private static SortedList<string, Person> dataBase; //Хранение клиентской базы
      [NonSerialized]
      private static DataBaseClass dbInstance;                 //Singleton. DataBase dataBase = DataBase.getInstance();      
      [NonSerialized]
      private string nameToShow;     // При записи Имени, вызывается форма Клиента
      [NonSerialized]
      private BinaryFormatter Formatter;
      public string NameToShow
      {
         get
         {
            return nameToShow;
         }
         set
         {
            if (dataBase.ContainsKey(value))
            {
               nameToShow = value;
            }
         }
      }

      /////////////////////////// КОНСТРУКТОР ///////////////////////////
      private DataBaseClass()
      {
         dataBase = new SortedList<string, Person>(StringComparer.OrdinalIgnoreCase);
         HelperMethods.DeSerialize<SortedList<string, Person>>(ref dataBase, "ClientsDataBase.bin");
      }

      ~DataBaseClass()
      {
         HelperMethods.Serialize<SortedList<string, Person>>(dataBase, "ClientsDataBase.bin");
      }

      public static DataBaseClass getInstance()
      /// Return instanse of data base,which contains all clients
      {
          return dbInstance ?? (dbInstance = new DataBaseClass());
      }
      
      /// /////////////////////////// CОБЫТИЯ ///////////////////////////
      public delegate void MyEventDelegate(object sender, EventArgs e);
      public event MyEventDelegate listChangedEvent;
      public void OnListChanged()
      {
        listChangedEvent?.Invoke(this, EventArgs.Empty);
      }
      
      /*/////////////////////////// МЕТОДЫ     ///////////////////////////*/

      public SortedList<string, Person> GetCollectionRW()
      {
         return (SortedList<string, Person>)dataBase;
      }
      public bool Serialize()
      {
         bool result;
         try
         {
            using (MemoryStream ms = new MemoryStream())
            {
               Formatter = new BinaryFormatter();
               Formatter.Serialize(ms, dataBase);// Если ошибка, вываливаемся тут и не стираем файл базы
               // Сохраняем в файл поток из памяти
               using (FileStream fileStream = new FileStream("ClientsDataBase.bin", FileMode.OpenOrCreate, FileAccess.Write))
               {
                  Formatter.Serialize(fileStream, dataBase);
               }
               result = true;
            }
         }
         catch (Exception e)
         {

            MessageBox.Show(e.Message);
            result = false;
         }

         return result;
      }

      public bool DeSerialize()
      {
         dataBase.Clear();
         try
         {
            Formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("ClientsDataBase.bin", FileMode.OpenOrCreate, FileAccess.Read))
            {
               dataBase = (SortedList<string, Person>)Formatter.Deserialize(fileStream);
               Console.WriteLine("  Объект десериализован " + dataBase.Count.ToString() + "клиентов.");
            }
            return true;
         }
         catch (Exception e)
         {
            return false;
         }
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
           var containsCopy = DataMethods.IsContainsCopyOfValues(dataBase, person, out response);
            if (containsCopy == false && (!string.IsNullOrEmpty(person.Key)))
            {
               try
               {
                  dataBase.Add(person.Key, person);
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
            if (dataBase.TryGetValue(key, out tempPerson))
            {
               try
               {
                  if (dataBase.Remove(key))
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
         bool result = false;
         result = DataMethods.EditName(dataBase, lastName, newName);
         if (result == true) OnListChanged();
         return result;
      }

      /// <summary>
      /// Returns numberof elements in collection
      /// </summary>
      /// <returns></returns>
      public int GetNumberOfPersons()
      {
         return dataBase.Count;
      }

      public bool ContainsKey(string key)
      {
         return dataBase.ContainsKey(key);
      }

      public void AddTestCollection()
      {
         AddPerson(new Person("Гомер Симпсон")
         {
            PersonalNumber = 1,
            Status = StatusPerson.Активный,
            BirthDate = DateTime.Parse("11.01.2001"),
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
