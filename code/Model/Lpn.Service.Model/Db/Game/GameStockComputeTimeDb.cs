using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Game
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class GameStockComputeTimeDb
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

        #region 开始计算时间
        private DateTime _fComputeTime;

        /// <summary>
        /// 开始计算时间
        /// </summary>
        public  DateTime  ComputeTime
        {
            get
            {
                return  _fComputeTime;
            }
            set
            {
                  _fComputeTime = value;
            }
         }
        #endregion

        #region 更新时间
        private DateTime _fLastUpdateTime;

        /// <summary>
        /// 更新时间
        /// </summary>
        public  DateTime  LastUpdateTime
        {
            get
            {
                return  _fLastUpdateTime;
            }
            set
            {
                  _fLastUpdateTime = value;
            }
         }
        #endregion

        #region 计算完成时间
        private DateTime _fComputeEndTime;

        /// <summary>
        /// 计算完成时间
        /// </summary>
        public  DateTime  ComputeEndTime
        {
            get
            {
                return  _fComputeEndTime;
            }
            set
            {
                  _fComputeEndTime = value;
            }
         }
        #endregion

     }
}

