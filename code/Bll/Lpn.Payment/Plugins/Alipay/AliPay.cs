using System;
using System.Collections.Generic;
using System.Text;
using Com.Alipay;
using OneCoin.Payment.Entity;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Entity.Payment;
using OneCoin.Service.Model.Enum.Payment;
using System.Xml;

namespace OneCoin.Payment.Plugins.Alipay
{
    public class AliPay : PayBase,IPayment
    {
        public AliPay(): base(PaymentType.AliPay)
        {
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

                var payConfig = GetConfig(req.ParkCode, req.Purpose);

                #region 添加APP所需要的参数
                var extraParam = new AliPayRes();

                // 商户PID
                extraParam.partner = payConfig.MchId;

                // 商户PID
                extraParam.seller_id = payConfig.MchId;

                // 支付成功后异步回调的路径
                extraParam.notify_url = Config.Notify_URL;

                // 接口名称（此为固定值，不能为空）
                extraParam.service = "mobile.securitypay.pay";

                // 支付类型,默认值为：1(商品购买),2(服务购买)
                extraParam.payment_type = "2";

                // 编码字符集
                extraParam._input_charset = "utf-8";

                // 未付款交易的超时时间
                extraParam.it_b_pay = "30m";

                // 签名方式
                extraParam.sign_type = "RSA";

                // 支付宝的公钥
                extraParam.alipaypublickey = Config.Public_key;

                // 加密数据的私钥（已做AES加密，需使用商户PID作为密钥进行解密）
                extraParam.privatekey = AesHelper.Encrypt(payConfig.Pfx, payConfig.MchId);

                res.ExtraParam = extraParam;
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Add("bool AliPay.GetPurchaseNo(PurchaseReq req, ref PurchaseRes res), ErrMsg:{0}", ex);
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

                if (param.Count > 0 && param.ContainsKey("notify_id") && param.ContainsKey("sign") && type == PaymentType.AliPay)
                {
                    var payConfig = GetConfig(info.ParkCode, info.Purpose);

                    var aliNotify = new Notify();
                    var verifyResult = aliNotify.Verify(param as SortedDictionary<string, string>, param["notify_id"], param["sign"], payConfig.MchId, payConfig.PlatformPublicCer);

                    if (verifyResult)//验证成功
                    {

                        //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                        //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表


                        var orderNo = param["out_trade_no"]; //商户订单号
                        var orderMoney = decimal.Parse(param["total_fee"]); //订单金额
                        var tradeNo = param["trade_no"]; //支付宝流水号
                        var tradeStatus = param["trade_status"]; //交易状态


                        switch (tradeStatus)
                        {
                            case "TRADE_FINISHED": //交易结束，不再允许操作
                            /*
                                该种交易状态只在两种情况下出现
                                    1、开通了普通即时到账，买家付款成功后。
                                    2、开通了高级即时到账，从该笔交易成功时间算起，过了签约时的可退款时限（如：三个月以内可退款、一年以内可退款等）后。
                                      
                                如果有做过支付成功的处理，不执行商户的业务程序
                             */

                            case "TRADE_SUCCESS": //交易结束，可退款
                                /*
                                   该种交易状态只在一种情况下出现——开通了高级即时到账，买家付款成功后。

                                  如果没有做过支付成功的处理，不执行商户的业务程序
                                 */
                                retObj = new PurchaseNotify
                                    {
                                        Qn = tradeNo,
                                        Description = tradeStatus,
                                        OrderMoney = orderMoney,
                                        OrderNo = orderNo
                                    };
                                break;

                        }

                    }
                    else//验证失败
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
                LogHelper.Add("支付宝回调异常处理",ex);
                return retObj;
            }
        }


        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string GetOrderNo(IDictionary<string, string> param)
        {
            if (param != null && param.ContainsKey("out_trade_no"))
            {
                return param["out_trade_no"];//商户订单号
            }

            return string.Empty;
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
                var payConfig = GetConfig(req.ParkCode, req.Purpose);
                //把请求参数打包成数组
                var sParaTemp = new SortedDictionary<string, string>
                    {
                        {"partner", payConfig.MchId},
                        {"_input_charset", Config.Input_charset.ToLower()},
                        {"service", Config.SingleQueryService},
                        {"trade_no", req.QN},
                        {"out_trade_no", req.OrderNo}
                    };

                res.OrderNo = req.OrderNo;
                res.OrderTime = req.OrderTime;

                var paramsList = new SortedDictionary<string, string>();

                try
                {
                    #region 解析XML
                    //建立请求
                    string sHtmlText = Submit.BuildPostRequestForQuery(sParaTemp,payConfig.Md5Key);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(sHtmlText);
                    XmlNode rootNode = xmlDoc.SelectSingleNode("/alipay");
                     
                    if (rootNode.SelectSingleNode("is_success").InnerText.ToLower().Equals("t"))
                    { //能查到此订单

                        paramsList.Add("is_success", rootNode.SelectSingleNode("is_success").InnerText);

                        XmlNode resNode = rootNode.SelectSingleNode("response/trade");

                        if (resNode != null)
                        {
                            paramsList.Add("body", resNode.SelectSingleNode("body") != null ? resNode.SelectSingleNode("body").InnerText : "");
                            paramsList.Add("buyer_email", resNode.SelectSingleNode("buyer_email").InnerText);
                            paramsList.Add("buyer_id", resNode.SelectSingleNode("buyer_id").InnerText);
                            paramsList.Add("discount", resNode.SelectSingleNode("discount").InnerText);
                            paramsList.Add("gmt_create", resNode.SelectSingleNode("gmt_create").InnerText);
                            paramsList.Add("gmt_last_modified_time", resNode.SelectSingleNode("gmt_last_modified_time").InnerText.Trim());
                            paramsList.Add("gmt_payment", resNode.SelectSingleNode("gmt_payment").InnerText);
                            paramsList.Add("is_total_fee_adjust", resNode.SelectSingleNode("is_total_fee_adjust").InnerText);
                            paramsList.Add("out_trade_no", resNode.SelectSingleNode("out_trade_no").InnerText);
                            paramsList.Add("payment_type", resNode.SelectSingleNode("payment_type").InnerText);
                            paramsList.Add("price", resNode.SelectSingleNode("price").InnerText);
                            paramsList.Add("quantity", resNode.SelectSingleNode("quantity").InnerText);
                            paramsList.Add("seller_email", resNode.SelectSingleNode("seller_email").InnerText);
                            paramsList.Add("seller_id", resNode.SelectSingleNode("seller_id").InnerText);
                            paramsList.Add("subject", resNode.SelectSingleNode("subject").InnerText);
                            paramsList.Add("total_fee", resNode.SelectSingleNode("total_fee").InnerText);
                            paramsList.Add("trade_no", resNode.SelectSingleNode("trade_no").InnerText);
                            paramsList.Add("trade_status", resNode.SelectSingleNode("trade_status").InnerText);
                            paramsList.Add("use_coupon", resNode.SelectSingleNode("use_coupon").InnerText);
                        }
                    }
                    else
                    {  //查询订单无效
                        paramsList.Add("is_success", rootNode.SelectSingleNode("is_success").InnerText);
                        paramsList.Add("error", rootNode.SelectSingleNode("error").InnerText);
                    }
                    #endregion


                    #region 打印订单查询反馈日志
                    StringBuilder str = new StringBuilder();
                    StringBuilder inputStr = new StringBuilder();

                    inputStr.AppendFormat("trade_no:{0}", req.QN);           //流水号
                    inputStr.AppendFormat("out_trade_no:{0}", req.OrderNo); // 订单号
                    inputStr.AppendFormat("ordertime:{0}", req.OrderTime);  //订单时间

                    foreach (string key in paramsList.Keys)
                    {
                        str.AppendFormat("{0}:{1};", key, paramsList[key]);
                    }

                    #endregion


                    if (paramsList["is_success"].ToLower().Equals("t"))
                    {
                        //订单有效

                        res.OrderDesc = paramsList["body"];
                        res.OrderMoney = float.Parse(paramsList["total_fee"]);
                        res.QN = paramsList["trade_no"];

                        switch (paramsList["trade_status"])
                        {
                            case "TRADE_SUCCESS":   //支付成功
                            case "TRADE_FINISHED":  //交易成功结束


                                res.Result = true;
                                LogHelper.Add(string.Format("AliPay 订单查询反馈({0} {1})\r\n传入:{2}\r\n返回:{3}", res.Result.ToString(), res.ErrMsg, inputStr, str));
                                return true;

                            case "TRADE_NOT_EXIST": //订单不存在
                                res.Result = false;
                                return false;
                            default:
                                res.Result = false;
                                LogHelper.Add(string.Format("AliPay 订单查询反馈({0} {1})\r\n传入:{2}\r\n返回:{3}", res.Result.ToString(), res.ErrMsg, inputStr, str));
                                return false;
                        }

                    }


                    //订单无效
                    res.ErrMsg = paramsList["error"];
                    res.Result = false;

                    return false;
                }
                catch (Exception exp)
                {
                    var str = new StringBuilder();
                    foreach (var key in paramsList.Keys)
                    {
                        str.AppendFormat("{0}:{1};", key, paramsList[key]);
                    }
                    LogHelper.Add(string.Format("AliPay 订单查询反馈 Exception({0})：\r\n{1}", exp.Message, str));
                }

                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Add("bool AliPay.Query, ErrMsg:{0}", ex);
                return false;
            }
        }

        /// <summary>
        /// 是否支持撤费
        /// </summary>
        public bool IsEnableCancel
        {
            get { return false; }
        }

        /// <summary>
        /// 检测异步回调的撤销通知(由于支付宝没提供自动撤费功能，因此此功能无效)
        /// </summary>
        /// <param name="info"></param> 
        /// <returns></returns>
        public CanceledPaymentInfo CheckCancelNotify(CallBackPaymentInfo info)
        {
            throw new NotSupportedException();
        }

        public string PayName()
        {
            return "支付宝";
        }


        /// <summary>
        /// 撤费申请（若撤费充值成功，则返回true，否则返回false要求重复尝试撤费申请）
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CancelOrder(ref  CanceledPaymentInfo info)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 撤费查询(此函数由于只有在撤费申请提交成功后才会调用，因此立即返回true)
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CancelOrderQuery(ref  CanceledPaymentInfo info)
        {
            throw new NotSupportedException();
        }


    }
}
