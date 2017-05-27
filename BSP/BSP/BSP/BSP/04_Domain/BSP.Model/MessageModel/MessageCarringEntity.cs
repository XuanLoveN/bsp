namespace BSP.Model
{
    /// <summary>
    /// 携带对象消息类型
    /// </summary>
    /// <typeparam name="T">携带对象类型</typeparam>
    public class Message<T> : Message, IMessage<T>
    {
        private T _entity = default(T);



        public Message(int messageId, string content, T entity)
            : base(messageId, content)
        {
            _entity = entity;
        }

        /// <summary>
        /// 构建错误消息对象
        /// </summary>
        public static new IMessage<T> ErrorMessage
        {
            get
            {
                return new Message<T>(-1, string.Empty, default(T));
            }
        }

        /// <summary>
        /// 携带实体对象
        /// </summary>
        public T Entity
        {
            get
            {
                return _entity;
            }
        }
    }
}
