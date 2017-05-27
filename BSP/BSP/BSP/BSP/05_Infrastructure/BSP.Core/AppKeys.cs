namespace BSP.Core
{
    public class AppKeys
    {
        /// <summary>
        /// 正则表达式键集
        /// </summary>
        public struct RegexPatternKeys
        {
            /// <summary>
            /// IP V4 地址正则表达式键
            /// </summary>
            public const string IPV4AddressPartten = "IPV4AddressPartten";
        }

        /// <summary>
        /// 设置键集
        /// </summary>
        public struct SettingKeys
        {
            /// <summary>
            /// Cookie缓存超时时间
            /// </summary>
            public const string Cache_CookieCacheExprise = "BSP.Cache.CookieCacheExprise";
            /// <summary>
            /// 内存缓存超时事件
            /// </summary>
            public const string Cache_MemoryCacheExprise = "BSP.Cache.MemoryCacheExprise";
        }
    }
}
