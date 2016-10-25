using System;
using System.Collections.Generic;
using System.Text;
using Com.UnionPay.Upmp;
using Lpn.Payment.Entity;
using Lpn.Service.Helper.Log;
using Lpn.Service.Model.Entity.Payment;
using Lpn.Service.Model.Enum.Payment;
using PCE.Payment;

namespace Lpn.Payment.Plugins.UnionPay
{
    /// <summary>
    /// 用于银联支付
    /// </summary>
    public class UnionPay : IPayment
    {

        /// <summary>
        /// 支付申请，获取流水号
        /// </summary>
        /// <param name="req">支付申请</param>
        /// <param name="res">反馈结论</param>
        /// <returns>true=操作成功 false=操作失败</returns>
        public bool GetPurchaseNo(PurchaseReq req, ref PurchaseRes res)
        {
            try
            {
                // 请求要素
                var param = new Dictionary<String, String>();

                param["version"] = UpmpConfig.GetInstance().VERSION;// 版本号
                param["charset"] = UpmpConfig.GetInstance().CHARSET;// 字符编码
                param["transType"] = "01";// 交易类型
                param["merId"] = UpmpConfig.GetInstance().MER_ID;// 商户代码
                param["backEndUrl"] = UpmpConfig.GetInstance().MER_BACK_END_URL;// 通知URL
                param["frontEndUrl"] = UpmpConfig.GetInstance().MER_FRONT_END_URL;// 前台通知URL(可选)


                // 保留域填充方法
                var merReservedMap = new Dictionary<String, String>();
                merReservedMap["ParkCode"] = req.ParkCode; //停车场编码
                merReservedMap["CarNo"] = req.CarNo; //车牌

                switch (req.Purpose)
                {
                    case PaymentPurpose.支付停车费:
                        merReservedMap["EntranceTime"] = req.EntranceTime.ToString("yyyy-MM-dd HH:mm:ss"); //入场时间
                        merReservedMap["ExitTime"] = req.ExitTime.ToString("yyyy-MM-dd HH:mm:ss"); //离场时间
                        break;

                    case PaymentPurpose.支付月租:
                        merReservedMap["TillDate"] = req.TillDate.ToString("yyyy-MM-dd HH:mm:ss");  //月租到期日期
                        merReservedMap["RenewalMonths"] = req.RenewalMonths.ToString(); //续费几月
                        break;

                    case PaymentPurpose.账户充值:
                        break;

                    case PaymentPurpose.租用车位:
                        //merReservedMap["ShareSubscribeID"] = req.ShareSubscribeID.ToString();
                        //merReservedMap["ShareType"] = req.ShareType.ToString();
                        //merReservedMap["OwerID"] = req.OwerID.ToString();
                        //merReservedMap["SapceCode"] = req.SapceCode;
                        break;

                }



                merReservedMap["OrderMoney"] = req.OrderMoney.ToString(); //需支付金额
                merReservedMap["PaymentType"] = req.PaymentType.ToString(); //支付方式

                param["merReserved"] = UpmpService.BuildReserved(merReservedMap);// 商户保留域(可选)
                param["reqReserved"] = req.Purpose.ToString();  //req.Description;// 请求方保留域(可选，用于透传商户信息)

                param["orderNumber"] = req.OrderNo;// 订单号(商户根据自己需要生成订单号)
                param["orderAmount"] = (req.OrderMoney * 100).ToString();// 订单金额
                param["orderDescription"] = req.Purpose.ToString();// req.Description;// 订单描述(可选)

                param["orderTime"] = DateTime.Now.ToString("yyyyMMddHHmmss");// 交易开始日期时间yyyyMMddHHmmss
                param["orderTimeout"] = "";// 订单超时时间yyyyMMddHHmmss(可选)

                param["orderCurrency"] = "156";// 交易币种(可选)


                var resp = new Dictionary<String, String>();
                var validResp = UpmpService.Trade(param, resp);

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

                // 商户的业务逻辑
                if (validResp)
                {
                    // 服务器应答签名验证成功
                    if (resp.ContainsKey("tn"))
                    {
                        res.Result = 1;
                        res.Sn = resp["tn"];
                    }

                    #region 打印订单流水号申请反馈日志
                    var str = new StringBuilder();
                    foreach (var key in resp.Keys)
                    {
                        str.AppendFormat("{0}:{1};", key, resp[key]);
                    }
                    LogHelper.Add(string.Format("{0} {1}", "UnionPay 订单流水号生成反馈：", str));
                    #endregion

                    return true;
                }
                else
                {
                    // 服务器应答签名验证失败
                    if (resp.ContainsKey("respMsg"))
                    {
                        res.Result = 0;
                        res.Sn = "";
                        res.ErrMsg = resp["respMsg"];

                        LogHelper.Add(string.Format("银联申请流水号失败，OrderNo:{0},ParkCode:{1},CarNo:{2},OrderMoney:{3},ErrMsg:{4}",
                            req.OrderNo,
                            req.ParkCode,
                            req.CarNo,
                            req.OrderMoney.ToString(),
                            resp["respMsg"]));
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Add("bool UnionPay.GetPurchaseNo(PurchaseReq req, ref PurchaseRes res)", ex);
                return false;
            }
        }


        public bool Query(PurchaseQueryReq req, ref PurchaseQueryRes res)
        {
            try
            {

                // 请求要素
                Dictionary<String, String> param = new Dictionary<String, String>();
                param["version"] = UpmpConfig.GetInstance().VERSION;// 版本号
                param["charset"] = UpmpConfig.GetInstance().CHARSET;// 字符编码
                param["transType"] = "01";// 交易类型
                param["merId"] = UpmpConfig.GetInstance().MER_ID;// 商户代码

                param["orderTime"] = DateTime.Parse(req.OrderTime).ToString("yyyyMMdd");// 交易开始日期时间yyyyMMddHHmmss或yyyyMMdd
                param["orderNumber"] = req.OrderNo;// 订单号
                res.OrderNo = req.OrderNo;

                Dictionary<String, String> resp = new Dictionary<String, String>();
                bool validResp = UpmpService.Query(param, resp);

                // 商户的业务逻辑
                if (validResp)
                {
                    if (resp.ContainsKey("respMsg"))
                        res.ErrMsg = resp["respMsg"];

                    // 服务器应答签名验证成功
                    if (resp.ContainsKey("respCode") && resp["respCode"].Equals("00"))
                    {
                        if (resp.ContainsKey("transStatus") && resp["transStatus"].Equals("00"))
                        {

                            if (resp.ContainsKey("orderTime") && resp["orderTime"].Length == 14)
                                res.OrderTime = string.Format("{0}-{1}-{2} {3}:{4}:{5}", resp["orderTime"].Substring(0, 4), resp["orderTime"].Substring(4, 2), resp["orderTime"].Substring(6, 2), resp["orderTime"].Substring(8, 2), resp["orderTime"].Substring(10, 2), resp["orderTime"].Substring(12, 2));

                            if (resp.ContainsKey("reqReserved"))
                                res.OrderDesc = resp["reqReserved"];

                            if (resp.ContainsKey("settleAmount"))
                                res.OrderMoney = float.Parse(resp["settleAmount"]) / 100;

                            if (resp.ContainsKey("qn")) //获取支付成功的流水号
                                res.QN = resp["qn"];


                            #region 打印订单查询反馈日志
                            StringBuilder str = new StringBuilder();
                            foreach (string key in resp.Keys)
                            {
                                str.AppendFormat("{0}:{1};", key, resp[key]);
                            }
                            LogHelper.Add(string.Format("{0} {1}", "UnionPay 订单查询反馈：", str));
                            #endregion

                            res.Result = true;
                            return true;
                        }

                        res.Result = false;
                        return true;
                }
                }
                else
                {
                    // 服务器应答签名验证失败

                    res.Result = false;

                    //if (resp.ContainsKey("respMsg"))
                    //    res.ErrMsg = resp["respMsg"];
                    //Logger.LogControl.Instance.Error("银联订单查询失败，OrderNo:{0},OrderTime:{1},ErrMsg:{2}",
                    //    req.OrderNo,
                    //    req.OrderTime,
                    //    res.ErrMsg);
                }

                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Add("bool UnionPay.Query(PurchaseQueryReq req, ref PurchaseQueryRes res)", ex);
                return false;
            }
        }

        /// <summary>
        /// 是否支持撤费
        /// </summary>
        public bool IsEnableCancel
        {
            get { return true; }
        }

        /// <summary>
        /// 已提交了撤费申请的订单的查询处理
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CancelOrderQuery(ref CanceledPaymentInfo info)
        {
            try
            {
                string respMsg = "";
                // 请求要素
                Dictionary<String, String> param = new Dictionary<String, String>();
                param["version"] = UpmpConfig.GetInstance().VERSION;// 版本号
                param["charset"] = UpmpConfig.GetInstance().CHARSET;// 字符编码
                param["transType"] = "31";// 交易类型
                param["merId"] = UpmpConfig.GetInstance().MER_ID;// 商户代码

                param["orderTime"] = info.OrderTime.ToString("yyyyMMdd");// 交易开始日期时间yyyyMMddHHmmss或yyyyMMdd
                param["orderNumber"] = info.CancelOrderNo;// 撤费订单号

                var resp = new Dictionary<String, String>();
                bool validResp = UpmpService.Query(param, resp);

                // 商户的业务逻辑
                if (validResp)
                {
                    // 服务器应答签名验证成功
                    if (resp.ContainsKey("respCode") && resp["respCode"].Equals("00"))
                    {
                        if (resp.ContainsKey("transStatus") && resp["transStatus"].Equals("00"))
                        {

                            #region 打印订单查询反馈日志
                            var str = new StringBuilder();
                            foreach (string key in resp.Keys)
                            {
                                str.AppendFormat("{0}:{1};", key, resp[key]);
                            }
                            LogHelper.Add(string.Format("{0} {1}", "UnionPay 撤费订单查询反馈：", str));
                            #endregion

                            return true;
                        }

                    }

                    if (resp.ContainsKey("respMsg"))
                        respMsg = resp["respMsg"];

                    LogHelper.Add(string.Format("银联撤费订单查询失败，OrderNo:{0},OrderTime:{1},ErrMsg:{2}",
                        info.OrderNo,
                        info.OrderTime,
                        respMsg));

                    return false;
                }
                else
                {
                    // 服务器应答签名验证失败
                    if (resp.ContainsKey("respMsg"))
                        respMsg = resp["respMsg"];

                    LogHelper.Add(string.Format("银联撤费订单查询失败，OrderNo:{0},OrderTime:{1},ErrMsg:{2}",
                        info.OrderNo,
                        info.OrderTime,
                        respMsg));
                }

                return false;
            }
            catch (Exception ex)
            {
                LogHelper.Add("bool UnionPay.CancelOrderQuery(ref PCE.Host.CanceledPaymentInfo info)", ex);
                return false;
            }
        }

        /// <summary>
        /// 撤费申请
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CancelOrder(ref  CanceledPaymentInfo info)
        {
            try
            {
                // 请求要素
                var param = new Dictionary<String, String>();

                string orderNo = string.Format("{0}{1}",DateTime.Now.ToString("yyMMddHHmmssfff"), info.ParkCode );

                param["version"] = UpmpConfig.GetInstance().VERSION;// 版本号
                param["charset"] = UpmpConfig.GetInstance().CHARSET;// 字符编码
                param["transType"] = "31";// 交易类型
                param["merId"] = UpmpConfig.GetInstance().MER_ID;// 商户代码
                param["backEndUrl"] = UpmpConfig.GetInstance().MER_BACK_END_VoidURL;// 撤费通知URL
                param["orderTime"] = DateTime.Now.ToString("yyyyMMddHHmmss");// 交易开始日期时间yyyyMMddHHmmss（撤销交易新交易日期，非原交易日期）
                param["orderCurrency"] = "156";// 交易币种
                param["reqReserved"] = "";// 请求方保留域(可选，用于透传商户信息)
                param["merReserved"] = "";// 商户保留域(可选)


                param["orderNumber"] = orderNo;// 订单号（撤销交易新订单号，非原订单号）
                param["orderAmount"] = (info.OrderMoney * 100).ToString();// 订单金额
                param["qn"] = info.qn;// 查询流水号（原订单支付成功后获取的流水号）


                Dictionary<String, String> resp = new Dictionary<String, String>();
                bool validResp = UpmpService.Trade(param, resp);

                // 商户的业务逻辑
                if (validResp)
                {
                    StringBuilder str = new StringBuilder();
                    foreach (string key in resp.Keys)
                    {
                        str.AppendFormat("{0}:{1};", key, resp[key]);
                    }

                    if (resp.ContainsKey("respCode") && resp["respCode"].Equals("00"))
                    {
                        info.CancelOrderNo = orderNo; //设置对应的撤费订单号
                        LogHelper.Add(string.Format("{0} {1}", "UnionPay 订单撤费申请成功反馈：", str));
                        return true;
                    }
                    else
                    {
                        LogHelper.Add(string.Format("{0} {1}", "UnionPay 订单撤费申请失败反馈：", str));
                        return false;
                    }
                }
                else
                {
                    var str = new StringBuilder();
                    foreach (string key in resp.Keys)
                    {
                        str.AppendFormat("{0}:{1};", key, resp[key]);
                    }
                    LogHelper.Add(string.Format("{0} {1}", "UnionPay 订单撤费申请失败反馈：", str));

                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Add( "bool UnionPay.CancelOrder(ref PCE.Host.CanceledPaymentInfo info) ", ex);
                return false;
            }
        }


        /// <summary>
        /// 检测异步回调的支付通知
        /// </summary>
        /// <param name="type"></param>
        /// <param name="param">回传的参数</param>
        /// <returns></returns>
        public PurchaseNotify CheckNotify(PaymentType type, IDictionary<String, String> param)
        {
            try
            { 
                if (param.Count > 0 && type == PaymentType.UnionPay)
                {
                    #region 打印日志
                    var str = new StringBuilder();
                    foreach (string key in param.Keys)
                        if (!key.Equals("sysReserved"))
                            str.AppendFormat("{0}:{1};", key, param[key]);
                        else
                            str.AppendFormat("{0}:{1};", key, param[key].Replace("{", "(").Replace("}", ")"));


                    LogHelper.Add(string.Format("{0} {1}", "UnionPay 异步支付反馈：\r\n", str));
                    #endregion

                    if (UpmpService.VerifySignature(param as Dictionary<string,string>))
                    {   // 服务器签名验证成功
                        //请在这里加上商户的业务逻辑程序代码
                        //获取通知返回参数，可参考接口文档中通知参数列表(以下仅供参考)
                        var transStatus = param["transStatus"];// 交易状态

                        if ("" != transStatus && "00" == transStatus)
                        {
                            // 交易处理成功
                            var orderNo = param["orderNumber"];
                            var orderMoney = decimal.Parse(param["settleAmount"])/100;
                            var qn = param["qn"];

                            return new PurchaseNotify
                                {
                                    Qn = qn,
                                    OrderNo = orderNo,
                                    OrderMoney = orderMoney,
                                    Description = transStatus
                                }; 
                        } 
                    }
                    else// 服务器签名验证失败
                    {
                        return null;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Add( "PurchaseReq UnionPay.CheckNotify(PAYMENTTYPE type, Dictionary<String, String> param)", ex);
                return null;
            }

        }

        /// <summary>
        /// 检测异步回调的撤销通知
        /// </summary>
        /// <param name="type"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public CanceledPaymentInfo CheckCancelNotify(PaymentType type, IDictionary<String, String> param)
        {
            try
            {
                if (param.Count > 0 && type == PaymentType.UnionPay)
                {

                    #region 打印日志
                    StringBuilder str = new StringBuilder();
                    foreach (string key in param.Keys)
                        if (!key.Equals("sysReserved"))
                            str.AppendFormat("{0}:{1};", key, param[key]);
                        else
                            str.AppendFormat("{0}:{1};", key, param[key].Replace("{", "(").Replace("}", ")"));


                    LogHelper.Add(string.Format("{0} {1}", "UnionPay 异步撤销反馈：\r\n", str));
                    #endregion

                    if (UpmpService.VerifySignature(param as Dictionary<string, string>))
                    {   // 服务器签名验证成功
                        //请在这里加上商户的业务逻辑程序代码
                        //获取通知返回参数，可参考接口文档中通知参数列表(以下仅供参考)
                        String transStatus = param["transStatus"];// 交易状态

                        if ("" != transStatus && "00" == transStatus)
                        {
                            // 撤销处理成功
                            string orderNo = "";
                            long orderMoney = 0;

                            if (param.ContainsKey("orderNumber"))
                                orderNo = param["orderNumber"];

                            if (param.ContainsKey("settleAmount"))
                                orderMoney = long.Parse(param["settleAmount"]);

                            //foreach (string key in PCE.Host.Payment.CanceledCache.Keys)
                            //{
                            //    if (PCE.Host.Payment.CanceledCache[key].CancelOrderNo.Equals(orderNo) && orderMoney == PCE.Host.Payment.CanceledCache[key].OrderMoney * 100)
                            //    {
                            //        return PCE.Host.Payment.CanceledCache[key];
                            //    }
                            //}

                            return null;
                        }
                        else
                        {
                            //交易失败
                            return null;
                        }

                    }
                    else// 服务器签名验证失败
                    {
                        return null;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                LogHelper.Add("CanceledPaymentInfo UnionPay.CheckCancelNotify(PAYMENTTYPE type, Dictionary<String, String> param)", ex);
                return null;
            }
        }
    }
}
