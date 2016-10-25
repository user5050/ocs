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
    public partial class ProductInfoDb
    {
        #region Id
        private string _fId;

        /// <summary>
        /// Id
        /// </summary>
        public  string  Id
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

        #region 期号前缀
        private string _fPreGameNo;

        /// <summary>
        /// 期号前缀
        /// </summary>
        public  string  PreGameNo
        {
            get
            {
                return  _fPreGameNo;
            }
            set
            {
                  _fPreGameNo = value;
            }
         }
        #endregion

        #region 商品名称
        private string _fName;

        /// <summary>
        /// 商品名称
        /// </summary>
        public  string  Name
        {
            get
            {
                return  _fName;
            }
            set
            {
                  _fName = value;
            }
         }
        #endregion

        #region 商品图片地址
        private string _fImg;

        /// <summary>
        /// 商品图片地址
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

        #region 售价
        private int _fOrderMoney;

        /// <summary>
        /// 售价
        /// </summary>
        public  int  OrderMoney
        {
            get
            {
                return  _fOrderMoney;
            }
            set
            {
                  _fOrderMoney = value;
            }
         }
        #endregion

        #region 多图地址
        private string _fImgs;

        /// <summary>
        /// 多图地址
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

        #region 状态(0无效1有效)
        private int _fState;

        /// <summary>
        /// 状态(0无效1有效)
        /// </summary>
        public  int  State
        {
            get
            {
                return  _fState;
            }
            set
            {
                  _fState = value;
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

        #region 分类id
        private string _fCategoryId;

        /// <summary>
        /// 分类id
        /// </summary>
        public  string  CategoryId
        {
            get
            {
                return  _fCategoryId;
            }
            set
            {
                  _fCategoryId = value;
            }
         }
        #endregion

        #region 排序
        private int _fOrder;

        /// <summary>
        /// 排序
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

     }
}

