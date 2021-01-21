using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceApp.MyServiceLibrary;

namespace WcfServiceApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyServiceLibrary.ConnectServiceClient client = new ConnectServiceClient();

            string returnString;

            returnString = client.GetData(textBox1.Text);
            label1.Text = returnString;
        }
    }
}
