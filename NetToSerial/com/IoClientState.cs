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

        public IoClientState(IoHeader header, Stream stream,int bufferSize) : base(header, stream,bufferSize)
        {

        }

        public IoClientState(IoHeader header,Stream stream,int bufferSize,TcpClient tcpClient):base(header,stream,bufferSize)
        {
            mTcpClient = tcpClient;
        }

        public override string ToString()
        {
            return mTcpClient.ToString();
        }
    }
}
