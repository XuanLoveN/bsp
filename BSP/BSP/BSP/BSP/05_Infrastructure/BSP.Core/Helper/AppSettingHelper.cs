using BSP.Helper;
using System.Configuration;

namespace BSP.Core.Helper
{
    public class AppSettingHelper
    {
        /// <summary>
        /// 获取指定类型配置信息，并转换为指定类型
        /// </summary>
        /// <typeparam name="T">需要转换的类型</typeparam>
        /// <param name="key">配置键</param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            string setting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(setting))
            {
                return default(T);
            }
            return (T)DataTypeHelper.ChangeType(typeof(T),setting);
        }
        /// <summary>
        /// 获取指定类型配置信息
        /// </summary>
        /// <param name="key">配置键</param>
        /// <returns></returns>
        public static string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
