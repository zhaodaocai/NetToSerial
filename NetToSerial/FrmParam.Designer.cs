namespace NetToSerial
{
    partial class FrmParam
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParam));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridServer = new System.Windows.Forms.DataGridView();
            this.TabParam = new System.Windows.Forms.TabControl();
            this.PageSerial = new System.Windows.Forms.TabPage();
            this.GridSerial = new System.Windows.Forms.DataGridView();
            this.MenuSerial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cOM1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOM2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBaud = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuParity = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.PageServer = new System.Windows.Forms.TabPage();
            this.PageClient = new System.Windows.Forms.TabPage();
            this.GridClient = new System.Windows.Forms.DataGridView();
            this.ClientSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ClientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColClientIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColClientPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageRelay = new System.Windows.Forms.TabPage();
            this.GridRelay = new System.Windows.Forms.DataGridView();
            this.RelaySelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WndEqual = new System.Windows.Forms.ToolStripButton();
            this.WndAdd = new System.Windows.Forms.ToolStripButton();
            this.WndDeleteRows = new System.Windows.Forms.ToolStripButton();
            this.WndAddRow = new System.Windows.Forms.ToolStripButton();
            this.WndOK = new System.Windows.Forms.ToolStripButton();
            this.WndCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.wndSave = new System.Windows.Forms.ToolStripButton();
            this.ColServerPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColServerIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColParity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBaud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerialPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridServer)).BeginInit();
            this.TabParam.SuspendLayout();
            this.PageSerial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridSerial)).BeginInit();
            this.MenuSerial.SuspendLayout();
            this.MenuBaud.SuspendLayout();
            this.MenuParity.SuspendLayout();
            this.PageServer.SuspendLayout();
            this.PageClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridClient)).BeginInit();
            this.PageRelay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRelay)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridServer
            // 
            this.GridServer.AllowUserToAddRows = false;
            this.GridServer.AllowUserToDeleteRows = false;
            this.GridServer.ColumnHeadersHeight = 40;
            this.GridServer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServerSelect,
            this.ServerID,
            this.ColServerIP,
            this.ColServerPort});
            this.GridServer.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GridServer.Location = new System.Drawing.Point(16, 17);
            this.GridServer.Margin = new System.Windows.Forms.Padding(4);
            this.GridServer.Name = "GridServer";
            this.GridServer.RowHeadersWidth = 80;
            this.GridServer.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GridServer.RowTemplate.Height = 30;
            this.GridServer.Size = new System.Drawing.Size(564, 207);
            this.GridServer.TabIndex = 1;
            this.GridServer.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.WndGrid_DataError);
            this.GridServer.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.GridServer_RowStateChanged);
            // 
            // TabParam
            // 
            this.TabParam.Controls.Add(this.PageSerial);
            this.TabParam.Controls.Add(this.PageServer);
            this.TabParam.Controls.Add(this.PageClient);
            this.TabParam.Controls.Add(this.PageRelay);
            this.TabParam.Location = new System.Drawing.Point(12, 67);
            this.TabParam.Name = "TabParam";
            this.TabParam.SelectedIndex = 0;
            this.TabParam.Size = new System.Drawing.Size(655, 339);
            this.TabParam.TabIndex = 12;
            // 
            // PageSerial
            // 
            this.PageSerial.Controls.Add(this.GridSerial);
            this.PageSerial.Location = new System.Drawing.Point(4, 26);
            this.PageSerial.Name = "PageSerial";
            this.PageSerial.Padding = new System.Windows.Forms.Padding(3);
            this.PageSerial.Size = new System.Drawing.Size(647, 309);
            this.PageSerial.TabIndex = 1;
            this.PageSerial.Text = "串口参数";
            this.PageSerial.UseVisualStyleBackColor = true;
            // 
            // GridSerial
            // 
            this.GridSerial.AllowUserToAddRows = false;
            this.GridSerial.AllowUserToDeleteRows = false;
            this.GridSerial.ColumnHeadersHeight = 40;
            this.GridSerial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialSelect,
            this.SerialID,
            this.ColSerialPort,
            this.ColBaud,
            this.ColParity});
            this.GridSerial.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GridSerial.Location = new System.Drawing.Point(7, 18);
            this.GridSerial.Margin = new System.Windows.Forms.Padding(4);
            this.GridSerial.Name = "GridSerial";
            this.GridSerial.RowHeadersWidth = 80;
            this.GridSerial.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GridSerial.RowTemplate.Height = 30;
            this.GridSerial.Size = new System.Drawing.Size(630, 208);
            this.GridSerial.TabIndex = 2;
            this.GridSerial.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridSerial_DataError);
            this.GridSerial.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.GridSerial_RowStateChanged);
            // 
            // MenuSerial
            // 
            this.MenuSerial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cOM1ToolStripMenuItem,
            this.cOM2ToolStripMenuItem});
            this.MenuSerial.Name = "MenuSerial";
            this.MenuSerial.Size = new System.Drawing.Size(114, 48);
            this.MenuSerial.Opening += new System.ComponentModel.CancelEventHandler(this.MenuSerial_Opening);
            this.MenuSerial.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuSerial_ItemClicked);
            // 
            // cOM1ToolStripMenuItem
            // 
            this.cOM1ToolStripMenuItem.Name = "cOM1ToolStripMenuItem";
            this.cOM1ToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.cOM1ToolStripMenuItem.Text = "COM1";
            // 
            // cOM2ToolStripMenuItem
            // 
            this.cOM2ToolStripMenuItem.Name = "cOM2ToolStripMenuItem";
            this.cOM2ToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.cOM2ToolStripMenuItem.Text = "COM2";
            // 
            // MenuBaud
            // 
            this.MenuBaud.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10});
            this.MenuBaud.Name = "MenuSerial";
            this.MenuBaud.Size = new System.Drawing.Size(119, 202);
            this.MenuBaud.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuBaud_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem1.Text = "300";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem2.Text = "600";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem4.Text = "1200";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem5.Text = "2400";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem6.Text = "4800";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem7.Text = "9600";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem8.Text = "38400";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem9.Text = "57600";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem10.Text = "115200";
            // 
            // MenuParity
            // 
            this.MenuParity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12});
            this.MenuParity.Name = "MenuSerial";
            this.MenuParity.Size = new System.Drawing.Size(123, 70);
            this.MenuParity.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuParity_ItemClicked);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem3.Tag = "0";
            this.toolStripMenuItem3.Text = "0:无校验";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem11.Tag = "1";
            this.toolStripMenuItem11.Text = "1:奇校验";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem12.Tag = "2";
            this.toolStripMenuItem12.Text = "2:偶校验";
            // 
            // PageServer
            // 
            this.PageServer.Controls.Add(this.GridServer);
            this.PageServer.Location = new System.Drawing.Point(4, 26);
            this.PageServer.Name = "PageServer";
            this.PageServer.Padding = new System.Windows.Forms.Padding(3);
            this.PageServer.Size = new System.Drawing.Size(647, 309);
            this.PageServer.TabIndex = 0;
            this.PageServer.Text = "网络服务端";
            this.PageServer.UseVisualStyleBackColor = true;
            // 
            // PageClient
            // 
            this.PageClient.Controls.Add(this.GridClient);
            this.PageClient.Location = new System.Drawing.Point(4, 26);
            this.PageClient.Name = "PageClient";
            this.PageClient.Padding = new System.Windows.Forms.Padding(3);
            this.PageClient.Size = new System.Drawing.Size(647, 309);
            this.PageClient.TabIndex = 2;
            this.PageClient.Text = "网络客户端";
            this.PageClient.UseVisualStyleBackColor = true;
            // 
            // GridClient
            // 
            this.GridClient.AllowUserToAddRows = false;
            this.GridClient.AllowUserToDeleteRows = false;
            this.GridClient.ColumnHeadersHeight = 40;
            this.GridClient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClientSelect,
            this.ClientID,
            this.ColClientIP,
            this.ColClientPort});
            this.GridClient.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GridClient.Location = new System.Drawing.Point(20, 32);
            this.GridClient.Margin = new System.Windows.Forms.Padding(4);
            this.GridClient.Name = "GridClient";
            this.GridClient.RowHeadersWidth = 80;
            this.GridClient.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GridClient.RowTemplate.Height = 30;
            this.GridClient.Size = new System.Drawing.Size(554, 204);
            this.GridClient.TabIndex = 2;
            this.GridClient.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridClient_DataError);
            this.GridClient.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.GridClient_RowStateChanged);
            // 
            // ClientSelect
            // 
            this.ClientSelect.DataPropertyName = "ClientSelect";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ClientSelect.DefaultCellStyle = dataGridViewCellStyle6;
            this.ClientSelect.HeaderText = "选择";
            this.ClientSelect.Name = "ClientSelect";
            // 
            // ClientID
            // 
            this.ClientID.DataPropertyName = "ClientID";
            this.ClientID.HeaderText = "客户端ID";
            this.ClientID.Name = "ClientID";
            // 
            // ColClientIP
            // 
            this.ColClientIP.DataPropertyName = "ColClientIP";
            this.ColClientIP.HeaderText = "IP地址";
            this.ColClientIP.MinimumWidth = 150;
            this.ColClientIP.Name = "ColClientIP";
            this.ColClientIP.Width = 150;
            // 
            // ColClientPort
            // 
            this.ColClientPort.DataPropertyName = "ColClientPort";
            this.ColClientPort.HeaderText = "网络端口";
            this.ColClientPort.MaxInputLength = 5;
            this.ColClientPort.Name = "ColClientPort";
            this.ColClientPort.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColClientPort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PageRelay
            // 
            this.PageRelay.Controls.Add(this.GridRelay);
            this.PageRelay.Location = new System.Drawing.Point(4, 26);
            this.PageRelay.Name = "PageRelay";
            this.PageRelay.Padding = new System.Windows.Forms.Padding(3);
            this.PageRelay.Size = new System.Drawing.Size(647, 309);
            this.PageRelay.TabIndex = 3;
            this.PageRelay.Text = "转发参数";
            this.PageRelay.UseVisualStyleBackColor = true;
            // 
            // GridRelay
            // 
            this.GridRelay.AllowUserToAddRows = false;
            this.GridRelay.AllowUserToDeleteRows = false;
            this.GridRelay.ColumnHeadersHeight = 40;
            this.GridRelay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RelaySelect,
            this.ID1,
            this.ID2});
            this.GridRelay.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GridRelay.Location = new System.Drawing.Point(24, 33);
            this.GridRelay.Margin = new System.Windows.Forms.Padding(4);
            this.GridRelay.Name = "GridRelay";
            this.GridRelay.RowHeadersWidth = 80;
            this.GridRelay.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GridRelay.RowTemplate.Height = 30;
            this.GridRelay.Size = new System.Drawing.Size(519, 204);
            this.GridRelay.TabIndex = 3;
            this.GridRelay.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridRelay_DataError);
            this.GridRelay.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.GridRelay_RowStateChanged);
            // 
            // RelaySelect
            // 
            this.RelaySelect.DataPropertyName = "RelaySelect";
            this.RelaySelect.HeaderText = "选择";
            this.RelaySelect.Name = "RelaySelect";
            // 
            // ID1
            // 
            this.ID1.DataPropertyName = "ID1";
            this.ID1.HeaderText = "ID1";
            this.ID1.Name = "ID1";
            // 
            // ID2
            // 
            this.ID2.DataPropertyName = "ID2";
            this.ID2.HeaderText = "ID2";
            this.ID2.MinimumWidth = 150;
            this.ID2.Name = "ID2";
            this.ID2.Width = 150;
            // 
            // WndEqual
            // 
            this.WndEqual.Image = ((System.Drawing.Image)(resources.GetObject("WndEqual.Image")));
            this.WndEqual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WndEqual.Name = "WndEqual";
            this.WndEqual.Size = new System.Drawing.Size(93, 24);
            this.WndEqual.Text = "以下相同";
            this.WndEqual.Click += new System.EventHandler(this.WndEqual_Click);
            // 
            // WndAdd
            // 
            this.WndAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WndAdd.Image = ((System.Drawing.Image)(resources.GetObject("WndAdd.Image")));
            this.WndAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WndAdd.Name = "WndAdd";
            this.WndAdd.Size = new System.Drawing.Size(93, 24);
            this.WndAdd.Text = "以下递增";
            this.WndAdd.Click += new System.EventHandler(this.WndAdd_Click);
            // 
            // WndDeleteRows
            // 
            this.WndDeleteRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WndDeleteRows.Image = ((System.Drawing.Image)(resources.GetObject("WndDeleteRows.Image")));
            this.WndDeleteRows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WndDeleteRows.Name = "WndDeleteRows";
            this.WndDeleteRows.Size = new System.Drawing.Size(77, 24);
            this.WndDeleteRows.Text = "删除行";
            this.WndDeleteRows.Click += new System.EventHandler(this.WndDeleteRows_Click);
            // 
            // WndAddRow
            // 
            this.WndAddRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WndAddRow.Image = ((System.Drawing.Image)(resources.GetObject("WndAddRow.Image")));
            this.WndAddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WndAddRow.Name = "WndAddRow";
            this.WndAddRow.Size = new System.Drawing.Size(77, 24);
            this.WndAddRow.Text = "增加行";
            this.WndAddRow.Click += new System.EventHandler(this.WndAddRow_Click);
            // 
            // WndOK
            // 
            this.WndOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WndOK.Image = ((System.Drawing.Image)(resources.GetObject("WndOK.Image")));
            this.WndOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WndOK.Name = "WndOK";
            this.WndOK.Size = new System.Drawing.Size(61, 24);
            this.WndOK.Text = "确定";
            this.WndOK.Click += new System.EventHandler(this.WndOK_Click);
            // 
            // WndCancel
            // 
            this.WndCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WndCancel.Image = ((System.Drawing.Image)(resources.GetObject("WndCancel.Image")));
            this.WndCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WndCancel.Name = "WndCancel";
            this.WndCancel.Size = new System.Drawing.Size(61, 24);
            this.WndCancel.Text = "取消";
            this.WndCancel.Click += new System.EventHandler(this.WndCancel_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WndEqual,
            this.WndAdd,
            this.WndDeleteRows,
            this.WndAddRow,
            this.wndSave,
            this.WndOK,
            this.WndCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(669, 27);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // wndSave
            // 
            this.wndSave.Image = ((System.Drawing.Image)(resources.GetObject("wndSave.Image")));
            this.wndSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wndSave.Name = "wndSave";
            this.wndSave.Size = new System.Drawing.Size(61, 24);
            this.wndSave.Text = "保存";
            this.wndSave.Click += new System.EventHandler(this.wndSave_Click);
            // 
            // ColServerPort
            // 
            this.ColServerPort.DataPropertyName = "ColServerPort";
            this.ColServerPort.HeaderText = "网络端口";
            this.ColServerPort.MaxInputLength = 5;
            this.ColServerPort.Name = "ColServerPort";
            this.ColServerPort.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColServerPort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColServerIP
            // 
            this.ColServerIP.DataPropertyName = "ColServerIP";
            this.ColServerIP.HeaderText = "IP地址";
            this.ColServerIP.MinimumWidth = 150;
            this.ColServerIP.Name = "ColServerIP";
            this.ColServerIP.Width = 150;
            // 
            // ServerID
            // 
            this.ServerID.DataPropertyName = "ServerID";
            this.ServerID.HeaderText = "服务端ID";
            this.ServerID.Name = "ServerID";
            // 
            // ServerSelect
            // 
            this.ServerSelect.DataPropertyName = "ServerSelect";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ServerSelect.DefaultCellStyle = dataGridViewCellStyle1;
            this.ServerSelect.HeaderText = "选择";
            this.ServerSelect.Name = "ServerSelect";
            // 
            // ColParity
            // 
            this.ColParity.ContextMenuStrip = this.MenuParity;
            this.ColParity.DataPropertyName = "ColParity";
            dataGridViewCellStyle5.NullValue = "0";
            this.ColParity.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColParity.HeaderText = "校验方式";
            this.ColParity.MaxInputLength = 1;
            this.ColParity.Name = "ColParity";
            this.ColParity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColParity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColBaud
            // 
            this.ColBaud.ContextMenuStrip = this.MenuBaud;
            this.ColBaud.DataPropertyName = "ColBaud";
            dataGridViewCellStyle4.NullValue = "0";
            this.ColBaud.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColBaud.HeaderText = "波特率";
            this.ColBaud.MaxInputLength = 6;
            this.ColBaud.Name = "ColBaud";
            this.ColBaud.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColBaud.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColSerialPort
            // 
            this.ColSerialPort.ContextMenuStrip = this.MenuSerial;
            this.ColSerialPort.DataPropertyName = "ColSerialPort";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.ColSerialPort.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColSerialPort.HeaderText = "串行端口";
            this.ColSerialPort.MaxInputLength = 3;
            this.ColSerialPort.Name = "ColSerialPort";
            this.ColSerialPort.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSerialPort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SerialID
            // 
            this.SerialID.DataPropertyName = "SerialID";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.SerialID.DefaultCellStyle = dataGridViewCellStyle2;
            this.SerialID.HeaderText = "串口ID";
            this.SerialID.MaxInputLength = 6;
            this.SerialID.Name = "SerialID";
            this.SerialID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SerialSelect
            // 
            this.SerialSelect.DataPropertyName = "SerialSelect";
            this.SerialSelect.HeaderText = "选择";
            this.SerialSelect.Name = "SerialSelect";
            this.SerialSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FrmParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 475);
            this.Controls.Add(this.TabParam);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数";
            this.Load += new System.EventHandler(this.FrmParam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridServer)).EndInit();
            this.TabParam.ResumeLayout(false);
            this.PageSerial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridSerial)).EndInit();
            this.MenuSerial.ResumeLayout(false);
            this.MenuBaud.ResumeLayout(false);
            this.MenuParity.ResumeLayout(false);
            this.PageServer.ResumeLayout(false);
            this.PageClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridClient)).EndInit();
            this.PageRelay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridRelay)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridServer;
        private System.Windows.Forms.TabControl TabParam;
        private System.Windows.Forms.TabPage PageServer;
        private System.Windows.Forms.TabPage PageSerial;
        private System.Windows.Forms.DataGridView GridSerial;
        private System.Windows.Forms.TabPage PageClient;
        private System.Windows.Forms.DataGridView GridClient;
        private System.Windows.Forms.ToolStripButton WndEqual;
        private System.Windows.Forms.ToolStripButton WndAdd;
        private System.Windows.Forms.ToolStripButton WndDeleteRows;
        private System.Windows.Forms.ToolStripButton WndAddRow;
        private System.Windows.Forms.ToolStripButton WndOK;
        private System.Windows.Forms.ToolStripButton WndCancel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ContextMenuStrip MenuSerial;
        private System.Windows.Forms.ToolStripMenuItem cOM1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOM2ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MenuBaud;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ContextMenuStrip MenuParity;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.TabPage PageRelay;
        private System.Windows.Forms.DataGridView GridRelay;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ClientSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColClientIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColClientPort;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RelaySelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID2;
        private System.Windows.Forms.ToolStripButton wndSave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ServerSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServerIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColServerPort;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SerialSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerialPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBaud;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColParity;
    }
}