using BSP.Model;
using System;
using System.Collections.Generic;

namespace BSP.Biz.Adapters
{
    /// <summary>
    /// 用户信息适配器
    /// </summary>
    public class UserAdapter : _BaseAdapter
    {
        /// <summary>
        /// 处理用户登录
        /// </summary>
        /// <param name="loginId">用户名</param>
        /// <param name="loginPwd">密码</param>
        /// <returns></returns>
        public IMessage<UserTicket> Signin(string loginId, string loginPwd)
        {
            IMessage<UserTicket> message = Message<UserTicket>.ErrorMessage;

            try
            {
                message = base.UserRepository.ValidateSignin(new User
                 {
                     LoginId = loginId,
                     LoginPwd = loginPwd//.ToMD5()
                 });
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
#if !DEBUG
                base.Logger.ErrorException("用户登录时产生异常", ex);
#endif
            }

            return message;
        }
        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        /// <returns></returns>
        public IList<User> GetAllUsers()
        {
            return base.UserRepository.GetAllUsers();
        }

        /// <summary>
        /// 根据编号获取用户对象
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            return base.UserRepository.GetUserById(id);
        }
        //获取全部用户状态信息
        public IList<UserStates> GetAllUserStates()
        {
            return base.UserRepository.GetAllUsetStates();
        }
    }
}
