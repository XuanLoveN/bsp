using BSP.Model;
using BSP.Mvc;
using System.Web.Mvc;
using System.Web.Routing;

namespace BSP.Filters
{
    /// <summary>
    /// 管理员权限验证特性
    /// </summary>
    public class AdminAuthorizationAttribute : AuthorizeAttribute
    {
        private const int ADMINID = 3;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"].ToString();
            var actionName = filterContext.RouteData.Values["action"].ToString();
            RouteValueDictionary dict = new RouteValueDictionary();
            dict.Add("controller", controllerName);
            dict.Add("action", actionName);
            dict.Add("area", "");

            UserTicket ticket = UserTicketManager.CurrentUserTicket;
            if (ticket == null || ticket.RoleID != ADMINID)
            {
                filterContext.Result = new RedirectToRouteResult(dict);
                return;
            }
        }
    }
}