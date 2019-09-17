using System;

namespace PBase
{
   [Serializable]
   public class Administrator
   {
      public string Name { get; set; }
      public string Phone { get; set; }
      public Administrator(string name, string phone)
      {
         Name = name;
      }
   }
}
