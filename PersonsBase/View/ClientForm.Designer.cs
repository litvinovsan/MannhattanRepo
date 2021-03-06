﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PersonsBase.View
{

    partial class ClientForm
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
         this.dateTimePicker_birthDate = new System.Windows.Forms.DateTimePicker();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.groupBox_buttons = new System.Windows.Forms.GroupBox();
         this.flowLayoutPanel_MainButtons = new System.Windows.Forms.FlowLayoutPanel();
         this.button_CheckInWorkout = new System.Windows.Forms.Button();
         this.button_Add_Abon = new System.Windows.Forms.Button();
         this.button_add_dop_tren = new System.Windows.Forms.Button();
         this.button_Freeze = new System.Windows.Forms.Button();
         this.button_RemoveCurrentAbon = new System.Windows.Forms.Button();
         this.groupBox_PhotoButtons = new System.Windows.Forms.GroupBox();
         this.button_photo = new System.Windows.Forms.Button();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.groupBox_AbonLists = new System.Windows.Forms.GroupBox();
         this.radioButton_NotValid_selected = new System.Windows.Forms.RadioButton();
         this.radioButton_Valid_Selected = new System.Windows.Forms.RadioButton();
         this.listView_Abonements = new System.Windows.Forms.ListView();
         this.columnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.groupBox_Info = new System.Windows.Forms.GroupBox();
         this.richTextBox_notes = new System.Windows.Forms.RichTextBox();
         this.contextMenuStrip_RichTextBox = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.toolStripMenuItem_Red = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem_Green = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem_Blue = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem_Bold = new System.Windows.Forms.ToolStripMenuItem();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.label_infoText = new System.Windows.Forms.Label();
         this.label_PersonName = new System.Windows.Forms.Label();
         this.tabPage2 = new System.Windows.Forms.TabPage();
         this.button_SavePersonalData = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
         this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
         this.dateTimePicker_Activation = new System.Windows.Forms.DateTimePicker();
         this.label18 = new System.Windows.Forms.Label();
         this.dateTimePicker_Buy = new System.Windows.Forms.DateTimePicker();
         this.label17 = new System.Windows.Forms.Label();
         this.textBox_Ostalos_Aerob = new System.Windows.Forms.TextBox();
         this.label16 = new System.Windows.Forms.Label();
         this.textBox_Ostalos_Person = new System.Windows.Forms.TextBox();
         this.label23 = new System.Windows.Forms.Label();
         this.textBox_Ostalos_Dney = new System.Windows.Forms.TextBox();
         this.label14 = new System.Windows.Forms.Label();
         this.comboBox_Spa = new System.Windows.Forms.ComboBox();
         this.label21 = new System.Windows.Forms.Label();
         this.comboBox_TrenTypes = new System.Windows.Forms.ComboBox();
         this.label13 = new System.Windows.Forms.Label();
         this.comboBox_Type = new System.Windows.Forms.ComboBox();
         this.label11 = new System.Windows.Forms.Label();
         this.comboBox_timeVisit = new System.Windows.Forms.ComboBox();
         this.label10 = new System.Windows.Forms.Label();
         this.comboBox_activation = new System.Windows.Forms.ComboBox();
         this.label12 = new System.Windows.Forms.Label();
         this.comboBox_status = new System.Windows.Forms.ComboBox();
         this.label9 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.textBox_name_Person = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label15 = new System.Windows.Forms.Label();
         this.comboBox_Payment = new System.Windows.Forms.ComboBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label4 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.maskedTextBox_PhoneNumber = new System.Windows.Forms.MaskedTextBox();
         this.maskedTextBox_Passport = new System.Windows.Forms.MaskedTextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.maskedTextBox_DriverID = new System.Windows.Forms.MaskedTextBox();
         this.label_Phone = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.comboBox_Gender = new System.Windows.Forms.ComboBox();
         this.textBox_Number = new System.Windows.Forms.TextBox();
         this.tabPage3 = new System.Windows.Forms.TabPage();
         this.dataGridView_Visits = new System.Windows.Forms.DataGridView();
         this.tabPage_abon_history = new System.Windows.Forms.TabPage();
         this.dataGridView_history_abonements = new System.Windows.Forms.DataGridView();
         this.button_Bold = new System.Windows.Forms.Button();
         this.button_Red = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
         this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
         this.button_Blue = new System.Windows.Forms.Button();
         this.button_Green = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.button_Cancel = new System.Windows.Forms.Button();
         this.pictureBox_ClientPhoto = new System.Windows.Forms.PictureBox();
         this.button_photo_cam = new System.Windows.Forms.Button();
         this.tabControl1.SuspendLayout();
         this.tabPage1.SuspendLayout();
         this.groupBox_buttons.SuspendLayout();
         this.flowLayoutPanel_MainButtons.SuspendLayout();
         this.groupBox_PhotoButtons.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.groupBox_AbonLists.SuspendLayout();
         this.contextMenuStrip_RichTextBox.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.tabPage2.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.tabPage3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Visits)).BeginInit();
         this.tabPage_abon_history.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView_history_abonements)).BeginInit();
         this.tableLayoutPanel4.SuspendLayout();
         this.flowLayoutPanel2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClientPhoto)).BeginInit();
         this.SuspendLayout();
         // 
         // dateTimePicker_birthDate
         // 
         this.dateTimePicker_birthDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.dateTimePicker_birthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.dateTimePicker_birthDate.Location = new System.Drawing.Point(130, 121);
         this.dateTimePicker_birthDate.Margin = new System.Windows.Forms.Padding(2);
         this.dateTimePicker_birthDate.MaxDate = new System.DateTime(2040, 12, 31, 0, 0, 0, 0);
         this.dateTimePicker_birthDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
         this.dateTimePicker_birthDate.MinimumSize = new System.Drawing.Size(115, 22);
         this.dateTimePicker_birthDate.Name = "dateTimePicker_birthDate";
         this.dateTimePicker_birthDate.Size = new System.Drawing.Size(190, 24);
         this.dateTimePicker_birthDate.TabIndex = 3;
         this.dateTimePicker_birthDate.ValueChanged += new System.EventHandler(this.dateTimePicker_birthDate_ValueChanged);
         // 
         // tabControl1
         // 
         this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControl1.Controls.Add(this.tabPage1);
         this.tabControl1.Controls.Add(this.tabPage2);
         this.tabControl1.Controls.Add(this.tabPage3);
         this.tabControl1.Controls.Add(this.tabPage_abon_history);
         this.tabControl1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.tabControl1.HotTrack = true;
         this.tabControl1.ItemSize = new System.Drawing.Size(170, 30);
         this.tabControl1.Location = new System.Drawing.Point(0, 0);
         this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(1298, 706);
         this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
         this.tabControl1.TabIndex = 2;
         this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.pictureBox_ClientPhoto);
         this.tabPage1.Controls.Add(this.groupBox_buttons);
         this.tabPage1.Controls.Add(this.splitContainer1);
         this.tabPage1.Controls.Add(this.tableLayoutPanel2);
         this.tabPage1.Location = new System.Drawing.Point(4, 34);
         this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
         this.tabPage1.Size = new System.Drawing.Size(1290, 668);
         this.tabPage1.TabIndex = 0;
         this.tabPage1.Text = "Информация";
         this.tabPage1.UseVisualStyleBackColor = true;
         // 
         // groupBox_buttons
         // 
         this.groupBox_buttons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.groupBox_buttons.Controls.Add(this.flowLayoutPanel_MainButtons);
         this.groupBox_buttons.Location = new System.Drawing.Point(13, 249);
         this.groupBox_buttons.Name = "groupBox_buttons";
         this.groupBox_buttons.Size = new System.Drawing.Size(247, 409);
         this.groupBox_buttons.TabIndex = 17;
         this.groupBox_buttons.TabStop = false;
         // 
         // flowLayoutPanel_MainButtons
         // 
         this.flowLayoutPanel_MainButtons.Controls.Add(this.button_CheckInWorkout);
         this.flowLayoutPanel_MainButtons.Controls.Add(this.button_Add_Abon);
         this.flowLayoutPanel_MainButtons.Controls.Add(this.button_add_dop_tren);
         this.flowLayoutPanel_MainButtons.Controls.Add(this.button_Freeze);
         this.flowLayoutPanel_MainButtons.Controls.Add(this.button_RemoveCurrentAbon);
         this.flowLayoutPanel_MainButtons.Controls.Add(this.groupBox_PhotoButtons);
         this.flowLayoutPanel_MainButtons.Dock = System.Windows.Forms.DockStyle.Fill;
         this.flowLayoutPanel_MainButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
         this.flowLayoutPanel_MainButtons.Location = new System.Drawing.Point(3, 19);
         this.flowLayoutPanel_MainButtons.Name = "flowLayoutPanel_MainButtons";
         this.flowLayoutPanel_MainButtons.Size = new System.Drawing.Size(241, 387);
         this.flowLayoutPanel_MainButtons.TabIndex = 0;
         // 
         // button_CheckInWorkout
         // 
         this.button_CheckInWorkout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.button_CheckInWorkout.BackColor = System.Drawing.Color.LightGreen;
         this.button_CheckInWorkout.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_CheckInWorkout.Location = new System.Drawing.Point(2, 2);
         this.button_CheckInWorkout.Margin = new System.Windows.Forms.Padding(2);
         this.button_CheckInWorkout.Name = "button_CheckInWorkout";
         this.button_CheckInWorkout.Size = new System.Drawing.Size(231, 46);
         this.button_CheckInWorkout.TabIndex = 3;
         this.button_CheckInWorkout.Text = "Отметить Посещение";
         this.button_CheckInWorkout.UseVisualStyleBackColor = false;
         this.button_CheckInWorkout.Click += new System.EventHandler(this.button_CheckInWorkout_Click);
         // 
         // button_Add_Abon
         // 
         this.button_Add_Abon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.button_Add_Abon.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_Add_Abon.Location = new System.Drawing.Point(2, 52);
         this.button_Add_Abon.Margin = new System.Windows.Forms.Padding(2);
         this.button_Add_Abon.Name = "button_Add_Abon";
         this.button_Add_Abon.Size = new System.Drawing.Size(231, 46);
         this.button_Add_Abon.TabIndex = 4;
         this.button_Add_Abon.Text = "Добавить Абонемент";
         this.button_Add_Abon.UseVisualStyleBackColor = false;
         this.button_Add_Abon.Click += new System.EventHandler(this.button_Add_New_Abon_Click);
         // 
         // button_add_dop_tren
         // 
         this.button_add_dop_tren.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.button_add_dop_tren.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_add_dop_tren.Location = new System.Drawing.Point(2, 102);
         this.button_add_dop_tren.Margin = new System.Windows.Forms.Padding(2);
         this.button_add_dop_tren.Name = "button_add_dop_tren";
         this.button_add_dop_tren.Size = new System.Drawing.Size(231, 46);
         this.button_add_dop_tren.TabIndex = 6;
         this.button_add_dop_tren.Text = "Добавить Тренировки";
         this.button_add_dop_tren.UseVisualStyleBackColor = true;
         this.button_add_dop_tren.Visible = false;
         this.button_add_dop_tren.Click += new System.EventHandler(this.button_add_dop_tren_Click);
         // 
         // button_Freeze
         // 
         this.button_Freeze.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.button_Freeze.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_Freeze.Location = new System.Drawing.Point(2, 152);
         this.button_Freeze.Margin = new System.Windows.Forms.Padding(2);
         this.button_Freeze.Name = "button_Freeze";
         this.button_Freeze.Size = new System.Drawing.Size(231, 46);
         this.button_Freeze.TabIndex = 5;
         this.button_Freeze.Text = "Заморозка";
         this.button_Freeze.UseVisualStyleBackColor = false;
         this.button_Freeze.Click += new System.EventHandler(this.button_Freeze_Click);
         // 
         // button_RemoveCurrentAbon
         // 
         this.button_RemoveCurrentAbon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.button_RemoveCurrentAbon.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_RemoveCurrentAbon.Location = new System.Drawing.Point(2, 202);
         this.button_RemoveCurrentAbon.Margin = new System.Windows.Forms.Padding(2);
         this.button_RemoveCurrentAbon.Name = "button_RemoveCurrentAbon";
         this.button_RemoveCurrentAbon.Size = new System.Drawing.Size(232, 46);
         this.button_RemoveCurrentAbon.TabIndex = 2;
         this.button_RemoveCurrentAbon.Text = "Удалить Абонемент";
         this.button_RemoveCurrentAbon.UseVisualStyleBackColor = false;
         this.button_RemoveCurrentAbon.Visible = false;
         this.button_RemoveCurrentAbon.Click += new System.EventHandler(this.button_remove_current_abon_Click);
         // 
         // groupBox_PhotoButtons
         // 
         this.groupBox_PhotoButtons.Controls.Add(this.button_photo);
         this.groupBox_PhotoButtons.Controls.Add(this.button_photo_cam);
         this.groupBox_PhotoButtons.Location = new System.Drawing.Point(3, 253);
         this.groupBox_PhotoButtons.Name = "groupBox_PhotoButtons";
         this.groupBox_PhotoButtons.Size = new System.Drawing.Size(230, 86);
         this.groupBox_PhotoButtons.TabIndex = 14;
         this.groupBox_PhotoButtons.TabStop = false;
         this.groupBox_PhotoButtons.Text = "Фото";
         this.groupBox_PhotoButtons.Visible = false;
         // 
         // button_photo
         // 
         this.button_photo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.button_photo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_photo.Location = new System.Drawing.Point(9, 21);
         this.button_photo.Margin = new System.Windows.Forms.Padding(2);
         this.button_photo.Name = "button_photo";
         this.button_photo.Size = new System.Drawing.Size(216, 24);
         this.button_photo.TabIndex = 4;
         this.button_photo.Text = "Из файла";
         this.button_photo.UseVisualStyleBackColor = true;
         this.button_photo.Click += new System.EventHandler(this.button_photo_Click);
         // 
         // splitContainer1
         // 
         this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.splitContainer1.Location = new System.Drawing.Point(279, 46);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.groupBox_AbonLists);
         this.splitContainer1.Panel1.Controls.Add(this.groupBox_Info);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.richTextBox_notes);
         this.splitContainer1.Size = new System.Drawing.Size(1003, 612);
         this.splitContainer1.SplitterDistance = 438;
         this.splitContainer1.SplitterWidth = 8;
         this.splitContainer1.TabIndex = 16;
         // 
         // groupBox_AbonLists
         // 
         this.groupBox_AbonLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.groupBox_AbonLists.Controls.Add(this.radioButton_NotValid_selected);
         this.groupBox_AbonLists.Controls.Add(this.radioButton_Valid_Selected);
         this.groupBox_AbonLists.Controls.Add(this.listView_Abonements);
         this.groupBox_AbonLists.Location = new System.Drawing.Point(3, 5);
         this.groupBox_AbonLists.Name = "groupBox_AbonLists";
         this.groupBox_AbonLists.Size = new System.Drawing.Size(290, 425);
         this.groupBox_AbonLists.TabIndex = 19;
         this.groupBox_AbonLists.TabStop = false;
         this.groupBox_AbonLists.Text = "Абонементы";
         // 
         // radioButton_NotValid_selected
         // 
         this.radioButton_NotValid_selected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.radioButton_NotValid_selected.AutoSize = true;
         this.radioButton_NotValid_selected.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.radioButton_NotValid_selected.ForeColor = System.Drawing.Color.Maroon;
         this.radioButton_NotValid_selected.Location = new System.Drawing.Point(155, 396);
         this.radioButton_NotValid_selected.Name = "radioButton_NotValid_selected";
         this.radioButton_NotValid_selected.Size = new System.Drawing.Size(132, 23);
         this.radioButton_NotValid_selected.TabIndex = 18;
         this.radioButton_NotValid_selected.Text = "Закончились";
         this.radioButton_NotValid_selected.UseVisualStyleBackColor = true;
         this.radioButton_NotValid_selected.CheckedChanged += new System.EventHandler(this.radioButton_NotValid_selected_CheckedChanged);
         // 
         // radioButton_Valid_Selected
         // 
         this.radioButton_Valid_Selected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.radioButton_Valid_Selected.AutoSize = true;
         this.radioButton_Valid_Selected.Checked = true;
         this.radioButton_Valid_Selected.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.radioButton_Valid_Selected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
         this.radioButton_Valid_Selected.Location = new System.Drawing.Point(8, 397);
         this.radioButton_Valid_Selected.Name = "radioButton_Valid_Selected";
         this.radioButton_Valid_Selected.Size = new System.Drawing.Size(115, 23);
         this.radioButton_Valid_Selected.TabIndex = 18;
         this.radioButton_Valid_Selected.TabStop = true;
         this.radioButton_Valid_Selected.Text = "Действуют";
         this.radioButton_Valid_Selected.UseVisualStyleBackColor = true;
         this.radioButton_Valid_Selected.CheckedChanged += new System.EventHandler(this.radioButton_Valid_Selected_CheckedChanged);
         // 
         // listView_Abonements
         // 
         this.listView_Abonements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listView_Abonements.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.listView_Abonements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Name,
            this.columnHeader_Type});
         this.listView_Abonements.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.listView_Abonements.FullRowSelect = true;
         this.listView_Abonements.GridLines = true;
         this.listView_Abonements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
         this.listView_Abonements.HideSelection = false;
         this.listView_Abonements.Location = new System.Drawing.Point(8, 32);
         this.listView_Abonements.MultiSelect = false;
         this.listView_Abonements.Name = "listView_Abonements";
         this.listView_Abonements.Size = new System.Drawing.Size(276, 359);
         this.listView_Abonements.TabIndex = 19;
         this.listView_Abonements.UseCompatibleStateImageBehavior = false;
         this.listView_Abonements.View = System.Windows.Forms.View.Details;
         this.listView_Abonements.SelectedIndexChanged += new System.EventHandler(this.listView_Abonements_SelectedIndexChanged);
         this.listView_Abonements.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Abonements_MouseClick);
         // 
         // columnHeader_Name
         // 
         this.columnHeader_Name.Text = "Name";
         this.columnHeader_Name.Width = 127;
         // 
         // columnHeader_Type
         // 
         this.columnHeader_Type.Text = "Type";
         this.columnHeader_Type.Width = 137;
         // 
         // groupBox_Info
         // 
         this.groupBox_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.groupBox_Info.Location = new System.Drawing.Point(315, 5);
         this.groupBox_Info.Margin = new System.Windows.Forms.Padding(2);
         this.groupBox_Info.Name = "groupBox_Info";
         this.groupBox_Info.Padding = new System.Windows.Forms.Padding(2);
         this.groupBox_Info.Size = new System.Drawing.Size(671, 425);
         this.groupBox_Info.TabIndex = 4;
         this.groupBox_Info.TabStop = false;
         this.groupBox_Info.Text = "Информация";
         // 
         // richTextBox_notes
         // 
         this.richTextBox_notes.ContextMenuStrip = this.contextMenuStrip_RichTextBox;
         this.richTextBox_notes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBox_notes.Font = new System.Drawing.Font("Arial", 14F);
         this.richTextBox_notes.ForeColor = System.Drawing.Color.Black;
         this.richTextBox_notes.HideSelection = false;
         this.richTextBox_notes.Location = new System.Drawing.Point(0, 0);
         this.richTextBox_notes.Name = "richTextBox_notes";
         this.richTextBox_notes.ShowSelectionMargin = true;
         this.richTextBox_notes.Size = new System.Drawing.Size(1003, 166);
         this.richTextBox_notes.TabIndex = 6;
         this.richTextBox_notes.Text = "";
         this.richTextBox_notes.TextChanged += new System.EventHandler(this.richTextBox_notes_TextChanged);
         // 
         // contextMenuStrip_RichTextBox
         // 
         this.contextMenuStrip_RichTextBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Red,
            this.toolStripMenuItem_Green,
            this.toolStripMenuItem_Blue,
            this.toolStripMenuItem_Bold});
         this.contextMenuStrip_RichTextBox.Name = "contextMenuStrip_RichTextBox";
         this.contextMenuStrip_RichTextBox.Size = new System.Drawing.Size(106, 92);
         // 
         // toolStripMenuItem_Red
         // 
         this.toolStripMenuItem_Red.ForeColor = System.Drawing.Color.Red;
         this.toolStripMenuItem_Red.Name = "toolStripMenuItem_Red";
         this.toolStripMenuItem_Red.Size = new System.Drawing.Size(105, 22);
         this.toolStripMenuItem_Red.Text = "Red";
         this.toolStripMenuItem_Red.Click += new System.EventHandler(this.toolStripMenuItem_Red_Click);
         // 
         // toolStripMenuItem_Green
         // 
         this.toolStripMenuItem_Green.ForeColor = System.Drawing.Color.Green;
         this.toolStripMenuItem_Green.Name = "toolStripMenuItem_Green";
         this.toolStripMenuItem_Green.Size = new System.Drawing.Size(105, 22);
         this.toolStripMenuItem_Green.Text = "Green";
         this.toolStripMenuItem_Green.Click += new System.EventHandler(this.toolStripMenuItem_Green_Click);
         // 
         // toolStripMenuItem_Blue
         // 
         this.toolStripMenuItem_Blue.ForeColor = System.Drawing.Color.DarkBlue;
         this.toolStripMenuItem_Blue.Name = "toolStripMenuItem_Blue";
         this.toolStripMenuItem_Blue.Size = new System.Drawing.Size(105, 22);
         this.toolStripMenuItem_Blue.Text = "Blue";
         this.toolStripMenuItem_Blue.Click += new System.EventHandler(this.toolStripMenuItem_Blue_Click);
         // 
         // toolStripMenuItem_Bold
         // 
         this.toolStripMenuItem_Bold.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
         this.toolStripMenuItem_Bold.Name = "toolStripMenuItem_Bold";
         this.toolStripMenuItem_Bold.Size = new System.Drawing.Size(105, 22);
         this.toolStripMenuItem_Bold.Text = "Bold";
         this.toolStripMenuItem_Bold.Click += new System.EventHandler(this.toolStripMenuItem_Bold_Click);
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.ColumnCount = 2;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.57288F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.42712F));
         this.tableLayoutPanel2.Controls.Add(this.label_infoText, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.label_PersonName, 0, 0);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 1;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(1286, 36);
         this.tableLayoutPanel2.TabIndex = 12;
         // 
         // label_infoText
         // 
         this.label_infoText.AutoSize = true;
         this.label_infoText.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label_infoText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label_infoText.ForeColor = System.Drawing.Color.DarkBlue;
         this.label_infoText.Location = new System.Drawing.Point(717, 0);
         this.label_infoText.Name = "label_infoText";
         this.label_infoText.Size = new System.Drawing.Size(566, 36);
         this.label_infoText.TabIndex = 1;
         this.label_infoText.Text = "Info";
         this.label_infoText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label_PersonName
         // 
         this.label_PersonName.AutoSize = true;
         this.label_PersonName.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label_PersonName.Font = new System.Drawing.Font("Arial", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label_PersonName.ForeColor = System.Drawing.Color.DarkBlue;
         this.label_PersonName.Location = new System.Drawing.Point(3, 0);
         this.label_PersonName.Name = "label_PersonName";
         this.label_PersonName.Size = new System.Drawing.Size(708, 36);
         this.label_PersonName.TabIndex = 0;
         this.label_PersonName.Text = "ФИО";
         this.label_PersonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tabPage2
         // 
         this.tabPage2.Controls.Add(this.button_SavePersonalData);
         this.tabPage2.Controls.Add(this.groupBox1);
         this.tabPage2.Controls.Add(this.groupBox2);
         this.tabPage2.Location = new System.Drawing.Point(4, 34);
         this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
         this.tabPage2.Name = "tabPage2";
         this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
         this.tabPage2.Size = new System.Drawing.Size(1290, 668);
         this.tabPage2.TabIndex = 1;
         this.tabPage2.Text = "Подробные данные";
         this.tabPage2.UseVisualStyleBackColor = true;
         // 
         // button_SavePersonalData
         // 
         this.button_SavePersonalData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.button_SavePersonalData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.button_SavePersonalData.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_SavePersonalData.Location = new System.Drawing.Point(4, 596);
         this.button_SavePersonalData.Margin = new System.Windows.Forms.Padding(2);
         this.button_SavePersonalData.Name = "button_SavePersonalData";
         this.button_SavePersonalData.Size = new System.Drawing.Size(251, 54);
         this.button_SavePersonalData.TabIndex = 2;
         this.button_SavePersonalData.Text = "Сохранить";
         this.button_SavePersonalData.UseVisualStyleBackColor = false;
         this.button_SavePersonalData.Click += new System.EventHandler(this.button_SavePersonalData_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.tableLayoutPanel3);
         this.groupBox1.Location = new System.Drawing.Point(362, 15);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(888, 620);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Детальные данные";
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel3.ColumnCount = 2;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0591F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.9409F));
         this.tableLayoutPanel3.Controls.Add(this.dateTimePicker_End, 1, 21);
         this.tableLayoutPanel3.Controls.Add(this.dateTimePicker_Activation, 1, 20);
         this.tableLayoutPanel3.Controls.Add(this.label18, 0, 21);
         this.tableLayoutPanel3.Controls.Add(this.dateTimePicker_Buy, 1, 19);
         this.tableLayoutPanel3.Controls.Add(this.label17, 0, 20);
         this.tableLayoutPanel3.Controls.Add(this.textBox_Ostalos_Aerob, 1, 18);
         this.tableLayoutPanel3.Controls.Add(this.label16, 0, 19);
         this.tableLayoutPanel3.Controls.Add(this.textBox_Ostalos_Person, 1, 17);
         this.tableLayoutPanel3.Controls.Add(this.label23, 0, 18);
         this.tableLayoutPanel3.Controls.Add(this.textBox_Ostalos_Dney, 1, 16);
         this.tableLayoutPanel3.Controls.Add(this.label14, 0, 17);
         this.tableLayoutPanel3.Controls.Add(this.comboBox_Spa, 1, 15);
         this.tableLayoutPanel3.Controls.Add(this.label21, 0, 16);
         this.tableLayoutPanel3.Controls.Add(this.comboBox_TrenTypes, 1, 14);
         this.tableLayoutPanel3.Controls.Add(this.label13, 0, 15);
         this.tableLayoutPanel3.Controls.Add(this.comboBox_Type, 1, 13);
         this.tableLayoutPanel3.Controls.Add(this.label11, 0, 14);
         this.tableLayoutPanel3.Controls.Add(this.comboBox_timeVisit, 1, 5);
         this.tableLayoutPanel3.Controls.Add(this.label10, 0, 13);
         this.tableLayoutPanel3.Controls.Add(this.comboBox_activation, 1, 2);
         this.tableLayoutPanel3.Controls.Add(this.label12, 0, 5);
         this.tableLayoutPanel3.Controls.Add(this.comboBox_status, 1, 1);
         this.tableLayoutPanel3.Controls.Add(this.label9, 0, 2);
         this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
         this.tableLayoutPanel3.Controls.Add(this.textBox_name_Person, 1, 0);
         this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
         this.tableLayoutPanel3.Controls.Add(this.label15, 0, 7);
         this.tableLayoutPanel3.Controls.Add(this.comboBox_Payment, 1, 7);
         this.tableLayoutPanel3.Location = new System.Drawing.Point(23, 48);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 23;
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
         this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
         this.tableLayoutPanel3.Size = new System.Drawing.Size(846, 454);
         this.tableLayoutPanel3.TabIndex = 4;
         // 
         // dateTimePicker_End
         // 
         this.dateTimePicker_End.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dateTimePicker_End.Enabled = false;
         this.dateTimePicker_End.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.dateTimePicker_End.Location = new System.Drawing.Point(214, 419);
         this.dateTimePicker_End.Name = "dateTimePicker_End";
         this.dateTimePicker_End.Size = new System.Drawing.Size(629, 26);
         this.dateTimePicker_End.TabIndex = 1;
         this.dateTimePicker_End.ValueChanged += new System.EventHandler(this.dateTimePicker_End_ValueChanged);
         // 
         // dateTimePicker_Activation
         // 
         this.dateTimePicker_Activation.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dateTimePicker_Activation.Enabled = false;
         this.dateTimePicker_Activation.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.dateTimePicker_Activation.Location = new System.Drawing.Point(214, 387);
         this.dateTimePicker_Activation.Name = "dateTimePicker_Activation";
         this.dateTimePicker_Activation.Size = new System.Drawing.Size(629, 26);
         this.dateTimePicker_Activation.TabIndex = 1;
         this.dateTimePicker_Activation.ValueChanged += new System.EventHandler(this.dateTimePicker_Activation_ValueChanged);
         // 
         // label18
         // 
         this.label18.AutoSize = true;
         this.label18.Dock = System.Windows.Forms.DockStyle.Left;
         this.label18.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label18.Location = new System.Drawing.Point(3, 416);
         this.label18.Name = "label18";
         this.label18.Size = new System.Drawing.Size(130, 32);
         this.label18.TabIndex = 0;
         this.label18.Text = "Дата Окончания:";
         this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // dateTimePicker_Buy
         // 
         this.dateTimePicker_Buy.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dateTimePicker_Buy.Enabled = false;
         this.dateTimePicker_Buy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.dateTimePicker_Buy.Location = new System.Drawing.Point(214, 355);
         this.dateTimePicker_Buy.Name = "dateTimePicker_Buy";
         this.dateTimePicker_Buy.Size = new System.Drawing.Size(629, 26);
         this.dateTimePicker_Buy.TabIndex = 1;
         // 
         // label17
         // 
         this.label17.AutoSize = true;
         this.label17.Dock = System.Windows.Forms.DockStyle.Left;
         this.label17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label17.Location = new System.Drawing.Point(3, 384);
         this.label17.Name = "label17";
         this.label17.Size = new System.Drawing.Size(128, 32);
         this.label17.TabIndex = 0;
         this.label17.Text = "Дата Активации:";
         this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // textBox_Ostalos_Aerob
         // 
         this.textBox_Ostalos_Aerob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBox_Ostalos_Aerob.Enabled = false;
         this.textBox_Ostalos_Aerob.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox_Ostalos_Aerob.Location = new System.Drawing.Point(214, 323);
         this.textBox_Ostalos_Aerob.Name = "textBox_Ostalos_Aerob";
         this.textBox_Ostalos_Aerob.Size = new System.Drawing.Size(629, 26);
         this.textBox_Ostalos_Aerob.TabIndex = 3;
         this.textBox_Ostalos_Aerob.TextChanged += new System.EventHandler(this.textBox_Ostalos_Aerob_TextChanged);
         this.textBox_Ostalos_Aerob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Ostalos_Aerob_KeyPress);
         // 
         // label16
         // 
         this.label16.AutoSize = true;
         this.label16.Dock = System.Windows.Forms.DockStyle.Left;
         this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label16.Location = new System.Drawing.Point(3, 352);
         this.label16.Name = "label16";
         this.label16.Size = new System.Drawing.Size(109, 32);
         this.label16.TabIndex = 0;
         this.label16.Text = "Дата Покупки:";
         this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // textBox_Ostalos_Person
         // 
         this.textBox_Ostalos_Person.Dock = System.Windows.Forms.DockStyle.Fill;
         this.textBox_Ostalos_Person.Enabled = false;
         this.textBox_Ostalos_Person.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox_Ostalos_Person.Location = new System.Drawing.Point(214, 291);
         this.textBox_Ostalos_Person.Name = "textBox_Ostalos_Person";
         this.textBox_Ostalos_Person.Size = new System.Drawing.Size(629, 26);
         this.textBox_Ostalos_Person.TabIndex = 3;
         this.textBox_Ostalos_Person.TextChanged += new System.EventHandler(this.textBox_Ostalos_Person_TextChanged);
         this.textBox_Ostalos_Person.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Ostalos_Person_KeyPress);
         // 
         // label23
         // 
         this.label23.AutoSize = true;
         this.label23.Dock = System.Windows.Forms.DockStyle.Left;
         this.label23.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label23.Location = new System.Drawing.Point(3, 320);
         this.label23.Name = "label23";
         this.label23.Size = new System.Drawing.Size(159, 32);
         this.label23.TabIndex = 0;
         this.label23.Text = "Осталось Аэробных:";
         this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // textBox_Ostalos_Dney
         // 
         this.textBox_Ostalos_Dney.Dock = System.Windows.Forms.DockStyle.Fill;
         this.textBox_Ostalos_Dney.Enabled = false;
         this.textBox_Ostalos_Dney.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox_Ostalos_Dney.Location = new System.Drawing.Point(214, 259);
         this.textBox_Ostalos_Dney.Name = "textBox_Ostalos_Dney";
         this.textBox_Ostalos_Dney.Size = new System.Drawing.Size(629, 26);
         this.textBox_Ostalos_Dney.TabIndex = 2;
         this.textBox_Ostalos_Dney.TextChanged += new System.EventHandler(this.textBox_Ostalos_Dney_TextChanged);
         this.textBox_Ostalos_Dney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Ostalos_Dney_KeyPress);
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Dock = System.Windows.Forms.DockStyle.Left;
         this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label14.Location = new System.Drawing.Point(3, 288);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(193, 32);
         this.label14.TabIndex = 0;
         this.label14.Text = "Осталось Персональных:";
         this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // comboBox_Spa
         // 
         this.comboBox_Spa.Dock = System.Windows.Forms.DockStyle.Fill;
         this.comboBox_Spa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_Spa.Enabled = false;
         this.comboBox_Spa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_Spa.FormattingEnabled = true;
         this.comboBox_Spa.Location = new System.Drawing.Point(214, 227);
         this.comboBox_Spa.Name = "comboBox_Spa";
         this.comboBox_Spa.Size = new System.Drawing.Size(629, 26);
         this.comboBox_Spa.TabIndex = 6;
         this.comboBox_Spa.SelectedIndexChanged += new System.EventHandler(this.comboBox_Spa_SelectedIndexChanged);
         // 
         // label21
         // 
         this.label21.AutoSize = true;
         this.label21.Dock = System.Windows.Forms.DockStyle.Left;
         this.label21.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label21.Location = new System.Drawing.Point(3, 256);
         this.label21.Name = "label21";
         this.label21.Size = new System.Drawing.Size(122, 32);
         this.label21.TabIndex = 0;
         this.label21.Text = "Осталось Дней:";
         this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // comboBox_TrenTypes
         // 
         this.comboBox_TrenTypes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.comboBox_TrenTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_TrenTypes.Enabled = false;
         this.comboBox_TrenTypes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_TrenTypes.FormattingEnabled = true;
         this.comboBox_TrenTypes.Location = new System.Drawing.Point(214, 195);
         this.comboBox_TrenTypes.Name = "comboBox_TrenTypes";
         this.comboBox_TrenTypes.Size = new System.Drawing.Size(629, 26);
         this.comboBox_TrenTypes.TabIndex = 5;
         this.comboBox_TrenTypes.SelectedIndexChanged += new System.EventHandler(this.comboBox_TrenTypes_SelectedIndexChanged);
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Dock = System.Windows.Forms.DockStyle.Left;
         this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label13.Location = new System.Drawing.Point(3, 224);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(91, 32);
         this.label13.TabIndex = 0;
         this.label13.Text = "Услуги Спа:";
         this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // comboBox_Type
         // 
         this.comboBox_Type.Dock = System.Windows.Forms.DockStyle.Fill;
         this.comboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_Type.Enabled = false;
         this.comboBox_Type.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_Type.FormattingEnabled = true;
         this.comboBox_Type.Location = new System.Drawing.Point(214, 163);
         this.comboBox_Type.Name = "comboBox_Type";
         this.comboBox_Type.Size = new System.Drawing.Size(629, 26);
         this.comboBox_Type.TabIndex = 4;
         this.comboBox_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox_Type_SelectedIndexChanged);
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Dock = System.Windows.Forms.DockStyle.Left;
         this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label11.Location = new System.Drawing.Point(3, 192);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(179, 32);
         this.label11.TabIndex = 0;
         this.label11.Text = "Доступные Тренировки:";
         this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // comboBox_timeVisit
         // 
         this.comboBox_timeVisit.Dock = System.Windows.Forms.DockStyle.Fill;
         this.comboBox_timeVisit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_timeVisit.Enabled = false;
         this.comboBox_timeVisit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_timeVisit.FormattingEnabled = true;
         this.comboBox_timeVisit.Location = new System.Drawing.Point(214, 99);
         this.comboBox_timeVisit.Name = "comboBox_timeVisit";
         this.comboBox_timeVisit.Size = new System.Drawing.Size(629, 26);
         this.comboBox_timeVisit.TabIndex = 4;
         this.comboBox_timeVisit.SelectedIndexChanged += new System.EventHandler(this.comboBox_timeVisit_SelectedIndexChanged);
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Dock = System.Windows.Forms.DockStyle.Left;
         this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label10.Location = new System.Drawing.Point(3, 160);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(188, 32);
         this.label10.TabIndex = 0;
         this.label10.Text = "Тип Карты / Абонемента:";
         this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // comboBox_activation
         // 
         this.comboBox_activation.Dock = System.Windows.Forms.DockStyle.Fill;
         this.comboBox_activation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_activation.Enabled = false;
         this.comboBox_activation.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_activation.FormattingEnabled = true;
         this.comboBox_activation.Location = new System.Drawing.Point(214, 67);
         this.comboBox_activation.Name = "comboBox_activation";
         this.comboBox_activation.Size = new System.Drawing.Size(629, 26);
         this.comboBox_activation.TabIndex = 3;
         this.comboBox_activation.SelectedIndexChanged += new System.EventHandler(this.comboBox_activation_SelectedIndexChanged);
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Dock = System.Windows.Forms.DockStyle.Left;
         this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label12.Location = new System.Drawing.Point(3, 96);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(147, 32);
         this.label12.TabIndex = 0;
         this.label12.Text = "Время Посещения:";
         this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // comboBox_status
         // 
         this.comboBox_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBox_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_status.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_status.FormattingEnabled = true;
         this.comboBox_status.Location = new System.Drawing.Point(214, 35);
         this.comboBox_status.Name = "comboBox_status";
         this.comboBox_status.Size = new System.Drawing.Size(629, 26);
         this.comboBox_status.TabIndex = 2;
         this.comboBox_status.SelectedIndexChanged += new System.EventHandler(this.comboBox_status_SelectedIndexChanged);
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Dock = System.Windows.Forms.DockStyle.Left;
         this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label9.Location = new System.Drawing.Point(3, 64);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(89, 32);
         this.label9.TabIndex = 0;
         this.label9.Text = "Активация:";
         this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Dock = System.Windows.Forms.DockStyle.Left;
         this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label8.Location = new System.Drawing.Point(3, 32);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(62, 32);
         this.label8.TabIndex = 0;
         this.label8.Text = "Cтатус:";
         this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // textBox_name_Person
         // 
         this.textBox_name_Person.Dock = System.Windows.Forms.DockStyle.Fill;
         this.textBox_name_Person.Enabled = false;
         this.textBox_name_Person.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox_name_Person.Location = new System.Drawing.Point(214, 3);
         this.textBox_name_Person.Name = "textBox_name_Person";
         this.textBox_name_Person.Size = new System.Drawing.Size(629, 26);
         this.textBox_name_Person.TabIndex = 1;
         this.textBox_name_Person.TextChanged += new System.EventHandler(this.textBox_name_Person_TextChanged);
         this.textBox_name_Person.Leave += new System.EventHandler(this.textBox_name_Person_Leave);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Dock = System.Windows.Forms.DockStyle.Left;
         this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label2.Location = new System.Drawing.Point(3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(104, 32);
         this.label2.TabIndex = 0;
         this.label2.Text = "Имя клиента:";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label15
         // 
         this.label15.AutoSize = true;
         this.label15.Dock = System.Windows.Forms.DockStyle.Left;
         this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label15.Location = new System.Drawing.Point(3, 128);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(65, 32);
         this.label15.TabIndex = 0;
         this.label15.Text = "Оплата:";
         this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // comboBox_Payment
         // 
         this.comboBox_Payment.Dock = System.Windows.Forms.DockStyle.Fill;
         this.comboBox_Payment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_Payment.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_Payment.FormattingEnabled = true;
         this.comboBox_Payment.Location = new System.Drawing.Point(214, 131);
         this.comboBox_Payment.Name = "comboBox_Payment";
         this.comboBox_Payment.Size = new System.Drawing.Size(629, 26);
         this.comboBox_Payment.TabIndex = 4;
         this.comboBox_Payment.SelectedIndexChanged += new System.EventHandler(this.comboBox_Payment_SelectedIndexChanged);
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.groupBox2.Controls.Add(this.tableLayoutPanel1);
         this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.groupBox2.Location = new System.Drawing.Point(7, 15);
         this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
         this.groupBox2.Size = new System.Drawing.Size(341, 258);
         this.groupBox2.TabIndex = 0;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Персональные данные";
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
         this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
         this.tableLayoutPanel1.Controls.Add(this.maskedTextBox_PhoneNumber, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.maskedTextBox_Passport, 1, 3);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
         this.tableLayoutPanel1.Controls.Add(this.maskedTextBox_DriverID, 1, 4);
         this.tableLayoutPanel1.Controls.Add(this.label_Phone, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.dateTimePicker_birthDate, 1, 6);
         this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 13);
         this.tableLayoutPanel1.Controls.Add(this.comboBox_Gender, 1, 5);
         this.tableLayoutPanel1.Controls.Add(this.textBox_Number, 1, 13);
         this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 24);
         this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 15;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(333, 208);
         this.tableLayoutPanel1.TabIndex = 1;
         // 
         // label4
         // 
         this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label4.Location = new System.Drawing.Point(2, 124);
         this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(124, 17);
         this.label4.TabIndex = 5;
         this.label4.Text = "День    Рождения";
         // 
         // label6
         // 
         this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label6.Location = new System.Drawing.Point(2, 66);
         this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(124, 17);
         this.label6.TabIndex = 2;
         this.label6.Text = "Права";
         this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // maskedTextBox_PhoneNumber
         // 
         this.maskedTextBox_PhoneNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.maskedTextBox_PhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.maskedTextBox_PhoneNumber.Location = new System.Drawing.Point(130, 2);
         this.maskedTextBox_PhoneNumber.Margin = new System.Windows.Forms.Padding(2);
         this.maskedTextBox_PhoneNumber.Mask = "8(999) 000-00-00";
         this.maskedTextBox_PhoneNumber.Name = "maskedTextBox_PhoneNumber";
         this.maskedTextBox_PhoneNumber.Size = new System.Drawing.Size(190, 29);
         this.maskedTextBox_PhoneNumber.TabIndex = 6;
         this.maskedTextBox_PhoneNumber.TextChanged += new System.EventHandler(this.maskedTextBox_PhoneNumber_TextChanged);
         // 
         // maskedTextBox_Passport
         // 
         this.maskedTextBox_Passport.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.maskedTextBox_Passport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.maskedTextBox_Passport.Location = new System.Drawing.Point(130, 35);
         this.maskedTextBox_Passport.Margin = new System.Windows.Forms.Padding(2);
         this.maskedTextBox_Passport.Mask = "9999   № 999999";
         this.maskedTextBox_Passport.Name = "maskedTextBox_Passport";
         this.maskedTextBox_Passport.Size = new System.Drawing.Size(190, 24);
         this.maskedTextBox_Passport.TabIndex = 4;
         this.maskedTextBox_Passport.TextChanged += new System.EventHandler(this.maskedTex_Passport_TextChanged);
         // 
         // label3
         // 
         this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label3.Location = new System.Drawing.Point(2, 38);
         this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(64, 17);
         this.label3.TabIndex = 8;
         this.label3.Text = "Паспорт";
         // 
         // maskedTextBox_DriverID
         // 
         this.maskedTextBox_DriverID.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.maskedTextBox_DriverID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.maskedTextBox_DriverID.Location = new System.Drawing.Point(130, 63);
         this.maskedTextBox_DriverID.Margin = new System.Windows.Forms.Padding(2);
         this.maskedTextBox_DriverID.Mask = "9999   № 999999";
         this.maskedTextBox_DriverID.Name = "maskedTextBox_DriverID";
         this.maskedTextBox_DriverID.Size = new System.Drawing.Size(190, 24);
         this.maskedTextBox_DriverID.TabIndex = 0;
         this.maskedTextBox_DriverID.TextChanged += new System.EventHandler(this.maskedTextBox_DriverID_TextChanged);
         // 
         // label_Phone
         // 
         this.label_Phone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.label_Phone.AutoSize = true;
         this.label_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label_Phone.Location = new System.Drawing.Point(2, 8);
         this.label_Phone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label_Phone.Name = "label_Phone";
         this.label_Phone.Size = new System.Drawing.Size(124, 17);
         this.label_Phone.TabIndex = 7;
         this.label_Phone.Text = "Телефон";
         // 
         // label5
         // 
         this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label5.Location = new System.Drawing.Point(2, 95);
         this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(34, 17);
         this.label5.TabIndex = 7;
         this.label5.Text = "Пол";
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label1.Location = new System.Drawing.Point(2, 155);
         this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(115, 17);
         this.label1.TabIndex = 4;
         this.label1.Text = "Личный   Номер";
         // 
         // comboBox_Gender
         // 
         this.comboBox_Gender.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.comboBox_Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_Gender.FormattingEnabled = true;
         this.comboBox_Gender.Location = new System.Drawing.Point(130, 91);
         this.comboBox_Gender.Margin = new System.Windows.Forms.Padding(2);
         this.comboBox_Gender.Name = "comboBox_Gender";
         this.comboBox_Gender.Size = new System.Drawing.Size(190, 26);
         this.comboBox_Gender.TabIndex = 2;
         this.comboBox_Gender.SelectedIndexChanged += new System.EventHandler(this.comboBox_Gender_SelectedIndexChanged);
         // 
         // textBox_Number
         // 
         this.textBox_Number.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.textBox_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox_Number.Location = new System.Drawing.Point(130, 149);
         this.textBox_Number.Margin = new System.Windows.Forms.Padding(2);
         this.textBox_Number.Name = "textBox_Number";
         this.textBox_Number.Size = new System.Drawing.Size(190, 29);
         this.textBox_Number.TabIndex = 5;
         this.textBox_Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         this.textBox_Number.TextChanged += new System.EventHandler(this.textBox_Number_TextChanged);
         this.textBox_Number.Leave += new System.EventHandler(this.textBox_Number_Leave);
         // 
         // tabPage3
         // 
         this.tabPage3.Controls.Add(this.dataGridView_Visits);
         this.tabPage3.Location = new System.Drawing.Point(4, 34);
         this.tabPage3.Name = "tabPage3";
         this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage3.Size = new System.Drawing.Size(1290, 668);
         this.tabPage3.TabIndex = 2;
         this.tabPage3.Text = "Посещения";
         this.tabPage3.UseVisualStyleBackColor = true;
         // 
         // dataGridView_Visits
         // 
         this.dataGridView_Visits.AllowUserToOrderColumns = true;
         this.dataGridView_Visits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.dataGridView_Visits.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
         this.dataGridView_Visits.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.dataGridView_Visits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView_Visits.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView_Visits.Location = new System.Drawing.Point(3, 3);
         this.dataGridView_Visits.Name = "dataGridView_Visits";
         this.dataGridView_Visits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dataGridView_Visits.Size = new System.Drawing.Size(1284, 662);
         this.dataGridView_Visits.TabIndex = 0;
         // 
         // tabPage_abon_history
         // 
         this.tabPage_abon_history.Controls.Add(this.dataGridView_history_abonements);
         this.tabPage_abon_history.Location = new System.Drawing.Point(4, 34);
         this.tabPage_abon_history.Name = "tabPage_abon_history";
         this.tabPage_abon_history.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage_abon_history.Size = new System.Drawing.Size(1290, 668);
         this.tabPage_abon_history.TabIndex = 3;
         this.tabPage_abon_history.Text = "Архив Абонементов";
         this.tabPage_abon_history.UseVisualStyleBackColor = true;
         // 
         // dataGridView_history_abonements
         // 
         this.dataGridView_history_abonements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView_history_abonements.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView_history_abonements.Location = new System.Drawing.Point(3, 3);
         this.dataGridView_history_abonements.Name = "dataGridView_history_abonements";
         this.dataGridView_history_abonements.Size = new System.Drawing.Size(1284, 662);
         this.dataGridView_history_abonements.TabIndex = 0;
         // 
         // button_Bold
         // 
         this.button_Bold.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_Bold.Location = new System.Drawing.Point(233, 3);
         this.button_Bold.Name = "button_Bold";
         this.button_Bold.Size = new System.Drawing.Size(65, 31);
         this.button_Bold.TabIndex = 8;
         this.button_Bold.Text = "Bold";
         this.button_Bold.UseVisualStyleBackColor = true;
         this.button_Bold.Click += new System.EventHandler(this.button_Bold_Click);
         // 
         // button_Red
         // 
         this.button_Red.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_Red.ForeColor = System.Drawing.Color.Red;
         this.button_Red.Location = new System.Drawing.Point(20, 3);
         this.button_Red.Name = "button_Red";
         this.button_Red.Size = new System.Drawing.Size(65, 31);
         this.button_Red.TabIndex = 7;
         this.button_Red.Text = "Red";
         this.button_Red.UseVisualStyleBackColor = false;
         this.button_Red.Click += new System.EventHandler(this.button_Red_Click);
         // 
         // button1
         // 
         this.button1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button1.Location = new System.Drawing.Point(304, 3);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(161, 31);
         this.button1.TabIndex = 7;
         this.button1.Text = "Сброс формата";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button_Clear_Selection_Click);
         // 
         // tableLayoutPanel4
         // 
         this.tableLayoutPanel4.AutoSize = true;
         this.tableLayoutPanel4.ColumnCount = 4;
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 261F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel2, 1, 0);
         this.tableLayoutPanel4.Controls.Add(this.button2, 3, 0);
         this.tableLayoutPanel4.Controls.Add(this.button_Cancel, 0, 0);
         this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 710);
         this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
         this.tableLayoutPanel4.Name = "tableLayoutPanel4";
         this.tableLayoutPanel4.RowCount = 1;
         this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
         this.tableLayoutPanel4.Size = new System.Drawing.Size(1298, 40);
         this.tableLayoutPanel4.TabIndex = 2;
         // 
         // flowLayoutPanel2
         // 
         this.flowLayoutPanel2.Controls.Add(this.button1);
         this.flowLayoutPanel2.Controls.Add(this.button_Bold);
         this.flowLayoutPanel2.Controls.Add(this.button_Blue);
         this.flowLayoutPanel2.Controls.Add(this.button_Green);
         this.flowLayoutPanel2.Controls.Add(this.button_Red);
         this.flowLayoutPanel2.Location = new System.Drawing.Point(264, 3);
         this.flowLayoutPanel2.Name = "flowLayoutPanel2";
         this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.flowLayoutPanel2.Size = new System.Drawing.Size(468, 34);
         this.flowLayoutPanel2.TabIndex = 7;
         // 
         // button_Blue
         // 
         this.button_Blue.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_Blue.ForeColor = System.Drawing.Color.DarkBlue;
         this.button_Blue.Location = new System.Drawing.Point(162, 3);
         this.button_Blue.Name = "button_Blue";
         this.button_Blue.Size = new System.Drawing.Size(65, 31);
         this.button_Blue.TabIndex = 7;
         this.button_Blue.Text = "Blue";
         this.button_Blue.UseVisualStyleBackColor = false;
         this.button_Blue.Click += new System.EventHandler(this.button_Blue_Click);
         // 
         // button_Green
         // 
         this.button_Green.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_Green.ForeColor = System.Drawing.Color.Green;
         this.button_Green.Location = new System.Drawing.Point(91, 3);
         this.button_Green.Name = "button_Green";
         this.button_Green.Size = new System.Drawing.Size(65, 31);
         this.button_Green.TabIndex = 7;
         this.button_Green.Text = "Green";
         this.button_Green.UseVisualStyleBackColor = false;
         this.button_Green.Click += new System.EventHandler(this.button_Green_Click);
         // 
         // button2
         // 
         this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button2.Location = new System.Drawing.Point(1121, 2);
         this.button2.Margin = new System.Windows.Forms.Padding(2);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(175, 34);
         this.button2.TabIndex = 5;
         this.button2.TabStop = false;
         this.button2.Text = "Доступ Руководителя";
         this.button2.UseVisualStyleBackColor = false;
         this.button2.Click += new System.EventHandler(this.button_Password_Click);
         // 
         // button_Cancel
         // 
         this.button_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button_Cancel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_Cancel.Location = new System.Drawing.Point(2, 2);
         this.button_Cancel.Margin = new System.Windows.Forms.Padding(2);
         this.button_Cancel.Name = "button_Cancel";
         this.button_Cancel.Size = new System.Drawing.Size(257, 36);
         this.button_Cancel.TabIndex = 3;
         this.button_Cancel.Text = "Закрыть";
         this.button_Cancel.UseVisualStyleBackColor = true;
         this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
         // 
         // pictureBox_ClientPhoto
         // 
         this.pictureBox_ClientPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pictureBox_ClientPhoto.Image = global::PersonsBase.Properties.Resources.No_Photo;
         this.pictureBox_ClientPhoto.Location = new System.Drawing.Point(10, 51);
         this.pictureBox_ClientPhoto.Margin = new System.Windows.Forms.Padding(2);
         this.pictureBox_ClientPhoto.Name = "pictureBox_ClientPhoto";
         this.pictureBox_ClientPhoto.Size = new System.Drawing.Size(250, 193);
         this.pictureBox_ClientPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox_ClientPhoto.TabIndex = 0;
         this.pictureBox_ClientPhoto.TabStop = false;
         this.pictureBox_ClientPhoto.DoubleClick += new System.EventHandler(this.pictureBox_ClientPhoto_DoubleClick);
         // 
         // button_photo_cam
         // 
         this.button_photo_cam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.button_photo_cam.BackgroundImage = global::PersonsBase.Properties.Resources.icons8_камера_100;
         this.button_photo_cam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.button_photo_cam.Location = new System.Drawing.Point(9, 49);
         this.button_photo_cam.Name = "button_photo_cam";
         this.button_photo_cam.Size = new System.Drawing.Size(216, 32);
         this.button_photo_cam.TabIndex = 13;
         this.button_photo_cam.UseVisualStyleBackColor = true;
         this.button_photo_cam.Click += new System.EventHandler(this.button_photo_cam_Click);
         // 
         // ClientForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1298, 750);
         this.Controls.Add(this.tableLayoutPanel4);
         this.Controls.Add(this.tabControl1);
         this.DoubleBuffered = true;
         this.Margin = new System.Windows.Forms.Padding(2);
         this.Name = "ClientForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Карточка Клиента";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
         this.Load += new System.EventHandler(this.ClientForm_Load);
         this.tabControl1.ResumeLayout(false);
         this.tabPage1.ResumeLayout(false);
         this.groupBox_buttons.ResumeLayout(false);
         this.flowLayoutPanel_MainButtons.ResumeLayout(false);
         this.groupBox_PhotoButtons.ResumeLayout(false);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.groupBox_AbonLists.ResumeLayout(false);
         this.groupBox_AbonLists.PerformLayout();
         this.contextMenuStrip_RichTextBox.ResumeLayout(false);
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.tabPage2.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel3.ResumeLayout(false);
         this.tableLayoutPanel3.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.tabPage3.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Visits)).EndInit();
         this.tabPage_abon_history.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView_history_abonements)).EndInit();
         this.tableLayoutPanel4.ResumeLayout(false);
         this.flowLayoutPanel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClientPhoto)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion
        [NonSerialized]
        private TabControl tabControl1;
        [NonSerialized]
        private TabPage tabPage1;
        [NonSerialized]
        private TabPage tabPage2;
        [NonSerialized]
        private GroupBox groupBox2;
        [NonSerialized]
        private MaskedTextBox maskedTextBox_DriverID;
        [NonSerialized]
        private TextBox textBox_Number;
        [NonSerialized]
        private Label label1;
        [NonSerialized]
        private DateTimePicker dateTimePicker_birthDate;
        [NonSerialized]
        private GroupBox groupBox_Info;
        [NonSerialized]
        private TableLayoutPanel tableLayoutPanel1;
        [NonSerialized]
        private Label label_Phone;
        [NonSerialized]
        private MaskedTextBox maskedTextBox_PhoneNumber;
        [NonSerialized]
        private MaskedTextBox maskedTextBox_Passport;
        [NonSerialized]
        private Label label3;
        [NonSerialized]
        private Label label6;
        [NonSerialized]
        private Label label4;
        [NonSerialized]
        private Label label5;
        private ComboBox comboBox_Gender;
        private Button button_SavePersonalData;
        private PictureBox pictureBox_ClientPhoto;
        private Button button_CheckInWorkout;
        private Button button_Add_Abon;
        private Button button_Freeze;
        private Button button_Cancel;
        private TableLayoutPanel tableLayoutPanel4;
        private Button button_add_dop_tren;
        private Button button_RemoveCurrentAbon;
        private Button button2;
        private Button button_photo;
        private FlowLayoutPanel flowLayoutPanel_MainButtons;
        private TabPage tabPage3;
        private DataGridView dataGridView_Visits;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label_PersonName;
        private Label label_infoText;
        private Button button_photo_cam;
        private TabPage tabPage_abon_history;
        private DataGridView dataGridView_history_abonements;
        private SplitContainer splitContainer1;
        private RichTextBox richTextBox_notes;
        private Button button1;
        private Button button_Red;
        private Button button_Bold;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button_Blue;
        private Button button_Green;
        private ContextMenuStrip contextMenuStrip_RichTextBox;
        private ToolStripMenuItem toolStripMenuItem_Red;
        private ToolStripMenuItem toolStripMenuItem_Green;
        private ToolStripMenuItem toolStripMenuItem_Blue;
        private ToolStripMenuItem toolStripMenuItem_Bold;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox textBox_name_Person;
        private Label label8;
        private ComboBox comboBox_status;
        private ComboBox comboBox_activation;
        private Label label9;
        private ComboBox comboBox_timeVisit;
        private Label label12;
        private ComboBox comboBox_Type;
        private Label label10;
        private ComboBox comboBox_TrenTypes;
        private Label label11;
        private ComboBox comboBox_Spa;
        private Label label13;
        private TextBox textBox_Ostalos_Dney;
        private Label label21;
        private TextBox textBox_Ostalos_Person;
        private Label label14;
        private TextBox textBox_Ostalos_Aerob;
        private Label label23;
        private DateTimePicker dateTimePicker_Buy;
        private Label label16;
        private DateTimePicker dateTimePicker_Activation;
        private Label label17;
        private DateTimePicker dateTimePicker_End;
        private Label label18;
      private TableLayoutPanel tableLayoutPanel3;
      private Label label15;
      private ComboBox comboBox_Payment;
      private GroupBox groupBox_AbonLists;
      private RadioButton radioButton_Valid_Selected;
      private RadioButton radioButton_NotValid_selected;
      private ListView listView_Abonements;
      private ColumnHeader columnHeader_Name;
      private ColumnHeader columnHeader_Type;
      private GroupBox groupBox_buttons;
      private GroupBox groupBox_PhotoButtons;
   }
}