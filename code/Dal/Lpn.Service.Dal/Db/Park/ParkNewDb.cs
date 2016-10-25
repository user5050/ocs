using System;

/*
* 由自动生成工具完成
* 描述:[park_news]停车场新闻列表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_news]停车场新闻列表
    /// </summary>
    [Serializable]
    public partial class ParkNewDb
    {
        #region 新闻编号
        private int _fNewsID;

        /// <summary>
        /// 新闻编号
        /// </summary>
        public  int  NewsID
        {
            get
            {
                return  _fNewsID;
            }
            set
            {
                  _fNewsID = value;
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

        #region 新闻类型
        private int _fInfoType;

        /// <summary>
        /// 新闻类型
        /// </summary>
        public  int  InfoType
        {
            get
            {
                return  _fInfoType;
            }
            set
            {
                  _fInfoType = value;
            }
         }
        #endregion

        #region 摘要
        private string _fAbstract;

        /// <summary>
        /// 摘要
        /// </summary>
        public  string  Abstract
        {
            get
            {
                return  _fAbstract;
            }
            set
            {
                  _fAbstract = value;
            }
         }
        #endregion

        #region 图片
        private string _fImg;

        /// <summary>
        /// 图片
        /// </summary>
        public  string  Img
        {
            get
            {
                return  _fImg;
            }
            set
            {
                  _fImg = value;
            }
         }
        #endregion

        #region 生成的html地址
        private string _fHtml;

        /// <summary>
        /// 生成的html地址
        /// </summary>
        public  string  Html
        {
            get
            {
                return  _fHtml;
            }
            set
            {
                  _fHtml = value;
            }
         }
        #endregion

        #region 操作员
        private int _fOperator;

        /// <summary>
        /// 操作员
        /// </summary>
        public  int  Operator
        {
            get
            {
                return  _fOperator;
            }
            set
            {
                  _fOperator = value;
            }
         }
        #endregion

        #region 创建时间
        private DateTime _fOperationTime;

        /// <summary>
        /// 创建时间
        /// </summary>
        public  DateTime  OperationTime
        {
            get
            {
                return  _fOperationTime;
            }
            set
            {
                  _fOperationTime = value;
            }
         }
        #endregion

        #region 是否发布
        private int _fIsPublished;

        /// <summary>
        /// 是否发布
        /// </summary>
        public  int  IsPublished
        {
            get
            {
                return  _fIsPublished;
            }
            set
            {
                  _fIsPublished = value;
            }
         }
        #endregion

        #region 跳转链接
        private string _fUrl;

        /// <summary>
        /// 跳转链接
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

        #region 发送时间
        private DateTime _fSendTime;

        /// <summary>
        /// 发送时间
        /// </summary>
        public  DateTime  SendTime
        {
            get
            {
                return  _fSendTime;
            }
            set
            {
                  _fSendTime = value;
            }
         }
        #endregion

        #region 灰度规则
        private string _fRule;

        /// <summary>
        /// 灰度规则
        /// </summary>
        public  string  Rule
        {
            get
            {
                return  _fRule;
            }
            set
            {
                  _fRule = value;
            }
         }
        #endregion

        #region 发布范围
        private int _fRuleType;

        /// <summary>
        /// 发布范围
        /// </summary>
        public  int  RuleType
        {
            get
            {
                return  _fRuleType;
            }
            set
            {
                  _fRuleType = value;
            }
         }
        #endregion

     }
}

