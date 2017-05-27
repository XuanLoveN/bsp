using BSP.IRepository;
using BSP.Model;
using BSP.SqlUtility;
using System.Collections.Generic;

namespace BSP.SqlRepository
{
    /// <summary>
    /// 用户数据仓库
    /// </summary>
    public class UserRepository : _BaseRespotiroy, IUserRepository
    {
        public IMessage<UserTicket> ValidateSignin(User user)
        {
            //将传递过来的参数名转化为 数据库对象 user.LoginId.ToInParamrter
            return Database.GetMessageForObject<UserTicket>("SP_Signin", user.LoginId.ToInParameter("LoginId"), user.LoginPwd.ToInParameter("LoginPwd"));
        }
        public IList<User> GetAllUsers()
        {
            return base.Database.GetSimpleList<User>();
        }

        public User GetUserById(int id)
        {
            return base.Database.GetSimpleObject<User>(id.ToInParameter("id"));
        }
        //获取用户状态信息
        public IList<UserStates> GetAllUsetStates()
        {
            return base.Database.GetSimpleList<UserStates>();
        }
    }
}
