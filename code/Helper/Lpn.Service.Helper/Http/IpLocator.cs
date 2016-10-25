using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using OneCoin.Service.Helper.Log;

namespace OneCoin.Service.Helper.Http
{
 
    public class IpLocator
    {
        private static readonly Encoding Encoding = Encoding.UTF8;
        private static uint _overflowIndex;
        private readonly byte[] _data; 

        public IpLocator(string  dataFilePath)
        {
            using (var stream = File.OpenRead(dataFilePath))
            {
                var len = stream.Length;
                _data = new byte[len];
                stream.Position = 0;

                stream.Read(_data, 0, (int)len);
            }

            _overflowIndex = BitConverter.ToUInt32(_data, 0);
        }

        public static uint IpToInt(string ip)
        {
            var bytes = IPAddress.Parse(ip).GetAddressBytes();
            return  bytes[3] + (((uint)bytes[2]) << 8) + (((uint)bytes[1]) << 16) + (((uint)bytes[0]) << 24);
        }

        public static string IntToIP(uint ipInt)
        {
            return new IPAddress(ipInt).ToString();
        }

        public string Query(string ip)
        {
            try
            {
                var ipAddress = IPAddress.Parse(ip);
                if (ipAddress.AddressFamily != AddressFamily.InterNetwork)
                {
                    return "局域网";
                }

                if (IPAddress.IsLoopback(ipAddress))
                {
                    return "局域网";
                }


                var ipBuffer = BitConverter.GetBytes(IpToInt(ip));

                var addressIndex = FindAddressIndex(_data, ipBuffer);

                if (addressIndex >= 0)
                {
                    return GetAddress(_data, addressIndex); 
                }
            }
            catch (Exception ex)
            {
                 LogHelper.Add("获取IP对应的区域地址",ex);
            }

            return "";
        }

        private static string GetAddress(byte[] dataBuffer, int addressIndex)
        {
            var contentLen = BitConverter.ToUInt32(dataBuffer, addressIndex);
            var address = Encoding.GetString(dataBuffer, addressIndex + 4, (int)contentLen);

            return address;
        }

        private static int FindAddressIndex(byte[] dataBuffer, byte[] ipBuffer)
        {
            var index = 4;
            const int ipIndex = 3;
            const int checkIndex = 3;

            int findAndCheckIndex = -1;
            var ipValue = ipBuffer[ipIndex];


            while (true)
            {
                if (ipValue < dataBuffer[index + checkIndex])
                {
                    findAndCheckIndex = index >= 12 ? index - 12 : 0;
                    break;
                }
                if (ipValue == dataBuffer[index + checkIndex])
                {
                    if (ipBuffer[2] < dataBuffer[index + checkIndex - 1]
                        || (ipBuffer[2] == dataBuffer[index + checkIndex - 1] && ipBuffer[1] < dataBuffer[index + checkIndex - 2])
                        || (ipBuffer[2] == dataBuffer[index + checkIndex - 1] && ipBuffer[1] == dataBuffer[index + checkIndex - 2] && ipBuffer[0] < dataBuffer[index + checkIndex - 3])
                        )
                    {

                        findAndCheckIndex = index - 12;
                        break;
                    }

                    if ((ipBuffer[2] == dataBuffer[index + checkIndex - 1] &&
                         ipBuffer[1] == dataBuffer[index + checkIndex - 2] &&
                         ipBuffer[0] == dataBuffer[index + checkIndex - 3])
                        )
                    {
                        findAndCheckIndex = index;
                        break;
                    }

                    index += 12;
                }
                else
                {
                    index += 12;
                }

                if (index >= _overflowIndex) break;
            }

            if (findAndCheckIndex <= 0) return -1;

            var findStartIp = BitConverter.ToUInt32(dataBuffer, findAndCheckIndex);
            var findEndIp = BitConverter.ToUInt32(dataBuffer, findAndCheckIndex + 4);
            var curIp = BitConverter.ToUInt32(ipBuffer, 0);

            if (findStartIp <= curIp && curIp <= findEndIp)
            {
                return BitConverter.ToInt32(dataBuffer, findAndCheckIndex + 8);
            }

            return -1;
        }

        

        /// <summary>
        /// C#将IP地址转为长整形
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static long IpToNumber(string ip)
        {
            var arr = ip.Split('.');
            return 256 * 256 * 256 * long.Parse(arr[0]) + 256 * 256 * long.Parse(arr[1]) + 256 * long.Parse(arr[2]) + long.Parse(arr[3]);
        }
        /// <summary>
        /// C#判断IP地址是否为私有/内网ip地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsPrivateIp(string ip)
        {
            long aBegin = IpToNumber("10.0.0.0"), aEnd = IpToNumber("10.255.255.255"),//A类私有IP地址
             bBegin = IpToNumber("172.16.0.0"), bEnd = IpToNumber("172.31.255.255"),//'B类私有IP地址
             cBegin = IpToNumber("192.168.0.0"), cEnd = IpToNumber("192.168.255.255"),//'C类私有IP地址
             ipNum = IpToNumber(ip);
            return (aBegin <= ipNum && ipNum <= aEnd) || (bBegin <= ipNum && ipNum <= bEnd) || (cBegin <= ipNum && ipNum <= cEnd);
        }
    }
}
