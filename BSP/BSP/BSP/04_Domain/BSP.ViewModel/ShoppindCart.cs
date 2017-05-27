using BSP.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BSP.ViewModel
{
    /// <summary>
    /// 购物车对象
    /// </summary>
    [System.Serializable]
    public class ShoppingCart
    {
        private IDictionary<int, ShoppingCartItem> _items = new Dictionary<int, ShoppingCartItem>();

        /// <summary>
        /// 购物项
        /// </summary>
        public IDictionary<int, ShoppingCartItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 商品总价
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;

                foreach (var item in this.Items.Values)
                {
                    totalPrice += item.Subtotal;
                }

                return totalPrice;
            }
        }
    }
}
