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
         _collectionObj = _dataBase.GetCollectionRw();
      }

      /// <summary>
      /// Настраиваем статический класс DataBaseObject на конкретную Персону
      /// </summary>
      public static Person SetPersonLink(string name)
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
