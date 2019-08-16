using PersonsBase.data;
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
         adminsList = new List<Administrator>();
         trenersList = new List<Trener>();
         adminsList.Add(new Administrator("Admin 1"));
         adminsList.Add(new Administrator("Admin 2"));
         adminsList.Add(new Administrator("Admin 3"));
         adminsList.Add(new Administrator("Admin 4"));

         trenersList.Add(new Trener("Trener 1"));
         trenersList.Add(new Trener("Trener 2"));
         trenersList.Add(new Trener("Trener 3"));
         trenersList.Add(new Trener("Trener 4"));
         trenersList.Add(new Trener("Trener 5"));
         trenersList.Add(new Trener("Trener 6"));
      }

      ////////////////  Свойства ///////////////////////////////////////


      ////////////////  Методы ///////////////////////////////////////

   }

   
}
