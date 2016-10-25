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
    public partial class GameShowDb
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

        #region 商品名称
        private string _fPName;

        /// <summary>
        /// 商品名称
        /// </summary>
        public  string  PName
        {
            get
            {
                return  _fPName;
            }
            set
            {
                  _fPName = value;
            }
         }
        #endregion

        #region 商品id
        private string _fPId;

        /// <summary>
        /// 商品id
        /// </summary>
        public  string  PId
        {
            get
            {
                return  _fPId;
            }
            set
            {
                  _fPId = value;
            }
         }
        #endregion

        #region 期号(活动前缀1610212210)
        private string _fGameNo;

        /// <summary>
        /// 期号(活动前缀1610212210)
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

        #region 评论
        private string _fComment;

        /// <summary>
        /// 评论
        /// </summary>
        public  string  Comment
        {
            get
            {
                return  _fComment;
            }
            set
            {
                  _fComment = value;
            }
         }
        #endregion

        #region 图片地址(多个逗号分隔)
        private string _fImgs;

        /// <summary>
        /// 图片地址(多个逗号分隔)
        /// </summary>
        public  string  Imgs
        {
            get
            {
                return  _fImgs;
            }
            set
            {
                  _fImgs = value;
            }
         }
        #endregion

        #region 购买次数
        private int _fBuyAmount;

        /// <summary>
        /// 购买次数
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

