using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com
{
    public class STR
    {
        public static String toString(byte[] buffer)
        {
            return toString(buffer, buffer.Length);
        }

        public static String toString(byte[] buffer, int len)
        {
            StringBuilder ret = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                if (i > 0)
                {
                    ret.Append(' ');
                }
                ret.Append(buffer[i].ToString("X2"));
            }
            return ret.ToString();
        }
    }
}
