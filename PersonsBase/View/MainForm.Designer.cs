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
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPage_Visit = new System.Windows.Forms.TabPage();
         this.panel1 = new System.Windows.Forms.Panel();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label_tren_zal = new System.Windows.Forms.Label();
         this.label_personal = new System.Windows.Forms.Label();
         this.label_group = new System.Windows.Forms.Label();
         this.listView_Tren_Zal = new System.Windows.Forms.ListView();
         this.tabPage_Abonements = new System.Windows.Forms.TabPage();
         this.button2 = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.tabPage_Otchet = new System.Windows.Forms.TabPage();
         this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label3 = new System.Windows.Forms.Label();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.label_Time = new System.Windows.Forms.Label();
         this.menuStrip1.SuspendLayout();
         this.tabControl1.SuspendLayout();
         this.tabPage_Visit.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.tabPage_Abonements.SuspendLayout();
         this.groupBox1.SuspendLayout();
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
         this.menuStrip1.ImageScalingSize = new System.Drawing.Size(19, 19);
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.конфигурацииToolStripMenuItem,
            this.toolStripComboBox1});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
         this.menuStrip1.Size = new System.Drawing.Size(1042, 30);
         this.menuStrip1.TabIndex = 2;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // конфигурацииToolStripMenuItem
         // 
         this.конфигурацииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.выходToolStripMenuItem});
         this.конфигурацииToolStripMenuItem.Name = "конфигурацииToolStripMenuItem";
         this.конфигурацииToolStripMenuItem.Size = new System.Drawing.Size(57, 28);
         this.конфигурацииToolStripMenuItem.Text = "Меню";
         // 
         // настройкиToolStripMenuItem
         // 
         this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
         this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
         this.настройкиToolStripMenuItem.Text = "Настройки";
         // 
         // выходToolStripMenuItem
         // 
         this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
         this.выходToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
         this.выходToolStripMenuItem.Text = "Выход";
         this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
         // 
         // toolStripComboBox1
         // 
         this.toolStripComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
         this.toolStripComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
         this.toolStripComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.toolStripComboBox1.DropDownWidth = 200;
         this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.toolStripComboBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
         this.toolStripComboBox1.IntegralHeight = false;
         this.toolStripComboBox1.Name = "toolStripComboBox1";
         this.toolStripComboBox1.Size = new System.Drawing.Size(300, 28);
         this.toolStripComboBox1.Sorted = true;
         this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
         // 
         // tabControl1
         // 
         this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControl1.Controls.Add(this.tabPage_Visit);
         this.tabControl1.Controls.Add(this.tabPage_Abonements);
         this.tabControl1.Controls.Add(this.tabPage_Otchet);
         this.tabControl1.Location = new System.Drawing.Point(12, 37);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(1025, 522);
         this.tabControl1.TabIndex = 3;
         // 
         // tabPage_Visit
         // 
         this.tabPage_Visit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.tabPage_Visit.Controls.Add(this.groupBox1);
         this.tabPage_Visit.Controls.Add(this.panel1);
         this.tabPage_Visit.Controls.Add(this.tableLayoutPanel1);
         this.tabPage_Visit.Location = new System.Drawing.Point(4, 22);
         this.tabPage_Visit.Name = "tabPage_Visit";
         this.tabPage_Visit.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage_Visit.Size = new System.Drawing.Size(1017, 496);
         this.tabPage_Visit.TabIndex = 0;
         this.tabPage_Visit.Text = "Посещение";
         this.tabPage_Visit.UseVisualStyleBackColor = true;
         // 
         // panel1
         // 
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(3, 448);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(1007, 41);
         this.panel1.TabIndex = 1;
         // 
         // textBox1
         // 
         this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.textBox1.Location = new System.Drawing.Point(6, 97);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(161, 20);
         this.textBox1.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(6, 81);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(98, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Клиентов в Базе: ";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.AutoSize = true;
         this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
         this.tableLayoutPanel1.ColumnCount = 3;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel1.Controls.Add(this.label_tren_zal, 2, 0);
         this.tableLayoutPanel1.Controls.Add(this.label_personal, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.label_group, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.listView_Tren_Zal, 2, 1);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(802, 417);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // label_tren_zal
         // 
         this.label_tren_zal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.label_tren_zal.AutoSize = true;
         this.label_tren_zal.Location = new System.Drawing.Point(538, 3);
         this.label_tren_zal.Name = "label_tren_zal";
         this.label_tren_zal.Size = new System.Drawing.Size(258, 13);
         this.label_tren_zal.TabIndex = 3;
         this.label_tren_zal.Text = "Тренажерный зал";
         // 
         // label_personal
         // 
         this.label_personal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.label_personal.AutoSize = true;
         this.label_personal.Location = new System.Drawing.Point(272, 3);
         this.label_personal.Name = "label_personal";
         this.label_personal.Size = new System.Drawing.Size(257, 13);
         this.label_personal.TabIndex = 2;
         this.label_personal.Text = "Персональные";
         // 
         // label_group
         // 
         this.label_group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.label_group.AutoSize = true;
         this.label_group.Location = new System.Drawing.Point(6, 3);
         this.label_group.Name = "label_group";
         this.label_group.Size = new System.Drawing.Size(257, 13);
         this.label_group.TabIndex = 1;
         this.label_group.Text = "Группы";
         // 
         // listView_Tren_Zal
         // 
         this.listView_Tren_Zal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listView_Tren_Zal.Location = new System.Drawing.Point(538, 29);
         this.listView_Tren_Zal.Name = "listView_Tren_Zal";
         this.listView_Tren_Zal.Size = new System.Drawing.Size(258, 382);
         this.listView_Tren_Zal.TabIndex = 2;
         this.listView_Tren_Zal.UseCompatibleStateImageBehavior = false;
         // 
         // tabPage_Abonements
         // 
         this.tabPage_Abonements.Controls.Add(this.button2);
         this.tabPage_Abonements.Controls.Add(this.button1);
         this.tabPage_Abonements.Location = new System.Drawing.Point(4, 22);
         this.tabPage_Abonements.Name = "tabPage_Abonements";
         this.tabPage_Abonements.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage_Abonements.Size = new System.Drawing.Size(711, 375);
         this.tabPage_Abonements.TabIndex = 2;
         this.tabPage_Abonements.Text = "Абонементы";
         this.tabPage_Abonements.UseVisualStyleBackColor = true;
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(6, 41);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(196, 23);
         this.button2.TabIndex = 1;
         this.button2.Text = "button2";
         this.button2.UseVisualStyleBackColor = true;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(6, 12);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(196, 23);
         this.button1.TabIndex = 0;
         this.button1.Text = "Добавить Клиента";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click_1);
         // 
         // tabPage_Otchet
         // 
         this.tabPage_Otchet.Location = new System.Drawing.Point(4, 22);
         this.tabPage_Otchet.Name = "tabPage_Otchet";
         this.tabPage_Otchet.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage_Otchet.Size = new System.Drawing.Size(711, 375);
         this.tabPage_Otchet.TabIndex = 1;
         this.tabPage_Otchet.Text = "Отчеты";
         this.tabPage_Otchet.UseVisualStyleBackColor = true;
         // 
         // monthCalendar1
         // 
         this.monthCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.monthCalendar1.Location = new System.Drawing.Point(6, 240);
         this.monthCalendar1.Name = "monthCalendar1";
         this.monthCalendar1.TabIndex = 2;
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.label_Time);
         this.groupBox1.Controls.Add(this.textBox2);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.monthCalendar1);
         this.groupBox1.Controls.Add(this.textBox1);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Location = new System.Drawing.Point(829, 6);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(178, 414);
         this.groupBox1.TabIndex = 3;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Текущие данные";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(3, 132);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(133, 13);
         this.label3.TabIndex = 3;
         this.label3.Text = "Посетителей за Сегодня";
         // 
         // textBox2
         // 
         this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.textBox2.Location = new System.Drawing.Point(6, 148);
         this.textBox2.Name = "textBox2";
         this.textBox2.Size = new System.Drawing.Size(161, 20);
         this.textBox2.TabIndex = 4;
         // 
         // label_Time
         // 
         this.label_Time.AutoSize = true;
         this.label_Time.Font = new System.Drawing.Font("Comic Sans MS", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label_Time.ForeColor = System.Drawing.Color.Navy;
         this.label_Time.Location = new System.Drawing.Point(6, 26);
         this.label_Time.Name = "label_Time";
         this.label_Time.Size = new System.Drawing.Size(140, 42);
         this.label_Time.TabIndex = 5;
         this.label_Time.Text = "15:25:00";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1042, 562);
         this.Controls.Add(this.tabControl1);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.menuStrip1);
         this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.MainMenuStrip = this.menuStrip1;
         this.MinimumSize = new System.Drawing.Size(687, 348);
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.tabControl1.ResumeLayout(false);
         this.tabPage_Visit.ResumeLayout(false);
         this.tabPage_Visit.PerformLayout();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.tabPage_Abonements.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Label label1;
      private MenuStrip menuStrip1;
      private ToolStripMenuItem конфигурацииToolStripMenuItem;
      private ToolStripMenuItem выходToolStripMenuItem;
      private TabControl tabControl1;
      private TabPage tabPage_Visit;
      private TabPage tabPage_Abonements;
      private TabPage tabPage_Otchet;
      private TableLayoutPanel tableLayoutPanel1;
      private ListView listView_Tren_Zal;
      private Label label_tren_zal;
      private Label label_personal;
      private Label label_group;
      private Button button1;
      private ToolStripMenuItem настройкиToolStripMenuItem;
      private Panel panel1;
      private TextBox textBox1;
      private Label label2;
      private Button button2;
        private ToolStripComboBox toolStripComboBox1;
      private MonthCalendar monthCalendar1;
      private GroupBox groupBox1;
      private Label label_Time;
      private TextBox textBox2;
      private Label label3;
   }
}