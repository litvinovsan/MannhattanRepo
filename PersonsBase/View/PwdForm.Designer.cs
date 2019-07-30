namespace PersonsBase.View
{
   partial class PwdForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

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
         this.textBox_pwd.Location = new System.Drawing.Point(16, 47);
         this.textBox_pwd.Name = "textBox_pwd";
         this.textBox_pwd.PasswordChar = '*';
         this.textBox_pwd.Size = new System.Drawing.Size(287, 22);
         this.textBox_pwd.TabIndex = 5;
         this.textBox_pwd.UseSystemPasswordChar = true;
         this.textBox_pwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_pwd_KeyPress);
         // 
         // button_Cancel
         // 
         this.button_Cancel.Location = new System.Drawing.Point(175, 94);
         this.button_Cancel.Name = "button_Cancel";
         this.button_Cancel.Size = new System.Drawing.Size(128, 35);
         this.button_Cancel.TabIndex = 7;
         this.button_Cancel.Text = "Отмена";
         this.button_Cancel.UseVisualStyleBackColor = true;
         this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
         // 
         // button_Ok
         // 
         this.button_Ok.Location = new System.Drawing.Point(16, 94);
         this.button_Ok.Name = "button_Ok";
         this.button_Ok.Size = new System.Drawing.Size(128, 35);
         this.button_Ok.TabIndex = 6;
         this.button_Ok.Text = "Ок";
         this.button_Ok.UseVisualStyleBackColor = true;
         this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(270, 20);
         this.label1.TabIndex = 4;
         this.label1.Text = "Введите пароль Администратора";
         // 
         // PwdForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(322, 143);
         this.Controls.Add(this.textBox_pwd);
         this.Controls.Add(this.button_Cancel);
         this.Controls.Add(this.button_Ok);
         this.Controls.Add(this.label1);
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(340, 187);
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(340, 187);
         this.Name = "PwdForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "PwdForm";
         this.Load += new System.EventHandler(this.PwdForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBox_pwd;
      private System.Windows.Forms.Button button_Cancel;
      private System.Windows.Forms.Button button_Ok;
      private System.Windows.Forms.Label label1;
   }
}