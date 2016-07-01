using stockdata.utils;
using System;
using System.Threading;
using System.Windows.Forms;

namespace stockdata
{
    public partial class frmTransWaiting : Form
    {
        private int maxCnt = 0;
        private Thread thread = null;
        private bool started = false;

        public HttpRestClient httpRestClient { get; set; } = null;

        private frmTransWaiting()
        {
            InitializeComponent();

            progBar.Step = 5;
            progBar.Maximum = progBar.Step * 30;

            thread = new Thread(new ThreadStart(doWork));
        }

        public frmTransWaiting(HttpRestClient httpRestClient) : this()
        {
            this.httpRestClient = httpRestClient;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // 전송작업 중지처리
            if (thread.IsAlive)
            {
                DialogResult result = MessageBox.Show("전송 작업을 중단하시겠습니까?\n" +
                    "서버에서 마저 처리가 될 수도 있으니 처리여부를 확인하셔야 합니다.",
                    "주의", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (thread.IsAlive && httpRestClient != null)
                        httpRestClient.Abort();
                    else
                        this.Close();
                    return;
                }
                else
                    return;
            }

            this.Close();
        }

        private void pgBarTimer_Tick(object sender, EventArgs e)
        {
            if (!started)
            {
                Console.WriteLine("Thread start...");
                thread.Start();
                started = true;
            }

            if (progBar.Value >= progBar.Maximum && maxCnt <= 3)
                maxCnt++;
            else if (progBar.Value >= progBar.Maximum && maxCnt > 3)
                progBar.Value = progBar.Minimum;
            else
                progBar.PerformStep();

            if (!thread.IsAlive)
            {
                this.Close();
            }
        }

        private void doWork()
        {
            if (httpRestClient != null)
                httpRestClient.doWork();
        }

    }
}
