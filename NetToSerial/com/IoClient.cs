using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace com
{
    public class IoClient : IoHeader
    {
        private IPAddress mAddress;
        private int mPort;
        private IoHeader mHeader;
        private int mBufferSize=1024;
        private int mID;
        TcpClient mClient=new TcpClient();
        public IoClient(int id, String ip, int port, IoHeader header)
        {
            mID = id;
            mHeader = header;
            mAddress = IPAddress.Parse(ip);
            mPort = port;
        }

        public int GetID()
        {
            return mID;
        }

        public override string ToString()
        {
            return String.Format("[{0},{1}:{2}]", mID, mAddress.ToString(), mPort);
        }

        public void Start()
        {
            IoClientState state = new IoClientState(mHeader, mBufferSize, mClient);
            mClient.BeginConnect(mAddress, mPort, new AsyncCallback(DoConnectCallBack), state);
        }

        private void DoConnectCallBack(IAsyncResult ar)
        {
            try
            {
                mClient.EndConnect(ar);
                IoState state = ar.AsyncState as IoState;
                ConnectOpened(state);

                //连接后启动异步读数据
                state.SetStream(mClient.GetStream());
                state.BeginRead();
            }
            catch(Exception ex)
            {
                mHeader.SessionException(this, ex);
            }
        }

        public void Stop()
        {
            
            
        }

        public void ConnectClosed(IoState state)
        {
            mHeader.ConnectClosed(state);
        }

        public void ConnectOpened(IoState state)
        {
            mHeader.ConnectOpened(state);
        }

        public void MessageReceived(IoState state, byte[] message)
        {
            mHeader.MessageReceived(state, message);
        }

        public void MessageSent(IoState state, byte[] message)
        {
            mHeader.MessageSent(state, message);
        }

        public void SessionClosed(IoHeader header)
        {
            mHeader.SessionClosed(header);
        }

        public void SessionException(Object o, Exception ex)
        {
            mHeader.SessionException(o, ex);
        }

        public void SessionOpened(IoHeader header)
        {
            mHeader.SessionOpened(header);
        }

        public void SetReadBuffer(int size)
        {
            mBufferSize = size;
        }
    }
}
