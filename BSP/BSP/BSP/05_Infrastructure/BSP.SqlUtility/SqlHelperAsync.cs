using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace BSP.SqlUtility
{
    public class SqlHelperAsync:SqlHelper
    {
        public SqlHelperAsync(string connectionStrionStringKey) : base(connectionStrionStringKey) { }
        #region 公开函数
        /// <summary>
        /// 执行数据库非查询类操作
        /// </summary>
        /// <param name="commandType">数据库操作类型</param>
        /// <param name="commandtext">数据库操作语句</param>
        /// <param name="commandParameters">数据库操作参数</param>
        /// <returns>数据库操作影响行数</returns>
        public async Task<int> ExecuteNonQueryAsync(CommandType commandType, string commandtext, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = new SqlConnection(DefaultDBConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        await connection.OpenAsync(CancellationToken.None);
                    }
                    catch
                    {
                        throw;
                    }
                }
                else if (connection.State == ConnectionState.Broken)
                {
                    try
                    {
                        connection.Close();
                        await connection.OpenAsync();
                    }
                    catch
                    {
                        throw;
                    }

                }
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = commandtext;
                command.CommandType = commandType;

                if (commandParameters != null)
                {
                    foreach (SqlParameter parameter in commandParameters)
                    {
                        if (parameter != null)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                }
                try
                {
                    int val = await command.ExecuteNonQueryAsync(new CancellationToken());
                    command.Parameters.Clear();
                    return await Task.FromResult<int>(val);
                }
                catch
                {
                    throw;
                }
                finally { connection.Close(); }
            }
        } 
        #endregion
    }
}
