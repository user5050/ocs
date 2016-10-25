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
    public partial class NopkDb
    {
        #region UserId
        private int _fUserId;

        /// <summary>
        /// UserId
        /// </summary>
        public  int  UserId
        {
            get
            {
                return  _fUserId;
            }
            set
            {
                  _fUserId = value;
            }
         }
        #endregion

        #region Mark
        private string _fMark;

        /// <summary>
        /// Mark
        /// </summary>
        public  string  Mark
        {
            get
            {
                return  _fMark;
            }
            set
            {
                  _fMark = value;
            }
         }
        #endregion

     }
}

