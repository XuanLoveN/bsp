
namespace BSP.Mvc.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 截断字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="length">截断长度，默认：20</param>
        /// <param name="linkUrl">跳转地址</param>
        /// <returns></returns>
        public static string CutString(this string source, int length = 20, string linkUrl = null)
        {
            string tag = string.Empty;
            if (!string.IsNullOrEmpty(linkUrl))
            {
                tag = string.Format("<a href='{0}'>[...]</a>", linkUrl);
            }

            return source.Length <= length ? source : source.Substring(0, length) + tag;
        }
    }
    
}

