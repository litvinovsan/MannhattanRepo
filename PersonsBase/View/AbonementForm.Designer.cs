using System.ComponentModel;
using System.Windows.Forms;

namespace PersonsBase.View
{
    partial class AbonementForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_Aplly = new System.Windows.Forms.Button();
            this.button2_Cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_AbonType = new System.Windows.Forms.Panel();
            this.comboBox_Abonem = new System.Windows.Forms.ComboBox();
            this.radioButton_Abonement = new System.Windows.Forms.RadioButton();
            this.panel_ClubCardType = new System.Windows.Forms.Panel();
            this.radioButton_ClubCard = new System.Windows.Forms.RadioButton();
            this.comboBox_ClubCard = new System.Windows.Forms.ComboBox();
            this.radioButton_Single = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.radioButton_guest = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_TypeTren = new System.Windows.Forms.Panel();
            this.comboBox_TypeTren = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_Spa = new System.Windows.Forms.Panel();
            this.comboBox_spa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_TimeTren = new System.Windows.Forms.Panel();
            this.comboBox_time = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_PayStatus = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Pay = new System.Windows.Forms.ComboBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.groupBox_Correctable = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker_ActivationDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_Tren = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Personal = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Aerob = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_freez = new System.Windows.Forms.ComboBox();
            this.checkBox_Activated = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox_Details = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel_AbonType.SuspendLayout();
            this.panel_ClubCardType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel_TypeTren.SuspendLayout();
            this.panel_Spa.SuspendLayout();
            this.panel_TimeTren.SuspendLayout();
            this.panel_PayStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.groupBox_Correctable.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.button_Aplly, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2_Cancel, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 464);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.12245F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.87755F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(639, 98);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_Aplly
            // 
            this.button_Aplly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_Aplly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Aplly.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Aplly.Location = new System.Drawing.Point(3, 2);
            this.button_Aplly.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Aplly.Name = "button_Aplly";
            this.button_Aplly.Size = new System.Drawing.Size(633, 51);
            this.button_Aplly.TabIndex = 0;
            this.button_Aplly.Text = "Применить";
            this.button_Aplly.UseVisualStyleBackColor = false;
            this.button_Aplly.Click += new System.EventHandler(this.button_Aplly_Click);
            // 
            // button2_Cancel
            // 
            this.button2_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2_Cancel.Location = new System.Drawing.Point(3, 57);
            this.button2_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2_Cancel.Name = "button2_Cancel";
            this.button2_Cancel.Size = new System.Drawing.Size(633, 39);
            this.button2_Cancel.TabIndex = 1;
            this.button2_Cancel.Text = "Отмена";
            this.button2_Cancel.UseVisualStyleBackColor = true;
            this.button2_Cancel.Click += new System.EventHandler(this.button_Cancel);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.01416F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.98584F));
            this.tableLayoutPanel2.Controls.Add(this.panel_AbonType, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel_ClubCardType, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.radioButton_Single, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox8, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.radioButton_guest, 1, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(328, 187);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel_AbonType
            // 
            this.panel_AbonType.Controls.Add(this.comboBox_Abonem);
            this.panel_AbonType.Controls.Add(this.radioButton_Abonement);
            this.panel_AbonType.Location = new System.Drawing.Point(52, 2);
            this.panel_AbonType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_AbonType.Name = "panel_AbonType";
            this.panel_AbonType.Size = new System.Drawing.Size(273, 37);
            this.panel_AbonType.TabIndex = 7;
            // 
            // comboBox_Abonem
            // 
            this.comboBox_Abonem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Abonem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Abonem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_Abonem.FormattingEnabled = true;
            this.comboBox_Abonem.Location = new System.Drawing.Point(151, 5);
            this.comboBox_Abonem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Abonem.Name = "comboBox_Abonem";
            this.comboBox_Abonem.Size = new System.Drawing.Size(119, 24);
            this.comboBox_Abonem.TabIndex = 3;
            // 
            // radioButton_Abonement
            // 
            this.radioButton_Abonement.AutoSize = true;
            this.radioButton_Abonement.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton_Abonement.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_Abonement.Location = new System.Drawing.Point(0, 0);
            this.radioButton_Abonement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_Abonement.Name = "radioButton_Abonement";
            this.radioButton_Abonement.Size = new System.Drawing.Size(103, 37);
            this.radioButton_Abonement.TabIndex = 1;
            this.radioButton_Abonement.Text = "Абонемент";
            this.radioButton_Abonement.UseVisualStyleBackColor = true;
            this.radioButton_Abonement.CheckedChanged += new System.EventHandler(this.radioButton_Abonement_CheckedChanged);
            // 
            // panel_ClubCardType
            // 
            this.panel_ClubCardType.Controls.Add(this.radioButton_ClubCard);
            this.panel_ClubCardType.Controls.Add(this.comboBox_ClubCard);
            this.panel_ClubCardType.Location = new System.Drawing.Point(52, 43);
            this.panel_ClubCardType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_ClubCardType.Name = "panel_ClubCardType";
            this.panel_ClubCardType.Size = new System.Drawing.Size(273, 37);
            this.panel_ClubCardType.TabIndex = 7;
            // 
            // radioButton_ClubCard
            // 
            this.radioButton_ClubCard.AutoSize = true;
            this.radioButton_ClubCard.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton_ClubCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_ClubCard.Location = new System.Drawing.Point(0, 0);
            this.radioButton_ClubCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_ClubCard.Name = "radioButton_ClubCard";
            this.radioButton_ClubCard.Size = new System.Drawing.Size(130, 37);
            this.radioButton_ClubCard.TabIndex = 0;
            this.radioButton_ClubCard.Text = "Клубная Карта";
            this.radioButton_ClubCard.UseVisualStyleBackColor = true;
            this.radioButton_ClubCard.CheckedChanged += new System.EventHandler(this.radioButton_ClubCard_CheckedChanged);
            // 
            // comboBox_ClubCard
            // 
            this.comboBox_ClubCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_ClubCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ClubCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_ClubCard.FormattingEnabled = true;
            this.comboBox_ClubCard.Location = new System.Drawing.Point(151, 7);
            this.comboBox_ClubCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_ClubCard.Name = "comboBox_ClubCard";
            this.comboBox_ClubCard.Size = new System.Drawing.Size(119, 24);
            this.comboBox_ClubCard.TabIndex = 3;
            this.comboBox_ClubCard.Visible = false;
            // 
            // radioButton_Single
            // 
            this.radioButton_Single.AutoSize = true;
            this.radioButton_Single.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton_Single.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_Single.Location = new System.Drawing.Point(52, 84);
            this.radioButton_Single.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_Single.Name = "radioButton_Single";
            this.radioButton_Single.Size = new System.Drawing.Size(166, 37);
            this.radioButton_Single.TabIndex = 2;
            this.radioButton_Single.Text = "Разовое посещение";
            this.radioButton_Single.UseVisualStyleBackColor = true;
            this.radioButton_Single.CheckedChanged += new System.EventHandler(this.radioButton_Single_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::PersonsBase.Properties.Resources.абонемент;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::PersonsBase.Properties.Resources.SinglVisit;
            this.pictureBox2.Location = new System.Drawing.Point(3, 44);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = global::PersonsBase.Properties.Resources.SinglVisit2;
            this.pictureBox3.Location = new System.Drawing.Point(3, 85);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::PersonsBase.Properties.Resources.user_male_add;
            this.pictureBox8.Location = new System.Drawing.Point(3, 126);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(43, 35);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 12;
            this.pictureBox8.TabStop = false;
            // 
            // radioButton_guest
            // 
            this.radioButton_guest.AutoSize = true;
            this.radioButton_guest.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton_guest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_guest.Location = new System.Drawing.Point(52, 125);
            this.radioButton_guest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_guest.Name = "radioButton_guest";
            this.radioButton_guest.Size = new System.Drawing.Size(135, 37);
            this.radioButton_guest.TabIndex = 11;
            this.radioButton_guest.Text = "Гостевой визит";
            this.radioButton_guest.UseVisualStyleBackColor = true;
            this.radioButton_guest.Visible = false;
            this.radioButton_guest.CheckedChanged += new System.EventHandler(this.radioButton_guest_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.71963F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.28037F));
            this.tableLayoutPanel3.Controls.Add(this.panel_TypeTren, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel_Spa, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel_TimeTren, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel_PayStatus, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox6, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox7, 0, 8);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 193);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 11;
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
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(328, 237);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // panel_TypeTren
            // 
            this.panel_TypeTren.AutoSize = true;
            this.panel_TypeTren.Controls.Add(this.comboBox_TypeTren);
            this.panel_TypeTren.Controls.Add(this.label2);
            this.panel_TypeTren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TypeTren.Location = new System.Drawing.Point(51, 2);
            this.panel_TypeTren.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_TypeTren.Name = "panel_TypeTren";
            this.panel_TypeTren.Size = new System.Drawing.Size(274, 52);
            this.panel_TypeTren.TabIndex = 7;
            // 
            // comboBox_TypeTren
            // 
            this.comboBox_TypeTren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_TypeTren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TypeTren.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_TypeTren.FormattingEnabled = true;
            this.comboBox_TypeTren.Location = new System.Drawing.Point(3, 25);
            this.comboBox_TypeTren.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_TypeTren.Name = "comboBox_TypeTren";
            this.comboBox_TypeTren.Size = new System.Drawing.Size(268, 24);
            this.comboBox_TypeTren.TabIndex = 3;
            this.comboBox_TypeTren.SelectedValueChanged += new System.EventHandler(this.comboBox_TypeTren_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Тип Тренировок";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_Spa
            // 
            this.panel_Spa.Controls.Add(this.comboBox_spa);
            this.panel_Spa.Controls.Add(this.label4);
            this.panel_Spa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Spa.Location = new System.Drawing.Point(51, 114);
            this.panel_Spa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Spa.Name = "panel_Spa";
            this.panel_Spa.Size = new System.Drawing.Size(274, 52);
            this.panel_Spa.TabIndex = 5;
            // 
            // comboBox_spa
            // 
            this.comboBox_spa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_spa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_spa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_spa.FormattingEnabled = true;
            this.comboBox_spa.Location = new System.Drawing.Point(3, 23);
            this.comboBox_spa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_spa.Name = "comboBox_spa";
            this.comboBox_spa.Size = new System.Drawing.Size(268, 24);
            this.comboBox_spa.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Услуги Спа";
            // 
            // panel_TimeTren
            // 
            this.panel_TimeTren.AutoSize = true;
            this.panel_TimeTren.Controls.Add(this.comboBox_time);
            this.panel_TimeTren.Controls.Add(this.label3);
            this.panel_TimeTren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TimeTren.Location = new System.Drawing.Point(51, 58);
            this.panel_TimeTren.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_TimeTren.Name = "panel_TimeTren";
            this.panel_TimeTren.Size = new System.Drawing.Size(274, 52);
            this.panel_TimeTren.TabIndex = 6;
            // 
            // comboBox_time
            // 
            this.comboBox_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_time.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_time.FormattingEnabled = true;
            this.comboBox_time.Location = new System.Drawing.Point(3, 25);
            this.comboBox_time.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_time.Name = "comboBox_time";
            this.comboBox_time.Size = new System.Drawing.Size(268, 24);
            this.comboBox_time.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Время Тренировок";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_PayStatus
            // 
            this.panel_PayStatus.Controls.Add(this.label5);
            this.panel_PayStatus.Controls.Add(this.comboBox_Pay);
            this.panel_PayStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_PayStatus.Location = new System.Drawing.Point(51, 170);
            this.panel_PayStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_PayStatus.Name = "panel_PayStatus";
            this.panel_PayStatus.Size = new System.Drawing.Size(274, 52);
            this.panel_PayStatus.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Оплата";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_Pay
            // 
            this.comboBox_Pay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Pay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Pay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_Pay.FormattingEnabled = true;
            this.comboBox_Pay.Location = new System.Drawing.Point(3, 22);
            this.comboBox_Pay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Pay.Name = "comboBox_Pay";
            this.comboBox_Pay.Size = new System.Drawing.Size(268, 24);
            this.comboBox_Pay.TabIndex = 3;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Image = global::PersonsBase.Properties.Resources.ВыборТрени;
            this.pictureBox4.Location = new System.Drawing.Point(3, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(42, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox5.Image = global::PersonsBase.Properties.Resources.timeTren;
            this.pictureBox5.Location = new System.Drawing.Point(3, 59);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(42, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox6.Image = global::PersonsBase.Properties.Resources.spa1;
            this.pictureBox6.Location = new System.Drawing.Point(3, 115);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(42, 50);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 10;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox7.Image = global::PersonsBase.Properties.Resources.currency_dollar_green;
            this.pictureBox7.Location = new System.Drawing.Point(3, 171);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(42, 50);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 11;
            this.pictureBox7.TabStop = false;
            // 
            // groupBox_Correctable
            // 
            this.groupBox_Correctable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_Correctable.Controls.Add(this.flowLayoutPanel2);
            this.groupBox_Correctable.Controls.Add(this.checkBox_Activated);
            this.groupBox_Correctable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_Correctable.Location = new System.Drawing.Point(338, 4);
            this.groupBox_Correctable.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Correctable.Name = "groupBox_Correctable";
            this.groupBox_Correctable.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Correctable.Size = new System.Drawing.Size(274, 426);
            this.groupBox_Correctable.TabIndex = 10;
            this.groupBox_Correctable.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label8);
            this.flowLayoutPanel2.Controls.Add(this.dateTimePicker_ActivationDate);
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Controls.Add(this.comboBox_Tren);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.comboBox_Personal);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.comboBox_Aerob);
            this.flowLayoutPanel2.Controls.Add(this.label7);
            this.flowLayoutPanel2.Controls.Add(this.comboBox_freez);
            this.flowLayoutPanel2.Enabled = false;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(32, 40);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(219, 251);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Дата Активации абонемента";
            // 
            // dateTimePicker_ActivationDate
            // 
            this.dateTimePicker_ActivationDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker_ActivationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker_ActivationDate.Location = new System.Drawing.Point(4, 22);
            this.dateTimePicker_ActivationDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker_ActivationDate.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker_ActivationDate.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_ActivationDate.Name = "dateTimePicker_ActivationDate";
            this.dateTimePicker_ActivationDate.Size = new System.Drawing.Size(205, 26);
            this.dateTimePicker_ActivationDate.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 18);
            this.label9.TabIndex = 19;
            this.label9.Text = "Тренажерный Зал";
            // 
            // comboBox_Tren
            // 
            this.comboBox_Tren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tren.Enabled = false;
            this.comboBox_Tren.FormattingEnabled = true;
            this.comboBox_Tren.Location = new System.Drawing.Point(3, 73);
            this.comboBox_Tren.Name = "comboBox_Tren";
            this.comboBox_Tren.Size = new System.Drawing.Size(134, 24);
            this.comboBox_Tren.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Персональные ";
            // 
            // comboBox_Personal
            // 
            this.comboBox_Personal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Personal.Enabled = false;
            this.comboBox_Personal.FormattingEnabled = true;
            this.comboBox_Personal.Location = new System.Drawing.Point(3, 121);
            this.comboBox_Personal.Name = "comboBox_Personal";
            this.comboBox_Personal.Size = new System.Drawing.Size(134, 24);
            this.comboBox_Personal.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Аэробные";
            // 
            // comboBox_Aerob
            // 
            this.comboBox_Aerob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Aerob.Enabled = false;
            this.comboBox_Aerob.FormattingEnabled = true;
            this.comboBox_Aerob.Location = new System.Drawing.Point(3, 169);
            this.comboBox_Aerob.Name = "comboBox_Aerob";
            this.comboBox_Aerob.Size = new System.Drawing.Size(134, 24);
            this.comboBox_Aerob.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Заморозка";
            // 
            // comboBox_freez
            // 
            this.comboBox_freez.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_freez.Enabled = false;
            this.comboBox_freez.FormattingEnabled = true;
            this.comboBox_freez.Location = new System.Drawing.Point(3, 217);
            this.comboBox_freez.Name = "comboBox_freez";
            this.comboBox_freez.Size = new System.Drawing.Size(134, 24);
            this.comboBox_freez.TabIndex = 17;
            // 
            // checkBox_Activated
            // 
            this.checkBox_Activated.AutoSize = true;
            this.checkBox_Activated.Location = new System.Drawing.Point(10, 9);
            this.checkBox_Activated.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Activated.Name = "checkBox_Activated";
            this.checkBox_Activated.Size = new System.Drawing.Size(256, 20);
            this.checkBox_Activated.TabIndex = 0;
            this.checkBox_Activated.Text = "Корректировка Абонемента/Карты";
            this.checkBox_Activated.UseVisualStyleBackColor = true;
            this.checkBox_Activated.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBox_Activated_MouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.groupBox_Correctable);
            this.flowLayoutPanel1.Controls.Add(this.groupBox_Details);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(697, 447);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // groupBox_Details
            // 
            this.groupBox_Details.Location = new System.Drawing.Point(619, 3);
            this.groupBox_Details.Name = "groupBox_Details";
            this.groupBox_Details.Size = new System.Drawing.Size(550, 427);
            this.groupBox_Details.TabIndex = 13;
            this.groupBox_Details.TabStop = false;
            this.groupBox_Details.Text = "Детали:";
            this.groupBox_Details.Visible = false;
            // 
            // AbonementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 562);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(664, 605);
            this.Name = "AbonementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление Абонемента/Карты";
            this.Load += new System.EventHandler(this.AbonementForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel_AbonType.ResumeLayout(false);
            this.panel_AbonType.PerformLayout();
            this.panel_ClubCardType.ResumeLayout(false);
            this.panel_ClubCardType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel_TypeTren.ResumeLayout(false);
            this.panel_TypeTren.PerformLayout();
            this.panel_Spa.ResumeLayout(false);
            this.panel_Spa.PerformLayout();
            this.panel_TimeTren.ResumeLayout(false);
            this.panel_TimeTren.PerformLayout();
            this.panel_PayStatus.ResumeLayout(false);
            this.panel_PayStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.groupBox_Correctable.ResumeLayout(false);
            this.groupBox_Correctable.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button button_Aplly;
        private Button button2_Cancel;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel_AbonType;
        private ComboBox comboBox_Abonem;
        private RadioButton radioButton_Abonement;
        private Panel panel_ClubCardType;
        private RadioButton radioButton_ClubCard;
        private ComboBox comboBox_ClubCard;
        private RadioButton radioButton_Single;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel_TypeTren;
        private ComboBox comboBox_TypeTren;
        private Label label2;
        private Panel panel_Spa;
        private ComboBox comboBox_spa;
        private Label label4;
        private Panel panel_TimeTren;
        private ComboBox comboBox_time;
        private Label label3;
        private Panel panel_PayStatus;
        private Label label5;
        private ComboBox comboBox_Pay;
        private DateTimePicker dateTimePicker_ActivationDate;
        private GroupBox groupBox_Correctable;
        private CheckBox checkBox_Activated;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label8;
        private Label label1;
        private Label label6;
        private Label label7;
        private ComboBox comboBox_Personal;
        private ComboBox comboBox_Aerob;
        private ComboBox comboBox_freez;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private Label label9;
        private ComboBox comboBox_Tren;
        private PictureBox pictureBox8;
        private RadioButton radioButton_guest;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox_Details;
    }
}