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
        public static void Initialize(ComboBox comboBox,object[] items,object selItem)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items); // Обновляем комбобокс
            comboBox.SelectedItem = selItem;
        }

    }
}
