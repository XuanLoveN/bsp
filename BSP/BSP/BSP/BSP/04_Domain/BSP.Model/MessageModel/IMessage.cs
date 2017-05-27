namespace BSP.Model
{
    /// <summary>
    /// 数据库执行反馈消息类型接口
    /// </summary>
    /// <typeparam name="T">消息携带对象类型</typeparam>
    public interface IMessage<T> : IMessage
    {
        /// <summary>
        /// 默认携带对象
        /// </summary>
        T Entity { get; }
    }

    /// <summary>
    /// 数据库执行反馈消息类型接口
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// 消息编号
        /// </summary>
        int MessageID { get; }

        /// <summary>
        /// 执行是否成功
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// 消息主体
        /// </summary>
        string Content { get; }
    }
}
