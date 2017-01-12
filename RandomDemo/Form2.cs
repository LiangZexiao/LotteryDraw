using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace RandomDemo
{
    public partial class Form2 : Form
    {
        SoundPlayer player;
        
        public Form2()
        {
            player = new SoundPlayer("鼓点.wav");

            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            player.PlayLooping();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            //timer1.Interval = 100;
            //timer1.Start();
            label2.Text = "进度：0%";
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        /*
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value<progressBar1.Maximum)
            {
                progressBar1.Value++;
                //int progress = (progressBar1.Value / progressBar1.Maximum) * 100;
                label2.Text = "进度：" + progressBar1.Value.ToString() + "%";
            }
            else
            {
                label2.Text="完成！";
                player.Stop();
                timer1.Stop();
            }
        }*/

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                if (backgroundWorker1.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                    backgroundWorker1.ReportProgress(i * 10);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label2.Text = "进度：" + (e.ProgressPercentage.ToString() + "%");
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label2.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                label2.Text = "Error:" + e.Error.Message;
            }
            else
            {
                label2.Text = "完成!";

                player.Stop();
                
                this.Close();
            }
        }
    }
}
