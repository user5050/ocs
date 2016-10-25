namespace OneCoin.Service.Model.Entity.AntiThief
{
    public class VerifyingInfo
    {
        #region 属性

        public string Type
        { get { return "verifyinginfo"; } }


        public int UserID
        { set; get; }

        /// <summary>
        /// 布控的账户名
        /// </summary>
        public string UserName
        { set; get; }

        /// <summary>
        /// 布控的车牌
        /// </summary>
        public string CarNo
        { set; get; }

        /// <summary>
        /// 布控的动态码
        /// </summary>
        public string VerifyingCode
        { set; get; }

        /// <summary>
        /// 停车场编码
        /// </summary>
        public string ParkCode
        { set; get; }

        /// <summary>
        /// 停车场名称
        /// </summary>
        public string ParkName
        { set; get; }

        /// <summary>
        /// 入场时间
        /// </summary>
        public string EntranceTime
        { set; get; }

        /// <summary>
        /// 布防状态
        /// 0=已撤防,1=已布防
        /// </summary>
        public int AntiThiefStatus
        { set; get; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperationTime
        { set; get; }

        #endregion

        public VerifyingInfo()
        {
            this.UserID = 0;
            this.UserName = "";
            this.CarNo = "";
            this.VerifyingCode = "";
            this.ParkCode = "";
            this.ParkName = "";
            this.EntranceTime = "";
            this.AntiThiefStatus = 0;
            this.OperationTime = "";
        }  

        public VerifyingInfo(int userID, string userName, string carNo, string verifyingCode, string parkCode, string parkName, string entranceTime, int antiThiefStatus, string operationTime)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.CarNo = carNo.ToUpper();
            this.VerifyingCode = verifyingCode;
            this.ParkCode = parkCode;
            this.ParkName = parkName;
            this.EntranceTime = entranceTime;
            this.AntiThiefStatus = antiThiefStatus;
            this.OperationTime = operationTime;
        }

        public override string ToString()
        {
            return string.Format("Type:{0};UserID{1};UserName:{2};CarNo:{3};VerifyingCode:{4};ParkCode:{5};ParkName:{6};EntranceTime:{7};AntiThiefStatus:{8};OperationTime:{9}",
                Type, UserID.ToString(), UserName, CarNo, VerifyingCode, ParkCode, ParkName, EntranceTime, ((int)AntiThiefStatus).ToString(), OperationTime);
        }
    }
}
