namespace stockdata.forms.report
{
    partial class frm종목변동현황
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnStcodeSearch = new System.Windows.Forms.Button();
            this.txtStockCodes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.datePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.radioBtn거래이평 = new System.Windows.Forms.RadioButton();
            this.radioBtn강력 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.datePicker2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(810, 299);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnStcodeSearch
            // 
            this.btnStcodeSearch.Location = new System.Drawing.Point(225, 106);
            this.btnStcodeSearch.Name = "btnStcodeSearch";
            this.btnStcodeSearch.Size = new System.Drawing.Size(75, 23);
            this.btnStcodeSearch.TabIndex = 21;
            this.btnStcodeSearch.Text = "종목검색";
            this.btnStcodeSearch.UseVisualStyleBackColor = true;
            this.btnStcodeSearch.Click += new System.EventHandler(this.btnStcodeSearch_Click);
            // 
            // txtStockCodes
            // 
            this.txtStockCodes.Location = new System.Drawing.Point(69, 107);
            this.txtStockCodes.Name = "txtStockCodes";
            this.txtStockCodes.Size = new System.Drawing.Size(150, 21);
            this.txtStockCodes.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "종목코드";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(225, 137);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 137);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(207, 23);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // datePicker1
            // 
            this.datePicker1.Location = new System.Drawing.Point(69, 50);
            this.datePicker1.Name = "datePicker1";
            this.datePicker1.Size = new System.Drawing.Size(231, 21);
            this.datePicker1.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "자료일자";
            // 
            // radioBtn거래이평
            // 
            this.radioBtn거래이평.AutoSize = true;
            this.radioBtn거래이평.Location = new System.Drawing.Point(78, 28);
            this.radioBtn거래이평.Name = "radioBtn거래이평";
            this.radioBtn거래이평.Size = new System.Drawing.Size(83, 16);
            this.radioBtn거래이평.TabIndex = 14;
            this.radioBtn거래이평.TabStop = true;
            this.radioBtn거래이평.Text = "거래20이평";
            this.radioBtn거래이평.UseVisualStyleBackColor = true;
            // 
            // radioBtn강력
            // 
            this.radioBtn강력.AutoSize = true;
            this.radioBtn강력.Location = new System.Drawing.Point(78, 6);
            this.radioBtn강력.Name = "radioBtn강력";
            this.radioBtn강력.Size = new System.Drawing.Size(71, 16);
            this.radioBtn강력.TabIndex = 13;
            this.radioBtn강력.TabStop = true;
            this.radioBtn강력.Text = "강력출동";
            this.radioBtn강력.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "자료종류";
            // 
            // datePicker2
            // 
            this.datePicker2.Location = new System.Drawing.Point(69, 77);
            this.datePicker2.Name = "datePicker2";
            this.datePicker2.Size = new System.Drawing.Size(231, 21);
            this.datePicker2.TabIndex = 23;
            // 
            // frm종목변동현황
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 477);
            this.Controls.Add(this.datePicker2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnStcodeSearch);
            this.Controls.Add(this.txtStockCodes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.datePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioBtn거래이평);
            this.Controls.Add(this.radioBtn강력);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(330, 300);
            this.Name = "frm종목변동현황";
            this.Text = "종목변동현황";
            this.Resize += new System.EventHandler(this.frm종목변동현황_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnStcodeSearch;
        private System.Windows.Forms.TextBox txtStockCodes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker datePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioBtn거래이평;
        private System.Windows.Forms.RadioButton radioBtn강력;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePicker2;
    }
}