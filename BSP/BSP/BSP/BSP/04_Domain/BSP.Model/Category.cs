using System;

namespace BSP.Model
{
    /// <summary>
    /// (Categories)实体类
    /// Template by Arien.Xie
    /// </summary>
    [Serializable]
    public partial class Category
    {
        #region 常量
        /// <summary>
        /// 表名
        /// </summary>
        public const string Tablename = "Categories";

        /// <summary>
        /// 
        /// </summary>
        public const string _Id = "Id";

        /// <summary>
        /// 
        /// </summary>
        public const string _Name = "Name";

        /// <summary>
        /// 
        /// </summary>
        public const string _PId = "PId";

        /// <summary>
        /// 
        /// </summary>
        public const string _SortNum = "SortNum";
        #endregion

        #region 私有变量
        //
        private int _id = 0;
        //
        private string _name = String.Empty;
        //
        private int _pId = 0;
        //
        private int _sortNum = 0;

        #endregion

        #region 公共属性
        /// <summary>
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// </summary>
        public int PId
        {
            get { return _pId; }
            set { _pId = value; }
        }

        /// <summary>
        /// </summary>
        public int SortNum
        {
            get { return _sortNum; }
            set { _sortNum = value; }
        }
        #endregion

        #region 扩展属性
        #endregion
    }
}
