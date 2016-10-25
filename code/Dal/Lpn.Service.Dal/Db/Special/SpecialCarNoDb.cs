using System;

/*
* 由自动生成工具完成
* 描述:[special_car_no]预置车牌
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Special
{
    /// <summary>
    /// [special_car_no]预置车牌
    /// </summary>
    [Serializable]
    public partial class SpecialCarNoDb
    {
        #region 预置车牌编号
        private int _fID;

        /// <summary>
        /// 预置车牌编号
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

        #region 添加时间
        private DateTime _fTime;

        /// <summary>
        /// 添加时间
        /// </summary>
        public  DateTime  Time
        {
            get
            {
                return  _fTime;
            }
            set
            {
                  _fTime = value;
            }
         }
        #endregion

     }
}

