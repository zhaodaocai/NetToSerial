using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com
{
    public interface IoHeader
    {

        void SessionClosed(int pid);

        void SessionOpened(IoHeader header);

        void ConnectOpened(IoState state);
        
        void ConnectClosed(int pid, int sid);
       
        void MessageReceived(IoState state, byte[] message);

        void MessageSent(IoState state, byte[] message);

        void SessionException(Object o, Exception ex);

        void SetReadBuffer(int size);

        void WriteData(byte[] buffer);
        void WriteData(int sid, byte[] buffer);
        int GetPID();

        void Start();

        void Stop();
       
    }
}
