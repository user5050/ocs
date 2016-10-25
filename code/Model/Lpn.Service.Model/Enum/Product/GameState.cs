namespace OneCoin.Service.Model.Enum.Product
{
    public enum GameState
    {
        //0无效1进行中2揭晓中3公示中4已发货5待评价6结束
        /// <summary>
        /// 无效
        /// </summary>
        InValid=0,

        /// <summary>
        /// 进行中
        /// </summary>
        Going=1,

        /// <summary>
        /// 揭晓中
        /// </summary>
        WaitForCompute=2,

        /// <summary>
        /// 公示中
        /// </summary>
        Publicity=3,

        /// <summary>
        /// 已发货
        /// </summary>
        Send=4,

        /// <summary>
        /// 待评价
        /// </summary>
        Assess=5,

        /// <summary>
        /// 结束
        /// </summary>
        End=6
    }
}
