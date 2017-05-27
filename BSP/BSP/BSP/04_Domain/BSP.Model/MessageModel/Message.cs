namespace BSP.Model
{
    /// <summary>
    /// 基础消息类型
    /// </summary>
    public class Message : IMessage
    {

        /// <summary>
        /// 成功标识
        /// </summary>
        private const int SuccessFlag = 0;
        private int _messageId;
        private string _content;

        public Message(int messageId, string content)
        {
            _messageId = messageId;
            _content = content;
        }

        /// <summary>
        /// 构建错误消息对象
        /// </summary>
        public static IMessage ErrorMessage
        {
            get
            {
                return new Message(-1, string.Empty);
            }
        }

        /// <summary>
        /// 消息编号
        /// </summary>
        public int MessageID
        {
            get
            {
                return _messageId;
            }
        }

        /// <summary>
        /// 执行是否成功
        /// </summary>
        public bool Success
        {
            get
            {
                return _messageId == SuccessFlag;
            }
        }

        /// <summary>
        /// 消息主体
        /// </summary>
        public string Content
        {
            get
            {
                return _content;
            }
        }
    }
}
