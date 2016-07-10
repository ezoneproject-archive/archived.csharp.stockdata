using stockdata.jsonobject;
using stockdata.utils;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace stockdata.forms.report
{
    public partial class frm집계표 : Form
    {
        public frm집계표()
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

        private void frm집계표_Resize(object sender, EventArgs e)
        {
            dataGridView1.Size = new System.Drawing.Size(this.Size.Width - 40, this.Size.Height - 225);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //조회
            MasterList master = null;
            if (radioBtn기관.Checked)
                master = DataMasterCache.getDataMasterByName("기관잠정치매매");
            else if (radioBtn외인.Checked)
                master = DataMasterCache.getDataMasterByName("외인잠정치매매");
            else if (radioBtn외인기관.Checked)
                master = DataMasterCache.getDataMasterByName("외인기관쌍끌이잠정치매매");

            if (master == null)
            {
                MessageBox.Show("자료 종류 중 하나를 선택하세요.", "Error");
                return;
            }

            // 자료일자
            DateTime d = this.datePicker.Value;
            string dataDate = d.ToString("yyyyMMdd");

            Console.WriteLine("자료종류: " + master.id + ":" + master.name);
            Console.WriteLine("자료일자: " + dataDate);

            // 자료 조회
            // 조회URL: data/<자료종류>/<자료일자>?stockcode=종목코드
            string resource_value = master.id + "/" + dataDate;
            HttpRestClient client = new HttpRestClient("report/listview/" + resource_value);

            // 조회조건
            if (txtStockCodes.Text.Length > 0)
                client.QueryString.Add("stockcode", txtStockCodes.Text);

            if (!client.doWorkDialog())
            {
                client.showErrorDialog();
                return;
            }

            // 응답 데이터 처리
            dynamic json = client.getJsonObject();

            DataTable workTable = new DataTable("Report");
            workTable.Columns.Add("종목코드", typeof(String));
            workTable.Columns.Add("종목명", typeof(String));

            workTable.Columns.Add("외0920-계", typeof(int));       // field

            workTable.Columns.Add("외0950-증감", typeof(int));
            workTable.Columns.Add("외0950-계", typeof(int));       // field
            //workTable.Columns.Add("기0950-증감", typeof(int));
            workTable.Columns.Add("기0950-계", typeof(int));       // field
            workTable.Columns.Add("0950-소계", typeof(int));
            workTable.Columns["외0950-증감"].Expression = "[외0950-계] - [외0920-계]";
            workTable.Columns["0950-소계"].Expression = "[외0950-계] + [기0950-계]";

            workTable.Columns.Add("외1100-증감", typeof(int));
            workTable.Columns.Add("외1100-계", typeof(int));       // field
            workTable.Columns.Add("기1100-증감", typeof(int));
            workTable.Columns.Add("기1100-계", typeof(int));       // field
            workTable.Columns.Add("1100-소계", typeof(int));
            workTable.Columns["외1100-증감"].Expression = "[외0950-계] - [외1100-계]";
            workTable.Columns["기1100-증감"].Expression = "[기0950-계] - [기1100-계]";
            workTable.Columns["1100-소계"].Expression = "[외1100-계] + [기1100-계]";

            workTable.Columns.Add("외1320-증감", typeof(int));
            workTable.Columns.Add("외1320-계", typeof(int));       // field
            workTable.Columns.Add("기1320-증감", typeof(int));
            workTable.Columns.Add("기1320-계", typeof(int));       // field
            workTable.Columns.Add("1320-소계", typeof(int));
            workTable.Columns["외1320-증감"].Expression = "[외1100-계] - [외1320-계]";
            workTable.Columns["기1320-증감"].Expression = "[기1100-계] - [기1320-계]";
            workTable.Columns["1320-소계"].Expression = "[외1320-계] + [기1320-계]";

            workTable.Columns.Add("외1505-증감", typeof(int));
            workTable.Columns.Add("외1505-계", typeof(int));       // field
            workTable.Columns.Add("기1505-증감", typeof(int));
            workTable.Columns.Add("기1505-계", typeof(int));       // field
            workTable.Columns.Add("1505-소계", typeof(int));
            workTable.Columns["외1505-증감"].Expression = "[외1320-계] - [외1505-계]";
            workTable.Columns["기1505-증감"].Expression = "[기1320-계] - [기1505-계]";
            workTable.Columns["1505-소계"].Expression = "[외1505-계] + [기1505-계]";

            foreach (dynamic item in json.dataList)
            {
                //DataRow[] foundRows = workTable.Select("종목코드 = '" + item["stockCode"] + "'");
                //if (foundRows == null || foundRows.Length == 0)
                //{
                DataRow workRow = workTable.NewRow();
                workRow["종목코드"] = item["stockCode"];
                workRow["종목명"] = item["stockName"];

                workRow["외0920-계"] = strToInt((string)item["fgn_0920"]);

                workRow["외0950-계"] = strToInt((string)item["fgn_0950"]);
                workRow["기0950-계"] = strToInt((string)item["inv_0950"]);
                workRow["외1100-계"] = strToInt((string)item["fgn_1100"]);
                workRow["기1100-계"] = strToInt((string)item["inv_1100"]);
                workRow["외1320-계"] = strToInt((string)item["fgn_1320"]);
                workRow["기1320-계"] = strToInt((string)item["inv_1320"]);
                workRow["외1505-계"] = strToInt((string)item["fgn_1505"]);
                workRow["기1505-계"] = strToInt((string)item["inv_1505"]);

                workTable.Rows.Add(workRow);
                //}
            }

            dataGridView1.DataSource = workTable;
            dataGridView1.AutoResizeColumns();

            dataGridView1.Columns["외0920-계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["외0950-증감"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["외0950-계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["기0950-계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["0950-소계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["외1100-증감"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["외1100-계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["기1100-증감"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["기1100-계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["1100-소계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["외1320-증감"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["외1320-계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["기1320-증감"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["기1320-계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["1320-소계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["외1505-증감"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["외1505-계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["기1505-증감"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["기1505-계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["1505-소계"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns["외0920-계"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["외0950-증감"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["외0950-계"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["기0950-계"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["0950-소계"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["외1100-증감"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["외1100-계"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["기1100-증감"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["기1100-계"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["1100-소계"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["외1320-증감"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["외1320-계"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["기1320-증감"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["기1320-계"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["1320-소계"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["외1505-증감"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["외1505-계"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["기1505-증감"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["기1505-계"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["1505-소계"].DefaultCellStyle.Format = "N0";
        }

        public static int strToInt(string str)
        {
            Regex regex = new Regex(@"[^-|\d]");
            string result = regex.Replace(str, "");

            if (result.Length == 0)
                return 0;

            return int.Parse(result);
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
