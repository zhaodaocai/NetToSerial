using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NetToSerial
{
    public struct SerialRow
    {
        public bool select;
        public int id;
        public int port;
        public int baud;
        public int parity;
        public SerialRow(DataRow dr)
        {
            select =Convert.ToBoolean(dr["SerialSelect"]);
            id = Convert.ToInt32(dr["SerialID"]);
            port= Convert.ToInt32(dr["ColSerialPort"]);
            baud= Convert.ToInt32(dr["ColBaud"]);
            parity= Convert.ToInt32(dr["ColParity"]);
        }
    }

    public struct ServerRow
    {
        public bool select;
        public int id;
        public String ip;
        public int port;
        public ServerRow(DataRow dr)
        {
            select = Convert.ToBoolean(dr["ServerSelect"]);
            id = Convert.ToInt32(dr["ServerID"]);
            ip = Convert.ToString(dr["ColServerIP"]);
            port= Convert.ToInt32(dr["ColServerPort"]);
        }
    }

    public struct ClientRow
    {
        public bool select;
        public int id;
        public String ip;
        public int port;
        public ClientRow(DataRow dr)
        {
            select = Convert.ToBoolean(dr["ClientSelect"]);
            id = Convert.ToInt32(dr["ClientID"]);
            ip = Convert.ToString(dr["ColClientIP"]);
            port = Convert.ToInt32(dr["ColClientPort"]);
        }
    }

    public struct RelayRow
    {
        public bool select;
        public int id1;
        public int id2;
        public RelayRow(DataRow dr)
        {
            select = Convert.ToBoolean(dr["RelaySelect"]);
            id1 = Convert.ToInt32(dr["ID1"]);
            id2 = Convert.ToInt32(dr["ID2"]);
        }
    }
}
