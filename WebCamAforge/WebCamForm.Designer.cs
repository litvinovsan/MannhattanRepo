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
            this.pictureBox_img = new System.Windows.Forms.PictureBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox_Config = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label_br = new System.Windows.Forms.Label();
            this.label_CamName = new System.Windows.Forms.Label();
            this.comboBox_CamList = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label_Resolutin = new System.Windows.Forms.Label();
            this.comboBox_Resolution = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_img)).BeginInit();
            this.groupBox_Config.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_save_picture
            // 
            this.button_save_picture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_save_picture.BackColor = System.Drawing.Color.LightGreen;
            this.button_save_picture.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save_picture.Location = new System.Drawing.Point(3, 3);
            this.button_save_picture.Name = "button_save_picture";
            this.button_save_picture.Size = new System.Drawing.Size(379, 34);
            this.button_save_picture.TabIndex = 0;
            this.button_save_picture.Text = "Сохранить изображение";
            this.button_save_picture.UseVisualStyleBackColor = false;
            this.button_save_picture.Click += new System.EventHandler(this.button_save_picture_Click);
            // 
            // pictureBox_img
            // 
            this.pictureBox_img.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_img.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_img.Name = "pictureBox_img";
            this.pictureBox_img.Size = new System.Drawing.Size(755, 358);
            this.pictureBox_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_img.TabIndex = 1;
            this.pictureBox_img.TabStop = false;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Cancel.Location = new System.Drawing.Point(388, 3);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(379, 34);
            this.button_Cancel.TabIndex = 0;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox_Config
            // 
            this.groupBox_Config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Config.Controls.Add(this.trackBar1);
            this.groupBox_Config.Controls.Add(this.label_Resolutin);
            this.groupBox_Config.Controls.Add(this.label_br);
            this.groupBox_Config.Controls.Add(this.label_CamName);
            this.groupBox_Config.Controls.Add(this.comboBox_Resolution);
            this.groupBox_Config.Controls.Add(this.comboBox_CamList);
            this.groupBox_Config.Location = new System.Drawing.Point(12, 376);
            this.groupBox_Config.Name = "groupBox_Config";
            this.groupBox_Config.Size = new System.Drawing.Size(756, 68);
            this.groupBox_Config.TabIndex = 2;
            this.groupBox_Config.TabStop = false;
            this.groupBox_Config.Text = "Настройки";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar1.Location = new System.Drawing.Point(336, 16);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(139, 45);
            this.trackBar1.TabIndex = 3;
            // 
            // label_br
            // 
            this.label_br.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_br.AutoSize = true;
            this.label_br.Location = new System.Drawing.Point(280, 18);
            this.label_br.Name = "label_br";
            this.label_br.Size = new System.Drawing.Size(50, 13);
            this.label_br.TabIndex = 2;
            this.label_br.Text = "Яркость";
            // 
            // label_CamName
            // 
            this.label_CamName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_CamName.AutoSize = true;
            this.label_CamName.Location = new System.Drawing.Point(6, 16);
            this.label_CamName.Name = "label_CamName";
            this.label_CamName.Size = new System.Drawing.Size(49, 13);
            this.label_CamName.TabIndex = 1;
            this.label_CamName.Text = "Камера:";
            // 
            // comboBox_CamList
            // 
            this.comboBox_CamList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_CamList.FormattingEnabled = true;
            this.comboBox_CamList.Location = new System.Drawing.Point(6, 34);
            this.comboBox_CamList.Name = "comboBox_CamList";
            this.comboBox_CamList.Size = new System.Drawing.Size(195, 21);
            this.comboBox_CamList.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button_save_picture);
            this.flowLayoutPanel1.Controls.Add(this.button_Cancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 450);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(780, 46);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label_Resolutin
            // 
            this.label_Resolutin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Resolutin.AutoSize = true;
            this.label_Resolutin.Location = new System.Drawing.Point(607, 18);
            this.label_Resolutin.Name = "label_Resolutin";
            this.label_Resolutin.Size = new System.Drawing.Size(70, 13);
            this.label_Resolutin.TabIndex = 2;
            this.label_Resolutin.Text = "Разрешение";
            // 
            // comboBox_Resolution
            // 
            this.comboBox_Resolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_Resolution.FormattingEnabled = true;
            this.comboBox_Resolution.Location = new System.Drawing.Point(536, 34);
            this.comboBox_Resolution.Name = "comboBox_Resolution";
            this.comboBox_Resolution.Size = new System.Drawing.Size(214, 21);
            this.comboBox_Resolution.TabIndex = 0;
            this.comboBox_Resolution.SelectedIndexChanged += new System.EventHandler(this.comboBox_Resolution_SelectedIndexChanged);
            // 
            // WebCamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 496);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox_Config);
            this.Controls.Add(this.pictureBox_img);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(796, 535);
            this.MinimumSize = new System.Drawing.Size(796, 535);
            this.Name = "WebCamForm";
            this.Text = "WebCamForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebCamForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_img)).EndInit();
            this.groupBox_Config.ResumeLayout(false);
            this.groupBox_Config.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox comboBox_CamList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label_Resolutin;
        private System.Windows.Forms.ComboBox comboBox_Resolution;
    }
}