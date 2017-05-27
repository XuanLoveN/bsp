using System;
using System.Collections.Generic;

namespace BSP.Model
{
    /// <summary>
    /// (Orders)实体类
    /// Template by Arien.Xie
    /// </summary>
    [Serializable]
    public partial class Order
    {
        #region 常量
        /// <summary>
        /// 表名
        /// </summary>
        public const string Tablename = "Orders";

        /// <summary>
        /// 
        /// </summary>
        public const string _Id = "Id";

        /// <summary>
        /// 
        /// </summary>
        public const string _OrderDate = "OrderDate";

        /// <summary>
        /// 
        /// </summary>
        public const string _UserId = "UserId";

        /// <summary>
        /// 
        /// </summary>
        public const string _TotalPrice = "TotalPrice";
        #endregion

        #region 私有变量
        //
        private int _id = 0;
        //
        private DateTime _orderDate = DateTime.Now;
        //
        private int _userId = 0;
        //
        private decimal _totalPrice;

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
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        /// <summary>
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// </summary>
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }
        #endregion

        #region 扩展属性
        #endregion
    }
}
