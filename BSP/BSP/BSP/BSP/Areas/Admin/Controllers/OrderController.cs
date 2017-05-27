using BSP.Controllers;
using BSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSP.Areas.Admin.Controllers
{
    [Authorize]
    public class OrderController : _BaseController
    {
        // GET: Admin/Order
        public ActionResult Index()
        {
            var model = base.Facade.Order.GetALlOrder(); 
            return View(model);
        }
        public ActionResult OrderBookList(int id)
        { 
            var model = base.Facade.OrderBook.GetAllOrderBook();
            var orderBookList = new List<OrderBook>();
            foreach (var item in model)
            {
                orderBookList = model.Where(m => m.OrderID == id).ToList();
            }
            return View(orderBookList);
        }
    }
}