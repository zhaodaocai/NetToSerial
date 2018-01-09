using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace com
{
    abstract public class IoState 
    {
        private byte[] mBuffer;
        private Stream mStream;
        private AsyncCallback mReadCallBack=new AsyncCallback(ReadCallBack);
        public IoHeader mHeader;

        public IoState(IoHeader header,Stream stream,int bufferSize)
        {
            mBuffer = new byte[bufferSize];
            mHeader = header;
            mStream = stream;
        }

        public byte[] GetBuffer()
        {
            return mBuffer;
        }

        public Stream GetStream()
        {
            return mStream;
        }

        public IAsyncResult BeginRead()
        {
            return mStream.BeginRead(mBuffer, 0, mBuffer.Length, mReadCallBack, this);
        }

        internal int EndRead(IAsyncResult iar)
        {
            return mStream.EndRead(iar);
        }

        private static void ReadCallBack(IAsyncResult iar)
        {
            IoState state = iar.AsyncState as IoState;
            int NumOfBytesRead;
            NumOfBytesRead = state.EndRead(iar);
            if (NumOfBytesRead > 0)
            {
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
    }
}
