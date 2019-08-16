using PersonsBase.View;
using System;
using System.Collections.Generic;

namespace PBase
{
   [Serializable]
   public class Logic
   {
      private Options _options;
      private DataBaseClass _dataBase;
      private SortedList<string, Person> _collection;

      public Logic(Options opt, DataBaseClass dataB)
      {
         _options = opt;
         _dataBase = dataB;
         _collection = _dataBase.GetCollectionRw();
      }

      // МЕТОДЫ
      public void AccessRoot()
      {
         if (PwdForm.IsPassUnLocked()) PwdForm.LockPassword();
         else
         {
            PwdForm pwd = new PwdForm(_options);
            pwd.ShowDialog();
         }
      }
   }
}
