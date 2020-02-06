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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.конфигурацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководительToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьКлиентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.продатьАбонементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьКлиентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сomboBox_PersonsList = new System.Windows.Forms.ToolStripComboBox();
            this.сканироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКлиентовToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SellAbonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_BDay = new System.Windows.Forms.ComboBox();
            this.label_Time = new System.Windows.Forms.Label();
            this.textBox_PeopleForDay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_ClientsPerDay = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.textBox_Total_persons = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.сomboBox_PersonsList,
            this.сканироватьToolStripMenuItem,
            this.списокКлиентовToolStripMenuItem1,
            this.SellAbonToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1241, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // конфигурацииToolStripMenuItem
            // 
            this.конфигурацииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.руководительToolStripMenuItem1,
            this.сохранитьВExcelToolStripMenuItem,
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
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = global::PersonsBase.Properties.Resources.exit;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
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
            // 
            // сканироватьToolStripMenuItem
            // 
            this.сканироватьToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.сканироватьToolStripMenuItem.Image = global::PersonsBase.Properties.Resources.sca;
            this.сканироватьToolStripMenuItem.Name = "сканироватьToolStripMenuItem";
            this.сканироватьToolStripMenuItem.Size = new System.Drawing.Size(122, 28);
            this.сканироватьToolStripMenuItem.Text = "Сканировать";
            this.сканироватьToolStripMenuItem.Click += new System.EventHandler(this.сканироватьToolStripMenuItem_Click);
            // 
            // списокКлиентовToolStripMenuItem1
            // 
            this.списокКлиентовToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.списокКлиентовToolStripMenuItem1.Image = global::PersonsBase.Properties.Resources.list_all_participants;
            this.списокКлиентовToolStripMenuItem1.Name = "списокКлиентовToolStripMenuItem1";
            this.списокКлиентовToolStripMenuItem1.Size = new System.Drawing.Size(149, 28);
            this.списокКлиентовToolStripMenuItem1.Text = "Список Клиентов";
            this.списокКлиентовToolStripMenuItem1.Click += new System.EventHandler(this.списокКлиентовToolStripMenuItem1_Click);
            // 
            // SellAbonToolStripMenuItem
            // 
            this.SellAbonToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SellAbonToolStripMenuItem.Image = global::PersonsBase.Properties.Resources.currency_dollar_green;
            this.SellAbonToolStripMenuItem.Name = "SellAbonToolStripMenuItem";
            this.SellAbonToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.SellAbonToolStripMenuItem.Text = "Добавить Абонемент";
            this.SellAbonToolStripMenuItem.Click += new System.EventHandler(this.SellButtonMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBox_BDay);
            this.groupBox1.Controls.Add(this.label_Time);
            this.groupBox1.Controls.Add(this.textBox_PeopleForDay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label_ClientsPerDay);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.textBox_Total_persons);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(1051, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 410);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сейчас:";
            // 
            // comboBox_BDay
            // 
            this.comboBox_BDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BDay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_BDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_BDay.FormattingEnabled = true;
            this.comboBox_BDay.Location = new System.Drawing.Point(6, 94);
            this.comboBox_BDay.Name = "comboBox_BDay";
            this.comboBox_BDay.Size = new System.Drawing.Size(161, 24);
            this.comboBox_BDay.Sorted = true;
            this.comboBox_BDay.TabIndex = 6;
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Font = new System.Drawing.Font("Comic Sans MS", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Time.ForeColor = System.Drawing.Color.Navy;
            this.label_Time.Location = new System.Drawing.Point(27, 16);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(0, 42);
            this.label_Time.TabIndex = 5;
            // 
            // textBox_PeopleForDay
            // 
            this.textBox_PeopleForDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_PeopleForDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PeopleForDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_PeopleForDay.Location = new System.Drawing.Point(6, 161);
            this.textBox_PeopleForDay.Name = "textBox_PeopleForDay";
            this.textBox_PeopleForDay.Size = new System.Drawing.Size(161, 23);
            this.textBox_PeopleForDay.TabIndex = 4;
            this.textBox_PeopleForDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // label_ClientsPerDay
            // 
            this.label_ClientsPerDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ClientsPerDay.AutoSize = true;
            this.label_ClientsPerDay.Location = new System.Drawing.Point(6, 145);
            this.label_ClientsPerDay.Name = "label_ClientsPerDay";
            this.label_ClientsPerDay.Size = new System.Drawing.Size(132, 17);
            this.label_ClientsPerDay.TabIndex = 3;
            this.label_ClientsPerDay.Text = "Клиентов за День:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.monthCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monthCalendar1.Location = new System.Drawing.Point(6, 242);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            // 
            // textBox_Total_persons
            // 
            this.textBox_Total_persons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Total_persons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Total_persons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Total_persons.Location = new System.Drawing.Point(6, 207);
            this.textBox_Total_persons.Name = "textBox_Total_persons";
            this.textBox_Total_persons.Size = new System.Drawing.Size(161, 23);
            this.textBox_Total_persons.TabIndex = 1;
            this.textBox_Total_persons.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.91756F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.1828F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.01912F));
            this.tableLayoutPanel1.Controls.Add(this.listView_Gym_Zal, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView_Personal, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView_Group, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_group, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_personal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_tren_zal, 2, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 53);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1033, 403);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.listView_Gym_Zal.Location = new System.Drawing.Point(705, 31);
            this.listView_Gym_Zal.MultiSelect = false;
            this.listView_Gym_Zal.Name = "listView_Gym_Zal";
            this.listView_Gym_Zal.ShowGroups = false;
            this.listView_Gym_Zal.Size = new System.Drawing.Size(322, 366);
            this.listView_Gym_Zal.TabIndex = 2;
            this.listView_Gym_Zal.UseCompatibleStateImageBehavior = false;
            this.listView_Gym_Zal.View = System.Windows.Forms.View.Details;
            // 
            // column_Time
            // 
            this.column_Time.Text = "";
            this.column_Time.Width = 61;
            // 
            // column_Persons
            // 
            this.column_Persons.Text = "";
            this.column_Persons.Width = 190;
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
            this.listView_Personal.Location = new System.Drawing.Point(385, 31);
            this.listView_Personal.MultiSelect = false;
            this.listView_Personal.Name = "listView_Personal";
            this.listView_Personal.Size = new System.Drawing.Size(311, 366);
            this.listView_Personal.TabIndex = 2;
            this.listView_Personal.UseCompatibleStateImageBehavior = false;
            this.listView_Personal.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 41;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 198;
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
            this.listView_Group.Location = new System.Drawing.Point(6, 31);
            this.listView_Group.MultiSelect = false;
            this.listView_Group.Name = "listView_Group";
            this.listView_Group.Size = new System.Drawing.Size(370, 366);
            this.listView_Group.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView_Group.TabIndex = 2;
            this.listView_Group.UseCompatibleStateImageBehavior = false;
            this.listView_Group.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 245;
            // 
            // label_group
            // 
            this.label_group.AutoSize = true;
            this.label_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_group.Location = new System.Drawing.Point(6, 3);
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
            this.label_personal.Location = new System.Drawing.Point(385, 3);
            this.label_personal.Name = "label_personal";
            this.label_personal.Size = new System.Drawing.Size(106, 17);
            this.label_personal.TabIndex = 2;
            this.label_personal.Text = "Персональные";
            // 
            // label_tren_zal
            // 
            this.label_tren_zal.AutoSize = true;
            this.label_tren_zal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_tren_zal.Location = new System.Drawing.Point(705, 3);
            this.label_tren_zal.Name = "label_tren_zal";
            this.label_tren_zal.Size = new System.Drawing.Size(127, 17);
            this.label_tren_zal.TabIndex = 3;
            this.label_tren_zal.Text = "Тренажерный зал";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 468);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1027, 507);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manhattan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
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
        private ListView listView_Gym_Zal;
        private Label label_tren_zal;
        private Label label_personal;
        private Label label_group;
        private TextBox textBox_Total_persons;
        private Label label2;
        private MonthCalendar monthCalendar1;
        private GroupBox groupBox1;
        private Label label_Time;
        private TextBox textBox_PeopleForDay;
        private Label label_ClientsPerDay;
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
        private ListView listView_Group;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader3;
        private ToolStripMenuItem SellAbonToolStripMenuItem;
        private ToolStripMenuItem списокКлиентовToolStripMenuItem1;
        private ToolStripMenuItem сохранитьВExcelToolStripMenuItem;
        private ToolStripComboBox сomboBox_PersonsList;
        private ToolStripMenuItem сканироватьToolStripMenuItem;
    }
}