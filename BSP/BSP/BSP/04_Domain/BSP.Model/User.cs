using BSP.SqlUtility.Annotation;
using System;

namespace BSP.Model
{
    /// <summary>
    /// (Users)实体类
    /// Template by Arien.Xie
    /// </summary>
    [Serializable]
    public partial class User
    {
        #region 常量
        /// <summary>
        /// 表名
        /// </summary>
        public const string Tablename = "Users";

        /// <summary>
        /// 流水号
        /// </summary>
        public const string _Id = "Id";

        /// <summary>
        /// 登录名
        /// </summary>
        public const string _LoginId = "LoginId";

        /// <summary>
        /// 密码
        /// </summary>
        public const string _LoginPwd = "LoginPwd";

        /// <summary>
        /// 用户名
        /// </summary>
        public const string _Name = "Name";

        /// <summary>
        /// 地址
        /// </summary>
        public const string _Address = "Address";

        /// <summary>
        /// 联系电话
        /// </summary>
        public const string _Phone = "Phone";

        /// <summary>
        /// 电子邮件
        /// </summary>
        public const string _Mail = "Mail";

        /// <summary>
        /// 生日
        /// </summary>
        public const string _Birthday = "Birthday";

        /// <summary>
        /// 用户权限编号
        /// </summary>
        public const string _UserRoleId = "UserRoleId";

        /// <summary>
        /// 用户状态编号
        /// </summary>
        public const string _UserStateId = "UserStateId";

        /// <summary>
        /// 注册IP地址
        /// </summary>
        public const string _RegisterIp = "RegisterIp";

        /// <summary>
        /// 注册时间
        /// </summary>
        public const string _RegisterTime = "RegisterTime";
        #endregion

        #region 私有变量
        //流水号
        private int _id = 0;
        //登录名
        private string _loginId = String.Empty;
        //密码
        private string _loginPwd = String.Empty;
        //用户名
        private string _name = String.Empty;
        //地址
        private string _address = String.Empty;
        //联系电话
        private string _phone = String.Empty;
        //电子邮件
        private string _mail = String.Empty;
        //生日
        private DateTime _birthday = DateTime.Now;
        //用户权限编号
        private int _userRoleId = 0;
        //用户状态编号
        private int _userStateId = 0;
        //注册IP地址
        private string _registerIp = String.Empty;
        //注册时间
        private DateTime _registerTime = DateTime.Now;

        #endregion

        #region 公共属性
        /// <summary>
        /// 流水号
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginId
        {
            get { return _loginId; }
            set { _loginId = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string LoginPwd
        {
            get { return _loginPwd; }
            set { _loginPwd = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /// <summary>
        /// 用户权限编号
        /// </summary>
        public int UserRoleId
        {
            get { return _userRoleId; }
            set { _userRoleId = value; }
        }

        /// <summary>
        /// 用户状态编号
        /// </summary>
        public int UserStateId
        {
            get { return _userStateId; }
            set { _userStateId = value; }
        }

        /// <summary>
        /// 注册IP地址
        /// </summary>
        public string RegisterIp
        {
            get { return _registerIp; }
            set { _registerIp = value; }
        }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterTime
        {
            get { return _registerTime; }
            set { _registerTime = value; }
        }
        #endregion

        #region 扩展属性

        [NonParameter, NonReflection]
        public UserStates UserState { get; set; }

        #endregion
    }
}
