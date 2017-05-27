using BSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSP.Biz.Adapters
{
    public class OrderBookAdapter:_BaseAdapter
    {
        public IList<OrderBook> GetAllOrderBook()
        {
            return base.OrderBookRepository.GetAllOrderBook();
        }
    }
}
