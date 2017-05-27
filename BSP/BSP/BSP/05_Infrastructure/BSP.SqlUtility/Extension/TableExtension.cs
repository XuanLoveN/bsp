namespace BSP.SqlUtility
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// 表类型帮助类
    /// </summary>
    public static class TableExtension
    {
        private static readonly string _namespacePrefix = "BookShop.Model";

        /// <summary>
        /// 使用实体对象添加数据行
        /// </summary>
        /// <param name="helper">数据库操作辅助类</param>
        /// <param name="entity">实体对象</param>
        /// <param name="excludeFields">需要被剔除的列名称，多个列使用逗号","分隔</param>
        /// <returns></returns>
        public static bool Create(this SqlHelper helper, object entity, params string[] excludeFields)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("实体对象不能为空");
            }

            Type t = entity.GetType();

            //如果实体对象命名空间不为空，并且位于指定命名空间下
            if (!string.IsNullOrEmpty(t.Namespace) && t.Namespace.StartsWith(_namespacePrefix, StringComparison.CurrentCultureIgnoreCase))
            {
                //获取表名
                string tableName = (string)t.GetField("Tablename").GetValue(entity);

                //获取全部属性
                PropertyInfo[] properties = t.GetProperties();

                StringBuilder columnBuilder = new StringBuilder();
                StringBuilder valuesBuilder = new StringBuilder();

                List<SqlParameter> param = new List<SqlParameter>();

                //转换所有排除列为小写
                if (excludeFields != null)
                {
                    for (int i = 0; i < excludeFields.Length; i++)
                    {
                        excludeFields[i] = excludeFields[i].ToLower();
                    }
                }

                //循环所有属性
                foreach (PropertyInfo property in properties)
                {
                    if (excludeFields != null && excludeFields.Contains(property.Name.ToLower()))
                    {
                        //去除主键列
                        continue;
                    }

                    var value = property.GetValue(entity);

                    if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        continue;
                    }

                    columnBuilder.AppendFormat("{0},", property.Name);
                    valuesBuilder.AppendFormat("@{0},", property.Name);

                    param.Add(new SqlParameter(string.Format("@{0}", property.Name), value));
                }

                string sqlFmt = "INSERT INTO {0} ({1}) VALUES ({2})";
                string sql = string.Format(sqlFmt, tableName,
                    columnBuilder.ToString().Substring(0, columnBuilder.Length - 1),
                    valuesBuilder.ToString().Substring(0, valuesBuilder.Length - 1));

                int result = helper.ExecuteNonQuery(System.Data.CommandType.Text, sql, param.ToArray<SqlParameter>());

                return result > 0;
            }

            return false;
        }

        /// <summary>
        /// 根据实体更新数据行
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="entity"></param>
        /// <param name="primaryKey">更新条件字段</param>
        /// <param name="excludeFields">排除更新列</param>
        /// <returns></returns>
        public static bool Modify(this SqlHelper helper, object entity, string primaryKey, params string[] excludeFields)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("实体对象不能为空");
            }

            Type t = entity.GetType();

            //如果实体对象命名空间不为空，并且位于指定命名空间下
            if (!string.IsNullOrEmpty(t.Namespace) && t.Namespace.StartsWith(_namespacePrefix, StringComparison.CurrentCultureIgnoreCase))
            {
                //获取表名
                string tableName = (string)t.GetField("Tablename").GetValue(entity);
                //获取全部属性
                PropertyInfo[] properties = t.GetProperties();
                //转换所有排除列为小写
                if (excludeFields != null)
                {
                    for (int i = 0; i < excludeFields.Length; i++)
                    {
                        excludeFields[i] = excludeFields[i].ToLower();
                    }
                }

                List<SqlParameter> param = new List<SqlParameter>();

                StringBuilder commandTextBuilder = new StringBuilder("UPDATE " + tableName + " SET ");

                foreach (var property in properties)
                {
                    if (string.Equals(property.Name, primaryKey, StringComparison.CurrentCultureIgnoreCase))
                    {
                        param.Add(property.GetValue(entity).ToInParameter(property.Name));
                        continue;
                    }

                    if ((excludeFields != null && excludeFields.Contains(property.Name.ToLower())))
                    {
                        continue;
                    }

                    var value = property.GetValue(entity);

                    if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        continue;
                    }

                    //追加语句
                    commandTextBuilder.AppendFormat(" {0} = @{0} ,", property.Name);
                    //追加参数
                    param.Add(value.ToInParameter(property.Name));
                }

                string commandText = commandTextBuilder.ToString().Substring(0, commandTextBuilder.Length - 1);

                //追加条件
                commandText += string.Format(" WHERE {0} = @{0}", primaryKey);

                return helper.ExecuteNonQuery(System.Data.CommandType.Text, commandText, param.ToArray()) > 0;
            }

            return false;
        }

        /// <summary>
        /// 根据实体删除数据行
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Remove(this SqlHelper helper, object entity, string primaryKey = "ID")
        {
            if (entity == null)
            {
                throw new ArgumentNullException("实体对象不能为空");
            }

            Type t = entity.GetType();

            if (!string.IsNullOrEmpty(t.Namespace) && t.Namespace.StartsWith(_namespacePrefix, StringComparison.CurrentCultureIgnoreCase))
            {
                //获取表名
                string tableName = (string)t.GetField("Tablename").GetValue(entity);
                PropertyInfo primaryProperty = null;

                try
                {
                    primaryProperty = t.GetProperty(primaryKey);
                }
                catch { return false; }

                object value = primaryProperty.GetValue(entity);

                string commandText = string.Format("DELETE FROM {0} WHERE {1}=@{1}", tableName, primaryKey);

                return helper.ExecuteNonQuery(System.Data.CommandType.Text, commandText, value.ToInParameter(primaryKey)) > 0;
            }

            return false;
        }
    }
}
