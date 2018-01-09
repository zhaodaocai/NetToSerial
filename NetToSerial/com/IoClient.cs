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
        private int mBufferSize;
        private long mID;
        TcpClient mClient=new TcpClient();

        public IoClient(long id,IoHeader header, String ip, int port,int bufferSize)
        {
            mID = id;
            mBufferSize = bufferSize;
            mHeader = header;
            mAddress = IPAddress.Parse(ip);
            mPort = port;
        }

        public long GetID()
        {
            return mID;
        }

        public void Start()
        {
            IoClientState state = new IoClientState(mHeader, mClient.GetStream(), mBufferSize, mClient);
            mClient.BeginConnect(mAddress, mPort, new AsyncCallback(DoConnectCallBack), state);
            state.BeginRead();
        }

        private void DoConnectCallBack(IAsyncResult ar)
        {
            mClient.EndConnect(ar);
            IoState state = ar.AsyncState as IoState;
            ConnectOpened(state);
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
  
    }
}
