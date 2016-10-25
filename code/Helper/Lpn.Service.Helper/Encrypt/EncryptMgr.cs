using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OneCoin.Service.Helper.Encrypt
{
    /// <summary>
    /// Encrypt 的摘要说明
    /// </summary>
    public class EncryptMgr
    {

        #region  MD5签名
        /// <summary>
        /// MD5签名
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MD5(string value)
        {
             byte[] passkey = Encoding.UTF8.GetBytes(value);

             return MD5(passkey);
        }

        public static string MD5_16(string value)
        {
            byte[] passkey = Encoding.UTF8.GetBytes(value);

            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(passkey), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        public static string MD5(byte[] value)
        {

            MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
            byte[] hashkey = md.ComputeHash(value);


            StringBuilder md5String = new StringBuilder();

            foreach (byte b in hashkey)
            {
                md5String.AppendFormat("{0:x2}", b);
            }

            return md5String.ToString();
        }

        /// <summary>
        /// 先MD5签名再Base64编码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MD5Base64(string value)
        {

            MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();

            byte[] passkey = Encoding.Default.GetBytes(value);


            return Convert.ToBase64String(md.ComputeHash(passkey));

        }
        #endregion

        #region Base64编码
        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Base64(string value)
        {
            return Base64(Encoding.Default.GetBytes(value));
        }


        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Base64(string value, string codePage)
        {
            return Base64(Encoding.GetEncoding(codePage).GetBytes(value));
        }

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Base64(byte[] value)
        {
            return Convert.ToBase64String(value);
        }


        public static byte[] FromBase64String(string str)
        {
            return Convert.FromBase64String(str);
        }
        #endregion

        #region 获取Hash描述表


        /// <summary>
        /// 获取Hash描述表
        /// </summary>
        /// <param name="m_strSource">待处理数据</param>
        /// <param name="HashData">Hash处理后值</param>
        /// <param name="hashName">Hash算法(SHA1,MD5)</param>
        /// <returns>true or false</returns>
        public static bool GetHash(string m_strSource, ref byte[] HashData, string hashName)
        {
            try
            {
                //从字符串中取得Hash描述
                byte[] Buffer;
                HashAlgorithm hash = HashAlgorithm.Create(hashName);
                Buffer = Encoding.Default.GetBytes(m_strSource);
                HashData = hash.ComputeHash(Buffer);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取Hash描述表
        /// </summary>
        /// <param name="m_strSource">待处理数据</param>
        /// <param name="strHashData">Hash处理后值(经Base64编码)</param>
        /// <param name="hashName">Hash算法(SHA1,MD5)</param>
        /// <returns>true or false</returns>
        public static bool GetHash(string m_strSource, ref string strHashData, string hashName)
        {
            try
            {
                //从字符串中取得Hash描述
                byte[] HashData = new byte[] { };
                GetHash(m_strSource, ref HashData, hashName);

                strHashData = Convert.ToBase64String(HashData);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 获取Hash描述表
        /// </summary>
        /// <param name="m_strSource">待处理数据</param>
        /// <param name="HashData">Hash处理后值</param>
        /// <param name="hashName">Hash算法(SHA1,MD5)</param>
        /// <returns>true or false</returns>
        public static bool GetHash(byte[] m_strSource, ref byte[] HashData, string hashName)
        {
            try
            {
                //从字符串中取得Hash描述
                HashAlgorithm hash = HashAlgorithm.Create(hashName);

                HashData = hash.ComputeHash(m_strSource);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取Hash描述表
        /// </summary>
        /// <param name="m_strSource">待处理数据</param>
        /// <param name="strHashData">Hash处理后值(经Base64编码)</param>
        /// <param name="hashName">Hash算法(SHA1,MD5)</param>
        /// <returns>true or false</returns>
        public static bool GetHash(byte[] m_strSource, ref string strHashData, string hashName)
        {
            try
            {
                //从字符串中取得Hash描述
                byte[] HashData = new byte[] { };
                GetHash(m_strSource, ref HashData, hashName);

                strHashData = Convert.ToBase64String(HashData);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        /// <summary>
        /// 获取Hash描述表
        /// </summary>
        /// <param name="objFile">待处理FileStream</param>
        /// <param name="HashData">Hash处理后值</param>
        /// <param name="hashName">Hash算法(SHA1,MD5)</param>
        /// <returns>true or false</returns>
        public static bool GetHash(System.IO.FileStream objFile, ref byte[] HashData, string hashName)
        {
            try
            {
                //从文件中取得Hash描述
                HashAlgorithm hash = HashAlgorithm.Create(hashName);
                HashData = hash.ComputeHash(objFile);
                objFile.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取Hash描述表
        /// </summary>
        /// <param name="objFile">待处理FileStream</param>
        /// <param name="strHashData">Hash处理后值(经Base64编码)</param>
        /// <param name="hashName">Hash算法(SHA1,MD5)</param>
        /// <returns>true or false</returns>
        public static bool GetHash(System.IO.FileStream objFile, ref string strHashData, string hashName)
        {
            try
            {
                //从文件中取得Hash描述
                byte[] HashData;
                HashAlgorithm hash = HashAlgorithm.Create(hashName);
                HashData = hash.ComputeHash(objFile);
                objFile.Close();

                strHashData = Convert.ToBase64String(HashData);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region RSA加解密
        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="DataToEncrypt">待加密的字节</param>
        /// <param name="RSAKeyInfo">公钥</param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                //Create a new instance of RSACryptoServiceProvider.
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                //Import the RSA Key information. This only needs
                //toinclude the public key information.
                RSA.ImportParameters(RSAKeyInfo);

                //Encrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                return RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch
            {
                return null;
            }

        }


        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="DataToDecrypt">待加密的字节</param>
        /// <param name="xmlKeyinfo">公钥</param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        public static byte[] RSAEncrypt(byte[] DataToDecrypt, string xmlKeyinfo, bool DoOAEPPadding)
        {
            try
            {
                RSACryptoServiceProvider Rsa = new RSACryptoServiceProvider();

                Rsa.FromXmlString(xmlKeyinfo);
                string xmlKeyinfo2 = Rsa.ToXmlString(false);

                return Rsa.Encrypt(DataToDecrypt, DoOAEPPadding);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="DataToDecrypt"></param>
        /// <param name="RSAKeyInfo"></param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                //Create a new instance of RSACryptoServiceProvider.
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                //Import the RSA Key information. This needs
                //to include the private key information.
                RSA.ImportParameters(RSAKeyInfo);


                //Decrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                return RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="DataToDecrypt"></param>
        /// <param name="xmlKeyinfo"></param>
        /// <param name="DoOAEPPadding"></param>
        /// <returns></returns>
        public static byte[] RSADecrypt(byte[] DataToDecrypt, string xmlKeyinfo, bool DoOAEPPadding)
        {
            try
            {
                RSACryptoServiceProvider Rsa = new RSACryptoServiceProvider();

                Rsa.FromXmlString(xmlKeyinfo);

                return Rsa.Decrypt(DataToDecrypt, DoOAEPPadding);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region  RSA签名
        /// <summary>
        /// RSA签名
        /// </summary>
        /// <param name="p_strKeyPrivate">私钥</param>
        /// <param name="HashbyteSignature">待加密数据(经Hash处理)</param>
        /// <param name="EncryptedSignatureData">加密后数据</param>
        /// <param name="hashName">Hash算法</param>
        /// <returns>true or false</returns>
        public static bool SignatureFormatter(string p_strKeyPrivate, byte[] HashbyteSignature
                                              , ref byte[] EncryptedSignatureData, string hashName)
        {
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                //导入私钥
                RSA.FromXmlString(p_strKeyPrivate);


                RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(RSA);

                //设置签名
                RSAFormatter.SetHashAlgorithm(hashName);

                //执行签名
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// RSA签名
        /// </summary>
        /// <param name="p_strKeyPrivate">私钥</param>
        /// <param name="HashbyteSignature">待加密数据(经Hash处理)</param>
        /// <param name="m_strEncryptedSignatureData">加密后数据(经Base64编码)</param>
        /// <param name="hashName"></param>
        /// <returns></returns>
        public static bool SignatureFormatter(string p_strKeyPrivate, byte[] HashbyteSignature
                                                , ref string m_strEncryptedSignatureData, string hashName)
        {
            try
            {
                byte[] EncryptedSignatureData = new byte[] { };

                SignatureFormatter(p_strKeyPrivate, HashbyteSignature, ref EncryptedSignatureData, hashName);

                m_strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// RSA签名
        /// </summary>
        /// <param name="p_strKeyPrivate">私钥</param>
        /// <param name="m_strHashbyteSignature">待加密数据(经Hash处理,Base64编码)</param>
        /// <param name="EncryptedSignatureData">加密后数据</param>
        /// <param name="hashName"></param>
        /// <returns></returns>
        public static bool SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature
                                                , ref byte[] EncryptedSignatureData, string hashName)
        {
            try
            {
                byte[] HashbyteSignature;

                HashbyteSignature = Convert.FromBase64String(m_strHashbyteSignature);

                SignatureFormatter(p_strKeyPrivate, HashbyteSignature, ref EncryptedSignatureData, hashName);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// RSA签名
        /// </summary>
        /// <param name="p_strKeyPrivate">私钥</param>
        /// <param name="m_strHashbyteSignature">待加密数据(经Hash处理,Base64编码码)</param>
        /// <param name="m_strEncryptedSignatureData">加密后数据(经Base64编码)</param>
        /// <param name="hashName"></param>
        /// <returns></returns>
        public static bool SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature,
                                                ref string m_strEncryptedSignatureData, string hashName)
        {
            try
            {
                byte[] HashbyteSignature;


                HashbyteSignature = Convert.FromBase64String(m_strHashbyteSignature);

                SignatureFormatter(p_strKeyPrivate, HashbyteSignature, ref m_strEncryptedSignatureData, hashName);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region RSA 签名验证
        /// <summary>
        /// 签名验证
        /// </summary>
        /// <param name="p_strKeyPublic">公钥</param>
        /// <param name="HashbyteDeformatter"></param>
        /// <param name="DeformatterData">签名信息</param>
        /// <param name="hashName"></param>
        /// <returns></returns>
        public static bool SignatureDeformatter(string p_strKeyPublic, byte[] HashbyteDeformatter
                                                  , byte[] DeformatterData, string hashName)
        {
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();


                RSA.FromXmlString(p_strKeyPublic);

                RSAPKCS1SignatureDeformatter RSADeformatter = new RSAPKCS1SignatureDeformatter(RSA);

                //指定解密的时候HASH算法
                RSADeformatter.SetHashAlgorithm(hashName);

                return RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter
                                                  , byte[] DeformatterData, string hashName)
        {
            try
            {
                byte[] HashbyteDeformatter;


                HashbyteDeformatter = Convert.FromBase64String(p_strHashbyteDeformatter);

                return SignatureDeformatter(p_strKeyPublic, HashbyteDeformatter, DeformatterData, hashName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SignatureDeformatter(string p_strKeyPublic, byte[] HashbyteDeformatter
                                                  , string p_strDeformatterData, string hashName)
        {
            try
            {
                byte[] DeformatterData;


                DeformatterData = Convert.FromBase64String(p_strDeformatterData);

                return SignatureDeformatter(p_strKeyPublic, HashbyteDeformatter, DeformatterData, hashName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter
                                                  , string p_strDeformatterData, string hashName)
        {
            try
            {
                byte[] DeformatterData;
                byte[] HashbyteDeformatter;


                HashbyteDeformatter = Convert.FromBase64String(p_strHashbyteDeformatter);

                DeformatterData = Convert.FromBase64String(p_strDeformatterData);

                return SignatureDeformatter(p_strKeyPublic, HashbyteDeformatter, DeformatterData, hashName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool SignVerify(string cerFileFullPath, byte[] source, byte[] signData, string hashName)
        {
            try
            {

                //读取cer证书文件
                var myX509Certificate2 = new X509Certificate2(cerFileFullPath);


                //从cer证书中获得含公钥的RSACryptoServiceProvider
                var myRSACryptoServiceProvider = (RSACryptoServiceProvider)myX509Certificate2.PublicKey.Key;


                //验签
                return myRSACryptoServiceProvider.VerifyData(source, hashName, signData);


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region DES加解密
        public static byte[] DESEncrypt(string PlainText, SymmetricAlgorithm key)
        {
            // Create a memory stream.
            MemoryStream ms = new MemoryStream();

            // Create a CryptoStream using the memory stream and the 
            // CSP DES key.  
            CryptoStream encStream = new CryptoStream(ms, key.CreateEncryptor(), CryptoStreamMode.Write);

            // Create a StreamWriter to write a string
            // to the stream.
            StreamWriter sw = new StreamWriter(encStream);

            // Write the plaintext to the stream.
            sw.WriteLine(PlainText);

            // Get an array of bytes that represents
            // the memory stream.
            byte[] buffer = ms.ToArray();

            // Close the memory stream.
            ms.Close();

            // Return the encrypted byte array.
            return buffer;
        }


        public static string DESEncrypt(string data, string key)
        {
            DESCryptoServiceProvider keyProvider = new DESCryptoServiceProvider();

            keyProvider.IV = Encoding.Default.GetBytes(key);
            keyProvider.Key = Encoding.Default.GetBytes(key);

            return Convert.ToBase64String(DESEncrypt(data, keyProvider));
        }


        // Decrypt the byte array.
        public static string DESDecrypt(byte[] CypherText, SymmetricAlgorithm key)
        {
            // Create a memory stream to the passed buffer.
            MemoryStream ms = new MemoryStream(CypherText);

            // Create a CryptoStream using the memory stream and the 
            // CSP DES key. 
            CryptoStream encStream = new CryptoStream(ms, key.CreateDecryptor(), CryptoStreamMode.Read);

            // Create a StreamReader for reading the stream.
            StreamReader sr = new StreamReader(encStream);

            // Read the stream as a string.
            string val = sr.ReadToEnd();
            if (val.EndsWith("\r\n"))
            {
                val = val.Replace("\r\n", "");
            }
            // Close the streams.
            ms.Close();


            return val;
        }


        public static string DESDecrypt(string dataBase64, string key)
        {
            DESCryptoServiceProvider keyProvider = new DESCryptoServiceProvider();

            keyProvider.IV = Encoding.Default.GetBytes(key);
            keyProvider.Key = Encoding.Default.GetBytes(key);

            return DESDecrypt(Convert.FromBase64String(dataBase64), keyProvider);

        }


        #endregion

        #region AES加解密

        /// <summary>  
        /// 密钥(32位,不足在后面补0)  
        /// </summary>  

        /// <summary>  
        /// 运算模式  
        /// </summary>  
        private static CipherMode _cipherMode = CipherMode.ECB;
        /// <summary>  
        /// 填充模式  
        /// </summary>  
        private static PaddingMode _paddingMode = PaddingMode.PKCS7;
        /// <summary>  
        /// 字符串采用的编码  
        /// </summary>  
        private static Encoding _encoding = Encoding.UTF8;

        /// <summary>  
        /// 获取32byte密钥数据  
        /// </summary>  
        /// <param name="password">密码</param>  
        /// <returns></returns>  
        private static byte[] GetKeyArray(string password)
        {
            if (password == null)
            {
                password = string.Empty;
            }
            if (password.Length < 32)
            {
                password = password.PadRight(32, '0');
            }
            else if (password.Length > 32)
            {
                password = password.Substring(0, 32);
            }
            return _encoding.GetBytes(password);
        }

        /// <summary>  
        /// 将字符数组转换成字符串  
        /// </summary>  
        /// <param name="inputData"></param>  
        /// <returns></returns>  
        private static string ConvertByteToString(byte[] inputData)
        {
            StringBuilder sb = new StringBuilder(inputData.Length * 2);
            foreach (var b in inputData)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>  
        /// 将字符串转换成字符数组  
        /// </summary>  
        /// <param name="inputString"></param>  
        /// <returns></returns>  
        private static byte[] ConvertStringToByte(string inputString)
        {
            if (inputString == null || inputString.Length < 2)
            {
                throw new ArgumentException();
            }
            int l = inputString.Length / 2;
            byte[] result = new byte[l];
            for (int i = 0; i < l; ++i)
            {
                result[i] = Convert.ToByte(inputString.Substring(2 * i, 2), 16);
            }
            return result;
        }

        /// <summary>  
        /// 加密字节数据  
        /// </summary>  
        /// <param name="inputData">要加密的字节数据</param>  
        /// <param name="password">密码</param>  
        /// <returns></returns>  
        public static byte[] Encrypt(byte[] inputData, string password)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.Key = GetKeyArray(password);
            aes.Mode = _cipherMode;
            aes.Padding = _paddingMode;
            ICryptoTransform transform = aes.CreateEncryptor();
            byte[] data = transform.TransformFinalBlock(inputData, 0, inputData.Length);
            aes.Clear();
            return data;
        }

        /// <summary>  
        /// 加密字符串(加密为16进制字符串)  
        /// </summary>  
        /// <param name="inputString">要加密的字符串</param>  
        /// <param name="password">密码</param>  
        /// <returns></returns>  
        public static string Encrypt(string inputString, string password)
        {
            byte[] toEncryptArray = _encoding.GetBytes(inputString);
            byte[] result = Encrypt(toEncryptArray, password);
            return ConvertByteToString(result);
        }

        /// <summary>  
        /// 字符串加密(加密为16进制字符串)  
        /// </summary>  
        /// <param name="inputString">需要加密的字符串</param>  
        /// <returns>加密后的字符串</returns>  
        public static string EncryptString(string inputString, string passwd)
        {
            return Encrypt(inputString, passwd);
        }

        /// <summary>  
        /// 解密字节数组  
        /// </summary>  
        /// <param name="inputData">要解密的字节数据</param>  
        /// <param name="password">密码</param>  
        /// <returns></returns>  
        public static byte[] Decrypt(byte[] inputData, string password)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.Key = GetKeyArray(password);
            aes.Mode = _cipherMode;
            aes.Padding = _paddingMode;
            ICryptoTransform transform = aes.CreateDecryptor();
            byte[] data = null;
            try
            {
                data = transform.TransformFinalBlock(inputData, 0, inputData.Length);
            }

            catch
            {
                return null;
            }
            aes.Clear();
            return data;
        }

        /// <summary>  
        /// 解密16进制的字符串为字符串  
        /// </summary>  
        /// <param name="inputString">要解密的字符串</param>  
        /// <param name="password">密码</param>  
        /// <returns>字符串</returns>  
        public static string Decrypt(string inputString, string password)
        {
            byte[] toDecryptArray = ConvertStringToByte(inputString);
            string decryptString = _encoding.GetString(Decrypt(toDecryptArray, password));
            return decryptString;
        }

        /// <summary>  
        /// 解密16进制的字符串为字符串  
        /// </summary>  
        /// <param name="inputString">需要解密的字符串</param>  
        /// <returns>解密后的字符串</returns>  
        public static string DecryptString(string inputString, string passwd)
        {
            return Decrypt(inputString, passwd);
        }

        #endregion

    }
}