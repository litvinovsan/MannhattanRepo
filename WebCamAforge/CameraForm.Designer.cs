namespace WebCamAforge
{
    partial class CameraForm
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
            this.pictureBox_img = new System.Windows.Forms.PictureBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox_Config = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_CamName = new System.Windows.Forms.Label();
            this.label_br = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_img)).BeginInit();
            this.groupBox_Config.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_save_picture
            // 
            this.button_save_picture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_save_picture.Location = new System.Drawing.Point(12, 339);
            this.button_save_picture.Name = "button_save_picture";
            this.button_save_picture.Size = new System.Drawing.Size(224, 34);
            this.button_save_picture.TabIndex = 0;
            this.button_save_picture.Text = "Сохранить изображение";
            this.button_save_picture.UseVisualStyleBackColor = true;
            // 
            // pictureBox_img
            // 
            this.pictureBox_img.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_img.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_img.Name = "pictureBox_img";
            this.pictureBox_img.Size = new System.Drawing.Size(453, 321);
            this.pictureBox_img.TabIndex = 1;
            this.pictureBox_img.TabStop = false;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Cancel.Location = new System.Drawing.Point(242, 339);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(224, 34);
            this.button_Cancel.TabIndex = 0;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox_Config
            // 
            this.groupBox_Config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Config.Controls.Add(this.trackBar1);
            this.groupBox_Config.Controls.Add(this.label_br);
            this.groupBox_Config.Controls.Add(this.label_CamName);
            this.groupBox_Config.Controls.Add(this.comboBox1);
            this.groupBox_Config.Location = new System.Drawing.Point(485, 12);
            this.groupBox_Config.Name = "groupBox_Config";
            this.groupBox_Config.Size = new System.Drawing.Size(138, 321);
            this.groupBox_Config.TabIndex = 2;
            this.groupBox_Config.TabStop = false;
            this.groupBox_Config.Text = "Настройки";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label_CamName
            // 
            this.label_CamName.AutoSize = true;
            this.label_CamName.Location = new System.Drawing.Point(6, 23);
            this.label_CamName.Name = "label_CamName";
            this.label_CamName.Size = new System.Drawing.Size(49, 13);
            this.label_CamName.TabIndex = 1;
            this.label_CamName.Text = "Камера:";
            // 
            // label_br
            // 
            this.label_br.AutoSize = true;
            this.label_br.Location = new System.Drawing.Point(6, 77);
            this.label_br.Name = "label_br";
            this.label_br.Size = new System.Drawing.Size(50, 13);
            this.label_br.TabIndex = 2;
            this.label_br.Text = "Яркость";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(7, 94);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(120, 45);
            this.trackBar1.TabIndex = 3;
            // 
            // WebCamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 385);
            this.Controls.Add(this.groupBox_Config);
            this.Controls.Add(this.pictureBox_img);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_save_picture);
            this.MaximizeBox = false;
            this.Name = "WebCamForm";
            this.Text = "WebCamForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_img)).EndInit();
            this.groupBox_Config.ResumeLayout(false);
            this.groupBox_Config.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_save_picture;
        private System.Windows.Forms.PictureBox pictureBox_img;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.GroupBox groupBox_Config;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label_br;
        private System.Windows.Forms.Label label_CamName;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}