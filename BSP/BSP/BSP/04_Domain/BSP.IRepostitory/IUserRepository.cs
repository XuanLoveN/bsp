using BSP.Model;
using System.Collections.Generic;

namespace BSP.IRepository
{
    /// <summary>
    /// 用户数据仓库接口
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        IMessage<UserTicket> ValidateSignin(User user);
        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        /// <returns></returns>
        IList<User> GetAllUsers();

        /// <summary>
        /// 根据用户编号获取用户对象
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns></returns>
        User GetUserById(int id);

        /// <summary>
        /// 获取全部用户状态信息
        /// </summary>
        /// <returns></returns>
        IList<UserStates> GetAllUsetStates();
    }
}
