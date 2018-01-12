using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace com
{
    public class IoSerial : IoHeader, IWriteData
    {
        private IoHeader mHeader = null;
        private SerialPort mSerialPort = new SerialPort();
        private int mPID;
        private int mBufferSize = 1024;
        private IoState mIoState;
        public IoSerial(int pid, SerialPort sp, IoHeader header)
        {
            mPID = pid;
            mHeader = header;
            mSerialPort.PortName = sp.PortName;
            mSerialPort.BaudRate = sp.BaudRate;
            mSerialPort.Parity = sp.Parity;
            mSerialPort.DataBits = sp.DataBits;
            mSerialPort.StopBits = sp.StopBits;
        }

        public int GetPID()
        {
            return mPID;
        }

        public int GetReadTimeout()
        {
            double ret = 0;
            ret = 1000 * 11 * 4 / mSerialPort.BaudRate;
            return (int)ret;
        }

        public override string ToString()
        {
            return String.Format("PID:{0},PORT:{1} ", mPID, mSerialPort.PortName);
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
                    mHeader.SessionOpened(this); //串口打开消息
                    Stream stream = mSerialPort.BaseStream;
                    stream.ReadTimeout = GetReadTimeout(); //设置读超时
                    mIoState = new IoSerialState(this, stream, mBufferSize, mSerialPort);
                    mIoState.BeginRead();
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
                }
                catch (Exception ex)
                {
                    SessionException(this, ex);
                }
            }
        }

        public void ConnectOpened(IoState state)
        {
            throw new NotImplementedException();
        }

        public void SessionClosed(int pid)
        {
            throw new NotImplementedException();
        }

        public void SessionOpened(IoHeader header)
        {
            throw new NotImplementedException();            
        }

        public void ConnectClosed(int pid, int sid)
        {
            mHeader.SessionClosed(pid);
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

        public void WriteData(byte[] buffer)
        {
            if (mIoState != null)
            {
                mIoState.WriteData(buffer);
            }
        }

        public void WriteData(int sid, byte[] buffer)
        {
            throw new NotImplementedException();
        }

    }
}
