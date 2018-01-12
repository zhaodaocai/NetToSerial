using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace com
{
    public class IoClient : IoHeader, IWriteData
    {
        private IPAddress mAddress;
        private int mPort;
        private IoHeader mHeader;
        private int mBufferSize=1024;
        private int mPID;
        TcpClient mClient=new TcpClient();

        IoState mIoState;
        public IoClient(int pid, String ip, int port, IoHeader header)
        {
            mPID = pid;
            mHeader = header;
            mAddress = IPAddress.Parse(ip);
            mPort = port;
        }

        public int GetPID()
        {
            return mPID;
        }

        public override string ToString()
        {
            return String.Format("PID:{0},IP:{1}:{2} ",mPID, mAddress.ToString(), mPort);
        }

        public void Start()
        {
            mClient.BeginConnect(mAddress, mPort, new AsyncCallback(DoConnectCallBack), mClient);
        }

        private void DoConnectCallBack(IAsyncResult ar)
        {
            try
            {
                mClient.EndConnect(ar);
                mIoState = new IoClientState(this, mBufferSize, mClient);
                mIoState.SetStream(mClient.GetStream());
                mHeader.SessionOpened(this);
                mIoState.BeginRead();
            }
            catch(Exception ex)
            {
                mHeader.SessionException(this, ex);
            }
        }

        public void Stop()
        {
            try
            {
                mClient.Close();
            }
            catch (Exception ex)
            {
                mHeader.SessionException(this, ex);
            }
        }

        public void ConnectClosed(int pid, int sid)
        {
            mHeader.SessionClosed(mPID);
        }

        public void ConnectOpened(IoState state)
        {
            throw new NotImplementedException();
        }

        public void MessageReceived(IoState state, byte[] message)
        {
            mHeader.MessageReceived(state, message);
        }

        public void MessageSent(IoState state, byte[] message)
        {
            mHeader.MessageSent(state, message);
        }

        public void SessionClosed(int pid)
        {
            throw new NotImplementedException();
        }

        public void SessionException(Object o, Exception ex)
        {
            mHeader.SessionException(o, ex);
        }

        public void SessionOpened(IoHeader header)
        {
            throw new NotImplementedException();
        }

        public void SetReadBuffer(int size)
        {
            mBufferSize = size;
        }

        public void WriteData(byte[] buffer)
        {
            if (mIoState != null)
            {
                mIoState.WriteData(buffer);
            }
        }

        public void WriteData(int sid,byte[] buffer)
        {
            throw new NotImplementedException();
        }
    }
}
