using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace com
{
    public class IoServer : IoHeader
    {
        private IoHeader mHeader = null;
        private IPAddress mAddress; 
        private int mPort;
        private int mBufferSize;
        private TcpListener mTcpListener;
        private List<IoState> mSessions = new List<IoState>();

        private long mID;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="bufferSize"> 客户端数据缓冲区大小</param>
        public IoServer(long id,IoHeader header, String ip, int port,int bufferSize)
        {
            mID = id;
            mBufferSize = bufferSize;
            mHeader = header;
            mPort = port;
            mAddress = IPAddress.Parse(ip);
        }

        public long GetID()
        {
            return mID;
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
                    IoAcceptState state = new IoAcceptState(mHeader, mTcpListener,mBufferSize);
                    state.BeginAcceptTcpClient();
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
            mSessions.Add(state);
            mHeader.ConnectOpened(state);
        }

        public void ConnectClosed(IoState state)
        {
            mSessions.Remove(state);
            mHeader.ConnectClosed(state);
        }
    }
}
