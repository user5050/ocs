using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Home
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class HomeBannerDb
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

        #region 图片地址
        private string _fImg;

        /// <summary>
        /// 图片地址
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

        #region 有效日期
        private DateTime _fStartTime;

        /// <summary>
        /// 有效日期
        /// </summary>
        public  DateTime  StartTime
        {
            get
            {
                return  _fStartTime;
            }
            set
            {
                  _fStartTime = value;
            }
         }
        #endregion

        #region 过期日期
        private DateTime _fExpriedTime;

        /// <summary>
        /// 过期日期
        /// </summary>
        public  DateTime  ExpriedTime
        {
            get
            {
                return  _fExpriedTime;
            }
            set
            {
                  _fExpriedTime = value;
            }
         }
        #endregion

        #region 跳转规则(商品，普通页,网页)
        private string _fUrl;

        /// <summary>
        /// 跳转规则(商品，普通页,网页)
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

        #region 排序编号
        private int _fOrder;

        /// <summary>
        /// 排序编号
        /// </summary>
        public  int  Order
        {
            get
            {
                return  _fOrder;
            }
            set
            {
                  _fOrder = value;
            }
         }
        #endregion

        #region (0商品，1普通页,2网页)
        private int _fType;

        /// <summary>
        /// (0商品，1普通页,2网页)
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

     }
}

