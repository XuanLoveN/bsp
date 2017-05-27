using BSP.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BSP.Areas.Admin.Controllers
{
    public class CategoryController : _BaseController
    {
        // GET: Admin/Category
        public ActionResult List()
        {
            var model = base.Facade.Category.GetAllCategories();
            return View(model);
        }
        public ActionResult Create(string categoryName)
        {
#if DEBUG
            Thread.Sleep(50);
#endif
            var result = base.Facade.Category.CreateNewCategory(categoryName);
            return Json(new { Result = result });
        }

        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (string.IsNullOrEmpty(ids) || ids.Length == 0)
            {
                return Content("0");
            }
            //1,2,3,4,5......
            //delete from 表 where id in (@id)
            base.Facade.Category.DeleteAll(ids);
            //添加消息
            return Content("1");
        }
    }
}