﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBase
{
   [Serializable]
   public class Administrator
   {
      public string Name { get; set; }
      public string Phone { get; set; }
      public Administrator(string name)
      {
         Name = name;
      }
   }
}
