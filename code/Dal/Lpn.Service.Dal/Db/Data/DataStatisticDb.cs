using System;

/*
* 由自动生成工具完成
* 描述:[data_statistics]快速出场统计信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Data
{
    /// <summary>
    /// [data_statistics]快速出场统计信息
    /// </summary>
    [Serializable]
    public partial class DataStatisticDb
    {
        #region 快速出场统计信息编号
        private int _fID;

        /// <summary>
        /// 快速出场统计信息编号
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

        #region 开启次数
        private int _fOnCount;

        /// <summary>
        /// 开启次数
        /// </summary>
        public  int  OnCount
        {
            get
            {
                return  _fOnCount;
            }
            set
            {
                  _fOnCount = value;
            }
         }
        #endregion

        #region 关闭次数
        private int _fOffCount;

        /// <summary>
        /// 关闭次数
        /// </summary>
        public  int  OffCount
        {
            get
            {
                return  _fOffCount;
            }
            set
            {
                  _fOffCount = value;
            }
         }
        #endregion

     }
}

