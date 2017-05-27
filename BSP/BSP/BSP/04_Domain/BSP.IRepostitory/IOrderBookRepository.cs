using BSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSP.IRepository
{
    /// <summary>
    /// 图书订单详情
    /// </summary>
    public interface IOrderBookRepository
    {
        /// <summary>
        /// 获得全部图书详情
        /// </summary>
        /// <returns></returns>
        IList<OrderBook> GetAllOrderBook();
    }
}
