using stockdata.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stockdata.forms.manager
{
    public partial class frmErrorManage : Form
    {
        private DataTable workTable = null;
        private string lastNo = null;

        public frmErrorManage()
        {
            InitializeComponent();
        }

        public frmErrorManage(DateTime dateFrom, DateTime dateTo, string apiKey, string requestID) : this()
        {
            if (dateFrom != null)
                this.dateTimeFrom.Value = dateFrom;
            if (dateTo != null)
                this.dateTimeTo.Value = dateTo;

            if (apiKey != null && apiKey.Length > 0)
                this.comboAPIKEY.Text = apiKey;

            if (requestID != null && requestID.Length > 0)
                this.txtRequestId.Text = requestID;

            btnSearch_Click(null, null);
        }

        /// <summary>
        /// 닫기버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 폼 크기 변경 시 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmErrorManage_Resize(object sender, EventArgs e)
        {
            dataGridView1.Size = new System.Drawing.Size(this.Size.Width - 45, this.Size.Height - 210);
        }

        /// <summary>
        /// 조회 버튼 클릭시 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            workTable = new DataTable("log");
            workTable.Columns.Add("No", typeof(String));

            workTable.Columns.Add("Date", typeof(String));
            workTable.Columns.Add("Time", typeof(String));
            workTable.Columns.Add("API Key", typeof(String));
            workTable.Columns.Add("Ticket ID", typeof(String));
            workTable.Columns.Add("Message", typeof(String));
            workTable.Columns.Add("Trace", typeof(String));

            lastNo = null;

            btnSearchNext_Click(sender, e);

            dataGridView1.DataSource = workTable;
            dataGridView1.AutoResizeColumns();
        }

        /// <summary>
        /// 다음 조회 버튼 클릭시 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchNext_Click(object sender, EventArgs e)
        {
            if (workTable == null)
            {
                MessageBox.Show("조회 후 추가 조회하세요.");
                return;
            }

            // 자료일자
            string dateFrom = this.dateTimeFrom.Value.ToString("yyyyMMdd");
            string dateTo = this.dateTimeTo.Value.ToString("yyyyMMdd");

            string dataDate = dateFrom;
            if (!dateFrom.Equals(dateTo))
                dataDate += "-" + dateTo;

            // 자료 조회
            // 조회URL: manager/log/<자료일자>?옵션
            HttpRestClient client = new HttpRestClient("manager/error/" + dataDate);

            // 조회조건
            if (comboAPIKEY.Text.Length > 0)
                client.QueryString.Add("apikey", comboAPIKEY.Text);

            if (txtRequestId.Text.Length > 0)
                client.QueryString.Add("requestid", txtRequestId.Text);

            // 페이징처리...
            if (lastNo != null && lastNo.Length > 0)
                client.QueryString.Add("startno", lastNo);

            if (!client.doWorkDialog())
            {
                client.showErrorDialog();
                return;
            }

            // 응답 데이터 처리
            dynamic json = client.getJsonObject();

            foreach (dynamic item in json.dataList)
            {
                DataRow workRow = workTable.NewRow();
                workRow["No"] = item["no"];

                string date = (string)item["date"];
                date = date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6, 2);
                workRow["Date"] = date;

                string time = (string)item["time"];
                time = time.Substring(0, 2) + ":" + time.Substring(2, 2) + ":" + time.Substring(4, 2);
                workRow["Time"] = time;

                workRow["API Key"] = item["apiKey"];
                workRow["Ticket ID"] = item["reuqestId"];
                workRow["Message"] = item["message"];
                workRow["Trace"] = item["trace"];

                workTable.Rows.Add(workRow);

                lastNo = (string)item["no"];
            }

            dataGridView1.AutoResizeColumns();
        }

        /// <summary>
        /// 로그 관리 열기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenLogManage_Click(object sender, EventArgs e)
        {
            frmLogManage frmL = null;

            // 그리드에서 선택된 행의 티켓ID를 가져와서 frmLogManage 창을 연다
            if (dataGridView1.CurrentCellAddress.Y >= 0)
            {
                string str = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["Ticket ID"].Value.ToString();
                frmL = new frmLogManage(this.dateTimeFrom.Value, this.dateTimeTo.Value, this.comboAPIKEY.Text, str);

            }
            else
            {
                frmL = new frmLogManage(this.dateTimeFrom.Value, this.dateTimeTo.Value, this.comboAPIKEY.Text, this.txtRequestId.Text);
            }

            frmL.MdiParent = this.MdiParent;
            frmL.Show();
        }

        /// <summary>
        /// 삭제 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 자료일자
            DateTime dateTimeFrom = this.dateTimeFrom.Value;
            DateTime dateTimeTo = this.dateTimeTo.Value;
            DateTime curDate = DateTime.Now;

            if (dateTimeFrom.Date > dateTimeTo.Date)
            {
                MessageBox.Show("대상일자 오류입니다. (시작일이 종료일보다 큼)");
                return;
            }

            if (dateTimeTo.Date >= curDate.Date)
            {
                MessageBox.Show("삭제대상일이 현재일자보다 같거나 큽니다.");
                return;
            }

            string dateFrom = dateTimeFrom.ToString("yyyyMMdd");
            string dateTo = dateTimeTo.ToString("yyyyMMdd");
            string dataDate = dateFrom;
            if (!dateFrom.Equals(dateTo))
                dataDate += "-" + dateTo;

            // 확인
            DialogResult result = MessageBox.Show("자료일자: " + dataDate +
                "\n\n삭제하시겠습니까? 삭제는 되돌릴 수 없습니다.", "주의", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;

            // 자료 삭제요청
            // 삭제URL: manager/log/<자료일자>
            HttpRestClient client = new HttpRestClient(HttpRestClient.REST_METHOD_DELETE, "manager/error/" + dataDate);

            if (!client.doWorkDialog())
            {
                client.showErrorDialog();
                return;
            }

            MessageBox.Show("삭제요청이 처리되었습니다.", "완료");
        }

        /// <summary>
        /// 셀 더블클릭 상세조회 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCellAddress.Y < 0)
            {
                return;
            }

            // 그리드에서 선택한 셀
            string strMessage = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["Message"].Value.ToString();
            string strTrace = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["Trace"].Value.ToString();

            frmErrorMessageDetail frmL = new frmErrorMessageDetail(strMessage, strTrace);
            frmL.MdiParent = this.MdiParent;
            frmL.Show();
            //frmL.ShowDialog();
        }
    }
}
