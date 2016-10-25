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
    public partial class ProductDetailDb
    {
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

        #region 商品详情
        private string _fDetail;

        /// <summary>
        /// 商品详情
        /// </summary>
        public  string  Detail
        {
            get
            {
                return  _fDetail;
            }
            set
            {
                  _fDetail = value;
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

