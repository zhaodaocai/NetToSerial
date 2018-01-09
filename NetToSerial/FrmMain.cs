using com;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
           
            

            
            //List<RunParam> rps = new List<RunParam>();
            //RunParam rp;
            //if (mRelayServer == null)
            //{
            //    LogInfo.Out(null);
            //    DataTable dt = GetGridSource();
            //    foreach(DataRow dr in dt.Rows)
            //    {
            //        try
            //        {
            //            Object oSelect = dr["ColSelect"];
            //            rp = new RunParam(dr);
            //            if (rp.mSelect)
            //            {
            //                rps.Add(rp);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            LogInfo.Err("获取参数异常:"+ex.Message);
            //            return;
            //        }
            //    }
            //    mRelayServer = new RelayServer();
            //    mRelayServer.setValue(rps);
            //    mRelayServer.IStart();
            //    LogInfo.Out("已执行启动");
            //}
            //else
            //{
            //    LogInfo.Err("重复启动");
            //}

        }

        private void wndStop_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (mRelayServer != null)
            //    {
            //        mRelayServer.IStop();
            //        mRelayServer = null;
            //        Log.Out("已执行关闭");
            //    }
            //    else
            //    {
            //        Log.Err("未启动,无需关闭");
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Log.Err("停止异常:" + ex.Message);
            //}
        }

        private void wndClear_Click(object sender, EventArgs e)
        {
            WndInfo.Text = "";
        }

        private void wndParam_Click(object sender, EventArgs e)
        {
            FrmParam frm = new FrmParam();
            if (frm.ShowDialog()==DialogResult.OK)
            {
                //DataTable dt = frm.GetDataTable();
            }

        }

        public void SessionClosed(IoHeader header)
        {
            System.Diagnostics.Debug.WriteLine("SessionClosed:" + header.ToString());
        }

        public void SessionOpened(IoHeader header)
        {
            System.Diagnostics.Debug.WriteLine("SessionOpened:" + header.ToString());
        }

        public void ConnectOpened(IoState state)
        {
            System.Diagnostics.Debug.WriteLine("ConnectOpened:" + state.ToString());
        }

        public void ConnectClosed(IoState state)
        {
            System.Diagnostics.Debug.WriteLine("ConnectClosed:" + state.ToString());
        }

        public void MessageReceived(IoState state, byte[] message)
        {
            System.Diagnostics.Debug.WriteLine("MessageReceived:" + state.ToString());
        }

        public void MessageSent(IoState state, byte[] message)
        {
            System.Diagnostics.Debug.WriteLine("MessageSent:"+state.ToString());
        }

        public void SessionException(Object o, Exception ex)
        {
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
    }
}
