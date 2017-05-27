using BSP.Biz.Adapters;
using Ninject;

namespace BSP.Biz
{
    /// <summary>
    /// 数据适配器外观
    /// </summary>
    public class AdapterFacade
    {
        /// <summary>
        /// 图书分类
        /// </summary>
        [Inject]
        public CategoryAdapter Category { get; private set; }

        /// <summary>
        /// 用户管理
        /// </summary>
        [Inject]
        public UserAdapter User{ get; private set; }

        /// <summary>
        /// 图书管理
        /// </summary>
        [Inject]
        public BookAdapter Book { get; private set; }
        /// <summary>
        /// 出版社管理
        /// </summary>
        [Inject]
        public PublisherAdapter Publisher { get; private set; }
        /// <summary>
        /// 用户状态管理
        /// </summary>
        [Inject]
        public UserStatesAdapter UserStates { get; private set; }
        /// <summary>
        /// 用户角色管理
        /// </summary>
        [Inject]
        public UserRoleAdapter UserRole { get; private set; }
        /// <summary>
        /// 订单管理
        /// </summary>
        [Inject]
        public OrderAdapter Order { get;private set;}
        /// <summary>
        /// 订单详情管理
        /// </summary>
        [Inject]
        public OrderBookAdapter OrderBook { get; private set; }
        
    }
}
