using System.Globalization;
using OneCoin.Payment.Plugins.BestPay.Core.Res;
using OneCoin.Service.Helper.Encrypt;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Serialization;

namespace OneCoin.Payment.Plugins.BestPay
{
    public class BestPayCore
    {
        #region 时间戳生成接口
        /// <summary>
        /// 时间戳生成接口
        /// </summary>
        /// <param name="merchantid"></param>
        /// <param name="orderseq"></param>
        /// <param name="orderreqtranseq"></param>
        /// <param name="signKey"></param>
        /// <returns></returns>
        internal static string CreateTimeStamp(string merchantid, string orderseq, string orderreqtranseq,string signKey)
        {
            // 签名源
            var signSource = string.Format("MERCHANTID={0}&ORDERSEQ={1}&ORDERREQSEQ={2}&KEY={3}", merchantid,orderseq, orderreqtranseq, signKey);
            var mac = EncryptMgr.MD5(signSource);

            // 提交的数据
            var data = string.Format("MERCHANTID={0}&ORDERSEQ={1}&ORDERREQTRANSEQ={2}&MAC={3}", merchantid, orderseq,
                                     orderreqtranseq, mac.ToUpper(CultureInfo.CurrentCulture));

            // 提交到接口
            var hc = new HttpClient(BestPayConfig.CreateTimeStampUrl) {PostString = data};
            var ret = hc.GetString();

            // 查询返回的数据
            var retObj = SimpleSerialization.JsonToObject<ResCreateTimeStamp>(ret);
            if (retObj != null && retObj.Success)
            {
                // 返回时间戳数据
                return retObj.Result;
            }

            // 失败，返回空
            return string.Empty;
        }
        #endregion
    }
}
