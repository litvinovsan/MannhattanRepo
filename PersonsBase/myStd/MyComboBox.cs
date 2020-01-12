using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static void SetComboBoxValue(ComboBox cbx, string selectedValue)
        {
            cbx.SelectedItem = selectedValue;
        }

        /// <summary>
        /// Получаем значение из комбо бокса, если комбо представлен в виде Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cbx"></param>
        /// <returns></returns>
        public static T GetComboBoxValue<T>(ComboBox cbx)
        {
            var val = (T)Enum.Parse(typeof(T), cbx.SelectedItem.ToString());
            return val;
        }

        // ПРИМЕНЕНИЕ  var result = MyComboBox.GetComboBoxValue((ComboBox)sender);
        public static string GetComboBoxValue(ComboBox cbx)
        {

            var resultString = cbx.SelectedItem != null ? cbx.SelectedItem.ToString() : "";
            return resultString;
        }
    }
}
