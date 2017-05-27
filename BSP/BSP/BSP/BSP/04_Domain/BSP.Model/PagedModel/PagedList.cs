namespace BSP.Model
{
    using BSP.Core.Helper;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// 分页集合类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : IPagedBase<T>
    {
        #region 受保护对象
        /// <summary>
        /// 本地集合对象
        /// </summary>
        protected readonly IList<T> _dataList = new List<T>();
        #endregion

        #region 构造函数
        /// <summary>
        /// 构建分页集合对象
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="pageCount">总页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="dataList">数据集合</param>
        public PagedList(int pageIndex, int pageSize, int pageCount, int recordCount, IList<T> dataList)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.RecordCount = recordCount;
            this.PageCount = pageCount;
            this._dataList = dataList;
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取指定索引位置的对象
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return this._dataList[index]; }
        }

        /// <summary>
        /// 集合中包含的元素个数
        /// </summary>
        public int Count
        {
            get { return this._dataList.Count; }
        }

        /// <summary>
        /// 集合是否含有数据
        /// </summary>
        public bool IsNotNull
        {
            get { return ValidationHelper.IsNotEmptyList<T>(this._dataList); }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; private set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount { get; private set; }

        /// <summary>
        /// 是否含有下一页
        /// </summary>
        public bool HasNextPage
        {
            get { return this.PageIndex < this.PageCount; }
        }

        /// <summary>
        /// 是否含有上一页
        /// </summary>
        public bool HasPreviewPage
        {
            get { return this.PageIndex > 1; }
        }
        #endregion

        #region 公共函数
        /// <summary>
        /// 获取迭代器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this._dataList.GetEnumerator();
        }

        /// <summary>
        /// 获取迭代器
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}