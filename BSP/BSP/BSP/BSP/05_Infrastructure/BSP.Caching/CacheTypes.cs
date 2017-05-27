namespace BSP.Caching
{
    /// <summary>
    /// 缓存类型
    /// </summary>
    public struct CacheTypes
    {
        /// <summary>
        /// 在内存中缓存
        /// </summary>
        public const string MEMORY = "Memory";

        /// <summary>
        /// 在Web请求中缓存
        /// </summary>
        public const string PERREQUEST = "PerRequest";

        /// <summary>
        /// 在Web会话中缓存
        /// </summary>
        public const string SESSION = "Session";

        /// <summary>
        /// Cookie中缓存
        /// </summary>
        public const string COOKIE = "Cookie";
    }
}
