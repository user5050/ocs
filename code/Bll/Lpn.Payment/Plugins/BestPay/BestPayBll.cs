using System;
using System.Collections.Generic;
using System.Text;
using OneCoin.Payment.Entity;
using OneCoin.Payment.Plugins.BestPay.Core;
using OneCoin.Payment.Plugins.BestPay.Core.Res;
using OneCoin.Service.Helper.Encrypt;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Helper.Serialization;
using OneCoin.Service.Model.Entity.Payment;
using OneCoin.Service.Model.Enum.Payment;

/*
 * 错误码	描述	备注
-309	校验商户调用密码出错	
-301	校验商户MAC校验域出错	
1002	商户未配置密钥信息	
BE100002	受理机构代码为空	
BE110028	分账信息有误	
BE110062	没有找到符合条件的记录。	原订单不存在
BE199999	请求参数有误	具体的参数错误，在描述中有体现
BE300000	商户不存在	
BE300006	受理机构未配置此交易权限	原支付机构不支持退款
BE300007	商户未配置此交易权限	商户没有给定渠道的普通退款权限
BE300012	分账金额总和不等于订单总金额	
BE300013	商户IP验证异常	
BE300018	订单不支持部分扣款	原订单支付机构不支持部分退款
BE301001	订单金额出现异常，交易失败	退款金额不符合要求
BE301007	不支持批量支付订单的退款，退款失败	
BE301008	订单的业务类型不支持退款，退款失败	
BE301009	订单状态不为成功，退款失败	
BE301010	退款订单受理中，退款失败	
BE301011	订单已退款或冲正，退款失败	
BE999999	系统繁忙，请稍后再试 	系统原因，联系技术支协查
 * 
 */

namespace OneCoin.Payment.Plugins.BestPay
{
    public class BestPay : PayBase, IPayment
    {
        public BestPay()
            : base(PaymentType.BestPay)
        {
        }

        public bool Query(PurchaseQueryReq req, ref PurchaseQueryRes res)
        {
            try
            {
                res.OrderNo = req.OrderNo;
                res.OrderTime = req.OrderTime;

                var payConfig = GetConfig(req.ParkCode, req.Purpose);
                var payDto = new PayQueryDto
                    {
                        COMMCODE = payConfig.MchId,
                        ORDERREQTRANSEQ = req.OrderNo,
                        ORDERSEQ = req.OrderNo
                    };

                payDto.MAC = EncryptMgr.MD5(payDto.GenricSource(payConfig.Md5Key));


                var response = Query(BestPayConfig.CommOrderQueryUrl, payDto.PostString());
                LogHelper.Add(string.Format("BestPay OrderQuery response : {0}", response));


                var result = SimpleSerialization.XmlToObject<result>(response);
                var ret = result;

                /*查询接口状态：
                0：成功查询到数据
                1：未找到记录
                9：MAC错误或系统忙，请稍后再试
                 * */
                if (ret != null)
                {
                    if (ret.RETURNCODE == "0")
                    {
                        if (ret.TRANSTATUS == "B")
                        {
                            res.OrderMoney = float.Parse(ret.ORDERAMOUNT) / 100;
                            res.QN = ret.OURTRANSNO;
                            res.Result = true;

                            return true;
                        }
                    }
                    //else if (ret.RETURNCODE == "1")
                    //{
                    //    res.IsCanDelOrder = true;
                    //}
                }

                res.Result = false;
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Add("bool PayBase.Query(PurchaseReq req, ref PurchaseRes res)", ex);
                return false;
            }
        }

        public bool GetPurchaseNo(PurchaseReq req, ref PurchaseRes res)
        {
            try
            {
                res.CarNo = req.CarNo;
                res.Description = req.Description;

                res.OrderMoney = req.OrderMoney;
                res.OrderNo = req.OrderNo;
                res.OrderTime = req.OrderTime;
                res.ParkCode = req.ParkCode;
                res.Purpose = req.Purpose;
                res.Description = req.Description;

                res.EntranceTime = req.EntranceTime;
                res.ExitTime = req.ExitTime;

                res.TillDate = req.TillDate;
                res.RenewalMonths = req.RenewalMonths;

                res.PaymentType = req.PaymentType;
                res.UserId = req.UserId;
                res.Result = 1;

                var data = new PayWebDto();
                var payConfig = GetConfig(res.ParkCode, res.Purpose);


                data.MERCHANTID = payConfig.MchId;//商户ID：
                data.SUBMERCHANTID = "";//商户子商户ID：
                data.ORDERSEQ = req.OrderNo;//订单号：
                data.ORDERREQTRANSEQ = req.OrderNo;//订单请求交易流水号：
                data.ORDERDATE = req.OrderTime.ToString("yyyyMMddhhmmss");//订单日期：


#if !DEBUG
                data.PRODUCTAMOUNT= ((int)(req.OrderMoney * 100)).ToString(); //产品金额(分)
#else
                data.PRODUCTAMOUNT = ((int)(req.OrderMoney / 10)).ToString(); //产品金额(分)

#endif

                data.ATTACHAMOUNT = "0";//附加金额(分)：
                data.ORDERAMOUNT = data.PRODUCTAMOUNT; //产品金额(分)
                data.CURTYPE = "RMB";//币种：
                data.ENCODETYPE = "1";  //加密方式
                data.MERCHANTURL = req.MerchantUrl;//交易返回的url地址
                data.BACKMERCHANTURL = BestPayConfig.BackmerchantUrl;//后台返回地址
                data.ATTACH = req.Description;//商户附加信息
                data.BUSICODE = "0001";//默认填0001
                data.PRODUCTID = "";//业务标识：
                data.TMNUM = "";//终端号码：
                data.CUSTOMERID = "";//客户标识：
                data.PRODUCTDESC = "";//产品描述：
                data.DIVDETAILS = "";//分账商户必填，格式参看 说明5：分账明细说明
                data.PEDCNT = "";//分期数：
                data.CLIENTIP = req.ClientIp;//用户在访问商户网站时的IP
                data.MAC = EncryptMgr.MD5(data.GenricSource(payConfig.Md5Key));//签名
                data.TIMESTAMP = BestPayCore.CreateTimeStamp(data.MERCHANTID, data.ORDERSEQ, data.ORDERREQTRANSEQ, payConfig.Md5Key);

                res.ExtraParam = new
                    {
                        payweburl = BestPayConfig.PayWebUrl,
                        postData = data
                    };
            }
            catch (Exception ex)
            {
                LogHelper.Add("bool BestPayBll.GetPurchaseNo(PurchaseReq req, ref PurchaseRes res)", ex);
                return false;
            }

            return true;
        }


        public bool IsEnableCancel
        {
            get { return true; }
        }

        public bool CancelOrder(ref CanceledPaymentInfo info)
        {
            try
            {  
                var payConfig = GetConfig(info.ParkCode, info.Purpose);
                info.CancelOrderNo = Spanner.DateTimeToStamp(DateTime.Now).ToString();

                var refundDto = new PayRefundDto
                    {
                        channel="01",
                        //ledgerDetail = "",
                        merchantId = payConfig.MchId,
                        merchantPwd = payConfig.EncrypCer,
                        oldOrderNo = info.OrderNo,
                        oldOrderReqNo = info.OrderNo,
                        refundReqDate = DateTime.Now.ToString("yyyyMMdd"),
                        refundReqNo = info.CancelOrderNo,
                        //subMerchantId = "",
#if DEBUG
                        transAmt = ((int)(info.OrderMoney / 10)).ToString()
#else
                        transAmt = ((int)(info.OrderMoney*100)).ToString()
#endif

                    };

                refundDto.mac = EncryptMgr.MD5(refundDto.GenricSource(payConfig.Md5Key, payConfig.EncrypCer));


                var postString = refundDto.PostString();

                LogHelper.Add(string.Format("BestPay Refund request : {0}", postString));
                string response = Query(BestPayConfig.PayRefundUrl, postString);
                LogHelper.Add(string.Format("BestPay Refund response : {0}", response));



                // 查询返回的数据
                var retObj = SimpleSerialization.JsonToObject<ResCreateTimeStamp>(response);
                if (retObj != null)
                {  
                    if (retObj.Success)
                    {
                        // 返回时间戳数据
                        return true;
                    }
                    else if (retObj.errorCode == "BE301010")//退款订单受理中，退款失败	
                    {
                        return true;
                    }
                    else if (retObj.errorCode == "BE301011")//订单已退款或冲正，退款失败
                    {
                        return true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                LogHelper.Add("bool BestPay.CancelOrder(ref Host.CanceledPaymentInfo info), ErrMsg:{0}", ex); 
            }

            return false;
        }

        public string GetOrderNo(IDictionary<string, string> param)
        {
            if (param != null && param.ContainsKey("ORDERSEQ"))
            {
                return param["ORDERSEQ"];
            }

            return string.Empty;
        }

        public bool CancelOrderQuery(ref CanceledPaymentInfo info)
        {
            // 翼支付未提供查询撤费订单状态接口
            return !string.IsNullOrEmpty(info.CancelOrderNo);
        }

        public PurchaseNotify CheckNotify(CallBackPaymentInfo info)
        {
            PurchaseNotify retObj = null;
            try
            {
                var param = info.Param;

                if (param.Count > 0)
                {
                    var payConfig = GetConfig(info.ParkCode, info.Purpose);
                    var callBackDto = PayCallBackDto.Parse(param);

                    if (VerifyResult(callBackDto, payConfig))
                    {
                        var orderNo = callBackDto.ORDERSEQ; //商户订单号
                        var orderMoney = decimal.Parse(callBackDto.PRODUCTAMOUNT) / 100; //订单金额
                        var tradeNo = callBackDto.UPTRANSEQ; //微信支付订单号
                        var retnCode = callBackDto.RETNCODE; //由翼支付网关平台统一定义，商户需保存，作为对帐数据。结果码为“0000” 表示支付成功，其他值则表示支付失败 
                        var retnInfo = callBackDto.RETNINFO; //由翼支付网关平台统一定义，对支付结果的说明码 

                        if (retnCode == "0000")
                        {
                            retObj = new PurchaseNotify { OrderNo = orderNo, OrderMoney = orderMoney, Qn = tradeNo, Description = string.Format("UPTRANSEQ_{0}", callBackDto.UPTRANSEQ) };
                        }
                    }
                    else
                    {
                        #region 打印调试日志
                        var strObj = new StringBuilder();
                        foreach (var key in param.Keys)
                            strObj.AppendFormat("{0}:{1}\r\n", key, param[key]);

                        LogHelper.Add(string.Format("BestPay.CheckNotify {0}\r\n{1}", "验证失败", strObj));
                        #endregion
                    }
                }

                return retObj;
            }
            catch (Exception ex)
            {
                LogHelper.Add("翼支付回调异常", ex);
                return retObj;
            }

        }

        public CanceledPaymentInfo CheckCancelNotify(CallBackPaymentInfo info)
        {
            return null;
        }

        public string PayName()
        {
            return "翼支付";
        }
    }
}
