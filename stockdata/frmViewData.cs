﻿using Newtonsoft.Json;
using stockdata.jsonobject;
using stockdata.utils;
using System;
using System.Windows.Forms;

namespace stockdata
{
    public partial class frmViewData : Form
    {
        public frmViewData()
        {
            InitializeComponent();

            if (DataMasterCache.DataMaster.masterList != null)
            {
                this.listDataTypes.BeginUpdate();
                this.listDataTypes.DataSource = new BindingSource(DataMasterCache.DataMaster.masterList, null);
                this.listDataTypes.DisplayMember = "name";
                this.listDataTypes.ValueMember = "id";
                this.listDataTypes.EndUpdate();

                this.listDataTypes.SelectedIndex = -1;
            }
        }

        private void listDataTypes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            MasterList selectedMaster = (MasterList)this.listDataTypes.SelectedItem;

            if (selectedMaster != null && selectedMaster.timeList != null)
            {
                this.listDataTimes.DataSource = new BindingSource(selectedMaster.timeList, null);
                this.listDataTimes.DisplayMember = "name";
                this.listDataTimes.ValueMember = "id";

                this.listDataTimes.SelectedIndex = -1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            if (this.listDataTypes.SelectedIndex < 0)
            {
                MessageBox.Show("자료 종류를 선택하지 않았습니다.", "Error");
                return;
            }

            if (this.listDataTimes.SelectedIndex < 0)
            {
                MessageBox.Show("시간을 선택하지 않았습니다.", "Error");
                return;
            }

            // 자료 종류
            MasterList selectedMaster = (MasterList)this.listDataTypes.SelectedItem;
            string dataTypeName = selectedMaster.name;
            int dataTypeId = selectedMaster.id;

            // 자료 시간
            string dataTime = (string)this.listDataTimes.SelectedValue;

            // 자료일자
            DateTime d = this.datePicker.Value;
            string dataDate = d.ToString("yyyyMMdd");

            Console.WriteLine("자료종류: " + dataTypeId + ":" + dataTypeName);
            Console.WriteLine("자료일자: " + dataDate);
            Console.WriteLine("자료시간: " + dataTime);

            // 자료 조회
            // 등록URL: data/<자료종류>/<자료일자>/<자료시간>
            string resource_value = dataTypeId + "/" + dataDate + "/" + dataTime;
            HttpRestClient client = new HttpRestClient("data/" + resource_value);

            if (!client.doWork())
            {
                MessageBox.Show(client.ResponseMessage, "Request error!");
                Console.WriteLine(client.getString());

                return;
            }

            DataRoot data = JsonConvert.DeserializeObject<DataRoot>(client.getString());
            Console.WriteLine("statusCode: " + data._metadata.statusCode);

            // 조회한 자료를 table로 생성한다...

            // 리스트뷰 뷰 타입
            listView.View = View.Details;
            // 데이터를 갱신하기 전에 UI쓰레드를 멈춘다.
            listView.BeginUpdate();

            // 컬럼헤더 Clear
            listView.Columns.Clear();

            listView.Columns.Add("stockCode", "종목코드", 5 *15);
            listView.Columns.Add("stockName", "종목명", 9 *15);
            foreach (DataHeader header in selectedMaster.dataHeader)
            {
                ColumnHeader hdrItem = new ColumnHeader();
                hdrItem.Text = header.name;
                hdrItem.Name = "" + header.id;
                hdrItem.Width = hdrItem.Text.Length * 15;
                listView.Columns.Add(hdrItem);
            }

            // 종목코드 찾음, 없을경우 새 row에 등록
            foreach (DataList item in data.dataList)
            {
                // rows 에서 stockCode 찾음
                //item.stockCode;
                //listView.Columns.
            }

            // UI 쓰레드 재개
            listView.EndUpdate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.listDataTypes.SelectedIndex < 0)
            {
                MessageBox.Show("자료 종류를 선택하지 않았습니다.", "Error");
                return;
            }

            if (this.listDataTimes.SelectedIndex < 0)
            {
                MessageBox.Show("시간을 선택하지 않았습니다.", "Error");
                return;
            }

            // 자료 종류
            MasterList selectedMaster = (MasterList)this.listDataTypes.SelectedItem;
            string dataTypeName = selectedMaster.name;
            int dataTypeId = selectedMaster.id;

            // 자료 시간
            string dataTime = (string)this.listDataTimes.SelectedValue;

            // 자료일자
            DateTime d = this.datePicker.Value;
            string dataDate = d.ToString("yyyyMMdd");

            Console.WriteLine("자료종류: " + dataTypeId + ":" + dataTypeName);
            Console.WriteLine("자료일자: " + dataDate);
            Console.WriteLine("자료시간: " + dataTime);

            // 확인
            DialogResult result = MessageBox.Show("자료명: " + dataTypeName + "\n자료일자: " + dataDate + "\n자료시간: " + dataTime +
                "\n\n삭제하시겠습니까? 삭제는 되돌릴 수 없습니다.", "주의", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;

            // 삭제요청
            // 등록URL: data/<자료종류>/<자료일자>/<자료시간>
            string resource_value = dataTypeId + "/" + dataDate + "/" + dataTime;
            HttpRestClient client = new HttpRestClient(HttpRestClient.REST_METHOD_DELETE, "data/" + resource_value);

            if (!client.doWork())
            {
                MessageBox.Show(client.ResponseMessage, "Request error!");
                Console.WriteLine(client.getString());

                return;
            }
        }
    }
}
