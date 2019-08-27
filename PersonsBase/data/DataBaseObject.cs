using System.Collections.Generic;

namespace PBase
{
   public static class DataBaseObject
   {
      private static readonly DataBaseClass _dataBase;
      private static readonly SortedList<string, Person> _collectionObj;

      private static Person _person;

      static DataBaseObject()
      {
         _dataBase = DataBaseClass.GetInstance();
         _collectionObj = _dataBase.GetPersonsList();
      }

      /// <summary>
      /// Настраиваем статический класс DataBaseObject на конкретную Персону
      /// </summary>
      public static Person GetPersonLink(string name)
      {
          if (_dataBase.ContainsKey(name))
          {
              _person = _collectionObj[name];
              return _person;
          }

          return null;
      }
   }
}
