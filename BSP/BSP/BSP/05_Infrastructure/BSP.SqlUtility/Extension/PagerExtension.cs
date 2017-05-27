namespace BSP.SqlUtility
{
    using BSP.Core.Helper;
    using BSP.Model;
    using BSP.SqlUtility.Helper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 分页扩展类型
    /// </summary>
    public static class PagerExtension
    {
        private static readonly string _procName = "WEB_PageView";

        /// <summary>
        /// 获取分页数据集
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static PagedSet GetPagerSet(this SqlHelper helper, PagerParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("分页参数不能为空");
            }

            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@TableName",parameter.TableName),
                new SqlParameter("@ReturnFields",GetFields(parameter.Fileds,parameter.FiledAlias)),
                new SqlParameter("@PageSize",parameter.PageSize),
                new SqlParameter("@PageIndex",parameter.PageIndex),
                new SqlParameter("@Where",parameter.Condition),
                new SqlParameter("@Orderby",parameter.OrderBy),
                new SqlParameter{ParameterName="PageCount", DbType=DbType.Int32,Direction=ParameterDirection.Output},
                new SqlParameter{ParameterName="RecordCount", DbType=DbType.Int32,Direction=ParameterDirection.Output}
            };

            sqlParam.BuildReturnParameter();

            DataSet dataSet = helper.ExecuteFillDataSet(CommandType.StoredProcedure, _procName, sqlParam.ToArray<SqlParameter>());

            int pageCount = Convert.ToInt32(sqlParam[sqlParam.Count - 3].Value);
            int recordCount = Convert.ToInt32(sqlParam[sqlParam.Count - 2].Value);

            return new PagedSet(parameter.PageIndex, parameter.PageSize, pageCount, recordCount, dataSet);
        }

        /// <summary>
        /// 获取分页数据集合
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static PagedList<T> GetPagerList<T>(this SqlHelper helper, PagerParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("分页参数不能为空");
            }

            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@TableName",parameter.TableName),
                new SqlParameter("@ReturnFields",GetFields(parameter.Fileds,parameter.FiledAlias)),
                new SqlParameter("@Where",parameter.Condition),
                new SqlParameter("@Orderby",parameter.OrderBy)
            };

            return GetPagerList<T>(helper, _procName, parameter, sqlParam.ToArray());
        }

        /// <summary>
        /// 获取分页数据集合
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static PagedList<T> GetPagerList<T>(this SqlHelper helper, string procName, PagerParameter parameter, params SqlParameter[] param)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("分页参数不能为空");
            }

            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@PageSize",parameter.PageSize),
                new SqlParameter("@PageIndex",parameter.PageIndex),
                
            };

            sqlParam = sqlParam.Concat(param).ToList();

            sqlParam.Add(ParameterHelper.NewOutParameter("PageCount", SqlDbType.Int));
            sqlParam.Add(ParameterHelper.NewOutParameter("RecordCount", SqlDbType.Int));
            sqlParam.BuildReturnParameter();

            IList<T> result = null;
            //去数据库
            DataSet dataSet = helper.ExecuteFillDataSet(CommandType.StoredProcedure, procName, sqlParam.ToArray<SqlParameter>());

            if (ValidationHelper.IsNotEmptyDataSet(dataSet))
            {
                result = DataConvertHelper.ToList<T>(dataSet.Tables[0], "PageView_RowNo");
            }

            int pageCount = Convert.ToInt32(sqlParam[sqlParam.Count - 3].Value);
            int recordCount = Convert.ToInt32(sqlParam[sqlParam.Count - 2].Value);

            return new PagedList<T>(parameter.PageIndex, parameter.PageSize, pageCount, recordCount, result);
        }

        /// <summary>
        /// 获取字段列表
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="fieldAlias"></param>
        /// <returns></returns>
        private static string GetFields(string[] fields, string[] fieldAlias = null)
        {
            if (fields == null)
            {
                return " * ";
            }

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < fields.Length; i++)
            {
                string field = fields[i];
                builder.AppendFormat(" {0} {1} ,", field, fieldAlias != null ? "AS " + fieldAlias[i] : string.Empty);
            }

            return builder.Remove(builder.Length - 1, 1).ToString();
        }
    }
}
