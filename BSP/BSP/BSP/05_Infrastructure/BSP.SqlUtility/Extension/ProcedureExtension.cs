namespace BSP.SqlUtility
{
    using BSP.Core.Helper;
    using BSP.SqlUtility.Helper;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// 存储过程帮助类
    /// </summary>
    public static class ProcedureExtension
    {
        /// <summary>
        /// 执行存储过程无任何返回值
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="procName"></param>
        /// <param name="param"></param>
        public static void RunProc(this SqlHelper helper, string procName, params SqlParameter[] param)
        {
            helper.ExecuteNonQuery(CommandType.StoredProcedure, procName, param);
        }

        /// <summary>
        /// 执行存储过程并获取第一行的数据转换为对象
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="helper">数据库操作辅助类</param>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">数据库操作参数列表</param>
        /// <returns></returns>
        public static T RunProcForObject<T>(this SqlHelper helper, string procName, params SqlParameter[] param)
        {
            DataSet dataSet = RunProcForDataset(helper, procName, param);

            if (ValidationHelper.IsNotEmptyDataSet(dataSet))
            {
                return DataConvertHelper.ToObject<T>(dataSet.Tables[0].Rows[0]);
            }

            return default(T);
        }

        /// <summary>
        /// 执行存储过程返回数据表对象并转换为集合
        /// </summary>
        /// <typeparam name="T">目标集合限定类型</typeparam>
        /// <param name="helper">数据库操作辅助类</param>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">数据库操作参数列表</param>
        /// <returns></returns>
        public static IList<T> RunProcForList<T>(this SqlHelper helper, string procName, params SqlParameter[] param)
        {
            DataSet dataSet = RunProcForDataset(helper, procName, param);

            if (ValidationHelper.IsNotEmptyDataSet(dataSet))
            {
                return DataConvertHelper.ToList<T>(dataSet.Tables[0]);
            }

            return null;
        }

        /// <summary>
        /// 执行存储过程返回数据集
        /// </summary>
        /// <param name="helper">数据库操作辅助类</param>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">数据库操作参数列表</param>
        /// <returns></returns>
        public static DataSet RunProcForDataset(this SqlHelper helper, string procName, params SqlParameter[] param)
        {
            return helper.ExecuteFillDataSet(CommandType.StoredProcedure, procName, param);
        }
    }
}
