using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2015/10/21
*/
namespace Lpn.Service.Helper.Db
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class TestjimDb
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

        #region Name
        private string _fName;

        /// <summary>
        /// Name
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

     }
}

