using System.ComponentModel.DataAnnotations;

namespace BSP.ViewModel
{
    /// <summary>
    /// 登录视图模型
    /// </summary>
    public class SigninViewModel
    {
        [Display(Name = "登录名"), Required(ErrorMessage = "{0}不能为空")]
        public string UserName { get; set; }

        [Display(Name = "密码"), Required(ErrorMessage = "{0}不能为空")]
        public string Password { get; set; }

        [Display(Name = "记录登录状态")]
        public bool Remember { get; set; }

        [Display(Name = "验证码"), Required(ErrorMessage = "{0}不能为空"), StringLength(4, MinimumLength = 4, ErrorMessage = "{0}的长度必须为{1}位")]
        public string ValidateCode { get; set; }
    }
}
