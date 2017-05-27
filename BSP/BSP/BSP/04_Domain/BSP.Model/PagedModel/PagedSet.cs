namespace BSP.Model
{
    using BSP.Core.Helper;
    using System.Data;

    /// <summary>
    /// 分页数据集类型
    /// </summary>
    public class PagedSet : IPagedBase
    {
        /// <summary>
        /// 单页数据集
        /// </summary>
        public DataSet DataSet { get; private set; }

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
            get
            {
                return PageIndex < PageCount;
            }
        }

        /// <summary>
        /// 是否含有上一页
        /// </summary>
        public bool HasPreviewPage
        {
            get
            {
                return PageIndex > 1;
            }
        }

        /// <summary>
        /// 数据集是否含有数据
        /// </summary>
        public bool IsNotNull
        {
            get
            {
                return ValidationHelper.IsNotEmptyDataSet(DataSet);
            }
        }



        /// <summary>
        /// 初始化分页数据集
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageCount">总页数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="dataSet">分页数据集</param>
        public PagedSet(int pageIndex, int pageSize, int pageCount, int recordCount, DataSet dataSet)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            PageCount = pageCount;
            RecordCount = recordCount;
            DataSet = dataSet;
        }
    }
}
