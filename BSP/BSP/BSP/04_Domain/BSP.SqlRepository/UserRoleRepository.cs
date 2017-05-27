using BSP.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSP.SqlUtility;
using BSP.Model;

namespace BSP.SqlRepository
{
    public  class UserRoleRepository:_BaseRespotiroy,IUserRoleRepository
    {
        public IList<UserRole> GetAllUserRole()
        {
            return base.Database.GetSimpleList<UserRole>();
        }
    }
}
