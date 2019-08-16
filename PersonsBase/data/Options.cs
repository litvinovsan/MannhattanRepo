using System;
using System.Collections.Generic;
// ReSharper disable All

namespace PBase
{

   /// Хранятся настройки приложения, а так же общие структуры, списки,и прочие данные.
   /// Использовать выборочное сохранение обьектов в Options. Весь класс сериализовать не рекомендуется т.к. перетирается пароль
   [Serializable]
   public class Options
   {
      ////////////////  События ///////////////////////////////////////
      //[field: NonSerialized]


      ////////////////////////////////////////////////////////////

      public Administrator adminCurrent;
      public List<Administrator> adminsList;
      public List<Trener> trenersList;

      public Options()
      {

      }

      ////////////////  Свойства ///////////////////////////////////////
      

      ////////////////  Методы ///////////////////////////////////////
  
   }
}
