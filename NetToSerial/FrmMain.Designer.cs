namespace NetToSerial
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.WndInfo = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.WndParam = new System.Windows.Forms.ToolStripButton();
            this.WndStart = new System.Windows.Forms.ToolStripButton();
            this.WndStop = new System.Windows.Forms.ToolStripButton();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerChild = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.wndClear = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.wndSend = new System.Windows.Forms.ToolStripButton();
            this.treeViewConnect = new System.Windows.Forms.TreeView();
            this.wndSendData = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerChild)).BeginInit();
            this.splitContainerChild.Panel1.SuspendLayout();
            this.splitContainerChild.Panel2.SuspendLayout();
            this.splitContainerChild.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(745, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // WndInfo
            // 
            this.WndInfo.Font = new System.Drawing.Font("宋体", 12F);
            this.WndInfo.Location = new System.Drawing.Point(13, 48);
            this.WndInfo.Name = "WndInfo";
            this.WndInfo.Size = new System.Drawing.Size(180, 98);
            this.WndInfo.TabIndex = 8;
            this.WndInfo.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WndParam,
            this.WndStart,
            this.WndStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(745, 27);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // WndParam
            // 
            this.WndParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.WndParam.Image = ((System.Drawing.Image)(resources.GetObject("WndParam.Image")));
            this.WndParam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WndParam.Name = "WndParam";
            this.WndParam.Size = new System.Drawing.Size(93, 24);
            this.WndParam.Text = "通信参数";
            this.WndParam.Click += new System.EventHandler(this.wndParam_Click);
            // 
            // WndStart
            // 
            this.WndStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.WndStart.Image = ((System.Drawing.Image)(resources.GetObject("WndStart.Image")));
            this.WndStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WndStart.Name = "WndStart";
            this.WndStart.Size = new System.Drawing.Size(61, 24);
            this.WndStart.Text = "启动";
            this.WndStart.Click += new System.EventHandler(this.wndStart_Click);
            // 
            // WndStop
            // 
            this.WndStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.WndStop.Image = ((System.Drawing.Image)(resources.GetObject("WndStop.Image")));
            this.WndStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WndStop.Name = "WndStop";
            this.WndStop.Size = new System.Drawing.Size(61, 24);
            this.WndStop.Text = "停止";
            this.WndStop.Click += new System.EventHandler(this.wndStop_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Location = new System.Drawing.Point(21, 52);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.treeViewConnect);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerChild);
            this.splitContainerMain.Size = new System.Drawing.Size(501, 287);
            this.splitContainerMain.SplitterDistance = 167;
            this.splitContainerMain.TabIndex = 11;
            // 
            // splitContainerChild
            // 
            this.splitContainerChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerChild.Location = new System.Drawing.Point(0, 0);
            this.splitContainerChild.Name = "splitContainerChild";
            this.splitContainerChild.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerChild.Panel1
            // 
            this.splitContainerChild.Panel1.Controls.Add(this.wndSendData);
            this.splitContainerChild.Panel1.Controls.Add(this.toolStrip3);
            // 
            // splitContainerChild.Panel2
            // 
            this.splitContainerChild.Panel2.Controls.Add(this.WndInfo);
            this.splitContainerChild.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerChild.Size = new System.Drawing.Size(330, 287);
            this.splitContainerChild.SplitterDistance = 90;
            this.splitContainerChild.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wndClear});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(330, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // wndClear
            // 
            this.wndClear.Image = ((System.Drawing.Image)(resources.GetObject("wndClear.Image")));
            this.wndClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wndClear.Name = "wndClear";
            this.wndClear.Size = new System.Drawing.Size(52, 22);
            this.wndClear.Text = "清空";
            this.wndClear.Click += new System.EventHandler(this.wndClear_Click_1);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wndSend});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(330, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // wndSend
            // 
            this.wndSend.Image = ((System.Drawing.Image)(resources.GetObject("wndSend.Image")));
            this.wndSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wndSend.Name = "wndSend";
            this.wndSend.Size = new System.Drawing.Size(52, 22);
            this.wndSend.Text = "发送";
            // 
            // treeViewConnect
            // 
            this.treeViewConnect.Location = new System.Drawing.Point(16, 28);
            this.treeViewConnect.Name = "treeViewConnect";
            this.treeViewConnect.Size = new System.Drawing.Size(101, 86);
            this.treeViewConnect.TabIndex = 0;
            // 
            // wndSendData
            // 
            this.wndSendData.Location = new System.Drawing.Point(13, 28);
            this.wndSendData.Name = "wndSendData";
            this.wndSendData.Size = new System.Drawing.Size(216, 37);
            this.wndSendData.TabIndex = 1;
            this.wndSendData.Text = "";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 423);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmMain";
            this.Text = "网络与串口转发";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerChild.Panel1.ResumeLayout(false);
            this.splitContainerChild.Panel1.PerformLayout();
            this.splitContainerChild.Panel2.ResumeLayout(false);
            this.splitContainerChild.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerChild)).EndInit();
            this.splitContainerChild.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RichTextBox WndInfo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton WndStart;
        private System.Windows.Forms.ToolStripButton WndStop;
        private System.Windows.Forms.ToolStripButton WndParam;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerChild;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton wndSend;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton wndClear;
        private System.Windows.Forms.TreeView treeViewConnect;
        private System.Windows.Forms.RichTextBox wndSendData;
    }
}

