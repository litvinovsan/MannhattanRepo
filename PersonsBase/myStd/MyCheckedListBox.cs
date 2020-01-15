using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonsBase.myStd
{
    public static class MyCheckedListBox
    {

        public static void SetAllItemsChecked(CheckedListBox checkedListBox, bool isChecked)
        {
            if (checkedListBox == null) return;
            for (var i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, isChecked);
            }
        }

        public static void ClearSelection(CheckedListBox listBox)
        {
            var ind = listBox.SelectedIndices;
            foreach (var item in ind)
            {
                listBox.SetSelected((int)item, false);
            }
        }

        public static bool IsChecked(CheckedListBox listBox, int id)
        {
            return listBox.GetItemCheckState(id) == CheckState.Checked;
        }
    }
}
