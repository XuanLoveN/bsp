using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSP.Helper
{
    /// <summary>
    /// 类型转换帮助类
    /// </summary>
    public sealed class DataTypeHelper
    {
        /// <summary>
        /// 调整对象类型
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="value">转换值</param>
        /// <returns></returns>
        public static T ChangeType<T>(object value)
        {
            object returnVal = ChangeType(typeof(T),value);
            if (returnVal == null)
            {
                return default(T);
            }
            return (T)returnVal;
        }
        /// <summary>
        /// 调整对象类型
        /// </summary>
        /// <param name="targetType">目标类型</param>
        /// <param name="val">转换值</param>
        /// <returns></returns>
        public static object  ChangeType(Type targetType, object val)
        {
            if (val == null || (targetType.IsGenericType && string.IsNullOrEmpty(val.ToString()))) return null;
            if (targetType == val.GetType()||targetType.IsGenericType)
            {
                return val;
            }
            if (targetType == typeof(bool))
            {
                return (val.ToString() != "0" || string.Equals(val.ToString(), "true", StringComparison.CurrentCultureIgnoreCase));
            }
            if (targetType.IsEnum)
            {
                int result = 0;
                if (!int.TryParse(val.ToString(),out result))
                {
                    return Enum.Parse(targetType,val.ToString());
                }
                return val;
            }
            if (targetType==typeof(Type))
            {
                return ReflectionHelper.GetType(val.ToString());
            }
            return Convert.ChangeType(val, targetType);
        }
        /// <summary>
        /// 验证指定类型是否为数值类型
        /// </summary>
        /// <param name="destDataType">目标数据类型</param>
        /// <returns></returns>
        public static bool IsNumbericType(Type destDataType)
        {
            return ((((((destDataType == typeof(int)) || (destDataType == typeof(uint))) || ((destDataType == typeof(double)) || (destDataType == typeof(short)))) || (((destDataType == typeof(ushort)) || (destDataType == typeof(decimal))) || ((destDataType == typeof(long)) || (destDataType == typeof(ulong))))) || ((destDataType == typeof(float)) || (destDataType == typeof(byte)))) || (destDataType == typeof(sbyte)));
        }
    }
}
