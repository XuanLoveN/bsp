using BSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSP.ViewModel
{
    /// <summary>
    /// 图书列表条件视图模型
    /// </summary>
    public class BookListConditionalViewModel : PagerParameter
    {
        /// <summary>
        /// 分类编号
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// 出版社编号
        /// </summary>
        public int PublisherID { get; set; }
        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Keyword { get; set; }
    }
}
