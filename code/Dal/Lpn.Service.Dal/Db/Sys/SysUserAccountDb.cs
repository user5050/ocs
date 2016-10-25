using System;

/*
* 由自动生成工具完成
* 描述:[sys_user_account]E泊帐户表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Sys
{
    /// <summary>
    /// [sys_user_account]E泊帐户表
    /// </summary>
    [Serializable]
    public partial class SysUserAccountDb
    {
        #region 用户编号
        private int _fUserID;

        /// <summary>
        /// 用户编号
        /// </summary>
        public  int  UserID
        {
            get
            {
                return  _fUserID;
            }
            set
            {
                  _fUserID = value;
            }
         }
        #endregion

        #region 剩余金额
        private decimal _fBalanceMoney;

        /// <summary>
        /// 剩余金额
        /// </summary>
        public  decimal  BalanceMoney
        {
            get
            {
                return  _fBalanceMoney;
            }
            set
            {
                  _fBalanceMoney = value;
            }
         }
        #endregion

        #region 账户余额中存储的验证码
        private string _fSign;

        /// <summary>
        /// 账户余额中存储的验证码
        /// </summary>
        public  string  Sign
        {
            get
            {
                return  _fSign;
            }
            set
            {
                  _fSign = value;
            }
         }
        #endregion

        #region 备注信息
        private string _fMemo;

        /// <summary>
        /// 备注信息
        /// </summary>
        public  string  Memo
        {
            get
            {
                return  _fMemo;
            }
            set
            {
                  _fMemo = value;
            }
         }
        #endregion

        #region 操作时间
        private DateTime _fOperateTime;

        /// <summary>
        /// 操作时间
        /// </summary>
        public  DateTime  OperateTime
        {
            get
            {
                return  _fOperateTime;
            }
            set
            {
                  _fOperateTime = value;
            }
         }
        #endregion

        #region 操作人员编号
        private int _fOperatorID;

        /// <summary>
        /// 操作人员编号
        /// </summary>
        public  int  OperatorID
        {
            get
            {
                return  _fOperatorID;
            }
            set
            {
                  _fOperatorID = value;
            }
         }
        #endregion

     }
}

