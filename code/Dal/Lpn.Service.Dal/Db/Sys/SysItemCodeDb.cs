using System;

/*
* 由自动生成工具完成
* 描述:[sys_item_code]字典信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Sys
{
    /// <summary>
    /// [sys_item_code]字典信息
    /// </summary>
    [Serializable]
    public partial class SysItemCodeDb
    {
        #region 字典编号
        private int _fID;

        /// <summary>
        /// 字典编号
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

        #region 类别
        private string _fSort;

        /// <summary>
        /// 类别
        /// </summary>
        public  string  Sort
        {
            get
            {
                return  _fSort;
            }
            set
            {
                  _fSort = value;
            }
         }
        #endregion

        #region 键
        private string _fKey;

        /// <summary>
        /// 键
        /// </summary>
        public  string  Key
        {
            get
            {
                return  _fKey;
            }
            set
            {
                  _fKey = value;
            }
         }
        #endregion

        #region 值
        private string _fValue;

        /// <summary>
        /// 值
        /// </summary>
        public  string  Value
        {
            get
            {
                return  _fValue;
            }
            set
            {
                  _fValue = value;
            }
         }
        #endregion

        #region 描述
        private string _fDes;

        /// <summary>
        /// 描述
        /// </summary>
        public  string  Des
        {
            get
            {
                return  _fDes;
            }
            set
            {
                  _fDes = value;
            }
         }
        #endregion

     }
}

