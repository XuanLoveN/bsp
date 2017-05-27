using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSP.Model
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        public class UserMetaData
        {
            [Display(Name = "用户编号")]
            public int Id { get; set; }
            [Display(Name = "登录名")]
            public string LoginId { get; set; }
            [Display(Name = "用户名"), Required(ErrorMessage = "{0}不能为空")]
            public string Name { get; set; }
            [Display(Name = "地址"), Required(ErrorMessage = "{0}不能为空")]
            public string Address { get; set; }
            [Display(Name = "联系电话"), Required(ErrorMessage = "{0}不能为空"), RegularExpression(@"^1\d{10}$", ErrorMessage = "{0}格式错误")]
            public string Phone { get; set; }
            [Display(Name = "电子邮件"), Required(ErrorMessage = "{0}不能为空"), RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "{0}格式错误")]
            public string Mail { get; set; }
            [Display(Name = "出生日期"), Required(ErrorMessage = "{0}不能为空"), Range(typeof(DateTime), "1960-01-01", "2016-08-16")]
            public DateTime Birthday { get; set; }
            [Display(Name = "用户角色"), Required(ErrorMessage = "{0}不能为空")]
            public int UserRoleId { get; set; }
            [Display(Name = "用户状态"), Required(ErrorMessage = "{0}不能为空")]
            public int UserStateId { get; set; }
        }
    }
}
