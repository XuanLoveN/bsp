namespace BSP.Caching
{
    /// <summary>
    /// 缓存管理基础接口
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// 根据指定键获取对应值
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="key">键名称</param>
        /// <returns>对应值</returns>
        T Get<T>(string key);

        /// <summary>
        /// 设置对象到缓存中
        /// </summary>
        /// <param name="key">键名称</param>
        /// <param name="value">需要缓存的对象</param>
        /// <param name="expriseTime">
        /// 过期时间(单位：分钟)
        /// <remarks>如果不赋值，则使用默认超时时间</remarks>
        /// </param>
        void Set(string key, object value, int expriseTime = 0);

        /// <summary>
        /// 判断指定键名称是否已经缓存
        /// </summary>
        /// <param name="key">键名称</param>
        /// <returns>是否已经缓存</returns>
        bool Contains(string key);

        /// <summary>
        /// 根据指定键名称删除缓存对象
        /// </summary>
        /// <param name="key">键名称</param>
        void Remove(string key);

        /// <summary>
        /// 根据指定规则删除缓存对象
        /// </summary>
        /// <param name="partten">删除规则</param>
        void RemoveByPartten(string pattern);

        /// <summary>
        /// 清空缓存对象
        /// </summary>
        void Clear();
    }
}
