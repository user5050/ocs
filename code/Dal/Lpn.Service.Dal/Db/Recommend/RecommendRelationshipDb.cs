using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Recommend
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class RecommendRelationshipDb
    {
        #region 推荐者ID
        private int _fUserId;

        /// <summary>
        /// 推荐者ID
        /// </summary>
        public  int  UserId
        {
            get
            {
                return  _fUserId;
            }
            set
            {
                  _fUserId = value;
            }
         }
        #endregion

        #region 领用者手机号
        private string _fReceiveMobile;

        /// <summary>
        /// 领用者手机号
        /// </summary>
        public  string  ReceiveMobile
        {
            get
            {
                return  _fReceiveMobile;
            }
            set
            {
                  _fReceiveMobile = value;
            }
         }
        #endregion

        #region 是否已注册领取(0:未领取　1:已领取)
        private int _fIsReceive;

        /// <summary>
        /// 是否已注册领取(0:未领取　1:已领取)
        /// </summary>
        public  int  IsReceive
        {
            get
            {
                return  _fIsReceive;
            }
            set
            {
                  _fIsReceive = value;
            }
         }
        #endregion

        #region 创建时间
        private DateTime _fRowTime;

        /// <summary>
        /// 创建时间
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

        #region 领用时间
        private DateTime _fReceiveTime;

        /// <summary>
        /// 领用时间
        /// </summary>
        public  DateTime  ReceiveTime
        {
            get
            {
                return  _fReceiveTime;
            }
            set
            {
                  _fReceiveTime = value;
            }
         }
        #endregion

     }
}

