using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OneCoin.Service.Helper.Encrypt
{
    /// <summary>
    /// 加密方法
    /// </summary>
    public enum EncryptionAlgorithm
    {
        None,
        DES,
        Rc2,
        Rijndael,
        TripleDes
    }

    /// <summary>
    /// 加密引擎
    /// </summary>
    public class Encryption
    {
        #region Other Encryption
        public static string MD5( string str )
        {
            str = str ?? string.Empty;
#pragma warning disable 612,618
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile( str, "MD5" );
#pragma warning restore 612,618
            /*
            if( code == 16 )
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile( str, "MD5" ).ToLower().Substring( 8, 16 );
            }
            else if( code == 32 )
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile( str, "MD5" );
            }
            else
            {
                return "00000000000000000000000000000000";
            }
            */
            // return "00000000000000000000000000000000";
        }
        #endregion

        #region Property
        /// <summary>
        /// 加密算法
        /// </summary>
        public EncryptionAlgorithm Algoritm
        {
            get;
            set;
        }

        /// <summary>
        /// 加密向量
        /// </summary>
        public byte[] IV
        {
            get;
            set;
        }

        /// <summary>
        /// 加密键
        /// </summary>
        public byte[] EncryptionKey
        {
            get;
            set;
        }
        #endregion

        #region Construct
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="iAlgID">加密算法</param>
        /// <param name="iKey">加密键</param>
        public Encryption( EncryptionAlgorithm algorithm, string cryptKey )
            : this( algorithm, cryptKey, string.Empty )
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="iAlgID">加密算法</param>
        /// <param name="iKey">加密键</param>
        /// <param name="iIV">加密向量</param>
        public Encryption( EncryptionAlgorithm algorithm, string cryptKey, string cryptIV )
        {
            Algoritm = algorithm;
            EncryptionKey = Encoding.ASCII.GetBytes( cryptKey ?? string.Empty );
            IV = Encoding.ASCII.GetBytes( cryptIV ?? string.Empty );
        }
        #endregion

        #region CryptoTransformer
        /// <summary>
        /// 构造加密对象
        /// </summary>
        /// <returns></returns>
        private ICryptoTransform GetEncryptor()
        {
            if( this.EncryptionKey.Length == 0 && this.IV.Length == 0 )
            {
                return null;
            }

            switch( Algoritm )
            {
                case EncryptionAlgorithm.DES:
                    DES des = new DESCryptoServiceProvider();
                    des.Mode = CipherMode.CBC;
                    if( this.EncryptionKey.Length > 0 )
                    {
                        des.Key = this.EncryptionKey;
                    }
                    if( this.IV.Length > 0 )
                    {
                        des.IV = this.IV;
                    }
                    return des.CreateEncryptor();
                case EncryptionAlgorithm.Rc2:
                    RC2 rc = new RC2CryptoServiceProvider();
                    rc.Mode = CipherMode.CBC;
                    if( this.EncryptionKey.Length > 0 )
                    {
                        rc.Key = this.EncryptionKey;
                    }
                    if( this.IV.Length > 0 )
                    {
                        rc.IV = this.IV;
                    }
                    return rc.CreateEncryptor();
                case EncryptionAlgorithm.Rijndael:
                    Rijndael rj = new RijndaelManaged();
                    rj.Mode = CipherMode.CBC;
                    if( this.EncryptionKey.Length > 0 )
                    {
                        rj.Key = this.EncryptionKey;
                    }
                    if( this.IV.Length > 0 )
                    {
                        rj.IV = this.IV;
                    }
                    return rj.CreateEncryptor();
                case EncryptionAlgorithm.TripleDes:
                    TripleDES tDes = new TripleDESCryptoServiceProvider();
                    // tDes.Mode = CipherMode.CBC;
                    if( this.EncryptionKey.Length > 0 )
                    {
                        tDes.Key = this.EncryptionKey;
                    }
                    if( this.IV.Length > 0 )
                    {
                        tDes.IV = this.IV;
                    }
                    return tDes.CreateEncryptor();
                default:
                    throw new Exception( string.Empty );
            }
        }

        /// <summary>
        /// 构造解密对象
        /// </summary>
        /// <returns></returns>
        private ICryptoTransform GetDecryptor()
        {
            if( this.EncryptionKey.Length == 0 && this.IV.Length == 0 )
            {
                return null;
            }

            switch( Algoritm )
            {
                case EncryptionAlgorithm.DES:
                    DES des = new DESCryptoServiceProvider();
                    des.Mode = CipherMode.CBC;
                    if( this.EncryptionKey.Length > 0 )
                    {
                        des.Key = this.EncryptionKey;
                    }
                    if( this.IV.Length > 0 )
                    {
                        des.IV = this.IV;
                    }
                    return des.CreateDecryptor();
                case EncryptionAlgorithm.Rc2:
                    RC2 rc = new RC2CryptoServiceProvider();
                    rc.Mode = CipherMode.CBC;
                    if( this.EncryptionKey.Length > 0 )
                    {
                        rc.Key = this.EncryptionKey;
                    }
                    if( this.IV.Length > 0 )
                    {
                        rc.IV = this.IV;
                    }
                    return rc.CreateDecryptor();
                case EncryptionAlgorithm.Rijndael:
                    Rijndael rj = new RijndaelManaged();
                    rj.Mode = CipherMode.CBC;
                    if( this.EncryptionKey.Length > 0 )
                    {
                        rj.Key = this.EncryptionKey;
                    }
                    if( this.IV.Length > 0 )
                    {
                        rj.IV = this.IV;
                    }
                    return rj.CreateDecryptor();
                case EncryptionAlgorithm.TripleDes:
                    TripleDES tDes = new TripleDESCryptoServiceProvider();
                    tDes.Mode = CipherMode.CBC;
                    if( this.EncryptionKey.Length > 0 )
                    {
                        tDes.Key = this.EncryptionKey;
                    }
                    if( this.IV.Length > 0 )
                    {
                        tDes.IV = this.IV;
                    }
                    return tDes.CreateDecryptor();
                default:
                    throw new CryptographicException( "Algorithm " + Algoritm + " Not Supported!" );
            }
        }
        #endregion

        #region Static Method
        public static string Encrypt( string key, string iv, string data )
        {
            string code = Encrypt( EncryptionAlgorithm.TripleDes, key, iv, data );
            code = code.Replace("/", "_").Replace("+", "*").Replace("=", "-");
            return code;
        }

        public static string Encrypt( EncryptionAlgorithm algorithm, string key, string iv, string data )
        {
            Encryption encrypt = new Encryption( algorithm, key, iv );
            return encrypt.Encrypt( data );
        }

        public static string Decrypt( string key, string iv, string data )
        {
            string code = data.Replace("_", "/").Replace("*", "+").Replace("-", "=");
            return Decrypt(EncryptionAlgorithm.TripleDes, key, iv, code);
        }

        public static string Decrypt( EncryptionAlgorithm algorithm, string key, string iv, string data )
        {
            Encryption encrypt = new Encryption( algorithm, key, iv );
            return encrypt.Decrypt( data );
        }
        #endregion

        #region Base64 Convert
        /// <summary>
        /// 二进制数据序列化到Base64String
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToBase64String( byte[] bytes )
        {
            return Convert.ToBase64String( bytes );
        }

        /// <summary>
        /// Base64string反序列化到二进制数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] Base64StringToBytes( string str )
        {
            return Convert.FromBase64String( str );
        }
        #endregion

        #region Class Member
        /// <summary>
        /// 根据设定的加密算法、加密向量进行解密
        /// </summary>
        /// <param name="encrptedString">需要解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public string Decrypt(string encrptedString)
        {

            byte[] buffer = Convert.FromBase64String(encrptedString); //System.Text.Encoding.UTF8.GetBytes( encrptedString.Trim() );
            if (buffer == null || buffer.Length == 0)
            {
                return string.Empty;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                var decryptor = GetDecryptor();
                if (decryptor == null)
                {
                    return encrptedString;
                }
                CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write);
                cs.Write(buffer, 0, buffer.Length);
                cs.FlushFinalBlock();

                return Encoding.Unicode.GetString(ms.ToArray());
            }
        }

        /// <summary>
        /// 根据设定的加密算法、加密向量进行解密
        /// </summary>
        /// <param name="encrptedString">需要解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public string Encrypt(string unencrptString)
        {

            var encryptor = GetEncryptor();
            if (encryptor == null)
            {
                return unencrptString;
            }
            byte[] buffer = System.Text.Encoding.Unicode.GetBytes(unencrptString.Trim());
            if (buffer == null || buffer.Length == 0)
            {
                return string.Empty;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
                cs.Write(buffer, 0, buffer.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray()); //Encoding.Unicode.GetString( buffer );
            }
        }
        #endregion

        #region Validate
        /// <summary>
        /// 加密键是否合法
        /// </summary>
        /// <param name="algID">加密算法</param>
        /// <param name="Lenght">加密键长度</param>
        /// <returns>true：合法，否则false</returns>
        public static bool ValidateKeySize( EncryptionAlgorithm algorithm, int Lenght )
        {
            switch( algorithm )
            {
                case EncryptionAlgorithm.DES:
                    DES des = new DESCryptoServiceProvider();
                    return des.ValidKeySize( Lenght );
                case EncryptionAlgorithm.Rc2:
                    RC2 rc = new RC2CryptoServiceProvider();
                    return rc.ValidKeySize( Lenght );
                case EncryptionAlgorithm.Rijndael:
                    Rijndael rj = new RijndaelManaged();
                    return rj.ValidKeySize( Lenght );
                case EncryptionAlgorithm.TripleDes:
                    TripleDES tDes = new TripleDESCryptoServiceProvider();
                    return tDes.ValidKeySize( Lenght );
                default:
                    throw new CryptographicException( "Algorithm " + algorithm + " Not Supported!" );
            }
        }
        #endregion
    }
}
