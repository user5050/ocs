using System;

/*
* 由自动生成工具完成
* 描述:[park_register]停车场注册信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_register]停车场注册信息
    /// </summary>
    [Serializable]
    public partial class ParkRegisterDb
    {
        #region 停车场注册信息编号
        private int _fID;

        /// <summary>
        /// 停车场注册信息编号
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

        #region 停车场MAC地址
        private string _fMac;

        /// <summary>
        /// 停车场MAC地址
        /// </summary>
        public  string  Mac
        {
            get
            {
                return  _fMac;
            }
            set
            {
                  _fMac = value;
            }
         }
        #endregion

     }
}

