using System;

/*
* 由自动生成工具完成
* 描述:[car_pattern]车辆类型字典表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Car
{
    /// <summary>
    /// [car_pattern]车辆类型字典表
    /// </summary>
    [Serializable]
    public partial class CarPatternDb
    {
        #region 车辆类型字典编号
        private int _fID;

        /// <summary>
        /// 车辆类型字典编号
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

        #region 车辆品牌
        private string _fType;

        /// <summary>
        /// 车辆品牌
        /// </summary>
        public  string  Type
        {
            get
            {
                return  _fType;
            }
            set
            {
                  _fType = value;
            }
         }
        #endregion

        #region 车辆型号
        private string _fName;

        /// <summary>
        /// 车辆型号
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

