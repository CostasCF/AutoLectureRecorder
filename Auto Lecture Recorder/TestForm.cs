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
            label_AuthIndicator.Text = "Not Authenticated";
            label_AuthIndicator.ForeColor = Color.Red;

            bot = new ChromeBot();

            //button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bot = new ChromeBot();           

            bool isValid = false;
            if (!String.IsNullOrEmpty(textBox1.Text) || !String.IsNullOrEmpty(textBox2.Text))
            {
                label_AuthIndicator.Text = "Authenticating...";
                label_AuthIndicator.ForeColor = Color.Gray;

                isValid = bot.AuthenticateUser(textBox1.Text, textBox2.Text);
            }               
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
                  
            if(isValid)
            {
                label_AuthIndicator.Text = "User Authenticated";
                label_AuthIndicator.ForeColor = Color.Green;

                button2.Enabled = true;
            }
            else
            {
                label_AuthIndicator.Text = "Not Authenticated";
                label_AuthIndicator.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Invalid metting link");
                return;
            }

            bool onMeeting = bot.ConnectToMeetingByName(textBox3.Text);
            if(onMeeting)
            {

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            List<string> meetingsList = bot.GetMeetings();
            foreach (string s in meetingsList)
            {
                sb.AppendLine(s);
            }
            richTextBox1.Text = sb.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bot.GoToTeamsMenu();
        }
    }
}
