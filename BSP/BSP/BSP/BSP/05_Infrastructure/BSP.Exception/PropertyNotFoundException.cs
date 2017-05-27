namespace BSP.Exceptions
{
    using System;
    /// <summary>
    /// 属性未发现异常类型
    /// </summary>
    [Serializable]
    public class PropertyNotFoundException : Exception
    {
        /// <summary>
        /// 目标类型名称
        /// </summary>
        public string TargetTypeName { get; private set; }
        /// <summary>
        /// 目标属性名称
        /// </summary>
        public string TargetPropertyName { get; private set; }

        public PropertyNotFoundException(string targetTypeName, string targetPropertyName)
            : base(string.Format("指定类型 '{0}' 中没有找到名称为 '{1}' 的属性", targetTypeName, targetPropertyName))
        {
            this.TargetPropertyName = targetPropertyName;
        }
    }
}
