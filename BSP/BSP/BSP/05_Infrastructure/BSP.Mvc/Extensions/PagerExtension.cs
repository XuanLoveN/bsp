using BSP.Model;
using System;
using System.Text;
using System.Web.Mvc;

namespace BSP.Mvc.Extensions
{
    /// <summary>
    /// 分页扩展类
    /// </summary>
    public static class PagerExtension
    {
        private static readonly int _pageNumberCount = 10;

        /// <summary>
        /// 呈现分页控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="model"></param>
        /// <param name="generateUrl"></param>
        /// <returns></returns>
        public static MvcHtmlString RenderPager(this HtmlHelper helper, IPagedBase model, Func<int, string> generateUrl)
        {
            StringBuilder resultBuilder = new StringBuilder();

            if (!model.IsNotNull)
            {
                return null;
            }

            TagBuilder navBuilder = new TagBuilder("nav");
            navBuilder.AddCssClass("text-center");
            resultBuilder.Append(navBuilder.ToString(TagRenderMode.StartTag));

            TagBuilder ulBuilder = new TagBuilder("ul");
            ulBuilder.AddCssClass("pagination no-margin");
            resultBuilder.Append(ulBuilder.ToString(TagRenderMode.StartTag));

            TagBuilder liBuilder = new TagBuilder("li");
            resultBuilder.Append(liBuilder.ToString(TagRenderMode.StartTag));

            TagBuilder aBuilder = new TagBuilder("a");
            aBuilder.Attributes.Add("href", generateUrl(1));
            aBuilder.Attributes.Add("aria-label", "首页");
            aBuilder.InnerHtml = "&laquo;";
            resultBuilder.Append(aBuilder.ToString());
            resultBuilder.Append(liBuilder.ToString(TagRenderMode.EndTag));

            if (model.HasPreviewPage)
            {
                resultBuilder.Append(liBuilder.ToString(TagRenderMode.StartTag));
                aBuilder = new TagBuilder("a");
                aBuilder.Attributes.Add("href", generateUrl(model.PageIndex - 1));
                aBuilder.Attributes.Add("aria-label", "上一页");
                aBuilder.InnerHtml = "&lt;";
                resultBuilder.Append(aBuilder.ToString());
                resultBuilder.Append(liBuilder.ToString(TagRenderMode.EndTag));
            }

            int firstPageIndex = model.PageIndex / _pageNumberCount * _pageNumberCount + 1;
            int lastPageIndex = (model.PageIndex / _pageNumberCount + 1) * _pageNumberCount;

            if (lastPageIndex > model.PageCount)
            {
                lastPageIndex = model.PageCount;
            }

            for (int i = firstPageIndex; i <= lastPageIndex; i++)
            {
                liBuilder = new TagBuilder("li");
                if (i == model.PageIndex)
                {
                    liBuilder.AddCssClass("active");
                }

                resultBuilder.Append(liBuilder.ToString(TagRenderMode.StartTag));
                aBuilder = new TagBuilder("a");
                aBuilder.Attributes.Add("href", generateUrl(i));
                aBuilder.Attributes.Add("aria-label", "上一页");
                aBuilder.InnerHtml = i.ToString();
                resultBuilder.Append(aBuilder.ToString());
                resultBuilder.Append(liBuilder.ToString(TagRenderMode.EndTag));
            }

            liBuilder = new TagBuilder("li");
            if (model.HasNextPage)
            {
                resultBuilder.Append(liBuilder.ToString(TagRenderMode.StartTag));
                aBuilder = new TagBuilder("a");
                aBuilder.Attributes.Add("href", generateUrl(model.PageIndex + 1));
                aBuilder.Attributes.Add("aria-label", "下一页");
                aBuilder.InnerHtml = "&gt;";
                resultBuilder.Append(aBuilder.ToString());
                resultBuilder.Append(liBuilder.ToString(TagRenderMode.EndTag));
            }

            resultBuilder.Append(liBuilder.ToString(TagRenderMode.StartTag));
            aBuilder = new TagBuilder("a");
            aBuilder.Attributes.Add("href", generateUrl(model.PageCount));
            aBuilder.Attributes.Add("aria-label", "末页");
            aBuilder.InnerHtml = "&raquo;";
            resultBuilder.Append(aBuilder.ToString());
            resultBuilder.Append(liBuilder.ToString(TagRenderMode.EndTag));

            return new MvcHtmlString(resultBuilder.ToString());
        }

        /// <summary>
        /// 呈现分页控件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="model"></param>
        /// <param name="generateUrl"></param>
        /// <returns></returns>
        public static MvcHtmlString RenderPager(this HtmlHelper helper, IPagedBase model, string functionName)
        {
            StringBuilder resultBuilder = new StringBuilder();
            string functionFormat = functionName + "({0});";

            if (!model.IsNotNull)
            {
                return null;
            }

            TagBuilder navBuilder = new TagBuilder("nav");
            navBuilder.AddCssClass("text-center");
            resultBuilder.Append(navBuilder.ToString(TagRenderMode.StartTag));

            TagBuilder ulBuilder = new TagBuilder("ul");
            ulBuilder.AddCssClass("pagination no-margin");
            resultBuilder.Append(ulBuilder.ToString(TagRenderMode.StartTag));

            TagBuilder liBuilder = new TagBuilder("li");
            resultBuilder.Append(liBuilder.ToString(TagRenderMode.StartTag));

            TagBuilder aBuilder = new TagBuilder("a");
            aBuilder.Attributes.Add("href", "javascript:void(0);");
            aBuilder.Attributes.Add("onclick", string.Format(functionFormat, 1));
            aBuilder.Attributes.Add("aria-label", "首页");
            aBuilder.InnerHtml = "&laquo;";
            resultBuilder.Append(aBuilder.ToString());
            resultBuilder.Append(liBuilder.ToString(TagRenderMode.EndTag));

            if (model.HasPreviewPage)
            {
                resultBuilder.Append(liBuilder.ToString(TagRenderMode.StartTag));
                aBuilder = new TagBuilder("a");
                aBuilder.Attributes.Add("href", "javascript:void(0);");
                aBuilder.Attributes.Add("onclick", string.Format(functionFormat, model.PageIndex - 1));
                aBuilder.Attributes.Add("aria-label", "上一页");
                aBuilder.InnerHtml = "&lt;";
                resultBuilder.Append(aBuilder.ToString());
                resultBuilder.Append(liBuilder.ToString(TagRenderMode.EndTag));
            }

            int firstPageIndex = model.PageIndex / _pageNumberCount * _pageNumberCount + 1;
            int lastPageIndex = (model.PageIndex / _pageNumberCount + 1) * _pageNumberCount;

            if (lastPageIndex > model.PageCount)
            {
                lastPageIndex = model.PageCount;
            }

            for (int i = firstPageIndex; i <= lastPageIndex; i++)
            {
                liBuilder = new TagBuilder("li");
                if (i == model.PageIndex)
                {
                    liBuilder.AddCssClass("active");
                }

                resultBuilder.Append(liBuilder.ToString(TagRenderMode.StartTag));
                aBuilder = new TagBuilder("a");
                aBuilder.Attributes.Add("href", "javascript:void(0);");
                aBuilder.Attributes.Add("onclick", string.Format(functionFormat, i));
                aBuilder.Attributes.Add("aria-label", "上一页");
                aBuilder.InnerHtml = i.ToString();
                resultBuilder.Append(aBuilder.ToString());
                resultBuilder.Append(liBuilder.ToString(TagRenderMode.EndTag));
            }

            liBuilder = new TagBuilder("li");
            if (model.HasNextPage)
            {
                resultBuilder.Append(liBuilder.ToString(TagRenderMode.StartTag));
                aBuilder = new TagBuilder("a");
                aBuilder.Attributes.Add("href", "javascript:void(0);");
                aBuilder.Attributes.Add("onclick", string.Format(functionFormat, model.PageIndex + 1));
                aBuilder.Attributes.Add("aria-label", "下一页");
                aBuilder.InnerHtml = "&gt;";
                resultBuilder.Append(aBuilder.ToString());
                resultBuilder.Append(liBuilder.ToString(TagRenderMode.EndTag));
            }

            resultBuilder.Append(liBuilder.ToString(TagRenderMode.StartTag));
            aBuilder = new TagBuilder("a");
            aBuilder.Attributes.Add("href", "javascript:void(0);");
            aBuilder.Attributes.Add("onclick", string.Format(functionFormat, model.PageCount));
            aBuilder.Attributes.Add("aria-label", "末页");
            aBuilder.InnerHtml = "&raquo;";
            resultBuilder.Append(aBuilder.ToString());
            resultBuilder.Append(liBuilder.ToString(TagRenderMode.EndTag));
            resultBuilder.Append(ulBuilder.ToString(TagRenderMode.EndTag));
            resultBuilder.Append(navBuilder.ToString(TagRenderMode.EndTag));

            return new MvcHtmlString(resultBuilder.ToString());
        }
    }
}
