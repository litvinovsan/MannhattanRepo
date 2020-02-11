using System.ComponentModel;
using System.Windows.Forms;

namespace PersonsBase.View
{
   partial class NumWorkoutForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox_num = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_aerob = new System.Windows.Forms.RadioButton();
            this.radioButton_personal = new System.Windows.Forms.RadioButton();
            this.radioButton_mini = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(141, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(261, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox_num
            // 
            this.comboBox_num.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_num.FormattingEnabled = true;
            this.comboBox_num.Location = new System.Drawing.Point(11, 30);
            this.comboBox_num.Name = "comboBox_num";
            this.comboBox_num.Size = new System.Drawing.Size(137, 28);
            this.comboBox_num.TabIndex = 0;
            this.comboBox_num.SelectedIndexChanged += new System.EventHandler(this.comboBox_num_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_num);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(187, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 78);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Количество";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_mini);
            this.groupBox2.Controls.Add(this.radioButton_aerob);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.radioButton_personal);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 115);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // radioButton_aerob
            // 
            this.radioButton_aerob.AutoSize = true;
            this.radioButton_aerob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_aerob.Location = new System.Drawing.Point(15, 47);
            this.radioButton_aerob.Name = "radioButton_aerob";
            this.radioButton_aerob.Size = new System.Drawing.Size(101, 24);
            this.radioButton_aerob.TabIndex = 1;
            this.radioButton_aerob.Text = "Аэробная";
            this.radioButton_aerob.UseVisualStyleBackColor = true;
            this.radioButton_aerob.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton_personal
            // 
            this.radioButton_personal.AutoSize = true;
            this.radioButton_personal.Checked = true;
            this.radioButton_personal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_personal.Location = new System.Drawing.Point(15, 17);
            this.radioButton_personal.Name = "radioButton_personal";
            this.radioButton_personal.Size = new System.Drawing.Size(138, 24);
            this.radioButton_personal.TabIndex = 0;
            this.radioButton_personal.TabStop = true;
            this.radioButton_personal.Text = "Персональная";
            this.radioButton_personal.UseVisualStyleBackColor = true;
            this.radioButton_personal.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton_mini
            // 
            this.radioButton_mini.AutoSize = true;
            this.radioButton_mini.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_mini.Location = new System.Drawing.Point(15, 77);
            this.radioButton_mini.Name = "radioButton_mini";
            this.radioButton_mini.Size = new System.Drawing.Size(119, 24);
            this.radioButton_mini.TabIndex = 6;
            this.radioButton_mini.Text = "Минигруппы";
            this.radioButton_mini.UseVisualStyleBackColor = true;
            this.radioButton_mini.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // NumWorkoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 185);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(397, 210);
            this.Name = "NumWorkoutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить Тренировки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

      }

      #endregion
      private ComboBox comboBox_num;
      private Button button1;
      private Button button2;
      private GroupBox groupBox1;
      private GroupBox groupBox2;
      private RadioButton radioButton_personal;
      private RadioButton radioButton_aerob;
        private RadioButton radioButton_mini;
    }
}