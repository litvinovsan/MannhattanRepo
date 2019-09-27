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
    public partial class SelectPersonForm : Form
    {
        #region /// ОСНОВНЫЕ ОБЬЕКТЫ ///
        private string _name;

        #endregion

        #region /// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ///
        public SelectPersonForm()
        {
            InitializeComponent();
        }

        #endregion

        #region /// МЕТОДЫ ///

        public string GetName()
        {
            return _name;
        }

        #endregion

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
