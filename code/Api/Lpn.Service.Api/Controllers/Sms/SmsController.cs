using System;
using System.Web.Mvc;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Bll.Logic.Sms;
using OneCoin.Service.Model.Config;
using OneCoin.Service.Model.Dto.Request.Sms;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Result;

/*
 * 描述: 短信发送
 * 作者: YT
 * 创建时间:2015/11/10
 */
namespace OneCoin.Service.Api.Controllers.Sms
{
    public class SmsController : Controller
    {
        /// <summary>
        /// 短信发送
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // GET: /Sms/Send
        public ActionResult Send(ReqSendDto data)
        {
            var smsConfig = WebConfig.SmsConfig;
            var randomCode = new Random().Next(9999).ToString().PadLeft(4, '0');
            return new ClientResult(SmsBll.SmsSend(smsConfig, data.Mobile, randomCode));
        }

        /// <summary>
        /// 短信验证码验证
        /// </summary> 
        /// <param name="data"></param>
        /// <returns></returns>
        // GET: /Sms/Validate
        public ActionResult Validate(ReqValidateDto data)
        {  
            var ret = SmsBll.Validate(data.Mobile, data.VCode);
            return new ClientResult( ret  ? ResultDto.DefaultSuccess():ResultDto.DefaultError(ResultState.GlobalVCodeError));
        }
    }
}
