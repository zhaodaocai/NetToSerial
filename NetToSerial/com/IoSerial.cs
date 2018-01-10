using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace com
{
    public class IoSerial : IoHeader
    {
        private IoHeader mHeader = null;
        private SerialPort mSerialPort = new SerialPort();
        private int mID;
        private int mBufferSize = 1024;
        public IoSerial(int id, SerialPort sp, IoHeader header)
        {
            mID = id;
            mHeader = header;
            mSerialPort.PortName = sp.PortName;
            mSerialPort.BaudRate = sp.BaudRate;
            mSerialPort.Parity = sp.Parity;
            mSerialPort.DataBits = sp.DataBits;
            mSerialPort.StopBits = sp.StopBits;
        }

        public int GetID()
        {
            return mID;
        }

        public int GetReadTimeout()
        {
            double ret = 0;
            ret = 1000 * 11 * 4 / mSerialPort.BaudRate;
            return (int)ret;
        }

        public override string ToString()
        {
            return String.Format("[{0},{1}]", mID, mSerialPort.PortName);
        }

        public void Start()
        {
            if (!mSerialPort.IsOpen)
            {
                try
                {
                    mSerialPort.Open();
                    mSerialPort.DiscardOutBuffer();
                    mSerialPort.DiscardInBuffer();
                    mHeader.SessionOpened(this);
                    Stream stream = mSerialPort.BaseStream;
                    stream.ReadTimeout = GetReadTimeout(); //设置读超时
                    IoSerialState state = new IoSerialState(this, stream, mBufferSize, mSerialPort);
                    mHeader.ConnectOpened(state); //连接打开
                    state.BeginRead();
                }
                catch (Exception ex)
                {
                    mHeader.SessionException(this, ex);
                }
            }
        }

        public void Stop()
        {
            if (mSerialPort.IsOpen)
            {
                try
                {
                    mSerialPort.DiscardOutBuffer();
                    mSerialPort.DiscardInBuffer();
                    mSerialPort.Close();
                    mHeader.SessionClosed(this);
                }
                catch (Exception ex)
                {
                    mHeader.SessionException(this, ex);
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

        public void ConnectOpened(IoState state)
        {
            mHeader.ConnectOpened(state);
        }

        public void ConnectClosed(IoState state)
        {
            mHeader.ConnectClosed(state);
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

        public void SetReadBuffer(int size)
        {
            mBufferSize = size;
        }
    }
}
