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
        /// 用户角色管理适配器
        /// </summary>
        public class UserRoleAdapter : _BaseAdapter
        {
            /// <summary>
            /// 用户角色管理缓存键
            /// </summary>
            private const string USERROLECHEKEY = "BSP.UserRole";

            public IList<UserRole> GetAllUserRole()
            {
                return base.CacheManager.Memory.Get<IList<UserRole>>(USERROLECHEKEY, () => base.UserRoleRepository.GetAllUserRole());
            }
        }
    }
