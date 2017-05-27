
namespace BSP.Exceptions
{
    /// <summary>
    /// 加载扩展正则表达式异常类型
    /// </summary>
    public class LoadExtendsPatternException : System.Exception
    {
        public LoadExtendsPatternException(string message, System.Exception innerException, string filePath)
            : base(message, innerException)
        {
            this.FilePath = filePath;
        }

        /// <summary>
        /// 加载文件路径
        /// </summary>
        public string FilePath { get; set; }
    }
}
