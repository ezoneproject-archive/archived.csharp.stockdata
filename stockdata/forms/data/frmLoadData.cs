using Newtonsoft.Json;
using stockdata.jsonobject;
using stockdata.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace stockdata.forms.data
{
    public partial class frmLoadData : Form
    {
        private bool isRegistered = false;
        private bool isParsed = false;
        private SamFileData samFileParser = new SamFileData();

        /// <summary>
        /// Default form load
        /// </summary>
        public frmLoadData()
        {
            InitializeComponent();

            // check null...
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

        /// <summary>
        /// Form load with file path name. (Drag n drop open)
        /// </summary>
        /// <param name="fileName"></param>
        public frmLoadData(string fileName) : this()
        {
            txtFilePathName.Text = fileName;

            txtFileName.Text = Path.GetFileName(txtFilePathName.Text);
            samFileParser.FileName = txtFilePathName.Text;
        }

        /// <summary>
        /// Browse... button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text File(*.txt)|*.txt|All Files(*.*)|*.*";
            //openFile.InitialDirectory = @"C:\";
            openFile.Title = "Open File ...";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtFilePathName.Text = openFile.FileName;

                txtFileName.Text = Path.GetFileName(txtFilePathName.Text);
                samFileParser.FileName = txtFilePathName.Text;

                listDataTypes_SelectedIndexChanged(sender, e);
            }
        }

        private void listDataTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterList selectedMaster = (MasterList)this.listDataTypes.SelectedItem;

            if (selectedMaster != null && selectedMaster.timeList != null)
            {
                this.listDataTimes.DataSource = new BindingSource(selectedMaster.timeList, null);
                this.listDataTimes.DisplayMember = "name";
                this.listDataTimes.ValueMember = "id";

                this.listDataTimes.SelectedIndex = -1;
            }

            // 항목 Clear
            isRegistered = false;
            this.listParseView.Columns.Clear();
            this.listParseView.Items.Clear();

            // 파일 분석이 완료되었으면 파일을 리스트뷰에 표시
            if (samFileParser.IsSuccess)
            {
                // 리스트뷰 뷰 타입
                this.listParseView.View = View.Details;
                // 데이터를 갱신하기 전에 UI쓰레드를 멈춘다.
                this.listParseView.BeginUpdate();

                // 컬럼헤더 생성
                for (int i = 0; i < samFileParser.HeaderNames.Length; i++)
                {
                    ColumnHeader hdrItem = new ColumnHeader();
                    hdrItem.Text = samFileParser.HeaderNames[i];

                    // 종목코드 정보는 PK 항목
                    if (samFileParser.HeaderNames[i].Equals("종목명") ||
                        samFileParser.HeaderNames[i].Equals("종목코드") ||
                        samFileParser.HeaderNames[i].Equals("소속업종"))
                    {
                        hdrItem.Text = "@" + hdrItem.Text;
                    }

                    if (selectedMaster != null && selectedMaster.dataHeader != null)
                    {
                        foreach (DataHeader header in selectedMaster.dataHeader)
                        {
                            // 항목명이 서버에 저장된 구조와 일치하면 필드명 앞에 * 추가
                            if (samFileParser.HeaderNames[i].Equals(header.name))
                            {
                                hdrItem.Text = "*" + hdrItem.Text;
                                hdrItem.Name = "" + header.id;
                                break;
                            }
                        }
                    }
                    hdrItem.Width = hdrItem.Text.Length * 15;

                    this.listParseView.Columns.Add(hdrItem);
                }

                // 리스트 데이터 생성
                foreach (List<SamFileDataStruct> data in samFileParser.DataItems)
                {
                    ListViewItem item = null;
                    foreach (SamFileDataStruct sam in data)
                    {
                        if (item == null)
                            item = new ListViewItem(sam.FieldValue);
                        else
                            item.SubItems.Add(sam.FieldValue);
                    }

                    this.listParseView.Items.Add(item);
                }

                // UI 쓰레드 재개
                this.listParseView.EndUpdate();

                isParsed = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewDesign_Click(object sender, EventArgs e)
        {
            MessageBox.Show("예정입니다...", "Error");
            return;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (isRegistered)
            {
                MessageBox.Show("이미 등록했습니다.", "Error");
                return;
            }

            if (!isParsed)
            {
                MessageBox.Show("미분석 파일입니다.", "Error");
                return;
            }

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

            // 자료 등록 처리
            // 등록URL: data/<자료종류>/<자료일자>/<자료시간>
            string resource_value = dataTypeId + "/" + dataDate + "/" + dataTime;
            HttpRestClient client = new HttpRestClient(HttpRestClient.REST_METHOD_CREATE, "data/" + resource_value);

            client.RequestDataFormat = HttpRestClient.DATA_FORMAT_JSON;
            string jsonStr = JsonConvert.SerializeObject(samFileParser.DataItems);
            client.RequestContent = Encoding.UTF8.GetBytes(jsonStr);

            // -------------------------------------------
            //Console.WriteLine(jsonStr);
            //File.WriteAllText("json.txt", jsonStr);

            if (!client.doWorkDialog())
            {
                client.showErrorDialog();
                return;
            }

            dynamic json = client.getJsonObject();
            if (json == null)
            {
                MessageBox.Show("전송 오류가 발생했습니다. (Can't convert json)", "Format error!");
                return;
            }
            Console.WriteLine("statusCode: " + json["_metadata"]["statusCode"]);

            if (json["FieldNotFound"] != null && ((string)json["FieldNotFound"]).Length > 0)
            {
                MessageBox.Show("다음 항목은 미등록 항목으로 저장하지 않았습니다.\n" + ((string)json["FieldNotFound"]), "주의");
            }

            //json["ErrorData"];

            if ((int)json["Rows"] == 0)
                MessageBox.Show("등록 건수가 없습니다. 중복여부를 확인하세요.", "등록오류");
            else
                MessageBox.Show(((string)json["Rows"]) + "건 등록이 완료되었습니다.", "등록완료");

            isRegistered = true;
        }

    }
}

