using System;
using System.Collections.Generic;

namespace BSP.Model
{
    /// <summary>
    /// (Books)实体类
    /// Template by Arien.Xie
    /// </summary>
    [Serializable]
    public partial class Book
    {
        #region 常量
        /// <summary>
        /// 表名
        /// </summary>
        public const string Tablename = "Books";

        /// <summary>
        /// 
        /// </summary>
        public const string _Id = "Id";

        /// <summary>
        /// 
        /// </summary>
        public const string _Title = "Title";

        /// <summary>
        /// 
        /// </summary>
        public const string _Author = "Author";

        /// <summary>
        /// 
        /// </summary>
        public const string _PublisherId = "PublisherId";

        /// <summary>
        /// 
        /// </summary>
        public const string _PublishDate = "PublishDate";

        /// <summary>
        /// 
        /// </summary>
        public const string _ISBN = "ISBN";

        /// <summary>
        /// 
        /// </summary>
        public const string _UnitPrice = "UnitPrice";

        /// <summary>
        /// 
        /// </summary>
        public const string _ContentDescription = "ContentDescription";

        /// <summary>
        /// 
        /// </summary>
        public const string _TOC = "TOC";

        /// <summary>
        /// 
        /// </summary>
        public const string _CategoryId = "CategoryId";

        /// <summary>
        /// 
        /// </summary>
        public const string _Clicks = "Clicks";
        #endregion

        #region 私有变量
        //
        private int _id = 0;
        //
        private string _title = String.Empty;
        //
        private string _author = String.Empty;
        //
        private int _publisherId = 0;
        //
        private DateTime _publishDate = DateTime.Now;
        //
        private string _iSBN = String.Empty;
        //
        private decimal _unitPrice;
        //
        private string _contentDescription = String.Empty;
        //
        private string _tOC = String.Empty;
        //
        private int _categoryId = 0;
        //
        private int _clicks = 0;

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
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// </summary>
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        /// <summary>
        /// </summary>
        public int PublisherId
        {
            get { return _publisherId; }
            set { _publisherId = value; }
        }

        /// <summary>
        /// </summary>
        public DateTime PublishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

        /// <summary>
        /// </summary>
        public string ISBN
        {
            get { return _iSBN; }
            set { _iSBN = value; }
        }

        /// <summary>
        /// </summary>
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        /// <summary>
        /// </summary>
        public string ContentDescription
        {
            get { return _contentDescription; }
            set { _contentDescription = value; }
        }

        /// <summary>
        /// </summary>
        public string TOC
        {
            get { return _tOC; }
            set { _tOC = value; }
        }

        /// <summary>
        /// </summary>
        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        /// <summary>
        /// </summary>
        public int Clicks
        {
            get { return _clicks; }
            set { _clicks = value; }
        }
        #endregion

        #region 扩展属性
        #endregion
    }
}
