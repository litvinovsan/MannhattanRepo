using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBase;

namespace PersonsBase.View
{
    public partial class CreatePersonForm : Form
    {
        #region /// ПОЛЯ ///

        private static Person _person;


        #endregion

        #region /// КОНСТРУКТОРЫ ///

        public CreatePersonForm()
        {
            InitializeComponent();
            
        }

        #endregion

        #region /// МЕТОДЫ ///

        public string GetName()
        {
            return _person.Name;
        }

        #endregion

        private void button_Add_New_Person_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
        }
    }
}
