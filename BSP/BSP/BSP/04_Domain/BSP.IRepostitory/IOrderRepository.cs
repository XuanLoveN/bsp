using BSP.Model;
using System.Collections.Generic;

namespace BSP.IRepository
{
    /// <summary>
    /// 订单数据仓库接口
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// 保存订单
        /// </summary>
        /// <param name="order">订单对象</param>
        /// <param name="orderBooks">订单图书列表</param>
        /// <returns></returns>
        IMessage SaveOrder(Order order, IList<OrderBook> orderBooks);
        IList<Order> GetAllOrder();
    }
}
