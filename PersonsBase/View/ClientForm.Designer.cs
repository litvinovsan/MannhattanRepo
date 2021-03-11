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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_CheckInWorkout = new System.Windows.Forms.Button();
            this.button_Add_Abon = new System.Windows.Forms.Button();
            this.button_add_dop_tren = new System.Windows.Forms.Button();
            this.button_Freeze = new System.Windows.Forms.Button();
            this.button_RemoveCurrentAbon = new System.Windows.Forms.Button();
            this.groupBox_Abon_NotValid = new System.Windows.Forms.GroupBox();
            this.listBox_NotValidAbons = new System.Windows.Forms.ListBox();
            this.groupBox_Info = new System.Windows.Forms.GroupBox();
            this.groupBox_Abonements = new System.Windows.Forms.GroupBox();
            this.listBox_abon_selector = new System.Windows.Forms.ListBox();
            this.button_photo = new System.Windows.Forms.Button();
            this.pictureBox_ClientPhoto = new System.Windows.Forms.PictureBox();
            this.button_photo_cam = new System.Windows.Forms.Button();
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
            this.groupBox_Detailed = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_SavePersonalData = new System.Windows.Forms.Button();
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox_Abon_NotValid.SuspendLayout();
            this.groupBox_Abonements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClientPhoto)).BeginInit();
            this.contextMenuStrip_RichTextBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Visits)).BeginInit();
            this.tabPage_abon_history.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_history_abonements)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(1312, 676);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1304, 638);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Информация";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 46);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_Abon_NotValid);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_Info);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_Abonements);
            this.splitContainer1.Panel1.Controls.Add(this.button_photo);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox_ClientPhoto);
            this.splitContainer1.Panel1.Controls.Add(this.button_photo_cam);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox_notes);
            this.splitContainer1.Size = new System.Drawing.Size(1291, 587);
            this.splitContainer1.SplitterDistance = 413;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(2, 385);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Заметки";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button_CheckInWorkout);
            this.flowLayoutPanel1.Controls.Add(this.button_Add_Abon);
            this.flowLayoutPanel1.Controls.Add(this.button_add_dop_tren);
            this.flowLayoutPanel1.Controls.Add(this.button_Freeze);
            this.flowLayoutPanel1.Controls.Add(this.button_RemoveCurrentAbon);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(248, 259);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // button_CheckInWorkout
            // 
            this.button_CheckInWorkout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_CheckInWorkout.BackColor = System.Drawing.Color.LightGreen;
            this.button_CheckInWorkout.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_CheckInWorkout.Location = new System.Drawing.Point(2, 2);
            this.button_CheckInWorkout.Margin = new System.Windows.Forms.Padding(2);
            this.button_CheckInWorkout.Name = "button_CheckInWorkout";
            this.button_CheckInWorkout.Size = new System.Drawing.Size(233, 46);
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
            this.button_Add_Abon.Size = new System.Drawing.Size(233, 46);
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
            this.button_add_dop_tren.Size = new System.Drawing.Size(233, 46);
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
            this.button_Freeze.Size = new System.Drawing.Size(233, 46);
            this.button_Freeze.TabIndex = 5;
            this.button_Freeze.Text = "Заморозка";
            this.button_Freeze.UseVisualStyleBackColor = false;
            this.button_Freeze.Click += new System.EventHandler(this.button_Freeze_Click);
            // 
            // button_RemoveCurrentAbon
            // 
            this.button_RemoveCurrentAbon.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_RemoveCurrentAbon.Location = new System.Drawing.Point(2, 202);
            this.button_RemoveCurrentAbon.Margin = new System.Windows.Forms.Padding(2);
            this.button_RemoveCurrentAbon.Name = "button_RemoveCurrentAbon";
            this.button_RemoveCurrentAbon.Size = new System.Drawing.Size(233, 46);
            this.button_RemoveCurrentAbon.TabIndex = 2;
            this.button_RemoveCurrentAbon.Text = "Удалить Абонемент";
            this.button_RemoveCurrentAbon.UseVisualStyleBackColor = false;
            this.button_RemoveCurrentAbon.Visible = false;
            this.button_RemoveCurrentAbon.Click += new System.EventHandler(this.button_remove_current_abon_Click);
            // 
            // groupBox_Abon_NotValid
            // 
            this.groupBox_Abon_NotValid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Abon_NotValid.Controls.Add(this.listBox_NotValidAbons);
            this.groupBox_Abon_NotValid.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_Abon_NotValid.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox_Abon_NotValid.Location = new System.Drawing.Point(1022, 282);
            this.groupBox_Abon_NotValid.Name = "groupBox_Abon_NotValid";
            this.groupBox_Abon_NotValid.Size = new System.Drawing.Size(268, 101);
            this.groupBox_Abon_NotValid.TabIndex = 15;
            this.groupBox_Abon_NotValid.TabStop = false;
            this.groupBox_Abon_NotValid.Text = "Закончились";
            this.groupBox_Abon_NotValid.Visible = false;
            // 
            // listBox_NotValidAbons
            // 
            this.listBox_NotValidAbons.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_NotValidAbons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_NotValidAbons.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_NotValidAbons.FormattingEnabled = true;
            this.listBox_NotValidAbons.ItemHeight = 19;
            this.listBox_NotValidAbons.Location = new System.Drawing.Point(3, 22);
            this.listBox_NotValidAbons.Name = "listBox_NotValidAbons";
            this.listBox_NotValidAbons.Size = new System.Drawing.Size(262, 76);
            this.listBox_NotValidAbons.TabIndex = 14;
            // 
            // groupBox_Info
            // 
            this.groupBox_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_Info.Location = new System.Drawing.Point(266, 4);
            this.groupBox_Info.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Info.Name = "groupBox_Info";
            this.groupBox_Info.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Info.Size = new System.Drawing.Size(741, 379);
            this.groupBox_Info.TabIndex = 4;
            this.groupBox_Info.TabStop = false;
            this.groupBox_Info.Text = "Информация";
            // 
            // groupBox_Abonements
            // 
            this.groupBox_Abonements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_Abonements.Controls.Add(this.listBox_abon_selector);
            this.groupBox_Abonements.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_Abonements.ForeColor = System.Drawing.Color.Green;
            this.groupBox_Abonements.Location = new System.Drawing.Point(13, 277);
            this.groupBox_Abonements.Name = "groupBox_Abonements";
            this.groupBox_Abonements.Size = new System.Drawing.Size(235, 106);
            this.groupBox_Abonements.TabIndex = 7;
            this.groupBox_Abonements.TabStop = false;
            this.groupBox_Abonements.Text = "Действующие";
            this.groupBox_Abonements.Visible = false;
            // 
            // listBox_abon_selector
            // 
            this.listBox_abon_selector.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_abon_selector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_abon_selector.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_abon_selector.FormattingEnabled = true;
            this.listBox_abon_selector.ItemHeight = 19;
            this.listBox_abon_selector.Location = new System.Drawing.Point(3, 22);
            this.listBox_abon_selector.Name = "listBox_abon_selector";
            this.listBox_abon_selector.Size = new System.Drawing.Size(229, 81);
            this.listBox_abon_selector.TabIndex = 14;
            this.listBox_abon_selector.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_abon_selector_MouseClick);
            this.listBox_abon_selector.SelectedIndexChanged += new System.EventHandler(this.listBox_abon_selector_SelectedIndexChanged);
            // 
            // button_photo
            // 
            this.button_photo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_photo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_photo.Location = new System.Drawing.Point(1025, 235);
            this.button_photo.Margin = new System.Windows.Forms.Padding(2);
            this.button_photo.Name = "button_photo";
            this.button_photo.Size = new System.Drawing.Size(265, 42);
            this.button_photo.TabIndex = 4;
            this.button_photo.Text = "Из файла";
            this.button_photo.UseVisualStyleBackColor = true;
            this.button_photo.Click += new System.EventHandler(this.button_photo_Click);
            // 
            // pictureBox_ClientPhoto
            // 
            this.pictureBox_ClientPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_ClientPhoto.Image = global::PersonsBase.Properties.Resources.no_photo_available_icon_20;
            this.pictureBox_ClientPhoto.Location = new System.Drawing.Point(1025, 4);
            this.pictureBox_ClientPhoto.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_ClientPhoto.Name = "pictureBox_ClientPhoto";
            this.pictureBox_ClientPhoto.Size = new System.Drawing.Size(264, 179);
            this.pictureBox_ClientPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ClientPhoto.TabIndex = 0;
            this.pictureBox_ClientPhoto.TabStop = false;
            // 
            // button_photo_cam
            // 
            this.button_photo_cam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_photo_cam.BackgroundImage = global::PersonsBase.Properties.Resources.icons8_камера_100;
            this.button_photo_cam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_photo_cam.Location = new System.Drawing.Point(1025, 188);
            this.button_photo_cam.Name = "button_photo_cam";
            this.button_photo_cam.Size = new System.Drawing.Size(264, 42);
            this.button_photo_cam.TabIndex = 13;
            this.button_photo_cam.UseVisualStyleBackColor = true;
            this.button_photo_cam.Click += new System.EventHandler(this.button_photo_cam_Click);
            // 
            // richTextBox_notes
            // 
            this.richTextBox_notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_notes.ContextMenuStrip = this.contextMenuStrip_RichTextBox;
            this.richTextBox_notes.Font = new System.Drawing.Font("Arial", 14F);
            this.richTextBox_notes.ForeColor = System.Drawing.Color.Black;
            this.richTextBox_notes.HideSelection = false;
            this.richTextBox_notes.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_notes.Name = "richTextBox_notes";
            this.richTextBox_notes.ShowSelectionMargin = true;
            this.richTextBox_notes.Size = new System.Drawing.Size(1282, 160);
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
            this.contextMenuStrip_RichTextBox.Size = new System.Drawing.Size(112, 92);
            // 
            // toolStripMenuItem_Red
            // 
            this.toolStripMenuItem_Red.ForeColor = System.Drawing.Color.Red;
            this.toolStripMenuItem_Red.Name = "toolStripMenuItem_Red";
            this.toolStripMenuItem_Red.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem_Red.Text = "Red";
            this.toolStripMenuItem_Red.Click += new System.EventHandler(this.toolStripMenuItem_Red_Click);
            // 
            // toolStripMenuItem_Green
            // 
            this.toolStripMenuItem_Green.ForeColor = System.Drawing.Color.Green;
            this.toolStripMenuItem_Green.Name = "toolStripMenuItem_Green";
            this.toolStripMenuItem_Green.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem_Green.Text = "Green";
            this.toolStripMenuItem_Green.Click += new System.EventHandler(this.toolStripMenuItem_Green_Click);
            // 
            // toolStripMenuItem_Blue
            // 
            this.toolStripMenuItem_Blue.ForeColor = System.Drawing.Color.DarkBlue;
            this.toolStripMenuItem_Blue.Name = "toolStripMenuItem_Blue";
            this.toolStripMenuItem_Blue.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem_Blue.Text = "Blue";
            this.toolStripMenuItem_Blue.Click += new System.EventHandler(this.toolStripMenuItem_Blue_Click);
            // 
            // toolStripMenuItem_Bold
            // 
            this.toolStripMenuItem_Bold.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem_Bold.Name = "toolStripMenuItem_Bold";
            this.toolStripMenuItem_Bold.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem_Bold.Text = "Bold";
            this.toolStripMenuItem_Bold.Click += new System.EventHandler(this.toolStripMenuItem_Bold_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.57288F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.42712F));
            this.tableLayoutPanel2.Controls.Add(this.label_infoText, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_PersonName, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1283, 36);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // label_infoText
            // 
            this.label_infoText.AutoSize = true;
            this.label_infoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_infoText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_infoText.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_infoText.Location = new System.Drawing.Point(716, 0);
            this.label_infoText.Name = "label_infoText";
            this.label_infoText.Size = new System.Drawing.Size(564, 36);
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
            this.label_PersonName.Size = new System.Drawing.Size(707, 36);
            this.label_PersonName.TabIndex = 0;
            this.label_PersonName.Text = "ФИО";
            this.label_PersonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox_Detailed);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1304, 638);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Подробные данные";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox_Detailed
            // 
            this.groupBox_Detailed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Detailed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_Detailed.Location = new System.Drawing.Point(370, 4);
            this.groupBox_Detailed.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Detailed.Name = "groupBox_Detailed";
            this.groupBox_Detailed.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Detailed.Size = new System.Drawing.Size(927, 626);
            this.groupBox_Detailed.TabIndex = 1;
            this.groupBox_Detailed.TabStop = false;
            this.groupBox_Detailed.Text = "Детальная информация";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_SavePersonalData);
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(7, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(341, 630);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Персональные данные";
            // 
            // button_SavePersonalData
            // 
            this.button_SavePersonalData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_SavePersonalData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_SavePersonalData.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_SavePersonalData.Location = new System.Drawing.Point(3, 572);
            this.button_SavePersonalData.Margin = new System.Windows.Forms.Padding(2);
            this.button_SavePersonalData.Name = "button_SavePersonalData";
            this.button_SavePersonalData.Size = new System.Drawing.Size(334, 54);
            this.button_SavePersonalData.TabIndex = 2;
            this.button_SavePersonalData.Text = "Сохранить";
            this.button_SavePersonalData.UseVisualStyleBackColor = false;
            this.button_SavePersonalData.Click += new System.EventHandler(this.button_SavePersonalData_Click);
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
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView_Visits);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1304, 638);
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
            this.dataGridView_Visits.Size = new System.Drawing.Size(1298, 632);
            this.dataGridView_Visits.TabIndex = 0;
            // 
            // tabPage_abon_history
            // 
            this.tabPage_abon_history.Controls.Add(this.dataGridView_history_abonements);
            this.tabPage_abon_history.Location = new System.Drawing.Point(4, 34);
            this.tabPage_abon_history.Name = "tabPage_abon_history";
            this.tabPage_abon_history.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_abon_history.Size = new System.Drawing.Size(1304, 638);
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
            this.dataGridView_history_abonements.Size = new System.Drawing.Size(1298, 632);
            this.dataGridView_history_abonements.TabIndex = 0;
            // 
            // button_Bold
            // 
            this.button_Bold.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Bold.Location = new System.Drawing.Point(362, 3);
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
            this.button_Red.Location = new System.Drawing.Point(149, 3);
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
            this.button1.Location = new System.Drawing.Point(433, 3);
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
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 349F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.button2, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_Cancel, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 680);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1312, 40);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Controls.Add(this.button_Bold);
            this.flowLayoutPanel2.Controls.Add(this.button_Blue);
            this.flowLayoutPanel2.Controls.Add(this.button_Green);
            this.flowLayoutPanel2.Controls.Add(this.button_Red);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(352, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(597, 34);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // button_Blue
            // 
            this.button_Blue.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Blue.ForeColor = System.Drawing.Color.DarkBlue;
            this.button_Blue.Location = new System.Drawing.Point(291, 3);
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
            this.button_Green.Location = new System.Drawing.Point(220, 3);
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
            this.button2.Location = new System.Drawing.Point(1135, 2);
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
            this.button_Cancel.Size = new System.Drawing.Size(345, 36);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Закрыть";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 720);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1157, 500);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Карточка Клиента";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.Resize += new System.EventHandler(this.ClientForm_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox_Abon_NotValid.ResumeLayout(false);
            this.groupBox_Abonements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClientPhoto)).EndInit();
            this.contextMenuStrip_RichTextBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Visits)).EndInit();
            this.tabPage_abon_history.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_history_abonements)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
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
        private GroupBox groupBox_Detailed;
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
        private FlowLayoutPanel flowLayoutPanel1;
        private TabPage tabPage3;
        private DataGridView dataGridView_Visits;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label_PersonName;
        private Label label_infoText;
        private Button button_photo_cam;
        private TabPage tabPage_abon_history;
        private DataGridView dataGridView_history_abonements;
        private ListBox listBox_abon_selector;
        private GroupBox groupBox_Abonements;
        private GroupBox groupBox_Abon_NotValid;
        private ListBox listBox_NotValidAbons;
        private SplitContainer splitContainer1;
        private RichTextBox richTextBox_notes;
        private Label label7;
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
    }
}