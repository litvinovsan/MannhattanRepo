using PersonsBase.View;
using System;
using System.Collections.Generic;

namespace PBase
{
   [Serializable]
   public class Logic
   {
      Options _options;

      private DataBaseClass _dataBase;
     // MainForm _mainForm; // Передается на всякий случай сюда, в дальнейшем, грохнуть
      SortedList<string, Person> _collection;

      public Logic(Options opt, DataBaseClass dataB/*, MainForm mf*/)
      {
         _options = opt;
         _dataBase = dataB;
        // _mainForm = mf;
         _collection = _dataBase.GetCollectionRw();
      }

      // МЕТОДЫ
      public void AccessRoot()
      {
         if (_options.IsPasswordValid) // Повторное нажатие Блокирует данные
         {
            _options.IsPasswordValid = false;
         }
         else
         {  // Проверка Пароля.
            PwdForm pwd = new PwdForm(_options);
            pwd.ShowDialog();
         }
      }

   }
}
