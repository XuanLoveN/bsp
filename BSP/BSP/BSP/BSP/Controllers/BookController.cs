using BSP.Common;
using BSP.Model;
using BSP.ViewModel;
using System.Web.Mvc;
using System.Linq;
namespace BSP.Controllers
{
    public class BookController : _BaseController
    {
        public ActionResult Index()
        {
            var model = base.Facade.Book.GetTopOfBooks(10);
            return View(model);
        }

        public ActionResult Seach(string title)
        {
            var model = base.Facade.Book.GetBooksByTitle("Title like'%" + title + "%'");
            if (model == null)
            {
                RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        public ActionResult List(BookListViewModel book, int pageIndex = 1)
        {
            if (book.Conditional == null)
            {
                pageIndex = 1;
            }
            else
            {
                pageIndex = book.Conditional.PageIndex;
            }
            var model = new BookListViewModel
            {
                Books = base.Facade.Book.GetPageBooks(new PagerParameter(Book.Tablename, Book._Id, pageIndex, 20, Conditionals.ALWAYSTRUE)),
                Categories = new SelectList(base.Facade.Category.GetAllCategories(), "Id", "Name"),
                Publishers = new SelectList(base.Facade.Publisher.GetAllPublishers(), "Id", "Name")
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult SearchBooks(BookListViewModel book)
        {
            if (book.Conditional != null)
            {
                var books = base.Facade.Book.GetBookByCategoryId(book.Conditional.CategoryID);
                var model = books.FirstOrDefault(r => r.PublisherId == book.Conditional.PublisherID);
                if (book.Conditional.PublisherID != 0)
                {
                    if (model != null)
                    {
                        var result = base.Facade.Book.GetBooksByTitle("Title like'%" + book.Conditional.Keyword + "%'");
                        if (result != null)
                        {
                            return View(result);
                        }
                        else
                        {
                            //返回错误信息
                        }
                    }
                    else
                    {
                        return View(model);
                    }
                }
                return View(books);
            }
            return View(book.Books);
        }


        public ActionResult Detail(int? id)
        {
            if (id.HasValue)
            {
                var model = base.Facade.Book.GetBookById(id.Value);
                return View(model);
            }
            return RedirectToAction("List");
        }
    }
}