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


      ////////////////////////////////////////////////////////////
      // Нужно пробросить Список Тренеров в класс TypeWorkoutForm 
      public Administrator adminCurrent;
      public List<Administrator> adminsList;
      public List<Trener> trenersList;

      // Список ежедневных Групповых Тренировок
      [field: NonSerialized]
      public static List<Tuple<MyTime, string>> GroupTrainingsList = new List<Tuple<MyTime, string>>();


      public Options()
      {
         adminsList = new List<Administrator>();
         trenersList = new List<Trener>();

         // Временные поля
         //adminsList.Add(new Administrator("Admin 1"));
         //adminsList.Add(new Administrator("Admin 2"));

         //trenersList.Add(new Trener("Trener 1"));
         //trenersList.Add(new Trener("Trener 2"));
         //trenersList.Add(new Trener("Trener 3"));
         //trenersList.Add(new Trener("Trener 4"));
         //trenersList.Add(new Trener("Trener 5"));
         //trenersList.Add(new Trener("Trener 6"));

         GroupTrainingsList.Add(new Tuple<MyTime, string>(new MyTime(9, 10), "Беговая"));
         GroupTrainingsList.Add(new Tuple<MyTime, string>(new MyTime(MyTime.Hours[1], MyTime.Minutes[4]), "Памп"));
         GroupTrainingsList.Add(new Tuple<MyTime, string>(new MyTime(16, 0), "Йога"));

      }

      ////////////////  Свойства ///////////////////////////////////////


      ////////////////  Методы ///////////////////////////////////////

   }


}
