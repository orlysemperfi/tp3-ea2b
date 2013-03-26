using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class HelperExtensions
    {
        public static IHtmlString ActionImageLink(this HtmlHelper html, string action, object routeValues, string styleClass, string alt)
        {
            var url = new UrlHelper(html.ViewContext.RequestContext);
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, routeValues));
            anchorBuilder.AddCssClass(styleClass);
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return new HtmlString(anchorHtml);
        }
    }
}