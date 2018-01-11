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
    class RelayServer  : StartEvent
    {
        /// <summary>
        /// 通信集合
        /// </summary>
        private Dictionary<int, IoHeader> mHeaders=new Dictionary<int, IoHeader>();

        /// <summary>
        /// 转发列表
        /// </summary>
        private Dictionary<int, List<int>> mRelays = new Dictionary<int, List<int>>();

        private static int mID = 0;
        private static RelayServer mRelayServer = new RelayServer();
        private RelayServer()
        {

        }

        public static int GetID()
        {
            return mID++;
        }
        
        public static RelayServer GetInstance()
        {
            return mRelayServer;
        }

        public void AddHeader(IoHeader header)
        {
            int id = header.GetID();
            mHeaders[id] = header;
        }

        public void WriteData(int id, byte[] buffer)
        {
            IoHeader header=null;
            List<int> ids = new List<int>();
            if (mRelays.TryGetValue(id, out ids))
            {
                foreach(int item in ids)
                {
                    if (mHeaders.TryGetValue(item, out header))
                    {
                        header.WriteData(buffer);
                    }
                }
            }
        }

        /// <summary>
        /// 增加转发列表
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        public void AddRelay(int id1,int id2)
        {
            AddRelay1(id1, id2);
            AddRelay1(id2, id1);
        }

        /// <summary>
        /// 增加ID1
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        private void AddRelay1(int id1, int id2)
        {
            List<int> ids;
            if (mRelays.TryGetValue(id1, out ids))
            {
                ids.Add(id2);
            }
            else
            {
                ids = new List<int>();
                ids.Add(id2);
                mRelays[id1] = ids;
            }
        }

        internal void Start()
        {
            if (mCanStart.WaitOne(0))
            {
                foreach (IoHeader item in mHeaders.Values)
                {
                    item.Start();
                }

            }
        }

        internal void Stop()
        {
            foreach (IoHeader item in mHeaders.Values)
            {
                item.Stop();
            }
            mHeaders.Clear();

            mCanStart.Set();
        }
    }
}
