using BSP.IRepository;
using BSP.Model;
using System.Collections.Generic;
using BSP.SqlUtility;

namespace BSP.SqlRepository
{
    public class UserStatesRepository : _BaseRespotiroy, IUserStatesRepository
    {
        public IList<Model.UserStates> GetAllUserStates()
        {
            return base.Database.GetSimpleList<UserStates>();
        }
    }
}
