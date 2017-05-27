using BSP.Model;

namespace BSP.ViewModel
{
    /// <summary>
    /// 购物车项目类型
    /// </summary>
[System.Serializable]
    public class ShoppingCartItem
    {
        /// <summary>
        /// 图书对象
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 购物车项目小计
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                if (this.Book != null)
                {
                    return this.Count * this.Book.UnitPrice;
                }

                return 0;
            }
        }
    }
}
