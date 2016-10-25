using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulv.YCF.Payment.Wing.H5ForM
{
    public class RsaKeyBO
    {
        private string aesIndex;

        private string aesRandomId;
        /** 索引号 */
        private String keyIndex;

        /** 公钥 */
        private String pubKey;

        /** 私钥 */
        private String privKey;
        
        private string sessionId { get; set; }

        private int waitTime { get; set; }

        public string KeyIndex { get { return keyIndex; } set { keyIndex = value; } }

        public string PubKey { get { return pubKey; } set { pubKey = value; } }

        public string PrivKey { get { return privKey; } set { privKey = value; } }
    }

    public class PublicKeyData {
        public RsaKeyBO Result { get; set; }

        public bool Success { get; set; }
    }
}
