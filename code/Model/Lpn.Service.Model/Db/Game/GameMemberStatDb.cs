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
    public partial class GameMemberStatDb
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

