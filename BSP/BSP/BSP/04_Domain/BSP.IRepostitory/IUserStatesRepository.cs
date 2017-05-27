using BSP.Model;
using System.Collections.Generic;

namespace BSP.IRepository
{
    /// <summary>
    /// 用户状态仓库接口
    /// </summary>
    public interface IUserStatesRepository
    {
        /// <summary>
        /// 获得用户状态列表
        /// </summary>
        /// <returns></returns>
        IList<UserStates> GetAllUserStates();
    }
}
