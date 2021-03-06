namespace RBOS
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.lbRBOSApplName = new System.Windows.Forms.Label();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRBOSApplName
            // 
            this.lbRBOSApplName.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRBOSApplName.Location = new System.Drawing.Point(66, 59);
            this.lbRBOSApplName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRBOSApplName.Name = "lbRBOSApplName";
            this.lbRBOSApplName.Size = new System.Drawing.Size(402, 35);
            this.lbRBOSApplName.TabIndex = 4;
            this.lbRBOSApplName.Text = "Retail-BOS";
            this.lbRBOSApplName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbRBOSApplName.Click += new System.EventHandler(this.About_Click);
            // 
            // lbCopyright
            // 
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCopyright.Location = new System.Drawing.Point(32, 219);
            this.lbCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(319, 27);
            this.lbCopyright.TabIndex = 5;
            this.lbCopyright.Text = "Copyrigth 2022-{0} Baker Tilly";
            this.lbCopyright.Click += new System.EventHandler(this.About_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(87, 272);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.About_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(162, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Version";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Click += new System.EventHandler(this.About_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.AutoSize = true;
            this.txtVersion.Location = new System.Drawing.Point(278, 134);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(51, 20);
            this.txtVersion.TabIndex = 8;
            this.txtVersion.Text = "label3";
            this.txtVersion.Click += new System.EventHandler(this.About_Click);
            // 
            // txtUser
            // 
            this.txtUser.AutoSize = true;
            this.txtUser.Location = new System.Drawing.Point(279, 162);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(60, 20);
            this.txtUser.TabIndex = 10;
            this.txtUser.Text = "txtUser";
            this.txtUser.Click += new System.EventHandler(this.About_Click);
            // 
            // lbUser
            // 
            this.lbUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(66, 158);
            this.lbUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(202, 29);
            this.lbUser.TabIndex = 9;
            this.lbUser.Text = "[User]";
            this.lbUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbUser.Click += new System.EventHandler(this.About_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 409);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbCopyright);
            this.Controls.Add(this.lbRBOSApplName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.Click += new System.EventHandler(this.About_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRBOSApplName;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtVersion;
        private System.Windows.Forms.Label txtUser;
        private System.Windows.Forms.Label lbUser;
    }
}