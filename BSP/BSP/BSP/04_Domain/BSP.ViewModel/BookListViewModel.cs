namespace BSP.ViewModel
{
    using BSP.Model;
    using BSP.Model.PagedModel;
    using System.Collections.Generic;
    using System.Web.Mvc;
    /// <summary>
    /// 图书列表视图模型
    /// </summary>
    public class BookListViewModel
    {
        /// <summary>
        /// 图书列表
        /// </summary>
        public IPagedList<Book> Books { get; set; }

        /// <summary>
        /// 图书分类集合
        /// </summary>
        public SelectList Categories { get; set; }

        /// <summary>
        /// 出版社集合
        /// </summary>
        public SelectList Publishers { get; set; }

        /// <summary>
        /// 搜索条件
        /// </summary>
        public BookListConditionalViewModel Conditional { get; set; }
    }
}
