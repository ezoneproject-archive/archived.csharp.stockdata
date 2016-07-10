using Newtonsoft.Json;
using stockdata.jsonobject;
using stockdata.utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace stockdata.forms.data
{
    public partial class frmStockCode : Form
    {
        /// <summary>
        /// 선택 리스트 목록
        /// </summary>
        public List<string> selectedList { get; private set; } = new List<string>();

        public frmStockCode()
        {
            InitializeComponent();
        }

        public frmStockCode(string text) : this()
        {
            txtSearch.Text = text;
            btnSearch_Click(null, null);
        }

        /// <summary>
        /// 닫기버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                Console.WriteLine("선택한 항목: " + listView1.SelectedItems[i].Name);
                selectedList.Add(listView1.SelectedItems[i].Name);
            }
            
            this.Close();
        }

        public override string ToString()
        {
            string str = "";
            foreach (string item in selectedList)
            {
                if (str.Length > 0)
                    str += ",";
                str += item;
            }

            return str;
        }

        /// <summary>
        /// 검색버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 자료 조회
            // 조회URL: stockcode/?search=검색어
            HttpRestClient client = new HttpRestClient("stockcode");

            // 조회조건
            if (txtSearch.Text.Length > 0)
                client.QueryString.Add("search", txtSearch.Text);

            if (!client.doWorkDialog())
            {
                client.showErrorDialog();
                return;
            }

            // 응답 데이터 처리
            StockCode data = JsonConvert.DeserializeObject<StockCode>(client.getString());

            // 리스트뷰 뷰 타입
            listView1.View = View.Details;
            // 데이터를 갱신하기 전에 UI쓰레드를 멈춘다.
            listView1.BeginUpdate();

            // 컬럼헤더 Clear
            listView1.Columns.Clear();

            listView1.Columns.Add("stockCode", "종목코드", 5 * 15);
            listView1.Columns.Add("stockName", "종목명", 9 * 15);
            listView1.Columns.Add("stockCate", "소속업종", 9 * 15);

            // 종목코드 찾음, 없을경우 새 row에 등록
            listView1.Items.Clear();
            foreach (StockCodeItem item in data.dataList)
            {
                ListViewItem listItem = new ListViewItem(item.stockCode);
                listItem.Name = item.stockCode;
                listItem.SubItems.Add(item.stockName);
                listItem.SubItems.Add(item.cateName);

                listView1.Items.Add(listItem);
            }

            // UI 쓰레드 재개
            listView1.EndUpdate();
        }

        /// <summary>
        /// 항목 더블클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnClose_Click(sender, e);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnSearch_Click(null, null);
            }

        }
    }
}
