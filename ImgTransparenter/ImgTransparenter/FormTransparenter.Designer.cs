namespace ImgTransparenter
{
    partial class FormTransparenter
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
            this.ButtonSelectImg = new System.Windows.Forms.Button();
            this.ButtonConvert = new System.Windows.Forms.Button();
            this.dialogOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonSelectImg
            // 
            this.ButtonSelectImg.Location = new System.Drawing.Point(16, 30);
            this.ButtonSelectImg.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonSelectImg.Name = "ButtonSelectImg";
            this.ButtonSelectImg.Size = new System.Drawing.Size(139, 28);
            this.ButtonSelectImg.TabIndex = 0;
            this.ButtonSelectImg.Text = "Select image";
            this.ButtonSelectImg.UseVisualStyleBackColor = true;
            this.ButtonSelectImg.Click += new System.EventHandler(this.ButtonSelectImg_Click);
            // 
            // ButtonConvert
            // 
            this.ButtonConvert.Enabled = false;
            this.ButtonConvert.Location = new System.Drawing.Point(163, 30);
            this.ButtonConvert.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonConvert.Name = "ButtonConvert";
            this.ButtonConvert.Size = new System.Drawing.Size(139, 28);
            this.ButtonConvert.TabIndex = 1;
            this.ButtonConvert.Text = "Convert";
            this.ButtonConvert.UseVisualStyleBackColor = true;
            this.ButtonConvert.Click += new System.EventHandler(this.ButtonConvert_Click);
            // 
            // dialogOpenFile
            // 
            this.dialogOpenFile.FileName = "Image";
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(13, 9);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(125, 17);
            this.LabelStatus.TabIndex = 2;
            this.LabelStatus.Text = "No image selected";
            // 
            // FormTransparenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 70);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.ButtonConvert);
            this.Controls.Add(this.ButtonSelectImg);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTransparenter";
            this.ShowIcon = false;
            this.Text = "ImgTransparenter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonSelectImg;
        private System.Windows.Forms.Button ButtonConvert;
        private System.Windows.Forms.OpenFileDialog dialogOpenFile;
        private System.Windows.Forms.Label LabelStatus;

    }
}

