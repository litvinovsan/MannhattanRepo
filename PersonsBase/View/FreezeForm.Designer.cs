﻿namespace PersonsBase.View
{
   partial class FreezeForm
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
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.textBox_available = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.comboBox_toFreeze = new System.Windows.Forms.ComboBox();
         this.label_PeriodClubCard = new System.Windows.Forms.Label();
         this.buttonClearFreeze = new System.Windows.Forms.Button();
         this.textBox_totalDays = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button1.Location = new System.Drawing.Point(15, 265);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(149, 34);
         this.button1.TabIndex = 0;
         this.button1.Text = "Заморозить";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // button2
         // 
         this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button2.Location = new System.Drawing.Point(190, 265);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(150, 34);
         this.button2.TabIndex = 1;
         this.button2.Text = "Отмена";
         this.button2.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label1.Location = new System.Drawing.Point(12, 102);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(112, 17);
         this.label1.TabIndex = 3;
         this.label1.Text = "Доступно дней:";
         // 
         // label2
         // 
         this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(271, 77);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(0, 13);
         this.label2.TabIndex = 4;
         // 
         // label3
         // 
         this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label3.Location = new System.Drawing.Point(12, 18);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(106, 17);
         this.label3.TabIndex = 5;
         this.label3.Text = "Клубная карта";
         // 
         // textBox_available
         // 
         this.textBox_available.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBox_available.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox_available.Location = new System.Drawing.Point(144, 99);
         this.textBox_available.Name = "textBox_available";
         this.textBox_available.ReadOnly = true;
         this.textBox_available.Size = new System.Drawing.Size(196, 23);
         this.textBox_available.TabIndex = 6;
         // 
         // label4
         // 
         this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label4.Location = new System.Drawing.Point(12, 141);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(111, 17);
         this.label4.TabIndex = 7;
         this.label4.Text = "Заморозить на:";
         // 
         // comboBox_toFreeze
         // 
         this.comboBox_toFreeze.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBox_toFreeze.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_toFreeze.FormattingEnabled = true;
         this.comboBox_toFreeze.Location = new System.Drawing.Point(144, 136);
         this.comboBox_toFreeze.Name = "comboBox_toFreeze";
         this.comboBox_toFreeze.Size = new System.Drawing.Size(196, 24);
         this.comboBox_toFreeze.TabIndex = 8;
         // 
         // label_PeriodClubCard
         // 
         this.label_PeriodClubCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.label_PeriodClubCard.AutoSize = true;
         this.label_PeriodClubCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label_PeriodClubCard.Location = new System.Drawing.Point(141, 18);
         this.label_PeriodClubCard.Name = "label_PeriodClubCard";
         this.label_PeriodClubCard.Size = new System.Drawing.Size(105, 17);
         this.label_PeriodClubCard.TabIndex = 9;
         this.label_PeriodClubCard.Text = "На 11 месяцев";
         // 
         // buttonClearFreeze
         // 
         this.buttonClearFreeze.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonClearFreeze.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.buttonClearFreeze.Location = new System.Drawing.Point(15, 214);
         this.buttonClearFreeze.Name = "buttonClearFreeze";
         this.buttonClearFreeze.Size = new System.Drawing.Size(325, 32);
         this.buttonClearFreeze.TabIndex = 10;
         this.buttonClearFreeze.Text = "Сбросить Заморозку";
         this.buttonClearFreeze.UseVisualStyleBackColor = true;
         this.buttonClearFreeze.Visible = false;
         // 
         // textBox_totalDays
         // 
         this.textBox_totalDays.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBox_totalDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox_totalDays.Location = new System.Drawing.Point(144, 53);
         this.textBox_totalDays.Name = "textBox_totalDays";
         this.textBox_totalDays.ReadOnly = true;
         this.textBox_totalDays.Size = new System.Drawing.Size(196, 23);
         this.textBox_totalDays.TabIndex = 12;
         // 
         // label6
         // 
         this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label6.Location = new System.Drawing.Point(12, 60);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(85, 17);
         this.label6.TabIndex = 11;
         this.label6.Text = "Всего дней:";
         // 
         // label5
         // 
         this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label5.Location = new System.Drawing.Point(12, 178);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(125, 17);
         this.label5.TabIndex = 13;
         this.label5.Text = "Старт заморозки:";
         // 
         // dateTimePicker1
         // 
         this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.dateTimePicker1.Location = new System.Drawing.Point(144, 172);
         this.dateTimePicker1.Name = "dateTimePicker1";
         this.dateTimePicker1.Size = new System.Drawing.Size(196, 23);
         this.dateTimePicker1.TabIndex = 14;
         // 
         // FreezeForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(352, 311);
         this.Controls.Add(this.dateTimePicker1);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.textBox_totalDays);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.buttonClearFreeze);
         this.Controls.Add(this.label_PeriodClubCard);
         this.Controls.Add(this.comboBox_toFreeze);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.textBox_available);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.MaximizeBox = false;
         this.Name = "FreezeForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Заморозка";
         this.Load += new System.EventHandler(this.FreezeForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox textBox_available;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.ComboBox comboBox_toFreeze;
      private System.Windows.Forms.Label label_PeriodClubCard;
      private System.Windows.Forms.Button buttonClearFreeze;
      private System.Windows.Forms.TextBox textBox_totalDays;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.DateTimePicker dateTimePicker1;
   }
}