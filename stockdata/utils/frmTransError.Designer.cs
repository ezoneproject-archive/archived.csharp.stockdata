namespace stockdata.utils
{
    partial class frmTransError
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
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRespCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRespMesg = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRequestId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRequestPath = new System.Windows.Forms.TextBox();
            this.txtRequestMethod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClientAddr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtErrorInfoType = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtErrorInfoMessage = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(363, 366);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "전송 중 오류가 발생했습니다.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "응답코드";
            // 
            // txtRespCode
            // 
            this.txtRespCode.Location = new System.Drawing.Point(22, 58);
            this.txtRespCode.Name = "txtRespCode";
            this.txtRespCode.ReadOnly = true;
            this.txtRespCode.Size = new System.Drawing.Size(67, 21);
            this.txtRespCode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "응답메시지";
            // 
            // txtRespMesg
            // 
            this.txtRespMesg.Location = new System.Drawing.Point(95, 58);
            this.txtRespMesg.Multiline = true;
            this.txtRespMesg.Name = "txtRespMesg";
            this.txtRespMesg.ReadOnly = true;
            this.txtRespMesg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRespMesg.Size = new System.Drawing.Size(340, 47);
            this.txtRespMesg.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRequestId);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtRequestPath);
            this.groupBox1.Controls.Add(this.txtRequestMethod);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtClientAddr);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtServerName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(14, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 164);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Metadata";
            // 
            // txtRequestId
            // 
            this.txtRequestId.Location = new System.Drawing.Point(81, 130);
            this.txtRequestId.Name = "txtRequestId";
            this.txtRequestId.ReadOnly = true;
            this.txtRequestId.Size = new System.Drawing.Size(326, 21);
            this.txtRequestId.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "Ticket ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "요청경로";
            // 
            // txtRequestPath
            // 
            this.txtRequestPath.Location = new System.Drawing.Point(81, 102);
            this.txtRequestPath.Name = "txtRequestPath";
            this.txtRequestPath.ReadOnly = true;
            this.txtRequestPath.Size = new System.Drawing.Size(326, 21);
            this.txtRequestPath.TabIndex = 22;
            // 
            // txtRequestMethod
            // 
            this.txtRequestMethod.Location = new System.Drawing.Point(81, 75);
            this.txtRequestMethod.Name = "txtRequestMethod";
            this.txtRequestMethod.ReadOnly = true;
            this.txtRequestMethod.Size = new System.Drawing.Size(100, 21);
            this.txtRequestMethod.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "요청방법";
            // 
            // txtClientAddr
            // 
            this.txtClientAddr.Location = new System.Drawing.Point(81, 47);
            this.txtClientAddr.Name = "txtClientAddr";
            this.txtClientAddr.ReadOnly = true;
            this.txtClientAddr.Size = new System.Drawing.Size(326, 21);
            this.txtClientAddr.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "클라이언트";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(81, 20);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.ReadOnly = true;
            this.txtServerName.Size = new System.Drawing.Size(326, 21);
            this.txtServerName.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "요청서버";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "서비스구분";
            // 
            // txtErrorInfoType
            // 
            this.txtErrorInfoType.Location = new System.Drawing.Point(22, 306);
            this.txtErrorInfoType.Name = "txtErrorInfoType";
            this.txtErrorInfoType.ReadOnly = true;
            this.txtErrorInfoType.Size = new System.Drawing.Size(67, 21);
            this.txtErrorInfoType.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(98, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "서비스 메시지";
            // 
            // txtErrorInfoMessage
            // 
            this.txtErrorInfoMessage.Location = new System.Drawing.Point(95, 306);
            this.txtErrorInfoMessage.Multiline = true;
            this.txtErrorInfoMessage.Name = "txtErrorInfoMessage";
            this.txtErrorInfoMessage.ReadOnly = true;
            this.txtErrorInfoMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrorInfoMessage.Size = new System.Drawing.Size(340, 50);
            this.txtErrorInfoMessage.TabIndex = 29;
            // 
            // frmTransError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(450, 401);
            this.Controls.Add(this.txtErrorInfoMessage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtErrorInfoType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRespMesg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRespCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmTransError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRespCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRespMesg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRequestId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRequestPath;
        private System.Windows.Forms.TextBox txtRequestMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClientAddr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtErrorInfoType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtErrorInfoMessage;
    }
}