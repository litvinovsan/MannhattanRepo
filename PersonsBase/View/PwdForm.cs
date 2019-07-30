using PBase;
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
   public partial class PwdForm : Form
   {
      private Options _options;
      private string _passwordToCheck; // Пароль суперпользователя
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

      private void CkeckPwd()
      { Не работает пароль.passwordRootString null
         if (_options.CheckPassword(textBox_pwd.Text))
         {
            _options.IsPasswordValid = true;
    
            label1.ForeColor = Color.Black;
            label1.Text = "Введите пароль Администратора";
            this.Close();
         }
         else
         {
            label1.ForeColor = Color.Red;
            label1.Text = "Неправильный пароль";
            _options.IsPasswordValid = false;
         }
      }

      private void button_Cancel_Click(object sender, EventArgs e)
      {
         this.Close();
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
