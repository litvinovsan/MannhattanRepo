using System;
using System.Drawing;
using System.Windows.Forms;
using PBase;

namespace PersonsBase.View
{
   public partial class PwdForm : Form
   {
      private readonly Options _options;
      public PwdForm(Options opt)
      {
         InitializeComponent();
         _options = opt;
      }

      private void PwdForm_Load(object sender, EventArgs e)
      {
         SelectNextControl(textBox_pwd, false, true, true, false);
      }

      private void button_Ok_Click(object sender, EventArgs e)
      {
         CkeckPwd();
      }

      private bool CkeckPwd()
      {
         if (_options.CheckPassword(textBox_pwd.Text))
         {
            _options.IsPasswordValid = true;

            label1.ForeColor = Color.Black;
            label1.Text = @"Введите пароль Администратора";
            Close();
            return true;
         }
         else
         {
            label1.ForeColor = Color.Red;
            label1.Text = @"Неправильный пароль";
            _options.IsPasswordValid = false;
            return false;
         }
      }

      private void button_Cancel_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void textBox_pwd_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == (char)Keys.Return) // Если нажат Enter
         {
            CkeckPwd();
         }
      }
   }
}
