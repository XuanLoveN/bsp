namespace BSP.Mvc
{
    using BSP.Model;
    using System.Web;

    /// <summary>
    /// 用户票证管理器
    /// </summary>
    public class UserTicketManager
    {
        /// <summary>
        /// 当前用户登录票证对象
        /// </summary>
        public static UserTicket CurrentUserTicket
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    UserTicket ticket = UserTicket.ParseFromString(HttpContext.Current.User.Identity.Name);
                    return ticket;

                }
                return null;
            }
        }
    }
}
