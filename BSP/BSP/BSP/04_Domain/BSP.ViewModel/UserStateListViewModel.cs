using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSP.Model;
using System.Web.Mvc;

namespace BSP.ViewModel
{
    public class UserStateListViewModel
    {
        public User User { get; set; }
        public SelectList States { get; set; }
        public SelectList Roles { get; set; }
    }
}
