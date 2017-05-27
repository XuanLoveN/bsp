using BSP.Controllers;
using BSP.Model;
using BSP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSP.Areas.Admin.Controllers
{
    public class BookController : _BaseController
    {
        // GET: Admin/Book
        public ActionResult List(int? categoryId,int pageIndex =1)
        {
            var categories = base.Facade.Category.GetAllCategories();
            //将取到的数据存入viewData 中 Categories 是键 显示name 取得id
            ViewData["Categories"] = new SelectList(categories,Category._Id,Category._Name);

            PagerParameter param = new PagerParameter(Book.Tablename, Book._Id, categoryId.HasValue ? "CategoryId=" + categoryId.Value : "1=1", pageIndex);
            var model = base.Facade.Book.GetPageBooks(param);
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BookViewModel model = new BookViewModel();
            model.Book = base.Facade.Book.GetBookById(id);
            model.Categories = new SelectList(base.Facade.Category.GetAllCategories(), "Id", "Name", model.Book.CategoryId);
            model.Publishers = new SelectList(base.Facade.Publisher.GetAllPublishers(), "Id", "Name", model.Book.PublisherId);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Edit(Book book, HttpPostedFileBase isbn_img)
        {
            if (ModelState.IsValid)
            {
                //如果用户上传了图片文件
                if (isbn_img != null)
                {
                    string filePath = Server.MapPath(string.Format("~/Images/BookCovers/{0}.jpg", book.ISBN));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    //保存图片到服务器
                    isbn_img.SaveAs(filePath);
                }

                bool result = base.Facade.Book.UpdateBookInfo(book);
                TempData["CommandResult"] = result;
            }
            return RedirectToAction("Edit", new { id = book.Id });
        }
    }
}