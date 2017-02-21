namespace stockdata.forms.report
{
    partial class frm기관시총대비순매수ONL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCybos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMarketType = new System.Windows.Forms.ComboBox();
            this.cmbDateType = new System.Windows.Forms.ComboBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCnt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.colBuyStCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuyStName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuyCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuyAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPriceTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuyCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCybos
            // 
            this.btnCybos.Location = new System.Drawing.Point(10, 10);
            this.btnCybos.Name = "btnCybos";
            this.btnCybos.Size = new System.Drawing.Size(120, 23);
            this.btnCybos.TabIndex = 1;
            this.btnCybos.Text = "CybosPlus 연결";
            this.btnCybos.UseVisualStyleBackColor = true;
            this.btnCybos.Click += new System.EventHandler(this.btnCybos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "[7215] 투자자별 매매상위(확정)";
            // 
            // cmbMarketType
            // 
            this.cmbMarketType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarketType.FormattingEnabled = true;
            this.cmbMarketType.Items.AddRange(new object[] {
            "1-거래소",
            "2-코스닥"});
            this.cmbMarketType.Location = new System.Drawing.Point(51, 37);
            this.cmbMarketType.Name = "cmbMarketType";
            this.cmbMarketType.Size = new System.Drawing.Size(83, 20);
            this.cmbMarketType.TabIndex = 4;
            // 
            // cmbDateType
            // 
            this.cmbDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateType.FormattingEnabled = true;
            this.cmbDateType.Items.AddRange(new object[] {
            "0-날짜입력",
            "1-최근일",
            "2-최근5일",
            "3-1개월",
            "4-1년"});
            this.cmbDateType.Location = new System.Drawing.Point(140, 37);
            this.cmbDateType.Name = "cmbDateType";
            this.cmbDateType.Size = new System.Drawing.Size(90, 20);
            this.cmbDateType.TabIndex = 5;
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(236, 36);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(176, 21);
            this.dateFrom.TabIndex = 6;
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(418, 35);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(176, 21);
            this.dateTo.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(600, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "조회";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCnt
            // 
            this.txtCnt.Location = new System.Drawing.Point(681, 35);
            this.txtCnt.Name = "txtCnt";
            this.txtCnt.ReadOnly = true;
            this.txtCnt.Size = new System.Drawing.Size(37, 21);
            this.txtCnt.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "※ ON-LINE 거래는 100건만 조회됩니다. (추가조회 없음)";
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBuyStCode,
            this.colBuyStName,
            this.colBuyCount,
            this.colBuyAmt,
            this.colPriceTotal,
            this.colBuyCost,
            this.colCurAmt,
            this.col1,
            this.col2});
            this.dataGrid.Location = new System.Drawing.Point(8, 66);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 23;
            this.dataGrid.Size = new System.Drawing.Size(1076, 397);
            this.dataGrid.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "조건:";
            // 
            // colBuyStCode
            // 
            this.colBuyStCode.HeaderText = "순매수종목코드";
            this.colBuyStCode.Name = "colBuyStCode";
            this.colBuyStCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBuyStCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBuyStName
            // 
            this.colBuyStName.HeaderText = "순매수종목명";
            this.colBuyStName.Name = "colBuyStName";
            this.colBuyStName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBuyStName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBuyStName.Width = 150;
            // 
            // colBuyCount
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = null;
            this.colBuyCount.DefaultCellStyle = dataGridViewCellStyle15;
            this.colBuyCount.HeaderText = "순매수량(백주)";
            this.colBuyCount.Name = "colBuyCount";
            this.colBuyCount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBuyCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBuyAmt
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N0";
            dataGridViewCellStyle16.NullValue = null;
            this.colBuyAmt.DefaultCellStyle = dataGridViewCellStyle16;
            this.colBuyAmt.HeaderText = "순매수대금(백만원)";
            this.colBuyAmt.Name = "colBuyAmt";
            this.colBuyAmt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBuyAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBuyAmt.Width = 120;
            // 
            // colPriceTotal
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N0";
            dataGridViewCellStyle17.NullValue = null;
            this.colPriceTotal.DefaultCellStyle = dataGridViewCellStyle17;
            this.colPriceTotal.HeaderText = "시가총액(백만원)";
            this.colPriceTotal.Name = "colPriceTotal";
            this.colPriceTotal.Width = 140;
            // 
            // colBuyCost
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N0";
            dataGridViewCellStyle18.NullValue = null;
            this.colBuyCost.DefaultCellStyle = dataGridViewCellStyle18;
            this.colBuyCost.HeaderText = "매수단가(기관)";
            this.colBuyCost.Name = "colBuyCost";
            this.colBuyCost.Width = 120;
            // 
            // colCurAmt
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N0";
            dataGridViewCellStyle19.NullValue = null;
            this.colCurAmt.DefaultCellStyle = dataGridViewCellStyle19;
            this.colCurAmt.HeaderText = "현재가";
            this.colCurAmt.Name = "colCurAmt";
            // 
            // col1
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col1.DefaultCellStyle = dataGridViewCellStyle20;
            this.col1.HeaderText = "매수비율(%)";
            this.col1.Name = "col1";
            this.col1.ToolTipText = "시가총액 대비 매수비율";
            this.col1.Width = 80;
            // 
            // col2
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N0";
            dataGridViewCellStyle21.NullValue = null;
            this.col2.DefaultCellStyle = dataGridViewCellStyle21;
            this.col2.HeaderText = "매수단가-4%";
            this.col2.Name = "col2";
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(728, 33);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 14;
            this.btnExcel.Text = "엑셀저장";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frm기관시총대비순매수ONL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 475);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCnt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.cmbDateType);
            this.Controls.Add(this.cmbMarketType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCybos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm기관시총대비순매수ONL";
            this.Text = "기관시총대비 순매수 Top100(ON-LINE)";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCybos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMarketType;
        private System.Windows.Forms.ComboBox cmbDateType;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuyStCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuyStName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuyCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuyAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPriceTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuyCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2;
        private System.Windows.Forms.Button btnExcel;
    }
}