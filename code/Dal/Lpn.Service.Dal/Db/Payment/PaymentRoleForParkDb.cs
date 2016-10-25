using System;

/*
* 由自动生成工具完成
* 描述:[payment_role_for_park]停车场支付权限
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Payment
{
    /// <summary>
    /// [payment_role_for_park]停车场支付权限
    /// </summary>
    [Serializable]
    public partial class PaymentRoleForParkDb
    {
        #region 停车场编号
        private int _fParkID;

        /// <summary>
        /// 停车场编号
        /// </summary>
        public  int  ParkID
        {
            get
            {
                return  _fParkID;
            }
            set
            {
                  _fParkID = value;
            }
         }
        #endregion

        #region 停车场支付权限
        private int _fRoleID;

        /// <summary>
        /// 停车场支付权限
        /// </summary>
        public  int  RoleID
        {
            get
            {
                return  _fRoleID;
            }
            set
            {
                  _fRoleID = value;
            }
         }
        #endregion

     }
}

