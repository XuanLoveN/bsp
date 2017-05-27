using BSP.Common;
using BSP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSP.Controllers
{
    public class ShoppingCartController : _BaseController
    {
        // GET: ShoppingCart
        /// <summary>
        /// 购物车对象
        /// </summary>
        /// <returns></returns>
        public ShoppingCart ShoppingCart
        {
           get
            {
                ShoppingCart shoppingCart = base.CacheManager.Session.Get<ShoppingCart>(Constants.SHOPPINGCARTKEY);
                if (shoppingCart == null)
                {
                    shoppingCart = new ShoppingCart();
                    base.CacheManager.Session.Set(Constants.SHOPPINGCARTKEY, shoppingCart);
                }
                return shoppingCart;
            }
        }
        public ActionResult PartialIndex()
        {
            return PartialView("_Index",ShoppingCart.Items.Count);
        }
        public ActionResult Add(int? id,int count = 1)
        {
            if (id.HasValue)
            {
                var book = base.Facade.Book.GetBookById(id.Value);

                if (book!=null)
                {
                    ShoppingCartItem item = new ShoppingCartItem
                    {
                        Book = book,
                        Count = count
                    };
                    var shoppingCart = ShoppingCart;
                    if (shoppingCart.Items.ContainsKey(id.Value))
                    {
                        var shoppingCartItem = shoppingCart.Items[id.Value];
                        shoppingCartItem.Count += count;
                    }
                    else
                    {
                        shoppingCart.Items.Add(item.Book.Id,item);
                    }
                    base.CacheManager.Session.Set(Constants.SHOPPINGCARTKEY,shoppingCart);
                }
            }
            return PartialView("_Index", ShoppingCart.Items.Count);
        }
        public ActionResult Index()
        {
            return View(ShoppingCart);
        }
    }
}