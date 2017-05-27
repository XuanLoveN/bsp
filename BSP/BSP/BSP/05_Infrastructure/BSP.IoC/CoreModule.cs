using BSP.IoC;
using Ninject;
using Ninject.Modules;
using System.Web;

namespace BSP.IoC
{
    /// <summary>
    /// 注入核心模块
    /// </summary>
    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            //注入私有属性
            Kernel.Settings.InjectNonPublic = true;

            //绑定Http上下文
            Kernel.Bind<HttpContextBase>().ToMethod(ctx => new HttpContextWrapper(HttpContext.Current) as HttpContextBase);

            //加载缓存模块
            Kernel.Load(new CacheModule());

            //加载数据仓库模块
            Kernel.Load(new RepositoryModule());
        }
    }
}
