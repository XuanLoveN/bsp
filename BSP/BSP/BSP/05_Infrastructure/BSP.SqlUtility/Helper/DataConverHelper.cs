
namespace BSP.SqlUtility.Helper
{
    using BSP.Core.Helper;
    using BSP.Exceptions;
    using BSP.Helper;
    using BSP.SqlUtility.Annotation;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// 数据转换帮助类
    /// </summary>
    internal sealed class DataConvertHelper
    {
        /// <summary>
        /// 将数据表转换为指定类型的对象集合
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="table">数据表</param>
        /// <param name="excludeProperties">需要排除的属性名称列表</param>
        /// <returns></returns>
        internal static IList<T> ToList<T>(DataTable table, params string[] excludeProperties)
        {
            IList<T> resultList = new List<T>();

            if (table != null && ValidationHelper.IsNotEmptyDataSet(table.DataSet))
            {
                foreach (DataRow row in table.Rows)
                {
                    T resultObject = ToObject<T>(row, excludeProperties);
                    //如果转换到的结果对象不为空，则添加到集合中
                    if (resultList != null && !resultObject.Equals(default(T)))
                        resultList.Add(resultObject);
                }
            }

            return resultList;
        }

        /// <summary>
        /// 将数据行转换为指定类型的对象
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="row">数据行</param>
        /// <param name="excludeProperties">需要排除的属性名称列表</param>
        /// <returns></returns>
        internal static T ToObject<T>(DataRow row, params string[] excludeProperties)
        {
            if (row == null) return default(T);

            //获取限定类型的类类型
            Type targetType = typeof(T);
            //通过反射中的激活器根据指定类型的无参构造函数创建对象实例
            T resultObject = Activator.CreateInstance<T>();
            //根据当前数据行获取拥有其架构的数据表对象
            DataTable table = row.Table;

            //指示属性为公开的、含有Set访问的、含有实例的、忽略大小写的
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.IgnoreCase;

            foreach (DataColumn column in table.Columns)
            {
                if (excludeProperties.Contains<string>(column.ColumnName)) continue;
                //根据列名称获取目标类型中的属性对象
                PropertyInfo targetProperty = targetType.GetProperty(column.ColumnName, bindingFlags);
                //如果未找到对象则抛出异常
                if (targetProperty == null) throw new PropertyNotFoundException(targetType.FullName, column.ColumnName);

                //获取用户自定义特性
                Attribute attribute = targetProperty.GetCustomAttribute(typeof(NonReflectionAttribute));
                if (attribute != null) continue;

                //获取指定属性的类类型
                Type propertyType = targetProperty.PropertyType;

                object parameters = null;
                bool convertFlag = true;

                try
                {
                    parameters = DataTypeHelper.ChangeType(propertyType, row[column]);
                }
                catch { convertFlag = false; }

                //如果数据类型转换成功，则将单元格中的值保存到指定属性中
                if (convertFlag) targetType.InvokeMember(column.ColumnName, bindingFlags, null, resultObject, new object[] { parameters });
            }

            return resultObject;
        }
    }
}
