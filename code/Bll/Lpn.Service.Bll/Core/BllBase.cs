/*
 * 描述: Bll基础类
 * 包括 用户ID
 * 作者:lee
 * 创建时间:2015/10/21
 */

using OneCoin.Service.Dal.Core;

namespace OneCoin.Service.Bll.Core
{
    public class BllBase
    {
        protected delegate T LockActionEventHandler<out T>();  
 
        protected static T LockUserAndRun<T>(int userId, LockActionEventHandler<T> action)
        {
            try
            {
                 return action();
            }
            finally
            {
                TransactionManager.Commit();
            } 
        }
    }
}
