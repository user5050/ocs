using OneCoin.Service.Model.Db.Orders;

namespace OneCoin.Service.Bll.Logic.Orders.Task.OrderProccess
{
    public interface IOrderProccess
    {
        bool Do(string orderNo);
    }
}
