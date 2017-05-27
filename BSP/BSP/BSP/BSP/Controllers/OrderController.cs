using BSP.Common;
using BSP.Model;
using BSP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSP.Controllers
{
    [Authorize]
    public class OrderController : _BaseController
    {
        public ActionResult Index()
        {
            ShoppingCart shoppingCart = base.CacheManager.Session.Get<ShoppingCart>(Constants.SHOPPINGCARTKEY);

            if (shoppingCart == null || shoppingCart.Items.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(shoppingCart);
        }

        public ActionResult Confirm()
        {
            ShoppingCart shoppingCart = base.CacheManager.Session.Get<ShoppingCart>(Constants.SHOPPINGCARTKEY);

            IMessage message = base.Facade.Order.SaveOrder(shoppingCart);

            TempData[Constants.COMMANDRESULTKEY] = message.Success ? "订单保存成功" : message.Content;

            return RedirectToAction("Index");
        }
    }
}