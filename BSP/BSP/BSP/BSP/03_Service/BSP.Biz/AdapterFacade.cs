using BSP.Biz.Adapters;
using Ninject;

namespace BSP.Biz
{
    /// <summary>
    /// 数据适配器外观
    /// </summary>
    public class AdapterFacade
    {
        /// <summary>
        /// 图书分类
        /// </summary>
        [Inject]
        public CategoryAdapter Category { get; private set; }

        /// <summary>
        /// 用户管理
        /// </summary>
        [Inject]
        public UserAdapter User{ get; private set; }

        /// <summary>
        /// 图书管理
        /// </summary>
        [Inject]
        public BookAdapter Book { get; set; }
        /// <summary>
        /// 出版社管理
        /// </summary>
        [Inject]
        public PublisherAdapter Publisher { get; set; }

    }
}
