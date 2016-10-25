using System;

/*
* 由自动生成工具完成
* 描述:[montyly_car_infoadd_byapp]APP添加的月租车牌
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Montyly
{
    /// <summary>
    /// [montyly_car_infoadd_byapp]APP添加的月租车牌
    /// </summary>
    [Serializable]
    public partial class MontylyCarInfoaddByappDb
    {
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

        #region 车牌号
        private string _fCarNo;

        /// <summary>
        /// 车牌号
        /// </summary>
        public  string  CarNo
        {
            get
            {
                return  _fCarNo;
            }
            set
            {
                  _fCarNo = value;
            }
         }
        #endregion

        #region 本地停车场的人员编号
        private int _fInternalUserID;

        /// <summary>
        /// 本地停车场的人员编号
        /// </summary>
        public  int  InternalUserID
        {
            get
            {
                return  _fInternalUserID;
            }
            set
            {
                  _fInternalUserID = value;
            }
         }
        #endregion

        #region 标识符
        private string _fIndexInfo;

        /// <summary>
        /// 标识符
        /// </summary>
        public  string  IndexInfo
        {
            get
            {
                return  _fIndexInfo;
            }
            set
            {
                  _fIndexInfo = value;
            }
         }
        #endregion

     }
}

