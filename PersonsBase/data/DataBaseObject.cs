using System.Collections.Generic;

namespace PBase
{
   public static class DataBaseObject
   {
      private static readonly DataBaseClass DataBase;
      private static readonly SortedList<string, Person> CollectionObj;

      private static Person _person;

      static DataBaseObject()
      {
         DataBase = DataBaseClass.GetInstance();
         CollectionObj = DataBase.GetCollectionRw();
      }

      /// <summary>
      /// Настраиваем статический класс DataBaseObject на конкретную Персону
      /// </summary>
      public static Person SetPersonLink(string name)
      {
          if (DataBase.ContainsKey(name))
          {
              _person = CollectionObj[name];
              return _person;
          }

          return null;
      }
   }
}
