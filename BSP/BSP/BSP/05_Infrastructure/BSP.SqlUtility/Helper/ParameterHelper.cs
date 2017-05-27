namespace BSP.SqlUtility
{
    using BSP.SqlUtility.Annotation;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;

    public class ParameterHelper
    {
        /// <summary>
        /// 构建新的输出参数
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="type">参数类型</param>
        /// <param name="size">参数大小(默认：127)</param>
        /// <returns></returns>
        public static SqlParameter NewOutParameter(string parameterName, SqlDbType type, int size = 127)
        {
            parameterName = parameterName.StartsWith("@") ? parameterName : "@" + parameterName;
            SqlParameter param = new SqlParameter(parameterName, type, size);
            param.Direction = ParameterDirection.Output;
            return param;
        }

        /// <summary>
        /// 非禁用参数
        /// </summary>
        /// <returns></returns>
        public static SqlParameter NotNullityParameter
        {
            get
            {
                SqlParameter param = new SqlParameter("@Nullity", false);
                param.SqlDbType = SqlDbType.Bit;
                return param;
            }
        }

        /// <summary>
        /// 转换对象为参数集合
        /// <remarks>
        /// 可扩展部分：
        /// 在实体模型上追加并在当前方法中验证自定义特性，以指定某个类型为实体类
        /// 因为类型如果超出实体类范围，则可能产生错误
        /// </remarks>
        /// </summary>
        /// <param name="obj">源对象</param>
        /// <param name="excludePropertyNames">转换排除属性名称列表</param>
        /// <returns></returns>
        public static IList<SqlParameter> ConvertObjectToParameterList(object obj, params string[] excludePropertyNames)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj", "将指定对象转换为SQL Server参数时，指定对象不能为空");
            }

            IList<SqlParameter> parameters = new List<SqlParameter>();

            //获取指定参数的类类型
            Type targetType = obj.GetType();
            //获取指定类型的所有属性
            PropertyInfo[] properites = targetType.GetProperties();

            foreach (var property in properites)
            {
                if (excludePropertyNames.Contains<string>(property.Name)) continue;
                //获取用户自定义特性描述
                Attribute attribute = Attribute.GetCustomAttribute(property, typeof(NonParameterAttribute));
                if (attribute != null) continue;

                //向参数对象集合中添加指定属性的SQL Server参数对象
                parameters.Add(property.GetValue(obj).ToInParameter(property.Name));
            }

            return parameters;
        }
    }
}
