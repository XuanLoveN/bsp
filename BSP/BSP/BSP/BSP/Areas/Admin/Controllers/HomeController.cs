using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BSP.Filters;
using BSP.Controllers;
using BSP.Common;
using System.Web.Security;
using BSP.Mvc;
using BSP.Model;

namespace BSP.Areas.Admin.Controllers
{
    [Authorize, AdminAuthorization]
    public class HomeController : _BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View(); 
        }
    }
}