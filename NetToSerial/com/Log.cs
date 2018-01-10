using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace com
{
    public class Log 
    {
        private static Log log = new Log();
        private static RichTextBox mRich = new RichTextBox();

        delegate void InfoDeleggate(Color color, String s);
        static InfoDeleggate mInfoDeleggate = new InfoDeleggate(CallInfo);

        private Log()
        {
        }

        public static void Init(RichTextBox rich)
        {
            mRich = rich;
        }

        public static void Debug(String s)
        {
            Info(Color.Black, s);
        }
        public static void Out(String s)
        {
            Info(Color.Blue, s);
        }

        public static void Err(String s)
        {
            Info(Color.Red, s);
        }

        public static void Info(Color color, String s)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
            {
                mRich.BeginInvoke(mInfoDeleggate, color, s);
            }));
        }

        public static void CallInfo(Color color, String s)
        {
            if (s == null)
            {
                mRich.Clear();
            }
            else{
                String stime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff");
                mRich.SelectionColor = color;
                mRich.AppendText(String.Format("{0} {1} \r\n", stime, s));
                mRich.ScrollToCaret();
            }
        }

    }
}
