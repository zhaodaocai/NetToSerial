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
        private int mPID;
        private IoAcceptState mIoAcceptState;

        Dictionary<int, IoState> mIoStates = new Dictionary<int, IoState>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="bufferSize"> 客户端数据缓冲区大小</param>
        public IoServer(int pid,String ip, int port,IoHeader header)
        {
            mPID = pid;
            mHeader = header;
            mPort = port;
            mAddress = IPAddress.Parse(ip);
        }

        public int GetPID()
        {
            return mPID;
        }


        public override string ToString()
        {
            return String.Format("PID:{0},IP:{1}:{2} ",mPID, mAddress.ToString(),mPort);
        }

        public void Stop()
        {
            if (mTcpListener != null)
            {
                CloseConnect();

                mTcpListener.Stop();
            }
        }

        
        public void CloseConnect()
        {
            lock (mIoStates)
            {
                foreach(IoState item in mIoStates.Values)
                {
                    IoClientState clientState = item as IoClientState;
                    clientState.Close();
                }
                mIoStates.Clear();
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
                    mIoAcceptState = new IoAcceptState(this, mTcpListener,mBufferSize);
                    mIoAcceptState.BeginAcceptTcpClient();
                    mHeader.SessionOpened(this);
                }
                catch (Exception ex)
                {
                    SessionException(this, ex);
                }
            }
        }

        public void SessionClosed(int pid)
        {
            
            mHeader.SessionClosed(pid);
        }

        public void SessionOpened(IoHeader header)
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

        public void SessionException(Object o, Exception ex)
        {
            mHeader.SessionException(o, ex);
        }

        public void ConnectOpened(IoState state)
        {
            lock (mIoStates)
            {
                mIoStates.Add(state.GetSID(), state);
            }
            mHeader.ConnectOpened(state);
        }

        public void ConnectClosed(int pid, int sid)
        {
            lock (mIoStates)
            {
                mIoStates.Remove(pid);
            }
            mHeader.ConnectClosed(pid,sid);
        }

        public void SetReadBuffer(int size)
        {
            mBufferSize = size;
        }

        public void WriteData(byte[] buffer)
        {
            lock (mIoStates)
            {
                foreach (IoState item in mIoStates.Values)
                {
                    item.WriteData(buffer);
                }
            }
        }

        public void WriteData(int sid, byte[] buffer)
        {
            lock (mIoStates)
            {
                IoState state;
                if(mIoStates.TryGetValue(sid,out state))
                {
                    state.WriteData(buffer);
                }
            }
        }
    }
}
