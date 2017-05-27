using System;
using System.Collections.Generic;

namespace BSP.Model
{
    /// <summary>
    /// (OrderBook)实体类
    /// Template by Arien.Xie
    /// </summary>
    [Serializable]
    public partial class OrderBook
    {
        #region 常量
        /// <summary>
        /// 表名
        /// </summary>
        public const string Tablename = "OrderBook";

        /// <summary>
        /// 
        /// </summary>
        public const string _Id = "Id";

        /// <summary>
        /// 
        /// </summary>
        public const string _OrderID = "OrderID";

        /// <summary>
        /// 
        /// </summary>
        public const string _BookID = "BookID";

        /// <summary>
        /// 
        /// </summary>
        public const string _Quantity = "Quantity";

        /// <summary>
        /// 
        /// </summary>
        public const string _UnitPrice = "UnitPrice";
        #endregion

        #region 私有变量
        //
        private int _id = 0;
        //
        private int _orderID = 0;
        //
        private int _bookID = 0;
        //
        private int _quantity = 0;
        //
        private decimal _unitPrice;

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
        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        /// <summary>
        /// </summary>
        public int BookID
        {
            get { return _bookID; }
            set { _bookID = value; }
        }

        /// <summary>
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        /// <summary>
        /// </summary>
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
        #endregion

        #region 扩展属性
        #endregion
    }
}
