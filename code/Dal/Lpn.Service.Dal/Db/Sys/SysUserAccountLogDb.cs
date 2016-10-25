using System;

/*
* 由自动生成工具完成
* 描述:[sys_user_account_log]E泊帐户日志
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Sys
{
    /// <summary>
    /// [sys_user_account_log]E泊帐户日志
    /// </summary>
    [Serializable]
    public partial class SysUserAccountLogDb
    {
        #region 日志编号
        private long _fLogID;

        /// <summary>
        /// 日志编号
        /// </summary>
        public  long  LogID
        {
            get
            {
                return  _fLogID;
            }
            set
            {
                  _fLogID = value;
            }
         }
        #endregion

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

        #region 操作金额
        private decimal _fMoney;

        /// <summary>
        /// 操作金额
        /// </summary>
        public  decimal  Money
        {
            get
            {
                return  _fMoney;
            }
            set
            {
                  _fMoney = value;
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

        #region 操作类型
        private int _fOperationType;

        /// <summary>
        /// 操作类型
        /// </summary>
        public  int  OperationType
        {
            get
            {
                return  _fOperationType;
            }
            set
            {
                  _fOperationType = value;
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

        #region 操作人员ID
        private int _fOperatorID;

        /// <summary>
        /// 操作人员ID
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

        #region 订单号
        private string _fOrderNo;

        /// <summary>
        /// 订单号
        /// </summary>
        public  string  OrderNo
        {
            get
            {
                return  _fOrderNo;
            }
            set
            {
                  _fOrderNo = value;
            }
         }
        #endregion

     }
}

