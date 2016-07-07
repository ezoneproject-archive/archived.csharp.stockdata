using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Windows.Forms;

namespace stockdata.utils
{
    public partial class frmTransError : Form
    {
        public HttpRestClient httpRestClient { get; set; } = null;

        public frmTransError()
        {
            InitializeComponent();
        }

        public frmTransError(HttpRestClient httpRestClient) : this()
        {
            this.httpRestClient = httpRestClient;

            txtRespCode.Text = ("" + httpRestClient.ResponseCode);
            txtRespMesg.Text = httpRestClient.ResponseMessage;

            dynamic jsonObj = httpRestClient.getJsonObject();
            if (jsonObj == null)
            {
                txtErrorInfoMessage.Text = httpRestClient.getString();
            }
            else
            {
                try
                {
                    txtServerName.Text = jsonObj["_metadata"]["ServerName"];
                    txtClientAddr.Text = jsonObj["_metadata"]["ClientAddr"];
                    txtRequestMethod.Text = jsonObj["_metadata"]["RequestMethod"];
                    txtRequestPath.Text = jsonObj["_metadata"]["RequestPath"];
                    txtRequestId.Text = jsonObj["_metadata"]["RequestId"];
                }
                catch (RuntimeBinderException)
                {
                    Console.WriteLine("_metadata not found.");
                }

                try
                {
                    txtErrorInfoType.Text = jsonObj["_errorInfo"]["Type"];
                    txtErrorInfoMessage.Text = jsonObj["_errorInfo"]["Message"];
                }
                catch (RuntimeBinderException)
                {
                    Console.WriteLine("_errorInfo not found.");
                }
            }
        }

        // TODO: 로그 저장해서 원격지원 기능 추가할 수 있도록 할 것...
        // 요청내용 dump, 응답내용 dump, 기타등등...

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
