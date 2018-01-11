using com;
using NetToSerial.com;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetToSerial
{
    public partial class FrmMain : Form, IoHeader
    {

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Log.Init(WndInfo);
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerChild.Dock = DockStyle.Fill;
            wndSendData.Dock = DockStyle.Fill;
            treeViewConnect.Dock = DockStyle.Fill;
            WndInfo.Dock = DockStyle.Fill;
        }

        private void wndSave_Click(object sender, EventArgs e)
        {

        }

        private void wndStart_Click(object sender, EventArgs e)
        {
            try
            {
                Start();
            }
            catch(Exception ex)
            {
                Log.Err(ex.ToString());
            }
           
        }

        private void wndStop_Click(object sender, EventArgs e)
        {
            RelayServer.GetInstance().Stop();
        }

        private void wndClear_Click(object sender, EventArgs e)
        {
            WndInfo.Text = "";
        }

        private void wndParam_Click(object sender, EventArgs e)
        {
            FrmParam frm = new FrmParam();
            frm.ShowDialog();
        }

        public void SessionClosed(IoHeader header)
        {
            Log.Out("SessionClosed:" + header.ToString());

            String key = "K" + header.GetID();
            treeViewConnect.Nodes.RemoveByKey(key);
        }

        public void SessionOpened(IoHeader header)
        {
            Log.Out("SessionOpened:"+header.ToString());

            String key="K"+header.GetID();
            TreeNode node=treeViewConnect.Nodes[key];
            if (key == null)
            {
                TreeNode item=treeViewConnect.Nodes.Add(key, header.ToString());
                item.Tag = header.GetID();
            }
        }

        public void ConnectOpened(IoState state)
        {
            Log.Out("ConnectOpened:" +state.ToString());
        }

        public void ConnectClosed(IoState state)
        {
            Log.Out("ConnectClosed:" + state.ToString());
        }

        public void MessageReceived(IoState state, byte[] message)
        {
            Log.Info(Color.Black, "RX:" + state.ToString()+","+ STR.toString(message));
            int id=state.GetHeaderID();
            RelayServer.GetInstance().WriteData(id, message);
        }

        public void MessageSent(IoState state, byte[] message)
        {
            Log.Info(Color.Blue,"TX:" + state.ToString() + "," + STR.toString(message));

            System.Diagnostics.Debug.WriteLine("MessageSent:"+state.ToString());
        }

        public void SessionException(Object o, Exception ex)
        {
            Log.Err("异常信息;" + ex.Message+","+ex.ToString());
            System.Diagnostics.Debug.WriteLine("SessionException:" + ex.Message+","+o.ToString());
        }

        public void Start()
        {
            //表集合
            DataSet ds = FrmParam.ReadDataSet();

            //串口
            DataTable tableSerial = ds.Tables[FrmParam.s_GridSerial];
            DataTable tableServer = ds.Tables[FrmParam.s_GridServer];
            DataTable tableClient = ds.Tables[FrmParam.s_GridClient];
            DataTable tableRelay = ds.Tables[FrmParam.s_GridRelay];
            if (tableSerial != null)
            {
                foreach (DataRow dr in tableSerial.Rows)
                {
                    SerialRow sr = new SerialRow(dr);
                    if (sr.select)
                    {
                        SerialPort sp = new SerialPort("COM" + sr.port, sr.baud, (Parity)sr.parity);
                        IoSerial serial = new IoSerial(sr.id, sp, this);

                        RelayServer.GetInstance().AddHeader(serial);
                    }
                }
            }

            if (tableServer != null)
            {
                foreach (DataRow dr in tableServer.Rows)
                {
                    ServerRow sr = new ServerRow(dr);
                    if (sr.select)
                    {
                        IoServer server = new IoServer(sr.id, sr.ip, sr.port, this);
                        RelayServer.GetInstance().AddHeader(server);
                    }
                }
            }

            if (tableClient != null)
            {
                foreach (DataRow dr in tableClient.Rows)
                {
                    ClientRow sr = new ClientRow(dr);
                    if (sr.select)
                    {
                        IoClient client = new IoClient(sr.id, sr.ip, sr.port, this);
                        RelayServer.GetInstance().AddHeader(client);
                    }
                }
            }

            if (tableRelay != null)
            {
                foreach (DataRow dr in tableRelay.Rows)
                {
                    RelayRow sr = new RelayRow(dr);
                    if (sr.select)
                    {
                        RelayServer.GetInstance().AddRelay(sr.id1, sr.id2);
                    }
                }
            }

            RelayServer.GetInstance().Start();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void SetReadBuffer(int size)
        {
            throw new NotImplementedException();
        }

        public int GetID()
        {
            throw new NotImplementedException();
        }

        public void WriteData(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        private void wndClear_Click_1(object sender, EventArgs e)
        {
            WndInfo.Clear();
        }
    }
}
