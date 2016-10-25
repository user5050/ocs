using System;
using System.Security.Cryptography;
using System.Text;

namespace Kulv.YCF.Payment.Wing
{
    public class CryptTool
    {
        public CryptTool()
        {
            MERCHANTID = "";                   //商户号
            MERCHANTkey = "";                   //商户KEY;
            SERVICE = "mobile.securitypay.pay";
            MERCHANTPWD = "";
        }

        public string SERVICE
        {
            get; protected set;
        }

        public string MERCHANTPWD
        {
            get;
            set;
        }

        public string MERCHANTID
        {
            get;  set;
        }
        public string MERCHANTkey
        {
            get;  set;
        }

        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        public string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public bool verifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = getMd5Hash(input);

            // Create a StringComparer an comare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
// This code example produces the following output:
//
// The MD5 hash of Hello World! is: ed076287532e86365e841e92bfc50d8c.
// Verifying the hash...
// The hashes are the same.