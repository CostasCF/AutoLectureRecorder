using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auto_Lecture_Recorder.BotController;

namespace Auto_Lecture_Recorder
{
    public partial class TestForm : Form
    {
        ChromeBot bot;

        public TestForm()
        {
            InitializeComponent();
        }
        private void TestForm_Load(object sender, EventArgs e)
        {
            button_LeaveMeeting.Enabled = false;
            button_GetPartsNum.Enabled = false;

            bot = new ChromeBot();            

            if (bot.IsCookieExpired("TSPREAUTHCOOKIE"))
            {
                label_AuthIndicator.Text = "Not Authenticated";
                label_AuthIndicator.ForeColor = Color.Red;

                panel_Meeting.Visible = false;
                panel_General.Visible = false;
                panel_Login.Visible = true;
                
            }
            else
            {
                label_AuthIndicator.Text = "User Authenticated";
                label_AuthIndicator.ForeColor = Color.Green;

                panel_Login.Visible = false;
                panel_Meeting.Visible = true;
                panel_General.Visible = true;
                
            }
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Invalid Credentials");
                return;
            }

            bool isValid = bot.AuthenticateUser(textBox1.Text, textBox2.Text);
            if(isValid)
            {
                label_AuthIndicator.Text = "User Authenticated";
                label_AuthIndicator.ForeColor = Color.Green;

                panel_Login.Visible = false;
                panel_Meeting.Visible = true;
                panel_General.Visible = true;
            }
            else
            {
                label_AuthIndicator.Text = "Not Authenticated";
                label_AuthIndicator.ForeColor = Color.Red;
            }

        }

        private void button_connToMeeting_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Invalid meeting name");
                return;
            }

            bool inMeeting = bot.ConnectToMeetingByName(textBox3.Text);
            if(inMeeting)
            {
                button_connToMeeting.Enabled = true;
                button_GetPartsNum.Enabled = true;
            }           
        }

        private void button_LeaveMeeting_Click(object sender, EventArgs e)
        {
            bot.LeaveMeeting();

            button_LeaveMeeting.Enabled = false;
            button_GetPartsNum.Enabled = false;
        }

        private void button_GetPartsNum_Click(object sender, EventArgs e)
        {
            textBox4.Text = bot.GetParticipantsNumber().ToString();
        }

        private void button_GetMeetings_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                List<string> meetingsList = bot.GetMeetings();
                if(meetingsList == null)
                {
                    MessageBox.Show("Getting meetings failed");
                    return;
                }
                foreach (string s in meetingsList)
                {
                    sb.AppendLine(s);
                }
                richTextBox1.Text = sb.ToString();
            }
            catch
            {
                MessageBox.Show("Getting meetings failed");
            }
           
        }
    }
}
