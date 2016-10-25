using OneCoin.Service.Bll.Core;
using OneCoin.Service.Dal.Dal.Msg;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Extension.User;
using OneCoin.Service.Model.Result;

/*
 * 描述: 消息模块逻辑处理 
 * 作者:lee
 * 创建时间:2016/06/12
 */

namespace OneCoin.Service.Bll.Logic.Msg
{
    public class MsgInfoBll : BllBase
    { 

        #region 获取消息

        /// <summary>
        ///  获取消息
        /// </summary>  
        /// <returns></returns>
        public static ResultDto Gets(string userId,int skip,int take)
        {
            var msgs = MsgInfoDal.GetByUserId(userId, skip, take);

            return ResultDto.DefaultSuccess(msgs.ToSampleDto());
        }


        public static ResultDto GetDetail(string userId, long id)
        {
            var msg = MsgInfoDal.GetByPriKey(id);
            if (msg == null || msg.Uid != userId)
            {
                return ResultDto.DefaultError(ResultState.GlobalParameterError);
            }

            return ResultDto.DefaultSuccess(msg.ToDto());
        }

        public static ResultDto Del(string userId, long id)
        {
            var msg = MsgInfoDal.GetByPriKey(id);
            if (msg == null || msg.Uid != userId)
            {
                return ResultDto.DefaultError(ResultState.GlobalParameterError);
            }

            if (MsgInfoDal.DeleteByPriKey(id))
            {
                return ResultDto.DefaultSuccess();
            }

            return ResultDto.DefaultError(ResultState.GlobalSystemError);
        }
        #endregion
         
    }
}
