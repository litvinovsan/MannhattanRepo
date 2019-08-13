using System.ComponentModel;
using System.Windows.Forms;

namespace PBase
{
   partial class MainForm
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
         this.label1 = new System.Windows.Forms.Label();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.конфигурацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label_Time = new System.Windows.Forms.Label();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label_tren_zal = new System.Windows.Forms.Label();
         this.label_personal = new System.Windows.Forms.Label();
         this.label_group = new System.Windows.Forms.Label();
         this.listView_Tren_Zal = new System.Windows.Forms.ListView();
         this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.добавитьКлиентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.удалитьКлиентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.конфигураторОтчетовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.продатьАбонементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.руководительToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.label4 = new System.Windows.Forms.Label();
         this.comboBox_BDay = new System.Windows.Forms.ComboBox();
         this.menuStrip1.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label1.Location = new System.Drawing.Point(64, 53);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(0, 25);
         this.label1.TabIndex = 1;
         // 
         // menuStrip1
         // 
         this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
         this.menuStrip1.ImageScalingSize = new System.Drawing.Size(19, 19);
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.конфигурацииToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.toolStripComboBox1});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
         this.menuStrip1.Size = new System.Drawing.Size(1026, 30);
         this.menuStrip1.TabIndex = 2;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // конфигурацииToolStripMenuItem
         // 
         this.конфигурацииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.руководительToolStripMenuItem1,
            this.настройкиToolStripMenuItem,
            this.выходToolStripMenuItem});
         this.конфигурацииToolStripMenuItem.Name = "конфигурацииToolStripMenuItem";
         this.конфигурацииToolStripMenuItem.Size = new System.Drawing.Size(60, 28);
         this.конфигурацииToolStripMenuItem.Text = "Меню";
         // 
         // настройкиToolStripMenuItem
         // 
         this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
         this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
         this.настройкиToolStripMenuItem.Text = "Настройки";
         this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
         // 
         // выходToolStripMenuItem
         // 
         this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
         this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
         this.выходToolStripMenuItem.Text = "Выход";
         this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
         // 
         // toolStripComboBox1
         // 
         this.toolStripComboBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.toolStripComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
         this.toolStripComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
         this.toolStripComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.toolStripComboBox1.DropDownWidth = 200;
         this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.toolStripComboBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
         this.toolStripComboBox1.IntegralHeight = false;
         this.toolStripComboBox1.Name = "toolStripComboBox1";
         this.toolStripComboBox1.Size = new System.Drawing.Size(400, 28);
         this.toolStripComboBox1.Sorted = true;
         this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.comboBox_BDay);
         this.groupBox1.Controls.Add(this.label_Time);
         this.groupBox1.Controls.Add(this.textBox2);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.monthCalendar1);
         this.groupBox1.Controls.Add(this.textBox1);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.groupBox1.Location = new System.Drawing.Point(836, 46);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(178, 410);
         this.groupBox1.TabIndex = 3;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Сейчас:";
         // 
         // label_Time
         // 
         this.label_Time.AutoSize = true;
         this.label_Time.Font = new System.Drawing.Font("Comic Sans MS", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label_Time.ForeColor = System.Drawing.Color.Navy;
         this.label_Time.Location = new System.Drawing.Point(27, 16);
         this.label_Time.Name = "label_Time";
         this.label_Time.Size = new System.Drawing.Size(140, 42);
         this.label_Time.TabIndex = 5;
         this.label_Time.Text = "15:25:00";
         // 
         // textBox2
         // 
         this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox2.Location = new System.Drawing.Point(6, 161);
         this.textBox2.Name = "textBox2";
         this.textBox2.Size = new System.Drawing.Size(161, 23);
         this.textBox2.TabIndex = 4;
         this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label3
         // 
         this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(6, 145);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(132, 17);
         this.label3.TabIndex = 3;
         this.label3.Text = "Клиентов за День:";
         // 
         // monthCalendar1
         // 
         this.monthCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.monthCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.monthCalendar1.Location = new System.Drawing.Point(6, 242);
         this.monthCalendar1.Name = "monthCalendar1";
         this.monthCalendar1.TabIndex = 2;
         // 
         // textBox1
         // 
         this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox1.Location = new System.Drawing.Point(6, 207);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(161, 23);
         this.textBox1.TabIndex = 1;
         this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label2
         // 
         this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(6, 187);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(126, 17);
         this.label2.TabIndex = 0;
         this.label2.Text = "Клиентов в Базе: ";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
         this.tableLayoutPanel1.ColumnCount = 3;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.Controls.Add(this.label_tren_zal, 2, 0);
         this.tableLayoutPanel1.Controls.Add(this.label_personal, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.label_group, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.listView_Tren_Zal, 2, 1);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 53);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(808, 403);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // label_tren_zal
         // 
         this.label_tren_zal.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label_tren_zal.AutoSize = true;
         this.label_tren_zal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label_tren_zal.Location = new System.Drawing.Point(608, 9);
         this.label_tren_zal.Name = "label_tren_zal";
         this.label_tren_zal.Size = new System.Drawing.Size(127, 17);
         this.label_tren_zal.TabIndex = 3;
         this.label_tren_zal.Text = "Тренажерный зал";
         // 
         // label_personal
         // 
         this.label_personal.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label_personal.AutoSize = true;
         this.label_personal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label_personal.Location = new System.Drawing.Point(350, 9);
         this.label_personal.Name = "label_personal";
         this.label_personal.Size = new System.Drawing.Size(106, 17);
         this.label_personal.TabIndex = 2;
         this.label_personal.Text = "Персональные";
         // 
         // label_group
         // 
         this.label_group.Anchor = System.Windows.Forms.AnchorStyles.None;
         this.label_group.AutoSize = true;
         this.label_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label_group.Location = new System.Drawing.Point(107, 9);
         this.label_group.Name = "label_group";
         this.label_group.Size = new System.Drawing.Size(57, 17);
         this.label_group.TabIndex = 1;
         this.label_group.Text = "Группы";
         this.label_group.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // listView_Tren_Zal
         // 
         this.listView_Tren_Zal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listView_Tren_Zal.Location = new System.Drawing.Point(542, 38);
         this.listView_Tren_Zal.Name = "listView_Tren_Zal";
         this.listView_Tren_Zal.Size = new System.Drawing.Size(260, 359);
         this.listView_Tren_Zal.TabIndex = 2;
         this.listView_Tren_Zal.UseCompatibleStateImageBehavior = false;
         // 
         // клиентыToolStripMenuItem
         // 
         this.клиентыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.продатьАбонементToolStripMenuItem,
            this.добавитьКлиентаToolStripMenuItem,
            this.удалитьКлиентаToolStripMenuItem});
         this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
         this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(75, 28);
         this.клиентыToolStripMenuItem.Text = "Клиенты";
         // 
         // добавитьКлиентаToolStripMenuItem
         // 
         this.добавитьКлиентаToolStripMenuItem.Name = "добавитьКлиентаToolStripMenuItem";
         this.добавитьКлиентаToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
         this.добавитьКлиентаToolStripMenuItem.Text = "Добавить Клиента";
         this.добавитьКлиентаToolStripMenuItem.Click += new System.EventHandler(this.добавитьКлиентаToolStripMenuItem_Click);
         // 
         // удалитьКлиентаToolStripMenuItem
         // 
         this.удалитьКлиентаToolStripMenuItem.Name = "удалитьКлиентаToolStripMenuItem";
         this.удалитьКлиентаToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
         this.удалитьКлиентаToolStripMenuItem.Text = "Удалить Клиента";
         // 
         // отчетыToolStripMenuItem
         // 
         this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.конфигураторОтчетовToolStripMenuItem});
         this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
         this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(69, 28);
         this.отчетыToolStripMenuItem.Text = "Отчеты";
         // 
         // конфигураторОтчетовToolStripMenuItem
         // 
         this.конфигураторОтчетовToolStripMenuItem.Name = "конфигураторОтчетовToolStripMenuItem";
         this.конфигураторОтчетовToolStripMenuItem.Size = new System.Drawing.Size(226, 24);
         this.конфигураторОтчетовToolStripMenuItem.Text = "Конфигуратор Отчетов";
         this.конфигураторОтчетовToolStripMenuItem.Click += new System.EventHandler(this.конфигураторОтчетовToolStripMenuItem_Click);
         // 
         // продатьАбонементToolStripMenuItem
         // 
         this.продатьАбонементToolStripMenuItem.Name = "продатьАбонементToolStripMenuItem";
         this.продатьАбонементToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
         this.продатьАбонементToolStripMenuItem.Text = "Продать Абонемент";
         // 
         // руководительToolStripMenuItem1
         // 
         this.руководительToolStripMenuItem1.Name = "руководительToolStripMenuItem1";
         this.руководительToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
         this.руководительToolStripMenuItem1.Text = "Руководитель";
         this.руководительToolStripMenuItem1.Click += new System.EventHandler(this.руководительToolStripMenuItem1_Click);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(6, 73);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(116, 17);
         this.label4.TabIndex = 3;
         this.label4.Text = "День Рождения:";
         // 
         // comboBox_BDay
         // 
         this.comboBox_BDay.DropDownWidth = 200;
         this.comboBox_BDay.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.comboBox_BDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_BDay.FormattingEnabled = true;
         this.comboBox_BDay.Location = new System.Drawing.Point(6, 94);
         this.comboBox_BDay.Name = "comboBox_BDay";
         this.comboBox_BDay.Size = new System.Drawing.Size(161, 24);
         this.comboBox_BDay.Sorted = true;
         this.comboBox_BDay.TabIndex = 6;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1026, 468);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.menuStrip1);
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.MainMenuStrip = this.menuStrip1;
         this.MinimumSize = new System.Drawing.Size(1027, 507);
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Manhattan";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Label label1;
      private MenuStrip menuStrip1;
      private ToolStripMenuItem конфигурацииToolStripMenuItem;
      private ToolStripMenuItem выходToolStripMenuItem;
      private TableLayoutPanel tableLayoutPanel1;
      private ListView listView_Tren_Zal;
      private Label label_tren_zal;
      private Label label_personal;
      private Label label_group;
      private ToolStripMenuItem настройкиToolStripMenuItem;
      private TextBox textBox1;
      private Label label2;
        private ToolStripComboBox toolStripComboBox1;
      private MonthCalendar monthCalendar1;
      private GroupBox groupBox1;
      private Label label_Time;
      private TextBox textBox2;
      private Label label3;
      private ToolStripMenuItem клиентыToolStripMenuItem;
      private ToolStripMenuItem добавитьКлиентаToolStripMenuItem;
      private ToolStripMenuItem удалитьКлиентаToolStripMenuItem;
      private ToolStripMenuItem отчетыToolStripMenuItem;
      private ToolStripMenuItem конфигураторОтчетовToolStripMenuItem;
      private ToolStripMenuItem руководительToolStripMenuItem1;
      private ToolStripMenuItem продатьАбонементToolStripMenuItem;
      private ComboBox comboBox_BDay;
      private Label label4;
   }
}