using System;

/*
* 由自动生成工具完成
* 描述:[coupon_random]评论池
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Coupon
{
    /// <summary>
    /// [coupon_random]评论池
    /// </summary>
    [Serializable]
    public partial class CouponRandomDb
    {
        #region 评论池编号
        private int _fID;

        /// <summary>
        /// 评论池编号
        /// </summary>
        public  int  ID
        {
            get
            {
                return  _fID;
            }
            set
            {
                  _fID = value;
            }
         }
        #endregion

        #region 评论类型
        private string _fTypeName;

        /// <summary>
        /// 评论类型
        /// </summary>
        public  string  TypeName
        {
            get
            {
                return  _fTypeName;
            }
            set
            {
                  _fTypeName = value;
            }
         }
        #endregion

        #region 评论
        private string _fRandomStr;

        /// <summary>
        /// 评论
        /// </summary>
        public  string  RandomStr
        {
            get
            {
                return  _fRandomStr;
            }
            set
            {
                  _fRandomStr = value;
            }
         }
        #endregion

     }
}

