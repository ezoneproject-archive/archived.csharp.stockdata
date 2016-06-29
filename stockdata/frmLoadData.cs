using stockdata.jsonobject;
using System;
using System.IO;
using System.Windows.Forms;

namespace stockdata
{
    public partial class frmLoadData : Form
    {
        private bool isRegistered = false;
        private bool isParsed = false;

        /// <summary>
        /// Default form load
        /// </summary>
        public frmLoadData()
        {
            InitializeComponent();

            // check null...
            this.listDataTypes.DataSource = new BindingSource(DataMasterCache.DataMaster.masterList, null);
            this.listDataTypes.DisplayMember = "name";
            this.listDataTypes.ValueMember = "id";
        }

        /// <summary>
        /// Form load with file path name. (Drag n drop open)
        /// </summary>
        /// <param name="fileName"></param>
        public frmLoadData(string fileName) : this()
        {
            txtFilePathName.Text = fileName;
            txtFileName.Text = Path.GetFileName(txtFilePathName.Text);
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

                listDataTypes_SelectedIndexChanged(sender, e);
            }
        }

        private void listDataTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterList selectedMaster = (MasterList)this.listDataTypes.SelectedItem;

            this.listDataTimes.DataSource = new BindingSource(selectedMaster.timeList, null);
            this.listDataTimes.DisplayMember = "name";
            this.listDataTimes.ValueMember = "id";

            // 파일 분석기 가동
            if (txtFilePathName.Text.Length > 0)
            {
                //
            }


            //this.listParseView.DataBindings = new BindingSource(selectedMaster.dataHeader, null);

            // 리스트뷰 뷰 타입
            listParseView.View = View.Details;

            // 데이터를 갱신하기 전에 UI쓰레드를 멈춘다.
            listParseView.BeginUpdate();

            listParseView.Columns.Clear();
            foreach (DataHeader header in selectedMaster.dataHeader)
            {
                listParseView.Columns.Add(header.name, 100, HorizontalAlignment.Left);
            }

            /*
                        // 각 파일별로 ListViewItem객체를 하나씩 만듦
                        // 파일명, 사이즈, 날짜 정보를 추가
                        ListViewItem lvi = new ListViewItem("" + header.id);
                        lvi.SubItems.Add(header.name);

                        // ListViewItem객체를 Items 속성에 추가
                        listParseView.Items.Add(lvi);
            */

            // UI 쓰레드 재개
            listParseView.EndUpdate();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

            // 등록 처리

            isRegistered = true;
        }
    }
}
