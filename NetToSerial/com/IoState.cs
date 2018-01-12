using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace com
{
    abstract public class IoState  : Object
    {
        private byte[] mReadBuffer;
        private byte[] mWriteBuffer;
        private Stream mStream;
        protected int mSID;
        private AutoResetEvent mCanWrite = new AutoResetEvent(true);
        public IoHeader mHeader;
        private static int GID = 0;
        public IoState(IoHeader header,int bufferSize)
        {
            mReadBuffer = new byte[bufferSize];
            mHeader = header;
            mSID=System.Threading.Interlocked.Increment(ref GID);
        }

        public byte[] GetBuffer()
        {
            return mReadBuffer;
        }

        public Stream GetStream()
        {
            return mStream;
        }

        public int GetSID()
        {
            return mSID;
        }

        public int GetPID()
        {
            return mHeader.GetPID();
        }

        public void SetStream(Stream stream)
        {
            mStream = stream;
        }

        public IAsyncResult BeginRead()
        {
            return mStream.BeginRead(mReadBuffer, 0, mReadBuffer.Length, new AsyncCallback(ReadCallBack), this);
        }

        public void WriteData(byte[] buffer)
        {
            if (mCanWrite.WaitOne())
            {
                mWriteBuffer = buffer;
                BeginWrite();
            }
        }

        public IAsyncResult BeginWrite()
        {
            return mStream.BeginWrite(mWriteBuffer, 0, mWriteBuffer.Length, new AsyncCallback(WriteCallBack), this);
        }

        internal int EndRead(IAsyncResult iar)
        {
            return mStream.EndRead(iar);
        }

        private static void ReadCallBack(IAsyncResult iar)
        {
            IoState state = iar.AsyncState as IoState;
            int NumOfBytesRead = 0;
            try
            {
                NumOfBytesRead = state.EndRead(iar);
                if (NumOfBytesRead > 0)
                {
                    NumOfBytesRead=state.ReadData(NumOfBytesRead);

                    byte[] buffer = new byte[NumOfBytesRead];
                    Array.Copy(state.GetBuffer(), buffer, NumOfBytesRead);
                    state.mHeader.MessageReceived(state, buffer);
                    state.BeginRead();
                }
                else
                {
                    state.mHeader.ConnectClosed(state.GetPID(), state.GetSID()); //连接断开
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                state.mHeader.ConnectClosed(state.GetPID(), state.GetSID()); //连接断开
            }
        }

        private static void WriteCallBack(IAsyncResult iar)
        {
            IoState state = iar.AsyncState as IoState;
            state.mStream.EndWrite(iar);
            
            int writeCount = state.mWriteBuffer.Length;
            byte[] buffer = new byte[writeCount];
            Array.Copy(state.mWriteBuffer, buffer, writeCount);
            state.mHeader.MessageSent(state, buffer);
            state.mCanWrite.Set();
        }

        private int ReadData(int offset)
        {
            int ret = offset;
            if (mStream.ReadTimeout > 0)
            {
                int readCount = 1;
                while (readCount>0)
                {
                    try
                    {
                        readCount = mStream.Read(mReadBuffer, ret, mReadBuffer.Length - ret);
                        ret += readCount;
                    }
                    catch(TimeoutException ex)
                    {
                        ex.Source = null;
                        break;
                    }
                }
            }
            return ret;
        }

        
    }
}
