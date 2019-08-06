using System.ComponentModel;
using System.Windows.Forms;

namespace PersonsBase.View
{
   partial class PwdForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.textBox_pwd = new System.Windows.Forms.TextBox();
         this.button_Cancel = new System.Windows.Forms.Button();
         this.button_Ok = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // textBox_pwd
         // 
         this.textBox_pwd.Location = new System.Drawing.Point(74, 19);
         this.textBox_pwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.textBox_pwd.Name = "textBox_pwd";
         this.textBox_pwd.PasswordChar = '*';
         this.textBox_pwd.Size = new System.Drawing.Size(153, 20);
         this.textBox_pwd.TabIndex = 5;
         this.textBox_pwd.UseSystemPasswordChar = true;
         this.textBox_pwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_pwd_KeyPress);
         // 
         // button_Cancel
         // 
         this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button_Cancel.Location = new System.Drawing.Point(131, 56);
         this.button_Cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.button_Cancel.Name = "button_Cancel";
         this.button_Cancel.Size = new System.Drawing.Size(96, 28);
         this.button_Cancel.TabIndex = 7;
         this.button_Cancel.Text = "Отмена";
         this.button_Cancel.UseVisualStyleBackColor = true;
         this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
         // 
         // button_Ok
         // 
         this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button_Ok.Location = new System.Drawing.Point(11, 56);
         this.button_Ok.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.button_Ok.Name = "button_Ok";
         this.button_Ok.Size = new System.Drawing.Size(96, 28);
         this.button_Ok.TabIndex = 6;
         this.button_Ok.Text = "Ок";
         this.button_Ok.UseVisualStyleBackColor = true;
         this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label1.Location = new System.Drawing.Point(9, 19);
         this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(61, 17);
         this.label1.TabIndex = 4;
         this.label1.Text = "Пароль:";
         // 
         // PwdForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(243, 100);
         this.Controls.Add(this.textBox_pwd);
         this.Controls.Add(this.button_Cancel);
         this.Controls.Add(this.button_Ok);
         this.Controls.Add(this.label1);
         this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(259, 159);
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(259, 139);
         this.Name = "PwdForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Доступ Администратора";
         this.Load += new System.EventHandler(this.PwdForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private TextBox textBox_pwd;
      private Button button_Cancel;
      private Button button_Ok;
      private Label label1;
   }
}