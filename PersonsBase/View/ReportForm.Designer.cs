namespace PersonsBase.View
{
    partial class ReportForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox_All_Options = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox_Status = new System.Windows.Forms.GroupBox();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.groupBox_LastVisit = new System.Windows.Forms.GroupBox();
            this.comboBox_LastVisit = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker_Visit = new System.Windows.Forms.DateTimePicker();
            this.groupBox_Gender = new System.Windows.Forms.GroupBox();
            this.checkedListBox_Gender = new System.Windows.Forms.CheckedListBox();
            this.groupBox_TypeAbon = new System.Windows.Forms.GroupBox();
            this.checkedListBox_TypeAbon = new System.Windows.Forms.CheckedListBox();
            this.groupBox_TimeTren = new System.Windows.Forms.GroupBox();
            this.checkedListBox_TimeTren = new System.Windows.Forms.CheckedListBox();
            this.groupBox_Pay = new System.Windows.Forms.GroupBox();
            this.checkedListBox_Pay = new System.Windows.Forms.CheckedListBox();
            this.groupBox_Age = new System.Windows.Forms.GroupBox();
            this.checkedListBox_Age = new System.Windows.Forms.CheckedListBox();
            this.groupBox_Activation = new System.Windows.Forms.GroupBox();
            this.checkedListBox_Activation = new System.Windows.Forms.CheckedListBox();
            this.dataGridView_Persons = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox_All_Options.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox_Status.SuspendLayout();
            this.groupBox_LastVisit.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_Gender.SuspendLayout();
            this.groupBox_TypeAbon.SuspendLayout();
            this.groupBox_TimeTren.SuspendLayout();
            this.groupBox_Pay.SuspendLayout();
            this.groupBox_Age.SuspendLayout();
            this.groupBox_Activation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Persons)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 469);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1229, 40);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 4);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(207, 32);
            this.button3.TabIndex = 3;
            this.button3.Text = "Сохранить в Excel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Click_SaveExcel);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(219, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(207, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // groupBox_All_Options
            // 
            this.groupBox_All_Options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_All_Options.Controls.Add(this.flowLayoutPanel2);
            this.groupBox_All_Options.Location = new System.Drawing.Point(4, 12);
            this.groupBox_All_Options.Name = "groupBox_All_Options";
            this.groupBox_All_Options.Size = new System.Drawing.Size(235, 451);
            this.groupBox_All_Options.TabIndex = 2;
            this.groupBox_All_Options.TabStop = false;
            this.groupBox_All_Options.Text = "Параметры клиентов";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.groupBox_Status);
            this.flowLayoutPanel2.Controls.Add(this.groupBox_LastVisit);
            this.flowLayoutPanel2.Controls.Add(this.groupBox1);
            this.flowLayoutPanel2.Controls.Add(this.groupBox_Gender);
            this.flowLayoutPanel2.Controls.Add(this.groupBox_TypeAbon);
            this.flowLayoutPanel2.Controls.Add(this.groupBox_TimeTren);
            this.flowLayoutPanel2.Controls.Add(this.groupBox_Pay);
            this.flowLayoutPanel2.Controls.Add(this.groupBox_Age);
            this.flowLayoutPanel2.Controls.Add(this.groupBox_Activation);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 20);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(229, 428);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // groupBox_Status
            // 
            this.groupBox_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Status.Controls.Add(this.comboBox_Status);
            this.groupBox_Status.Location = new System.Drawing.Point(3, 3);
            this.groupBox_Status.Name = "groupBox_Status";
            this.groupBox_Status.Size = new System.Drawing.Size(186, 59);
            this.groupBox_Status.TabIndex = 5;
            this.groupBox_Status.TabStop = false;
            this.groupBox_Status.Text = "Статус Клиента";
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.Location = new System.Drawing.Point(3, 20);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(180, 26);
            this.comboBox_Status.TabIndex = 0;
            this.comboBox_Status.SelectedIndexChanged += new System.EventHandler(this.comboBox_Status_SelectedIndexChanged);
            // 
            // groupBox_LastVisit
            // 
            this.groupBox_LastVisit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_LastVisit.Controls.Add(this.comboBox_LastVisit);
            this.groupBox_LastVisit.Location = new System.Drawing.Point(3, 68);
            this.groupBox_LastVisit.Name = "groupBox_LastVisit";
            this.groupBox_LastVisit.Size = new System.Drawing.Size(186, 52);
            this.groupBox_LastVisit.TabIndex = 8;
            this.groupBox_LastVisit.TabStop = false;
            this.groupBox_LastVisit.Text = "Последнее Посещение";
            // 
            // comboBox_LastVisit
            // 
            this.comboBox_LastVisit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_LastVisit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_LastVisit.FormattingEnabled = true;
            this.comboBox_LastVisit.Location = new System.Drawing.Point(3, 20);
            this.comboBox_LastVisit.Name = "comboBox_LastVisit";
            this.comboBox_LastVisit.Size = new System.Drawing.Size(180, 26);
            this.comboBox_LastVisit.TabIndex = 1;
            this.comboBox_LastVisit.SelectedIndexChanged += new System.EventHandler(this.comboBox_LastVisit_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dateTimePicker_Visit);
            this.groupBox1.Location = new System.Drawing.Point(3, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 86);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дата Посещения";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сброс";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_resetDate_Click);
            // 
            // dateTimePicker_Visit
            // 
            this.dateTimePicker_Visit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker_Visit.Location = new System.Drawing.Point(3, 20);
            this.dateTimePicker_Visit.Name = "dateTimePicker_Visit";
            this.dateTimePicker_Visit.Size = new System.Drawing.Size(180, 24);
            this.dateTimePicker_Visit.TabIndex = 0;
            this.dateTimePicker_Visit.ValueChanged += new System.EventHandler(this.dateTimePicker_Visit_ValueChanged);
            // 
            // groupBox_Gender
            // 
            this.groupBox_Gender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Gender.Controls.Add(this.checkedListBox_Gender);
            this.groupBox_Gender.Location = new System.Drawing.Point(3, 218);
            this.groupBox_Gender.Name = "groupBox_Gender";
            this.groupBox_Gender.Size = new System.Drawing.Size(186, 86);
            this.groupBox_Gender.TabIndex = 1;
            this.groupBox_Gender.TabStop = false;
            this.groupBox_Gender.Text = "Пол";
            // 
            // checkedListBox_Gender
            // 
            this.checkedListBox_Gender.CheckOnClick = true;
            this.checkedListBox_Gender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_Gender.FormattingEnabled = true;
            this.checkedListBox_Gender.Items.AddRange(new object[] {
            "М",
            "Ж",
            "H"});
            this.checkedListBox_Gender.Location = new System.Drawing.Point(3, 20);
            this.checkedListBox_Gender.Name = "checkedListBox_Gender";
            this.checkedListBox_Gender.Size = new System.Drawing.Size(180, 63);
            this.checkedListBox_Gender.TabIndex = 1;
            this.checkedListBox_Gender.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_Gender_SelectedIndexChanged);
            // 
            // groupBox_TypeAbon
            // 
            this.groupBox_TypeAbon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_TypeAbon.Controls.Add(this.checkedListBox_TypeAbon);
            this.groupBox_TypeAbon.Location = new System.Drawing.Point(3, 310);
            this.groupBox_TypeAbon.Name = "groupBox_TypeAbon";
            this.groupBox_TypeAbon.Size = new System.Drawing.Size(186, 89);
            this.groupBox_TypeAbon.TabIndex = 5;
            this.groupBox_TypeAbon.TabStop = false;
            this.groupBox_TypeAbon.Text = "Вид Абонемента";
            // 
            // checkedListBox_TypeAbon
            // 
            this.checkedListBox_TypeAbon.CheckOnClick = true;
            this.checkedListBox_TypeAbon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_TypeAbon.FormattingEnabled = true;
            this.checkedListBox_TypeAbon.Items.AddRange(new object[] {
            "Абон",
            "Клубн",
            "Разов"});
            this.checkedListBox_TypeAbon.Location = new System.Drawing.Point(3, 20);
            this.checkedListBox_TypeAbon.Name = "checkedListBox_TypeAbon";
            this.checkedListBox_TypeAbon.Size = new System.Drawing.Size(180, 66);
            this.checkedListBox_TypeAbon.TabIndex = 3;
            this.checkedListBox_TypeAbon.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_TypeAbon_SelectedIndexChanged);
            // 
            // groupBox_TimeTren
            // 
            this.groupBox_TimeTren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_TimeTren.Controls.Add(this.checkedListBox_TimeTren);
            this.groupBox_TimeTren.Location = new System.Drawing.Point(3, 405);
            this.groupBox_TimeTren.Name = "groupBox_TimeTren";
            this.groupBox_TimeTren.Size = new System.Drawing.Size(186, 69);
            this.groupBox_TimeTren.TabIndex = 6;
            this.groupBox_TimeTren.TabStop = false;
            this.groupBox_TimeTren.Text = "Время посещения";
            // 
            // checkedListBox_TimeTren
            // 
            this.checkedListBox_TimeTren.CheckOnClick = true;
            this.checkedListBox_TimeTren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_TimeTren.FormattingEnabled = true;
            this.checkedListBox_TimeTren.Items.AddRange(new object[] {
            "Утр",
            "День"});
            this.checkedListBox_TimeTren.Location = new System.Drawing.Point(3, 20);
            this.checkedListBox_TimeTren.Name = "checkedListBox_TimeTren";
            this.checkedListBox_TimeTren.Size = new System.Drawing.Size(180, 46);
            this.checkedListBox_TimeTren.TabIndex = 3;
            this.checkedListBox_TimeTren.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_TimeTren_SelectedIndexChanged);
            // 
            // groupBox_Pay
            // 
            this.groupBox_Pay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Pay.Controls.Add(this.checkedListBox_Pay);
            this.groupBox_Pay.Location = new System.Drawing.Point(3, 480);
            this.groupBox_Pay.Name = "groupBox_Pay";
            this.groupBox_Pay.Size = new System.Drawing.Size(186, 69);
            this.groupBox_Pay.TabIndex = 4;
            this.groupBox_Pay.TabStop = false;
            this.groupBox_Pay.Text = "Оплата";
            // 
            // checkedListBox_Pay
            // 
            this.checkedListBox_Pay.CheckOnClick = true;
            this.checkedListBox_Pay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_Pay.FormattingEnabled = true;
            this.checkedListBox_Pay.Items.AddRange(new object[] {
            "Н",
            "О"});
            this.checkedListBox_Pay.Location = new System.Drawing.Point(3, 20);
            this.checkedListBox_Pay.Name = "checkedListBox_Pay";
            this.checkedListBox_Pay.Size = new System.Drawing.Size(180, 46);
            this.checkedListBox_Pay.TabIndex = 0;
            this.checkedListBox_Pay.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_Pay_SelectedIndexChanged);
            // 
            // groupBox_Age
            // 
            this.groupBox_Age.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Age.Controls.Add(this.checkedListBox_Age);
            this.groupBox_Age.Location = new System.Drawing.Point(3, 555);
            this.groupBox_Age.Name = "groupBox_Age";
            this.groupBox_Age.Size = new System.Drawing.Size(186, 85);
            this.groupBox_Age.TabIndex = 0;
            this.groupBox_Age.TabStop = false;
            this.groupBox_Age.Text = "Возраст";
            // 
            // checkedListBox_Age
            // 
            this.checkedListBox_Age.CheckOnClick = true;
            this.checkedListBox_Age.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_Age.FormattingEnabled = true;
            this.checkedListBox_Age.Items.AddRange(new object[] {
            "До 30 лет_Temp",
            "30 до 40 лет_Temp",
            "40 лет_Temp"});
            this.checkedListBox_Age.Location = new System.Drawing.Point(3, 20);
            this.checkedListBox_Age.Name = "checkedListBox_Age";
            this.checkedListBox_Age.Size = new System.Drawing.Size(180, 62);
            this.checkedListBox_Age.TabIndex = 0;
            this.checkedListBox_Age.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_Age_SelectedIndexChanged);
            // 
            // groupBox_Activation
            // 
            this.groupBox_Activation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Activation.Controls.Add(this.checkedListBox_Activation);
            this.groupBox_Activation.Location = new System.Drawing.Point(3, 646);
            this.groupBox_Activation.Name = "groupBox_Activation";
            this.groupBox_Activation.Size = new System.Drawing.Size(186, 70);
            this.groupBox_Activation.TabIndex = 7;
            this.groupBox_Activation.TabStop = false;
            this.groupBox_Activation.Text = "Активация";
            // 
            // checkedListBox_Activation
            // 
            this.checkedListBox_Activation.CheckOnClick = true;
            this.checkedListBox_Activation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_Activation.FormattingEnabled = true;
            this.checkedListBox_Activation.Items.AddRange(new object[] {
            "A",
            "N"});
            this.checkedListBox_Activation.Location = new System.Drawing.Point(3, 20);
            this.checkedListBox_Activation.Name = "checkedListBox_Activation";
            this.checkedListBox_Activation.Size = new System.Drawing.Size(180, 47);
            this.checkedListBox_Activation.TabIndex = 2;
            this.checkedListBox_Activation.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_Activation_SelectedIndexChanged);
            // 
            // dataGridView_Persons
            // 
            this.dataGridView_Persons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Persons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView_Persons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Persons.Location = new System.Drawing.Point(245, 12);
            this.dataGridView_Persons.MultiSelect = false;
            this.dataGridView_Persons.Name = "dataGridView_Persons";
            this.dataGridView_Persons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Persons.Size = new System.Drawing.Size(972, 451);
            this.dataGridView_Persons.TabIndex = 3;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 509);
            this.Controls.Add(this.dataGridView_Persons);
            this.Controls.Add(this.groupBox_All_Options);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генератор Отчетов";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox_All_Options.ResumeLayout(false);
            this.groupBox_All_Options.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox_Status.ResumeLayout(false);
            this.groupBox_LastVisit.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox_Gender.ResumeLayout(false);
            this.groupBox_TypeAbon.ResumeLayout(false);
            this.groupBox_TimeTren.ResumeLayout(false);
            this.groupBox_Pay.ResumeLayout(false);
            this.groupBox_Age.ResumeLayout(false);
            this.groupBox_Activation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Persons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox_All_Options;
        private System.Windows.Forms.GroupBox groupBox_Age;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView_Persons;
        private System.Windows.Forms.GroupBox groupBox_Pay;
        private System.Windows.Forms.GroupBox groupBox_TypeAbon;
        private System.Windows.Forms.GroupBox groupBox_Status;
        private System.Windows.Forms.GroupBox groupBox_TimeTren;
        private System.Windows.Forms.GroupBox groupBox_Gender;
        private System.Windows.Forms.GroupBox groupBox_Activation;
        private System.Windows.Forms.GroupBox groupBox_LastVisit;
        private System.Windows.Forms.CheckedListBox checkedListBox_Age;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckedListBox checkedListBox_Pay;
        private System.Windows.Forms.CheckedListBox checkedListBox_Gender;
        private System.Windows.Forms.CheckedListBox checkedListBox_Activation;
        private System.Windows.Forms.CheckedListBox checkedListBox_TypeAbon;
        private System.Windows.Forms.ComboBox comboBox_LastVisit;
        private System.Windows.Forms.ComboBox comboBox_Status;
        private System.Windows.Forms.CheckedListBox checkedListBox_TimeTren;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Visit;
        private System.Windows.Forms.Button button1;
    }
}