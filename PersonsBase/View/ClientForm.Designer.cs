using System;

namespace PBase
{

   partial class ClientForm
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
         this.textBox_Name = new System.Windows.Forms.TextBox();
         this.dateTimePicker_birthDate = new System.Windows.Forms.DateTimePicker();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.groupBox_abonList = new System.Windows.Forms.GroupBox();
         this.button1 = new System.Windows.Forms.Button();
         this.button__remove_abon = new System.Windows.Forms.Button();
         this.listBox_abonements = new System.Windows.Forms.ListBox();
         this.groupBox6 = new System.Windows.Forms.GroupBox();
         this.pictureBox_ClientPhoto = new System.Windows.Forms.PictureBox();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.button_CheckInWorkout = new System.Windows.Forms.Button();
         this.button_Add_Abon = new System.Windows.Forms.Button();
         this.button_Freeze = new System.Windows.Forms.Button();
         this.button_add_dop_tren = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.textBox_Notes = new System.Windows.Forms.TextBox();
         this.groupBox_Info = new System.Windows.Forms.GroupBox();
         this.tabPage2 = new System.Windows.Forms.TabPage();
         this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
         this.button_Cancel = new System.Windows.Forms.Button();
         this.button_SavePersonalData = new System.Windows.Forms.Button();
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
         this.tabControl1.SuspendLayout();
         this.tabPage1.SuspendLayout();
         this.groupBox_abonList.SuspendLayout();
         this.groupBox6.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClientPhoto)).BeginInit();
         this.groupBox4.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.tabPage2.SuspendLayout();
         this.tableLayoutPanel4.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // textBox_Name
         // 
         this.textBox_Name.Dock = System.Windows.Forms.DockStyle.Top;
         this.textBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox_Name.ForeColor = System.Drawing.SystemColors.WindowText;
         this.textBox_Name.Location = new System.Drawing.Point(3, 2);
         this.textBox_Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.textBox_Name.Name = "textBox_Name";
         this.textBox_Name.Size = new System.Drawing.Size(959, 38);
         this.textBox_Name.TabIndex = 1;
         this.textBox_Name.Text = "ФИО";
         this.textBox_Name.TextChanged += new System.EventHandler(this.textBox_Name_TextChanged);
         // 
         // dateTimePicker_birthDate
         // 
         this.dateTimePicker_birthDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.dateTimePicker_birthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.dateTimePicker_birthDate.Location = new System.Drawing.Point(146, 120);
         this.dateTimePicker_birthDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.dateTimePicker_birthDate.MinimumSize = new System.Drawing.Size(152, 22);
         this.dateTimePicker_birthDate.Name = "dateTimePicker_birthDate";
         this.dateTimePicker_birthDate.Size = new System.Drawing.Size(220, 26);
         this.dateTimePicker_birthDate.TabIndex = 3;
         this.dateTimePicker_birthDate.ValueChanged += new System.EventHandler(this.dateTimePicker_birthDate_ValueChanged);
         // 
         // tabControl1
         // 
         this.tabControl1.Controls.Add(this.tabPage1);
         this.tabControl1.Controls.Add(this.tabPage2);
         this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControl1.Location = new System.Drawing.Point(0, 0);
         this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(973, 576);
         this.tabControl1.TabIndex = 2;
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.groupBox_abonList);
         this.tabPage1.Controls.Add(this.groupBox6);
         this.tabPage1.Controls.Add(this.groupBox4);
         this.tabPage1.Controls.Add(this.groupBox1);
         this.tabPage1.Controls.Add(this.groupBox_Info);
         this.tabPage1.Controls.Add(this.textBox_Name);
         this.tabPage1.Location = new System.Drawing.Point(4, 25);
         this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tabPage1.Size = new System.Drawing.Size(965, 547);
         this.tabPage1.TabIndex = 0;
         this.tabPage1.Text = "Основная";
         this.tabPage1.UseVisualStyleBackColor = true;
         // 
         // groupBox_abonList
         // 
         this.groupBox_abonList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox_abonList.Controls.Add(this.button1);
         this.groupBox_abonList.Controls.Add(this.button__remove_abon);
         this.groupBox_abonList.Controls.Add(this.listBox_abonements);
         this.groupBox_abonList.Location = new System.Drawing.Point(712, 267);
         this.groupBox_abonList.Name = "groupBox_abonList";
         this.groupBox_abonList.Size = new System.Drawing.Size(236, 191);
         this.groupBox_abonList.TabIndex = 11;
         this.groupBox_abonList.TabStop = false;
         this.groupBox_abonList.Text = "Следующие Абонементы:";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(32, 153);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(176, 29);
         this.button1.TabIndex = 2;
         this.button1.Text = "Удалить Активный";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button_remove_current_abon_Click);
         // 
         // button__remove_abon
         // 
         this.button__remove_abon.Location = new System.Drawing.Point(32, 118);
         this.button__remove_abon.Name = "button__remove_abon";
         this.button__remove_abon.Size = new System.Drawing.Size(176, 29);
         this.button__remove_abon.TabIndex = 1;
         this.button__remove_abon.Text = "Удалить из Очереди";
         this.button__remove_abon.UseVisualStyleBackColor = true;
         this.button__remove_abon.Click += new System.EventHandler(this.button__remove_abon_Click);
         // 
         // listBox_abonements
         // 
         this.listBox_abonements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listBox_abonements.FormattingEnabled = true;
         this.listBox_abonements.ItemHeight = 16;
         this.listBox_abonements.Location = new System.Drawing.Point(32, 28);
         this.listBox_abonements.Name = "listBox_abonements";
         this.listBox_abonements.Size = new System.Drawing.Size(176, 84);
         this.listBox_abonements.TabIndex = 0;
         // 
         // groupBox6
         // 
         this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox6.Controls.Add(this.pictureBox_ClientPhoto);
         this.groupBox6.Location = new System.Drawing.Point(712, 47);
         this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox6.Name = "groupBox6";
         this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox6.Size = new System.Drawing.Size(236, 215);
         this.groupBox6.TabIndex = 10;
         this.groupBox6.TabStop = false;
         this.groupBox6.Text = "Фото Клиента";
         // 
         // pictureBox_ClientPhoto
         // 
         this.pictureBox_ClientPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pictureBox_ClientPhoto.Location = new System.Drawing.Point(32, 18);
         this.pictureBox_ClientPhoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.pictureBox_ClientPhoto.Name = "pictureBox_ClientPhoto";
         this.pictureBox_ClientPhoto.Size = new System.Drawing.Size(176, 184);
         this.pictureBox_ClientPhoto.TabIndex = 0;
         this.pictureBox_ClientPhoto.TabStop = false;
         // 
         // groupBox4
         // 
         this.groupBox4.Controls.Add(this.tableLayoutPanel2);
         this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.groupBox4.Location = new System.Drawing.Point(27, 47);
         this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox4.Size = new System.Drawing.Size(205, 396);
         this.groupBox4.TabIndex = 9;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Действия";
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.tableLayoutPanel2.ColumnCount = 1;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel2.Controls.Add(this.button_CheckInWorkout, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.button_Add_Abon, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.button_Freeze, 0, 3);
         this.tableLayoutPanel2.Controls.Add(this.button_add_dop_tren, 0, 1);
         this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
         this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 4;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 372);
         this.tableLayoutPanel2.TabIndex = 0;
         // 
         // button_CheckInWorkout
         // 
         this.button_CheckInWorkout.AutoSize = true;
         this.button_CheckInWorkout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.button_CheckInWorkout.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button_CheckInWorkout.Location = new System.Drawing.Point(3, 2);
         this.button_CheckInWorkout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.button_CheckInWorkout.Name = "button_CheckInWorkout";
         this.button_CheckInWorkout.Size = new System.Drawing.Size(194, 89);
         this.button_CheckInWorkout.TabIndex = 3;
         this.button_CheckInWorkout.Text = "Отметить Посещение";
         this.button_CheckInWorkout.UseVisualStyleBackColor = true;
         this.button_CheckInWorkout.Click += new System.EventHandler(this.button_CheckInWorkout_Click);
         // 
         // button_Add_Abon
         // 
         this.button_Add_Abon.AutoSize = true;
         this.button_Add_Abon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.button_Add_Abon.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button_Add_Abon.Location = new System.Drawing.Point(3, 188);
         this.button_Add_Abon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.button_Add_Abon.Name = "button_Add_Abon";
         this.button_Add_Abon.Size = new System.Drawing.Size(194, 89);
         this.button_Add_Abon.TabIndex = 4;
         this.button_Add_Abon.Text = "Добавить Абонемент";
         this.button_Add_Abon.UseVisualStyleBackColor = true;
         this.button_Add_Abon.Click += new System.EventHandler(this.button_Add_Abon_Click);
         // 
         // button_Freeze
         // 
         this.button_Freeze.AutoSize = true;
         this.button_Freeze.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.button_Freeze.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button_Freeze.Location = new System.Drawing.Point(3, 281);
         this.button_Freeze.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.button_Freeze.Name = "button_Freeze";
         this.button_Freeze.Size = new System.Drawing.Size(194, 89);
         this.button_Freeze.TabIndex = 5;
         this.button_Freeze.Text = "Заморозить";
         this.button_Freeze.UseVisualStyleBackColor = true;
         // 
         // button_add_dop_tren
         // 
         this.button_add_dop_tren.AutoSize = true;
         this.button_add_dop_tren.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.button_add_dop_tren.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button_add_dop_tren.Location = new System.Drawing.Point(3, 95);
         this.button_add_dop_tren.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.button_add_dop_tren.Name = "button_add_dop_tren";
         this.button_add_dop_tren.Size = new System.Drawing.Size(194, 89);
         this.button_add_dop_tren.TabIndex = 6;
         this.button_add_dop_tren.Text = "Добавить Тренировки";
         this.button_add_dop_tren.UseVisualStyleBackColor = true;
         this.button_add_dop_tren.Visible = false;
         this.button_add_dop_tren.VisibleChanged += new System.EventHandler(this.button_add_dop_tren_VisibleChanged);
         this.button_add_dop_tren.Click += new System.EventHandler(this.button_add_dop_tren_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.textBox_Notes);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.groupBox1.Location = new System.Drawing.Point(3, 459);
         this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox1.Size = new System.Drawing.Size(959, 86);
         this.groupBox1.TabIndex = 8;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Заметки";
         // 
         // textBox_Notes
         // 
         this.textBox_Notes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.textBox_Notes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox_Notes.Location = new System.Drawing.Point(3, 17);
         this.textBox_Notes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.textBox_Notes.Multiline = true;
         this.textBox_Notes.Name = "textBox_Notes";
         this.textBox_Notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.textBox_Notes.Size = new System.Drawing.Size(953, 67);
         this.textBox_Notes.TabIndex = 5;
         this.textBox_Notes.TextChanged += new System.EventHandler(this.textBox_Notes_TextChanged);
         // 
         // groupBox_Info
         // 
         this.groupBox_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.groupBox_Info.Location = new System.Drawing.Point(256, 47);
         this.groupBox_Info.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox_Info.Name = "groupBox_Info";
         this.groupBox_Info.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox_Info.Size = new System.Drawing.Size(449, 411);
         this.groupBox_Info.TabIndex = 4;
         this.groupBox_Info.TabStop = false;
         this.groupBox_Info.Text = "Информация";
         // 
         // tabPage2
         // 
         this.tabPage2.Controls.Add(this.tableLayoutPanel4);
         this.tabPage2.Controls.Add(this.groupBox_Detailed);
         this.tabPage2.Controls.Add(this.groupBox2);
         this.tabPage2.Location = new System.Drawing.Point(4, 25);
         this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tabPage2.Name = "tabPage2";
         this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tabPage2.Size = new System.Drawing.Size(965, 547);
         this.tabPage2.TabIndex = 1;
         this.tabPage2.Text = "Дополнительная";
         this.tabPage2.UseVisualStyleBackColor = true;
         // 
         // tableLayoutPanel4
         // 
         this.tableLayoutPanel4.ColumnCount = 3;
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
         this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel4.Controls.Add(this.button_Cancel, 1, 0);
         this.tableLayoutPanel4.Controls.Add(this.button_SavePersonalData, 0, 0);
         this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 511);
         this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tableLayoutPanel4.Name = "tableLayoutPanel4";
         this.tableLayoutPanel4.RowCount = 1;
         this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
         this.tableLayoutPanel4.Size = new System.Drawing.Size(959, 34);
         this.tableLayoutPanel4.TabIndex = 2;
         // 
         // button_Cancel
         // 
         this.button_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button_Cancel.Location = new System.Drawing.Point(203, 2);
         this.button_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.button_Cancel.Name = "button_Cancel";
         this.button_Cancel.Size = new System.Drawing.Size(194, 30);
         this.button_Cancel.TabIndex = 3;
         this.button_Cancel.Text = "Отмена";
         this.button_Cancel.UseVisualStyleBackColor = true;
         this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
         // 
         // button_SavePersonalData
         // 
         this.button_SavePersonalData.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button_SavePersonalData.Location = new System.Drawing.Point(3, 2);
         this.button_SavePersonalData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.button_SavePersonalData.Name = "button_SavePersonalData";
         this.button_SavePersonalData.Size = new System.Drawing.Size(194, 30);
         this.button_SavePersonalData.TabIndex = 2;
         this.button_SavePersonalData.Text = "Сохранить изменения";
         this.button_SavePersonalData.UseVisualStyleBackColor = true;
         this.button_SavePersonalData.Click += new System.EventHandler(this.button_SavePersonalData_Click);
         // 
         // groupBox_Detailed
         // 
         this.groupBox_Detailed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox_Detailed.Location = new System.Drawing.Point(415, 9);
         this.groupBox_Detailed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox_Detailed.Name = "groupBox_Detailed";
         this.groupBox_Detailed.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox_Detailed.Size = new System.Drawing.Size(481, 479);
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
         this.groupBox2.Location = new System.Drawing.Point(5, 6);
         this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox2.Size = new System.Drawing.Size(395, 482);
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
         this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 30);
         this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 206);
         this.tableLayoutPanel1.TabIndex = 1;
         // 
         // label4
         // 
         this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(3, 124);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(119, 18);
         this.label4.TabIndex = 5;
         this.label4.Text = "День Рождения";
         // 
         // label6
         // 
         this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(3, 63);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(137, 18);
         this.label6.TabIndex = 2;
         this.label6.Text = "Права";
         this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // maskedTextBox_PhoneNumber
         // 
         this.maskedTextBox_PhoneNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.maskedTextBox_PhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.maskedTextBox_PhoneNumber.Location = new System.Drawing.Point(146, 2);
         this.maskedTextBox_PhoneNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.maskedTextBox_PhoneNumber.Mask = "8(999) 000-00-00";
         this.maskedTextBox_PhoneNumber.Name = "maskedTextBox_PhoneNumber";
         this.maskedTextBox_PhoneNumber.Size = new System.Drawing.Size(220, 26);
         this.maskedTextBox_PhoneNumber.TabIndex = 6;
         this.maskedTextBox_PhoneNumber.TextChanged += new System.EventHandler(this.maskedTextBox_PhoneNumber_TextChanged);
         // 
         // maskedTextBox_Passport
         // 
         this.maskedTextBox_Passport.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.maskedTextBox_Passport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.maskedTextBox_Passport.Location = new System.Drawing.Point(146, 32);
         this.maskedTextBox_Passport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.maskedTextBox_Passport.Mask = "9999   № 999999";
         this.maskedTextBox_Passport.Name = "maskedTextBox_Passport";
         this.maskedTextBox_Passport.Size = new System.Drawing.Size(220, 24);
         this.maskedTextBox_Passport.TabIndex = 4;
         this.maskedTextBox_Passport.TextChanged += new System.EventHandler(this.maskedTex_Passport_TextChanged);
         // 
         // label3
         // 
         this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(3, 35);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(67, 18);
         this.label3.TabIndex = 8;
         this.label3.Text = "Паспорт";
         // 
         // maskedTextBox_DriverID
         // 
         this.maskedTextBox_DriverID.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.maskedTextBox_DriverID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.maskedTextBox_DriverID.Location = new System.Drawing.Point(146, 60);
         this.maskedTextBox_DriverID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.maskedTextBox_DriverID.Mask = "9999   № 999999";
         this.maskedTextBox_DriverID.Name = "maskedTextBox_DriverID";
         this.maskedTextBox_DriverID.Size = new System.Drawing.Size(220, 24);
         this.maskedTextBox_DriverID.TabIndex = 0;
         this.maskedTextBox_DriverID.TextChanged += new System.EventHandler(this.maskedTextBox_DriverID_TextChanged);
         // 
         // label_Phone
         // 
         this.label_Phone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.label_Phone.AutoSize = true;
         this.label_Phone.Location = new System.Drawing.Point(3, 6);
         this.label_Phone.Name = "label_Phone";
         this.label_Phone.Size = new System.Drawing.Size(137, 18);
         this.label_Phone.TabIndex = 7;
         this.label_Phone.Text = "Телефон";
         // 
         // label5
         // 
         this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(3, 93);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(37, 18);
         this.label5.TabIndex = 7;
         this.label5.Text = "Пол";
         // 
         // label1
         // 
         this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 154);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(137, 18);
         this.label1.TabIndex = 4;
         this.label1.Text = "Табельный Номер";
         // 
         // comboBox_Gender
         // 
         this.comboBox_Gender.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.comboBox_Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_Gender.FormattingEnabled = true;
         this.comboBox_Gender.Location = new System.Drawing.Point(146, 88);
         this.comboBox_Gender.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.comboBox_Gender.Name = "comboBox_Gender";
         this.comboBox_Gender.Size = new System.Drawing.Size(220, 28);
         this.comboBox_Gender.TabIndex = 2;
         this.comboBox_Gender.SelectedIndexChanged += new System.EventHandler(this.comboBox_Gender_SelectedIndexChanged);
         // 
         // textBox_Number
         // 
         this.textBox_Number.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.textBox_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.textBox_Number.Location = new System.Drawing.Point(146, 150);
         this.textBox_Number.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.textBox_Number.Name = "textBox_Number";
         this.textBox_Number.ReadOnly = true;
         this.textBox_Number.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.textBox_Number.Size = new System.Drawing.Size(220, 26);
         this.textBox_Number.TabIndex = 5;
         this.textBox_Number.Text = "123";
         // 
         // ClientForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(973, 576);
         this.Controls.Add(this.tabControl1);
         this.DoubleBuffered = true;
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.MaximizeBox = false;
         this.Name = "ClientForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Карточка Клиента";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
         this.Load += new System.EventHandler(this.ClientForm_Load);
         this.Resize += new System.EventHandler(this.ClientForm_Resize);
         this.tabControl1.ResumeLayout(false);
         this.tabPage1.ResumeLayout(false);
         this.tabPage1.PerformLayout();
         this.groupBox_abonList.ResumeLayout(false);
         this.groupBox6.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ClientPhoto)).EndInit();
         this.groupBox4.ResumeLayout(false);
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.tabPage2.ResumeLayout(false);
         this.tableLayoutPanel4.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion
      [NonSerialized]
      private System.Windows.Forms.TextBox textBox_Name;
      [NonSerialized]
      private System.Windows.Forms.TabControl tabControl1;
      [NonSerialized]
      private System.Windows.Forms.TabPage tabPage1;
      [NonSerialized]
      private System.Windows.Forms.TabPage tabPage2;
      [NonSerialized]
      private System.Windows.Forms.GroupBox groupBox2;
      [NonSerialized]
      private System.Windows.Forms.MaskedTextBox maskedTextBox_DriverID;
      [NonSerialized]
      private System.Windows.Forms.TextBox textBox_Number;
      [NonSerialized]
      private System.Windows.Forms.Label label1;
      [NonSerialized]
      private System.Windows.Forms.DateTimePicker dateTimePicker_birthDate;
      [NonSerialized]
      private System.Windows.Forms.GroupBox groupBox_Info;
      [NonSerialized]
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      [NonSerialized]
      private System.Windows.Forms.Label label_Phone;
      [NonSerialized]
      private System.Windows.Forms.MaskedTextBox maskedTextBox_PhoneNumber;
      [NonSerialized]
      private System.Windows.Forms.MaskedTextBox maskedTextBox_Passport;
      [NonSerialized]
      private System.Windows.Forms.Label label3;
      [NonSerialized]
      private System.Windows.Forms.Label label6;
      [NonSerialized]
      private System.Windows.Forms.Label label4;
      [NonSerialized]
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.ComboBox comboBox_Gender;
      private System.Windows.Forms.Button button_SavePersonalData;
      private System.Windows.Forms.GroupBox groupBox_Detailed;
      private System.Windows.Forms.TextBox textBox_Notes;
      private System.Windows.Forms.PictureBox pictureBox_ClientPhoto;
      private System.Windows.Forms.Button button_CheckInWorkout;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Button button_Add_Abon;
      private System.Windows.Forms.Button button_Freeze;
      private System.Windows.Forms.GroupBox groupBox6;
      private System.Windows.Forms.Button button_Cancel;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
      private System.Windows.Forms.Button button_add_dop_tren;
      private System.Windows.Forms.GroupBox groupBox_abonList;
      private System.Windows.Forms.ListBox listBox_abonements;
      private System.Windows.Forms.Button button__remove_abon;
      private System.Windows.Forms.Button button1;
   }
}