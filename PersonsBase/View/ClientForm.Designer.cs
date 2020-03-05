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
            this.dateTimePicker_birthDate = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Notes = new System.Windows.Forms.TextBox();
            this.button_photo = new System.Windows.Forms.Button();
            this.button_photo_cam = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_infoText = new System.Windows.Forms.Label();
            this.label_PersonName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_CheckInWorkout = new System.Windows.Forms.Button();
            this.button_add_dop_tren = new System.Windows.Forms.Button();
            this.button_Add_Abon = new System.Windows.Forms.Button();
            this.button_Freeze = new System.Windows.Forms.Button();
            this.button_RemoveCurrentAbon = new System.Windows.Forms.Button();
            this.pictureBox_ClientPhoto = new System.Windows.Forms.PictureBox();
            this.groupBox_abonList = new System.Windows.Forms.GroupBox();
            this.button__remove_abon = new System.Windows.Forms.Button();
            this.listBox_abonements = new System.Windows.Forms.ListBox();
            this.groupBox_Info = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox_Detailed = new System.Windows.Forms.GroupBox();
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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_SavePersonalData = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClientPhoto)).BeginInit();
            this.groupBox_abonList.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Visits)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker_birthDate
            // 
            this.dateTimePicker_birthDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker_birthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker_birthDate.Location = new System.Drawing.Point(130, 107);
            this.dateTimePicker_birthDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_birthDate.MinimumSize = new System.Drawing.Size(115, 22);
            this.dateTimePicker_birthDate.Name = "dateTimePicker_birthDate";
            this.dateTimePicker_birthDate.Size = new System.Drawing.Size(166, 23);
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
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1049, 707);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.button_photo);
            this.tabPage1.Controls.Add(this.button_photo_cam);
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.pictureBox_ClientPhoto);
            this.tabPage1.Controls.Add(this.groupBox_abonList);
            this.tabPage1.Controls.Add(this.groupBox_Info);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1041, 678);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Информация";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_Notes);
            this.panel1.Location = new System.Drawing.Point(5, 472);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 201);
            this.panel1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Заметки о Клиенте";
            // 
            // textBox_Notes
            // 
            this.textBox_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Notes.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Notes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textBox_Notes.Location = new System.Drawing.Point(2, 48);
            this.textBox_Notes.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Notes.Multiline = true;
            this.textBox_Notes.Name = "textBox_Notes";
            this.textBox_Notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Notes.Size = new System.Drawing.Size(1021, 151);
            this.textBox_Notes.TabIndex = 5;
            this.textBox_Notes.TextChanged += new System.EventHandler(this.textBox_Notes_TextChanged);
            // 
            // button_photo
            // 
            this.button_photo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_photo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_photo.Location = new System.Drawing.Point(843, 277);
            this.button_photo.Margin = new System.Windows.Forms.Padding(2);
            this.button_photo.Name = "button_photo";
            this.button_photo.Size = new System.Drawing.Size(188, 42);
            this.button_photo.TabIndex = 4;
            this.button_photo.Text = "Из файла";
            this.button_photo.UseVisualStyleBackColor = true;
            this.button_photo.Click += new System.EventHandler(this.button_photo_Click);
            // 
            // button_photo_cam
            // 
            this.button_photo_cam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_photo_cam.BackgroundImage = global::PersonsBase.Properties.Resources.icons8_камера_100;
            this.button_photo_cam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_photo_cam.Enabled = false;
            this.button_photo_cam.Location = new System.Drawing.Point(843, 230);
            this.button_photo_cam.Name = "button_photo_cam";
            this.button_photo_cam.Size = new System.Drawing.Size(187, 42);
            this.button_photo_cam.TabIndex = 13;
            this.button_photo_cam.UseVisualStyleBackColor = true;
            this.button_photo_cam.Click += new System.EventHandler(this.button_photo_cam_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.31774F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.68226F));
            this.tableLayoutPanel2.Controls.Add(this.label_infoText, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_PersonName, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1020, 36);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // label_infoText
            // 
            this.label_infoText.AutoSize = true;
            this.label_infoText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_infoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_infoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_infoText.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_infoText.Location = new System.Drawing.Point(506, 0);
            this.label_infoText.Name = "label_infoText";
            this.label_infoText.Size = new System.Drawing.Size(511, 36);
            this.label_infoText.TabIndex = 1;
            this.label_infoText.Text = "Info";
            this.label_infoText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_PersonName
            // 
            this.label_PersonName.AutoSize = true;
            this.label_PersonName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_PersonName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_PersonName.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_PersonName.Location = new System.Drawing.Point(3, 0);
            this.label_PersonName.Name = "label_PersonName";
            this.label_PersonName.Size = new System.Drawing.Size(497, 36);
            this.label_PersonName.TabIndex = 0;
            this.label_PersonName.Text = "ФИО";
            this.label_PersonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button_CheckInWorkout);
            this.flowLayoutPanel1.Controls.Add(this.button_add_dop_tren);
            this.flowLayoutPanel1.Controls.Add(this.button_Add_Abon);
            this.flowLayoutPanel1.Controls.Add(this.button_Freeze);
            this.flowLayoutPanel1.Controls.Add(this.button_RemoveCurrentAbon);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 46);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(169, 419);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // button_CheckInWorkout
            // 
            this.button_CheckInWorkout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_CheckInWorkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_CheckInWorkout.Location = new System.Drawing.Point(2, 2);
            this.button_CheckInWorkout.Margin = new System.Windows.Forms.Padding(2);
            this.button_CheckInWorkout.Name = "button_CheckInWorkout";
            this.button_CheckInWorkout.Size = new System.Drawing.Size(165, 63);
            this.button_CheckInWorkout.TabIndex = 3;
            this.button_CheckInWorkout.Text = "Отметить Посещение";
            this.button_CheckInWorkout.UseVisualStyleBackColor = true;
            this.button_CheckInWorkout.Click += new System.EventHandler(this.button_CheckInWorkout_Click);
            // 
            // button_add_dop_tren
            // 
            this.button_add_dop_tren.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_add_dop_tren.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_add_dop_tren.Location = new System.Drawing.Point(2, 69);
            this.button_add_dop_tren.Margin = new System.Windows.Forms.Padding(2);
            this.button_add_dop_tren.Name = "button_add_dop_tren";
            this.button_add_dop_tren.Size = new System.Drawing.Size(165, 63);
            this.button_add_dop_tren.TabIndex = 6;
            this.button_add_dop_tren.Text = "Добавить Тренировки";
            this.button_add_dop_tren.UseVisualStyleBackColor = true;
            this.button_add_dop_tren.Visible = false;
            this.button_add_dop_tren.Click += new System.EventHandler(this.button_add_dop_tren_Click);
            // 
            // button_Add_Abon
            // 
            this.button_Add_Abon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_Add_Abon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Add_Abon.Location = new System.Drawing.Point(2, 136);
            this.button_Add_Abon.Margin = new System.Windows.Forms.Padding(2);
            this.button_Add_Abon.Name = "button_Add_Abon";
            this.button_Add_Abon.Size = new System.Drawing.Size(165, 63);
            this.button_Add_Abon.TabIndex = 4;
            this.button_Add_Abon.Text = "Добавить Абонемент";
            this.button_Add_Abon.UseVisualStyleBackColor = true;
            this.button_Add_Abon.Click += new System.EventHandler(this.button_Add_New_Abon_Click);
            // 
            // button_Freeze
            // 
            this.button_Freeze.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_Freeze.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Freeze.Location = new System.Drawing.Point(2, 203);
            this.button_Freeze.Margin = new System.Windows.Forms.Padding(2);
            this.button_Freeze.Name = "button_Freeze";
            this.button_Freeze.Size = new System.Drawing.Size(165, 53);
            this.button_Freeze.TabIndex = 5;
            this.button_Freeze.Text = "Заморозить";
            this.button_Freeze.UseVisualStyleBackColor = true;
            this.button_Freeze.Click += new System.EventHandler(this.button_Freeze_Click);
            // 
            // button_RemoveCurrentAbon
            // 
            this.button_RemoveCurrentAbon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_RemoveCurrentAbon.ForeColor = System.Drawing.Color.Red;
            this.button_RemoveCurrentAbon.Location = new System.Drawing.Point(2, 260);
            this.button_RemoveCurrentAbon.Margin = new System.Windows.Forms.Padding(2);
            this.button_RemoveCurrentAbon.Name = "button_RemoveCurrentAbon";
            this.button_RemoveCurrentAbon.Size = new System.Drawing.Size(165, 56);
            this.button_RemoveCurrentAbon.TabIndex = 2;
            this.button_RemoveCurrentAbon.Text = "Удалить Абонемент";
            this.button_RemoveCurrentAbon.UseVisualStyleBackColor = true;
            this.button_RemoveCurrentAbon.Visible = false;
            this.button_RemoveCurrentAbon.Click += new System.EventHandler(this.button_remove_current_abon_Click);
            // 
            // pictureBox_ClientPhoto
            // 
            this.pictureBox_ClientPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_ClientPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_ClientPhoto.Location = new System.Drawing.Point(842, 46);
            this.pictureBox_ClientPhoto.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_ClientPhoto.Name = "pictureBox_ClientPhoto";
            this.pictureBox_ClientPhoto.Size = new System.Drawing.Size(188, 179);
            this.pictureBox_ClientPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ClientPhoto.TabIndex = 0;
            this.pictureBox_ClientPhoto.TabStop = false;
            // 
            // groupBox_abonList
            // 
            this.groupBox_abonList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_abonList.Controls.Add(this.button__remove_abon);
            this.groupBox_abonList.Controls.Add(this.listBox_abonements);
            this.groupBox_abonList.Location = new System.Drawing.Point(834, 339);
            this.groupBox_abonList.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_abonList.Name = "groupBox_abonList";
            this.groupBox_abonList.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_abonList.Size = new System.Drawing.Size(196, 128);
            this.groupBox_abonList.TabIndex = 11;
            this.groupBox_abonList.TabStop = false;
            this.groupBox_abonList.Text = "Очередь Абонементов:";
            this.groupBox_abonList.Visible = false;
            // 
            // button__remove_abon
            // 
            this.button__remove_abon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button__remove_abon.Enabled = false;
            this.button__remove_abon.Location = new System.Drawing.Point(2, 102);
            this.button__remove_abon.Margin = new System.Windows.Forms.Padding(2);
            this.button__remove_abon.Name = "button__remove_abon";
            this.button__remove_abon.Size = new System.Drawing.Size(192, 24);
            this.button__remove_abon.TabIndex = 1;
            this.button__remove_abon.Text = "Удалить";
            this.button__remove_abon.UseVisualStyleBackColor = true;
            this.button__remove_abon.Click += new System.EventHandler(this.button_remove_abon_Click);
            // 
            // listBox_abonements
            // 
            this.listBox_abonements.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox_abonements.FormattingEnabled = true;
            this.listBox_abonements.ItemHeight = 16;
            this.listBox_abonements.Location = new System.Drawing.Point(2, 18);
            this.listBox_abonements.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_abonements.Name = "listBox_abonements";
            this.listBox_abonements.Size = new System.Drawing.Size(192, 84);
            this.listBox_abonements.TabIndex = 0;
            this.listBox_abonements.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_abonements_MouseDoubleClick);
            // 
            // groupBox_Info
            // 
            this.groupBox_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_Info.Location = new System.Drawing.Point(192, 38);
            this.groupBox_Info.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Info.Name = "groupBox_Info";
            this.groupBox_Info.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Info.Size = new System.Drawing.Size(638, 429);
            this.groupBox_Info.TabIndex = 4;
            this.groupBox_Info.TabStop = false;
            this.groupBox_Info.Text = "Информация";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox_Detailed);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1041, 678);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Персональные данные";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox_Detailed
            // 
            this.groupBox_Detailed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Detailed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_Detailed.Location = new System.Drawing.Point(334, 4);
            this.groupBox_Detailed.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Detailed.Name = "groupBox_Detailed";
            this.groupBox_Detailed.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Detailed.Size = new System.Drawing.Size(700, 670);
            this.groupBox_Detailed.TabIndex = 1;
            this.groupBox_Detailed.TabStop = false;
            this.groupBox_Detailed.Text = "Детальная информация";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(4, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(313, 669);
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
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 208);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(2, 110);
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
            this.label6.Location = new System.Drawing.Point(2, 56);
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
            this.maskedTextBox_PhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_PhoneNumber.Location = new System.Drawing.Point(130, 2);
            this.maskedTextBox_PhoneNumber.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBox_PhoneNumber.Mask = "8(999) 000-00-00";
            this.maskedTextBox_PhoneNumber.Name = "maskedTextBox_PhoneNumber";
            this.maskedTextBox_PhoneNumber.Size = new System.Drawing.Size(166, 23);
            this.maskedTextBox_PhoneNumber.TabIndex = 6;
            this.maskedTextBox_PhoneNumber.TextChanged += new System.EventHandler(this.maskedTextBox_PhoneNumber_TextChanged);
            // 
            // maskedTextBox_Passport
            // 
            this.maskedTextBox_Passport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maskedTextBox_Passport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_Passport.Location = new System.Drawing.Point(130, 29);
            this.maskedTextBox_Passport.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBox_Passport.Mask = "9999   № 999999";
            this.maskedTextBox_Passport.Name = "maskedTextBox_Passport";
            this.maskedTextBox_Passport.Size = new System.Drawing.Size(166, 21);
            this.maskedTextBox_Passport.TabIndex = 4;
            this.maskedTextBox_Passport.TextChanged += new System.EventHandler(this.maskedTex_Passport_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(2, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Паспорт";
            // 
            // maskedTextBox_DriverID
            // 
            this.maskedTextBox_DriverID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maskedTextBox_DriverID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_DriverID.Location = new System.Drawing.Point(130, 54);
            this.maskedTextBox_DriverID.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBox_DriverID.Mask = "9999   № 999999";
            this.maskedTextBox_DriverID.Name = "maskedTextBox_DriverID";
            this.maskedTextBox_DriverID.Size = new System.Drawing.Size(166, 21);
            this.maskedTextBox_DriverID.TabIndex = 0;
            this.maskedTextBox_DriverID.TextChanged += new System.EventHandler(this.maskedTextBox_DriverID_TextChanged);
            // 
            // label_Phone
            // 
            this.label_Phone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Phone.AutoSize = true;
            this.label_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Phone.Location = new System.Drawing.Point(2, 5);
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
            this.label5.Location = new System.Drawing.Point(2, 82);
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
            this.label1.Location = new System.Drawing.Point(2, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Личный   Номер";
            // 
            // comboBox_Gender
            // 
            this.comboBox_Gender.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_Gender.FormattingEnabled = true;
            this.comboBox_Gender.Location = new System.Drawing.Point(130, 79);
            this.comboBox_Gender.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Gender.Name = "comboBox_Gender";
            this.comboBox_Gender.Size = new System.Drawing.Size(166, 24);
            this.comboBox_Gender.TabIndex = 2;
            this.comboBox_Gender.SelectedIndexChanged += new System.EventHandler(this.comboBox_Gender_SelectedIndexChanged);
            // 
            // textBox_Number
            // 
            this.textBox_Number.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Number.Location = new System.Drawing.Point(130, 134);
            this.textBox_Number.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Number.Name = "textBox_Number";
            this.textBox_Number.Size = new System.Drawing.Size(166, 23);
            this.textBox_Number.TabIndex = 5;
            this.textBox_Number.Text = "123";
            this.textBox_Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Number.Click += new System.EventHandler(this.textBox_Number_Click);
            this.textBox_Number.TextChanged += new System.EventHandler(this.textBox_Number_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView_Visits);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1041, 678);
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
            this.dataGridView_Visits.Size = new System.Drawing.Size(1035, 672);
            this.dataGridView_Visits.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_SavePersonalData, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button2, 4, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 711);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1049, 40);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Cancel.Location = new System.Drawing.Point(152, 2);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(146, 36);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_SavePersonalData
            // 
            this.button_SavePersonalData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_SavePersonalData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_SavePersonalData.Location = new System.Drawing.Point(2, 2);
            this.button_SavePersonalData.Margin = new System.Windows.Forms.Padding(2);
            this.button_SavePersonalData.Name = "button_SavePersonalData";
            this.button_SavePersonalData.Size = new System.Drawing.Size(146, 36);
            this.button_SavePersonalData.TabIndex = 2;
            this.button_SavePersonalData.Text = "Сохранить";
            this.button_SavePersonalData.UseVisualStyleBackColor = true;
            this.button_SavePersonalData.Click += new System.EventHandler(this.button_SavePersonalData_Click);
            // 
            // button2
            // 
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(872, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 34);
            this.button2.TabIndex = 5;
            this.button2.TabStop = false;
            this.button2.Text = "Доступ Руководителя";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button_Password_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 751);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1065, 726);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Карточка Клиента";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.Resize += new System.EventHandler(this.ClientForm_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClientPhoto)).EndInit();
            this.groupBox_abonList.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Visits)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
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
        private TextBox textBox_Notes;
        private PictureBox pictureBox_ClientPhoto;
        private Button button_CheckInWorkout;
        private Button button_Add_Abon;
        private Button button_Freeze;
        private Button button_Cancel;
        private TableLayoutPanel tableLayoutPanel4;
        private Button button_add_dop_tren;
        private GroupBox groupBox_abonList;
        private ListBox listBox_abonements;
        private Button button__remove_abon;
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
        private Panel panel1;
        private Label label2;
    }
}