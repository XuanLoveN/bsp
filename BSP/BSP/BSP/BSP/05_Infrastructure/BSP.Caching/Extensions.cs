namespace BSP.Caching
{
    using System;
    /// <summary>
    /// 缓存扩展类
    /// </summary>
    public static class Extensions
    {
        private static readonly object _syncObject = new object();

        /// <summary>
        /// 获取缓存对象，如果不存在，则通过函数进行获取
        /// </summary>
        /// <typeparam name="T">获取对象类型</typeparam>
        /// <param name="provider">缓存提供程序源</param>
        /// <param name="key">缓存键</param>
        /// <param name="acquire">对象获取函数</param>
        /// <returns></returns>
        public static T Get<T>(this ICache provider, string key, Func<T> acquire)
        {
            return Get<T>(provider, key, 0, acquire);
        }

        /// <summary>
        /// 获取缓存对象，如果不存在，则通过函数进行获取
        /// </summary>
        /// <typeparam name="T">获取对象类型</typeparam>
        /// <param name="provider">缓存提供程序源</param>
        /// <param name="key">缓存键</param>
        /// <param name="exprise">缓存过期时间</param>
        /// <param name="acquire">对象获取函数</param>
        /// <returns></returns>
        public static T Get<T>(this ICache provider, string key, int exprise, Func<T> acquire)
        {
            lock (_syncObject)
            {
                if (provider.Contains(key))
                {
                    return provider.Get<T>(key);
                }

                var result = acquire();
                provider.Set(key, result, exprise);

                return result;
            }
        }
    }
}
