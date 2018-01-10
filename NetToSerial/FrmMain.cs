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

            WndInfo.Dock = DockStyle.Fill;


        }

        private void wndSave_Click(object sender, EventArgs e)
        {

        }

        private void wndStart_Click(object sender, EventArgs e)
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
                foreach(DataRow dr in tableSerial.Rows)
                {
                    SerialRow sr = new SerialRow(dr);
                    if (sr.select)
                    {
                        SerialPort sp = new SerialPort("COM" + sr.port, sr.baud, (Parity)sr.parity);
                        IoSerial serial = new IoSerial(RelayServer.GetID(), sp, this);
                        
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
                        IoServer server = new IoServer(RelayServer.GetID(), sr.ip, sr.port, this);
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
                        IoClient client = new IoClient(RelayServer.GetID(), sr.ip, sr.port, this);
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
            Log.Info(Color.Black, "SessionClosed:" + header.ToString());
            System.Diagnostics.Debug.WriteLine("SessionClosed:" + header.ToString());
        }

        public void SessionOpened(IoHeader header)
        {
            Log.Info(Color.Black, "SessionOpened:"+header.ToString());
            System.Diagnostics.Debug.WriteLine("SessionOpened:" + header.ToString());
        }

        public void ConnectOpened(IoState state)
        {
            Log.Info(Color.Black, "ConnectOpened:"+state.ToString());
            System.Diagnostics.Debug.WriteLine("ConnectOpened:" + state.ToString());
        }

        public void ConnectClosed(IoState state)
        {
            Log.Info(Color.Black, "ConnectClosed:" + state.ToString());
            System.Diagnostics.Debug.WriteLine("ConnectClosed:" + state.ToString());
        }

        public void MessageReceived(IoState state, byte[] message)
        {
            Log.Info(Color.Black, "RX:" + STR.toString(message));
            System.Diagnostics.Debug.WriteLine("MessageReceived:" + state.ToString());
        }

        public void MessageSent(IoState state, byte[] message)
        {
            Log.Info(Color.Blue,"TX:" + STR.toString(message));

            System.Diagnostics.Debug.WriteLine("MessageSent:"+state.ToString());
        }

        public void SessionException(Object o, Exception ex)
        {
            Log.Info(Color.Red, "异常信息;" + ex.Message);
            System.Diagnostics.Debug.WriteLine("SessionException:" + ex.Message+","+o.ToString());
        }

        public void Start()
        {
            throw new NotImplementedException();
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
    }
}
