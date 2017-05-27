using BSP.SqlUtility;

namespace BSP.SqlRepository
{
    /// <summary>
    /// 基础数据库仓库类型
    /// </summary>
    public abstract class _BaseRespotiroy
    {
        /// <summary>
        /// 数据库操作基础对象
        /// </summary>
        protected SqlHelper Database
        {
            get
            {
                return new SqlHelper("DefaultConnection");
            }
        }
    }
}
