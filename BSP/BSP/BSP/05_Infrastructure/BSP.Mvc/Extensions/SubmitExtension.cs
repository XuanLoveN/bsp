using System.Collections.Generic;
using System.Web.Mvc;

namespace BSP.Mvc.Extensions
{
    /// <summary>
    /// 提交按钮扩展类型
    /// </summary>
    public static class SubmitExtension
    {
        /// <summary>
        /// 生成提交按钮
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="text"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString Submit(this HtmlHelper helper, string text, object htmlAttributes = null)
        {
            TagBuilder builder = new TagBuilder("button");
            builder.MergeAttribute("type", "submit");
            //附加html属性
            var extAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>;
            builder.MergeAttributes<string, object>(extAttributes);
            //追加内部文本
            builder.SetInnerText(text);

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}
