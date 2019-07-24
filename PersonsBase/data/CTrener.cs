using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBase
{
   [Serializable]
   public class Trener
   {
      public string Name { get; set; }
      public string Phone { get; set; }

      public Trener(string name)
      {
         Name = name;
      }
   }
}
