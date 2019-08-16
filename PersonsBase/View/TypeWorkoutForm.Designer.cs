using System.ComponentModel;
using System.Windows.Forms;

namespace PersonsBase.View
{
   partial class WorkoutForm
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
         this.button_Ok = new System.Windows.Forms.Button();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.button_Cancel = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
         this.panel_tren = new System.Windows.Forms.Panel();
         this.radioButton_tren = new System.Windows.Forms.RadioButton();
         this.pictureBox_tren = new System.Windows.Forms.PictureBox();
         this.panel_aero = new System.Windows.Forms.Panel();
         this.radioButton_aerob = new System.Windows.Forms.RadioButton();
         this.pictureBox_aero = new System.Windows.Forms.PictureBox();
         this.panel_personal = new System.Windows.Forms.Panel();
         this.radioButton_personal = new System.Windows.Forms.RadioButton();
         this.pictureBox_person = new System.Windows.Forms.PictureBox();
         this.groupBox_SelectTrener = new System.Windows.Forms.GroupBox();
         this.comboBox_select_Trener = new System.Windows.Forms.ComboBox();
         this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.tableLayoutPanel1.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.flowLayoutPanel1.SuspendLayout();
         this.panel_tren.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tren)).BeginInit();
         this.panel_aero.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_aero)).BeginInit();
         this.panel_personal.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_person)).BeginInit();
         this.groupBox_SelectTrener.SuspendLayout();
         this.flowLayoutPanel2.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // button_Ok
         // 
         this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button_Ok.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button_Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_Ok.Location = new System.Drawing.Point(2, 2);
         this.button_Ok.Margin = new System.Windows.Forms.Padding(2);
         this.button_Ok.Name = "button_Ok";
         this.button_Ok.Size = new System.Drawing.Size(313, 32);
         this.button_Ok.TabIndex = 0;
         this.button_Ok.Text = "Применить";
         this.button_Ok.UseVisualStyleBackColor = true;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Controls.Add(this.button_Ok, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.button_Cancel, 1, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 196);
         this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(634, 36);
         this.tableLayoutPanel1.TabIndex = 1;
         // 
         // button_Cancel
         // 
         this.button_Cancel.AutoSize = true;
         this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_Cancel.Location = new System.Drawing.Point(319, 2);
         this.button_Cancel.Margin = new System.Windows.Forms.Padding(2);
         this.button_Cancel.Name = "button_Cancel";
         this.button_Cancel.Size = new System.Drawing.Size(313, 32);
         this.button_Cancel.TabIndex = 1;
         this.button_Cancel.Text = "Отмена";
         this.button_Cancel.UseVisualStyleBackColor = true;
         this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.flowLayoutPanel2);
         this.groupBox1.Controls.Add(this.flowLayoutPanel1);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox1.Location = new System.Drawing.Point(0, 0);
         this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
         this.groupBox1.Size = new System.Drawing.Size(634, 196);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         // 
         // flowLayoutPanel1
         // 
         this.flowLayoutPanel1.Controls.Add(this.panel_tren);
         this.flowLayoutPanel1.Controls.Add(this.panel_aero);
         this.flowLayoutPanel1.Controls.Add(this.panel_personal);
         this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 15);
         this.flowLayoutPanel1.Name = "flowLayoutPanel1";
         this.flowLayoutPanel1.Size = new System.Drawing.Size(289, 275);
         this.flowLayoutPanel1.TabIndex = 10;
         // 
         // panel_tren
         // 
         this.panel_tren.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tren.Controls.Add(this.radioButton_tren);
         this.panel_tren.Controls.Add(this.pictureBox_tren);
         this.panel_tren.Location = new System.Drawing.Point(3, 3);
         this.panel_tren.Name = "panel_tren";
         this.panel_tren.Size = new System.Drawing.Size(272, 51);
         this.panel_tren.TabIndex = 9;
         // 
         // radioButton_tren
         // 
         this.radioButton_tren.AutoSize = true;
         this.radioButton_tren.Dock = System.Windows.Forms.DockStyle.Left;
         this.radioButton_tren.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.radioButton_tren.Location = new System.Drawing.Point(0, 0);
         this.radioButton_tren.Margin = new System.Windows.Forms.Padding(2);
         this.radioButton_tren.Name = "radioButton_tren";
         this.radioButton_tren.Size = new System.Drawing.Size(164, 49);
         this.radioButton_tren.TabIndex = 2;
         this.radioButton_tren.TabStop = true;
         this.radioButton_tren.Text = "Тренажерный Зал";
         this.radioButton_tren.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         this.radioButton_tren.UseVisualStyleBackColor = true;
         this.radioButton_tren.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
         // 
         // pictureBox_tren
         // 
         this.pictureBox_tren.BackColor = System.Drawing.Color.White;
         this.pictureBox_tren.Dock = System.Windows.Forms.DockStyle.Right;
         this.pictureBox_tren.Image = global::PersonsBase.Properties.Resources.TrenZal;
         this.pictureBox_tren.Location = new System.Drawing.Point(217, 0);
         this.pictureBox_tren.Margin = new System.Windows.Forms.Padding(2);
         this.pictureBox_tren.Name = "pictureBox_tren";
         this.pictureBox_tren.Size = new System.Drawing.Size(53, 49);
         this.pictureBox_tren.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox_tren.TabIndex = 5;
         this.pictureBox_tren.TabStop = false;
         // 
         // panel_aero
         // 
         this.panel_aero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_aero.Controls.Add(this.radioButton_aerob);
         this.panel_aero.Controls.Add(this.pictureBox_aero);
         this.panel_aero.Location = new System.Drawing.Point(3, 60);
         this.panel_aero.Name = "panel_aero";
         this.panel_aero.Size = new System.Drawing.Size(271, 51);
         this.panel_aero.TabIndex = 8;
         // 
         // radioButton_aerob
         // 
         this.radioButton_aerob.AutoSize = true;
         this.radioButton_aerob.Dock = System.Windows.Forms.DockStyle.Left;
         this.radioButton_aerob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.radioButton_aerob.Location = new System.Drawing.Point(0, 0);
         this.radioButton_aerob.Margin = new System.Windows.Forms.Padding(2);
         this.radioButton_aerob.Name = "radioButton_aerob";
         this.radioButton_aerob.Size = new System.Drawing.Size(101, 49);
         this.radioButton_aerob.TabIndex = 1;
         this.radioButton_aerob.TabStop = true;
         this.radioButton_aerob.Text = "Аэробная";
         this.radioButton_aerob.UseVisualStyleBackColor = true;
         this.radioButton_aerob.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
         // 
         // pictureBox_aero
         // 
         this.pictureBox_aero.BackColor = System.Drawing.Color.White;
         this.pictureBox_aero.Dock = System.Windows.Forms.DockStyle.Right;
         this.pictureBox_aero.Image = global::PersonsBase.Properties.Resources.Aerob;
         this.pictureBox_aero.Location = new System.Drawing.Point(216, 0);
         this.pictureBox_aero.Margin = new System.Windows.Forms.Padding(2);
         this.pictureBox_aero.Name = "pictureBox_aero";
         this.pictureBox_aero.Size = new System.Drawing.Size(53, 49);
         this.pictureBox_aero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox_aero.TabIndex = 4;
         this.pictureBox_aero.TabStop = false;
         // 
         // panel_personal
         // 
         this.panel_personal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this.panel_personal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_personal.Controls.Add(this.radioButton_personal);
         this.panel_personal.Controls.Add(this.pictureBox_person);
         this.panel_personal.Location = new System.Drawing.Point(3, 117);
         this.panel_personal.Name = "panel_personal";
         this.panel_personal.Size = new System.Drawing.Size(270, 51);
         this.panel_personal.TabIndex = 7;
         // 
         // radioButton_personal
         // 
         this.radioButton_personal.AutoSize = true;
         this.radioButton_personal.Dock = System.Windows.Forms.DockStyle.Left;
         this.radioButton_personal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.radioButton_personal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.radioButton_personal.Location = new System.Drawing.Point(0, 0);
         this.radioButton_personal.Margin = new System.Windows.Forms.Padding(2);
         this.radioButton_personal.Name = "radioButton_personal";
         this.radioButton_personal.Size = new System.Drawing.Size(138, 49);
         this.radioButton_personal.TabIndex = 0;
         this.radioButton_personal.TabStop = true;
         this.radioButton_personal.Text = "Персональная";
         this.radioButton_personal.UseVisualStyleBackColor = true;
         this.radioButton_personal.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
         // 
         // pictureBox_person
         // 
         this.pictureBox_person.BackColor = System.Drawing.Color.White;
         this.pictureBox_person.Dock = System.Windows.Forms.DockStyle.Right;
         this.pictureBox_person.Image = global::PersonsBase.Properties.Resources.Personal;
         this.pictureBox_person.Location = new System.Drawing.Point(215, 0);
         this.pictureBox_person.Margin = new System.Windows.Forms.Padding(2);
         this.pictureBox_person.Name = "pictureBox_person";
         this.pictureBox_person.Size = new System.Drawing.Size(53, 49);
         this.pictureBox_person.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox_person.TabIndex = 3;
         this.pictureBox_person.TabStop = false;
         // 
         // groupBox_SelectTrener
         // 
         this.groupBox_SelectTrener.Controls.Add(this.comboBox_select_Trener);
         this.groupBox_SelectTrener.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.groupBox_SelectTrener.Location = new System.Drawing.Point(3, 77);
         this.groupBox_SelectTrener.Name = "groupBox_SelectTrener";
         this.groupBox_SelectTrener.Size = new System.Drawing.Size(318, 71);
         this.groupBox_SelectTrener.TabIndex = 6;
         this.groupBox_SelectTrener.TabStop = false;
         this.groupBox_SelectTrener.Text = "Групповая Тренировка";
         // 
         // comboBox_select_Trener
         // 
         this.comboBox_select_Trener.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBox_select_Trener.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_select_Trener.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox_select_Trener.FormattingEnabled = true;
         this.comboBox_select_Trener.Location = new System.Drawing.Point(1, 37);
         this.comboBox_select_Trener.Name = "comboBox_select_Trener";
         this.comboBox_select_Trener.Size = new System.Drawing.Size(311, 28);
         this.comboBox_select_Trener.TabIndex = 0;
         // 
         // flowLayoutPanel2
         // 
         this.flowLayoutPanel2.Controls.Add(this.groupBox2);
         this.flowLayoutPanel2.Controls.Add(this.groupBox_SelectTrener);
         this.flowLayoutPanel2.Location = new System.Drawing.Point(297, 15);
         this.flowLayoutPanel2.Name = "flowLayoutPanel2";
         this.flowLayoutPanel2.Size = new System.Drawing.Size(329, 181);
         this.flowLayoutPanel2.TabIndex = 11;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.comboBox1);
         this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.groupBox2.Location = new System.Drawing.Point(3, 3);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(318, 68);
         this.groupBox2.TabIndex = 7;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Тренер";
         // 
         // comboBox1
         // 
         this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Location = new System.Drawing.Point(1, 34);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(311, 28);
         this.comboBox1.TabIndex = 0;
         // 
         // WorkoutForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.ClientSize = new System.Drawing.Size(634, 232);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Margin = new System.Windows.Forms.Padding(2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "WorkoutForm";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Настройте Тренировку";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.flowLayoutPanel1.ResumeLayout(false);
         this.panel_tren.ResumeLayout(false);
         this.panel_tren.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tren)).EndInit();
         this.panel_aero.ResumeLayout(false);
         this.panel_aero.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_aero)).EndInit();
         this.panel_personal.ResumeLayout(false);
         this.panel_personal.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_person)).EndInit();
         this.groupBox_SelectTrener.ResumeLayout(false);
         this.flowLayoutPanel2.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private Button button_Ok;
      private TableLayoutPanel tableLayoutPanel1;
      private Button button_Cancel;
      private GroupBox groupBox1;
      private RadioButton radioButton_tren;
      private RadioButton radioButton_aerob;
      private RadioButton radioButton_personal;
      private PictureBox pictureBox_person;
      private PictureBox pictureBox_aero;
      private PictureBox pictureBox_tren;
      private GroupBox groupBox_SelectTrener;
      private Panel panel_personal;
      private Panel panel_tren;
      private Panel panel_aero;
      private FlowLayoutPanel flowLayoutPanel1;
      private ComboBox comboBox_select_Trener;
      private FlowLayoutPanel flowLayoutPanel2;
      private GroupBox groupBox2;
      private ComboBox comboBox1;
   }
}