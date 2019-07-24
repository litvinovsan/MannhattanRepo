using PBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBase
{
   [Serializable]
   public class Logic
   {
      Options _options;
      DataBaseClass _dataBase;
     // MainForm _mainForm; // Передается на всякий случай сюда, в дальнейшем, грохнуть
      SortedList<string, Person> _collection;

      public Logic(Options opt, DataBaseClass dataB/*, MainForm mf*/)
      {
         _options = opt;
         _dataBase = dataB;
        // _mainForm = mf;
         _collection = _dataBase.GetCollectionRW();
      }

      // МЕТОДЫ

      /// <summary>
      /// Открывает Карточку Клиента.
      /// </summary>
      /// <param name="keyName"></param>
      
   }
}
