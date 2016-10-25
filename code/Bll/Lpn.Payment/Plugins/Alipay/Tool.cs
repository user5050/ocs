using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace Com.Alipay
{
    public class Tool
    {
        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            byte[] readBuffer = new byte[1024];

            int totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
            {
                totalBytesRead += bytesRead;

                if (totalBytesRead == readBuffer.Length)
                {
                    int nextByte = stream.ReadByte();
                    if (nextByte != -1)
                    {
                        byte[] temp = new byte[readBuffer.Length * 2];
                        Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                        Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                        readBuffer = temp;
                        totalBytesRead++;
                    }
                }
            }

            byte[] buffer = readBuffer;
            if (readBuffer.Length != totalBytesRead)
            {
                buffer = new byte[totalBytesRead];
                Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
            }
            return buffer;
        }


        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);

            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }


        public static byte[] StreamToBytes(Stream stream, int len)
        {
            byte[] bytes = new byte[len];
            stream.Read(bytes, 0, len);

            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }


        private static object SwitchPropertyValue(Type type, object val)
        {

            switch (type.Name)
            {
                case "Int16":
                    if (val.ToString().Equals(""))
                        return 0;
                    else
                        return Convert.ToInt16(val);
                    break;

                case "Int32":
                    if (val.ToString().Equals(""))
                        return 0;
                    else
                        return Convert.ToInt32(val);
                    break;

                case "Int64":
                    if (val.ToString().Equals(""))
                        return 0;
                    else
                        return Convert.ToInt64(val);
                    break;

                case "String":
                    return val.ToString();
                    break;

                case "Boolean":
                    if (val.ToString().Equals(""))
                        return false;
                    else
                        return Convert.ToBoolean(val);
                    break;

                case "DateTime":
                    if (val.ToString().Equals(""))
                        return default(DateTime);
                    else
                        return Convert.ToDateTime(val);
                    break;

                case "Guid":
                    if (val.ToString().Equals(""))
                        return Guid.Empty;
                    else
                        return new Guid(val.ToString());
                    break;

                case "Double":
                    if (val.ToString().Equals(""))
                        return 0;
                    else
                        return Convert.ToDouble(val);
                    break;

                case "Float":
                    if (val.ToString().Equals(""))
                        return 0;
                    else
                        return float.Parse(val.ToString());
                    break;

                case "Decimal":
                    if (val.ToString().Equals(""))
                        return 0;
                    else
                        return Convert.ToDecimal(val);
                    break;
            }
            return null;
        }

    }


}
