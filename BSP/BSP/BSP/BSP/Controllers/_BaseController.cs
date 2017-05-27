using BSP.Biz;
using BSP.Caching;
using BSP.Common;
using Ninject;
using System.Web.Mvc;

namespace BSP.Controllers
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    public class _BaseController : Controller
    {
        /// <summary>
        /// 业务逻辑外观
        /// </summary>
        [Inject]
        protected AdapterFacade Facade { get; private set; }

        /// <summary>
        /// 缓存控制器
        /// </summary>
        [Inject]
        public CacheFacade CacheManager { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="message"></param>
        protected string ErrorMessage
        {
            set
            {
                TempData[Constants.ERRORMESSAGEKEY] = value;
            }
        }
    }
}