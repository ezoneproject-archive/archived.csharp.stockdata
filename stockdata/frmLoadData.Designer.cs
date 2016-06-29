namespace stockdata
{
    partial class frmLoadData
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
            this.txtFilePathName = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNewDesign = new System.Windows.Forms.Button();
            this.listDataTypes = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listDataTimes = new System.Windows.Forms.ListBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.listParseView = new System.Windows.Forms.ListView();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "파일";
            // 
            // txtFilePathName
            // 
            this.txtFilePathName.Location = new System.Drawing.Point(72, 6);
            this.txtFilePathName.Name = "txtFilePathName";
            this.txtFilePathName.Size = new System.Drawing.Size(267, 21);
            this.txtFilePathName.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(345, 5);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(85, 23);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "찾아보기...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(72, 34);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(267, 21);
            this.txtFileName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "파일명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "종류";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "자료시간";
            // 
            // btnNewDesign
            // 
            this.btnNewDesign.Location = new System.Drawing.Point(345, 174);
            this.btnNewDesign.Name = "btnNewDesign";
            this.btnNewDesign.Size = new System.Drawing.Size(85, 23);
            this.btnNewDesign.TabIndex = 14;
            this.btnNewDesign.Text = "신규 ...";
            this.btnNewDesign.UseVisualStyleBackColor = true;
            this.btnNewDesign.Click += new System.EventHandler(this.btnNewDesign_Click);
            // 
            // listDataTypes
            // 
            this.listDataTypes.FormattingEnabled = true;
            this.listDataTypes.ItemHeight = 12;
            this.listDataTypes.Location = new System.Drawing.Point(72, 61);
            this.listDataTypes.Name = "listDataTypes";
            this.listDataTypes.Size = new System.Drawing.Size(267, 136);
            this.listDataTypes.TabIndex = 6;
            this.listDataTypes.SelectedIndexChanged += new System.EventHandler(this.listDataTypes_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "자료일자";
            // 
            // listDataTimes
            // 
            this.listDataTimes.FormattingEnabled = true;
            this.listDataTimes.ItemHeight = 12;
            this.listDataTimes.Location = new System.Drawing.Point(71, 230);
            this.listDataTimes.Name = "listDataTimes";
            this.listDataTimes.Size = new System.Drawing.Size(267, 112);
            this.listDataTimes.TabIndex = 10;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(72, 203);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(267, 21);
            this.datePicker.TabIndex = 8;
            // 
            // listParseView
            // 
            this.listParseView.FullRowSelect = true;
            this.listParseView.GridLines = true;
            this.listParseView.Location = new System.Drawing.Point(14, 348);
            this.listParseView.MultiSelect = false;
            this.listParseView.Name = "listParseView";
            this.listParseView.Size = new System.Drawing.Size(416, 114);
            this.listParseView.TabIndex = 11;
            this.listParseView.UseCompatibleStateImageBehavior = false;
            this.listParseView.View = System.Windows.Forms.View.Details;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(14, 487);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(335, 23);
            this.btnRegister.TabIndex = 12;
            this.btnRegister.Text = "등록";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(355, 487);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 465);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "범례: @:키항목, *:일치";
            // 
            // frmLoadData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(447, 520);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.listParseView);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.listDataTimes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listDataTypes);
            this.Controls.Add(this.btnNewDesign);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtFilePathName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLoadData";
            this.Text = "자료 입력";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePathName;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNewDesign;
        private System.Windows.Forms.ListBox listDataTypes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listDataTimes;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ListView listParseView;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
    }
}