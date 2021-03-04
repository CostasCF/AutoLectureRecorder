
namespace YoutubeAPI
{
    partial class Form1
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
            this.uploadBtn = new System.Windows.Forms.Button();
            this.lblstatus = new System.Windows.Forms.Label();
            this.browserBtn = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.authenticateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uploadBtn
            // 
            this.uploadBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadBtn.Location = new System.Drawing.Point(615, 234);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(75, 23);
            this.uploadBtn.TabIndex = 0;
            this.uploadBtn.Text = "upload";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus.Location = new System.Drawing.Point(83, 234);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(47, 17);
            this.lblstatus.TabIndex = 1;
            this.lblstatus.Text = "label1";
            // 
            // browserBtn
            // 
            this.browserBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browserBtn.Location = new System.Drawing.Point(615, 116);
            this.browserBtn.Name = "browserBtn";
            this.browserBtn.Size = new System.Drawing.Size(109, 23);
            this.browserBtn.TabIndex = 2;
            this.browserBtn.Text = "browser file";
            this.browserBtn.UseVisualStyleBackColor = true;
            this.browserBtn.Click += new System.EventHandler(this.browserBtn_Click);
            // 
            // txtPath
            // 
            this.txtPath.AutoSize = true;
            this.txtPath.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(83, 116);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(56, 17);
            this.txtPath.TabIndex = 3;
            this.txtPath.Text = "filePath";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(281, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Retrieve Playlists";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // authenticateBtn
            // 
            this.authenticateBtn.Location = new System.Drawing.Point(281, 46);
            this.authenticateBtn.Name = "authenticateBtn";
            this.authenticateBtn.Size = new System.Drawing.Size(75, 23);
            this.authenticateBtn.TabIndex = 5;
            this.authenticateBtn.Text = "Authenticate Youtube";
            this.authenticateBtn.UseVisualStyleBackColor = true;
            this.authenticateBtn.Click += new System.EventHandler(this.authenticateBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.authenticateBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.browserBtn);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.uploadBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.Button browserBtn;
        private System.Windows.Forms.Label txtPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button authenticateBtn;
        private System.Windows.Forms.Label label1;
    }
}

