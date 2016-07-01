namespace stockdata
{
    partial class frmViewData
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
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.listDataTimes = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listDataTypes = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.txtDataInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(72, 5);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(267, 21);
            this.datePicker.TabIndex = 1;
            // 
            // listDataTimes
            // 
            this.listDataTimes.FormattingEnabled = true;
            this.listDataTimes.ItemHeight = 12;
            this.listDataTimes.Location = new System.Drawing.Point(71, 177);
            this.listDataTimes.Name = "listDataTimes";
            this.listDataTimes.Size = new System.Drawing.Size(267, 112);
            this.listDataTimes.TabIndex = 16;
            this.listDataTimes.SelectedIndexChanged += new System.EventHandler(this.listDataTimes_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "자료일자";
            // 
            // listDataTypes
            // 
            this.listDataTypes.FormattingEnabled = true;
            this.listDataTypes.ItemHeight = 12;
            this.listDataTypes.Location = new System.Drawing.Point(72, 35);
            this.listDataTypes.Name = "listDataTypes";
            this.listDataTypes.Size = new System.Drawing.Size(267, 136);
            this.listDataTypes.TabIndex = 3;
            this.listDataTypes.SelectedIndexChanged += new System.EventHandler(this.listDataTypes_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "자료시간";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "종류";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(344, 236);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(425, 236);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(506, 236);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // listView
            // 
            this.listView.AllowColumnReorder = true;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(14, 295);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(567, 272);
            this.listView.TabIndex = 7;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // txtDataInfo
            // 
            this.txtDataInfo.Location = new System.Drawing.Point(344, 268);
            this.txtDataInfo.Name = "txtDataInfo";
            this.txtDataInfo.ReadOnly = true;
            this.txtDataInfo.Size = new System.Drawing.Size(237, 21);
            this.txtDataInfo.TabIndex = 17;
            this.txtDataInfo.TabStop = false;
            // 
            // frmViewData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 579);
            this.Controls.Add(this.txtDataInfo);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.listDataTimes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listDataTypes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "frmViewData";
            this.Text = "자료관리";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ListBox listDataTimes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listDataTypes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TextBox txtDataInfo;
    }
}