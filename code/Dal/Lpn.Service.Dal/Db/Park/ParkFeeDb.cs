using System;

/*
* 由自动生成工具完成
* 描述:[park_fee]停车场费率
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_fee]停车场费率
    /// </summary>
    [Serializable]
    public partial class ParkFeeDb
    {
        #region 停车场费率编号
        private int _fID;

        /// <summary>
        /// 停车场费率编号
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

        #region 停车场编码
        private string _fParkCode;

        /// <summary>
        /// 停车场编码
        /// </summary>
        public  string  ParkCode
        {
            get
            {
                return  _fParkCode;
            }
            set
            {
                  _fParkCode = value;
            }
         }
        #endregion

        #region 免费时间
        private int _fFreeTime;

        /// <summary>
        /// 免费时间
        /// </summary>
        public  int  FreeTime
        {
            get
            {
                return  _fFreeTime;
            }
            set
            {
                  _fFreeTime = value;
            }
         }
        #endregion

        #region 每小时的价格
        private int _fUnitPrice;

        /// <summary>
        /// 每小时的价格
        /// </summary>
        public  int  UnitPrice
        {
            get
            {
                return  _fUnitPrice;
            }
            set
            {
                  _fUnitPrice = value;
            }
         }
        #endregion

        #region 描述
        private string _fDetail;

        /// <summary>
        /// 描述
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

        #region 结算周期
        private int _fIsChecked;

        /// <summary>
        /// 结算周期
        /// </summary>
        public  int  IsChecked
        {
            get
            {
                return  _fIsChecked;
            }
            set
            {
                  _fIsChecked = value;
            }
         }
        #endregion

        #region 第一阶段价格
        private int _fFirstPrice;

        /// <summary>
        /// 第一阶段价格
        /// </summary>
        public  int  FirstPrice
        {
            get
            {
                return  _fFirstPrice;
            }
            set
            {
                  _fFirstPrice = value;
            }
         }
        #endregion

        #region 第一阶段时间
        private int _fFirstTime;

        /// <summary>
        /// 第一阶段时间
        /// </summary>
        public  int  FirstTime
        {
            get
            {
                return  _fFirstTime;
            }
            set
            {
                  _fFirstTime = value;
            }
         }
        #endregion

        #region 免费离场时间(分钟)
        private int _fFreeExitTime;

        /// <summary>
        /// 免费离场时间(分钟)
        /// </summary>
        public  int  FreeExitTime
        {
            get
            {
                return  _fFreeExitTime;
            }
            set
            {
                  _fFreeExitTime = value;
            }
         }
        #endregion

     }
}

