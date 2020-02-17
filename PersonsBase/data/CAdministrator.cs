using System;

namespace PersonsBase.data
{
   [Serializable]
   public class Administrator
   {
      public string Name { get; private set; }
      public string Phone { get; set; }
      public Administrator(string name, string phone)
      {
         Name = name;
         Phone = phone;
      }
      public Administrator()
      {
         Name = "";
         Phone = "";
      }
    }
}
