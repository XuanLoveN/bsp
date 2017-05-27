namespace BSP.Model
{
    using System;

    /// <summary>
    /// 分页参数
    /// </summary>
    [Serializable]
    public class PagerParameter
    {
        #region 私有字段
        private string _orderBy;
        private string _condition;
        #endregion

        #region 公开属性
        /// <summary>
        /// 当前页面索引
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 排序条件
        /// </summary>
        public string OrderBy
        {
            get
            {
                this._orderBy = this._orderBy.Trim();

                return _orderBy.StartsWith("order by", StringComparison.CurrentCultureIgnoreCase) ? _orderBy : string.Format("ORDER BY {0}", this._orderBy);
            }
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string Condition
        {
            get
            {
                this._condition = this._condition.Trim();

                return _condition.StartsWith("where", StringComparison.CurrentCultureIgnoreCase) ? _condition : string.Format("WHERE {0}", this._condition);
            }
        }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; private set; }

        /// <summary>
        /// 字段别名
        /// </summary>
        public string[] FiledAlias { get; private set; }

        /// <summary>
        /// 字段集合
        /// </summary>
        public string[] Fileds { get; private set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化分页参数
        /// </summary>
        public PagerParameter()
            : this(1, 20)
        {
        }

        /// <summary>
        /// 初始化分页参数
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public PagerParameter(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }

        /// <summary>
        /// 初始化分页参数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="pageIndex">当前页码</param>
        public PagerParameter(string tableName, string orderBy, int pageIndex)
            : this()
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException("表名不能为空！");
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                throw new ArgumentException("排序条件不能为空！");
            }
            if (pageIndex < 1)
            {
                throw new ArgumentException("当前页码不能低于1");
            }

            this._orderBy = orderBy;
            this.TableName = tableName;
            this.PageIndex = pageIndex;
        }

        /// <summary>
        /// 初始化分页参数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="pageIndex">查询条件</param>
        /// <param name="pageSize">页面大小</param>
        public PagerParameter(string tableName, string orderBy, int pageIndex, int pageSize)
            : this(tableName, orderBy, pageIndex)
        {
            if (PageSize < 1)
            {
                throw new ArgumentException("页面大小不能小于1");
            }
            this.PageSize = pageSize;
        }

        /// <summary>
        /// 初始化分页参数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="condition">查询条件</param>
        /// <param name="pageIndex">当前页码</param>
        public PagerParameter(string tableName, string orderBy, string condition, int pageIndex)
            : this(tableName, orderBy, pageIndex)
        {
            this._condition = condition;
        }

        /// <summary>
        /// 初始化分页参数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="condition">查询条件</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">页面大小</param>
        public PagerParameter(string tableName, string orderBy, int pageIndex, int pageSize, string condition)
            : this(tableName, orderBy, condition, pageIndex)
        {
            this.PageSize = pageSize;
        }

        /// <summary>
        /// 初始化分页参数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="condition">查询条件</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="fields">字段集合</param>
        public PagerParameter(string tableName, string orderBy, int pageIndex, int pageSize, string condition, string[] fields)
            : this(tableName, orderBy, pageIndex, pageSize, condition)
        {
            this.Fileds = fields;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="condition">查询条件</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="fields">字段集合</param>
        /// <param name="fieldAlias">字段别名</param>
        public PagerParameter(string tableName, string orderBy, int pageIndex, int pageSize, string condition, string[] fields, string[] fieldAlias)
            : this(tableName, orderBy, pageIndex, pageSize, condition, fields)
        {
            this.FiledAlias = fieldAlias;
        }
        #endregion
    }
}
