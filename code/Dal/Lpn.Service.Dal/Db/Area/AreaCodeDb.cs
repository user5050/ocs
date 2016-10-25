using System;

/*
* 由自动生成工具完成
* 描述:[area_code]区域编码
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Area
{
    /// <summary>
    /// [area_code]区域编码
    /// </summary>
    [Serializable]
    public partial class AreaCodeDb
    {
        #region 区域编码编号
        private int _fID;

        /// <summary>
        /// 区域编码编号
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

        #region 区域编码
        private string _fCode;

        /// <summary>
        /// 区域编码
        /// </summary>
        public  string  Code
        {
            get
            {
                return  _fCode;
            }
            set
            {
                  _fCode = value;
            }
         }
        #endregion

        #region 已生成最大编码
        private int _fIndex;

        /// <summary>
        /// 已生成最大编码
        /// </summary>
        public  int  Index
        {
            get
            {
                return  _fIndex;
            }
            set
            {
                  _fIndex = value;
            }
         }
        #endregion

     }
}

