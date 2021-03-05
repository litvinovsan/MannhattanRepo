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
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.dataGridViewLeft = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Name = new System.Windows.Forms.TabPage();
            this.tabPage_Phone = new System.Windows.Forms.TabPage();
            this.dataGridViewRight_Phone = new System.Windows.Forms.DataGridView();
            this.tabPage_Unic = new System.Windows.Forms.TabPage();
            this.dataGridViewRight_Unic = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.dataGridViewRight_Name.Size = new System.Drawing.Size(765, 643);
            this.dataGridViewRight_Name.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Notes Column";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Phone Column";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name Column";
            // 
            // textBox_Note_Column
            // 
            this.textBox_Note_Column.Location = new System.Drawing.Point(6, 169);
            this.textBox_Note_Column.Name = "textBox_Note_Column";
            this.textBox_Note_Column.Size = new System.Drawing.Size(73, 20);
            this.textBox_Note_Column.TabIndex = 1;
            this.textBox_Note_Column.Text = "3";
            this.textBox_Note_Column.TextChanged += new System.EventHandler(this.textBox_Note_Column_TextChanged);
            // 
            // textBox_Phone_Column
            // 
            this.textBox_Phone_Column.Location = new System.Drawing.Point(6, 129);
            this.textBox_Phone_Column.Name = "textBox_Phone_Column";
            this.textBox_Phone_Column.Size = new System.Drawing.Size(73, 20);
            this.textBox_Phone_Column.TabIndex = 1;
            this.textBox_Phone_Column.Text = "2";
            this.textBox_Phone_Column.TextChanged += new System.EventHandler(this.textBox_Phone_Column_TextChanged_1);
            // 
            // textBox_Name_Column
            // 
            this.textBox_Name_Column.Location = new System.Drawing.Point(6, 89);
            this.textBox_Name_Column.Name = "textBox_Name_Column";
            this.textBox_Name_Column.Size = new System.Drawing.Size(73, 20);
            this.textBox_Name_Column.TabIndex = 1;
            this.textBox_Name_Column.Text = "1";
            this.textBox_Name_Column.TextChanged += new System.EventHandler(this.textBox_Name_Column_TextChanged_1);
            // 
            // button_start
            // 
            this.button_start.Enabled = false;
            this.button_start.Location = new System.Drawing.Point(6, 231);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 37);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click_1);
            // 
            // button_OpenFile
            // 
            this.button_OpenFile.Location = new System.Drawing.Point(6, 19);
            this.button_OpenFile.Name = "button_OpenFile";
            this.button_OpenFile.Size = new System.Drawing.Size(75, 37);
            this.button_OpenFile.TabIndex = 0;
            this.button_OpenFile.Text = "Open";
            this.button_OpenFile.UseVisualStyleBackColor = true;
            this.button_OpenFile.Click += new System.EventHandler(this.button_OpenFile_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(6, 175);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(121, 29);
            this.button_Delete.TabIndex = 9;
            this.button_Delete.Text = "Delete";
            this.button_Delete.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
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
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 113);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(121, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.TextChanged += new System.EventHandler(this.textBoxNoteMod_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(6, 73);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(121, 20);
            this.textBox5.TabIndex = 4;
            this.textBox5.TextChanged += new System.EventHandler(this.textBoxPhoneMod_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(6, 33);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(121, 20);
            this.textBox6.TabIndex = 5;
            this.textBox6.TextChanged += new System.EventHandler(this.textBoxNameMod_TextChanged);
            // 
            // dataGridViewLeft
            // 
            this.dataGridViewLeft.AllowUserToOrderColumns = true;
            this.dataGridViewLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLeft.Location = new System.Drawing.Point(106, 31);
            this.dataGridViewLeft.MultiSelect = false;
            this.dataGridViewLeft.Name = "dataGridViewLeft";
            this.dataGridViewLeft.Size = new System.Drawing.Size(372, 652);
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
            this.tabControl1.Size = new System.Drawing.Size(785, 681);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage_Name
            // 
            this.tabPage_Name.Controls.Add(this.dataGridViewRight_Name);
            this.tabPage_Name.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Name.Name = "tabPage_Name";
            this.tabPage_Name.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Name.Size = new System.Drawing.Size(777, 655);
            this.tabPage_Name.TabIndex = 0;
            this.tabPage_Name.Text = "Дубликат по Имени (Тел. отличается)";
            this.tabPage_Name.UseVisualStyleBackColor = true;
            // 
            // tabPage_Phone
            // 
            this.tabPage_Phone.Controls.Add(this.dataGridViewRight_Phone);
            this.tabPage_Phone.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Phone.Name = "tabPage_Phone";
            this.tabPage_Phone.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Phone.Size = new System.Drawing.Size(777, 655);
            this.tabPage_Phone.TabIndex = 1;
            this.tabPage_Phone.Text = "Дубликат по Телефону (Имя отличается)";
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
            this.dataGridViewRight_Phone.Size = new System.Drawing.Size(700, 634);
            this.dataGridViewRight_Phone.TabIndex = 6;
            // 
            // tabPage_Unic
            // 
            this.tabPage_Unic.Controls.Add(this.dataGridViewRight_Unic);
            this.tabPage_Unic.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Unic.Name = "tabPage_Unic";
            this.tabPage_Unic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Unic.Size = new System.Drawing.Size(777, 655);
            this.tabPage_Unic.TabIndex = 2;
            this.tabPage_Unic.Text = "Уникальные";
            this.tabPage_Unic.UseVisualStyleBackColor = true;
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
            this.dataGridViewRight_Unic.Size = new System.Drawing.Size(765, 643);
            this.dataGridViewRight_Unic.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button_Delete);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Location = new System.Drawing.Point(790, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 216);
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
            this.groupBox2.Size = new System.Drawing.Size(88, 277);
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
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1418, 687);
            this.splitContainer1.SplitterDistance = 481;
            this.splitContainer1.TabIndex = 7;
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 687);
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
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
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
    }
}