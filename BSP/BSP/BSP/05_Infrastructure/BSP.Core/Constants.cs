using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSP.Core
{
    /// <summary>
    /// 系统设置键集
    /// </summary>
    internal sealed class SettingKeys
    {
        #region 加密配置部分
        /// <summary>
        /// AES加密向量(IV)值
        /// </summary>
        public const string Cryptography_AES_IV = "BSP.Cryptography.AES_IV";

        /// <summary>
        /// AES加密密钥
        /// </summary>
        public const string Cryptography_AES_KEY = "BSP.Cryptography.AES_KEY";
        #endregion
        #region 缓存配置部分
        /// <summary>
        /// 内存缓存超时时间
        /// </summary>
        public const string Cache_MemoryCacheExprise = "BSP.Cache.MemoryCacheExprise";

        /// <summary>
        /// Cookie缓存超时时间
        /// </summary>
        public const string Cache_CookieCacheExprise = "BSP.Cache.CookieCacheExprise";
        #endregion
    }
}
