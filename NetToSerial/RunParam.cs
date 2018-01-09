using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.Ports;
using System.Data;

namespace NetToSerial
{
    public class RunParam
    {
        public Boolean mSelect;
        public int mNetPort;
        public int mSerialPort;
        public int mBaud;
        public int mParity;
        public int mReadTimeout=0;

        public RunParam(DataRow dr)
        {
            Object oSelect = dr["ColSelect"];
            mSelect = (oSelect is Boolean) ? (Boolean)oSelect : false; 
            mNetPort = (int)dr["ColNetPort"];
            mSerialPort = (int)dr["ColSerialPort"];
            mBaud = (int)dr["ColBaud"];
            mParity = (int)dr["ColParity"];
        }

    }
}
