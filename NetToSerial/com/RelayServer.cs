using com;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 数据转发服务
/// </summary>
namespace NetToSerial.com
{
    class RelayServer
    {


        /// <summary>
        /// 串口列表
        /// </summary>
        Dictionary<int, IoSerial> mDictSerial=new Dictionary<int, IoSerial>();

        /// <summary>
        /// TCP服务端列表
        /// </summary>
        Dictionary<int, IoServer> mDictServer=new Dictionary<int, IoServer>();

        /// <summary>
        /// TCP客户端列表
        /// </summary>
        Dictionary<int, IoClient> mDictClient=new Dictionary<int, IoClient>();

        private static long mID=0;
        public static long GetID()
        {
            return mID++;
        }


    }
}
