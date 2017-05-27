using BSP.Model;
using System.Collections.Generic;

namespace BSP.IRepository
{
    /// <summary>
    /// 用户角色仓库接口
    /// </summary>
    public interface IUserRoleRepository
    {
        /// <summary>
        /// 获得全部用户角色
        /// </summary>
        /// <returns></returns>
        IList<UserRole> GetAllUserRole();
    }
}
