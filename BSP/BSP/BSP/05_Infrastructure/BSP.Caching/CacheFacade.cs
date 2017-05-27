namespace BSP.Caching
{
    using Ninject;
    /// <summary>
    /// 缓存控制器外观
    /// </summary>
    public sealed class CacheFacade
    {
        [Inject, Named(CacheTypes.MEMORY)]
        public ICache Memory { get; private set; }

        [Inject, Named(CacheTypes.PERREQUEST)]
        public ICache PerRequest { get; private set; }

        [Inject, Named(CacheTypes.SESSION)]
        public ICache Session { get; private set; }

        [Inject, Named(CacheTypes.COOKIE)]
        public ICache Cookie { get; private set; }
    }
}
