using BSP.Model;

namespace BSP.ViewModel
{
    /// <summary>
    /// 购物车项目类型
    /// </summary>
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
    }
}
