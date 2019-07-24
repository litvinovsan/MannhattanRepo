using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBase
{
   public static class DataBaseObject
   {
      public static readonly DataBaseClass _dataBase;
      public static SortedList<string, Person> _collectionObj;

      public static Person _person;

      static DataBaseObject()
      {
         _dataBase = DataBaseClass.getInstance();
         _collectionObj = _dataBase.GetCollectionRW();
      }

      /// <summary>
      /// Настраиваем статический класс DataBaseObject на конкретную Персону
      /// </summary>
      public static Person SetPersonLink(string Name)
      {
         if (_dataBase.ContainsKey(Name))
         {
            _person = _collectionObj[Name];
            return _person;
         }
         else return null;
      }
   }
}
