namespace OneCoin.Service.Model.Const
{
    public class AppconfigDefine
    {
        /// <summary>
        /// 配置类定义
        /// </summary>
        public class ClassName
        {
            /// <summary>
            /// 开关值的类名，不允许修改,通知类
            /// </summary>
            public const string  Notification="Notification"; 
        }


        /// <summary>
        /// 配置KEY定义
        /// </summary>
        public class Key
        {
            /// <summary>
            /// 车辆入场
            /// </summary>
            public const string EntranceNotify = "EntranceNotify";

            /// <summary>
            /// 车辆出场
            /// </summary>
            public const string ExitNotify = "ExitNotify";
            
             /// <summary>
            /// 快速出场
            /// </summary>
            public const string AutoPayment = "AutoPayment";
            
            
        }
    }
}
