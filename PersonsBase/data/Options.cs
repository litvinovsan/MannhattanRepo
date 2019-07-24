using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PBase
{

   /// <summary>
   /// Хранятся настройки приложения, а так же общие структуры, списки,и прочие данные.
   /// </summary>
   [Serializable]
   public class Options
   {
      public Administrator adminCurrent;
      public List<Administrator> adminsList;
      public List<Trener> trenersList;
            
      public Options()
      {
         adminsList = new List<Administrator>();
         trenersList = new List<Trener>();
      }
      /// Методы
   }
}
