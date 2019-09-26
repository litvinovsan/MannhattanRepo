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
        private string _name;
        public SelectPersonForm()
        {
            InitializeComponent();
        }

        public string GetName()
        {
            return _name;
        }
    }
}
