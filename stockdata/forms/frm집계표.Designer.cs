namespace stockdata.forms
{
    partial class frm집계표
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
            this.label1 = new System.Windows.Forms.Label();
            this.radioBtn기관 = new System.Windows.Forms.RadioButton();
            this.radioBtn외인 = new System.Windows.Forms.RadioButton();
            this.radioBtn외인기관 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStockCodes = new System.Windows.Forms.TextBox();
            this.btnStcodeSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "자료종류";
            // 
            // radioBtn기관
            // 
            this.radioBtn기관.AutoSize = true;
            this.radioBtn기관.Location = new System.Drawing.Point(78, 20);
            this.radioBtn기관.Name = "radioBtn기관";
            this.radioBtn기관.Size = new System.Drawing.Size(107, 16);
            this.radioBtn기관.TabIndex = 1;
            this.radioBtn기관.TabStop = true;
            this.radioBtn기관.Text = "기관잠정치매매";
            this.radioBtn기관.UseVisualStyleBackColor = true;
            // 
            // radioBtn외인
            // 
            this.radioBtn외인.AutoSize = true;
            this.radioBtn외인.Location = new System.Drawing.Point(78, 42);
            this.radioBtn외인.Name = "radioBtn외인";
            this.radioBtn외인.Size = new System.Drawing.Size(107, 16);
            this.radioBtn외인.TabIndex = 2;
            this.radioBtn외인.TabStop = true;
            this.radioBtn외인.Text = "외인잠정치매매";
            this.radioBtn외인.UseVisualStyleBackColor = true;
            // 
            // radioBtn외인기관
            // 
            this.radioBtn외인기관.AutoSize = true;
            this.radioBtn외인기관.Location = new System.Drawing.Point(78, 64);
            this.radioBtn외인기관.Name = "radioBtn외인기관";
            this.radioBtn외인기관.Size = new System.Drawing.Size(167, 16);
            this.radioBtn외인기관.TabIndex = 3;
            this.radioBtn외인기관.TabStop = true;
            this.radioBtn외인기관.Text = "외인기관쌍끌이잠정치매매";
            this.radioBtn외인기관.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "자료일자";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(71, 91);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(231, 21);
            this.datePicker.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(14, 150);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(207, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(227, 150);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "종목코드";
            // 
            // txtStockCodes
            // 
            this.txtStockCodes.Location = new System.Drawing.Point(71, 120);
            this.txtStockCodes.Name = "txtStockCodes";
            this.txtStockCodes.Size = new System.Drawing.Size(150, 21);
            this.txtStockCodes.TabIndex = 9;
            // 
            // btnStcodeSearch
            // 
            this.btnStcodeSearch.Location = new System.Drawing.Point(227, 121);
            this.btnStcodeSearch.Name = "btnStcodeSearch";
            this.btnStcodeSearch.Size = new System.Drawing.Size(75, 23);
            this.btnStcodeSearch.TabIndex = 10;
            this.btnStcodeSearch.Text = "종목검색";
            this.btnStcodeSearch.UseVisualStyleBackColor = true;
            this.btnStcodeSearch.Click += new System.EventHandler(this.btnStcodeSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 180);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(810, 325);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // frm집계표
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(837, 517);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnStcodeSearch);
            this.Controls.Add(this.txtStockCodes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioBtn외인기관);
            this.Controls.Add(this.radioBtn외인);
            this.Controls.Add(this.radioBtn기관);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(330, 300);
            this.Name = "frm집계표";
            this.Text = "외인기관집계표";
            this.Resize += new System.EventHandler(this.frm집계표_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioBtn기관;
        private System.Windows.Forms.RadioButton radioBtn외인;
        private System.Windows.Forms.RadioButton radioBtn외인기관;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStockCodes;
        private System.Windows.Forms.Button btnStcodeSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}