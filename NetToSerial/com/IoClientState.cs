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

        public IoClientState(IoHeader header, int bufferSize) : base(header, bufferSize)
        {
           
        }

        public IoClientState(IoHeader header, int bufferSize, TcpClient tcpClient) : base(header, bufferSize)
        {
            mTcpClient = tcpClient;
        }

        public override string ToString()
        {
            String addr = "";
            if (mTcpClient.Client.Connected)
            {
                addr = mTcpClient.Client.RemoteEndPoint.ToString();
            }
            int headerID = this.GetHeaderID();
            return String.Format("PID:{0},SID:{1},IP:{1}", headerID, this.mStateID,  addr);
        }

    }
}
