using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace com
{
    abstract public class IoState  : Object
    {
        private byte[] mBuffer;
        private Stream mStream;
        public IoHeader mHeader;
        public IoState(IoHeader header,int bufferSize)
        {
            mBuffer = new byte[bufferSize];
            mHeader = header;
        }

        public byte[] GetBuffer()
        {
            return mBuffer;
        }

        public Stream GetStream()
        {
            return mStream;
        }

        public void SetStream(Stream stream)
        {
            mStream = stream;
        }

        public IAsyncResult BeginRead()
        {
            return mStream.BeginRead(mBuffer, 0, mBuffer.Length, new AsyncCallback(ReadCallBack), this);
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
                    state.mHeader.ConnectClosed(state); //连接断开
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                state.mHeader.ConnectClosed(state); //连接断开
            }
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
                        readCount = mStream.Read(mBuffer, ret, mBuffer.Length - ret);
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
