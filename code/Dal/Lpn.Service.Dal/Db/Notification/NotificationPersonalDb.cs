using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Notification
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class NotificationPersonalDb
    {
        #region 编号
        private int _fId;

        /// <summary>
        /// 编号
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

        #region 用户编号
        private int _fUserid;

        /// <summary>
        /// 用户编号
        /// </summary>
        public  int  Userid
        {
            get
            {
                return  _fUserid;
            }
            set
            {
                  _fUserid = value;
            }
         }
        #endregion

        #region 消息类型
        private int _fType;

        /// <summary>
        /// 消息类型
        /// </summary>
        public  int  Type
        {
            get
            {
                return  _fType;
            }
            set
            {
                  _fType = value;
            }
         }
        #endregion

        #region 标题
        private string _fTitle;

        /// <summary>
        /// 标题
        /// </summary>
        public  string  Title
        {
            get
            {
                return  _fTitle;
            }
            set
            {
                  _fTitle = value;
            }
         }
        #endregion

        #region 内容
        private string _fContent;

        /// <summary>
        /// 内容
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

        #region 链接地址
        private string _fUrl;

        /// <summary>
        /// 链接地址
        /// </summary>
        public  string  Url
        {
            get
            {
                return  _fUrl;
            }
            set
            {
                  _fUrl = value;
            }
         }
        #endregion

        #region 是否已读
        private int _fViewed;

        /// <summary>
        /// 是否已读
        /// </summary>
        public  int  Viewed
        {
            get
            {
                return  _fViewed;
            }
            set
            {
                  _fViewed = value;
            }
         }
        #endregion

        #region 消息时间
        private DateTime _fTime;

        /// <summary>
        /// 消息时间
        /// </summary>
        public  DateTime  Time
        {
            get
            {
                return  _fTime;
            }
            set
            {
                  _fTime = value;
            }
         }
        #endregion

     }
}

