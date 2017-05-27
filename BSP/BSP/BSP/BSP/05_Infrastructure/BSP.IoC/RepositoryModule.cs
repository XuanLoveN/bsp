using Ninject.Modules;


namespace BSP.IoC
{
    /// <summary>
    /// 数据仓库绑定模块
    /// </summary>
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            //绑定图书分类数据仓库实现
            Kernel.Bind<BSP.IRepository.ICategoryRepository>().To<BSP.SqlRepository.CategoryRepository>();

            //绑定用户数据仓库实现
            Kernel.Bind<BSP.IRepository.IUserRepository>().To<BSP.SqlRepository.UserRepository>();
            //绑定图书数据仓库实现
            Kernel.Bind<BSP.IRepository.IBookRepository>().To<BSP.SqlRepository.BookRepository>();
            //绑定出版社数据仓库实现
            Kernel.Bind<BSP.IRepository.IPublisherRepository>().To<BSP.SqlRepository.PublisherRepository>();
        }
    }
}
