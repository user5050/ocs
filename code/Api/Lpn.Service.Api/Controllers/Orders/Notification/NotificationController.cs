using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lpn.Service.Api.Core;
using Lpn.Service.Api.Core.Result;
using Lpn.Service.Api.Filters;
using Lpn.Service.Bll.Logic.Notification;
using Lpn.Service.Model.Dto.Request.Notification;

namespace Lpn.Service.Api.Controllers.Notification
{
    public class NotificationController : BaseController
    {
        //
        // GET: /Notification/

        /// <summary>
        /// 获取私有通知
        /// </summary>
        /// <returns></returns>
        [UserAuthFilter]
        public ActionResult PrivateNotification()
        {
            //UserId
            return new ClientResult(NotificationBll.PrivateNotification(UserId));
        }

        /// <summary>
        /// 获取系统通知
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        [UserAuthFilter]
        public ActionResult PublicNotification(string sn)
        {
            return new ClientResult(NotificationBll.PublicNotification(Convert.ToInt32(sn), UserId));
        }

        /// <summary>
        /// 添加系统消息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [CommAuthFilter]
        public ActionResult AddPublicNotification(ReqAddPublicNotificationDto data)
        {
            return new ClientResult(NotificationBll.AddPublicNotification(data.SN, data.Title, data.Content, data.Url));
        }

        /// <summary>
        /// 删除系统消息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [CommAuthFilter]
        public ActionResult RevmovePublicNotification(ReqRevmovePublicNotificationDto data)
        {
            return new ClientResult(NotificationBll.RevmovePublicNotification(data.SN));
        }

        /// <summary>
        /// 找回车牌申请成功的提醒
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [CommAuthFilter]
        public ActionResult SuccForRetrieveCarNo(ReqSuccForRetrieveCarNoDto data )
        {
            return new ClientResult(NotificationBll.SuccForRetrieveCarNo(data.CarNo));
        }
         

        /// <summary>
        ///  找回车牌申请失败的提醒
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [CommAuthFilter]
        public ActionResult FailForRetrieveCarNo(ReqFailForRetrieveCarNoDto data )
        {
            return new ClientResult(NotificationBll.FailForRetrieveCarNo(data.UserID,data.FailedReason,data.CarNo));
        }


        /// <summary>
        /// 找回车牌申请成功的提醒原绑定人
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [CommAuthFilter]
        public ActionResult SuccForRetrieveCarNoForPreBindUser(ReqSuccForRetrieveCarNoDto data)
        {
            return new ClientResult(NotificationBll.SuccForRetrieveCarNoByOther(data.UserId,data.CarNo));
        }

        /// <summary>
        /// 月租到期提醒
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [CommAuthFilter]
        public ActionResult SendMonthTimeOut(ReqSendMonthTimeOutDto data)
        {
            return new ClientResult(NotificationBll.SendMonthTimeOut(data.Userid, data.Carno, data.Parkname, data.tilldate));
        }

        /// <summary>
        /// 撤防失败
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [CommAuthFilter]
        public ActionResult SendAntithiefFailed(ReqSendAntithiefFailedDto data)
        {
            return new ClientResult(NotificationBll.SendAntithiefFailed(data.Userid, data.Carno));
        }

        /// <summary>
        /// 对用户发送系统消息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [CommAuthFilter]
        public ActionResult SendSystemMessage(ReqSendSystemMessageDto data)
        {
            return new ClientResult(NotificationBll.SendSystemMessage(data.UserId, data.Title, data.Summary, data.Content, data.Url, data.Sn));
        }

        /// <summary>
        /// 保险返还消息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [CommAuthFilter]
        public ActionResult SendBxfh(ReqSendBxfhDto data)
        {
            return new ClientResult(NotificationBll.SendBxfh(data.Mobiles));
        }
    }
}
