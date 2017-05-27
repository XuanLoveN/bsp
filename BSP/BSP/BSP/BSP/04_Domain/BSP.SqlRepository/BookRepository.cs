using BSP.IRepository;
using BSP.Model;
using BSP.SqlUtility;
using System.Collections.Generic;

namespace BSP.SqlRepository
{
    public class BookRepository : _BaseRespotiroy, IBookRepository
    {
        public IList<Book> GetTopOfBooks(int top)
        {
            return base.Database.GetSimpleList<Book>(top);
        }
        public PagedList<Book> GetPageBooks(PagerParameter param)
        {
            return base.Database.GetPagerList<Book>(param);
        }
        public Book GetBookById(int id)
        {
            return base.Database.GetSimpleObject<Book>(id.ToInParameter(Book._Id));
        }

        public bool UpdateBookInfo(Book book)
        {
            return base.Database.Modify(book, Book._Id, Book._Id, Book._Clicks);
        }
        public IList<Book> GetBooksByTitle(string title)
        {
            return base.Database.GetSimpleList<Book>(title);
        }
        public IList<Book> GetBookByCategoryId(int categoryId)
        {
            return base.Database.GetSimpleList<Book>("categoryId="+categoryId);
        }
    }
}
