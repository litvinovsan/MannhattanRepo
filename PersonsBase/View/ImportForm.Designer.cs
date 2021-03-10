namespace PersonsBase.View
{
    partial class ImportForm
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
            this.bindingSource_Process = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewRight_Name = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Note_Column = new System.Windows.Forms.TextBox();
            this.textBox_Phone_Column = new System.Windows.Forms.TextBox();
            this.textBox_Name_Column = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_OpenFile = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Edit_Notes = new System.Windows.Forms.TextBox();
            this.textBox_Edit_Phone = new System.Windows.Forms.TextBox();
            this.textBox_Edit_Name = new System.Windows.Forms.TextBox();
            this.dataGridViewLeft = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Name = new System.Windows.Forms.TabPage();
            this.tabPage_Phone = new System.Windows.Forms.TabPage();
            this.dataGridViewRight_Phone = new System.Windows.Forms.DataGridView();
            this.tabPage_Unic = new System.Windows.Forms.TabPage();
            this.button_Add_Uniq = new System.Windows.Forms.Button();
            this.dataGridViewRight_Unic = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Base_Name = new System.Windows.Forms.TextBox();
            this.textBox_Base_Note = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Base_Phone = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Process)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRight_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeft)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage_Name.SuspendLayout();
            this.tabPage_Phone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRight_Phone)).BeginInit();
            this.tabPage_Unic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRight_Unic)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewRight_Name
            // 
            this.dataGridViewRight_Name.AllowUserToOrderColumns = true;
            this.dataGridViewRight_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRight_Name.AutoGenerateColumns = false;
            this.dataGridViewRight_Name.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRight_Name.DataSource = this.bindingSource_Process;
            this.dataGridViewRight_Name.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewRight_Name.MultiSelect = false;
            this.dataGridViewRight_Name.Name = "dataGridViewRight_Name";
            this.dataGridViewRight_Name.Size = new System.Drawing.Size(673, 643);
            this.dataGridViewRight_Name.TabIndex = 5;
            this.dataGridViewRight_Name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewRight_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Notes Col";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Phone Col";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name Col";
            // 
            // textBox_Note_Column
            // 
            this.textBox_Note_Column.Location = new System.Drawing.Point(322, 31);
            this.textBox_Note_Column.Name = "textBox_Note_Column";
            this.textBox_Note_Column.Size = new System.Drawing.Size(52, 20);
            this.textBox_Note_Column.TabIndex = 1;
            this.textBox_Note_Column.Text = "3";
            this.textBox_Note_Column.TextChanged += new System.EventHandler(this.textBox_Note_Column_TextChanged);
            // 
            // textBox_Phone_Column
            // 
            this.textBox_Phone_Column.Location = new System.Drawing.Point(253, 31);
            this.textBox_Phone_Column.Name = "textBox_Phone_Column";
            this.textBox_Phone_Column.Size = new System.Drawing.Size(52, 20);
            this.textBox_Phone_Column.TabIndex = 1;
            this.textBox_Phone_Column.Text = "2";
            this.textBox_Phone_Column.TextChanged += new System.EventHandler(this.textBox_Phone_Column_TextChanged_1);
            // 
            // textBox_Name_Column
            // 
            this.textBox_Name_Column.Location = new System.Drawing.Point(184, 31);
            this.textBox_Name_Column.Name = "textBox_Name_Column";
            this.textBox_Name_Column.Size = new System.Drawing.Size(52, 20);
            this.textBox_Name_Column.TabIndex = 1;
            this.textBox_Name_Column.Text = "1";
            this.textBox_Name_Column.TextChanged += new System.EventHandler(this.textBox_Name_Column_TextChanged_1);
            // 
            // button_start
            // 
            this.button_start.Enabled = false;
            this.button_start.Location = new System.Drawing.Point(90, 14);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(67, 37);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click_1);
            // 
            // button_OpenFile
            // 
            this.button_OpenFile.Location = new System.Drawing.Point(6, 14);
            this.button_OpenFile.Name = "button_OpenFile";
            this.button_OpenFile.Size = new System.Drawing.Size(67, 37);
            this.button_OpenFile.TabIndex = 0;
            this.button_OpenFile.Text = "Open";
            this.button_OpenFile.UseVisualStyleBackColor = true;
            this.button_OpenFile.Click += new System.EventHandler(this.button_OpenFile_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(9, 299);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(182, 29);
            this.button_Delete.TabIndex = 9;
            this.button_Delete.Text = "Delete";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_Save_Edited);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Notes ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Phone ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Name ";
            // 
            // textBox_Edit_Notes
            // 
            this.textBox_Edit_Notes.Location = new System.Drawing.Point(6, 113);
            this.textBox_Edit_Notes.Multiline = true;
            this.textBox_Edit_Notes.Name = "textBox_Edit_Notes";
            this.textBox_Edit_Notes.Size = new System.Drawing.Size(182, 144);
            this.textBox_Edit_Notes.TabIndex = 3;
            this.textBox_Edit_Notes.TextChanged += new System.EventHandler(this.textBoxNoteMod_TextChanged);
            // 
            // textBox_Edit_Phone
            // 
            this.textBox_Edit_Phone.Location = new System.Drawing.Point(6, 73);
            this.textBox_Edit_Phone.Name = "textBox_Edit_Phone";
            this.textBox_Edit_Phone.Size = new System.Drawing.Size(182, 20);
            this.textBox_Edit_Phone.TabIndex = 4;
            this.textBox_Edit_Phone.TextChanged += new System.EventHandler(this.textBoxPhoneMod_TextChanged);
            // 
            // textBox_Edit_Name
            // 
            this.textBox_Edit_Name.Location = new System.Drawing.Point(6, 33);
            this.textBox_Edit_Name.Name = "textBox_Edit_Name";
            this.textBox_Edit_Name.Size = new System.Drawing.Size(182, 20);
            this.textBox_Edit_Name.TabIndex = 5;
            this.textBox_Edit_Name.TextChanged += new System.EventHandler(this.textBoxNameMod_TextChanged);
            // 
            // dataGridViewLeft
            // 
            this.dataGridViewLeft.AllowUserToOrderColumns = true;
            this.dataGridViewLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLeft.Location = new System.Drawing.Point(10, 69);
            this.dataGridViewLeft.MultiSelect = false;
            this.dataGridViewLeft.Name = "dataGridViewLeft";
            this.dataGridViewLeft.Size = new System.Drawing.Size(451, 627);
            this.dataGridViewLeft.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_Name);
            this.tabControl1.Controls.Add(this.tabPage_Phone);
            this.tabControl1.Controls.Add(this.tabPage_Unic);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(693, 700);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage_Name
            // 
            this.tabPage_Name.Controls.Add(this.dataGridViewRight_Name);
            this.tabPage_Name.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Name.Name = "tabPage_Name";
            this.tabPage_Name.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Name.Size = new System.Drawing.Size(685, 674);
            this.tabPage_Name.TabIndex = 0;
            this.tabPage_Name.Text = "Новые Телефоны(Имена могут повторяться)";
            this.tabPage_Name.UseVisualStyleBackColor = true;
            // 
            // tabPage_Phone
            // 
            this.tabPage_Phone.Controls.Add(this.dataGridViewRight_Phone);
            this.tabPage_Phone.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Phone.Name = "tabPage_Phone";
            this.tabPage_Phone.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Phone.Size = new System.Drawing.Size(685, 674);
            this.tabPage_Phone.TabIndex = 1;
            this.tabPage_Phone.Text = "Дубликат по Телефону (Уже есть в базе)";
            this.tabPage_Phone.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRight_Phone
            // 
            this.dataGridViewRight_Phone.AllowUserToOrderColumns = true;
            this.dataGridViewRight_Phone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRight_Phone.AutoGenerateColumns = false;
            this.dataGridViewRight_Phone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRight_Phone.DataSource = this.bindingSource_Process;
            this.dataGridViewRight_Phone.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewRight_Phone.MultiSelect = false;
            this.dataGridViewRight_Phone.Name = "dataGridViewRight_Phone";
            this.dataGridViewRight_Phone.Size = new System.Drawing.Size(673, 662);
            this.dataGridViewRight_Phone.TabIndex = 6;
            this.dataGridViewRight_Phone.SelectionChanged += new System.EventHandler(this.dataGridViewRight_Phone_SelectionChanged);
            this.dataGridViewRight_Phone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewRight_MouseClick);
            // 
            // tabPage_Unic
            // 
            this.tabPage_Unic.Controls.Add(this.button_Add_Uniq);
            this.tabPage_Unic.Controls.Add(this.dataGridViewRight_Unic);
            this.tabPage_Unic.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Unic.Name = "tabPage_Unic";
            this.tabPage_Unic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Unic.Size = new System.Drawing.Size(685, 674);
            this.tabPage_Unic.TabIndex = 2;
            this.tabPage_Unic.Text = "Уникальные. Имя и тел нет в базе";
            this.tabPage_Unic.UseVisualStyleBackColor = true;
            // 
            // button_Add_Uniq
            // 
            this.button_Add_Uniq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Add_Uniq.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Add_Uniq.Location = new System.Drawing.Point(6, 635);
            this.button_Add_Uniq.Name = "button_Add_Uniq";
            this.button_Add_Uniq.Size = new System.Drawing.Size(676, 36);
            this.button_Add_Uniq.TabIndex = 7;
            this.button_Add_Uniq.Text = "Добавить в Базу всех! ";
            this.button_Add_Uniq.UseVisualStyleBackColor = true;
            this.button_Add_Uniq.Click += new System.EventHandler(this.button_Add_Uniq_Click);
            // 
            // dataGridViewRight_Unic
            // 
            this.dataGridViewRight_Unic.AllowUserToOrderColumns = true;
            this.dataGridViewRight_Unic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRight_Unic.AutoGenerateColumns = false;
            this.dataGridViewRight_Unic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRight_Unic.DataSource = this.bindingSource_Process;
            this.dataGridViewRight_Unic.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewRight_Unic.MultiSelect = false;
            this.dataGridViewRight_Unic.Name = "dataGridViewRight_Unic";
            this.dataGridViewRight_Unic.Size = new System.Drawing.Size(673, 623);
            this.dataGridViewRight_Unic.TabIndex = 6;
            this.dataGridViewRight_Unic.SelectionChanged += new System.EventHandler(this.dataGridViewRight_Unic_SelectionChanged);
            this.dataGridViewRight_Unic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewRight_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button_Delete);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_Edit_Name);
            this.groupBox1.Controls.Add(this.textBox_Edit_Notes);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_Edit_Phone);
            this.groupBox1.Location = new System.Drawing.Point(702, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 334);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Редактирование";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_start);
            this.groupBox2.Controls.Add(this.button_OpenFile);
            this.groupBox2.Controls.Add(this.textBox_Name_Column);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_Phone_Column);
            this.groupBox2.Controls.Add(this.textBox_Note_Column);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 53);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Открыть";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewLeft);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1370, 706);
            this.splitContainer1.SplitterDistance = 464;
            this.splitContainer1.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBox_Base_Name);
            this.groupBox3.Controls.Add(this.textBox_Base_Note);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox_Base_Phone);
            this.groupBox3.Location = new System.Drawing.Point(702, 371);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 270);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "В Базе если есть:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Notes ";
            // 
            // textBox_Base_Name
            // 
            this.textBox_Base_Name.Location = new System.Drawing.Point(6, 33);
            this.textBox_Base_Name.Name = "textBox_Base_Name";
            this.textBox_Base_Name.Size = new System.Drawing.Size(182, 20);
            this.textBox_Base_Name.TabIndex = 5;
            this.textBox_Base_Name.TextChanged += new System.EventHandler(this.textBoxNameMod_TextChanged);
            // 
            // textBox_Base_Note
            // 
            this.textBox_Base_Note.Location = new System.Drawing.Point(6, 113);
            this.textBox_Base_Note.Multiline = true;
            this.textBox_Base_Note.Name = "textBox_Base_Note";
            this.textBox_Base_Note.Size = new System.Drawing.Size(182, 144);
            this.textBox_Base_Note.TabIndex = 3;
            this.textBox_Base_Note.TextChanged += new System.EventHandler(this.textBoxNoteMod_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Phone ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Name ";
            // 
            // textBox_Base_Phone
            // 
            this.textBox_Base_Phone.Location = new System.Drawing.Point(6, 73);
            this.textBox_Base_Phone.Name = "textBox_Base_Phone";
            this.textBox_Base_Phone.Size = new System.Drawing.Size(182, 20);
            this.textBox_Base_Phone.TabIndex = 4;
            this.textBox_Base_Phone.TextChanged += new System.EventHandler(this.textBoxPhoneMod_TextChanged);
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 706);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "ImportForm";
            this.Text = "ImportForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Process)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRight_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeft)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Name.ResumeLayout(false);
            this.tabPage_Phone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRight_Phone)).EndInit();
            this.tabPage_Unic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRight_Unic)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource_Process;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Note_Column;
        private System.Windows.Forms.TextBox textBox_Phone_Column;
        private System.Windows.Forms.TextBox textBox_Name_Column;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_OpenFile;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_Edit_Notes;
        private System.Windows.Forms.TextBox textBox_Edit_Phone;
        private System.Windows.Forms.TextBox textBox_Edit_Name;
        private System.Windows.Forms.DataGridView dataGridViewLeft;
        private System.Windows.Forms.DataGridView dataGridViewRight_Name;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Name;
        private System.Windows.Forms.TabPage tabPage_Phone;
        private System.Windows.Forms.DataGridView dataGridViewRight_Phone;
        private System.Windows.Forms.TabPage tabPage_Unic;
        private System.Windows.Forms.DataGridView dataGridViewRight_Unic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_Add_Uniq;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Base_Name;
        private System.Windows.Forms.TextBox textBox_Base_Note;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Base_Phone;
    }
}