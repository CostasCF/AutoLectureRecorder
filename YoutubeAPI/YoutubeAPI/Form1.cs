
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeAPI
{
    public partial class Form1 : Form
    {
        YoutubeUploader myyoutube = new YoutubeUploader();
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }



        private async void uploadBtn_Click(object sender, EventArgs e)
        {

            try
            {

                await myyoutube.UploadVideo("Sample.mkv", "pithanotites", "12.12.2020");
                lblstatus.Text = "Video Uploaded";
            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void browserBtn_Click(object sender, EventArgs e)
        {

        }


        private async void button1_Click(object sender, EventArgs e)
        {

            try
            {

                await myyoutube.retrievePlaylists();

            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        bool authenticationIsSuccessful = false;
        private async void authenticateBtn_Click(object sender, EventArgs e)
        {
            //Color color = new Color();
            try
            {
                authenticationIsSuccessful = await myyoutube.Authentication();
                if (authenticationIsSuccessful)
                {
                    label1.Visible = true;
                    label1.Text = "Success";
                    label1.ForeColor = Color.Green;
                }
                else {
                    label1.Visible = true;
                    label1.Text = "Failed to authenticate";
                    label1.ForeColor = Color.Red;
                }
                // await myyoutube.retrievePlaylists();

            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
