﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace com
{
    public class IoSerialState : IoState
    {
        SerialPort mSerialPort;

        public override string ToString()
        {
            return String.Format("PID:{0},SID:{1},{2}-{3}",mHeader.GetPID(),this.mSID, mSerialPort.PortName,mSerialPort.BaudRate);
        }


        public IoSerialState(IoHeader header, Stream stream, int bufferSize) : base(header, bufferSize)
        {
            this.SetStream(stream);
        }

        public IoSerialState(IoHeader header, Stream stream, int bufferSize,SerialPort serialPort) : base(header, bufferSize)
        {
            this.SetStream(stream);
            mSerialPort = serialPort;
        }
    }
}
