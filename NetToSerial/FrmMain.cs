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
        int mSendType=0;
        int mRecType=0;


        public delegate void InvokeDeleteNode(String key);
        public delegate void InvokeAddNode(TreeNode parent,TreeNode node);


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
            treeConnect.Dock = DockStyle.Fill;
            WndInfo.Dock = DockStyle.Fill;
            wndRecFormat.SelectedIndex = 0;
            wndSendFormat.SelectedIndex = 0;
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

        public void SessionClosed(int pid)
        {
            Log.Out("SessionClosed,PID:" + pid);
            String key = "K" + pid;
            treeConnect.BeginInvoke(new InvokeDeleteNode(DeleteNode),key);
        }

        public void DeleteNode(String key)
        {
            treeConnect.Nodes.RemoveByKey(key);
        }

        public void AddNode(TreeNode parent,TreeNode child)
        {
            if (parent == null)
            {
                treeConnect.Nodes.Add(child);
            }
            else
            {
                parent.Nodes.Add(child);
            }
        }


        public String GetNodeKey(int id)
        {
            return "K" + id;
        }

        public void SessionOpened(IoHeader header)
        {
            Log.Out("SessionOpened,"+header.ToString());
            int pid = header.GetPID();
            String key = GetNodeKey(pid);
            TreeNode node=treeConnect.Nodes[key];
            if (node == null)
            {
                node = treeConnect.Nodes.Add(key, header.ToString());
                node.Tag = pid;
            }

        }

        public void ConnectOpened(IoState state)
        {
            Log.Out("ConnectOpened,"+ state.ToString());
            int pid = state.GetPID();
            int sid = state.GetSID();
            TreeNode pnode, snode;
            pnode =treeConnect.Nodes[ GetNodeKey(pid)];
            if (pnode != null)
            {
                String skey = GetNodeKey(sid);
                snode = new TreeNode();
                snode.Name = skey;
                snode.Text = state.ToString();
                snode.Tag = sid;
                treeConnect.BeginInvoke(new InvokeAddNode(AddNode),pnode, snode);
            }
        }

        public void ConnectClosed(int pid, int sid)
        {
            Log.Out(String.Format("ConnectClosed,PID:{0},SID:{1}", pid, sid));
        }

        public void MessageReceived(IoState state, byte[] message)
        {
            int pid = state.GetPID();
            int sid = state.GetSID();
            Log.Info(Color.Black,String.Format("{0}-{1} RX: ",pid,sid) +STR.ToFormatString(message,mRecType));
            RelayServer.GetInstance().RelayData(state.GetPID(), message);
        }

        public void MessageSent(IoState state, byte[] message)
        {
            int pid = state.GetPID();
            int sid = state.GetSID();
            Log.Info(Color.Blue, String.Format("{0}-{1} TX: ", pid, sid) + STR.ToFormatString(message,mSendType));
        }

        public void SessionException(Object o, Exception ex)
        {
            Log.Err("异常信息;" + ex.Message+","+ex.ToString());
         }

        public void Start()
        {
            if (!RelayServer.GetInstance().CanStart())
            {
                return;
            }

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

        public int GetPID()
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


        private byte[] GetSendData()
        {
            byte[] ret = null;
            String strSend = wndSendData.Text.Trim();
            if (strSend.Length < 1)
            {
                return ret;
            }
            try
            {
                int index = wndSendFormat.SelectedIndex;
                if (index == 0)
                {
                    ret = STR.HextoBytes(strSend);
                }
                else
                {
                    ret = STR.AscToBytes(strSend);
                }
            }
            catch(Exception ex)
            {
                Log.Err(ex.ToString());
            }
            return ret;
        }


        private void wndSend_Click(object sender, EventArgs e)
        {
            byte[] buffer = GetSendData();
            TreeNode selectNode = treeConnect.SelectedNode;
            if (buffer!=null && buffer.Length>0 && selectNode != null)
            {
                int pid, sid;
                if (selectNode.Parent == null)
                {
                    pid = (int)selectNode.Tag;
                    RelayServer.GetInstance().WriteData(pid, buffer);
                }
                else
                {
                    pid = (int)selectNode.Parent.Tag;
                    sid = (int)selectNode.Tag;
                    RelayServer.GetInstance().WriteData(pid, sid, buffer);
                }
            }
        }

        public void WriteData(int sid, byte[] buffer)
        {
            throw new NotImplementedException();
        }

        private void wndSendFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSendType = wndSendFormat.SelectedIndex;
        }

        private void wndRecFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            mRecType = wndRecFormat.SelectedIndex;
        }
    }
}
