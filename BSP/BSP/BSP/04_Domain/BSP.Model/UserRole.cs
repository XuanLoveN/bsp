using System;
using System.Collections.Generic;

namespace BSP.Model
{
	/// <summary>
    /// (UserRoles)实体类
    /// Template by Arien.Xie
	/// </summary>
	[Serializable]
	public partial class UserRole
	{
        #region 常量
        /// <summary>
		/// 表名
		/// </summary>
        public const string Tablename="UserRoles";

        /// <summary>
        /// 
        /// </summary>
        public const string _Id = "Id";

        /// <summary>
        /// 
        /// </summary>
        public const string _Name = "Name";
        #endregion
    
		#region 私有变量
        //
		private int _id = 0; 
        //
		private string _name = String.Empty; 
		
		#endregion
		
		#region 公共属性
		/// <summary>
        /// </summary>
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		/// <summary>
        /// </summary>
		public string Name
		{
			get {return _name;}
			set {_name = value;}
		}
		#endregion
        
        #region 扩展属性
        #endregion
	}
}
