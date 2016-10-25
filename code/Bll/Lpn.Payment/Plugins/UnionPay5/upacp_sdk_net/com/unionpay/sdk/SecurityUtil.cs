﻿using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;
using System.Configuration;


namespace upacp_sdk_net.com.unionpay.sdk
{
    public static class SecurityUtil
    {

        public static string ALGORITHM_SHA1 = "SHA1";

        /// <summary>
        /// 摘要计算
        /// </summary>
        /// <param name="dataStr"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] Sha1X16(string dataStr, Encoding encoding)
        {
            try
            {
                byte[] data = encoding.GetBytes(dataStr);
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] sha1Res = sha1.ComputeHash(data, 0, data.Length);
                return sha1Res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// 软签名
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] SignBySoft(RSACryptoServiceProvider provider, byte[] data)
        {
            byte[] res = null;
            try
            {
                HashAlgorithm hashalg = new SHA1CryptoServiceProvider();
                res = provider.SignData(data, hashalg);
            }
            catch (Exception e)
            {
                throw e;
            }
            if (null == res) { return null; }
            return res;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="base64DecodingSignStr"></param>
        /// <param name="srcByte"></param>
        /// <returns></returns>
        public static bool ValidateBySoft(RSACryptoServiceProvider provider, byte[] base64DecodingSignStr, byte[] srcByte)
        {
            HashAlgorithm hashalg = new SHA1CryptoServiceProvider();
            return provider.VerifyData(srcByte, hashalg, base64DecodingSignStr);
        }


        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="encode">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string EncodeBase64(string source, Encoding encoding)
        {
            string encodeStr = "";
            byte[] bytes = encoding.GetBytes(source);
            try
            {
                encodeStr = Convert.ToBase64String(bytes);
            }
            catch
            {
                encodeStr = source;
            }
            return encodeStr;
        }



        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="encode">解码采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解码的密文</param>
        /// <returns>解码后的字符串</returns>
        public static string DecodeBase64(string result, Encoding encoding)
        {
            string decodeStr = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decodeStr = encoding.GetString(bytes);
            }
            catch
            {
                decodeStr = result;
            }
            return decodeStr;
        }

        /// <summary>
        /// Inflater解压缩
        /// </summary>
        /// <param name="inputByte"></param>
        /// <returns></returns>
        public static byte[] inflater(byte[] inputByte)
        {
            byte[] temp = new byte[1024];
            MemoryStream memory = new MemoryStream();
            ICSharpCode.SharpZipLib.Zip.Compression.Inflater inf = new ICSharpCode.SharpZipLib.Zip.Compression.Inflater();
            inf.SetInput(inputByte);
            while (!inf.IsFinished)
            {
                int extracted = inf.Inflate(temp);
                if (extracted > 0)
                {
                    memory.Write(temp, 0, extracted);
                }
                else
                {
                    break;
                }
            }
            return memory.ToArray();
        }

        /// <summary>
        /// deflater压缩
        /// </summary>
        /// <param name="inputByte"></param>
        /// <returns></returns>
        public static byte[] deflater(byte[] inputByte)
        {
            byte[] temp = new byte[1024];
            MemoryStream memory = new MemoryStream();
            ICSharpCode.SharpZipLib.Zip.Compression.Deflater def = new ICSharpCode.SharpZipLib.Zip.Compression.Deflater();
            def.SetInput(inputByte);
            def.Finish();
            while (!def.IsFinished)
            {
                int extracted = def.Deflate(temp);
                if (extracted > 0)
                {
                    memory.Write(temp, 0, extracted);
                }
                else
                {
                    break;
                }
            }
            return memory.ToArray();

        }

        
         /// <summary>
         /// 密码计算
         /// </summary>
         /// <param name="aPin"></param>
         /// <returns></returns>
        private static byte[] pin2PinBlock(string aPin)
        {
            int tTemp = 1;
            int tPinLen = aPin.Length;

            byte[] tByte = new byte[8];
            try
            {
                tByte[0] = (byte)Convert.ToInt32(tPinLen.ToString(),10);
                if (tPinLen % 2 == 0)
                {
                    for (int i = 0; i < tPinLen; )
                    {
                        string a = aPin.Substring(i,2).Trim();
                        tByte[tTemp] = (byte)Convert.ToInt32(a, 16);
                        if (i == (tPinLen - 2))
                        {
                            if (tTemp < 7)
                            {
                                for (int x = (tTemp + 1); x < 8; x++)
                                {
                                    tByte[x] = (byte)0xff;
                                }
                            }
                        }
                        tTemp++;
                        i = i + 2;
                    }
                }
                else
                {
                    for (int i = 0; i < tPinLen - 1; )
                    {
                        string a;
                        a = aPin.Substring(i, 2);
                        tByte[tTemp] = (byte)Convert.ToInt32(a,16);
                        if (i == (tPinLen - 3))
                        {
                            string b = aPin.Substring(tPinLen - 1) + "F";
                            tByte[tTemp + 1] = (byte)Convert.ToInt32(b, 16);
                            if ((tTemp + 1) < 7)
                            {
                                for (int x = (tTemp + 2); x < 8; x++)
                                {
                                    tByte[x] = (byte)0xff;
                                }
                            }
                        }
                        tTemp++;
                        i = i + 2;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return tByte;
        }


        /// <summary>
        /// 获取卡号密码pinblock计算
        /// </summary>
        /// <param name="aPin"></param>
        /// <param name="aCardNO"></param>
        /// <returns></returns>
        public static byte[] pin2PinBlockWithCardNO(string aPin, string aCardNO)
        {
            byte[] tPinByte = pin2PinBlock(aPin);
            if (aCardNO.Length == 11)
            {
                aCardNO = "00" + aCardNO;
            }
            else if (aCardNO.Length == 12)
            {
                aCardNO = "0" + aCardNO;
            }
            byte[] tPanByte = formatPan(aCardNO);


            byte[] tByte = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                tByte[i] = (byte)(tPinByte[i] ^ tPanByte[i]);
            }
            return tByte;

        }

        /// <summary>
        /// 卡号计算
        /// </summary>
        /// <param name="aPan"></param>
        /// <returns></returns>
        private static byte[] formatPan(string aPan)
        {
            int tPanLen = aPan.Length;
            byte[] tByte = new byte[8];
            int temp = tPanLen - 13;
            try
            {
                tByte[0] = (byte)0x00;
                tByte[1] = (byte)0x00;
                for (int i = 2; i < 8; i++)
                {
                    string a = aPan.Substring(temp,2).Trim();
                    tByte[i] = (byte)Convert.ToInt32(a, 16);
                    temp = temp + 2;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tByte;
        }

        ///<summary>
        /// 加密
        /// </summary>
        /// <returns></returns>
        public static byte[] EncryptedData(byte[] encData, string encryptCert)
        {
            try
            {
                var pc = new X509Certificate2(Encoding.ASCII.GetBytes(encryptCert));  
                var p = (RSACryptoServiceProvider)pc.PublicKey.Key;
              
                var enBytes = p.Encrypt(encData, false);


                return enBytes;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;

        }

        ///<summary>
        /// 密码加密,进行base64加密@return 转PIN结果
        /// </summary>
        /// <returns></returns>

        public static string EncryptPin(string pin, string card, Encoding encoding, string encryptCert)
        {
            /** 生成PIN Block **/
            byte[] pinBlock = pin2PinBlockWithCardNO(pin, card);

            /** 使用公钥对密码加密 **/
            try
            {
                var data = EncryptedData(pinBlock, encryptCert);
                return EncodeBase64(encoding.GetString(data), encoding);
            }
            catch (Exception e)
            {
                //TODO 请改为讲异常输出日志
                Console.WriteLine(e.Message);
                return "";
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="dataString">原字符串</param>
        /// <param name="encoding">编码</param>
        /// <param name="encryptCert"></param>
        /// <returns>RSA+BASE64的加密结果</returns>
        public static string EncryptData(string dataString, Encoding encoding, string encryptCert)
        {
            /** 使用公钥对数据加密 **/
            byte[] data = null;
            try
            {
                data = EncryptedData(encoding.GetBytes(dataString), encryptCert);
                return EncodeBase64(encoding.GetString(data), encoding);
            }
            catch (Exception e)
            {
                //TODO 请改为讲异常输出日志
                Console.WriteLine(e.Message);
                return "";
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="dataString">原字符串</param>
        /// <param name="encoding">编码</param>
        /// <returns>解密结果</returns>
        public static string DecryptData(string dataString, Encoding encoding,string pfx,string pfxPwd)
        {
            /** 使用公钥对数据加密 **/
            byte[] data = null;
            try
            {
                data = Convert.FromBase64String(dataString);
                RSACryptoServiceProvider p = CertUtil.GetSignProviderFromPfx(pfx,pfxPwd);
                data = p.Decrypt(data, false);
                return encoding.GetString(data);
            }
            catch (Exception e)
            {
                //TODO 请改为讲异常输出日志
                Console.WriteLine(e.Message);
                return "";
            }
        }  
    }


}