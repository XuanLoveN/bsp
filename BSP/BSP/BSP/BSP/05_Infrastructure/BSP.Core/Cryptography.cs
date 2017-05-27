using BSP.Core.Helper;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BSP.Core
{
    /// <summary>
    /// 加密工具类
    /// </summary>
    public sealed class Cryptography
    {
        /// <summary>
        /// AES加密向量(IV)值
        /// </summary>
        private static readonly string IV = AppSettingHelper.Get(SettingKeys.Cryptography_AES_IV);
        /// <summary>
        /// AES加密密钥
        /// </summary>
        private static readonly string AES_KEY = AppSettingHelper.Get(SettingKeys.Cryptography_AES_KEY);

        /// <summary>
        /// 将字符串转换为MD5加密格式字符串
        /// </summary>
        /// <param name="sourceString">原始字符串</param>
        /// <returns></returns>
        public static string ToMD5(string sourceString)
        {
            if (string.IsNullOrEmpty(sourceString))
            {
                return string.Empty;
            }
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] md5Data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(sourceString));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < md5Data.Length; i++)
            {
                builder.Append(md5Data[i].ToString("X2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// AES加密算法(使用系统统一AES密钥解密)
        /// </summary>
        /// <param name="sourceString">原始字符串</param>
        /// <returns></returns>
        public static string EncryptToAES(string sourceString)
        {
            if (string.IsNullOrEmpty(AES_KEY))
            {
                throw new ArgumentNullException("加(解)密密钥没有配置");
            }

            return EncryptToAES(sourceString, AES_KEY);
        }

        /// <summary>
        /// AES加密算法
        /// </summary>
        /// <param name="sourceString">原始字符串</param>
        /// <param name="aesKey">AES密钥</param>
        /// <returns></returns>
        public static string EncryptToAES(string sourceString, string aesKey)
        {
            if (string.IsNullOrEmpty(aesKey))
            {
                throw new ArgumentNullException("请传入AES加(解)密密钥");
            }

            if (string.IsNullOrEmpty(IV))
            {
                throw new ArgumentException("AES加(解)密向量值未配置");
            }

            aesKey = aesKey.PadRight(32, ' ');
            ICryptoTransform transform = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(aesKey.Substring(0, 32)),
                IV = Encoding.Default.GetBytes(IV)
            }.CreateEncryptor();
            byte[] bytes = Encoding.UTF8.GetBytes(sourceString);
            return Convert.ToBase64String(transform.TransformFinalBlock(bytes, 0, bytes.Length));
        }

        /// <summary>
        /// AES解密算法(使用系统统一AES密钥解密)
        /// </summary>
        /// <param name="sourceString">加密字符串</param>
        /// <returns></returns>
        public static string DecryptToAES(string sourceString)
        {
            if (string.IsNullOrEmpty(AES_KEY))
            {
                throw new ArgumentNullException("加(解)密密钥没有配置");
            }

            return DecryptToAES(sourceString, AES_KEY);
        }

        /// <summary>
        /// AES解密算法
        /// </summary>
        /// <param name="sourceString">加密字符串</param>
        /// <param name="aesKey">AES密钥</param>
        /// <returns>解密后的字符串</returns>
        public static string DecryptToAES(string sourceString, string aesKey)
        {
            if (string.IsNullOrEmpty(aesKey))
            {
                throw new ArgumentNullException("请传入AES加(解)密密钥");
            }

            if (string.IsNullOrEmpty(IV))
            {
                throw new ArgumentException("AES加(解)密向量值未配置");
            }

            try
            {
                aesKey = aesKey.PadRight(32, ' ');
                ICryptoTransform transform = new RijndaelManaged
                {
                    Key = Encoding.UTF8.GetBytes(aesKey),
                    IV = Encoding.Default.GetBytes(IV)
                }.CreateDecryptor();
                byte[] inputBuffer = Convert.FromBase64String(sourceString);
                byte[] bytes = transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                return Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return "";
            }
        }
    }
}
