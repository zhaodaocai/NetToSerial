using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace com
{
    public class IoServer : IoHeader, IWriteData
    {
        private IoHeader mHeader = null;
        private IPAddress mAddress; 
        private int mPort;
        private int mBufferSize=1024;
        private TcpListener mTcpListener;
        private List<IoState> mIoStates = new List<IoState>();
        private int mID;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="bufferSize"> 客户端数据缓冲区大小</param>
        public IoServer(int id,String ip, int port,IoHeader header)
        {
            mID = id;
            mHeader = header;
            mPort = port;
            mAddress = IPAddress.Parse(ip);
        }

        public int GetID()
        {
            return mID;
        }


        public override string ToString()
        {
            return String.Format("IoServer, ID:{0},IP:{1}:{2} ",mID, mAddress.ToString(),mPort);
        }

        public void Stop()
        {
            if (mTcpListener != null)
            {
                mTcpListener.Stop();
               SessionClosed(this);
            }
        }

        public void Start()
        {
            if (mTcpListener == null)
            {
                try
                {
                    mTcpListener = new TcpListener(mAddress, mPort);
                    mTcpListener.Start();
                    IoAcceptState state = new IoAcceptState(this, mTcpListener,mBufferSize);
                    state.BeginAcceptTcpClient();
                    mHeader.SessionOpened(this);
                }
                catch (Exception ex)
                {
                    SessionException(this, ex);
                }
            }
        }

        public void SessionClosed(IoHeader header)
        {
            mHeader.SessionClosed(header);
        }

        public void SessionOpened(IoHeader header)
        {
            mHeader.SessionOpened(header);
        }

        public void MessageReceived(IoState state, byte[] message)
        {
            mHeader.MessageReceived(state, message);
        }

        public void MessageSent(IoState state, byte[] message)
        {
            mHeader.MessageSent(state, message);
        }

        public void SessionException(Object o, Exception ex)
        {
            mHeader.SessionException(o, ex);
        }

        public void ConnectOpened(IoState state)
        {
            lock (mIoStates)
            {
                mIoStates.Add(state);
            }
            mHeader.ConnectOpened(state);
        }

        public void ConnectClosed(IoState state)
        {
            lock (mIoStates)
            {
                mIoStates.Remove(state);
            }
            mHeader.ConnectClosed(state);
        }

        public void SetReadBuffer(int size)
        {
            mBufferSize = size;
        }

        public void WriteData(byte[] buffer)
        {
            lock (mIoStates)
            {
                foreach(IoState item in mIoStates)
                {
                    item.WriteData(buffer);
                }
            }
        }
    }
}
