namespace BSP.SqlUtility
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// 参数扩展类型
    /// </summary>
    public static class ParameterExtension
    {
        private const string PREFIX = "@";

        /// <summary>
        /// 将对象转换为SQL Server参数对象
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static SqlParameter ToInParameter(this object obj, string parameterName)
        {
            if (string.IsNullOrEmpty(parameterName)) throw new ArgumentNullException("参数名不能为空");

            parameterName = parameterName.StartsWith(PREFIX) ? parameterName : PREFIX + parameterName;

            if (obj == null) obj = DBNull.Value;

            return new SqlParameter(parameterName, obj);
        }

        /// <summary>
        /// 将一个对象转换为SQL Server参数列表对象
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="excludePropertiyNames">需要排除的属性名称</param>
        /// <returns></returns>
        public static IList<SqlParameter> ToInPrarmterList(this object obj, params string[] excludePropertiyNames)
        {
            return ParameterHelper.ConvertObjectToParameterList(obj, excludePropertiyNames);
        }

        /// <summary>
        /// 构建错误输出参数
        /// </summary>
        /// <param name="param"></param>
        public static void BuildErrorParameter(this IList<SqlParameter> param)
        {
            param.Add(ParameterHelper.NewOutParameter("ErrorDescribe", SqlDbType.NVarChar));
        }

        /// <summary>
        /// 构建返回值参数
        /// </summary>
        /// <param name="param"></param>
        public static void BuildReturnParameter(this IList<SqlParameter> param)
        {
            SqlParameter retParam = new SqlParameter("ReturnValue", SqlDbType.Int);
            retParam.Direction = ParameterDirection.ReturnValue;
            param.Add(retParam);
        }
    }
}
