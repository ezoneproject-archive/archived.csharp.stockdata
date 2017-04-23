using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace stockdata.forms.report
{
    public partial class frm기관시총대비순매수ONL : Form
    {
        CPUTILLib.CpCybos cpCybos = null;
        CPSYSDIBLib.CpSvrNew7215A cpSvrNew7215a = null; // [7215 투자자별 매매상위(확정)]
        DSCBO1Lib.StockMst2 stockMst2 = null; // CpDib [7059 관심종목조회]

        public frm기관시총대비순매수ONL()
        {
            InitializeComponent();

            /*
            Excel.Workbook wb = null;
            Excel.Application oXL = new Excel.Application();
            oXL.Visible = true;
            MessageBox.Show("Run excel...");
            oXL.Quit();
            */
            /*
            CPUTILLib.CpStockCode stock = new CPUTILLib.CpStockCode();
            string name = stock.CodeToName("A003220");
            MessageBox.Show("==> " + name);
            */

            cmbMarketType.Text = "1-거래소";
            cmbDateType.Text = "1-최근일";
        }

        private void btnCybos_Click(object sender, EventArgs e)
        {
            if (cpCybos == null)
            {
                try
                {
                    cpCybos = new CPUTILLib.CpCybos();
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("CybosPlus가 설치되어 있지 않습니다.\nCybos 로그인 화면에서 Cybos plus 탭을 클릭하고 로그인하세요.");
                    cpCybos = null;
                    return;
                }
            }

            if (cpCybos.IsConnect == 0)
            {
                btnCybos.Text = "CybosPlus 연결";
                MessageBox.Show("CybosPlus로 로그인되어 있지 않습니다.\nCybos 로그인 화면에서 Cybos plus 탭을 클릭하고 로그인하세요.");
                return;
            }

            btnCybos.Text = "CybosPlus 사용중";

            if (cpSvrNew7215a == null)
                cpSvrNew7215a = new CPSYSDIBLib.CpSvrNew7215A();

            if (stockMst2 == null)
                stockMst2 = new DSCBO1Lib.StockMst2();

        }

        /// <summary>
        /// 7215 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbMarketType.Text.Length == 0)
            {
                MessageBox.Show("장 구분을 선택해주세요.");
                return;
            }

            if (cmbDateType.Text.Length == 0)
            {
                MessageBox.Show("일자 구분을 선택해주세요.");
                return;
            }

            // 자료일자
            long ldateFrom = 0;
            long ldateTo = 0;
            {
                DateTime dFrom = this.dateFrom.Value;
                DateTime dTo = this.dateTo.Value;
                string sdFrom1 = dFrom.ToString("yyyyMMdd");
                string sdTo1 = dTo.ToString("yyyyMMdd");

                ldateFrom = long.Parse(sdFrom1);
                ldateTo = long.Parse(sdTo1);

                if (ldateFrom > ldateTo)
                {
                    MessageBox.Show("종료일자가 시작일자보다 큽니다.");
                    return;
                }
            }

            if (cpSvrNew7215a == null || stockMst2 == null)
            {
                MessageBox.Show("CybosPlus 에 접속되어있지 않습니다. 접속 후 처리하세요.");
                return;
            }

            if (cpSvrNew7215a.GetDibStatus() == 1 || stockMst2.GetDibStatus() == 1)
            {
                MessageBox.Show("수신대기중입니다. (종료후 다시 실행해 주세요...)");
                return;
            }

            char marketType = char.Parse(cmbMarketType.Text.Substring(0, 1));
            char dateType = char.Parse(cmbDateType.Text.Substring(0, 1));

            Console.WriteLine("입력: " + marketType + ", " + dateType + ", " + ldateFrom + " ~ " + ldateTo);

            cpSvrNew7215a.SetInputValue(0, marketType);
            cpSvrNew7215a.SetInputValue(1, dateType);
            if (dateType.Equals('0'))
            {
                Console.WriteLine("Set date...");
                cpSvrNew7215a.SetInputValue(2, ldateFrom);
                cpSvrNew7215a.SetInputValue(3, ldateTo);
            }

            int result = cpSvrNew7215a.BlockRequest();
            if (result != 0)
            {
                string retStr = "";
                switch (result)
                {
                    case 1: retStr = "1:통신요청 실패"; break;
                    case 2: retStr = "2:주문확인창에서 취소"; break;
                    case 3: retStr = "3:그 외 내부오류"; break;
                    case 4: retStr = "4:주문요청 개수 초과"; break;
                    default: retStr = "" + result + ":기타오류"; break;
                }
                MessageBox.Show("CybosPlus 거래처리 오류입니다. [" + retStr + "]");
                return;
            }

            Console.WriteLine("Continue: " + cpSvrNew7215a.Continue);

            ldateFrom = (long)cpSvrNew7215a.GetHeaderValue(1);
            ldateTo = (long)cpSvrNew7215a.GetHeaderValue(2);
            string sdFrom = ldateFrom.ToString();
            string sdTo = ldateTo.ToString();
            if (sdFrom.Length >= 8 && sdTo.Length >= 8)
            {
                DateTime dFrom = new DateTime(int.Parse(sdFrom.Substring(0, 4)), int.Parse(sdFrom.Substring(4, 2)), int.Parse(sdFrom.Substring(6, 2)));
                DateTime dTo = new DateTime(int.Parse(sdTo.Substring(0, 4)), int.Parse(sdTo.Substring(4, 2)), int.Parse(sdTo.Substring(6, 2)));

                this.dateFrom.Value = dFrom;
                this.dateTo.Value = dTo;
            }

            long dataCount = (long)cpSvrNew7215a.GetHeaderValue(0);
            txtCnt.Text = dataCount.ToString();

            // 시가총액을 구하기 위한 종목데이터 조회
            string stCodeList = "";
            for (int i = 0; i < dataCount && i < 100; i++)
            {
                string buyCode = (string)cpSvrNew7215a.GetDataValue(4, i);
                if (stCodeList.Length > 0)
                    stCodeList += ",";
                stCodeList += buyCode;
            }
            if (stCodeList.Length > 0)
            {
                stockMst2.SetInputValue(0, stCodeList);
                result = stockMst2.BlockRequest();
                if (result != 0)
                {
                    string retStr = "";
                    switch (result)
                    {
                        case 1: retStr = "1:통신요청 실패"; break;
                        case 2: retStr = "2:주문확인창에서 취소"; break;
                        case 3: retStr = "3:그 외 내부오류"; break;
                        case 4: retStr = "4:주문요청 개수 초과"; break;
                        default: retStr = "" + result + ":기타오류"; break;
                    }
                    MessageBox.Show("CybosPlus 거래처리 오류입니다. [" + retStr + "]");
                    return;
                }
            }
            int stDataCount = (int)stockMst2.GetHeaderValue(0);

            dataGrid.Rows.Clear();
            for (int i = 0; i < dataCount; i++)
            {
                /*
                 * 0 - (string) 종목코드
                   1 - (string) 순매도종목명
                   2 - (long) 순매도량
                   3 - (long) 순매도대금
                   4 - (string) 순매수종목코드
                   5 - (string) 순매수종목명
                   6 - (long) 순매수량
                   7 - (long) 순매수대금
                */
                string sellCode = (string)cpSvrNew7215a.GetDataValue(0, i);
                string sellName = (string)cpSvrNew7215a.GetDataValue(1, i);
                long sellCount = (long)cpSvrNew7215a.GetDataValue(2, i);
                long sellAmt = (long)cpSvrNew7215a.GetDataValue(3, i);
                string buyCode = (string)cpSvrNew7215a.GetDataValue(4, i);
                string buyName = (string)cpSvrNew7215a.GetDataValue(5, i);
                long buyCount = (long)cpSvrNew7215a.GetDataValue(6, i);
                long buyAmt = (long)cpSvrNew7215a.GetDataValue(7, i);

                long currentAmt = 0; // 현재가
                decimal totalStockCnt = 0; // 상장주식수
                for (int j = 0; j < stDataCount; j++)
                {
                    string stCode = (string)stockMst2.GetDataValue(0, j);
                    if (!stCode.Equals(buyCode))
                        continue;
                    currentAmt = (long)stockMst2.GetDataValue(3, i); // 3: 현재가
                    totalStockCnt = (decimal)stockMst2.GetDataValue(17, i); // 3: 현재가
                }
                long totalStockAmt = (long)((currentAmt * totalStockCnt) / 1000000); // 시가총액

                long buyItemAmt = buyAmt * 1000000 / buyCount / 100; // 매수단가
                double buyP = (long)((double)buyAmt / (double)totalStockAmt * 100000);
                buyP /= 1000;

                long buyItemAmt2 = buyItemAmt * 96 / 100; // 매수단가2

                dataGrid.Rows.Add(buyCode, buyName, buyCount, buyAmt, totalStockAmt, buyItemAmt, currentAmt, buyP, buyItemAmt2, sellCode, sellName, sellCount, sellAmt);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            // save as 대화상자 열기...

            // excel start...
            Excel._Workbook oWB = null;
            Excel._Worksheet oSheet = null;
            Excel.Application oXL = new Excel.Application();

            oXL.Visible = true;
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            int colCount = dataGrid.Columns.Count;
            for (int i = 0; i < colCount; i++)
            {
                ((Excel.Range)oSheet.Cells[1, (i + 1)]).Value = dataGrid.Columns[i].HeaderText;
            }

            for (int rowIdx = 0; rowIdx < dataGrid.Rows.Count; rowIdx++)
            {
                int cellRow = rowIdx + 2;

                for (int i = 0; i < colCount; i++)
                {
                    ((Excel.Range)oSheet.Cells[cellRow, (i + 1)]).Value = dataGrid.Rows[rowIdx].Cells[i].Value;
                }
            }

            //string tblName = (string)((Excel.Range)oSheet.Cells[1, 4]).Text


            //oXL.Quit();

            if (oSheet != null)
                Marshal.ReleaseComObject(oSheet);
            if (oWB != null)
                Marshal.ReleaseComObject(oWB);
            if (oXL != null)
                Marshal.ReleaseComObject(oXL);

        }
    }
}

