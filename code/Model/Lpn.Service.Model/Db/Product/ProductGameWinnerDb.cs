using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Product
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class ProductGameWinnerDb
    {
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

        #region 获奖者
        private string _fUid;

        /// <summary>
        /// 获奖者
        /// </summary>
        public  string  Uid
        {
            get
            {
                return  _fUid;
            }
            set
            {
                  _fUid = value;
            }
         }
        #endregion

        #region 商品id
        private string _fPid;

        /// <summary>
        /// 商品id
        /// </summary>
        public  string  Pid
        {
            get
            {
                return  _fPid;
            }
            set
            {
                  _fPid = value;
            }
         }
        #endregion

        #region 参与次数
        private int _fBuyAmount;

        /// <summary>
        /// 参与次数
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

        #region 揭晓时间
        private DateTime _fRowTime;

        /// <summary>
        /// 揭晓时间
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

        #region 中奖号
        private int _fWinNo;

        /// <summary>
        /// 中奖号
        /// </summary>
        public  int  WinNo
        {
            get
            {
                return  _fWinNo;
            }
            set
            {
                  _fWinNo = value;
            }
         }
        #endregion

     }
}

