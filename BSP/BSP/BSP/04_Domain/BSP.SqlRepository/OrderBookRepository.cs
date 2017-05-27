using BSP.IRepository;
using BSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSP.SqlUtility;

namespace BSP.SqlRepository
{
    public class OrderBookRepository:_BaseRespotiroy,IOrderBookRepository
    {
        public IList<OrderBook> GetAllOrderBook()
        {
            return base.Database.GetSimpleList<OrderBook>();
        }
    }
}
