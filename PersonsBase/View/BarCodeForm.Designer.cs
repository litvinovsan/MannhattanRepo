namespace PersonsBase.View
{
    partial class BarCodeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxScaner = new System.Windows.Forms.PictureBox();
            this.textBox_Code = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScaner)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Отсканируйте Штрихкод";
            // 
            // pictureBoxScaner
            // 
            this.pictureBoxScaner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxScaner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxScaner.Image = global::PersonsBase.Properties.Resources.barcode__1_;
            this.pictureBoxScaner.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxScaner.Name = "pictureBoxScaner";
            this.pictureBoxScaner.Size = new System.Drawing.Size(247, 173);
            this.pictureBoxScaner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxScaner.TabIndex = 1;
            this.pictureBoxScaner.TabStop = false;
            // 
            // textBox_Code
            // 
            this.textBox_Code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Code.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBox_Code.Location = new System.Drawing.Point(12, 197);
            this.textBox_Code.MaxLength = 13;
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.Size = new System.Drawing.Size(247, 30);
            this.textBox_Code.TabIndex = 1;
            this.textBox_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Code.TextChanged += new System.EventHandler(this.textBox_Code_TextChanged);
            // 
            // BarCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 254);
            this.Controls.Add(this.textBox_Code);
            this.Controls.Add(this.pictureBoxScaner);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(287, 293);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(287, 293);
            this.Name = "BarCodeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск Клиента";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScaner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxScaner;
        private System.Windows.Forms.TextBox textBox_Code;
    }
}