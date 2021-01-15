using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunicatorCms.Core.Application.FileSystem;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CommunicatorCms.Core.Extensions
{
    public static class IHtmlHelperExtension
    {
        public static Task RenderPartialAsyncFromUrl(this IHtmlHelper htmlHelper, string url)
        {
            return RenderPartialAsyncFromUrl(htmlHelper, url, null!);
        }
        public static Task RenderPartialAsyncFromUrl(this IHtmlHelper htmlHelper, string url, object model)
        {
            return htmlHelper.RenderPartialAsync(AppUrl.ConvertToAppPath(url), model);
        }

        public static Task RenderActiveOrDefaultAsyncFromUrl(this IHtmlHelper htmlHelper, string activeUrl, string defaultUrl)
        {
            return RenderActiveOrDefaultAsyncFromUrl(htmlHelper, activeUrl, defaultUrl, null!);
        }

        public static Task RenderActiveOrDefaultAsyncFromUrl(this IHtmlHelper htmlHelper, string activeUrl, string defaultUrl, object model)
        {
            if (AppUrl.Exists(activeUrl))
            {
                return htmlHelper.RenderPartialAsyncFromUrl(activeUrl, model);
            }
            else if (AppUrl.Exists(defaultUrl))
            {
                return htmlHelper.RenderPartialAsyncFromUrl(defaultUrl, model);
            }

            return Task.CompletedTask;
        }
    }
}
