using System.Web.Mvc;

namespace BSP.Controllers
{
    public class CategoryController : _BaseController
    {
        // GET: Category
        public ActionResult Menu()
        {
            var result = base.Facade.Category.GetAllCategories();
            return PartialView("_CategoryMenu", result);
        }
        public ActionResult BookList(int id)
        {
            var books = base.Facade.Book.GetBookByCategoryId(id);
            if (books ==null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(books);
        }
    }
}