namespace WebCamAforge
{
    partial class WebCamForm
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
            this.button_save_picture = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_CamName = new System.Windows.Forms.Label();
            this.comboBox_CamList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox_img = new System.Windows.Forms.PictureBox();
            this.pictureBox_Final = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Final)).BeginInit();
            this.SuspendLayout();
            // 
            // button_save_picture
            // 
            this.button_save_picture.BackColor = System.Drawing.Color.LightGreen;
            this.button_save_picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_save_picture.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save_picture.Location = new System.Drawing.Point(3, 3);
            this.button_save_picture.Name = "button_save_picture";
            this.button_save_picture.Size = new System.Drawing.Size(471, 48);
            this.button_save_picture.TabIndex = 0;
            this.button_save_picture.Text = "Сделать снимок";
            this.button_save_picture.UseVisualStyleBackColor = false;
            this.button_save_picture.Click += new System.EventHandler(this.button_save_picture_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Cancel.Location = new System.Drawing.Point(480, 3);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(471, 48);
            this.button_Cancel.TabIndex = 0;
            this.button_Cancel.Text = "Закрыть";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label_CamName
            // 
            this.label_CamName.AutoSize = true;
            this.label_CamName.Location = new System.Drawing.Point(12, 9);
            this.label_CamName.Name = "label_CamName";
            this.label_CamName.Size = new System.Drawing.Size(49, 13);
            this.label_CamName.TabIndex = 1;
            this.label_CamName.Text = "Камера:";
            // 
            // comboBox_CamList
            // 
            this.comboBox_CamList.FormattingEnabled = true;
            this.comboBox_CamList.Location = new System.Drawing.Point(67, 6);
            this.comboBox_CamList.Name = "comboBox_CamList";
            this.comboBox_CamList.Size = new System.Drawing.Size(240, 21);
            this.comboBox_CamList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(810, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Итоговое изображение:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_Cancel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_save_picture, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 353);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(954, 54);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox_img, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox_Final, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 33);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 374F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(926, 304);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // pictureBox_img
            // 
            this.pictureBox_img.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_img.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_img.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_img.Name = "pictureBox_img";
            this.pictureBox_img.Size = new System.Drawing.Size(457, 298);
            this.pictureBox_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_img.TabIndex = 1;
            this.pictureBox_img.TabStop = false;
            // 
            // pictureBox_Final
            // 
            this.pictureBox_Final.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Final.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Final.Image = global::WebCamAforge.Properties.Resources.no_photo_available_icon_20;
            this.pictureBox_Final.Location = new System.Drawing.Point(466, 3);
            this.pictureBox_Final.Name = "pictureBox_Final";
            this.pictureBox_Final.Size = new System.Drawing.Size(457, 298);
            this.pictureBox_Final.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Final.TabIndex = 1;
            this.pictureBox_Final.TabStop = false;
            // 
            // WebCamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 407);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_CamName);
            this.Controls.Add(this.comboBox_CamList);
            this.MaximizeBox = false;
            this.Name = "WebCamForm";
            this.Text = "WebCamForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebCamForm_FormClosing);
            this.Load += new System.EventHandler(this.WebCamForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Final)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_save_picture;
        private System.Windows.Forms.PictureBox pictureBox_img;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_CamName;
        private System.Windows.Forms.ComboBox comboBox_CamList;
        private System.Windows.Forms.PictureBox pictureBox_Final;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}