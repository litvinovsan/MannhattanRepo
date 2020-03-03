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

        private static void InitializeTemp(ComboBox comboBox, List<KeyValuePair<int, string>> dataList)
        {
            // Очищаем camListComboBox
            comboBox.DataSource = null;
            comboBox.Items.Clear();
            // Забиваем значения в camListComboBox
            comboBox.DataSource = new BindingSource(dataList, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
            if (comboBox.Items.Count > 0) comboBox.SelectedIndex = 0;
        }
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
