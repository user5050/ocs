using System;

/*
* 由自动生成工具完成
* 描述:排除的日期
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Game
{
    /// <summary>
    /// 排除的日期
    /// </summary>
    [Serializable]
    public partial class GameStockComputeEldtimeDb
    {
        #region Date
        private DateTime _fDate;

        /// <summary>
        /// Date
        /// </summary>
        public  DateTime  Date
        {
            get
            {
                return  _fDate;
            }
            set
            {
                  _fDate = value;
            }
         }
        #endregion

     }
}

