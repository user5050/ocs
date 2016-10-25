using Lpn.Service.Helper.Log;
using Lpn.Service.Helper.Serialization;
using Lpn.Service.TrdPart.Partner.Core.Interface;
using Lpn.Service.TrdPart.Partner.Core.Interface.Model;
using Lpn.Service.TrdPart.Partner.Ykb.Core;
using Lpn.Service.TrdPart.Partner.Ykb.Model.Response;

namespace Lpn.Service.TrdPart.Partner.Ykb
{
    public class YkbApiMgr : ApiBase, IPartnerActivityAction
    {
        #region 下单
        /// <summary>
        /// 下单
        /// </summary>
        /// <returns></returns>
        private bool SyncWashOrder(SyncActivityDto reqData, out string msg)
        {
            LogHelper.Add("优快保下单" + SimpleSerialization.ObjectToJson(reqData));

            if (string.IsNullOrEmpty(reqData.carNo) ||
                string.IsNullOrEmpty(reqData.memberPhone) ||
                ( reqData.carType != 1 && reqData.carType != 2 ) ||
                string.IsNullOrEmpty(reqData.thirdTradeNo) ||
                reqData.memberPrice < 0
                )
            {
                msg = "参数错误";
                return false;
            }

            reqData.compToken = ConfigDef.Token;


            // 调用接口
            //0失败  1成功  502 表示订单已经处理过
            var ret = RemoteQuery<ResWarpper<ResGorderDto>>("/third/service/gorder", ConfigDef.Token, reqData);
            if (ret.state == 1)
            {
                msg = ret.data.OrderNo;
                return true;
            }

            //502 表示订单已经处理过
            if (ret.state == 502)
            {
                msg = "订单已经处理过";
                return true;
            }

            msg = ret.msg;
            return false;
        }
        #endregion

        #region 同步服务内容
        /// <summary>
        /// 同步服务内容
        /// </summary>
        /// <param name="a"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SyncActivity(SyncActivityDto a,out string msg)
        { 
            return SyncWashOrder(a, out msg);
        }

        public string PartnerId {
            get { return ConfigDef.PartnerId; }
        }

        #endregion
    }
}
