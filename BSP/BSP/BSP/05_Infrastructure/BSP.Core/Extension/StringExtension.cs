namespace BSP.Core.Extension
{
    using BSP.Core.Helper;

    /// <summary>
    /// 字符串扩展类型
    /// </summary>
    public static class StringExtension
    {
        #region 加密解密部分
        /// <summary>
        /// 将字符串转换为MD5加密字符串
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string ToMD5(this string sourceString)
        {
            return Cryptography.ToMD5(sourceString);
        }

        /// <summary>
        /// 将字符串以AES算法加密(使用系统统一AES加(解)密密钥)
        /// </summary>
        /// <param name="sourceString">原始字符串</param>
        /// <returns></returns>
        public static string EncryptToAES(this string sourceString)
        {
            return Cryptography.EncryptToAES(sourceString);
        }

        /// <summary>
        /// 将字符串以AES算法加密
        /// </summary>
        /// <param name="sourceString">原始字符串</param>
        /// <param name="aesKey">AES加(解)密密钥</param>
        /// <returns></returns>
        public static string EncryptToAES(this string sourceString, string aesKey)
        {
            return Cryptography.EncryptToAES(sourceString, aesKey);
        }

        /// <summary>
        /// 将AES加密后的字符串转换为明文字符串(使用系统统一AES加(解)密密钥)
        /// </summary>
        /// <param name="sourceString">加密字符串</param>
        /// <returns></returns>
        public static string DecryptToAES(this string sourceString)
        {
            return Cryptography.DecryptToAES(sourceString);
        }

        /// <summary>
        /// 将AES加密后的字符串转换为明文字符串
        /// </summary>
        /// <param name="sourceString">加密字符串</param>
        /// <param name="aesKey">AES加(解)密密钥</param>
        /// <returns></returns>
        public static string DecryptToAES(this string sourceString, string aesKey)
        {
            return Cryptography.DecryptToAES(sourceString, aesKey);
        }
        #endregion

        #region 验证部分
        /// <summary>
        /// 是否是IP地址格式
        /// </summary>
        /// <param name="sourceString">待验证字符串</param>
        /// <returns></returns>
        public static bool IsIPV4Address(this string sourceString)
        {
            return ValidationHelper.IsIPV4Address(sourceString);
        }
        #endregion

        #region 转换部分
        /// <summary>
        /// 转换为Int32类型
        /// </summary>
        /// <param name="sourceString">原始字符串</param>
        /// <param name="defaultValue">默认返回值(默认为：0)</param>
        /// <returns></returns>
        public static int ToInt32(this string sourceString, int defaultValue = 0)
        {
            int result = 0;

            if (!int.TryParse(sourceString, out result))
            {
                return defaultValue;
            }

            return result;
        }
        #endregion

        #region 过滤部分
        /// <summary>
        /// 过滤SQL注入字符
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string FilterSQLInjectWords(this string sourceString)
        {
            return TextUtility.FilterSQLInjectWords(sourceString);
        }
        #endregion
    }
}
