using System;
using System.Collections.Generic;
using System.Text;
using Kulv.YCF.Payment.Wing;
using Kulv.YCF.Payment.Wing.H5ForM;
using OneCoin.Payment.Entity;
using OneCoin.Payment.Plugins.BestPay.Core;
using OneCoin.Payment.Plugins.BestPay.Core.Res;
using OneCoin.Service.Helper.Encrypt;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Helper.Serialization;
using OneCoin.Service.Model.Entity.Payment;
using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Payment.Plugins.BestPayH5
{
    public class BestPayMobile : PayBase, IPayment
    {
        public BestPayMobile()
            : base(PaymentType.BestPayMobile)
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


                var response = Query(BestPayMobileConfig.CommOrderQueryUrl, payDto.PostString());
                LogHelper.Add(string.Format("BestPayMobile OrderQuery response : {0}", response));


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
                LogHelper.Add("bool BestPayMobile.Query(PurchaseReq req, ref PurchaseRes res)", ex);
                return false;
            }
        }

        public bool GetPurchaseNo(PurchaseReq req, ref PurchaseRes res)
        {
            res.CarNo = req.CarNo;
            res.Description = string.IsNullOrEmpty(req.Description) ? "宜泊支付" : req.Description;

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


            var payConfig = GetConfig(req.ParkCode, req.Purpose);


            #region M版
            var h5Util = WingCryptToolFactory.GetCryptTool(false) as H5Util;

            h5Util.MERCHANTkey = payConfig.Md5Key;
            h5Util.MERCHANTID = payConfig.MchId;
            h5Util.MERCHANTPWD = payConfig.EncrypCer;

            var ORDERSEQ = req.OrderNo;                                //订单号
            var ORDERREQTRANSEQ = req.OrderNo;                         //订单请求交易流水号
            var ORDERTIME = req.OrderTime.ToString("yyyyMMddHHmmss"); //订单日期

#if !DEBUG
            var ORDERAMOUNT = req.OrderMoney.ToString("0.00"); //产品金额(分)
#else
            var ORDERAMOUNT =  (req.OrderMoney/1000).ToString("0.00"); //产品金额(分)

#endif


            string BACKMERCHANTURL = BestPayMobileConfig.BackmerchantUrl;
            string BEFOREMERCHANTURL = req.MerchantUrl;
            string ORDERVALIDITYTIME = req.OrderTime.AddMonths(15).ToString("yyyyMMddHHmmss");


            //TODO:初始化下单和支付参数、下单、加密、生成翼支付支付地址
            var webUrl = h5Util.InitParameters(ORDERSEQ, ORDERREQTRANSEQ, ORDERTIME, ORDERAMOUNT, req.Description, "宜泊支付",
                "13099999999", BEFOREMERCHANTURL, BACKMERCHANTURL, ORDERVALIDITYTIME).CreateOrder().Encrypt().CreateRequestUrl();


            res.ExtraParam = new
            {
                payweburl = webUrl,
                postData = string.Empty
            };

            #endregion

            return true;
        }

        public bool IsEnableCancel { get { return true; } }


        public bool CancelOrder(ref CanceledPaymentInfo info)
        {
            try
            {
                var payConfig = GetConfig(info.ParkCode, info.Purpose);
                info.CancelOrderNo = Spanner.DateTimeToStamp(DateTime.Now).ToString();

                var refundDto = new PayRefundDto
                {
                    channel = "01",
                    //ledgerDetail = "",
                    merchantId = payConfig.MchId,
                    merchantPwd = payConfig.EncrypCer,
                    oldOrderNo = info.OrderNo,
                    oldOrderReqNo = info.OrderNo,
                    refundReqDate = DateTime.Now.ToString("yyyyMMdd"),
                    refundReqNo = info.CancelOrderNo,
                    //subMerchantId = "",
#if DEBUG
                    transAmt = ((int)(info.OrderMoney)).ToString()
#else
                    transAmt = ((int)(info.OrderMoney*100)).ToString()
#endif

                };

                refundDto.mac = EncryptMgr.MD5(refundDto.GenricSource(payConfig.Md5Key, payConfig.EncrypCer));


                var postString = refundDto.PostString();

                LogHelper.Add(string.Format("BestPayMobile Refund request : {0}", postString));
                string response = Query(BestPayMobileConfig.PayRefundUrl, postString);
                LogHelper.Add(string.Format("BestPayMobile Refund response : {0}", response));



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
                LogHelper.Add("bool BestPayMobile.CancelOrder(ref Host.CanceledPaymentInfo info), ErrMsg:{0}", ex);
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
                        var orderMoney = decimal.Parse(callBackDto.PRODUCTAMOUNT); //订单金额
                        var tradeNo = callBackDto.UPTRANSEQ; //支付订单号
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

                        LogHelper.Add(string.Format("BestPayMobile.CheckNotify {0}\r\n{1}", "验证失败", strObj));
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
