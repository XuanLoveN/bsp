using BSP.Model;
using System.Collections.Generic;

namespace BSP.IRepository
{
    /// <summary>
    /// 图书数据仓库接口
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// 获取推荐图书列表
        /// </summary>
        /// <returns></returns>
        IList<Book> GetTopOfBooks(int top);
        /// <summary>
        /// 获取图书分页数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        PagedList<Book> GetPageBooks(PagerParameter param);
        /// <summary>
        /// 根据编号获取图书对象
        /// </summary>
        /// <param name="id">图书编号</param>
        /// <returns></returns>
        Book GetBookById(int id);

        /// <summary>
        /// 更新图书信息
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        bool UpdateBookInfo(Book book);
        /// <summary>
        /// 根据图书标题查找图书信息
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        IList<Book> GetBooksByTitle(string title);
        /// <summary>
        /// 通过图书分类id 获取图书信息
        /// </summary>
        /// <returns></returns>
        IList<Book> GetBookByCategoryId(int categoryId);
    }
}
