using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Game
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class GameMemberDb
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

        #region 活动期号
        private string _fGameNo;

        /// <summary>
        /// 活动期号
        /// </summary>
        public  string  GameNo
        {
            get
            {
                return  _fGameNo;
            }
            set
            {
                  _fGameNo = value;
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

        #region ip地址
        private string _fIpAddr;

        /// <summary>
        /// ip地址
        /// </summary>
        public  string  IpAddr
        {
            get
            {
                return  _fIpAddr;
            }
            set
            {
                  _fIpAddr = value;
            }
         }
        #endregion

        #region 购买数量
        private int _fBuyAmount;

        /// <summary>
        /// 购买数量
        /// </summary>
        public  int  BuyAmount
        {
            get
            {
                return  _fBuyAmount;
            }
            set
            {
                  _fBuyAmount = value;
            }
         }
        #endregion

        #region 开始号码(包含)
        private int _fStartNo;

        /// <summary>
        /// 开始号码(包含)
        /// </summary>
        public  int  StartNo
        {
            get
            {
                return  _fStartNo;
            }
            set
            {
                  _fStartNo = value;
            }
         }
        #endregion

        #region 结束号码(包含)
        private int _fEndNo;

        /// <summary>
        /// 结束号码(包含)
        /// </summary>
        public  int  EndNo
        {
            get
            {
                return  _fEndNo;
            }
            set
            {
                  _fEndNo = value;
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

     }
}

