using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;
using System.Text;
using OneCoin.Service.Helper.Encrypt;
using OneCoin.Service.Helper.Log;


namespace upacp_sdk_net.com.unionpay.sdk
{

    public class CertUtil
    {

        /// <summary>
        /// 获取签名证书私钥
        /// </summary>
        /// <returns></returns>
        public static RSACryptoServiceProvider GetSignProviderFromPfx(string pfx, string pfxPwd)
        {  
            var pc = new X509Certificate2(EncryptMgr.FromBase64String(pfx), pfxPwd, X509KeyStorageFlags.MachineKeySet);

            return (RSACryptoServiceProvider)pc.PrivateKey;
        }

        /// <summary>
        /// 获取签名证书的证书序列号
        /// </summary>
        /// <returns></returns>
        public static string GetSignCertId(string pfx, string pfxPwd)
        {
            var pc = new X509Certificate2(EncryptMgr.FromBase64String(pfx), pfxPwd, X509KeyStorageFlags.MachineKeySet);

            return BigInteger.Parse(pc.SerialNumber, System.Globalization.NumberStyles.HexNumber).ToString();
        }

        /// <summary>
        /// 获取加密证书的证书序列号
        /// </summary>
        /// <returns></returns>
        public static string GetEncryptCertId(string encrptCer)
        {
            var pc = new X509Certificate2(EncryptMgr.FromBase64String(encrptCer)); 
            return BigInteger.Parse(pc.SerialNumber, System.Globalization.NumberStyles.HexNumber).ToString();
        }

        /// <summary>
        /// 通过证书id，获取验证签名的证书
        /// </summary>
        /// <param name="publicCer"></param>
        /// <returns></returns>
        public static RSACryptoServiceProvider GetValidateProviderFromPath(string publicCer)
        {
            var pc = new X509Certificate2(EncryptMgr.FromBase64String(publicCer));

            return (RSACryptoServiceProvider)pc.PublicKey.Key;
        }

    }
}