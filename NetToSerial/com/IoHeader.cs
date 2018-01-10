using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com
{
    public interface IoHeader
    {
        /// <summary>
        /// 用于串口或者网络服务的关闭
        /// </summary>
        /// <param name="header"></param>
        void SessionClosed(IoHeader header);

        /// <summary>
        /// 用于串口或者网络服务的关闭
        /// </summary>
        /// <param name="header"></param>
        void SessionOpened(IoHeader header);

        /// <summary>
        /// 用于网络服务接收的新连接
        /// </summary>
        /// <param name="state"></param>
        void ConnectOpened(IoState state);

        /// <summary>
        /// 用于网络服务接收的新连接
        /// </summary>
        /// <param name="state"></param>
        void ConnectClosed(IoState state);

        /// <summary>
        /// 收到消息
        /// </summary>
        /// <param name="state"></param>
        /// <param name="message"></param>
        void MessageReceived(IoState state, byte[] message);

        /// <summary>
        /// 发送完成
        /// </summary>
        /// <param name="state"></param>
        /// <param name="message"></param>
        void MessageSent(IoState state, byte[] message);

        /// <summary>
        /// 异常消息,会话与状态异常消息
        /// </summary>
        /// <param name="o"></param>
        /// <param name="ex"></param>
        void SessionException(Object o, Exception ex);

        void SetReadBuffer(int size);

        int GetID();
        
        /// <summary>
        /// 启动命令
        /// </summary>
        void Start();

        /// <summary>
        /// 停止命令
        /// </summary>
        void Stop();


    }
}
