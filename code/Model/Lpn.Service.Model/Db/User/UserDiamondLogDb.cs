using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.User
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class UserDiamondLogDb
    {
        #region Id
        private long _fId;

        /// <summary>
        /// Id
        /// </summary>
        public  long  Id
        {
            get
            {
                return  _fId;
            }
            set
            {
                  _fId = value;
            }
         }
        #endregion

        #region 用户id
        private string _fUId;

        /// <summary>
        /// 用户id
        /// </summary>
        public  string  UId
        {
            get
            {
                return  _fUId;
            }
            set
            {
                  _fUId = value;
            }
         }
        #endregion

        #region 充值数量
        private int _fAmount;

        /// <summary>
        /// 充值数量
        /// </summary>
        public  int  Amount
        {
            get
            {
                return  _fAmount;
            }
            set
            {
                  _fAmount = value;
            }
         }
        #endregion

        #region 充值后数量
        private int _fAfterAmount;

        /// <summary>
        /// 充值后数量
        /// </summary>
        public  int  AfterAmount
        {
            get
            {
                return  _fAfterAmount;
            }
            set
            {
                  _fAfterAmount = value;
            }
         }
        #endregion

        #region IP地址
        private string _fClientIp;

        /// <summary>
        /// IP地址
        /// </summary>
        public  string  ClientIp
        {
            get
            {
                return  _fClientIp;
            }
            set
            {
                  _fClientIp = value;
            }
         }
        #endregion

        #region 时间
        private DateTime _fRowTime;

        /// <summary>
        /// 时间
        /// </summary>
        public  DateTime  RowTime
        {
            get
            {
                return  _fRowTime;
            }
            set
            {
                  _fRowTime = value;
            }
         }
        #endregion

        #region 订单编号
        private string _fRefOrderNo;

        /// <summary>
        /// 订单编号
        /// </summary>
        public  string  RefOrderNo
        {
            get
            {
                return  _fRefOrderNo;
            }
            set
            {
                  _fRefOrderNo = value;
            }
         }
        #endregion

     }
}

