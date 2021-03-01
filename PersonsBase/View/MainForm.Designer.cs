using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.myStd;
using PersonsBase.Properties;

namespace PersonsBase.View
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.конфигурацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководительToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.администраторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьКлиентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.продатьАбонементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьКлиентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сomboBox_PersonsList = new System.Windows.Forms.ToolStripComboBox();
            this.сканироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_Reset_Date = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_Total_persons = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_PeopleForDay = new System.Windows.Forms.Label();
            this.comboBox_BDay = new System.Windows.Forms.ComboBox();
            this.label_Time = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView_MiniGroup = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_Gym_Zal = new System.Windows.Forms.ListView();
            this.column_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Persons = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_Personal = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_Group = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_group = new System.Windows.Forms.Label();
            this.label_personal = new System.Windows.Forms.Label();
            this.label_tren_zal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.открытьКарточкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_SelectedDate = new System.Windows.Forms.Label();
            this.maskedTextBox_PhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.импортИзExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.администраторыToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.сomboBox_PersonsList,
            this.сканироватьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1292, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // конфигурацииToolStripMenuItem
            // 
            this.конфигурацииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.руководительToolStripMenuItem1,
            this.сохранитьВExcelToolStripMenuItem,
            this.импортИзExcelToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.конфигурацииToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("конфигурацииToolStripMenuItem.Image")));
            this.конфигурацииToolStripMenuItem.Name = "конфигурацииToolStripMenuItem";
            this.конфигурацииToolStripMenuItem.Size = new System.Drawing.Size(79, 28);
            this.конфигурацииToolStripMenuItem.Text = "Меню";
            // 
            // руководительToolStripMenuItem1
            // 
            this.руководительToolStripMenuItem1.Name = "руководительToolStripMenuItem1";
            this.руководительToolStripMenuItem1.Size = new System.Drawing.Size(183, 26);
            this.руководительToolStripMenuItem1.Text = "Руководитель";
            this.руководительToolStripMenuItem1.Click += new System.EventHandler(this.руководительToolStripMenuItem1_Click);
            // 
            // сохранитьВExcelToolStripMenuItem
            // 
            this.сохранитьВExcelToolStripMenuItem.Image = global::PersonsBase.Properties.Resources.diskette;
            this.сохранитьВExcelToolStripMenuItem.Name = "сохранитьВExcelToolStripMenuItem";
            this.сохранитьВExcelToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.сохранитьВExcelToolStripMenuItem.Text = "Сохранить Базу";
            this.сохранитьВExcelToolStripMenuItem.Click += new System.EventHandler(this.сохранитьВExcelToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = global::PersonsBase.Properties.Resources.exit;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // администраторыToolStripMenuItem
            // 
            this.администраторыToolStripMenuItem.Image = global::PersonsBase.Properties.Resources.arrow;
            this.администраторыToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.администраторыToolStripMenuItem.Name = "администраторыToolStripMenuItem";
            this.администраторыToolStripMenuItem.Size = new System.Drawing.Size(150, 28);
            this.администраторыToolStripMenuItem.Text = "Администраторы";
            this.администраторыToolStripMenuItem.Click += new System.EventHandler(this.администраторыToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьКлиентаToolStripMenuItem,
            this.списокКлиентовToolStripMenuItem,
            this.продатьАбонементToolStripMenuItem,
            this.удалитьКлиентаToolStripMenuItem});
            this.клиентыToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("клиентыToolStripMenuItem.Image")));
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.клиентыToolStripMenuItem.Text = "Клиент";
            // 
            // добавитьКлиентаToolStripMenuItem
            // 
            this.добавитьКлиентаToolStripMenuItem.Image = global::PersonsBase.Properties.Resources.edit_add;
            this.добавитьКлиентаToolStripMenuItem.Name = "добавитьКлиентаToolStripMenuItem";
            this.добавитьКлиентаToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.добавитьКлиентаToolStripMenuItem.Text = "Добавить Клиента";
            this.добавитьКлиентаToolStripMenuItem.Click += new System.EventHandler(this.добавитьКлиентаToolStripMenuItem_Click);
            // 
            // списокКлиентовToolStripMenuItem
            // 
            this.списокКлиентовToolStripMenuItem.Image = global::PersonsBase.Properties.Resources.list_all_participants;
            this.списокКлиентовToolStripMenuItem.Name = "списокКлиентовToolStripMenuItem";
            this.списокКлиентовToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.списокКлиентовToolStripMenuItem.Text = "Список Клиентов";
            this.списокКлиентовToolStripMenuItem.Click += new System.EventHandler(this.списокКлиентовToolStripMenuItem_Click);
            // 
            // продатьАбонементToolStripMenuItem
            // 
            this.продатьАбонементToolStripMenuItem.Image = global::PersonsBase.Properties.Resources.currency_dollar_green;
            this.продатьАбонементToolStripMenuItem.Name = "продатьАбонементToolStripMenuItem";
            this.продатьАбонементToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.продатьАбонементToolStripMenuItem.Text = "Продать Абонемент";
            this.продатьАбонементToolStripMenuItem.Click += new System.EventHandler(this.продатьАбонементToolStripMenuItem_Click);
            // 
            // удалитьКлиентаToolStripMenuItem
            // 
            this.удалитьКлиентаToolStripMenuItem.Image = global::PersonsBase.Properties.Resources.delete;
            this.удалитьКлиентаToolStripMenuItem.Name = "удалитьКлиентаToolStripMenuItem";
            this.удалитьКлиентаToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.удалитьКлиентаToolStripMenuItem.Text = "Удалить Клиента";
            this.удалитьКлиентаToolStripMenuItem.Click += new System.EventHandler(this.удалитьКлиентаToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.Image = global::PersonsBase.Properties.Resources.clipboard_report_bar_24_ns;
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(88, 28);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            this.отчетыToolStripMenuItem.Click += new System.EventHandler(this.отчетыToolStripMenuItem_Click);
            // 
            // сomboBox_PersonsList
            // 
            this.сomboBox_PersonsList.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.сomboBox_PersonsList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.сomboBox_PersonsList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.сomboBox_PersonsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.сomboBox_PersonsList.DropDownHeight = 350;
            this.сomboBox_PersonsList.DropDownWidth = 250;
            this.сomboBox_PersonsList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.сomboBox_PersonsList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.сomboBox_PersonsList.IntegralHeight = false;
            this.сomboBox_PersonsList.Name = "сomboBox_PersonsList";
            this.сomboBox_PersonsList.Size = new System.Drawing.Size(400, 28);
            this.сomboBox_PersonsList.Sorted = true;
            this.сomboBox_PersonsList.SelectedIndexChanged += new System.EventHandler(this.сomboBox_PersonsListSelectedIndexChanged);
            this.сomboBox_PersonsList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.сomboBox_PersonsList_KeyUp);
            // 
            // сканироватьToolStripMenuItem
            // 
            this.сканироватьToolStripMenuItem.Image = global::PersonsBase.Properties.Resources.sca;
            this.сканироватьToolStripMenuItem.Name = "сканироватьToolStripMenuItem";
            this.сканироватьToolStripMenuItem.Size = new System.Drawing.Size(162, 28);
            this.сканироватьToolStripMenuItem.Text = "Сканировать Карту";
            this.сканироватьToolStripMenuItem.Click += new System.EventHandler(this.сканироватьToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.comboBox_BDay);
            this.groupBox1.Controls.Add(this.label_Time);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(1090, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 640);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.button_Reset_Date);
            this.groupBox4.Controls.Add(this.monthCalendar1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(10, 363);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(174, 249);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "История посещений:";
            // 
            // button_Reset_Date
            // 
            this.button_Reset_Date.Location = new System.Drawing.Point(6, 207);
            this.button_Reset_Date.Name = "button_Reset_Date";
            this.button_Reset_Date.Size = new System.Drawing.Size(162, 36);
            this.button_Reset_Date.TabIndex = 3;
            this.button_Reset_Date.Text = "Сегодня";
            this.button_Reset_Date.UseVisualStyleBackColor = true;
            this.button_Reset_Date.Click += new System.EventHandler(this.button_Reset_Date_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monthCalendar1.Location = new System.Drawing.Point(4, 29);
            this.monthCalendar1.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label_Total_persons);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(10, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 70);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Клиентов в Базе: ";
            // 
            // label_Total_persons
            // 
            this.label_Total_persons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Total_persons.AutoSize = true;
            this.label_Total_persons.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Total_persons.Location = new System.Drawing.Point(63, 26);
            this.label_Total_persons.Name = "label_Total_persons";
            this.label_Total_persons.Size = new System.Drawing.Size(32, 36);
            this.label_Total_persons.TabIndex = 0;
            this.label_Total_persons.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label_PeopleForDay);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(10, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 70);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Клиентов за День:";
            // 
            // label_PeopleForDay
            // 
            this.label_PeopleForDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_PeopleForDay.AutoSize = true;
            this.label_PeopleForDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_PeopleForDay.Location = new System.Drawing.Point(63, 26);
            this.label_PeopleForDay.Name = "label_PeopleForDay";
            this.label_PeopleForDay.Size = new System.Drawing.Size(32, 36);
            this.label_PeopleForDay.TabIndex = 7;
            this.label_PeopleForDay.Text = "0";
            // 
            // comboBox_BDay
            // 
            this.comboBox_BDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_BDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BDay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_BDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_BDay.FormattingEnabled = true;
            this.comboBox_BDay.Location = new System.Drawing.Point(10, 117);
            this.comboBox_BDay.Name = "comboBox_BDay";
            this.comboBox_BDay.Size = new System.Drawing.Size(166, 28);
            this.comboBox_BDay.Sorted = true;
            this.comboBox_BDay.TabIndex = 6;
            // 
            // label_Time
            // 
            this.label_Time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Time.AutoSize = true;
            this.label_Time.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Time.ForeColor = System.Drawing.Color.Navy;
            this.label_Time.Location = new System.Drawing.Point(12, 19);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(160, 45);
            this.label_Time.TabIndex = 5;
            this.label_Time.Text = "09:00:00";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(7, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дни Рождения:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.59165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.59165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.59165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.22506F));
            this.tableLayoutPanel1.Controls.Add(this.listView_MiniGroup, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView_Gym_Zal, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView_Personal, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView_Group, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_group, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_personal, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_tren_zal, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 53);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1072, 632);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listView_MiniGroup
            // 
            this.listView_MiniGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listView_MiniGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_MiniGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView_MiniGroup.FullRowSelect = true;
            this.listView_MiniGroup.GridLines = true;
            this.listView_MiniGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_MiniGroup.HideSelection = false;
            this.listView_MiniGroup.Location = new System.Drawing.Point(6, 31);
            this.listView_MiniGroup.MultiSelect = false;
            this.listView_MiniGroup.Name = "listView_MiniGroup";
            this.listView_MiniGroup.Size = new System.Drawing.Size(243, 595);
            this.listView_MiniGroup.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView_MiniGroup.TabIndex = 4;
            this.listView_MiniGroup.UseCompatibleStateImageBehavior = false;
            this.listView_MiniGroup.View = System.Windows.Forms.View.Details;
            this.listView_MiniGroup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MiniGroup_MouseClick);
            this.listView_MiniGroup.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MiniGroup_MouseDoubleClick);
            this.listView_MiniGroup.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.listView_MiniGroup_PreviewKeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 5;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "";
            this.columnHeader6.Width = 130;
            // 
            // listView_Gym_Zal
            // 
            this.listView_Gym_Zal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Time,
            this.column_Persons});
            this.listView_Gym_Zal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Gym_Zal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView_Gym_Zal.FullRowSelect = true;
            this.listView_Gym_Zal.GridLines = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.listView_Gym_Zal.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listView_Gym_Zal.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_Gym_Zal.HideSelection = false;
            this.listView_Gym_Zal.Location = new System.Drawing.Point(762, 31);
            this.listView_Gym_Zal.MultiSelect = false;
            this.listView_Gym_Zal.Name = "listView_Gym_Zal";
            this.listView_Gym_Zal.ShowGroups = false;
            this.listView_Gym_Zal.Size = new System.Drawing.Size(304, 595);
            this.listView_Gym_Zal.TabIndex = 2;
            this.listView_Gym_Zal.UseCompatibleStateImageBehavior = false;
            this.listView_Gym_Zal.View = System.Windows.Forms.View.Details;
            this.listView_Gym_Zal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Gym_Zal_MouseClick);
            this.listView_Gym_Zal.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_Gym_Zal_MouseDoubleClick);
            this.listView_Gym_Zal.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.listView_Gym_Zal_PreviewKeyDown);
            // 
            // column_Time
            // 
            this.column_Time.Text = "";
            this.column_Time.Width = 50;
            // 
            // column_Persons
            // 
            this.column_Persons.Text = "";
            this.column_Persons.Width = 130;
            // 
            // listView_Personal
            // 
            this.listView_Personal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView_Personal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Personal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView_Personal.FullRowSelect = true;
            this.listView_Personal.GridLines = true;
            this.listView_Personal.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_Personal.HideSelection = false;
            this.listView_Personal.Location = new System.Drawing.Point(510, 31);
            this.listView_Personal.MultiSelect = false;
            this.listView_Personal.Name = "listView_Personal";
            this.listView_Personal.Size = new System.Drawing.Size(243, 595);
            this.listView_Personal.TabIndex = 2;
            this.listView_Personal.UseCompatibleStateImageBehavior = false;
            this.listView_Personal.View = System.Windows.Forms.View.Details;
            this.listView_Personal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Personal_MouseClick);
            this.listView_Personal.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_Personal_MouseDoubleClick);
            this.listView_Personal.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.listView_Personal_PreviewKeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 5;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 130;
            // 
            // listView_Group
            // 
            this.listView_Group.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader3});
            this.listView_Group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Group.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView_Group.FullRowSelect = true;
            this.listView_Group.GridLines = true;
            this.listView_Group.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_Group.HideSelection = false;
            this.listView_Group.Location = new System.Drawing.Point(258, 31);
            this.listView_Group.MultiSelect = false;
            this.listView_Group.Name = "listView_Group";
            this.listView_Group.Size = new System.Drawing.Size(243, 595);
            this.listView_Group.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView_Group.TabIndex = 2;
            this.listView_Group.UseCompatibleStateImageBehavior = false;
            this.listView_Group.View = System.Windows.Forms.View.Details;
            this.listView_Group.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Group_MouseClick);
            this.listView_Group.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_Group_MouseDoubleClick);
            this.listView_Group.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.listView_Group_PreviewKeyDown);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 5;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 130;
            // 
            // label_group
            // 
            this.label_group.AutoSize = true;
            this.label_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_group.Location = new System.Drawing.Point(258, 3);
            this.label_group.Name = "label_group";
            this.label_group.Size = new System.Drawing.Size(57, 17);
            this.label_group.TabIndex = 1;
            this.label_group.Text = "Группы";
            this.label_group.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_personal
            // 
            this.label_personal.AutoSize = true;
            this.label_personal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_personal.Location = new System.Drawing.Point(510, 3);
            this.label_personal.Name = "label_personal";
            this.label_personal.Size = new System.Drawing.Size(106, 17);
            this.label_personal.TabIndex = 2;
            this.label_personal.Text = "Персональные";
            // 
            // label_tren_zal
            // 
            this.label_tren_zal.AutoSize = true;
            this.label_tren_zal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_tren_zal.Location = new System.Drawing.Point(762, 3);
            this.label_tren_zal.Name = "label_tren_zal";
            this.label_tren_zal.Size = new System.Drawing.Size(127, 17);
            this.label_tren_zal.TabIndex = 3;
            this.label_tren_zal.Text = "Тренажерный зал";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Мини Группы";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьКарточкуToolStripMenuItem,
            this.удалитьЗаписьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 48);
            // 
            // открытьКарточкуToolStripMenuItem
            // 
            this.открытьКарточкуToolStripMenuItem.Name = "открытьКарточкуToolStripMenuItem";
            this.открытьКарточкуToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.открытьКарточкуToolStripMenuItem.Text = "Открыть карточку";
            this.открытьКарточкуToolStripMenuItem.Click += new System.EventHandler(this.открытьКарточкуToolStripMenuItem_Click);
            // 
            // удалитьЗаписьToolStripMenuItem
            // 
            this.удалитьЗаписьToolStripMenuItem.Name = "удалитьЗаписьToolStripMenuItem";
            this.удалитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.удалитьЗаписьToolStripMenuItem.Text = "Удалить запись";
            this.удалитьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.удалитьЗаписьToolStripMenuItem_Click);
            // 
            // label_SelectedDate
            // 
            this.label_SelectedDate.AutoSize = true;
            this.label_SelectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_SelectedDate.ForeColor = System.Drawing.Color.Red;
            this.label_SelectedDate.Location = new System.Drawing.Point(266, 30);
            this.label_SelectedDate.Name = "label_SelectedDate";
            this.label_SelectedDate.Size = new System.Drawing.Size(134, 20);
            this.label_SelectedDate.TabIndex = 4;
            this.label_SelectedDate.Text = "Посещения за:";
            this.label_SelectedDate.Visible = false;
            // 
            // maskedTextBox_PhoneNumber
            // 
            this.maskedTextBox_PhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_PhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_PhoneNumber.Location = new System.Drawing.Point(716, 1);
            this.maskedTextBox_PhoneNumber.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBox_PhoneNumber.Mask = "8(999) 000-00-00";
            this.maskedTextBox_PhoneNumber.Name = "maskedTextBox_PhoneNumber";
            this.maskedTextBox_PhoneNumber.Size = new System.Drawing.Size(164, 29);
            this.maskedTextBox_PhoneNumber.TabIndex = 5;
            this.maskedTextBox_PhoneNumber.Click += new System.EventHandler(this.maskedTextBox_PhoneNumber_Click);
            this.maskedTextBox_PhoneNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox_PhoneNumber_KeyUp);
            // 
            // импортИзExcelToolStripMenuItem
            // 
            this.импортИзExcelToolStripMenuItem.Name = "импортИзExcelToolStripMenuItem";
            this.импортИзExcelToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.импортИзExcelToolStripMenuItem.Text = "Импорт из Excel";
            this.импортИзExcelToolStripMenuItem.Click += new System.EventHandler(this.импортИзExcelToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 697);
            this.Controls.Add(this.maskedTextBox_PhoneNumber);
            this.Controls.Add(this.label_SelectedDate);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1308, 708);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manhattan Fitness Club";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem конфигурацииToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private ListView listView_Gym_Zal;
        private Label label_tren_zal;
        private Label label_personal;
        private Label label_group;
        private MonthCalendar monthCalendar1;
        private GroupBox groupBox1;
        private Label label_Time;
        private ToolStripMenuItem клиентыToolStripMenuItem;
        private ToolStripMenuItem добавитьКлиентаToolStripMenuItem;
        private ToolStripMenuItem удалитьКлиентаToolStripMenuItem;
        private ToolStripMenuItem отчетыToolStripMenuItem;
        private ToolStripMenuItem руководительToolStripMenuItem1;
        private ToolStripMenuItem продатьАбонементToolStripMenuItem;
        private ComboBox comboBox_BDay;
        private Label label4;
        private ToolStripMenuItem списокКлиентовToolStripMenuItem;
        private ColumnHeader column_Persons;
        private ColumnHeader column_Time;
        private ListView listView_Personal;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ToolStripMenuItem сохранитьВExcelToolStripMenuItem;
        private ToolStripComboBox сomboBox_PersonsList;
        private ToolStripMenuItem сканироватьToolStripMenuItem;
        private ListView listView_MiniGroup;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Label label3;
        private ToolStripMenuItem администраторыToolStripMenuItem;
        private Label label_PeopleForDay;
        private GroupBox groupBox3;
        private Label label_Total_persons;
        private GroupBox groupBox2;
        private ToolTip toolTip1;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem открытьКарточкуToolStripMenuItem;
        private ToolStripMenuItem удалитьЗаписьToolStripMenuItem;
        private ListView listView_Group;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader3;
        private GroupBox groupBox4;
        private Button button_Reset_Date;
        private Label label_SelectedDate;
        private MaskedTextBox maskedTextBox_PhoneNumber;
        private ToolStripMenuItem импортИзExcelToolStripMenuItem;
    }
}