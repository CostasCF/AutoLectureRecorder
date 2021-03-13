
namespace Auto_Lecture_Recorder
{
    partial class TestForm
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
            this.panel_Login = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Login = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label_AuthIndicator = new System.Windows.Forms.Label();
            this.button_GetPartsNum = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel_Meeting = new System.Windows.Forms.Panel();
            this.button_LeaveMeeting = new System.Windows.Forms.Button();
            this.button_connToMeeting = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_General = new System.Windows.Forms.Panel();
            this.button_GetMeetings = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel_Login.SuspendLayout();
            this.panel_Meeting.SuspendLayout();
            this.panel_General.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Login
            // 
            this.panel_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_Login.Controls.Add(this.label1);
            this.panel_Login.Controls.Add(this.button_Login);
            this.panel_Login.Controls.Add(this.textBox2);
            this.panel_Login.Controls.Add(this.label2);
            this.panel_Login.Controls.Add(this.textBox1);
            this.panel_Login.Location = new System.Drawing.Point(406, 199);
            this.panel_Login.Name = "panel_Login";
            this.panel_Login.Size = new System.Drawing.Size(262, 193);
            this.panel_Login.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(82, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password";
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(0, 142);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(262, 44);
            this.button_Login.TabIndex = 3;
            this.button_Login.Text = "Login";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox2.Location = new System.Drawing.Point(0, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(262, 23);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(82, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox1.Location = new System.Drawing.Point(0, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 23);
            this.textBox1.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox3.Location = new System.Drawing.Point(0, 41);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(262, 23);
            this.textBox3.TabIndex = 6;
            // 
            // label_AuthIndicator
            // 
            this.label_AuthIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_AuthIndicator.AutoSize = true;
            this.label_AuthIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_AuthIndicator.ForeColor = System.Drawing.Color.Red;
            this.label_AuthIndicator.Location = new System.Drawing.Point(891, 25);
            this.label_AuthIndicator.Name = "label_AuthIndicator";
            this.label_AuthIndicator.Size = new System.Drawing.Size(142, 20);
            this.label_AuthIndicator.TabIndex = 0;
            this.label_AuthIndicator.Text = "Not Authenticated ";
            // 
            // button_GetPartsNum
            // 
            this.button_GetPartsNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_GetPartsNum.Location = new System.Drawing.Point(0, 331);
            this.button_GetPartsNum.Name = "button_GetPartsNum";
            this.button_GetPartsNum.Size = new System.Drawing.Size(233, 34);
            this.button_GetPartsNum.TabIndex = 9;
            this.button_GetPartsNum.Text = "Get Participants Number";
            this.button_GetPartsNum.UseVisualStyleBackColor = true;
            this.button_GetPartsNum.Click += new System.EventHandler(this.button_GetPartsNum_Click);
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox4.Location = new System.Drawing.Point(93, 302);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(47, 23);
            this.textBox4.TabIndex = 11;
            // 
            // panel_Meeting
            // 
            this.panel_Meeting.Controls.Add(this.button_LeaveMeeting);
            this.panel_Meeting.Controls.Add(this.button_connToMeeting);
            this.panel_Meeting.Controls.Add(this.label3);
            this.panel_Meeting.Controls.Add(this.textBox3);
            this.panel_Meeting.Location = new System.Drawing.Point(406, 199);
            this.panel_Meeting.Name = "panel_Meeting";
            this.panel_Meeting.Size = new System.Drawing.Size(262, 166);
            this.panel_Meeting.TabIndex = 12;
            // 
            // button_LeaveMeeting
            // 
            this.button_LeaveMeeting.Location = new System.Drawing.Point(0, 120);
            this.button_LeaveMeeting.Name = "button_LeaveMeeting";
            this.button_LeaveMeeting.Size = new System.Drawing.Size(262, 44);
            this.button_LeaveMeeting.TabIndex = 10;
            this.button_LeaveMeeting.Text = "Leave meeting";
            this.button_LeaveMeeting.UseVisualStyleBackColor = true;
            this.button_LeaveMeeting.Click += new System.EventHandler(this.button_LeaveMeeting_Click);
            // 
            // button_connToMeeting
            // 
            this.button_connToMeeting.Location = new System.Drawing.Point(0, 70);
            this.button_connToMeeting.Name = "button_connToMeeting";
            this.button_connToMeeting.Size = new System.Drawing.Size(262, 44);
            this.button_connToMeeting.TabIndex = 9;
            this.button_connToMeeting.Text = "Connect to meeting";
            this.button_connToMeeting.UseVisualStyleBackColor = true;
            this.button_connToMeeting.Click += new System.EventHandler(this.button_connToMeeting_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(63, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Meeting\'s Link";
            // 
            // panel_General
            // 
            this.panel_General.Controls.Add(this.button_GetMeetings);
            this.panel_General.Controls.Add(this.richTextBox1);
            this.panel_General.Controls.Add(this.button_GetPartsNum);
            this.panel_General.Controls.Add(this.textBox4);
            this.panel_General.Location = new System.Drawing.Point(67, 79);
            this.panel_General.Name = "panel_General";
            this.panel_General.Size = new System.Drawing.Size(233, 384);
            this.panel_General.TabIndex = 13;
            // 
            // button_GetMeetings
            // 
            this.button_GetMeetings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_GetMeetings.Location = new System.Drawing.Point(0, 253);
            this.button_GetMeetings.Name = "button_GetMeetings";
            this.button_GetMeetings.Size = new System.Drawing.Size(233, 34);
            this.button_GetMeetings.TabIndex = 9;
            this.button_GetMeetings.Text = "Get Meetings";
            this.button_GetMeetings.UseVisualStyleBackColor = true;
            this.button_GetMeetings.Click += new System.EventHandler(this.button_GetMeetings_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(233, 247);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 592);
            this.Controls.Add(this.panel_General);
            this.Controls.Add(this.panel_Meeting);
            this.Controls.Add(this.label_AuthIndicator);
            this.Controls.Add(this.panel_Login);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.panel_Login.ResumeLayout(false);
            this.panel_Login.PerformLayout();
            this.panel_Meeting.ResumeLayout(false);
            this.panel_Meeting.PerformLayout();
            this.panel_General.ResumeLayout(false);
            this.panel_General.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Login;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_AuthIndicator;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button_GetPartsNum;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Panel panel_Meeting;
        private System.Windows.Forms.Button button_LeaveMeeting;
        private System.Windows.Forms.Button button_connToMeeting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_General;
        private System.Windows.Forms.Button button_GetMeetings;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}