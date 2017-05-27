using BSP.Model;
using System.Collections.Generic;

namespace BSP.Biz.Adapters
{
    /// <summary>
    /// 图书管理适配器
    /// </summary>
    public class BookAdapter : _BaseAdapter
    {
        /// <summary>
        /// 获取推荐的前N个图书信息
        /// </summary>
        /// <returns></returns>
        public IList<Book> GetTopOfBooks(int top)
        {
            return base.BookRepository.GetTopOfBooks(top);
        }
        /// <summary>
        /// 获取分页图书列表
        /// </summary>
        /// <param name="param">分页参数类型</param>
        /// <returns></returns>
        public PagedList<Book> GetPageBooks(PagerParameter param)
        {
            return base.BookRepository.GetPageBooks(param);
        }
        /// <summary>
        /// 根据图书编号获取图书对象
        /// </summary>
        /// <param name="id">图书编号</param>
        /// <returns></returns>
        public Book GetBookById(int id)
        {
            return base.BookRepository.GetBookById(id);
        }

        /// <summary>
        /// 更新图书信息
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool UpdateBookInfo(Book book)
        {
            return base.BookRepository.UpdateBookInfo(book);
        }
        /// <summary>
        /// 根据图书标题获取图书信息
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public IList<Book> GetBooksByTitle(string title)
        {
            return base.BookRepository.GetBooksByTitle(title);
        }
        /// <summary>
        /// 取得所有图书信息
        /// </summary>
        /// <returns></returns>
        public IList<Book> GetBookByCategoryId(int categoryId)
        {
            return base.BookRepository.GetBookByCategoryId(categoryId);
        }
    }
}
