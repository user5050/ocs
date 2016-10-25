using System;
using System.Collections.Generic;
using System.Text;
using OneCoin.Payment.Entity;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Entity.Payment;
using OneCoin.Service.Model.Enum.Payment;
using upacp_sdk_net.com.unionpay.sdk;
using HttpClient = upacp_sdk_net.com.unionpay.sdk.HttpClient;

namespace OneCoin.Payment.Plugins.UnionPay5
{
    /// <summary>
    /// 用于银联支付
    /// </summary>
    public class UnionPay : PayBase, IPayment
    {
        public UnionPay(): base(PaymentType.UnionPay)
        {
        }

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
                /**
            * 重要：联调测试时请仔细阅读注释！
            * 
            * 产品：跳转网关支付产品<br>
            * 交易：消费：前台跳转，有前台通知应答和后台通知应答<br>
            * 日期： 2015-09<br>
            * 版本： 1.0.0
            * 版权： 中国银联<br>
            * 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己需要，按照技术文档编写。该代码仅供参考，不提供编码性能规范性等方面的保障<br>
            * 提示：该接口参考文档位置：open.unionpay.com帮助中心 下载  产品接口规范  《网关支付产品接口规范》，<br>
            *              《平台接入接口规范-第5部分-附录》（内包含应答码接口规范，全渠道平台银行名称-简码对照表)<br>
            *              《全渠道平台接入接口规范 第3部分 文件接口》（对账文件格式说明）<br>
            * 测试过程中的如果遇到疑问或问题您可以：1）优先在open平台中查找答案：
            * 							        调试过程中的问题或其他问题请在 https://open.unionpay.com/ajweb/help/faq/list 帮助中心 FAQ 搜索解决方案
            *                             测试过程中产生的6位应答码问题疑问请在https://open.unionpay.com/ajweb/help/respCode/respCodeList 输入应答码搜索解决方案
            *                          2） 咨询在线人工支持： open.unionpay.com注册一个用户并登陆在右上角点击“在线客服”，咨询人工QQ测试支持。
            * 交易说明:1）以后台通知或交易状态查询交易确定交易成功,前台通知不能作为判断成功的标准.
            *       2）交易状态查询交易（Form_6_5_Query）建议调用机制：前台类交易建议间隔（5分、10分、30分、60分、120分）发起交易查询，如果查询到结果成功，则不用再查询。（失败，处理中，查询不到订单均可能为中间状态）。也可以建议商户使用payTimeout（支付超时时间），过了这个时间点查询，得到的结果为最终结果。
            */

                var payConfig = GetConfig(req.ParkCode, req.Purpose);
                var param = new Dictionary<string, string>();

                //以下信息非特殊情况不需要改动
                param["version"] = "5.0.0"; //版本号
                param["encoding"] = "UTF-8"; //编码方式
                param["certId"] = CertUtil.GetSignCertId(payConfig.Pfx, payConfig.PfxPwd); //证书ID
                param["txnType"] = "01"; //交易类型
                param["txnSubType"] = "01"; //交易子类
                param["bizType"] = "000201"; //业务类型
                param["signMethod"] = "01"; //签名方法
                param["channelType"] = "08"; //渠道类型
                param["accessType"] = "0"; //接入类型
                param["frontUrl"] = SDKConfig.FrontUrl; //前台通知地址      
                param["backUrl"] = SDKConfig.BackUrl; //后台通知地址
                param["currencyCode"] = "156"; //交易币种

                //以下信息需要填写
                param["merId"] = payConfig.MchId; //商户号，请改自己的测试商户号，此处默认取demo演示页面传递的参数
                param["orderId"] = req.OrderNo; //商户订单号，8-32位数字字母，不能含“-”或“_”，此处默认取demo演示页面传递的参数，可以自行定制规则
                param["txnTime"] = req.OrderTime.ToString("yyyyMMddHHmmss");
                //订单发送时间，格式为YYYYMMDDhhmmss，取北京时间，此处默认取demo演示页面传递的参数，参考取法： DateTime.Now.ToString("yyyyMMddHHmmss")
                param["txnAmt"] = ((int) (req.OrderMoney*100)).ToString(); //交易金额，单位分，此处默认取demo演示页面传递的参数
                //param["reqReserved"] = "透传信息";//请求方保留域，透传字段，查询、通知、对账文件中均会原样出现，如有需要请启用并修改自己希望透传的数据


                //保留域填充方法 
                //param["reqReserved"] = UpmpService.BuildReserved(ReservedMap(req)); //req.Description;// 请求方保留域(可选，用于透传商户信息)


                SDKUtil.Sign(param, Encoding.UTF8, payConfig.Pfx, payConfig.PfxPwd); // 签名

                var url = SDKConfig.AppRequestUrl;
                var hc = new HttpClient(url);
                var status = hc.Send(param, Encoding.UTF8);
                var result = hc.Result;

                if (status == 200)
                {
                    var resData = SDKUtil.CoverStringToDictionary(result);

                    if (SDKUtil.Validate(resData, Encoding.UTF8, payConfig.PlatformPublicCer))
                    {
                        var respcode = resData["respCode"]; //其他应答参数也可用此方法获取
                        if ("00" == respcode)
                        {
                            //成功 
                            //"成功接收tn：" + resData["tn"] + "<br>\n");
                            //"后续请将此tn传给手机开发，由他们用此tn调起控件后完成支付。<br>\n");
                            //"手机端demo默认从仿真获取tn，仿真只返回一个tn，如不想修改手机和后台间的通讯方式，【此页面请修改代码为只输出tn】。<br>\n");

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


                            res.Sn = resData["tn"];
                            res.Result = 1;
                            res.ExtraParam = new {tn = resData["tn"]}; 
                            return true;
                        }
                        else
                        {
                            //其他应答码做以失败处理 
                            LogHelper.Add("失败：" + resData["respMsg"] + "。<br>\n");
                        }
                    }
                    else
                    {
                        LogHelper.Add("商户端验证返回报文签名失败。<br>\n");
                    }
                }
                else
                {
                    LogHelper.Add("请求失败，http状态：" + status + "。<br>\n");
                } 
            }
            catch (Exception ex)
            {
                LogHelper.Add("请求失败", ex);
            }

            return false;
        }
         
        private Dictionary<string, string> ReservedMap(PurchaseReq req)
        {
            var merReservedMap = new Dictionary<String, String>();
            merReservedMap["ParkCode"] = req.ParkCode; //停车场编码
            merReservedMap["CarNo"] = req.CarNo; //车牌

            switch (req.Purpose)
            {
                case PaymentPurpose.支付停车费:
                    merReservedMap["EntranceTime"] = req.EntranceTime.ToString("yyyy-MM-dd HH:mm:ss"); //入场时间
                    merReservedMap["ExitTime"] = req.ExitTime.ToString("yyyy-MM-dd HH:mm:ss"); //离场时间
                    break;

                case PaymentPurpose.商品购买:
                    merReservedMap["TillDate"] = req.TillDate.ToString("yyyy-MM-dd HH:mm:ss");  //月租到期日期
                    merReservedMap["RenewalMonths"] = req.RenewalMonths.ToString(); //续费几月
                    break;

                case PaymentPurpose.账户充值:
                    break;

                case PaymentPurpose.租用车位:
                    break;

            }

            merReservedMap["OrderMoney"] = req.OrderMoney.ToString(); //需支付金额
            merReservedMap["PaymentType"] = req.PaymentType.ToString(); //支付方式
            merReservedMap["Purpose"] = req.Purpose.ToString(); //支付目的

            return merReservedMap;
        }

        public bool Query(PurchaseQueryReq req, ref PurchaseQueryRes res)
        {
            try
            {

                /**
             * 重要：联调测试时请仔细阅读注释！
             * 
             * 产品：跳转网关支付产品<br>
             * 交易：交易状态查询交易：只有同步应答 <br>
             * 日期： 2015-09<br>
             * 版本： 1.0.0 
             * 版权： 中国银联<br>
             * 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己需要，按照技术文档编写。该代码仅供参考，不提供编码性能及规范性等方面的保障<br>
             * 该接口参考文档位置：open.unionpay.com帮助中心 下载  产品接口规范  《网关支付产品接口规范》，<br>
             *              《平台接入接口规范-第5部分-附录》（内包含应答码接口规范，全渠道平台银行名称-简码对照表）<br>
             * 测试过程中的如果遇到疑问或问题您可以：1）优先在open平台中查找答案：
             * 							        调试过程中的问题或其他问题请在 https://open.unionpay.com/ajweb/help/faq/list 帮助中心 FAQ 搜索解决方案
             *                             测试过程中产生的6位应答码问题疑问请在https://open.unionpay.com/ajweb/help/respCode/respCodeList 输入应答码搜索解决方案
             *                           2） 咨询在线人工支持： open.unionpay.com注册一个用户并登陆在右上角点击“在线客服”，咨询人工QQ测试支持。
             * 交易说明： 1）对前台交易发起交易状态查询：前台类交易建议间隔（5分、10分、30分、60分、120分）发起交易查询，如果查询到结果成功，则不用再查询。（失败，处理中，查询不到订单均可能为中间状态）。也可以建议商户使用payTimeout（支付超时时间），过了这个时间点查询，得到的结果为最终结果。
             *        2）对后台交易发起交易状态查询：后台类资金类交易同步返回00，成功银联有后台通知，商户也可以发起 查询交易，可查询N次（不超过6次），每次时间间隔2N秒发起,即间隔1，2，4，8，16，32S查询（查询到03，04，05继续查询，否则终止查询）。
             *        					         后台类资金类同步返03 04 05响应码及未得到银联响应（读超时）需发起查询交易，可查询N次（不超过6次），每次时间间隔2N秒发起,即间隔1，2，4，8，16，32S查询（查询到03，04，05继续查询，否则终止查询）。
             */

            var payConfig = GetConfig(req.ParkCode,req.Purpose);
            var param = new Dictionary<string, string>();

            //以下信息非特殊情况不需要改动
            param["version"] = "5.0.0";//版本号
            param["encoding"] = "UTF-8";//编码方式
            param["certId"] = CertUtil.GetSignCertId(payConfig.Pfx,payConfig.PfxPwd);//证书ID
            param["signMethod"] = "01";//签名方法
            param["txnType"] = "00";//交易类型
            param["txnSubType"] = "00";//交易子类
            param["bizType"] = "000000";//业务类型
            param["accessType"] = "0";//接入类型
            param["channelType"] = "07";//渠道类型

            //信息需要填写
            param["orderId"] = req.OrderNo;	//请修改被查询的交易的订单号，8-32位数字字母，不能含“-”或“_”，此处默认取demo演示页面传递的参数
            param["merId"] = payConfig.MchId;//商户代码，请改成自己的测试商户号，此处默认取demo演示页面传递的参数
            param["txnTime"] = DateTime.Parse(req.OrderTime).ToString("yyyyMMddHHmmss");//请修改被查询的交易的订单发送时间，格式为YYYYMMDDhhmmss，此处默认取demo演示页面传递的参数

            SDKUtil.Sign(param, Encoding.UTF8, payConfig.Pfx,payConfig.PfxPwd);  // 签名
            string url = SDKConfig.SingleQueryUrl;
            var hc = new HttpClient(url);
            int status = hc.Send(param, Encoding.UTF8);
            string result = hc.Result; 


            if (status == 200)
            {
                Dictionary<string, string> resData = SDKUtil.CoverStringToDictionary(result);

                if (SDKUtil.Validate(resData, Encoding.UTF8, payConfig.PlatformPublicCer))
                {
                    string respcode = resData["respCode"]; //其他应答参数也可用此方法获取
                    if ("00" == respcode)
                    {
                        string origRespCode = resData["origRespCode"]; //其他应答参数也可用此方法获取
                        //处理被查询交易的应答码逻辑
                        if ("00" == origRespCode)
                        {
                            //交易成功，更新商户订单状态
                            if (resData.ContainsKey("txnTime") && resData["txnTime"].Length == 14)
                                res.OrderTime = string.Format("{0}-{1}-{2} {3}:{4}:{5}", resData["txnTime"].Substring(0, 4), resData["txnTime"].Substring(4, 2), resData["txnTime"].Substring(6, 2), resData["txnTime"].Substring(8, 2), resData["txnTime"].Substring(10, 2), resData["txnTime"].Substring(12, 2));

                            if (resData.ContainsKey("txnAmt"))
                                res.OrderMoney = float.Parse(resData["txnAmt"]) / 100;

                            if (resData.ContainsKey("queryId")) //获取支付成功的流水号
                                res.QN = resData["queryId"];


                            #region 打印订单查询反馈日志  
                            LogHelper.Add(string.Format("{0} {1}", "UnionPay 订单查询反馈：", result));
                            #endregion

                            res.Result = true;
                            return true;
                        }
                        else if ("03" == origRespCode ||
                            "04" == origRespCode ||
                            "05" == origRespCode)
                        {
                            //需再次发起交易状态查询交易
                            //交易处理中，稍后查询 
                        }
                        else
                        {
                            //其他应答码做以失败处理  交易失败 
                            res.IsCanDelOrder = true;
                        }
                    }
                    else if ("03" == respcode ||
                            "04" == respcode ||
                            "05" == respcode)
                    {
                        //不明原因超时，后续继续发起交易查询。
                        //TODO 
                    }
                    else
                    {
                        //其他应答码做以失败处理
                        //TODO 
                    }
                }
            }
            else
            {
                LogHelper.Add("请求失败，http状态：" + status + "\n");
            }
            } 
            catch (Exception ex)
            {
                LogHelper.Add("bool UnionPay.Query(PurchaseQueryReq req, ref PurchaseQueryRes res)", ex);
                return false;
            }

            return false;

        }

        /// <summary>
        /// 是否支持撤费
        /// </summary>
        public bool IsEnableCancel
        {
            get { return true; }
        }


        public string GetOrderNo(IDictionary<string, string> param)
        {
            if (param!=null && param.ContainsKey("orderId"))
            {
                return param["orderId"];
            }

            return string.Empty;
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

                /**
             * 重要：联调测试时请仔细阅读注释！
             * 
             * 产品：跳转网关支付产品<br>
             * 交易：交易状态查询交易：只有同步应答 <br>
             * 日期： 2015-09<br>
             * 版本： 1.0.0 
             * 版权： 中国银联<br>
             * 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己需要，按照技术文档编写。该代码仅供参考，不提供编码性能及规范性等方面的保障<br>
             * 该接口参考文档位置：open.unionpay.com帮助中心 下载  产品接口规范  《网关支付产品接口规范》，<br>
             *              《平台接入接口规范-第5部分-附录》（内包含应答码接口规范，全渠道平台银行名称-简码对照表）<br>
             * 测试过程中的如果遇到疑问或问题您可以：1）优先在open平台中查找答案：
             * 							        调试过程中的问题或其他问题请在 https://open.unionpay.com/ajweb/help/faq/list 帮助中心 FAQ 搜索解决方案
             *                             测试过程中产生的6位应答码问题疑问请在https://open.unionpay.com/ajweb/help/respCode/respCodeList 输入应答码搜索解决方案
             *                           2） 咨询在线人工支持： open.unionpay.com注册一个用户并登陆在右上角点击“在线客服”，咨询人工QQ测试支持。
             * 交易说明： 1）对前台交易发起交易状态查询：前台类交易建议间隔（5分、10分、30分、60分、120分）发起交易查询，如果查询到结果成功，则不用再查询。（失败，处理中，查询不到订单均可能为中间状态）。也可以建议商户使用payTimeout（支付超时时间），过了这个时间点查询，得到的结果为最终结果。
             *        2）对后台交易发起交易状态查询：后台类资金类交易同步返回00，成功银联有后台通知，商户也可以发起 查询交易，可查询N次（不超过6次），每次时间间隔2N秒发起,即间隔1，2，4，8，16，32S查询（查询到03，04，05继续查询，否则终止查询）。
             *        					         后台类资金类同步返03 04 05响应码及未得到银联响应（读超时）需发起查询交易，可查询N次（不超过6次），每次时间间隔2N秒发起,即间隔1，2，4，8，16，32S查询（查询到03，04，05继续查询，否则终止查询）。
             */

                var payConfig = GetConfig(info.ParkCode, info.Purpose);
                var param = new Dictionary<string, string>();

                //以下信息非特殊情况不需要改动
                param["version"] = "5.0.0";//版本号
                param["encoding"] = "UTF-8";//编码方式
                param["certId"] = CertUtil.GetSignCertId(payConfig.Pfx, payConfig.PfxPwd);//证书ID
                param["signMethod"] = "01";//签名方法
                param["txnType"] = "00";//交易类型
                param["txnSubType"] = "00";//交易子类
                param["bizType"] = "000000";//业务类型
                param["accessType"] = "0";//接入类型
                param["channelType"] = "07";//渠道类型

                //信息需要填写
                param["orderId"] = info.OrderNo;	//请修改被查询的交易的订单号，8-32位数字字母，不能含“-”或“_”，此处默认取demo演示页面传递的参数
                param["merId"] = payConfig.MchId;//商户代码，请改成自己的测试商户号，此处默认取demo演示页面传递的参数
                param["txnTime"] = info.OrderTime.ToString("yyyyMMddHHmmss");//请修改被查询的交易的订单发送时间，格式为YYYYMMDDhhmmss，此处默认取demo演示页面传递的参数

                SDKUtil.Sign(param, Encoding.UTF8, payConfig.Pfx, payConfig.PfxPwd);  // 签名
                string url = SDKConfig.SingleQueryUrl;
                var hc = new HttpClient(url);
                int status = hc.Send(param, Encoding.UTF8);
                string result = hc.Result;


                if (status == 200)
                {
                    Dictionary<string, string> resData = SDKUtil.CoverStringToDictionary(result);

                    if (SDKUtil.Validate(resData, Encoding.UTF8, payConfig.PlatformPublicCer))
                    {
                        string respcode = resData["respCode"]; //其他应答参数也可用此方法获取
                        if ("00" == respcode)
                        {
                            string origRespCode = resData["origRespCode"]; //其他应答参数也可用此方法获取
                            //处理被查询交易的应答码逻辑
                            if ("00" == origRespCode)
                            { 
                                #region 打印订单查询反馈日志
                                LogHelper.Add(string.Format("{0} {1}", "UnionPay 订单查询反馈：", result));
                                #endregion
                                 
                                return true;
                            }
                            else if ("03" == origRespCode ||
                                "04" == origRespCode ||
                                "05" == origRespCode)
                            {
                                //需再次发起交易状态查询交易
                                //交易处理中，稍后查询 
                            }
                            else
                            {
                                //其他应答码做以失败处理  交易失败  
                            }
                        }
                        else if ("03" == respcode ||
                                "04" == respcode ||
                                "05" == respcode)
                        {
                            //不明原因超时，后续继续发起交易查询。
                            //TODO 
                        }
                        else
                        {
                            //其他应答码做以失败处理
                            //TODO 
                        }
                    }
                }
                else
                {
                    LogHelper.Add("请求失败，http状态：" + status + "\n");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Add("bool UnionPay.Query(PurchaseQueryReq req, ref PurchaseQueryRes res)", ex);
                return false;
            }

            return false;
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

                /**
             * 重要：联调测试时请仔细阅读注释！
             * 
             * 产品：跳转网关支付产品<br>
             * 交易：消费撤销类交易：后台消费撤销交易，有同步应答和后台通知应答<br>
             * 日期： 2015-09<br>
             * 版权： 中国银联<br>
             * 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己需要，按照技术文档编写。该代码仅供参考，不提供编码性能规范性等方面的保障<br>
             * 该接口参考文档位置：open.unionpay.com帮助中心 下载  产品接口规范  《网关支付产品接口规范》<br>
             *              《平台接入接口规范-第5部分-附录》（内包含应答码接口规范，全渠道平台银行名称-简码对照表）<br>
             * 测试过程中的如果遇到疑问或问题您可以：1）优先在open平台中查找答案：
             * 							        调试过程中的问题或其他问题请在 https://open.unionpay.com/ajweb/help/faq/list 帮助中心 FAQ 搜索解决方案
             *                             测试过程中产生的6位应答码问题疑问请在https://open.unionpay.com/ajweb/help/respCode/respCodeList 输入应答码搜索解决方案
             *                          2） 咨询在线人工支持： open.unionpay.com注册一个用户并登陆在右上角点击“在线客服”，咨询人工QQ测试支持。
             * 交易说明:1）以后台通知或交易状态查询交易确定交易成功
             *       2）消费撤销仅能对当清算日的消费做，必须为全额，一般当日或第二日到账。
             */

                var payConfig = GetConfig(info.ParkCode, info.Purpose);
                var param = new Dictionary<string, string>();

                //以下信息非特殊情况不需要改动
                param["version"] = "5.0.0";//版本号
                param["encoding"] = "UTF-8";//编码方式
                param["certId"] = CertUtil.GetSignCertId(payConfig.Pfx, payConfig.PfxPwd);//证书ID
                param["signMethod"] = "01";//签名方法
                param["txnType"] = "31";//交易类型
                param["txnSubType"] = "00";//交易子类
                param["bizType"] = "000201";//业务类型
                param["accessType"] = "0";//接入类型
                param["channelType"] = "07";//渠道类型
                param["backUrl"] = SDKConfig.BackUrl;  //后台通知地址

                var cancelOrderNo = Spanner.GetOrderNo();
                //以下信息需要填写 
                param["orderId"] = cancelOrderNo;//商户订单号，8-32位数字字母，不能含“-”或“_”，可以自行定制规则，重新产生，不同于原消费，此处默认取demo演示页面传递的参数
                param["merId"] = payConfig.MchId;//商户代码，请改成自己的测试商户号，此处默认取demo演示页面传递的参数
                param["origQryId"] = info.qn;//原消费的queryId，可以从查询接口或者通知接口中获取，此处默认取demo演示页面传递的参数
                param["txnTime"] = info.OrderTime.ToString("yyyyMMddHHmmss");//订单发送时间，格式为YYYYMMDDhhmmss，重新产生，不同于原消费，此处默认取demo演示页面传递的参数，参考取法： DateTime.Now.ToString("yyyyMMddHHmmss")
                param["txnAmt"] = ((int)(info.OrderMoney * 100)).ToString(); //交易金额，消费撤销时需和原消费一致，此处默认取demo演示页面传递的参数
                //param["reqReserved"] = "透传信息";//请求方保留域，透传字段，查询、通知、对账文件中均会原样出现，如有需要请启用并修改自己希望透传的数据

                SDKUtil.Sign(param, Encoding.UTF8, payConfig.Pfx, payConfig.PfxPwd);  // 签名
                string url = SDKConfig.BackTransUrl;
                var hc = new HttpClient(url);
                int status = hc.Send(param, Encoding.UTF8);
                string result = hc.Result;
                if (status == 200)
                {
                    Dictionary<string, string> resData = SDKUtil.CoverStringToDictionary(result);

                    if (SDKUtil.Validate(resData, Encoding.UTF8, payConfig.PlatformPublicCer))
                    {
                        string respcode = resData["respCode"]; //其他应答参数也可用此方法获取
                        if ("00" == respcode)
                        {
                            //交易已受理，等待接收后台通知更新订单状态，如果通知长时间未收到也可发起交易状态查询 
                            info.CancelOrderNo = cancelOrderNo;
                            return true;
                        }
                        else if ("03" == respcode ||
                                "04" == respcode ||
                                "05" == respcode)
                        {
                            //后续需发起交易状态查询交易确定交易状态
                            //TODO 
                        }
                        else
                        {
                            //其他应答码做以失败处理
                            //TODO 
                        }
                    }
                    else
                    {
                        LogHelper.Add("商户端验证返回报文签名失败。<br>\n");
                    }
                }
                else
                {
                    LogHelper.Add("请求失败，http状态：" + status + "。<br>\n");
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
        /// 检测异步回调的支付通知
        /// </summary>
        /// <param name="info"></param> 
        /// <returns></returns>
        public PurchaseNotify CheckNotify(CallBackPaymentInfo info)
        {
            try
            {
                var param = info.Param;
                var type = info.Type;

                if (param.Count > 0 && type == PaymentType.UnionPay)
                {
                    var payConfig = GetConfig(info.ParkCode, info.Purpose);
                    if (SDKUtil.Validate(param as Dictionary<string, string>, Encoding.UTF8, payConfig.PlatformPublicCer))
                    {   
                        // 服务器签名验证成功
                        //请在这里加上商户的业务逻辑程序代码
                        //获取通知返回参数，可参考接口文档中通知参数列表(以下仅供参考)
                        var respCode = param["respCode"];// 交易状态

                        if ("" != respCode && "00" == respCode)
                        {
                            // 交易处理成功
                            var orderNo = param["orderId"];
                            var orderMoney = decimal.Parse(param["txnAmt"])/100;
                            var qn = param["queryId"];

                            return new PurchaseNotify
                                {
                                    Qn = qn,
                                    OrderNo = orderNo,
                                    OrderMoney = orderMoney,
                                    Description = respCode
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
        /// <param name="info"></param> 
        /// <returns></returns>
        public CanceledPaymentInfo CheckCancelNotify(CallBackPaymentInfo info)
        {
            try
            {
                var param = info.Param;
                var type = info.Type;

                if (param.Count > 0 && type == PaymentType.UnionPay)
                {
                    var payConfig = GetConfig(info.ParkCode, info.Purpose);
                    if (SDKUtil.Validate(param as Dictionary<string, string>, Encoding.UTF8, payConfig.PlatformPublicCer))
                    {
                        //服务器签名验证成功
                        //请在这里加上商户的业务逻辑程序代码
                        //获取通知返回参数，可参考接口文档中通知参数列表(以下仅供参考)
                        var respCode = param["respCode"];// 交易状态

                        if ("" != respCode && "00" == respCode)
                        {
                            // 交易处理成功
                            var orderNo = param["orderId"];
                            var orderMoney = decimal.Parse(param["txnAmt"]) / 100;
                            var qn = param["origQryId"];

                            return new CanceledPaymentInfo
                            { 
                                OrderNo = orderNo,
                                OrderMoney = orderMoney,
                                CancelOrderNo = orderNo,
                                qn = qn
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
                LogHelper.Add("PurchaseReq UnionPay.CheckNotify(PAYMENTTYPE type, Dictionary<String, String> param)", ex);
                return null;
            }
        }

        public string PayName()
        {
            return "银联支付";
        }
    }
}
