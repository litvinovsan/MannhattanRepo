using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PBase
{
   /// <summary>
   /// Вспомогательные и универсальные методы, которые неразместить в конкретных классах.
   /// </summary>
   [Serializable]
   static class Methods
   {

      /// <summary>
      /// Подготавливает строку с именем, приводит в  заглавный формат Фамилия Имя Отчество вместо  фамилия имя отчество
      /// </summary>
      /// <param name="fio"></param>
      /// <returns></returns>
      public static string PrepareName(string fio)
      {
         string surname = "";
         string firstName = "";
         string secondName = "";

         string minimumSpaces = Regex.Replace(fio.ToLower().Trim(), @"[^\S\r\n]+", " "); // Уплотняем пробелы
         string[] fioArray = minimumSpaces.Split(' ');

         if (fioArray.Length == 1 && fioArray[0].Length >= 1) //Фамилия
         {
            surname = char.ToUpper(fioArray[0][0]) + fioArray[0].Remove(0, 1);
         }
         else if (fioArray.Length == 2 && fioArray[0].Length > 1 && fioArray[1].Length > 1) // Фамилия Имя
         {
            surname = char.ToUpper(fioArray[0][0]) + fioArray[0].Remove(0, 1);
            firstName = char.ToUpper(fioArray[1][0]) + fioArray[1].Remove(0, 1);
         }
         else // Фамилия Имя Отчество
         {
            if (fioArray[0].Length > 1 && fioArray[1].Length > 1 && fioArray[2].Length > 1)
            {
               surname = char.ToUpper(fioArray[0][0]) + fioArray[0].Remove(0, 1);
               firstName = char.ToUpper(fioArray[1][0]) + fioArray[1].Remove(0, 1);
               secondName = char.ToUpper(fioArray[2][0]) + fioArray[2].Remove(0, 1);
            }
         }
         return $"{surname} {firstName} {secondName}".Trim();
      }

      public static string PreparePhoneNumber(string phoneNumber)
      {
         //FIXME 
         return "todo";
      }


      // Сериализация обьектов
      public static bool Serialize<T>(T objectToSerialize, string nameFile)
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
            MessageBox.Show("Ошибка: " + e.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
         }
      }


      // Работа с таблицами.Подготовка для отображения на Клиентской форме
      public static TableLayoutPanel CreateTable(List<Tuple<Label, Control>> list)
      {// Создает таблицу с элементами из List. Таблица вида: Лэйбл - Значение.
         var tableInfo = new TableLayoutPanel { Dock = DockStyle.Fill };
         // Базовая таблица. 1 стр, 2 стлб
         tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
         tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));

         for (int i = 0; i < list.Count; i++)
         {
            tableInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tableInfo.Controls.Add(list[i].Item1, 0, i);
            tableInfo.Controls.Add(list[i].Item2, 1, i);
         }

         // Пустые элементы. Без них сьезжает вся разметка.
         tableInfo.Controls.Add(new Panel(), 0, list.Count);
         tableInfo.Controls.Add(new Panel(), 1, list.Count);

         return tableInfo;
      }
      public static IEnumerable<Tuple<string, string>> GetEmptyInfoList(Person _person)
      {
         var result = new List<Tuple<string, string>>
          {
              new Tuple<string, string>("Текущий статус Клиента", _person.Status.ToString()),
              new Tuple<string, string>("Абонемент ", "Нет"),
              new Tuple<string, string>("Клубная Карта ", "Нет ")
          };

         return result;
      }
      public static Tuple<Label, Control> CreateRowInfo(string label, string info)
      {// Создаем экземпляры Label и TextBox. Настройка отображения и свойст тут
         Label lb = new Label
         {
            Text = label,
            Anchor = AnchorStyles.Left,
            AutoSize = true,
            TextAlign = ContentAlignment.TopLeft
         };

         TextBox tb = new TextBox
         {
            BackColor = Color.AliceBlue,
            BorderStyle = BorderStyle.FixedSingle,
            Text = " " + info.Replace("_", " "),
            Dock = DockStyle.Fill,
            Font = new Font("Microsoft Sans Serif", 9F)
         };

         // Выполняем проверки на какие-либо ограничения. 
         if (info == "Не_Оплачено") tb.BackColor = Color.LightPink;

         return Tuple.Create<Label, Control>(lb, tb);
      }
      public static IEnumerable<Tuple<Label, Control>> TupleConverter(IEnumerable<Tuple<string, string>> data)
      {// Преобразует Список вида List<Tuple<string, string>> в универсальный Список: List<Tuple<Label, Control>>
         var result = new List<Tuple<Label, Control>>();

         foreach (var item in data)
         {
            result.Add(Methods.CreateRowInfo(item.Item1, item.Item2));
         }
         // Выделяем жирным первую строку
         result[0].Item1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
         result[0].Item2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
         result[0].Item1.ForeColor = Color.FromArgb(0, 64, 64);
         result[0].Item2.ForeColor = Color.FromArgb(0, 64, 64);

         return result;
      }


      // Методы по оформлению контролов На WinForm
      #region // Разные мелкие методы По оформлению и тд
      /// <summary>
      /// Задает Цвет Текстбоксам и другим элементам. Зеленый если == , Красный если != аргументы. 
      /// </summary>
      public static void SetFontColor(Control ctrl, string actual, string expected)
      {
         ctrl.ForeColor = actual == expected ? Color.Green : Color.Red;
      }
      /// <summary>
      /// // Задает Цвет clrSuccess если == , И clrFail если != аргументы.
      /// </summary>
      public static void SetControlBackColor(Control ctrl, string current, string expected, Color clrSuccess, Color clrFail)
      {
         ctrl.BackColor = current == expected ? clrSuccess : clrFail;
      }
      /// <summary>
      /// // Задает Цвет SystemColors.Window если == , И Yellow если != аргументы.
      /// </summary>
      public static void SetControlBackColor(Control ctrl, string current, string expected)
      {
         Color clrSuccess = SystemColors.Window;
         Color clrFail = Color.Yellow;
         ctrl.BackColor = current == expected ? clrSuccess : clrFail;
      }
      /// <summary>  
      /// Задает Цвет clr если == , Красный если != аргументы.
      /// </summary>
      public static void SetControlBackColor(Control ctrl, string current, string expected, Color clrFail)
      { // Задает Цвет clrFail если != аргументы.
         if (current != expected)
         {
            ctrl.BackColor = clrFail;
         } // SystemColors.Window
      }
      /// <summary>
      /// Перебираем все контролы рекурсивно. Выполняем для каждого действие action
      /// </summary>
      public static void ForAllControls(Control parent, Action<Control> action)
      {
         foreach (Control c in parent.Controls)
         {
            action(c);
            ForAllControls(c, action);
         }
      }
      /// <summary>
      /// Снимает выделение по всем контролам в групбоксе
      /// </summary>
      public static void ClearSelection(Control control)
      {
         ForAllControls(control, x =>
         {
            if (x is ComboBox)
            {
               (x as ComboBox).SelectionLength = 0;
               (x as ComboBox).Select(0, 0);
               (x as ComboBox).BackColor = SystemColors.Window;
            }
         });
      }
      public static void SetControlsColorDefault(Control control)
      {
         ForAllControls(control, x =>
         {
            if (x is ComboBox)
            {
               (x as ComboBox).BackColor = SystemColors.Window;
            }
            if (x is TextBox)
            {
               (x as TextBox).BackColor = SystemColors.Window;
            }
         });
      }

      // Часы. Подготовка строки 
      public static string ClockProcessing()
      {
         int h = DateTime.Now.Hour;
         int m = DateTime.Now.Minute;
         int s = DateTime.Now.Second;

         string time = "";
         if (h < 10)
         {
            time += "0" + h;
         }
         else
         {
            time += h;
         }

         time += ":";

         if (m < 10)
         {
            time += "0" + m;
         }
         else
         {
            time += m;
         }

         time += ":";

         if (s < 10)
         {
            time += "0" + s;
         }
         else
         {
            time += s;
         }

         return time;
      }
      #endregion
   }
}
