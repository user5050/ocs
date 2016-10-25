using System;
using System.Collections.Generic;
using System.Text;
using OneCoin.Payment.Entity;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Entity.Config;
using OneCoin.Service.Model.Entity.Payment;
using OneCoin.Service.Model.Enum.Payment;
using PCE.Payment.Plugins.Weixin;

namespace OneCoin.Payment.Plugins.Weixin
{
    public class WeixinPay : PayBase, IPayment
    {
        public WeixinPay()
            : base(PaymentType.WeixinPay)
        {
        }

        /// <summary>
        /// 查询支付是否成功
        /// </summary>
        /// <param name="req">查询的请求参数</param>
        /// <param name="res">查询结论的反馈</param>
        /// <returns>true=调用成功 false=调用失败</returns>
        public bool Query(PurchaseQueryReq req, ref PurchaseQueryRes res)
        {
            try
            {
                res.OrderNo = req.OrderNo;
                res.OrderTime = req.OrderTime;

                const string url = "https://api.mch.weixin.qq.com/pay/orderquery";
                var data = new WxPayData();
                var payConfig = GetConfig(req.ParkCode, req.Purpose, !req.IsWxApp);


                data.SetValue("out_trade_no", req.OrderNo);
                data.SetValue("appid", payConfig.AppId);//公众账号ID
                data.SetValue("mch_id", payConfig.MchId);//商户号
                data.SetValue("nonce_str", GenerateNonceStr());//随机字符串
                

#if DEBUG 
                //data.SetValue("sub_appid", "wx90bfb17d1fba6928"); //商品金额
#endif

                if (!string.IsNullOrEmpty(payConfig.SubMchId))
                {
                    data.SetValue("sub_mch_id", payConfig.SubMchId); //商品金额
                }

                data.SetValue("sign", data.MakeSign(payConfig));//签名



                string xml = data.ToXml();

                LogHelper.Add(string.Format("WxPayApi OrderQuery request : {0}", xml));
                string response = HttpService.Post(xml, url, false, 20, payConfig);//调用HTTP通信接口提交数据

                LogHelper.Add(string.Format("WxPayApi OrderQuery response : {0}", response));

                var result = new WxPayData();
                result.FromXml(response, payConfig);
                if (result.GetValue("return_code").ToString() == "SUCCESS")
                {
                    if (result.GetValue("result_code").ToString() != "SUCCESS")
                    {
                        return false;
                    }
                    if (result.GetValue("trade_state").ToString() != "SUCCESS")
                    {
                        return false;
                    }

                    res.OrderMoney = float.Parse(result.GetValue("cash_fee").ToString()) / 100;
                    res.QN = result.GetValue("transaction_id").ToString();
                    res.Result = true;
                    return true;
                }

                res.Result = false;
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Add("bool WeixinPay.Query(PurchaseReq req, ref PurchaseRes res)", ex);
                return false;
            }
        }

        /// <summary>
        /// 申请支付
        /// </summary>
        /// <param name="req">支付的请求参数</param>
        /// <param name="res">支付结论的反馈</param>
        /// <returns>true=调用成功 false=调用失败</returns>
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

                var data = new WxPayData();
                var isapp = req.WxpayType == 0;
                var payConfig = GetConfig(res.ParkCode, res.Purpose, !isapp);
                var openid = req.OpenId;// GetOpenidAndAccessTokenFromCode(req.Code);

                data.SetValue("body", req.Purpose.ToString());//商品描述
                data.SetValue("out_trade_no", req.OrderNo);//商家订单号

#if !DEBUG
                data.SetValue("total_fee", ((int)(req.OrderMoney * 100)).ToString()); //商品金额
                 
#else
                data.SetValue("total_fee", Math.Max(1,(int)(req.OrderMoney/10))); //商品金额 
                
#endif

                if (!string.IsNullOrEmpty(payConfig.SubMchId))
                {
                    data.SetValue("sub_mch_id", payConfig.SubMchId); //商品金额
                }


                data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
                data.SetValue("time_expire", DateTime.Now.AddMinutes(5).ToString("yyyyMMddHHmmss"));
                data.SetValue("trade_type", isapp ? "APP" : "JSAPI");

                if (!string.IsNullOrEmpty(req.ExtreGoodsTag))
                {
                    data.SetValue("goods_tag", req.ExtreGoodsTag);
                }

                //微信公众号
                if (!isapp) data.SetValue("openid", openid);

                data.SetValue("notify_url", WxAppPayConfig.NOTIFY_URL);
                data.SetValue("appid", payConfig.AppId);//公众账号ID
                data.SetValue("mch_id", payConfig.MchId);//商户号
                data.SetValue("spbill_create_ip", WxAppPayConfig.IP);//终端ip	  	    
                data.SetValue("nonce_str", GenerateNonceStr());//随机字符串
                data.SetValue("sign", data.MakeSign(payConfig));    //签名

                   

                var xml = data.ToXml();
                const string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
                LogHelper.Add(string.Format("GetPurchaseNo UnfiedOrder request : {0}", xml));
                var response = HttpService.Post(xml, url, false, 20, null);
                LogHelper.Add(string.Format("GetPurchaseNo UnfiedOrder response :{0} ", response));

                var result = new WxPayData();
                result.FromXml(response, payConfig);


                if (result.GetValue("return_code").ToString() != "SUCCESS")
                {
                    return false;
                }
                if (result.GetValue("result_code").ToString() != "SUCCESS")
                {
                    return false;
                }

                if (req.WxpayType == 0) //app支付
                {
                    //二次签名的时候涉及到的参数有appid,timestamp,noncestr,partnerid,prepayid，package,
                    //这6个参数全部是小写（大小写不同，MD5加密结果不一致，二次签名官方没有文档，比较坑）
                    var jsApiParam = new WxPayData();
                    jsApiParam.SetValue("appid", result.GetValue("appid"));
                    jsApiParam.SetValue("timestamp", GenerateTimeStamp());
                    jsApiParam.SetValue("noncestr", GenerateNonceStr());
                    jsApiParam.SetValue("partnerid", payConfig.MchId);
                    jsApiParam.SetValue("prepayid", result.GetValue("prepay_id"));
                    jsApiParam.SetValue("package", "Sign=WXPay");
                    jsApiParam.SetValue("paySign", jsApiParam.MakeSign(payConfig));

                    var apiParam = new WXAppRes
                        {
                            appId = jsApiParam.GetValue("appid").ToString(),
                            timeStamp = jsApiParam.GetValue("timestamp").ToString(),
                            nonceStr = jsApiParam.GetValue("noncestr").ToString(),
                            prepayid = jsApiParam.GetValue("prepayid").ToString(),
                            signType = "MD5",
                            paySign = jsApiParam.GetValue("paySign").ToString(),
                            package = jsApiParam.GetValue("package").ToString(),
                            partnerid = jsApiParam.GetValue("partnerid").ToString()
                        };
                    res.ExtraParam = apiParam;
                }
                else
                {
                    var jsApiParam = new WxPayData();
                    jsApiParam.SetValue("appId", result.GetValue("appid"));
                    jsApiParam.SetValue("timeStamp", GenerateTimeStamp());
                    jsApiParam.SetValue("nonceStr", GenerateNonceStr());
                    jsApiParam.SetValue("package", "prepay_id=" + result.GetValue("prepay_id"));
                    jsApiParam.SetValue("signType", "MD5");
                    jsApiParam.SetValue("paySign", jsApiParam.MakeSign(payConfig));

                    var apiParam = new WXRes
                        {
                            appId = jsApiParam.GetValue("appId").ToString(),
                            timeStamp = jsApiParam.GetValue("timeStamp").ToString(),
                            nonceStr = jsApiParam.GetValue("nonceStr").ToString(),
                            package = jsApiParam.GetValue("package").ToString(),
                            signType = jsApiParam.GetValue("signType").ToString(),
                            paySign = jsApiParam.GetValue("paySign").ToString()
                        };
                    res.ExtraParam = apiParam;
                }

                return true;

            }
            catch (Exception ex)
            {
                LogHelper.Add("bool WeixinPay.GetPurchaseNo(PurchaseReq req, ref PurchaseRes res), ErrMsg:{0}", ex);
                return false;
            }
        }

        /// <summary>
        ///申请退款（若撤费充值成功，则返回true，否则返回false要求重复尝试撤费申请）
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CancelOrder(ref CanceledPaymentInfo info)
        {
            try
            {
                var isApppay = info.IsWxApp;

                string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";

                var data = new WxPayData();
                var payConfig = GetConfig(info.ParkCode, info.Purpose, !isApppay);


                data.SetValue("out_trade_no", info.OrderNo);
                data.SetValue("out_refund_no", GenerateOutTradeNo(payConfig));//随机生成商户退款单号
                data.SetValue("op_user_id", payConfig.MchId);//操作员，默认为商户号
                data.SetValue("appid", payConfig.AppId);//appID
                data.SetValue("mch_id", payConfig.MchId);//商户号
                data.SetValue("nonce_str", Guid.NewGuid().ToString().Replace("-", ""));//随机字符串


#if !DEBUG
                data.SetValue("total_fee", (int)double.Parse((info.OrderMoney * 100).ToString()));//订单总金额
                data.SetValue("refund_fee", (int)double.Parse((info.OrderMoney * 100).ToString()));//退款金额
                 
#else 
                data.SetValue("total_fee", (int)double.Parse((info.OrderMoney /10).ToString()));//订单总金额
                data.SetValue("refund_fee", (int)double.Parse((info.OrderMoney / 10).ToString()));//退款金额

#endif


                if (!string.IsNullOrEmpty(payConfig.SubMchId))
                {
                    data.SetValue("sub_mch_id", payConfig.SubMchId); //商品金额
                }

                data.SetValue("sign", data.MakeSign(payConfig));//签名


                string xml = data.ToXml();



                LogHelper.Add(string.Format("WxPayApi Refund request : {0}", xml));
                string response = HttpService.Post(xml, url, true, 20, payConfig);//调用HTTP通信接口提交数据到API
                LogHelper.Add(string.Format("WxPayApi Refund response : {0}", response));

                var result = new WxPayData();
                result.FromXml(response, payConfig);

                if (result.GetValue("return_code").ToString() == "SUCCESS")
                {
                    if (result.GetValue("result_code").ToString() != "SUCCESS")
                    {
                        return false;
                    }
                    info.CancelOrderNo = result.GetValue("refund_id").ToString();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                LogHelper.Add("bool WeixinPay.CancelOrder(ref Host.CanceledPaymentInfo info), ErrMsg:{0}", ex);
                return false;

            }

        }

        public string GetOrderNo(IDictionary<string, string> param)
        {
            if (param != null && param.ContainsKey("out_trade_no"))
            {
                return param["out_trade_no"];
            }

            return string.Empty;
        }

        /// <summary>
        /// 查询退款
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CancelOrderQuery(ref CanceledPaymentInfo info)
        {
            try
            {
                var isApppay = info.IsWxApp;

                const string url = "https://api.mch.weixin.qq.com/pay/refundquery";
                var data = new WxPayData();
                var payConfig = GetConfig(info.ParkCode, info.Purpose, !isApppay);


                data.SetValue("refund_id", info.CancelOrderNo);
                data.SetValue("appid", payConfig.AppId);//公众账号ID
                data.SetValue("mch_id", payConfig.MchId);//商户号
                data.SetValue("nonce_str", GenerateNonceStr());//随机字符串
                data.SetValue("sign", data.MakeSign(payConfig));//签名

                


                var xml = data.ToXml();

                LogHelper.Add(string.Format("WxPayApi RefundQuery request : {0}", xml));
                var response = HttpService.Post(xml, url, false, 20, payConfig);//调用HTTP通信接口以提交数据到API
                LogHelper.Add(string.Format("WxPayApi RefundQuery response : {0}", response));

                var result = new WxPayData();
                result.FromXml(response, payConfig);



                if (result.GetValue("return_code").ToString() == "SUCCESS")
                {
                    if (result.GetValue("result_code").ToString() != "SUCCESS")
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Add("bool WeixinPay.CancelOrderQuery(ref Host.CanceledPaymentInfo info), ErrMsg:{0}", ex);
                return false;

            }
        }

        /// <summary>
        /// 检测异步回调的支付通知
        /// </summary>
        /// <param name="info"></param> 
        /// <returns></returns>
        public PurchaseNotify CheckNotify(CallBackPaymentInfo info)
        {
            PurchaseNotify retObj = null;
            try
            {
                var param = info.Param;
                var type = info.Type;

                if (param.Count > 0 && type == PaymentType.WeixinPay)
                {
                    var isApppay = param["trade_type"].ToUpper() == "APP"; //商户订单号
                    var payConfig = GetConfig(info.ParkCode, info.Purpose, !isApppay);

                    if (VerifyResult(param, payConfig))
                    {
                        var orderNo = param["out_trade_no"]; //商户订单号
                        var orderMoney = decimal.Parse(param["total_fee"]) / 100; //订单金额
                        var tradeNo = param["transaction_id"]; //微信支付订单号
                        var status = param["result_code"]; //业务结果 
                        var isSubscribe = param["is_subscribe"]; //用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
                        

                        switch (status)
                        {
                            case "SUCCESS":
                                retObj = new PurchaseNotify { OrderNo = orderNo, OrderMoney = orderMoney, Qn = tradeNo, Description = status };
                                break;
                            case "FAIL":
                                break;
                        }
                    }
                    else
                    {
                        #region 打印调试日志
                        var strObj = new StringBuilder();
                        foreach (var key in param.Keys)
                            strObj.AppendFormat("{0}:{1}\r\n", key, param[key]);

                        LogHelper.Add(string.Format("AliPay.CheckNotify {0}\r\n{1}", "验证失败", strObj));
                        #endregion
                    }
                }

                return retObj;
            }
            catch (Exception ex)
            {
                LogHelper.Add("微信支付回调异常", ex);
                return retObj;
            }
        }

        private bool VerifyResult(IEnumerable<KeyValuePair<string, string>> param, PayConfig payConfig)
        {
            var data = new WxPayData(param);

            return data.CheckSign(payConfig);
        }

        /// <summary>
        /// 微信无此功能。不实现
        /// </summary>
        /// <param name="info"></param> 
        /// <returns></returns>
        public CanceledPaymentInfo CheckCancelNotify(CallBackPaymentInfo info)
        {
            throw new NotImplementedException();
        }

        public string PayName()
        {
            return "微信支付";
        }

        /// <summary>
        /// 是否支持撤费
        /// </summary>
        public bool IsEnableCancel
        {
            get { return true; }
        }

        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        private static string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        private static string GenerateOutTradeNo(PayConfig payConfig)
        {
            var ran = new Random();
            return string.Format("{0}{1}{2}", payConfig.MchId , DateTime.Now.ToString("yyyyMMddHHmmss"), ran.Next(999));
        }

        private string GetOpenidAndAccessTokenFromCode(string code)
        {
            //try
            //{
            //    LogHelper.Add(string.Format("GetOpenidAndAccessTokenFromCode code : {0}", code));

            //    //构造获取openid及access_token的url
            //    var data = new WxPayData();
            //    data.SetValue("appid", WxPayConfig.APPID);
            //    data.SetValue("secret", WxPayConfig.APPSECRET);
            //    data.SetValue("code", code);
            //    data.SetValue("grant_type", "authorization_code");
            //    var url = "https://api.weixin.qq.com/sns/oauth2/access_token?" + data.ToUrl();

            //    //请求url以获取数据
            //    var result = HttpService.Get(url);

            //    // Logger.LogControl.Instance.PayMentInfo(string.Format("GetOpenidAndAccessTokenFromCode response : {0}", result));

            //    //保存access_token，用于收货地址获取
            //    var jd = JsonMapper.ToObject(result);
            //    //access_token = (string)jd["access_token"];

            //    //获取用户openid
            //    var openid = (string)jd["openid"];
            //    LogHelper.Add(string.Format("GetOpenidAndAccessTokenFromCode openid : {0}", openid));
            //    return openid;
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.Add("GetOpenidAndAccessTokenFromCode", ex);
            //    return string.Empty;
            //}

                return string.Empty;
        }
    }
}
