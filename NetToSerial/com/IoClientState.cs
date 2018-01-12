using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace com
{
    public class IoClientState : IoState
    {
        private TcpClient mTcpClient;
        private String mAddress;
        public IoClientState(IoHeader header, int bufferSize, TcpClient tcpClient) : base(header, bufferSize)
        {
            mTcpClient = tcpClient;
            mAddress = mTcpClient.Client.RemoteEndPoint.ToString();
        }

        public override string ToString()
        {
           int headerID = this.GetPID();
           return String.Format("PID:{0},SID:{1},IP:{2}", headerID, this.mSID, mAddress);
        }

        public void Close()
        {
            if (mTcpClient != null)
            {
                mTcpClient.Close();
            }
        }

    }
}
