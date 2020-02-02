namespace PersonsBase.View
{
    partial class CreatePersonForm
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
            this.comboBox_Names = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.maskedTextBox_PhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.label_Phone = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Gender = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBox_Passport = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePicker_birthDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox_DriverID = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_number = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_add_foto = new System.Windows.Forms.Button();
            this.pictureBox_Client = new System.Windows.Forms.PictureBox();
            this.textBox_Notes = new System.Windows.Forms.TextBox();
            this.button_Add_New_Person = new System.Windows.Forms.Button();
            this.groupBox_Notes = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Client)).BeginInit();
            this.groupBox_Notes.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Names);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фамилия Имя Отчество";
            // 
            // comboBox_Names
            // 
            this.comboBox_Names.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Names.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Names.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Names.DropDownHeight = 250;
            this.comboBox_Names.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_Names.FormattingEnabled = true;
            this.comboBox_Names.IntegralHeight = false;
            this.comboBox_Names.Location = new System.Drawing.Point(6, 22);
            this.comboBox_Names.Name = "comboBox_Names";
            this.comboBox_Names.Size = new System.Drawing.Size(340, 28);
            this.comboBox_Names.TabIndex = 9;
            this.comboBox_Names.TextChanged += new System.EventHandler(this.comboBox_Names_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(11, 73);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(357, 193);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Персональные данные";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.maskedTextBox_PhoneNumber, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_Phone, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_Gender, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.maskedTextBox_Passport, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker_birthDate, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.maskedTextBox_DriverID, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.maskedTextBox_number, 1, 14);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 21);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 16;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(343, 161);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // maskedTextBox_PhoneNumber
            // 
            this.maskedTextBox_PhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_PhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_PhoneNumber.Location = new System.Drawing.Point(159, 2);
            this.maskedTextBox_PhoneNumber.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBox_PhoneNumber.Mask = "8(999) 000-00-00";
            this.maskedTextBox_PhoneNumber.Name = "maskedTextBox_PhoneNumber";
            this.maskedTextBox_PhoneNumber.Size = new System.Drawing.Size(182, 23);
            this.maskedTextBox_PhoneNumber.TabIndex = 2;
            this.maskedTextBox_PhoneNumber.Click += new System.EventHandler(this.maskedTextBox_PhoneNumber_Click);
            this.maskedTextBox_PhoneNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox_PhoneNumber_KeyUp);
            // 
            // label_Phone
            // 
            this.label_Phone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Phone.AutoSize = true;
            this.label_Phone.Location = new System.Drawing.Point(2, 5);
            this.label_Phone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Phone.Name = "label_Phone";
            this.label_Phone.Size = new System.Drawing.Size(153, 17);
            this.label_Phone.TabIndex = 7;
            this.label_Phone.Text = "Телефон";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Пол";
            // 
            // comboBox_Gender
            // 
            this.comboBox_Gender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_Gender.FormattingEnabled = true;
            this.comboBox_Gender.Location = new System.Drawing.Point(159, 29);
            this.comboBox_Gender.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Gender.Name = "comboBox_Gender";
            this.comboBox_Gender.Size = new System.Drawing.Size(182, 24);
            this.comboBox_Gender.TabIndex = 3;
            this.comboBox_Gender.SelectedIndexChanged += new System.EventHandler(this.comboBox_Gender_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Паспорт";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "День Рождения";
            // 
            // maskedTextBox_Passport
            // 
            this.maskedTextBox_Passport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_Passport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_Passport.Location = new System.Drawing.Point(159, 84);
            this.maskedTextBox_Passport.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBox_Passport.Mask = "9999   № 999999";
            this.maskedTextBox_Passport.Name = "maskedTextBox_Passport";
            this.maskedTextBox_Passport.Size = new System.Drawing.Size(182, 21);
            this.maskedTextBox_Passport.TabIndex = 5;
            this.maskedTextBox_Passport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox_Passport.Click += new System.EventHandler(this.maskedTextBox_Passport_Click);
            this.maskedTextBox_Passport.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox_Passport_KeyUp);
            // 
            // dateTimePicker_birthDate
            // 
            this.dateTimePicker_birthDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_birthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker_birthDate.Location = new System.Drawing.Point(159, 57);
            this.dateTimePicker_birthDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_birthDate.MinimumSize = new System.Drawing.Size(115, 22);
            this.dateTimePicker_birthDate.Name = "dateTimePicker_birthDate";
            this.dateTimePicker_birthDate.Size = new System.Drawing.Size(182, 23);
            this.dateTimePicker_birthDate.TabIndex = 4;
            this.dateTimePicker_birthDate.ValueChanged += new System.EventHandler(this.dateTimePicker_birthDate_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 111);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Права";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 138);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Персональный Номер";
            // 
            // maskedTextBox_DriverID
            // 
            this.maskedTextBox_DriverID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_DriverID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_DriverID.Location = new System.Drawing.Point(159, 109);
            this.maskedTextBox_DriverID.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBox_DriverID.Mask = "9999   № 999999";
            this.maskedTextBox_DriverID.Name = "maskedTextBox_DriverID";
            this.maskedTextBox_DriverID.Size = new System.Drawing.Size(182, 21);
            this.maskedTextBox_DriverID.TabIndex = 6;
            this.maskedTextBox_DriverID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox_DriverID.Click += new System.EventHandler(this.maskedTextBox_DriverID_Click);
            this.maskedTextBox_DriverID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox_DriverID_KeyUp);
            // 
            // maskedTextBox_number
            // 
            this.maskedTextBox_number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_number.Location = new System.Drawing.Point(160, 135);
            this.maskedTextBox_number.Name = "maskedTextBox_number";
            this.maskedTextBox_number.Size = new System.Drawing.Size(180, 23);
            this.maskedTextBox_number.TabIndex = 7;
            this.maskedTextBox_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBox_number.ValidatingType = typeof(int);
            this.maskedTextBox_number.TextChanged += new System.EventHandler(this.maskedTextBox_Personal_Number_TextChanged);
            this.maskedTextBox_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox_number_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button_add_foto);
            this.groupBox2.Controls.Add(this.pictureBox_Client);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(404, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 254);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Фото";
            // 
            // button_add_foto
            // 
            this.button_add_foto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_add_foto.Location = new System.Drawing.Point(3, 215);
            this.button_add_foto.Name = "button_add_foto";
            this.button_add_foto.Size = new System.Drawing.Size(194, 36);
            this.button_add_foto.TabIndex = 1;
            this.button_add_foto.Text = "Загрузить Фото";
            this.button_add_foto.UseVisualStyleBackColor = true;
            this.button_add_foto.Click += new System.EventHandler(this.button_add_foto_Click);
            // 
            // pictureBox_Client
            // 
            this.pictureBox_Client.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Client.Location = new System.Drawing.Point(6, 23);
            this.pictureBox_Client.Name = "pictureBox_Client";
            this.pictureBox_Client.Size = new System.Drawing.Size(188, 189);
            this.pictureBox_Client.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Client.TabIndex = 0;
            this.pictureBox_Client.TabStop = false;
            // 
            // textBox_Notes
            // 
            this.textBox_Notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Notes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Notes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textBox_Notes.Location = new System.Drawing.Point(3, 16);
            this.textBox_Notes.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Notes.Multiline = true;
            this.textBox_Notes.Name = "textBox_Notes";
            this.textBox_Notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Notes.Size = new System.Drawing.Size(585, 104);
            this.textBox_Notes.TabIndex = 8;
            this.textBox_Notes.Text = "Заметки о Клиенте";
            this.textBox_Notes.TextChanged += new System.EventHandler(this.textBox_Notes_TextChanged);
            // 
            // button_Add_New_Person
            // 
            this.button_Add_New_Person.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Add_New_Person.Enabled = false;
            this.button_Add_New_Person.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Add_New_Person.Location = new System.Drawing.Point(0, 419);
            this.button_Add_New_Person.Name = "button_Add_New_Person";
            this.button_Add_New_Person.Size = new System.Drawing.Size(616, 52);
            this.button_Add_New_Person.TabIndex = 7;
            this.button_Add_New_Person.Text = "Создать Клиента";
            this.button_Add_New_Person.UseVisualStyleBackColor = false;
            this.button_Add_New_Person.Click += new System.EventHandler(this.button_Add_New_Person_Click);
            // 
            // groupBox_Notes
            // 
            this.groupBox_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Notes.Controls.Add(this.textBox_Notes);
            this.groupBox_Notes.Location = new System.Drawing.Point(13, 289);
            this.groupBox_Notes.Name = "groupBox_Notes";
            this.groupBox_Notes.Size = new System.Drawing.Size(591, 123);
            this.groupBox_Notes.TabIndex = 8;
            this.groupBox_Notes.TabStop = false;
            this.groupBox_Notes.Text = "Дополнительная информация:";
            // 
            // CreatePersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 471);
            this.Controls.Add(this.groupBox_Notes);
            this.Controls.Add(this.button_Add_New_Person);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(632, 505);
            this.Name = "CreatePersonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание Клиента";
            this.Load += new System.EventHandler(this.CreatePersonForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Client)).EndInit();
            this.groupBox_Notes.ResumeLayout(false);
            this.groupBox_Notes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_PhoneNumber;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Passport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_DriverID;
        private System.Windows.Forms.Label label_Phone;
        private System.Windows.Forms.DateTimePicker dateTimePicker_birthDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Gender;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_add_foto;
        private System.Windows.Forms.PictureBox pictureBox_Client;
        private System.Windows.Forms.TextBox textBox_Notes;
        private System.Windows.Forms.Button button_Add_New_Person;
        private System.Windows.Forms.GroupBox groupBox_Notes;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_number;
        private System.Windows.Forms.ComboBox comboBox_Names;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}