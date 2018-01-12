using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com
{
    public class STR
    {
        public static String ToString(byte[] buffer)
        {
            return ToString(buffer, buffer.Length);
        }

        public static String ToString(byte[] buffer, int len)
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


        public static byte[] AscToBytes(String Value)
        {
            byte[] ret;
            ret=System.Text.Encoding.Default.GetBytes(Value);
            return ret;
        }

        public static byte[] HextoBytes(String value)
        {
            List<byte> ret = new List<byte>();
            char[] chSeparate = " ,;；，\r\n\t".ToArray();
            string[] aString = value.Split(chSeparate, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                foreach (String item in aString)
                {
                    int count = item.Length;
                    String sValue;
                    byte byteValue;
                    for (int i = 0; i < count; i += 2)
                    {
                        sValue = item.Substring(i, 2);
                        byteValue = Convert.ToByte(sValue, 16);
                        ret.Add(byteValue);
                    }
                }
            }
            catch(FormatException ex)
            {
                Log.Err(ex.Message);
            }
            catch(Exception ex)
            {
                Log.Err(ex.ToString());
            }
            return ret.ToArray();
        }

        public static String ToAscString(byte[] message)
        {
            String ret=System.Text.Encoding.Default.GetString(message);
            return ret;
        }

        internal static string ToFormatString(byte[] message, int index)
        {
            if (index == 0)
            {
                return ToString(message);
            }
            else
            {
                return ToAscString(message);
            }
        }
    }
}
