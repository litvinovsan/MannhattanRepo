namespace PersonsBase.View
{
    partial class BossForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView_schedule = new System.Windows.Forms.ListView();
            this.columnHeader_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_remove_sched = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox_add = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_nameTren = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox_time_M = new System.Windows.Forms.ComboBox();
            this.comboBox_time_H = new System.Windows.Forms.ComboBox();
            this.button_add_sched = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView_Admins = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_Remove_Admin = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Remove_Trener = new System.Windows.Forms.Button();
            this.listView_Tren = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox_select = new System.Windows.Forms.GroupBox();
            this.radioButton_adm = new System.Windows.Forms.RadioButton();
            this.radioButton_tren = new System.Windows.Forms.RadioButton();
            this.button_AddEmploee = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_phone = new System.Windows.Forms.MaskedTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox_FiO = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_add.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox_select.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listView_schedule);
            this.groupBox1.Location = new System.Drawing.Point(260, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 400);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Расписание Групповых тренировок";
            // 
            // listView_schedule
            // 
            this.listView_schedule.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView_schedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_schedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Time,
            this.columnHeader_Name});
            this.listView_schedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView_schedule.FullRowSelect = true;
            this.listView_schedule.GridLines = true;
            this.listView_schedule.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_schedule.Location = new System.Drawing.Point(3, 17);
            this.listView_schedule.MultiSelect = false;
            this.listView_schedule.Name = "listView_schedule";
            this.listView_schedule.ShowGroups = false;
            this.listView_schedule.Size = new System.Drawing.Size(678, 377);
            this.listView_schedule.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_schedule.TabIndex = 3;
            this.listView_schedule.UseCompatibleStateImageBehavior = false;
            this.listView_schedule.View = System.Windows.Forms.View.Details;
            this.listView_schedule.SelectedIndexChanged += new System.EventHandler(this.listView_schedule_SelectedIndexChanged);
            // 
            // columnHeader_Time
            // 
            this.columnHeader_Time.Text = "Время:";
            this.columnHeader_Time.Width = 82;
            // 
            // columnHeader_Name
            // 
            this.columnHeader_Name.Text = "Название";
            this.columnHeader_Name.Width = 500;
            // 
            // button_remove_sched
            // 
            this.button_remove_sched.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_remove_sched.Enabled = false;
            this.button_remove_sched.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_remove_sched.Location = new System.Drawing.Point(6, 233);
            this.button_remove_sched.Name = "button_remove_sched";
            this.button_remove_sched.Size = new System.Drawing.Size(235, 29);
            this.button_remove_sched.TabIndex = 5;
            this.button_remove_sched.Text = "Удалить из расписания";
            this.button_remove_sched.UseVisualStyleBackColor = true;
            this.button_remove_sched.Click += new System.EventHandler(this.button_remove_sched_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(963, 444);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox_add);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(955, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Расписание";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox_add
            // 
            this.groupBox_add.Controls.Add(this.button_remove_sched);
            this.groupBox_add.Controls.Add(this.groupBox5);
            this.groupBox_add.Controls.Add(this.groupBox4);
            this.groupBox_add.Controls.Add(this.button_add_sched);
            this.groupBox_add.Location = new System.Drawing.Point(6, 6);
            this.groupBox_add.Name = "groupBox_add";
            this.groupBox_add.Size = new System.Drawing.Size(248, 268);
            this.groupBox_add.TabIndex = 7;
            this.groupBox_add.TabStop = false;
            this.groupBox_add.Text = "Создание тренировки";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.textBox_nameTren);
            this.groupBox5.Location = new System.Drawing.Point(5, 113);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(236, 65);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Название:";
            // 
            // textBox_nameTren
            // 
            this.textBox_nameTren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_nameTren.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_nameTren.Location = new System.Drawing.Point(6, 35);
            this.textBox_nameTren.Name = "textBox_nameTren";
            this.textBox_nameTren.Size = new System.Drawing.Size(224, 23);
            this.textBox_nameTren.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.comboBox_time_M);
            this.groupBox4.Controls.Add(this.comboBox_time_H);
            this.groupBox4.Location = new System.Drawing.Point(5, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 71);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Начало:";
            // 
            // comboBox_time_M
            // 
            this.comboBox_time_M.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_time_M.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_time_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_time_M.ForeColor = System.Drawing.Color.DarkBlue;
            this.comboBox_time_M.FormattingEnabled = true;
            this.comboBox_time_M.Location = new System.Drawing.Point(119, 32);
            this.comboBox_time_M.Name = "comboBox_time_M";
            this.comboBox_time_M.Size = new System.Drawing.Size(111, 28);
            this.comboBox_time_M.TabIndex = 5;
            // 
            // comboBox_time_H
            // 
            this.comboBox_time_H.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_time_H.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_time_H.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_time_H.ForeColor = System.Drawing.Color.DarkBlue;
            this.comboBox_time_H.FormattingEnabled = true;
            this.comboBox_time_H.Location = new System.Drawing.Point(5, 32);
            this.comboBox_time_H.Name = "comboBox_time_H";
            this.comboBox_time_H.Size = new System.Drawing.Size(110, 28);
            this.comboBox_time_H.TabIndex = 0;
            // 
            // button_add_sched
            // 
            this.button_add_sched.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add_sched.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_add_sched.Location = new System.Drawing.Point(7, 198);
            this.button_add_sched.Name = "button_add_sched";
            this.button_add_sched.Size = new System.Drawing.Size(235, 29);
            this.button_add_sched.TabIndex = 2;
            this.button_add_sched.Text = "Добавить";
            this.button_add_sched.UseVisualStyleBackColor = true;
            this.button_add_sched.Click += new System.EventHandler(this.button_add_sched_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(955, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Персонал";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(949, 409);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView_Admins);
            this.groupBox3.Controls.Add(this.button_Remove_Admin);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(619, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 403);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Администраторы:";
            // 
            // listView_Admins
            // 
            this.listView_Admins.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView_Admins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Admins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listView_Admins.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView_Admins.FullRowSelect = true;
            this.listView_Admins.GridLines = true;
            this.listView_Admins.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_Admins.Location = new System.Drawing.Point(7, 22);
            this.listView_Admins.MultiSelect = false;
            this.listView_Admins.Name = "listView_Admins";
            this.listView_Admins.ShowGroups = false;
            this.listView_Admins.Size = new System.Drawing.Size(314, 340);
            this.listView_Admins.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_Admins.TabIndex = 6;
            this.listView_Admins.UseCompatibleStateImageBehavior = false;
            this.listView_Admins.View = System.Windows.Forms.View.Details;
            this.listView_Admins.SelectedIndexChanged += new System.EventHandler(this.listView_Admin_SelectedIndexChanged);
            this.listView_Admins.Leave += new System.EventHandler(this.listView_Admins_Leave);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 300;
            // 
            // button_Remove_Admin
            // 
            this.button_Remove_Admin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Remove_Admin.Enabled = false;
            this.button_Remove_Admin.Location = new System.Drawing.Point(6, 368);
            this.button_Remove_Admin.Name = "button_Remove_Admin";
            this.button_Remove_Admin.Size = new System.Drawing.Size(314, 29);
            this.button_Remove_Admin.TabIndex = 5;
            this.button_Remove_Admin.Text = "Удалить";
            this.button_Remove_Admin.UseVisualStyleBackColor = true;
            this.button_Remove_Admin.Click += new System.EventHandler(this.button_Remove_Admin_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Remove_Trener);
            this.groupBox2.Controls.Add(this.listView_Tren);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(287, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 403);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тренерский состав:";
            // 
            // button_Remove_Trener
            // 
            this.button_Remove_Trener.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Remove_Trener.Enabled = false;
            this.button_Remove_Trener.Location = new System.Drawing.Point(6, 368);
            this.button_Remove_Trener.Name = "button_Remove_Trener";
            this.button_Remove_Trener.Size = new System.Drawing.Size(314, 29);
            this.button_Remove_Trener.TabIndex = 5;
            this.button_Remove_Trener.Text = "Удалить";
            this.button_Remove_Trener.UseVisualStyleBackColor = true;
            this.button_Remove_Trener.Click += new System.EventHandler(this.button_Remove_Trener_Click);
            // 
            // listView_Tren
            // 
            this.listView_Tren.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView_Tren.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Tren.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView_Tren.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView_Tren.FullRowSelect = true;
            this.listView_Tren.GridLines = true;
            this.listView_Tren.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView_Tren.Location = new System.Drawing.Point(6, 22);
            this.listView_Tren.MultiSelect = false;
            this.listView_Tren.Name = "listView_Tren";
            this.listView_Tren.ShowGroups = false;
            this.listView_Tren.Size = new System.Drawing.Size(314, 340);
            this.listView_Tren.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_Tren.TabIndex = 4;
            this.listView_Tren.UseCompatibleStateImageBehavior = false;
            this.listView_Tren.View = System.Windows.Forms.View.Details;
            this.listView_Tren.SelectedIndexChanged += new System.EventHandler(this.listView_Tren_SelectedIndexChanged);
            this.listView_Tren.Leave += new System.EventHandler(this.listView_Tren_Leave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 300;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox_select);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(278, 403);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            // 
            // groupBox_select
            // 
            this.groupBox_select.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_select.Controls.Add(this.radioButton_adm);
            this.groupBox_select.Controls.Add(this.radioButton_tren);
            this.groupBox_select.Controls.Add(this.button_AddEmploee);
            this.groupBox_select.Location = new System.Drawing.Point(6, 177);
            this.groupBox_select.Name = "groupBox_select";
            this.groupBox_select.Size = new System.Drawing.Size(266, 127);
            this.groupBox_select.TabIndex = 2;
            this.groupBox_select.TabStop = false;
            this.groupBox_select.Text = "Позиция";
            // 
            // radioButton_adm
            // 
            this.radioButton_adm.AutoSize = true;
            this.radioButton_adm.Location = new System.Drawing.Point(13, 58);
            this.radioButton_adm.Name = "radioButton_adm";
            this.radioButton_adm.Size = new System.Drawing.Size(129, 21);
            this.radioButton_adm.TabIndex = 2;
            this.radioButton_adm.Text = "Администратор";
            this.radioButton_adm.UseVisualStyleBackColor = true;
            this.radioButton_adm.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_tren
            // 
            this.radioButton_tren.AutoSize = true;
            this.radioButton_tren.Checked = true;
            this.radioButton_tren.Location = new System.Drawing.Point(13, 30);
            this.radioButton_tren.Name = "radioButton_tren";
            this.radioButton_tren.Size = new System.Drawing.Size(75, 21);
            this.radioButton_tren.TabIndex = 1;
            this.radioButton_tren.TabStop = true;
            this.radioButton_tren.Text = "Тренер";
            this.radioButton_tren.UseVisualStyleBackColor = true;
            this.radioButton_tren.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // button_AddEmploee
            // 
            this.button_AddEmploee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AddEmploee.Location = new System.Drawing.Point(6, 92);
            this.button_AddEmploee.Name = "button_AddEmploee";
            this.button_AddEmploee.Size = new System.Drawing.Size(254, 29);
            this.button_AddEmploee.TabIndex = 0;
            this.button_AddEmploee.Text = "Добавить";
            this.button_AddEmploee.UseVisualStyleBackColor = true;
            this.button_AddEmploee.Click += new System.EventHandler(this.button_AddEmploee_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.maskedTextBox_phone);
            this.groupBox8.Location = new System.Drawing.Point(6, 95);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(266, 70);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Телефон";
            // 
            // maskedTextBox_phone
            // 
            this.maskedTextBox_phone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_phone.Location = new System.Drawing.Point(6, 41);
            this.maskedTextBox_phone.Mask = "8(999) 000-00-00";
            this.maskedTextBox_phone.Name = "maskedTextBox_phone";
            this.maskedTextBox_phone.Size = new System.Drawing.Size(254, 23);
            this.maskedTextBox_phone.TabIndex = 0;
            this.maskedTextBox_phone.TextChanged += new System.EventHandler(this.maskedTextBox_phone_TextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.textBox_FiO);
            this.groupBox7.Location = new System.Drawing.Point(6, 13);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(266, 70);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "ФИО";
            // 
            // textBox_FiO
            // 
            this.textBox_FiO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FiO.Location = new System.Drawing.Point(6, 41);
            this.textBox_FiO.Name = "textBox_FiO";
            this.textBox_FiO.Size = new System.Drawing.Size(254, 23);
            this.textBox_FiO.TabIndex = 0;
            // 
            // BossForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 444);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(876, 482);
            this.Name = "BossForm";
            this.Text = "Настройки для Самого Лучшего Руководителя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BossForm_FormClosing);
            this.Load += new System.EventHandler(this.BossForm_Load);
            this.SizeChanged += new System.EventHandler(this.BossForm_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox_add.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox_select.ResumeLayout(false);
            this.groupBox_select.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView_schedule;
        private System.Windows.Forms.ColumnHeader columnHeader_Time;
        private System.Windows.Forms.ColumnHeader columnHeader_Name;
        private System.Windows.Forms.GroupBox groupBox_add;
        private System.Windows.Forms.Button button_add_sched;
        private System.Windows.Forms.ComboBox comboBox_time_H;
        private System.Windows.Forms.TextBox textBox_nameTren;
        private System.Windows.Forms.Button button_remove_sched;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox_time_M;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button button_AddEmploee;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_phone;
        private System.Windows.Forms.TextBox textBox_FiO;
        private System.Windows.Forms.Button button_Remove_Admin;
        private System.Windows.Forms.Button button_Remove_Trener;
        private System.Windows.Forms.ListView listView_Tren;
        private System.Windows.Forms.ListView listView_Admins;
        private System.Windows.Forms.GroupBox groupBox_select;
        private System.Windows.Forms.RadioButton radioButton_adm;
        private System.Windows.Forms.RadioButton radioButton_tren;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}