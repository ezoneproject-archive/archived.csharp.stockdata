using stockdata.jsonobject;
using stockdata.utils;
using System;
using System.Data;
using System.Windows.Forms;

namespace stockdata.forms
{
    public partial class frm종목변동현황 : Form
    {
        public frm종목변동현황()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStcodeSearch_Click(object sender, EventArgs e)
        {
            // 종목코드검색
            MessageBox.Show("개발중입니다...");
        }

        private void frm종목변동현황_Resize(object sender, EventArgs e)
        {
            dataGridView1.Size = new System.Drawing.Size(this.Size.Width - 40, this.Size.Height - 225);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //조회
            MasterList master = null;
            if (radioBtn강력.Checked)
                master = DataMasterCache.getDataMasterByName("강력출동");
            else if (radioBtn거래이평.Checked)
                master = DataMasterCache.getDataMasterByName("거래20이평");

            if (master == null)
            {
                MessageBox.Show("자료 종류 중 하나를 선택하세요.", "Error");
                return;
            }

            // 자료일자
            DateTime d1 = this.datePicker1.Value;
            string dataDate1 = d1.ToString("yyyyMMdd");
            DateTime d2 = this.datePicker2.Value;
            string dataDate2 = d2.ToString("yyyyMMdd");

            Console.WriteLine("자료종류: " + master.id + ":" + master.name);
            Console.WriteLine("자료일자: " + dataDate1 + " ~ " + dataDate2);

            string dataDate = dataDate1;
            if (!dataDate1.Equals(dataDate2))
                dataDate += "-" + dataDate2;

            // 자료 조회
            // 조회URL: data/<자료종류>/<자료일자>?stockcode=종목코드
            string resource_value = master.id + "/" + dataDate;
            HttpRestClient client = new HttpRestClient("report/diffview/" + resource_value);

            // 조회조건
            if (txtStockCodes.Text.Length > 0)
                client.QueryString.Add("stockcode", txtStockCodes.Text);

            if (!client.doWorkDialog())
            {
                MessageBox.Show(client.ResponseMessage, "Request error!");
                Console.WriteLine(client.getString());

                return;
            }

            // 응답 데이터 처리
            dynamic json = client.getJsonObject();

            DataTable workTable = new DataTable("Report");
            workTable.Columns.Add("자료일자", typeof(String));

            workTable.Columns.Add("09:30", typeof(String));
            workTable.Columns.Add("10:00", typeof(String));
            workTable.Columns.Add("11:00", typeof(String));
            workTable.Columns.Add("12:00", typeof(String));
            workTable.Columns.Add("13:00", typeof(String));
            workTable.Columns.Add("14:00", typeof(String));
            workTable.Columns.Add("15:30", typeof(String));
            workTable.Columns.Add("종목코드", typeof(String));

            foreach (dynamic item in json.dataList)
            {
                DataRow workRow = workTable.NewRow();
                string gsdate = (string)item["gsDate"];
                gsdate = gsdate.Substring(0, 4) + "-" + gsdate.Substring(4, 2) + "-" + gsdate.Substring(6, 2);
                workRow["자료일자"] = gsdate;
                string stCode = (string)item["stockCode"];
                string stName = (string)item["stockName"];
                workRow["종목코드"] = stCode;

                workRow["09:30"] = codeToName((string)item["ST0930"], stCode, stName);
                workRow["10:00"] = codeToName((string)item["ST1000"], stCode, stName);
                workRow["11:00"] = codeToName((string)item["ST1100"], stCode, stName);
                workRow["12:00"] = codeToName((string)item["ST1200"], stCode, stName);
                workRow["13:00"] = codeToName((string)item["ST1300"], stCode, stName);
                workRow["14:00"] = codeToName((string)item["ST1400"], stCode, stName);
                workRow["15:30"] = codeToName((string)item["ST1530"], stCode, stName);

                workTable.Rows.Add(workRow);
            }

            dataGridView1.DataSource = workTable;
            dataGridView1.AutoResizeColumns();
        }

        public static string codeToName(string code, string baseCode, string codeName)
        {
            if (baseCode.Equals(code))
                return codeName;
            else
                return "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["종목코드"].Value.ToString();
            if (txtStockCodes.Text.Length > 0)
                txtStockCodes.Text += ",";
            txtStockCodes.Text += str;
        }
    }
}
