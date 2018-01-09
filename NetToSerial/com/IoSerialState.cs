using System;
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
            return String.Format("{0},{1}",mSerialPort.PortName,mSerialPort.BaudRate);
        }


        public IoSerialState(IoHeader header, Stream stream, int bufferSize) : base(header, stream,bufferSize)
        {
        }

        public IoSerialState(IoHeader header, Stream stream, int bufferSize,SerialPort serialPort) :base(header,stream,bufferSize)
        {
            mSerialPort = serialPort;
        }
    }
}
