using System;
using System.Collections.Generic;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Bll.Logic.Sms;
using OneCoin.Service.Cache.Token;
using OneCoin.Service.Cache.User;
using OneCoin.Service.Dal.Dal.User;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Db.User;
using OneCoin.Service.Model.Dto.Response.User;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Extension.Dto;
using OneCoin.Service.Model.Extension.User;
using OneCoin.Service.Model.Result;

namespace OneCoin.Service.Bll.Logic.SysUser
{
    public class UserBll : BllBase
    {
        #region 账号登录或注册

        /// <summary>
        /// 账号登录或注册
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="vcode"></param> 
        /// <param name="devicetoken"></param> 
        /// <param name="clientType"></param>
        /// <returns></returns>
        public static ResultDto LoginOrRegist(string mobile, string vcode, string devicetoken,int clientType)
        {
            // 首先检查验证码是否正确
            if (!SmsBll.Validate(mobile, vcode))
            {
                return ResultDto.DefaultError(ResultState.GlobalVCodeError);
            }

            var user = GetUserByName(mobile);

            // 检查是否已注册,未注册则新增账号
            if (user == null)
            {
                // 注册基本账号和支付账号
                user = Regist(mobile, clientType,devicetoken);
                if (user == null)
                {
                    return ResultDto.DefaultError(ResultState.GlobalDbError);
                }
            }

             
            //相关更新
            TryUpdateExtreData(user, devicetoken);
           
            return ResultDto.DefaultSuccess(GetLoginDto(user));
        }

        /// <summary>
        /// 更新IOS 标示
        /// </summary>
        /// <param name="user"></param> 
        /// <param name="devicetoken"></param> 
        private static void TryUpdateExtreData(UserBaseDb user,  string devicetoken )
        { 
            if(!string.IsNullOrEmpty(devicetoken))
                UserBaseDal.UpdateDt(user.Id,devicetoken); 
        }


        /// <summary>
        /// 生成标示
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private static string GenericToken(string userId)
        {
            var token = Guid.NewGuid().ToString("N");

            if (TokenCacheMgr.SetUserId(token, userId))
            {
                return token;
            }

            return string.Empty;
        }

        #endregion

        #region 更新用户信息

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userId"></param> 
        /// <param name="nickname"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ResultDto Update(string userId,string nickname, string head)
        {
            var user = GetById(userId);
            if (user == null)
            {
                return ResultDto.DefaultError(ResultState.GlobalParameterError);
            }

            if (!string.IsNullOrEmpty(nickname))
            {
                user.Name = nickname;
            }

            if (!string.IsNullOrEmpty(head))
            {
                user.Head = head;
            }

            
            if (UserBaseDal.UpdateByPriKey(user))
            {
                return ResultDto.DefaultSuccess();
            }

            return ResultDto.DefaultError(ResultState.GlobalDbError);
        }
        #endregion

        #region 更新头像

        /// <summary>
        /// 更新头像
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ResultDto UpdateHead(string userId, string head)
        {
            var user = GetById(userId);
            if (user == null)
            {
                return ResultDto.DefaultError(ResultState.GlobalParameterError);
            }

            if (!string.IsNullOrEmpty(head))
            {
                user.Head = head.ToFullUrl();
            }

            if (UserBaseDal.UpdateByPriKey(user))
            {
                return ResultDto.DefaultSuccess(user.Head.ToFullUrl());
            }

            return ResultDto.DefaultError(ResultState.GlobalDbError);
        }

        #endregion

        #region 退出登录
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static ResultDto Quit(string userId,string token)
        {
            if (TokenCacheMgr.RemoveToken(userId, token))
            {
                return ResultDto.DefaultSuccess();
            }

            return ResultDto.DefaultError(ResultState.GlobalParameterError);
        }
        #endregion

        #region 重新绑定手机号

        /// <summary>
        /// 重新绑定手机号
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="mobile"></param>
        /// <param name="vcode"></param>
        /// <returns></returns>
        public static ResultDto BindMobile(string userId, string mobile, string vcode)
        {
            // 验证短信码是否正确
            if (!SmsBll.Validate(mobile, vcode))
            {
                return ResultDto.DefaultError(ResultState.GlobalVCodeError);
            }

            var user = GetById(userId);
            if (user == null)
            {
                return ResultDto.DefaultError(ResultState.GlobalParameterError);
            }


            var prvMobile = user.Mobile;
            user.Name = Spanner.MarkMobile(mobile);
            user.Mobile = mobile;

            // 检查mobile是否已经注册
            if (IsRegist(mobile))
            {
                return ResultDto.DefaultError(ResultState.AccountAccountIsRegisted);
            }

            // 清除旧缓存
            UserCacheMgr.RemoveUserIdNameMap(prvMobile, user.Id);

            // 更新数据
            if (!UserBaseDal.UpdateByPriKey(user))
            {
                return ResultDto.DefaultError(ResultState.GlobalDbError);
            }

            // 更新缓存
            UserCacheMgr.SetUserIdNameMap(user.Mobile, user.Id);

            return ResultDto.DefaultSuccess();
        }

        #endregion

        #region internal

        #region 账号注册

        /// <summary>
        /// 账号注册
        /// </summary>
        /// <param name="mobile"></param> 
        /// <param name="clientType"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static UserBaseDb Regist(string mobile, int clientType, string dt)
        {
            var username = Spanner.MarkMobile(mobile);


            var data = new UserBaseDb
                {
                    Mobile = mobile,
                    Name = username,
                    ClientType = clientType,
                    DeviceToken = dt,
                    Id = Spanner.GetGuid(),
                    Head = "",
                    RegTime = DateTime.Now,
                    State = 1
                };

            if (UserBaseDal.Insert(data))
            {
                return data;
            }


            return null;
        }

        #endregion

        #region  账号是否存在
        /// <summary>
        /// 账号是否存在
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns></returns>
        internal static bool IsRegist(string userName)
        {
            return UserBaseDal.IsExistsUserName(userName);
        }
        #endregion

        #region  获取指定账户
        /// <summary>
        /// 获取指定账户
        /// </summary>
        /// <param name="userId">账号Id</param>
        /// <returns></returns>
        internal static UserBaseDb GetById(string userId)
        {
            return UserBaseDal.GetByPriKey(userId);
        }
        #endregion
         

        #endregion

        #region 通过用户编号查询用户信息
         

        #region 获取账号查询数据
        /// <summary>
        /// 获取账号查询数据
        /// </summary>
        /// <param name="mobile">账号</param> 
        /// <returns>SysUserDb</returns>
        internal static UserBaseDb GetUserByName(string mobile)
        {
            return UserBaseDal.GetUserByName(mobile);
        }
        #endregion


        #region 获取账号查询数据
        /// <summary>
        /// 获取账号查询数据
        /// </summary>
        /// <param name="userIds">账号</param> 
        /// <returns>SysUserDb</returns>
        internal static List<UserBaseDb> GetUsers(List<string> userIds)
        {
            return UserBaseDal.GetUsers(userIds);
        }
        #endregion
         
        #endregion
          
        #region private

        private static ResLoginDto GetLoginDto(UserBaseDb user)
        { 

            // App登录会导致token失效,微信登陆不刷新token;
            var token = GenericToken(user.Id);
            
            return user.ToLoginDto(token);
        }
         
        
        #endregion
    }
}
