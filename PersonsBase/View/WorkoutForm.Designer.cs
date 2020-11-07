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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox_TrenerName = new System.Windows.Forms.GroupBox();
            this.comboBox_treners = new System.Windows.Forms.ComboBox();
            this.groupBox_SelectWorkout = new System.Windows.Forms.GroupBox();
            this.comboBox_Time_Name_Workout = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.panel_miniGroup = new System.Windows.Forms.Panel();
            this.radioButton_miniGr = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox_TrenerName.SuspendLayout();
            this.groupBox_SelectWorkout.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel_tren.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tren)).BeginInit();
            this.panel_aero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_aero)).BeginInit();
            this.panel_personal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_person)).BeginInit();
            this.panel_miniGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Ok
            // 
            this.button_Ok.AutoSize = true;
            this.button_Ok.BackColor = System.Drawing.Color.LightGreen;
            this.button_Ok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Ok.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Ok.Location = new System.Drawing.Point(366, 2);
            this.button_Ok.Margin = new System.Windows.Forms.Padding(2);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(392, 40);
            this.button_Ok.TabIndex = 0;
            this.button_Ok.Text = "Применить";
            this.button_Ok.UseVisualStyleBackColor = false;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.89474F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.10526F));
            this.tableLayoutPanel1.Controls.Add(this.button_Ok, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Cancel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 270);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 44);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button_Cancel
            // 
            this.button_Cancel.AutoSize = true;
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Cancel.Location = new System.Drawing.Point(2, 2);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(360, 40);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(760, 270);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.flowLayoutPanel2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(369, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(379, 237);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Дополнительно:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.groupBox_SelectWorkout);
            this.flowLayoutPanel2.Controls.Add(this.groupBox_TrenerName);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(14, 37);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(354, 158);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // groupBox_TrenerName
            // 
            this.groupBox_TrenerName.Controls.Add(this.comboBox_treners);
            this.groupBox_TrenerName.Enabled = false;
            this.groupBox_TrenerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_TrenerName.Location = new System.Drawing.Point(3, 81);
            this.groupBox_TrenerName.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.groupBox_TrenerName.Name = "groupBox_TrenerName";
            this.groupBox_TrenerName.Size = new System.Drawing.Size(351, 60);
            this.groupBox_TrenerName.TabIndex = 7;
            this.groupBox_TrenerName.TabStop = false;
            this.groupBox_TrenerName.Text = "Имя Тренера";
            // 
            // comboBox_treners
            // 
            this.comboBox_treners.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_treners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_treners.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_treners.FormattingEnabled = true;
            this.comboBox_treners.Location = new System.Drawing.Point(1, 26);
            this.comboBox_treners.Name = "comboBox_treners";
            this.comboBox_treners.Size = new System.Drawing.Size(344, 28);
            this.comboBox_treners.TabIndex = 0;
            this.comboBox_treners.SelectedIndexChanged += new System.EventHandler(this.comboBox_treners_SelectedIndexChanged);
            // 
            // groupBox_SelectWorkout
            // 
            this.groupBox_SelectWorkout.Controls.Add(this.comboBox_Time_Name_Workout);
            this.groupBox_SelectWorkout.Enabled = false;
            this.groupBox_SelectWorkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_SelectWorkout.Location = new System.Drawing.Point(3, 3);
            this.groupBox_SelectWorkout.Name = "groupBox_SelectWorkout";
            this.groupBox_SelectWorkout.Size = new System.Drawing.Size(351, 60);
            this.groupBox_SelectWorkout.TabIndex = 6;
            this.groupBox_SelectWorkout.TabStop = false;
            this.groupBox_SelectWorkout.Text = "Время и Название";
            // 
            // comboBox_Time_Name_Workout
            // 
            this.comboBox_Time_Name_Workout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Time_Name_Workout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Time_Name_Workout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_Time_Name_Workout.FormattingEnabled = true;
            this.comboBox_Time_Name_Workout.Location = new System.Drawing.Point(1, 26);
            this.comboBox_Time_Name_Workout.Name = "comboBox_Time_Name_Workout";
            this.comboBox_Time_Name_Workout.Size = new System.Drawing.Size(344, 28);
            this.comboBox_Time_Name_Workout.Sorted = true;
            this.comboBox_Time_Name_Workout.TabIndex = 0;
            this.comboBox_Time_Name_Workout.SelectedIndexChanged += new System.EventHandler(this.comboBox_Time_Name_Workout_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel3);
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 237);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тип Тренировки:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel_tren);
            this.flowLayoutPanel1.Controls.Add(this.panel_aero);
            this.flowLayoutPanel1.Controls.Add(this.panel_personal);
            this.flowLayoutPanel1.Controls.Add(this.panel_miniGroup);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(260, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(63, 196);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // panel_tren
            // 
            this.panel_tren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_tren.Controls.Add(this.pictureBox_tren);
            this.panel_tren.Location = new System.Drawing.Point(3, 3);
            this.panel_tren.Name = "panel_tren";
            this.panel_tren.Size = new System.Drawing.Size(51, 42);
            this.panel_tren.TabIndex = 9;
            // 
            // radioButton_tren
            // 
            this.radioButton_tren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButton_tren.AutoSize = true;
            this.radioButton_tren.Checked = true;
            this.radioButton_tren.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_tren.Location = new System.Drawing.Point(2, 10);
            this.radioButton_tren.Margin = new System.Windows.Forms.Padding(2, 10, 2, 10);
            this.radioButton_tren.Name = "radioButton_tren";
            this.radioButton_tren.Size = new System.Drawing.Size(192, 28);
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
            this.pictureBox_tren.Location = new System.Drawing.Point(6, 0);
            this.pictureBox_tren.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_tren.Name = "pictureBox_tren";
            this.pictureBox_tren.Size = new System.Drawing.Size(45, 42);
            this.pictureBox_tren.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_tren.TabIndex = 5;
            this.pictureBox_tren.TabStop = false;
            // 
            // panel_aero
            // 
            this.panel_aero.Controls.Add(this.pictureBox_aero);
            this.panel_aero.Location = new System.Drawing.Point(3, 51);
            this.panel_aero.Name = "panel_aero";
            this.panel_aero.Size = new System.Drawing.Size(51, 42);
            this.panel_aero.TabIndex = 8;
            // 
            // radioButton_aerob
            // 
            this.radioButton_aerob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButton_aerob.AutoSize = true;
            this.radioButton_aerob.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_aerob.Location = new System.Drawing.Point(2, 58);
            this.radioButton_aerob.Margin = new System.Windows.Forms.Padding(2, 10, 2, 10);
            this.radioButton_aerob.Name = "radioButton_aerob";
            this.radioButton_aerob.Size = new System.Drawing.Size(115, 28);
            this.radioButton_aerob.TabIndex = 1;
            this.radioButton_aerob.Text = "Аэробная";
            this.radioButton_aerob.UseVisualStyleBackColor = true;
            this.radioButton_aerob.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // pictureBox_aero
            // 
            this.pictureBox_aero.BackColor = System.Drawing.Color.White;
            this.pictureBox_aero.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox_aero.Image = global::PersonsBase.Properties.Resources.Aerob;
            this.pictureBox_aero.Location = new System.Drawing.Point(6, 0);
            this.pictureBox_aero.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_aero.Name = "pictureBox_aero";
            this.pictureBox_aero.Size = new System.Drawing.Size(45, 42);
            this.pictureBox_aero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_aero.TabIndex = 4;
            this.pictureBox_aero.TabStop = false;
            // 
            // panel_personal
            // 
            this.panel_personal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_personal.Controls.Add(this.pictureBox_person);
            this.panel_personal.Location = new System.Drawing.Point(3, 99);
            this.panel_personal.Name = "panel_personal";
            this.panel_personal.Size = new System.Drawing.Size(51, 42);
            this.panel_personal.TabIndex = 7;
            // 
            // radioButton_personal
            // 
            this.radioButton_personal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButton_personal.AutoSize = true;
            this.radioButton_personal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_personal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton_personal.Location = new System.Drawing.Point(2, 106);
            this.radioButton_personal.Margin = new System.Windows.Forms.Padding(2, 10, 2, 10);
            this.radioButton_personal.Name = "radioButton_personal";
            this.radioButton_personal.Size = new System.Drawing.Size(157, 28);
            this.radioButton_personal.TabIndex = 0;
            this.radioButton_personal.Text = "Персональная";
            this.radioButton_personal.UseVisualStyleBackColor = true;
            this.radioButton_personal.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // pictureBox_person
            // 
            this.pictureBox_person.BackColor = System.Drawing.Color.White;
            this.pictureBox_person.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox_person.Image = global::PersonsBase.Properties.Resources.Personal21;
            this.pictureBox_person.Location = new System.Drawing.Point(6, 0);
            this.pictureBox_person.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_person.Name = "pictureBox_person";
            this.pictureBox_person.Size = new System.Drawing.Size(45, 42);
            this.pictureBox_person.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_person.TabIndex = 3;
            this.pictureBox_person.TabStop = false;
            // 
            // panel_miniGroup
            // 
            this.panel_miniGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_miniGroup.Controls.Add(this.pictureBox1);
            this.panel_miniGroup.Location = new System.Drawing.Point(3, 147);
            this.panel_miniGroup.Name = "panel_miniGroup";
            this.panel_miniGroup.Size = new System.Drawing.Size(51, 42);
            this.panel_miniGroup.TabIndex = 13;
            // 
            // radioButton_miniGr
            // 
            this.radioButton_miniGr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButton_miniGr.AutoSize = true;
            this.radioButton_miniGr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_miniGr.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton_miniGr.Location = new System.Drawing.Point(2, 154);
            this.radioButton_miniGr.Margin = new System.Windows.Forms.Padding(2, 10, 2, 10);
            this.radioButton_miniGr.Name = "radioButton_miniGr";
            this.radioButton_miniGr.Size = new System.Drawing.Size(145, 28);
            this.radioButton_miniGr.TabIndex = 0;
            this.radioButton_miniGr.Text = "Мини Группа";
            this.radioButton_miniGr.UseVisualStyleBackColor = true;
            this.radioButton_miniGr.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::PersonsBase.Properties.Resources.clientsCopy;
            this.pictureBox1.Location = new System.Drawing.Point(6, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoScroll = true;
            this.flowLayoutPanel3.Controls.Add(this.radioButton_tren);
            this.flowLayoutPanel3.Controls.Add(this.radioButton_aerob);
            this.flowLayoutPanel3.Controls.Add(this.radioButton_personal);
            this.flowLayoutPanel3.Controls.Add(this.radioButton_miniGr);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(43, 27);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(209, 193);
            this.flowLayoutPanel3.TabIndex = 11;
            // 
            // WorkoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(760, 314);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkoutForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройте Тренировку";
            this.Load += new System.EventHandler(this.WorkoutForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox_TrenerName.ResumeLayout(false);
            this.groupBox_SelectWorkout.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel_tren.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tren)).EndInit();
            this.panel_aero.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_aero)).EndInit();
            this.panel_personal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_person)).EndInit();
            this.panel_miniGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
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
        private GroupBox groupBox_SelectWorkout;
        private Panel panel_personal;
        private Panel panel_tren;
        private Panel panel_aero;
        private FlowLayoutPanel flowLayoutPanel1;
        private ComboBox comboBox_Time_Name_Workout;
        private FlowLayoutPanel flowLayoutPanel2;
        private GroupBox groupBox_TrenerName;
        private ComboBox comboBox_treners;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private Panel panel_miniGroup;
        private RadioButton radioButton_miniGr;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel3;
    }
}