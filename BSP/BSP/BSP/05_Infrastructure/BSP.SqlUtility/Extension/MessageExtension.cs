namespace BSP.SqlUtility
{
    using BSP.Core.Extension;
    using BSP.Core.Helper;
    using BSP.Model;
    using BSP.SqlUtility.Helper;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    /// <summary>
    /// 消息扩展类
    /// </summary>
    public static class MessageExtension
    {
        /// <summary>
        /// 获取未携带任何实体消息的消息对象
        /// </summary>
        /// <param name="helper">数据库操作辅助类对象</param>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">存储过程参数</param>
        /// <returns></returns>
        public static IMessage GetMessage(this SqlHelper helper, string procName, params SqlParameter[] param)
        {
            return GetMessage(helper, procName, new List<SqlParameter>(param), includeError: true);
        }

        /// <summary>
        /// 获取未携带任何实体消息的消息对象
        /// </summary>
        /// <param name="helper">数据库操作辅助类对象</param>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">存储过程参数</param>
        /// <param name="includeError">是否包括错误返回值</param>
        /// <returns></returns>
        public static IMessage GetMessage(this SqlHelper helper, string procName, IList<SqlParameter> param, bool includeError = true)
        {
            if (includeError)
            {
                param.BuildErrorParameter();
            }
            param.BuildReturnParameter();
            helper.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, procName, param.ToArray<SqlParameter>());
            return new Message(param[param.Count - 1].Value.ToString().ToInt32(), param[param.Count - 2].Value.ToString());
        }

        /// <summary>
        /// 获取消息并携带单个实体对象
        /// </summary>
        /// <typeparam name="T">目标实体类型</typeparam>
        /// <param name="helper">数据库操作辅助类对象</param>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">存储过程参数</param>
        /// <returns></returns>
        public static IMessage<T> GetMessageForObject<T>(this SqlHelper helper, string procName, params SqlParameter[] param)
        {
            return GetMessageForObject<T>(helper, procName, new List<SqlParameter>(param), includeError: true);
        }

        /// <summary>
        /// 获取消息并携带单个实体对象
        /// </summary>
        /// <typeparam name="T">目标实体类型</typeparam>
        /// <param name="helper">数据库操作辅助类对象</param>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">存储过程参数</param>
        /// <param name="includeError">是否包括错误返回值</param>
        /// <returns></returns>
        public static IMessage<T> GetMessageForObject<T>(this SqlHelper helper, string procName, IList<SqlParameter> param, bool includeError = true)
        {
            if (includeError)
            {
                param.BuildErrorParameter();
            }
            param.BuildReturnParameter();
            DataSet dataSet = helper.ExecuteFillDataSet(CommandType.StoredProcedure, procName, param.ToArray<SqlParameter>());

            if (!ValidationHelper.IsNotEmptyDataSet(dataSet))
            {
                return new Message<T>(param[param.Count - 1].Value.ToString().ToInt32(), param[param.Count - 2].Value.ToString(), default(T));
            }

            return new Message<T>(param[param.Count - 1].Value.ToString().ToInt32(), param[param.Count - 2].Value.ToString(), DataConvertHelper.ToObject<T>(dataSet.Tables[0].Rows[0]));
        }

        /// <summary>
        /// 获取消息对象并携带集合对象
        /// </summary>
        /// <typeparam name="T">目标实体类型</typeparam>
        /// <param name="helper">数据库操作辅助类对象</param>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">存储过程参数</param>
        /// <returns></returns>
        public static IMessage<IList<T>> GetMessageForList<T>(this SqlHelper helper, string procName, params SqlParameter[] param)
        {
            return GetMessageForList<T>(helper, procName, new List<SqlParameter>(param), includeError: true);
        }

        /// <summary>
        /// 获取消息对象并携带集合对象
        /// </summary>
        /// <typeparam name="T">目标实体类型</typeparam>
        /// <param name="helper">数据库操作辅助类对象</param>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">存储过程参数</param>
        /// <param name="includeError">是否包括错误返回值</param>
        /// <returns></returns>
        public static IMessage<IList<T>> GetMessageForList<T>(this SqlHelper helper, string procName, IList<SqlParameter> param, bool includeError = true)
        {
            if (includeError)
            {
                param.BuildErrorParameter();
            }
            param.BuildReturnParameter();
            DataSet dataSet = helper.ExecuteFillDataSet(CommandType.StoredProcedure, procName, param.ToArray<SqlParameter>());

            if (!ValidationHelper.IsNotEmptyDataSet(dataSet))
            {
                return new Message<IList<T>>(param[param.Count - 1].Value.ToString().ToInt32(), param[param.Count - 2].Value.ToString(), default(IList<T>));
            }

            return new Message<IList<T>>(param[param.Count - 1].Value.ToString().ToInt32(), param[param.Count - 2].Value.ToString(), DataConvertHelper.ToList<T>(dataSet.Tables[0]));
        }
    }
}
