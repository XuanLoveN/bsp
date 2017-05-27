using BSP.IRepository;
using BSP.Model;
using BSP.SqlUtility;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BSP.SqlRepository
{
    public class OrderRepository : _BaseRespotiroy, IOrderRepository
    {
        public Model.IMessage SaveOrder(Model.Order order, IList<Model.OrderBook> orderBooks)
        {
            IList<SqlParameter> param = order.ToInPrarmterList(Order._Id);

            DataTable table = new DataTable();
            table.Columns.Add("OrderID", typeof(int));
            table.Columns.Add("BookID", typeof(int));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("UnitPrice", typeof(decimal));

            foreach (var item in orderBooks)
            {
                DataRow row = table.NewRow();
                row["OrderID"] = 0;
                row["BookID"] = item.BookID;
                row["Quantity"] = item.Quantity;
                row["UnitPrice"] = item.UnitPrice;
                table.Rows.Add(row);
            }

            SqlParameter listParameter = new SqlParameter("@OrderBooks", table);
            listParameter.TypeName = "OrderBookTvp";

            param.Add(listParameter);

            return base.Database.GetMessage("SP_SaveOrder", param.ToArray());
        }
        public IList<Order> GetAllOrder()
        { 
            return base.Database.GetSimpleList<Order>();
        }
    }
}
