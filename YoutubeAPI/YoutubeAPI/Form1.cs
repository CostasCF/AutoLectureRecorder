
using System;
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
        private void uploadBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                Thread thead = new Thread(() =>
                {
                  //  myyoutube.Run("Sample.mkv","pithanotites","pithanotites","12.12.2020").Wait();
                });
                thead.IsBackground = true;
                thead.Start();

            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
        private void browserBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Thread thead = new Thread(() =>
                {
                    myyoutube.Run().Wait();
                });
                thead.IsBackground = true;
                thead.Start();

            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
