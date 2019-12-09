using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonsBase.View
{
    public partial class BarCodeForm : Form
    {

        public BarCodeForm()
        {
            InitializeComponent();
        }

        private string _name = "qwqwqw";
        //        Парсинг строки в число
        //   Поиск в базе, если найден -возврат имени клиента
        // Ловить событие по текстововму полю. Сразу искать клиента. Если Ок возвращать  DialogResult.OK
        public string GetFindedName()
        {
            return _name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
