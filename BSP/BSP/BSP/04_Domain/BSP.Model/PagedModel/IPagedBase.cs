namespace BSP.Model
{
    using System.Collections.Generic;
    /// <summary>
    /// 分页集合对象泛型接口
    /// </summary>
    /// <typeparam name="T">集合限定类型</typeparam>
    public interface IPagedBase<T> : IPagedBase, IEnumerable<T>
    {
        /// <summary>
        /// 获取指定索引位置的对象
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T this[int index] { get; }

        /// <summary>
        /// 集合中包含的元素个数
        /// </summary>
        int Count { get; }
    }

    /// <summary>
    /// 分页集合对象基础接口
    /// </summary>
    public interface IPagedBase
    {
        /// <summary>
        /// 集合是否含有数据
        /// </summary>
        bool IsNotNull { get; }

        /// <summary>
        /// 总页数
        /// </summary>
        int PageCount { get; }

        /// <summary>
        /// 当前页码
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// 页面大小
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// 总记录数
        /// </summary>
        int RecordCount { get; }

        /// <summary>
        /// 是否含有下一页
        /// </summary>
        bool HasNextPage { get; }

        /// <summary>
        /// 是否含有上一页
        /// </summary>
        bool HasPreviewPage { get; }
    }
}
