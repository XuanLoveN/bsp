using BSP.Common;
using System.Web.Mvc;
using System.Web.Security;

namespace BSP.Controllers
{
    public class HomeController : _BaseController
    {
        public ActionResult Index()
        {
            if (base.CacheManager.Cookie.Contains(Constants.SIGNINREMEMBERKEY))
            {
                var ticketString = base.CacheManager.Cookie.Get<string>(Constants.SIGNINREMEMBERKEY);

                //设置票证
                FormsAuthentication.SetAuthCookie(ticketString, false);
            }
            var model = base.Facade.Book.GetTopOfBooks(8);
            return View(model);
        }
    }
}