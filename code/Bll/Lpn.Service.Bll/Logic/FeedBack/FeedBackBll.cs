using System;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Cache.FrequencyCtl;
using OneCoin.Service.Dal.Dal.Feed;
using OneCoin.Service.Model.Db.Feed;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Result;

namespace OneCoin.Service.Bll.Logic.FeedBack
{
    public class FeedBackBll : BllBase
    {
        /// <summary>
        /// 保存反馈意见
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="content"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        public static ResultDto Save(string userId, string content, string contact)
        {
            if (!FrequencyCtlCacheMgr.IsCanDo("feedback", userId))
            {
                return ResultDto.DefaultError(ResultState.GlobalTooFrequency);
            }

            if (FeedBackDal.Insert(new FeedBackDb
               {
                   Uid = userId,
                   Content = content,
                   RowTime = DateTime.Now
               }))
            {
                FrequencyCtlCacheMgr.AddActionLog("feedback", userId, TimeSpan.FromMilliseconds(30));

                return ResultDto.DefaultSuccess();
            }

            return ResultDto.DefaultError(ResultState.GlobalParameterError);
        }
    }
}
