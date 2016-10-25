using System;
using System.Collections.Generic;
using Kulv.YCF.Payment.Wing;
using Kulv.YCF.Payment.Wing.H5ForM;
using OneCoin.Payment;
using OneCoin.Payment.Entity;
using OneCoin.Payment.Plugins;
using OneCoin.Payment.Plugins.BestPay;
using OneCoin.Service.Model.Entity.Payment;
using OneCoin.Service.Model.Enum.Payment;

namespace Kulv.YCF.Payment.Core.PayServices.WingPay
{
    public class WingPayForMService
    { 
      
        //private object NewPayNotify(CompanyEnum companyId)
        //{
        //    HttpRequest request = HttpContext.Current.Request;
        //    SortedDictionary<string, string> sPara = PaymentTool.GetRequestPost(request);
        //    if (sPara.Count > 0)
        //    {
        //        var cryptTool = WingCryptToolFactory.GetCryptTool(companyId);
        //        var MERCHANTID = cryptTool.MERCHANTID;   //商户号
        //        var key = cryptTool.MERCHANTkey;         //商户key
        //        var UPTRANSEQ = request.Params["UPTRANSEQ"];            //交易流水号  商户必须保存该信息，作为对帐依据
        //        var TRANDATE = request.Params["TRANDATE"];              //交易日期
        //        var RETNCODE = request.Params["RETNCODE"];              //处理结果码 “0000” 表示支付成功，其他值则表示支付失败
        //        var RETNINFO = request.Params["RETNINFO"];              //处理结果解释码 对支付结果的说明码
        //        var ORDERREQTRANSEQ = request.Params["ORDERREQTRANSEQ"]; //订单请求交易流水号
        //        var ORDERSEQ = request.Params["ORDERSEQ"];               //订单号
        //        var ORDERAMOUNT = request.Params["ORDERAMOUNT"];         //订单总金额
        //        var PRODUCTAMOUNT = request.Params["PRODUCTAMOUNT"];     //产品金额
        //        var ATTACHAMOUNT = request.Params["ATTACHAMOUNT"];       //附加金额
        //        var CURTYPE = request.Params["CURTYPE"];
        //        var ENCODETYPE = request.Params["ENCODETYPE"];
        //        var ATTACH = request.Params["ATTACH"];
        //        var BANKID = request.Params["BANKID"];
        //        var PRODUCTNO = request.Params["PRODUCTNO"];
        //        var BANKACCID = request.Params["BANKACCID "];
        //        var ORDERVALIDITYFLAG = request.Params["ORDERVALIDITYFLAG"];

        //        var SIGN = request.Params["SIGN"];
        //        var signOrg = "UPTRANSEQ=" + UPTRANSEQ + "&" +
        //        "MERCHANTID=" + MERCHANTID + "&" +
        //        "ORDERSEQ=" + ORDERSEQ + "&" +
        //        "ORDERAMOUNT=" + ORDERAMOUNT + "&" +
        //        "RETNCODE=" + RETNCODE + "&" +
        //        "RETNINFO=" + RETNINFO + "&" +
        //        "TRANDATE=" + TRANDATE + "&" +
        //         "KEY=" + key;

        //        var signNew = cryptTool.getMd5Hash(signOrg);
        //        if (SIGN != null && SIGN.ToUpper().Equals(signNew.ToUpper()))
        //        {
        //            if ("0000".Equals(RETNCODE))
        //            {
        //                var responseStri = "UPTRANSEQ_" + UPTRANSEQ;
        //                PaymentLogger.Info("翼支付通知响应信息：" + responseStri);
        //                decimal totalFee = Convert.ToDecimal(ORDERAMOUNT);
        //                int payTypeId = (int)PayTypeEnum.Wing;
        //                string operatorName = "系统WingM" + payTypeId;
        //                //支付回写业务逻辑
        //                BusinessTransponder.PaymentNotify(payTypeId, ORDERSEQ, UPTRANSEQ, totalFee, operatorName, null, null, MERCHANTID);
        //                return responseStri;//请不要修改或删除
        //            }
        //            else
        //            {
        //                PaymentLogger.Error("支付失败：" + request.Url.ToString(), null);
        //                return "支付失败";
        //            }
        //        }
        //        else
        //        {
        //            PaymentLogger.Info("sign不一致，签名验证失败");
        //            return "sign不一致，签名验证失败";
        //        }
        //        //pc
        //        // UPTRANSEQ=20080101000001&MERCHANTID=0250000001&ORDERID=2006050112564931556&PAYMENT=10000&RETNCODE=0000&RETNINFO=0000&PAYDATE=20060101&KEY=344C4FB521F5A52EA28FB7FC79AEA889478D4343E4548C02
        //        //m
        //        // UPTRANSEQ=20080101000001&MERCHANTID=0250000001&ORDERSEQ=2006050112564931556&ORDERAMOUNT=10000&RETNCODE=0000&RETNINFO=0000&TRANDATE=20060101&KEY=344C4FB521F5A52EA28FB7FC79AEA889478D4343E4548C02
        //    }
        //    else
        //    {
        //        PaymentLogger.Error("翼支付订单回发验证失败，无通知参数.", null);
        //        return "无通知参数";
        //    }
        //}

       
    }
}
