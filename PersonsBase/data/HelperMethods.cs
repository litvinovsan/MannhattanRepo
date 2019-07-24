﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBase
{
   /// <summary>
   /// Вспомогательные и универсальные методы, которые неразместить в конкретных классах.
   /// </summary>
   [Serializable]
   static class HelperMethods
   {

      /// <summary>
      /// Подготавливает строку с именем, приводит в  заглавный формат Фамилия Имя Отчество вместо  фамилия имя отчество
      /// </summary>
      /// <param name="fio"></param>
      /// <returns></returns>
      public static string prepareName(string fio)
      {
         string Surname = "";
         string FirstName = "";
         string SecondName = "";

         string minimumSpaces = Regex.Replace(fio.ToLower().Trim(), @"[^\S\r\n]+", " "); // Уплотняем пробелы
         string[] fioArray = minimumSpaces.Split(' ');

         if (fioArray.Length == 1 && fioArray[0].Length >= 1) //Фамилия
         {
            Surname = char.ToUpper(fioArray[0][0]) + fioArray[0].Remove(0, 1);
         }
         else if (fioArray.Length == 2 && fioArray[0].Length > 1 && fioArray[1].Length > 1) // Фамилия Имя
         {
            Surname = char.ToUpper(fioArray[0][0]) + fioArray[0].Remove(0, 1);
            FirstName = char.ToUpper(fioArray[1][0]) + fioArray[1].Remove(0, 1);
         }
         else // Фамилия Имя Отчество
         {
            if (fioArray[0].Length > 1 && fioArray[1].Length > 1 && fioArray[2].Length > 1)
            {
               Surname = char.ToUpper(fioArray[0][0]) + fioArray[0].Remove(0, 1);
               FirstName = char.ToUpper(fioArray[1][0]) + fioArray[1].Remove(0, 1);
               SecondName = char.ToUpper(fioArray[2][0]) + fioArray[2].Remove(0, 1);
            }
         }
         return string.Format("{0} {1} {2}", Surname, FirstName, SecondName).Trim();
      }

      public static string preparePhoneNumber(string phoneNumber)
      {
         //FIXME 
         return "todo";
      }


      // Сериализация обьектов

      public static bool Serialize<T>( T objectToSerialize, string nameFile)
      {
         
         try
         {
            using (MemoryStream ms = new MemoryStream())
            {
               var formatter = new BinaryFormatter();
               formatter.Serialize(ms, objectToSerialize);// Если ошибка, вываливаемся тут и не стираем файл базы
               // Сохраняем в файл поток из памяти
               using (FileStream fileStream = new FileStream(nameFile, FileMode.OpenOrCreate, FileAccess.Write))
               {
                  formatter.Serialize(fileStream, objectToSerialize);
               }
               return true;
            }
         }
         catch (Exception e)
         {
            MessageBox.Show("Ошибка: " + e.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
         }
      }

      public static bool DeSerialize<T>(ref T objectToDeSerialize, string nameFile)
      {
        
         try
         {
            var formatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(nameFile, FileMode.OpenOrCreate, FileAccess.Read))
            {
               objectToDeSerialize = (T)formatter.Deserialize(fileStream);

            }
            return true;
         }
         catch (Exception e)
         {
            MessageBox.Show("Ошибка: "+ e.Message,"Внимание",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return false;
         }
      }
   }
}