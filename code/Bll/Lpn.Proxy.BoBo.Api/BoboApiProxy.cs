using System;
using Lpn.Proxy.BoBo.Api.Model.Request;
using Lpn.Proxy.BoBo.Api.Model.Response;
using Newtonsoft.Json;

namespace Lpn.Proxy.BoBo.Api
{
    public class BoboApiProxy : BaseProxy
    {
        /// <summary>
        /// 4.2用户的出入场的车牌识别时间接口
        /// </summary>
        /// <param name="carNumber"></param>
        /// <param name="importTime">1440495067742</param>
        /// <param name="exportTime">1440495067742  </param>
        /// <param name="conAmount">单位(元)</param>
        /// <param name="paymentMethod">1:现金支付，2:app支付</param>
        /// <returns></returns>
        public static ResDto GetImportExportTime(string carNumber, long importTime, long exportTime, double conAmount, int paymentMethod)
        {
            var content = Query("ebBerthOrder_getImportExportTime", new ReqDto
                {
                    para = new ReqCarInOrOutDto
                        {
                            carNumber = carNumber,
                            conAmount = importTime > 0 ? "" : ((int)(conAmount * 100)).ToString(),
                            exportTime = exportTime <= 0 ? "" : exportTime.ToString(),
                            importTime = importTime <=0 ? "" : importTime.ToString(),
                            paymentMethod = importTime > 0 ? "" : paymentMethod.ToString()
                        }
                });

            if (String.IsNullOrEmpty(content))
            {
                return new ResDto {head = new ResHeadDto {code = "-1", msg = "超时"}};
            }

            return JsonConvert.DeserializeObject<ResDto>(content);
        }


        /// <summary>
        /// 4.3用户线下缴费成功通知接口
        /// </summary>
        /// <param name="carNumber"></param>
        /// <param name="linepayment">是否线下缴费（1：是，0：否）</param> 
        /// <param name="conAmount">单位(元)</param>
        /// <returns></returns>
        public static ResDto IsLinePayment(string carNumber, int linepayment,   double conAmount)
        {
            var content = Query("ebBerthOrder_isLinePayment", new ReqDto
            {
                para = new ReqofflinePayDto
                {
                    carNumber = carNumber,
                    conAmount = ((int)(conAmount * 100)).ToString(),
                    linepayment = linepayment.ToString()
                }
            });

            if (String.IsNullOrEmpty(content))
            {
                return new ResDto { head = new ResHeadDto { code = "-1", msg = "超时" } };
            }

            return JsonConvert.DeserializeObject<ResDto>(content);
        }



        /// <summary>
        /// 4.4退费接口
        /// </summary>
        /// <param name="carNumber"></param> 
        /// <param name="conAmount">单位(元)</param>
        /// <returns></returns>
        public static ResDto ReAmount(string carNumber,double conAmount)
        {
            var content = Query("ebBerthOrder_reAmount", new ReqDto
            {
                para = new ReqCancelOrderDto
                {
                    carNumber = carNumber,
                    reAmount = ((int)(conAmount * 100)).ToString()
                }
            });

            if (String.IsNullOrEmpty(content))
            {
                return new ResDto { head = new ResHeadDto { code = "-1", msg = "超时" } };
            }

            return JsonConvert.DeserializeObject<ResDto>(content);
        }
    }
}
