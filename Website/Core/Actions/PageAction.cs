using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CommunicatorCms.Core.Actions
{
    public class PageAction
    {
        public static string GetContentUrl { get; } = "/Actions/Get/Page/Content.cshtml";
        public static string GetNavigationUrl { get; set; } = "/Actions/Get/Page/Navigation.cshtml";

        public static string PageUrlParameter { get; set; } = "PagePath";

        public static string NavigationDepthParameter { get; set; } = "Depth";
        public static string NavigationRootPageUrlParameter { get; set; } = "RootPagePath";
        public static string NavigationOnlyVisibleParameter { get; set; } = "OnlyVisible";

        public static string GetContentRelativeUrl(string pageUrl) 
        {
            return GetContentUrl + "?" + PageUrlParameter + "=" + pageUrl;
        }
        public static string GetContentAbsoluteUrl(string pageUrl, HttpRequest httpRequest)
        {
            return ActionHelper.AbsoluteUrl(GetContentRelativeUrl(pageUrl), httpRequest);
        }
        public static async Task<HttpResponseMessage> GetContent(string pagePath, HttpRequest httpRequest, HttpClient httpClient)
        {
            return await httpClient.GetAsync(GetContentAbsoluteUrl(pagePath, httpRequest));
        }

        public static string GetNavigationRelativeUrl(string pageUrl, string? rootPageUrl = null, bool onlyVisible = false, int depth = -1) 
        {
            var parametersAndValues = new Dictionary<string, object>();
            parametersAndValues.Add(PageUrlParameter, pageUrl);
            parametersAndValues.Add(NavigationOnlyVisibleParameter, onlyVisible);
            parametersAndValues.Add(NavigationDepthParameter, depth);

            if (rootPageUrl != null) 
            {
                parametersAndValues.Add(NavigationRootPageUrlParameter, rootPageUrl);
            }

            return GetNavigationUrl + ActionHelper.GetParameterString(parametersAndValues);
        }
        public static string GetNavigationAbsoluteUrl(string pageUrl, HttpRequest httpRequest, string? rootPageUrl = null, bool onlyVisible = false, int depth = -1)
        {
            return ActionHelper.AbsoluteUrl(GetNavigationRelativeUrl(pageUrl, rootPageUrl, onlyVisible, depth), httpRequest);
        }
        public static async Task<HttpResponseMessage> GetNavigation(string pageUrl, HttpRequest httpRequest, HttpClient httpClient, string? rootPageUrl = null, bool onlyVisible = false, int depth = -1)
        {
            return await httpClient.GetAsync(GetNavigationAbsoluteUrl(pageUrl, httpRequest, rootPageUrl, onlyVisible, depth));
        }

    }
}
