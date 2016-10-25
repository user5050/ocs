namespace OneCoin.Service.Helper.DBHelper
{
    public interface ITransaction
    {
        /// <summary>
        /// 回滚
        /// </summary>
        /// <returns></returns>
        bool Rollback();

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        bool Commit();
    }
}
