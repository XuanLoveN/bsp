namespace BSP.Caching.Provider
{
    using BSP.Core;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Caching;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 内存缓存提供程序
    /// </summary>
    public class MemoryCacheProvider : ICache
    {
        protected ObjectCache Cache { get { return MemoryCache.Default; } }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public void Set(string key, object value, int expriseTime = 0)
        {
            if (value == null) { return; }

            if (expriseTime == 0)
            {
                expriseTime = AppSettings.Get<int>(AppKeys.SettingKeys.Cache_MemoryCacheExprise);
            }

            var policy = new CacheItemPolicy();
            //设置过期时间
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(expriseTime);
            Cache.Add(new CacheItem(key, value), policy);
        }

        public bool Contains(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPartten(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (var item in Cache)
                if (regex.IsMatch(item.Key))
                    keysToRemove.Add(item.Key);

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        public void Clear()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }
    }
}
