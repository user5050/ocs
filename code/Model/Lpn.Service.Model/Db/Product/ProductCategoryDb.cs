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
    public partial class ProductCategoryDb
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

        #region 分类名称
        private string _fName;

        /// <summary>
        /// 分类名称
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

        #region 是否显示(0否1是)
        private int _fIsShow;

        /// <summary>
        /// 是否显示(0否1是)
        /// </summary>
        public  int  IsShow
        {
            get
            {
                return  _fIsShow;
            }
            set
            {
                  _fIsShow = value;
            }
         }
        #endregion

     }
}

