namespace BSP.SqlUtility
{
    using BSP.Core.Helper;
    using BSP.Helper;
    using BSP.SqlUtility.Helper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    /// <summary>
    /// 简单对象处理扩展类型
    /// </summary>
    public static class SimpleObjectExtension
    {
        #region 公开函数
        /// <summary>
        /// 更改禁用状态
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="tableName">表名</param>
        /// <param name="id">更改编号</param>
        /// <param name="idField">标识字段名称(默认为ID)</param>
        /// <returns></returns>
        public static bool ChangeNullity(this SqlHelper helper, string tableName, int id, string idField = "ID")
        {
            string sql = string.Format("UPDATE {0} SET Nullity=(~Nullity) WHERE {1}=@ID", tableName, idField);
            return helper.ExecuteNonQuery(System.Data.CommandType.Text, sql, id.ToInParameter("ID")) > 0;
        }

        /// <summary>
        /// 获取单个结果
        /// </summary>
        /// <typeparam name="T">结果类型</typeparam>
        /// <param name="helper">数据库操作辅助对象</param>
        /// <param name="commandType">数据库操作类型</param>
        /// <param name="commandText">数据库操作语句</param>
        /// <param name="param">数据库操作参数</param>
        /// <returns></returns>
        public static T GetSingleResult<T>(this SqlHelper helper, CommandType commandType, string commandText, params SqlParameter[] param)
        {
            object tmpObjResult = helper.ExecuteScalar(commandType, commandText, param);
            return (T)DataTypeHelper.ChangeType(typeof(T), tmpObjResult);
        }

        /// <summary>
        /// 获取单个结果
        /// </summary>
        /// <typeparam name="T">结果类型</typeparam>
        /// <param name="helper">数据库操作辅助对象</param>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">列名称</param>
        /// <param name="param">数据库操作参数</param>
        /// <returns></returns>
        public static T GetSingleResult<T>(this SqlHelper helper, string tableName, string columnName, params SqlParameter[] param)
        {
            string commandText = string.Format("SELECT TOP 1 {0} FROM {1}(NOLOCK)", columnName, tableName);

            if (param != null)
            {
                commandText += " WHERE 1=1 ";
                foreach (var item in param)
                {
                    string key = item.ParameterName.StartsWith("@") ? item.ParameterName.Substring(1) : item.ParameterName;
                    string value = item.ParameterName.StartsWith("@") ? item.ParameterName : "@" + item.ParameterName;
                    commandText += string.Format("AND {0}={1}", key, value);
                }
            }

            object tmpObjResult = helper.ExecuteScalar(CommandType.Text, commandText, param);
            return (T)DataTypeHelper.ChangeType(typeof(T), tmpObjResult);
        }

        /// <summary>
        /// 获取单个简单对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="helper">数据库操作辅助对象</param>
        /// <param name="condition">查询条件(可空)</param>
        /// <param name="fields">查询字段(可空)</param>
        /// <param name="param">查询参数(可空)</param>
        /// <returns></returns>
        public static T GetSimpleObject<T>(this SqlHelper helper, string condition, string[] fields, params SqlParameter[] param)
        {
            //获取表名称
            Type targetType = typeof(T);
            T obj = Activator.CreateInstance<T>();
            string tableName = (string)targetType.GetField("Tablename").GetValue(obj);

            if (!string.IsNullOrEmpty(condition))
            {
                if (!condition.StartsWith("WHERE", StringComparison.CurrentCultureIgnoreCase))
                {
                    condition = "WHERE " + condition;
                }
            }

            //拼接SQL语句
            string sql = string.Format("SELECT {0} FROM {1}(NOLOCK) {2}", GetFields(fields), tableName, condition);

            DataSet dataSet = helper.ExecuteFillDataSet(CommandType.Text, sql, param);

            //验证数据集
            if (ValidationHelper.IsNotEmptyDataSet(dataSet))
            {
                //返回指定类型数据
                return DataConvertHelper.ToObject<T>(dataSet.Tables[0].Rows[0]);
            }

            return default(T);
        }

        /// <summary>
        /// 获取单个简单对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="helper">数据库操作辅助对象</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static T GetSimpleObject<T>(this SqlHelper helper, SqlParameter param)
        {
            return GetSimpleObject<T>(helper, string.Format("WHERE {0}={1}", param.ParameterName.Substring(1), param.ParameterName), null, param);
        }

        /// <summary>
        /// 查询简单集合对象
        /// </summary>
        /// <typeparam name="T">集合对象限定类型</typeparam>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IList<T> GetSimpleList<T>(this SqlHelper helper)
        {
            return GetSimpleList<T>(helper, string.Empty, string.Empty, null);
        }

        /// <summary>
        /// 查询简单集合对象
        /// </summary>
        /// <typeparam name="T">集合对象限定类型</typeparam>
        /// <param name="helper"></param>
        /// <param name="top">限制返回行数</param>
        /// <returns></returns>
        public static IList<T> GetSimpleList<T>(this SqlHelper helper, int top)
        {
            return GetSimpleList<T>(helper, string.Empty, string.Empty, null, top);
        }

        /// <summary>
        /// 查询简单集合对象
        /// </summary>
        /// <typeparam name="T">集合对象限定类型</typeparam>
        /// <param name="helper">数据库操作辅助对象</param>
        /// <param name="condition">查询条件(可空)</param>
        /// <param name="orderBy">查询排序条件</param>
        /// <param name="fields">查询字段(可空)</param>
        /// <param name="top">限制返回行数(默认为0，即代表不限制)</param>
        /// <param name="param">查询参数(可空)</param>
        /// <returns></returns>
        public static IList<T> GetSimpleList<T>(this SqlHelper helper, string condition, string orderBy = null, string[] fields = null, int top = 0, params SqlParameter[] param)
        {
            //获取表名称
            Type targetType = typeof(T);
            T obj = Activator.CreateInstance<T>();
            string tableName = (string)targetType.GetField("Tablename").GetValue(obj);

            string sql = "SELECT ";

            //判断并追加限制行数
            if (top > 0)
            {
                sql += string.Format("TOP {0} ", top);
            }

            sql += string.Format("{0} FROM {1}(NOLOCK)", GetFields(fields), tableName);

            //判断并追加条件
            if (!string.IsNullOrEmpty(condition))
            {
                sql += string.Format(" {0} {1} ", !condition.Trim().StartsWith("WHERE", StringComparison.CurrentCultureIgnoreCase) ? "WHERE" : string.Empty, condition);
            }

            //判断并追加排序
            if (!string.IsNullOrEmpty(orderBy))
            {
                sql += string.Format(" {0} {1} ", !orderBy.Trim().StartsWith("ORDER BY", StringComparison.CurrentCultureIgnoreCase) ? "ORDER BY" : string.Empty, orderBy);
            }

            DataSet dataSet = helper.ExecuteFillDataSet(CommandType.Text, sql, param);

            if (ValidationHelper.IsNotEmptyDataSet(dataSet))
            {
                return DataConvertHelper.ToList<T>(dataSet.Tables[0]);
            }

            return null;
        }
        #endregion

        #region 私有函数
        /// <summary>
        /// 获取字段列表
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="fieldAlias"></param>
        /// <returns></returns>
        private static string GetFields(string[] fields)
        {
            if (fields == null)
            {
                return " * ";
            }

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < fields.Length; i++)
            {
                string field = fields[i];
                builder.AppendFormat("{0} ,", field);
            }

            return builder.Remove(builder.Length - 1, 1).ToString();
        }
        #endregion
    }
}
