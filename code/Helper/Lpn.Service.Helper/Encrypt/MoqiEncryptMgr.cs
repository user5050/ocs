using System;
using System.Text;
using System.Runtime.InteropServices;

namespace OneCoin.Service.Helper.Encrypt
{
    /// <summary>
    /// 摩奇卡卡加解密类
    /// 依赖外部dll  Moqikaka.CommunicationDataEncode.Component.dll
    /// </summary>
    public class MoqiEncryptMgr
    {
        #region 解密
        /// <summary>
        /// 解密Base64加密字符串(字符编码utf-8)
        /// </summary>
        /// <param name="encryptBase64Source">Base64加密字符串</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string DecryptDataWithBase64(string encryptBase64Source, string key)
        {
            return DecryptDataWithBase64(encryptBase64Source, key, Encoding.UTF8);
        }
        /// <summary>
        /// 解密Base64加密字符串
        /// </summary>
        /// <param name="encryptBase64Source">Base64加密字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public static string DecryptDataWithBase64(string encryptBase64Source, string key, Encoding encoding)
        {
            if (!string.IsNullOrEmpty(encryptBase64Source))
            {
                //var bufferLen = (uint)encoding.GetByteCount(encryptBase64Source);
                byte[] sb = null;

                _SetKey(key);
                if (_DecryptDataWithBase64(encryptBase64Source,ref sb))
                {
                    //var realLen = (int)bufferLen;
                    return encoding.GetString(sb);
                }
                else
                {
                    throw new Exception("解密失败");
                }
            }

            return string.Empty;
        }
        #endregion

        #region 加密
        /// <summary>
        /// 加密后Base64编码(utf8字符编码)
        /// </summary>
        /// <param name="source">加密源</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string EncryptDataAndBase64(string source, string key)
        {
            return EncryptDataAndBase64(source, key, Encoding.UTF8);
        }
        /// <summary>
        /// 加密后Base64编码
        /// </summary>
        /// <param name="source">加密源</param>
        /// <param name="key">秘钥</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public static string EncryptDataAndBase64(string source, string key, Encoding encoding)
        {
            if (!string.IsNullOrEmpty(source))
            {
                var bytes = encoding.GetBytes(source);
                //var byteLen = bytes.Length;

                //UInt32 bufferLen = (UInt32)GetEncryptBufferLen(byteLen);
                var sb = new StringBuilder();

                _SetKey(key);
                if (_EncryptDataAndBase64(bytes, sb))
                {
                    //sb.Length = (int)bufferLen;
                    return sb.ToString();
                }
                else
                {
                    throw new Exception("加密失败");
                }
            }

            return string.Empty;
        }
        #endregion

        #region helper
        /// <summary>
        /// 获取字节数
        /// </summary>
        /// <param name="source">待加密字符串</param>
        /// <param name="byteLen">字节数</param>
        /// <returns></returns>
        private static int GetEncryptBufferLen(int byteLen)
        {
            return (byteLen + ((byteLen % 8) != 0 ? 8 : 0) + 1) * 5 / 3 + 5;
        }
        #endregion

        #region DllImport
        /*
         *      数据加密并Base64
         *
         *  ARGUMENT:
         *      pszFrom                 -   (IN)待加密字符串
         *      ulFromLen               -   (IN)待加密字符串长度
         *      pszToBase64             -   (OUT)加密并Base64后字符串存储空间
         *      pulToBase64Len          -   (IN)加密后字符串存储空间的长度 (OUT)加密后实际数据大小
         *      bEndOfNull              -   (IN)是否在结果字符串最后加上一个空字符(空字符不会影响pulToBase64Len返回值)
         *
         *  RETURN:
         *      bool                    -   成功返回true    否则返回false
         *
         */
        //[DllImport("Moqikaka.CommunicationDataEncode.Component.dll", EntryPoint = "EncryptDataAndBase64", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        //private static extern bool _EncryptDataAndBase64(byte[] source, UInt32 sourceLen, StringBuilder encryptCode, ref UInt32 encryptCodeLen, bool endOfNull);
        private static bool _EncryptDataAndBase64(byte[] source,StringBuilder encryptCode)
        {
            if (source != null)
            {
                var keyLen = _key.Length;
                for (int i = 0; i < source.Length; i++)
                {
                    source[i] ^=  _key[i % keyLen];
                }

                encryptCode.Append(Convert.ToBase64String(source, Base64FormattingOptions.None));
            }

            return true;
        }

        /*
         *      Base64格式数据解密
         *
         *  ARGUMENT:
         *      pszFromWithBase64       -   (IN)待解密的Base64字符串
         *      pszTo                   -   (OUT)解密后字符串存储空间
         *      pulToLen                -   (IN)解密后字符串存储空间的长度 (OUT)解密后实际数据大小
         *      bEndOfNull              -   (IN)是否在结果字符串最后加上一个空字符(空字符不会影响pulToLen返回值)
         *
         *  RETURN:
         *      bool                    -   成功返回true    否则返回false
         *
         */
        //[DllImport("Moqikaka.CommunicationDataEncode.Component.dll", EntryPoint = "DecryptDataWithBase64", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        //private static extern bool _DecryptDataWithBase64(string base64Source, byte[] decryptCode, ref UInt32 decryptCodeLen, bool endOfNull);
        private static bool _DecryptDataWithBase64(string base64Source, ref byte[] decryptCode)
        {
            var keyLen = _key.Length;
            decryptCode = Convert.FromBase64String(base64Source);

            for (int i = 0; i < decryptCode.Length; i++)
            {
                decryptCode[i] ^= _key[i % keyLen];
            }

            return true;
        }

        // 设置加密/解密 KEY *** 调用加密/解密函数前，必须先设置KEY ***
        //[DllImport("Moqikaka.CommunicationDataEncode.Component.dll", EntryPoint = "SetKey", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        // private static extern void _SetKey(string pszKeyString);
        private static byte[] _key = null;
        private static void _SetKey(string pszKeyString)
        {
            _key = Encoding.UTF8.GetBytes(pszKeyString);
        }

        // 设置加密/解密的轮数 *** 可选调用 ***
        [DllImport("Moqikaka.CommunicationDataEncode.Component.dll", EntryPoint = "SetRound", CallingConvention = CallingConvention.StdCall)]
        private static extern void _SetRound(Int32 round);
        #endregion

        #region 加密
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string EncodeString(string source,string key)
        {

            byte[] inputBytes = Encoding.UTF8.GetBytes(source);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            for (int i = 0; i < inputBytes.Length; i++)
            {
                inputBytes[i] = (byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
            }
            return Convert.ToBase64String(inputBytes);
        }
        #endregion
    }
}
