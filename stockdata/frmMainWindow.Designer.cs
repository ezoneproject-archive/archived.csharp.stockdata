namespace stockdata
{
    partial class frmMainWindow
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsOpen_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkNewVersion_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataManage_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerFile_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewServerData_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.view_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invfgnRpt_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stDiffRpt_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataManage_ToolStripMenuItem,
            this.view_ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsOpen_ToolStripMenuItem,
            this.checkNewVersion_ToolStripMenuItem,
            this.exit_ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsOpen_ToolStripMenuItem
            // 
            this.settingsOpen_ToolStripMenuItem.Name = "settingsOpen_ToolStripMenuItem";
            this.settingsOpen_ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.settingsOpen_ToolStripMenuItem.Text = "설정";
            this.settingsOpen_ToolStripMenuItem.Click += new System.EventHandler(this.settingsOpen_ToolStripMenuItem_Click);
            // 
            // checkNewVersion_ToolStripMenuItem
            // 
            this.checkNewVersion_ToolStripMenuItem.Name = "checkNewVersion_ToolStripMenuItem";
            this.checkNewVersion_ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.checkNewVersion_ToolStripMenuItem.Text = "새 버전 체크";
            this.checkNewVersion_ToolStripMenuItem.Click += new System.EventHandler(this.checkNewVersion_ToolStripMenuItem_Click);
            // 
            // exit_ToolStripMenuItem
            // 
            this.exit_ToolStripMenuItem.Name = "exit_ToolStripMenuItem";
            this.exit_ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exit_ToolStripMenuItem.Text = "종료";
            this.exit_ToolStripMenuItem.Click += new System.EventHandler(this.exit_ToolStripMenuItem_Click);
            // 
            // dataManage_ToolStripMenuItem
            // 
            this.dataManage_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerFile_ToolStripMenuItem,
            this.viewServerData_ToolStripMenuItem});
            this.dataManage_ToolStripMenuItem.Name = "dataManage_ToolStripMenuItem";
            this.dataManage_ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.dataManage_ToolStripMenuItem.Text = "자료관리";
            // 
            // registerFile_ToolStripMenuItem
            // 
            this.registerFile_ToolStripMenuItem.Name = "registerFile_ToolStripMenuItem";
            this.registerFile_ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.registerFile_ToolStripMenuItem.Text = "자료등록";
            this.registerFile_ToolStripMenuItem.Click += new System.EventHandler(this.registerFile_ToolStripMenuItem_Click);
            // 
            // viewServerData_ToolStripMenuItem
            // 
            this.viewServerData_ToolStripMenuItem.Name = "viewServerData_ToolStripMenuItem";
            this.viewServerData_ToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.viewServerData_ToolStripMenuItem.Text = "자료조회/삭제";
            this.viewServerData_ToolStripMenuItem.Click += new System.EventHandler(this.viewServerData_ToolStripMenuItem_Click);
            // 
            // view_ToolStripMenuItem
            // 
            this.view_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invfgnRpt_ToolStripMenuItem,
            this.stDiffRpt_ToolStripMenuItem});
            this.view_ToolStripMenuItem.Name = "view_ToolStripMenuItem";
            this.view_ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.view_ToolStripMenuItem.Text = "조회";
            // 
            // invfgnRpt_ToolStripMenuItem
            // 
            this.invfgnRpt_ToolStripMenuItem.Name = "invfgnRpt_ToolStripMenuItem";
            this.invfgnRpt_ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.invfgnRpt_ToolStripMenuItem.Text = "외인기관 집계표";
            this.invfgnRpt_ToolStripMenuItem.Click += new System.EventHandler(this.invfgnRpt_ToolStripMenuItem_Click);
            // 
            // stDiffRpt_ToolStripMenuItem
            // 
            this.stDiffRpt_ToolStripMenuItem.Name = "stDiffRpt_ToolStripMenuItem";
            this.stDiffRpt_ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.stDiffRpt_ToolStripMenuItem.Text = "종목변동현황";
            // 
            // frmMainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainWindow";
            this.Text = "종목데이터분석기";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainWindow_FormClosed);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exit_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkNewVersion_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataManage_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsOpen_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewServerData_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerFile_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem view_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invfgnRpt_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stDiffRpt_ToolStripMenuItem;
    }
}

