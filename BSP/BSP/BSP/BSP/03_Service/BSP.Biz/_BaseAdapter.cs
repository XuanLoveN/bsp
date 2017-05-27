using BSP.Caching;
using BSP.IRepository;
using Ninject;
using Ninject.Extensions.Logging;

namespace BSP.Biz
{
    /// <summary>
    /// 基础数据适配器
    /// </summary>
    public class _BaseAdapter
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        [Inject]
        protected ILogger Logger { get; private set; }

        /// <summary>
        /// 缓存控制器
        /// </summary>
        [Inject]
        protected CacheFacade CacheManager { get; private set; }

        /// <summary>
        /// 图书分类数据仓库
        /// </summary>
        [Inject]
        protected ICategoryRepository CategoryRepository { get; private set; }

        /// <summary>
        /// 用户数据仓库
        /// </summary>
        [Inject]
        protected IUserRepository UserRepository { get; private set; }


        /// <summary>
        /// 图书数据仓库
        /// </summary>
        [Inject]
        protected IBookRepository BookRepository { get; private set; }

        /// <summary>
        /// 出版社数据仓库
        /// </summary>
        [Inject]
        protected IPublisherRepository PublisherRepository { get; private set; }
    }
}
