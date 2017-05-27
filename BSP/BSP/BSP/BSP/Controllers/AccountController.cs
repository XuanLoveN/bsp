using BSP.Common;
using BSP.Model;
using BSP.ViewModel;
using System.Web.Mvc;
using System.Web.Security;

namespace BSP.Controllers
{
    public class AccountController : _BaseController
    {
        [HttpGet]
        public ActionResult Signin()
        {
            if (base.CacheManager.Cookie.Contains(Constants.SIGNINREMEMBERKEY))
            {
                var ticketString = base.CacheManager.Cookie.Get<string>(Constants.SIGNINREMEMBERKEY);

                //设置票证
                FormsAuthentication.SetAuthCookie(ticketString, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Signin(SigninViewModel model)
        {
            string captcha = base.CacheManager.Session.Get<string>("Captcha");

            if (!string.Equals(model.ValidateCode, captcha, System.StringComparison.CurrentCultureIgnoreCase))
            {
                ModelState.AddModelError("ValidateCode", "验证码输入错误");
                return View();
            }

            IMessage<UserTicket> message = base.Facade.User.Signin(model.UserName, model.Password);

            if (message.Success)
            {
                if (model.Remember)
                {
                    base.CacheManager.Cookie.Set(Constants.SIGNINREMEMBERKEY, message.Entity.ParseToString());
                }
                //设置票证
                FormsAuthentication.SetAuthCookie(message.Entity.ParseToString(), false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                base.ErrorMessage = message.Content;
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            base.CacheManager.Cookie.Remove(Constants.SIGNINREMEMBERKEY);
            return Redirect(FormsAuthentication.DefaultUrl);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //操作数据库，添加用户
            }

            return View(model);
        }
    }
}