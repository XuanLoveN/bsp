using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BSP.SqlUtility
{
    public class SqlHelper
    {
        #region 私有字段：数据库连接字符串
        /// <summary>
        /// 数据库连接字符串 暂时为空 
        /// </summary>
        private readonly string _defaultDBConnectionString = string.Empty; 
        #endregion

        #region 公有属性
        public string DefaultDBConnectionString
        {
            get { return _defaultDBConnectionString; }
        } 
        #endregion

        #region 构造函数：判断数据库连接字符串是否为空
        /// <summary>
        /// 初始化数据库操作辅助类
        /// </summary>
        /// <param name="connectionStringKey"></param>
        public SqlHelper(string connectionStringKey)
        {
            if (string.IsNullOrEmpty(connectionStringKey))
            {
                throw new ArgumentNullException("数据库连接字符串键不能为空");
            }
            this._defaultDBConnectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;
            if (string.IsNullOrEmpty(this._defaultDBConnectionString))
            {
                throw new ArgumentNullException("数据库连接字符串配置不能为空，或连接字符串键错误");
            }
        } 
        #endregion

        #region 公开函数：实行数据库非查询类操作
        /// <summary>
        /// 执行数据库非查询类操作
        /// </summary>
        /// <param name="commandType">数据库操作类型</param>
        /// <param name="commandText">数据库操作语句</param>
        /// <param name="commandParameters">数据库操作参数</param>
        /// <returns>数据库操作影响行数</returns>
        public int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = new SqlConnection(this._defaultDBConnectionString))
            {
                SqlCommand command = new SqlCommand();
                try
                {
                    PrepareCommand(command, connection, commandType, commandText, commandParameters);
                    int val = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    return val;
                }
                catch (Exception)
                {

                    throw;
                }
                finally { connection.Close(); }
            }
        }
        private SqlCommand GetCommand(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand();
            PrepareCommand(command, connection, commandType, commandText, commandParameters);
            return command;
        }
        /// <summary>
        /// 执行数据库查询并返回数据库读取对象
        /// </summary>
        /// <param name="commandType">数据库操作类型</param>
        /// <param name="commandText">数据库操作语句</param>
        /// <param name="commandParameters">数据库操作参数</param>
        /// <returns>数据库读取对象</returns>
        
        public SqlDataReader ExecuteReader(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlConnection connection = new SqlConnection(this._defaultDBConnectionString);
            SqlCommand command = new SqlCommand();

            try
            {
                PrepareCommand(command, connection, commandType, commandText, commandParameters);
                SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();
                return rdr;
            }
            catch 
            {
                connection.Close();
                throw;
            }
        }
        /// <summary>
        /// 执行数据库操作并返回首个结果对象
        /// </summary>
        /// <param name="commandType">数据库操作类型</param>
        /// <param name="commandText">数据库操作语句</param>
        /// <param name="commandParameters">数据库操作参数</param>
        /// <returns>首个结果对象</returns>
        public object ExecuteScalar(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = new SqlConnection(this._defaultDBConnectionString))
            {
                SqlCommand command = new SqlCommand();
                try
                {
                    PrepareCommand(command, connection, commandType, commandText, commandParameters);
                    object val = command.ExecuteScalar();
                    command.Parameters.Clear();
                    return val;
                }
                catch
                {
                    throw;
                }
                finally { connection.Close(); }
            }
        }
        /// <summary>
        /// 执行数据集填充
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public DataSet ExecuteFillDataSet(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(this._defaultDBConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    PrepareCommand(command, connection, commandType, commandText, commandParameters);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataSet);
                    command.Parameters.Clear();
                    return dataSet;
                }
                catch 
                {
                    throw;
                }
            }
        }
        #endregion

        #region 私有函数：预处理数据库操作对象
        /// <summary>
        /// 预处理数据库操作对象
        /// </summary>
        /// <param name="command">数据库操作对象</param>
        /// <param name="connection">数据库连接对象</param>
        /// <param name="commandType">数据库操作类型</param>
        /// <param name="commandText">数据库操作语句</param>
        /// <param name="parameters">数据库操作参数数组</param>
        private void PrepareCommand(SqlCommand command, SqlConnection connection, CommandType commandType, string commandText, SqlParameter[] parameters)
        {
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch { throw; }
            }
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter != null)
                    {
                        command.Parameters.Add(parameter);
                    }
                }
            }

        } 
        #endregion
    }
}
