using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Api.Filters;
using OneCoin.Service.Bll.Logic.Orders;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Dto.Request.PayPlatform;
using OneCoin.Service.Model.Dto.Response.PayPlatform;
using OneCoin.Service.Model.Enum.Payment;
/*
* 描述: 支付回调接口
* 作者:lee
* 创建时间:2015/11/09
*/
namespace OneCoin.Service.Api.Controllers.PayPlatform
{
    [TraceLog]
    public class PayPlatformController : Controller
    {
        // 微信支付回调
        // GET: /PayPlatform/WexinCallBack

        public ActionResult WexinCallBack()
        {
            var data = Spanner.GetHttpFormData();

            using (var io = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                var doc = XDocument.Load(io);
                var sReturncode = doc.Element("xml").Element("return_code").Value;

                var param = new SortedDictionary<String, String>();

                if (sReturncode.Equals("FAIL"))
                {
                    var wr = new ResWexinCallBackDto {Return_msg = "SUCCESS", Return_code = "OK"};
                    var retStr = wr.Serialize();

                    return new TextResult(retStr,false);
                }
                else
                {
                    var query = from item in doc.Descendants("xml")
                                select item;
                    foreach (var item in query)
                    {
                        foreach (var c in item.Elements())
                        {
                            param.Add(c.Name.LocalName, c.Value);
                        }
                    }
                }

                var ret = OrdersBll.PaySuccessCallBack(PaymentType.WeixinPay, param);
                if (ret.IsSuccess)
                {
                    var wr = new ResWexinCallBackDto {Return_code = "SUCCESS", Return_msg = "OK"};
                    var retStr = wr.Serialize();

                    return new TextResult(retStr, false);
                }
                else
                {
                    var wr = new ResWexinCallBackDto { Return_code = "FAIL", Return_msg = "处理失败" };
                    var retStr = wr.Serialize();

                    return new TextResult(retStr, false);
                } 
            } 
        }


        // 支付宝支付回调
        // GET: /PayPlatform/AlipayCallBack

        public ActionResult AlipayCallBack()
        {
            var data = Spanner.GetHttpFormData();

            var cols = HttpUtility.ParseQueryString(data);

            var param = new SortedDictionary<String, String>();
            foreach (string key in cols.Keys)
            {
                if (!param.ContainsKey(key))
                    param.Add(key, cols[key]);
            }

            var ret = OrdersBll.PaySuccessCallBack(PaymentType.AliPay, param);

            return new TextResult(ret.IsSuccess ? "success" : "fail", false);
        }


        // 银联支付异步回调
        // GET: /PayPlatform/UnionPayCallBack

        public ActionResult UnionPayCallBack()
        {
            var data = Spanner.GetHttpFormData();

            var cols = HttpUtility.ParseQueryString(data);

            var param = new SortedDictionary<String, String>();
            foreach (string key in cols.Keys)
            {
                if (!param.ContainsKey(key))
                    param.Add(key, cols[key]);
            }

            var ret = OrdersBll.PaySuccessCallBack(PaymentType.UnionPay, param);

            return new TextResult(ret.IsSuccess ? "success" : "fail", false);
        }
         

        // 翼支付H5异步回调
        // GET: /PayPlatform/BestPayH5CallBack 

        public ActionResult BestPayH5CallBack()
        {
            var data = Spanner.GetHttpFormData();
            var cols = HttpUtility.ParseQueryString(data);

            var param = new SortedDictionary<String, String>();
            foreach (string key in cols.Keys)
            {
                if (!param.ContainsKey(key))
                    param.Add(key, cols[key]);
            }

            var ret = OrdersBll.PaySuccessCallBack(PaymentType.BestPayMobile, param);

            return new TextResult(ret.IsSuccess ? ret.Result.ToString() : "fail", false);
        }
        
    }
}
