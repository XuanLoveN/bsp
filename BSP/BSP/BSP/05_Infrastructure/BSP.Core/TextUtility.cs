namespace BSP.Core
{
    using System;
    using System.Security.Cryptography;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 文本工具类
    /// </summary>
    public sealed class TextUtility
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length">目标字符串的长度</param>
        /// <param name="useNum">是否包含数字</param>
        /// <param name="useLow">是否包含小写字母</param>
        /// <param name="useUpp">是否包含大写字母</param>
        /// <param name="useSpe">是否包含特殊字符</param>
        /// <param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        /// <returns>指定长度的随机字符串</returns>
        public static string GetRandomString(int length, bool useNum = true, bool useLow = false, bool useUpp = false, bool useSpe = false, string custom = "")
        {
            byte[] buffer = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(buffer);
            Random rand = new Random(BitConverter.ToInt32(buffer, 0));
            string result = null, str = custom;

            if (useNum) { str += "0123456789"; }
            if (useLow) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }

            for (int i = 0; i < length; i++) { result += str.Substring(rand.Next(0, str.Length - 1), 1); }

            return result;
        }

        /// <summary>
        /// 替换标签中的HTML元素
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string ReplaceHtmlTags(string html)
        {
            html = ReplaceTextWithPatten("&#[^>]*;", "", html);
            html = ReplaceTextWithPatten("</?marquee[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?object[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?param[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?embed[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?table[^>]*>", "", html);
            html = ReplaceTextWithPatten("&nbsp;", "", html);
            html = ReplaceTextWithPatten("</?tr[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?th[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?p[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?a[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?img[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?tbody[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?li[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?span[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?div[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?th[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?td[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?script[^>]*>", "", html);
            html = ReplaceTextWithPatten("(javascript|jscript|vbscript|vbs):", "", html);
            html = ReplaceTextWithPatten("on(mouse|exit|error|click|key)", "", html);
            html = ReplaceTextWithPatten("<\\?xml[^>]*>", "", html);
            html = ReplaceTextWithPatten("<\\/?[a-z]+:[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?font[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?b[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?u[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?i[^>]*>", "", html);
            html = ReplaceTextWithPatten("</?strong[^>]*>", "", html);
            string clearHtml = html;
            return clearHtml;
        }

        /// <summary>
        /// 清除文本中的Html标签
        /// </summary>
        /// <param name="patrn">要替换的标签正则表达式</param>
        /// <param name="strRep">替换为的内容</param>
        /// <param name="content">要替换的内容</param>
        /// <returns></returns>
        public static string ReplaceTextWithPatten(string patrn, string strRep, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                content = "";
            }
            Regex rgEx = new Regex(patrn, RegexOptions.IgnoreCase);
            string strTxt = rgEx.Replace(content, strRep);
            return strTxt;
        }

        /// <summary>
        /// 过滤SQL注入攻击的字符串和符号
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>true:没有恶意字符串，false:含有恶意字符串</returns>
        public static string FilterSQLInjectWords(string str)
        {
            string parttenKeyword = @"^[select|insert|delete|from|count\(|drop|update|truncate|asc\(|min\(|char\(|xp_cmdshell|exec|master|local|group|administrator|:|net user|and|or]$";
            string parttenOperater = @"^[-|;|,|\/|\(|\)|\[|\]|\{|\}|%|@|\*|!|\']$";

            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            //return !Regex.IsMatch(str, parttenKeyword, RegexOptions.IgnoreCase) && !Regex.IsMatch(str, parttenOperater);

            str = Regex.Replace(str, parttenKeyword, "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, parttenOperater, "", RegexOptions.IgnoreCase);

            return str;
        }
    }
}
