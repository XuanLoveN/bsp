namespace BSP.IoC
{
    using Ninject.Modules;
    /// <summary>
    /// 缓存绑定模块
    /// </summary>
    public class CacheModule : NinjectModule
    {
        public override void Load()
        {
            //绑定内存缓存管理器
            Kernel.Bind<BSP.Caching.ICache>().To<BSP.Caching.Provider.MemoryCacheProvider>().Named(BSP.Caching.CacheTypes.MEMORY);

            //绑定Web请求缓存管理器
            Kernel.Bind<BSP.Caching.ICache>().To<BSP.Caching.Provider.PerRequestCacheProvider>().Named(BSP.Caching.CacheTypes.PERREQUEST);

            //绑定Web会话缓存管理器
            Kernel.Bind<BSP.Caching.ICache>().To<BSP.Caching.Provider.SessionCacheProvider>().Named(BSP.Caching.CacheTypes.SESSION);

            //绑定Web Cookie缓存管理器
            Kernel.Bind<BSP.Caching.ICache>().To<BSP.Caching.Provider.CookieCacheProvider>().Named(BSP.Caching.CacheTypes.COOKIE);
        }
    }
}
