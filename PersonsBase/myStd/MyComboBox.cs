using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersonsBase.myStd
{
   /* Текст из ENUMERATION
    * .AddRange(Enum.GetNames(typeof(Gender)).ToArray<object>());
    * .SelectedItem = _person.GenderType.ToString();
    *
    *
    */
   public static class MyComboBox
   {
      public static void Initialize(ComboBox comboBox, object[] items, object selItem)
      {
         comboBox.Items.Clear();
         comboBox.Items.AddRange(items); // Обновляем комбобокс
         comboBox.SelectedItem = selItem;
      }
      public static void Initialize(ComboBox comboBox, object[] items)
      {
         comboBox.Items.Clear();
         comboBox.Items.AddRange(items); // Обновляем комбобокс
      }

      #region Работа с Енумами
      public static void Initialize<T>(ComboBox comboBox)
      {
         // Очищаем camListComboBox
         comboBox.DataSource = null;
         comboBox.Items.Clear();
         // Забиваем значения в camListComboBox
         comboBox.DataSource = Enum.GetValues(typeof(T));

         if (comboBox.Items.Count > 0) comboBox.SelectedIndex = 0;
      }

      public static T GetComboBoxEnum<T>(ComboBox cmbx)
      {
         T selectedEnum = (T)cmbx.SelectedItem;

         return selectedEnum;
      }

      /// <summary>
      /// Устанавливает новое значение в комбобокс.
      /// Инициализирует комбобокс если он пустой или значение первого элемента не соответствует первому элементу Enum
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="cmbx"></param>
      /// <param name="val"></param>
      public static void SetComboBoxEnumValue<T>(ComboBox cmbx, T val)
      {
         var curentEnumInComboBox = Enum.GetValues(typeof(T)).GetValue(0).ToString();
         var firstItem = cmbx.Items == null || cmbx.Items.Count == 0 ? "" : cmbx.Items[0].ToString();

         if (cmbx.Items.Count < 1 || !curentEnumInComboBox.Equals(firstItem))
         {
            Initialize<T>(cmbx);
         }

         cmbx.SelectedItem = val;
      }

      #endregion



      public static void SetSelectedValue(ComboBox cbx, string selectedValue)
      {
         cbx.SelectedItem = selectedValue;
      }

      /// <summary>
      /// Получаем значение из комбо бокса, если комбо представлен в виде Enum
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="cbx"></param>
      /// <returns></returns>
      public static T GetComboBoxValue<T>(ComboBox cmbx)
      {
         var tempVar = (T)Enum.Parse(typeof(T), cmbx.SelectedItem.ToString());
         return tempVar;
      }

      // ПРИМЕНЕНИЕ  var result = MyComboBox.GetComboBoxValue((ComboBox)sender);
      public static string GetComboBoxValue(ComboBox cbx)
      {
         var resultString = cbx?.SelectedItem != null ? cbx?.SelectedItem?.ToString() : "";
         return resultString;
      }
   }
}
