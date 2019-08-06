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
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.radioButton_personal = new System.Windows.Forms.RadioButton();
         this.radioButton_aerob = new System.Windows.Forms.RadioButton();
         this.radioButton_tren = new System.Windows.Forms.RadioButton();
         this.pictureBox_person = new System.Windows.Forms.PictureBox();
         this.pictureBox_aero = new System.Windows.Forms.PictureBox();
         this.pictureBox_tren = new System.Windows.Forms.PictureBox();
         this.tableLayoutPanel1.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.tableLayoutPanel2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_person)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_aero)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tren)).BeginInit();
         this.SuspendLayout();
         // 
         // button_Ok
         // 
         this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button_Ok.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button_Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_Ok.Location = new System.Drawing.Point(2, 2);
         this.button_Ok.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.button_Ok.Name = "button_Ok";
         this.button_Ok.Size = new System.Drawing.Size(187, 32);
         this.button_Ok.TabIndex = 0;
         this.button_Ok.Text = "Применить";
         this.button_Ok.UseVisualStyleBackColor = true;
         this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Controls.Add(this.button_Ok, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.button_Cancel, 1, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 140);
         this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(382, 36);
         this.tableLayoutPanel1.TabIndex = 1;
         // 
         // button_Cancel
         // 
         this.button_Cancel.AutoSize = true;
         this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.button_Cancel.Location = new System.Drawing.Point(193, 2);
         this.button_Cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.button_Cancel.Name = "button_Cancel";
         this.button_Cancel.Size = new System.Drawing.Size(187, 32);
         this.button_Cancel.TabIndex = 1;
         this.button_Cancel.Text = "Отмена";
         this.button_Cancel.UseVisualStyleBackColor = true;
         this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.tableLayoutPanel2);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox1.Location = new System.Drawing.Point(0, 0);
         this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.groupBox1.Size = new System.Drawing.Size(382, 140);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.ColumnCount = 2;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.875F));
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.125F));
         this.tableLayoutPanel2.Controls.Add(this.radioButton_personal, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.radioButton_aerob, 1, 1);
         this.tableLayoutPanel2.Controls.Add(this.radioButton_tren, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.pictureBox_person, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.pictureBox_aero, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.pictureBox_tren, 0, 2);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 15);
         this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 4;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel2.Size = new System.Drawing.Size(378, 123);
         this.tableLayoutPanel2.TabIndex = 3;
         // 
         // radioButton_personal
         // 
         this.radioButton_personal.AutoSize = true;
         this.radioButton_personal.Dock = System.Windows.Forms.DockStyle.Left;
         this.radioButton_personal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.radioButton_personal.Location = new System.Drawing.Point(65, 2);
         this.radioButton_personal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.radioButton_personal.Name = "radioButton_personal";
         this.radioButton_personal.Size = new System.Drawing.Size(138, 34);
         this.radioButton_personal.TabIndex = 0;
         this.radioButton_personal.TabStop = true;
         this.radioButton_personal.Text = "Персональная";
         this.radioButton_personal.UseVisualStyleBackColor = true;
         this.radioButton_personal.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
         // 
         // radioButton_aerob
         // 
         this.radioButton_aerob.AutoSize = true;
         this.radioButton_aerob.Dock = System.Windows.Forms.DockStyle.Left;
         this.radioButton_aerob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.radioButton_aerob.Location = new System.Drawing.Point(65, 40);
         this.radioButton_aerob.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.radioButton_aerob.Name = "radioButton_aerob";
         this.radioButton_aerob.Size = new System.Drawing.Size(101, 34);
         this.radioButton_aerob.TabIndex = 1;
         this.radioButton_aerob.TabStop = true;
         this.radioButton_aerob.Text = "Аэробная";
         this.radioButton_aerob.UseVisualStyleBackColor = true;
         this.radioButton_aerob.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
         // 
         // radioButton_tren
         // 
         this.radioButton_tren.AutoSize = true;
         this.radioButton_tren.Dock = System.Windows.Forms.DockStyle.Left;
         this.radioButton_tren.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.radioButton_tren.Location = new System.Drawing.Point(65, 78);
         this.radioButton_tren.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.radioButton_tren.Name = "radioButton_tren";
         this.radioButton_tren.Size = new System.Drawing.Size(164, 35);
         this.radioButton_tren.TabIndex = 2;
         this.radioButton_tren.TabStop = true;
         this.radioButton_tren.Text = "Тренажерный Зал";
         this.radioButton_tren.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         this.radioButton_tren.UseVisualStyleBackColor = true;
         this.radioButton_tren.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
         // 
         // pictureBox_person
         // 
         this.pictureBox_person.BackColor = System.Drawing.Color.White;
         this.pictureBox_person.Image = global::PersonsBase.Properties.Resources.Personal;
         this.pictureBox_person.Location = new System.Drawing.Point(2, 2);
         this.pictureBox_person.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.pictureBox_person.Name = "pictureBox_person";
         this.pictureBox_person.Size = new System.Drawing.Size(56, 34);
         this.pictureBox_person.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox_person.TabIndex = 3;
         this.pictureBox_person.TabStop = false;
         // 
         // pictureBox_aero
         // 
         this.pictureBox_aero.BackColor = System.Drawing.Color.White;
         this.pictureBox_aero.Image = global::PersonsBase.Properties.Resources.Aerob;
         this.pictureBox_aero.Location = new System.Drawing.Point(2, 40);
         this.pictureBox_aero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.pictureBox_aero.Name = "pictureBox_aero";
         this.pictureBox_aero.Size = new System.Drawing.Size(56, 34);
         this.pictureBox_aero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox_aero.TabIndex = 4;
         this.pictureBox_aero.TabStop = false;
         // 
         // pictureBox_tren
         // 
         this.pictureBox_tren.BackColor = System.Drawing.Color.White;
         this.pictureBox_tren.Image = global::PersonsBase.Properties.Resources.TrenZal;
         this.pictureBox_tren.Location = new System.Drawing.Point(2, 78);
         this.pictureBox_tren.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.pictureBox_tren.Name = "pictureBox_tren";
         this.pictureBox_tren.Size = new System.Drawing.Size(56, 35);
         this.pictureBox_tren.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox_tren.TabIndex = 5;
         this.pictureBox_tren.TabStop = false;
         // 
         // WorkoutForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(382, 176);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "WorkoutForm";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Выберите Тренировку";
         this.Load += new System.EventHandler(this.WorkoutForm_Load);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_person)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_aero)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tren)).EndInit();
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
      private TableLayoutPanel tableLayoutPanel2;
      private PictureBox pictureBox_person;
      private PictureBox pictureBox_aero;
      private PictureBox pictureBox_tren;
   }
}