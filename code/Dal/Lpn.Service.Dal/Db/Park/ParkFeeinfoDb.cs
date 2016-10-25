using System;

/*
* 由自动生成工具完成
* 描述:[park_feeinfo]e泊停车场费率信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_feeinfo]e泊停车场费率信息
    /// </summary>
    [Serializable]
    public partial class ParkFeeinfoDb
    {
        #region 标志
        private int _fId;

        /// <summary>
        /// 标志
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

        #region 停车场编码
        private string _fParkcode;

        /// <summary>
        /// 停车场编码
        /// </summary>
        public  string  Parkcode
        {
            get
            {
                return  _fParkcode;
            }
            set
            {
                  _fParkcode = value;
            }
         }
        #endregion

        #region 车库类型
        private string _fParktype;

        /// <summary>
        /// 车库类型
        /// </summary>
        public  string  Parktype
        {
            get
            {
                return  _fParktype;
            }
            set
            {
                  _fParktype = value;
            }
         }
        #endregion

        #region 免费出场时间
        private string _fParkfeetime;

        /// <summary>
        /// 免费出场时间
        /// </summary>
        public  string  Parkfeetime
        {
            get
            {
                return  _fParkfeetime;
            }
            set
            {
                  _fParkfeetime = value;
            }
         }
        #endregion

        #region 费率
        private string _fParkfee;

        /// <summary>
        /// 费率
        /// </summary>
        public  string  Parkfee
        {
            get
            {
                return  _fParkfee;
            }
            set
            {
                  _fParkfee = value;
            }
         }
        #endregion

     }
}

