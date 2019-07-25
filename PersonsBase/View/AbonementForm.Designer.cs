namespace PBase
{
   partial class AbonementForm
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
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.button_Aplly = new System.Windows.Forms.Button();
         this.button2_Cancel = new System.Windows.Forms.Button();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.panel_AbonType = new System.Windows.Forms.Panel();
         this.comboBox_Abonem = new System.Windows.Forms.ComboBox();
         this.radioButton_Abonement = new System.Windows.Forms.RadioButton();
         this.panel_ClubCardType = new System.Windows.Forms.Panel();
         this.radioButton_ClubCard = new System.Windows.Forms.RadioButton();
         this.comboBox_ClubCard = new System.Windows.Forms.ComboBox();
         this.radioButton_Single = new System.Windows.Forms.RadioButton();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
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
         this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
         this.panel1 = new System.Windows.Forms.Panel();
         this.tableLayoutPanel1.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         this.panel_AbonType.SuspendLayout();
         this.panel_ClubCardType.SuspendLayout();
         this.groupBox4.SuspendLayout();
         this.tableLayoutPanel3.SuspendLayout();
         this.panel_TypeTren.SuspendLayout();
         this.panel_Spa.SuspendLayout();
         this.panel_TimeTren.SuspendLayout();
         this.panel_PayStatus.SuspendLayout();
         this.flowLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Controls.Add(this.button_Aplly, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.button2_Cancel, 1, 0);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 521);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(414, 39);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // button_Aplly
         // 
         this.button_Aplly.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button_Aplly.Location = new System.Drawing.Point(3, 3);
         this.button_Aplly.Name = "button_Aplly";
         this.button_Aplly.Size = new System.Drawing.Size(201, 33);
         this.button_Aplly.TabIndex = 0;
         this.button_Aplly.Text = "Применить";
         this.button_Aplly.UseVisualStyleBackColor = true;
         this.button_Aplly.Click += new System.EventHandler(this.button_Aplly_Click);
         // 
         // button2_Cancel
         // 
         this.button2_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button2_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button2_Cancel.Location = new System.Drawing.Point(210, 3);
         this.button2_Cancel.Name = "button2_Cancel";
         this.button2_Cancel.Size = new System.Drawing.Size(201, 33);
         this.button2_Cancel.TabIndex = 1;
         this.button2_Cancel.Text = "Отмена";
         this.button2_Cancel.UseVisualStyleBackColor = true;
         this.button2_Cancel.Click += new System.EventHandler(this.button_Cancel);
         // 
         // groupBox3
         // 
         this.groupBox3.AutoSize = true;
         this.groupBox3.Controls.Add(this.tableLayoutPanel2);
         this.groupBox3.Location = new System.Drawing.Point(3, 3);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this.groupBox3.Size = new System.Drawing.Size(405, 159);
         this.groupBox3.TabIndex = 7;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Варианты Занятий";
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.AutoSize = true;
         this.tableLayoutPanel2.ColumnCount = 2;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.54082F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.45918F));
         this.tableLayoutPanel2.Controls.Add(this.panel_AbonType, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.panel_ClubCardType, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.radioButton_Single, 1, 2);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 4;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.Size = new System.Drawing.Size(399, 138);
         this.tableLayoutPanel2.TabIndex = 0;
         // 
         // panel_AbonType
         // 
         this.panel_AbonType.Controls.Add(this.comboBox_Abonem);
         this.panel_AbonType.Controls.Add(this.radioButton_Abonement);
         this.panel_AbonType.Location = new System.Drawing.Point(61, 3);
         this.panel_AbonType.Name = "panel_AbonType";
         this.panel_AbonType.Size = new System.Drawing.Size(332, 40);
         this.panel_AbonType.TabIndex = 7;
         // 
         // comboBox_Abonem
         // 
         this.comboBox_Abonem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_Abonem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_Abonem.FormattingEnabled = true;
         this.comboBox_Abonem.Location = new System.Drawing.Point(146, 7);
         this.comboBox_Abonem.Name = "comboBox_Abonem";
         this.comboBox_Abonem.Size = new System.Drawing.Size(183, 28);
         this.comboBox_Abonem.TabIndex = 3;
         // 
         // radioButton_Abonement
         // 
         this.radioButton_Abonement.AutoSize = true;
         this.radioButton_Abonement.Dock = System.Windows.Forms.DockStyle.Left;
         this.radioButton_Abonement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.radioButton_Abonement.Location = new System.Drawing.Point(0, 0);
         this.radioButton_Abonement.Name = "radioButton_Abonement";
         this.radioButton_Abonement.Size = new System.Drawing.Size(112, 40);
         this.radioButton_Abonement.TabIndex = 1;
         this.radioButton_Abonement.Text = "Абонемент";
         this.radioButton_Abonement.UseVisualStyleBackColor = true;
         this.radioButton_Abonement.CheckedChanged += new System.EventHandler(this.radioButton_Abonement_CheckedChanged);
         // 
         // panel_ClubCardType
         // 
         this.panel_ClubCardType.Controls.Add(this.radioButton_ClubCard);
         this.panel_ClubCardType.Controls.Add(this.comboBox_ClubCard);
         this.panel_ClubCardType.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_ClubCardType.Location = new System.Drawing.Point(61, 49);
         this.panel_ClubCardType.Name = "panel_ClubCardType";
         this.panel_ClubCardType.Size = new System.Drawing.Size(335, 40);
         this.panel_ClubCardType.TabIndex = 7;
         // 
         // radioButton_ClubCard
         // 
         this.radioButton_ClubCard.AutoSize = true;
         this.radioButton_ClubCard.Dock = System.Windows.Forms.DockStyle.Left;
         this.radioButton_ClubCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.radioButton_ClubCard.Location = new System.Drawing.Point(0, 0);
         this.radioButton_ClubCard.Name = "radioButton_ClubCard";
         this.radioButton_ClubCard.Size = new System.Drawing.Size(140, 40);
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
         this.comboBox_ClubCard.Location = new System.Drawing.Point(146, 7);
         this.comboBox_ClubCard.Name = "comboBox_ClubCard";
         this.comboBox_ClubCard.Size = new System.Drawing.Size(186, 28);
         this.comboBox_ClubCard.TabIndex = 3;
         this.comboBox_ClubCard.Visible = false;
         // 
         // radioButton_Single
         // 
         this.radioButton_Single.AutoSize = true;
         this.radioButton_Single.Dock = System.Windows.Forms.DockStyle.Left;
         this.radioButton_Single.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.radioButton_Single.Location = new System.Drawing.Point(61, 95);
         this.radioButton_Single.Name = "radioButton_Single";
         this.radioButton_Single.Size = new System.Drawing.Size(178, 40);
         this.radioButton_Single.TabIndex = 2;
         this.radioButton_Single.Text = "Разовое посещение";
         this.radioButton_Single.UseVisualStyleBackColor = true;
         this.radioButton_Single.CheckedChanged += new System.EventHandler(this.radioButton_Single_CheckedChanged);
         // 
         // groupBox4
         // 
         this.groupBox4.Controls.Add(this.tableLayoutPanel3);
         this.groupBox4.Location = new System.Drawing.Point(3, 194);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(405, 295);
         this.groupBox4.TabIndex = 8;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Опции";
         // 
         // tableLayoutPanel3
         // 
         this.tableLayoutPanel3.AutoSize = true;
         this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.tableLayoutPanel3.ColumnCount = 2;
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.58974F));
         this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.41026F));
         this.tableLayoutPanel3.Controls.Add(this.panel_TypeTren, 1, 0);
         this.tableLayoutPanel3.Controls.Add(this.panel_Spa, 1, 2);
         this.tableLayoutPanel3.Controls.Add(this.panel_TimeTren, 1, 1);
         this.tableLayoutPanel3.Controls.Add(this.panel_PayStatus, 1, 8);
         this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
         this.tableLayoutPanel3.Name = "tableLayoutPanel3";
         this.tableLayoutPanel3.RowCount = 10;
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
         this.tableLayoutPanel3.Size = new System.Drawing.Size(399, 274);
         this.tableLayoutPanel3.TabIndex = 6;
         // 
         // panel_TypeTren
         // 
         this.panel_TypeTren.AutoSize = true;
         this.panel_TypeTren.Controls.Add(this.comboBox_TypeTren);
         this.panel_TypeTren.Controls.Add(this.label2);
         this.panel_TypeTren.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_TypeTren.Location = new System.Drawing.Point(57, 3);
         this.panel_TypeTren.Name = "panel_TypeTren";
         this.panel_TypeTren.Size = new System.Drawing.Size(339, 61);
         this.panel_TypeTren.TabIndex = 7;
         // 
         // comboBox_TypeTren
         // 
         this.comboBox_TypeTren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBox_TypeTren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_TypeTren.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_TypeTren.FormattingEnabled = true;
         this.comboBox_TypeTren.Location = new System.Drawing.Point(3, 30);
         this.comboBox_TypeTren.Name = "comboBox_TypeTren";
         this.comboBox_TypeTren.Size = new System.Drawing.Size(335, 28);
         this.comboBox_TypeTren.TabIndex = 3;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label2.Location = new System.Drawing.Point(3, 6);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(129, 20);
         this.label2.TabIndex = 5;
         this.label2.Text = "Тип Тренировок";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // panel_Spa
         // 
         this.panel_Spa.Controls.Add(this.comboBox_spa);
         this.panel_Spa.Controls.Add(this.label4);
         this.panel_Spa.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_Spa.Location = new System.Drawing.Point(57, 139);
         this.panel_Spa.Name = "panel_Spa";
         this.panel_Spa.Size = new System.Drawing.Size(339, 55);
         this.panel_Spa.TabIndex = 5;
         // 
         // comboBox_spa
         // 
         this.comboBox_spa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBox_spa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_spa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_spa.FormattingEnabled = true;
         this.comboBox_spa.Location = new System.Drawing.Point(3, 27);
         this.comboBox_spa.Name = "comboBox_spa";
         this.comboBox_spa.Size = new System.Drawing.Size(333, 28);
         this.comboBox_spa.TabIndex = 3;
         // 
         // label4
         // 
         this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label4.Location = new System.Drawing.Point(3, 6);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(93, 20);
         this.label4.TabIndex = 2;
         this.label4.Text = "Услуги Спа";
         // 
         // panel_TimeTren
         // 
         this.panel_TimeTren.AutoSize = true;
         this.panel_TimeTren.Controls.Add(this.comboBox_time);
         this.panel_TimeTren.Controls.Add(this.label3);
         this.panel_TimeTren.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_TimeTren.Location = new System.Drawing.Point(57, 70);
         this.panel_TimeTren.Name = "panel_TimeTren";
         this.panel_TimeTren.Size = new System.Drawing.Size(339, 63);
         this.panel_TimeTren.TabIndex = 6;
         // 
         // comboBox_time
         // 
         this.comboBox_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBox_time.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_time.FormattingEnabled = true;
         this.comboBox_time.Location = new System.Drawing.Point(3, 32);
         this.comboBox_time.Name = "comboBox_time";
         this.comboBox_time.Size = new System.Drawing.Size(335, 28);
         this.comboBox_time.TabIndex = 3;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label3.Location = new System.Drawing.Point(3, 6);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(151, 20);
         this.label3.TabIndex = 1;
         this.label3.Text = "Время Тренировок";
         this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // panel_PayStatus
         // 
         this.panel_PayStatus.Controls.Add(this.label5);
         this.panel_PayStatus.Controls.Add(this.comboBox_Pay);
         this.panel_PayStatus.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_PayStatus.Location = new System.Drawing.Point(57, 200);
         this.panel_PayStatus.Name = "panel_PayStatus";
         this.panel_PayStatus.Size = new System.Drawing.Size(339, 55);
         this.panel_PayStatus.TabIndex = 7;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.label5.Location = new System.Drawing.Point(3, 6);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(67, 20);
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
         this.comboBox_Pay.Location = new System.Drawing.Point(3, 27);
         this.comboBox_Pay.Name = "comboBox_Pay";
         this.comboBox_Pay.Size = new System.Drawing.Size(333, 28);
         this.comboBox_Pay.TabIndex = 3;
         // 
         // flowLayoutPanel1
         // 
         this.flowLayoutPanel1.AutoSize = true;
         this.flowLayoutPanel1.Controls.Add(this.groupBox3);
         this.flowLayoutPanel1.Controls.Add(this.panel1);
         this.flowLayoutPanel1.Controls.Add(this.groupBox4);
         this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
         this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 12);
         this.flowLayoutPanel1.Name = "flowLayoutPanel1";
         this.flowLayoutPanel1.Size = new System.Drawing.Size(411, 499);
         this.flowLayoutPanel1.TabIndex = 9;
         // 
         // panel1
         // 
         this.panel1.Location = new System.Drawing.Point(3, 168);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(405, 20);
         this.panel1.TabIndex = 10;
         // 
         // AbonementForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(436, 573);
         this.Controls.Add(this.flowLayoutPanel1);
         this.Controls.Add(this.tableLayoutPanel1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(450, 617);
         this.Name = "AbonementForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Добавление Абонемента/Карты";
         this.Load += new System.EventHandler(this.AbonementForm_Load);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         this.panel_AbonType.ResumeLayout(false);
         this.panel_AbonType.PerformLayout();
         this.panel_ClubCardType.ResumeLayout(false);
         this.panel_ClubCardType.PerformLayout();
         this.groupBox4.ResumeLayout(false);
         this.groupBox4.PerformLayout();
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
         this.flowLayoutPanel1.ResumeLayout(false);
         this.flowLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Button button_Aplly;
      private System.Windows.Forms.Button button2_Cancel;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Panel panel_AbonType;
      private System.Windows.Forms.ComboBox comboBox_Abonem;
      private System.Windows.Forms.RadioButton radioButton_Abonement;
      private System.Windows.Forms.Panel panel_ClubCardType;
      private System.Windows.Forms.RadioButton radioButton_ClubCard;
      private System.Windows.Forms.ComboBox comboBox_ClubCard;
      private System.Windows.Forms.RadioButton radioButton_Single;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
      private System.Windows.Forms.Panel panel_TypeTren;
      private System.Windows.Forms.ComboBox comboBox_TypeTren;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Panel panel_Spa;
      private System.Windows.Forms.ComboBox comboBox_spa;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Panel panel_TimeTren;
      private System.Windows.Forms.ComboBox comboBox_time;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Panel panel_PayStatus;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.ComboBox comboBox_Pay;
      private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
      private System.Windows.Forms.Panel panel1;
   }
}