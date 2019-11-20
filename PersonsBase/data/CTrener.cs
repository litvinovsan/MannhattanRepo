using System;

namespace PBase
{
   [Serializable]
   public class Trener
   {
      public string Name { get; set; }
      public string Phone { get; set; }
      public string Notes { get; set; }
      public Trener(string name, string phone)
      {
         Name = name;
         Phone = phone;
      }
      public Trener()
      {
         Name = "Имя неизвестно";
         Phone = "";
      }
   }
}
