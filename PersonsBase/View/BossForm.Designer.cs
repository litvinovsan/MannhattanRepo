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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_remove = new System.Windows.Forms.Button();
            this.listView_schedule = new System.Windows.Forms.ListView();
            this.columnHeader_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox_add = new System.Windows.Forms.GroupBox();
            this.button_add = new System.Windows.Forms.Button();
            this.comboBox_time_H = new System.Windows.Forms.ComboBox();
            this.textBox_nameTren = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox_time_M = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.myTimeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_add.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myTimeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button_remove);
            this.groupBox1.Controls.Add(this.listView_schedule);
            this.groupBox1.Location = new System.Drawing.Point(260, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 368);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Расписание Групповых тренировок";
            // 
            // button_remove
            // 
            this.button_remove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_remove.Enabled = false;
            this.button_remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_remove.Location = new System.Drawing.Point(6, 333);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(513, 29);
            this.button_remove.TabIndex = 5;
            this.button_remove.Text = "Удалить из расписания";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
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
            this.listView_schedule.Size = new System.Drawing.Size(516, 310);
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
            this.columnHeader_Name.Width = 414;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 411);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox_add);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(793, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Расписание АЗ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox_add
            // 
            this.groupBox_add.Controls.Add(this.groupBox5);
            this.groupBox_add.Controls.Add(this.groupBox4);
            this.groupBox_add.Controls.Add(this.button_add);
            this.groupBox_add.Location = new System.Drawing.Point(6, 6);
            this.groupBox_add.Name = "groupBox_add";
            this.groupBox_add.Size = new System.Drawing.Size(248, 229);
            this.groupBox_add.TabIndex = 7;
            this.groupBox_add.TabStop = false;
            this.groupBox_add.Text = "Создание тренировки в расписании";
            // 
            // button_add
            // 
            this.button_add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_add.Location = new System.Drawing.Point(0, 190);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(236, 29);
            this.button_add.TabIndex = 2;
            this.button_add.Text = "Добавить";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // comboBox_time_H
            // 
            this.comboBox_time_H.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_time_H.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_time_H.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_time_H.ForeColor = System.Drawing.Color.DarkBlue;
            this.comboBox_time_H.FormattingEnabled = true;
            this.comboBox_time_H.Location = new System.Drawing.Point(5, 24);
            this.comboBox_time_H.Name = "comboBox_time_H";
            this.comboBox_time_H.Size = new System.Drawing.Size(110, 28);
            this.comboBox_time_H.TabIndex = 0;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(793, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Списки Персонала";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(406, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 388);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Администраторы:";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 388);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тренерский состав:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.comboBox_time_M);
            this.groupBox4.Controls.Add(this.comboBox_time_H);
            this.groupBox4.Location = new System.Drawing.Point(0, 30);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 63);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Начало в:";
            // 
            // comboBox_time_M
            // 
            this.comboBox_time_M.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_time_M.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_time_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_time_M.ForeColor = System.Drawing.Color.DarkBlue;
            this.comboBox_time_M.FormattingEnabled = true;
            this.comboBox_time_M.Location = new System.Drawing.Point(119, 24);
            this.comboBox_time_M.Name = "comboBox_time_M";
            this.comboBox_time_M.Size = new System.Drawing.Size(111, 28);
            this.comboBox_time_M.TabIndex = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_nameTren);
            this.groupBox5.Location = new System.Drawing.Point(2, 108);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(236, 65);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Название:";
            // 
            // myTimeBindingSource
            // 
            this.myTimeBindingSource.DataSource = typeof(PBase.MyTime);
            // 
            // BossForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 411);
            this.Controls.Add(this.tabControl1);
            this.Name = "BossForm";
            this.Text = "Настройки для Самого Лучшего Руководителя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BossForm_FormClosing);
            this.Load += new System.EventHandler(this.BossForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox_add.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myTimeBindingSource)).EndInit();
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
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.ComboBox comboBox_time_H;
        private System.Windows.Forms.TextBox textBox_nameTren;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.BindingSource myTimeBindingSource;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox_time_M;
    }
}