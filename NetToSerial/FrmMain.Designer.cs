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
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 379);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1074, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // WndInfo
            // 
            this.WndInfo.Font = new System.Drawing.Font("宋体", 12F);
            this.WndInfo.Location = new System.Drawing.Point(12, 46);
            this.WndInfo.Name = "WndInfo";
            this.WndInfo.Size = new System.Drawing.Size(549, 269);
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
            this.toolStrip1.Size = new System.Drawing.Size(1074, 27);
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
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 401);
            this.Controls.Add(this.WndInfo);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmMain";
            this.Text = "网络与串口转发";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
    }
}

