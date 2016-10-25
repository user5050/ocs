using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Feed
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class FeedBackDb
    {
        #region Id
        private int _fId;

        /// <summary>
        /// Id
        /// </summary>
        public  int  Id
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
        private string _fUid;

        /// <summary>
        /// 用户id
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

        #region 反馈内容
        private string _fContent;

        /// <summary>
        /// 反馈内容
        /// </summary>
        public  string  Content
        {
            get
            {
                return  _fContent;
            }
            set
            {
                  _fContent = value;
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

