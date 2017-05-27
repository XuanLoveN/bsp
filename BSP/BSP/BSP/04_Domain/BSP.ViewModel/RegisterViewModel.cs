using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BSP.ViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "登录名"), Required(ErrorMessage = "{0}不能为空")]
        public string LoginId { get; set; }

        [Display(Name = "密码"), Required(ErrorMessage = "{0}不能为空"), StringLength(18, MinimumLength = 6, ErrorMessage = "{0}的长度必须在{2}-{1}之间")]
        public string LoginPwd { get; set; }

        [Display(Name = "登录密码"), Compare("LoginPwd", ErrorMessage = "两次输入密码不一致")]
        public string ConfirmPwd { get; set; }

        [Display(Name = "电子邮件"), Required(ErrorMessage = "{0}不能为空"), RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "{0}格式错误")]
        public string Email { get; set; }

        [Display(Name = "用户名"), Required(ErrorMessage = "{0}不能为空")]
        public string Name { get; set; }

        [Display(Name = "地址"), Required(ErrorMessage = "{0}不能为空")]
        public string Address { get; set; }

        [Display(Name = "联系电话"), Required(ErrorMessage = "{0}不能为空"), RegularExpression(@"^1\d{10}$", ErrorMessage = "{0}格式错误")]
        public string Phone { get; set; }
    }
}
