using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace com
{
    public class IoSerial :IoSession,IoHeader
    {
        private IoHeader mHeader = null;
        private SerialPort mSerialPort=new SerialPort();
        private long mID;
        public IoSerial(long id,IoHeader header, SerialPort sp)
        {
            mID = id;
            mHeader = header;
            mSerialPort.PortName =  sp.PortName;
            mSerialPort.BaudRate =  sp.BaudRate;
            mSerialPort.Parity =    sp.Parity;
            mSerialPort.DataBits =  sp.DataBits;
            mSerialPort.StopBits =  sp.StopBits;
        }

        public long GetID()
        {
            return mID;
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
                    IoSerialState state = new IoSerialState(this,mSerialPort.BaseStream,1024,mSerialPort);

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

        public void SessionClosed(IoSession session)
        {
            throw new NotImplementedException();
        }

        public void SessionOpened(IoSession session)
        {
            throw new NotImplementedException();
        }

        public void ConnectOpened(IoState state)
        {
            throw new NotImplementedException();
        }

        public void ConnectClosed(IoSession session)
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

        public void ConnectClosed(IoState state)
        {
            throw new NotImplementedException();
        }
    }
}
