using BSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSP.Caching;

namespace BSP.Biz.Adapters
{
    /// <summary>
    /// 用户状态管理适配器
    /// </summary>
    public class UserStatesAdapter:_BaseAdapter
    {
        /// <summary>
        /// 用户状态管理缓存键
        /// </summary>
        private const string USERSTATECHEKEY = "BSP.UserStates";

        public IList<UserStates> GetAllUserState()
        {
            return base.CacheManager.Memory.Get<IList<UserStates>>(USERSTATECHEKEY,()=>base.UserStatesRepository.GetAllUserStates());
        }
    }
}
