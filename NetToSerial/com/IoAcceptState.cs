using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace com
{
    class IoAcceptState
    {
        internal TcpListener mTcpListener;
        internal IoHeader mHeader;
        internal int mBufferSize;

        internal IoAcceptState(IoHeader header,TcpListener tcpListener,int bufferSize)
        {
            mBufferSize = bufferSize;
            mHeader = header;
            mTcpListener = tcpListener;
        }

        public override string ToString()
        {
            return mTcpListener.ToString();
        }

        internal TcpClient EndAcceptTcpClient(IAsyncResult ar)
        {
            return mTcpListener.EndAcceptTcpClient(ar);
        }

        internal void BeginAcceptTcpClient()
        {
            mTcpListener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClient), this);
        }


        private static void DoAcceptTcpClient(IAsyncResult ar)
        {
            IoAcceptState acceptState = (IoAcceptState)ar.AsyncState;
            try
            {
                TcpClient client = acceptState.EndAcceptTcpClient(ar);
                IoClientState sockState = new IoClientState(acceptState.mHeader,acceptState.mBufferSize,client);
                acceptState.mHeader.ConnectOpened(sockState); //接收到连接消息
                sockState.SetStream(client.GetStream());
                sockState.BeginRead();
                acceptState.BeginAcceptTcpClient();
            }
            catch (Exception ex)
            {
                acceptState.mHeader.SessionException(acceptState, ex);
            }
        }

     
    }
}
