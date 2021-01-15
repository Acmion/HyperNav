using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CommunicatorCms.Core.Extensions;
using CommunicatorCms.Core.Settings;

namespace CommunicatorCms.Core.Application.FileSystem
{
    public static class AppUrl
    {
        public static char Separator = '/';
        public static string SeparatorString = "/";
        public static string[] UnservableStrings = { "/_", "/.", ".cshtml" };

        public static string ConvertToActualUrl(string url)
        {
            url = ConvertAspNetCoreUrlToStandardUrl(url);
            var rootUrl = RootUrl(url);

            if (UrlSettings.NonVirtualRootUrls.Contains(rootUrl))
            {
                return url;
            }

            if (url.StartsWith(UrlSettings.ContentRootUrl))
            {
                var rootUrlPlusOne = RootUrlPlusOne(url);
                if (UrlSettings.NonVirtualContentUrls.Contains(rootUrlPlusOne))
                {
                    return url;
                }
                else if (rootUrlPlusOne != UrlSettings.ContentWwwUrl)
                {
                    return url.ReplaceFirst(UrlSettings.ContentRootUrl, UrlSettings.ContentWwwUrl);
                }
            }
            else
            {
                var contentUrl = Join(UrlSettings.ContentRootUrl, rootUrl);

                if (UrlSettings.NonVirtualContentUrls.Contains(contentUrl))
                {
                    return UrlSettings.ContentRootUrl + url;
                }

                return UrlSettings.ContentWwwUrl + url;
            }

            if (url == "")
            {
                return SeparatorString;
            }

            return url;
        }
        public static string ConvertToVirtualUrl(string url)
        {
            url = ConvertAspNetCoreUrlToStandardUrl(url);

            if (url.StartsWith(UrlSettings.ContentWwwUrl))
            {
                url = url.ReplaceFirst(UrlSettings.ContentWwwUrl, "");
            }

            if (url.StartsWith(UrlSettings.ContentRootUrl))
            {
                url = url.ReplaceFirst(UrlSettings.ContentRootUrl, "");
            }

            if (url == "")
            {
                return SeparatorString;
            }

            return url;
        }
        public static string ConvertAspNetCoreUrlToStandardUrl(string url)
        {
            if (url.StartsWith("~/"))
            {
                url = url.ReplaceFirst("~/", "/");
            }

            if (url.StartsWith("/Web"))
            {
                url = url.ReplaceFirst("/Web", "");
            }

            return url;
        }

        public static string ConvertToAppPath(string url)
        {
            return AppPath.Join(GeneralSettings.WebRootPath, ConvertToActualUrl(url));
        }
        public static string ConvertToAbsolutePath(string url)
        {
            return AppPath.Join(Program.RootPath, ConvertToAppPath(url));
        }

        public static string ConvertAppPathToUrl(string appPath)
        {
            return ConvertToVirtualUrl(appPath);
        }
        public static string ConvertAbsoluteAppPathToUrl(string absAppPath)
        {
            return ConvertToVirtualUrl(AppPath.ConvertAbsolutePathToAppPath(absAppPath));
        }


        public static bool Exists(string url)
        {
            var appPath = ConvertToAppPath(url);
            return AppFile.Exists(appPath) || AppDirectory.Exists(appPath);
        }
        public static bool IsFile(string url)
        {
            return AppFile.Exists(ConvertToAppPath(url));
        }
        public static bool IsDirectory(string url)
        {
            return AppDirectory.Exists(ConvertToAppPath(url));
        }
        public static bool IsDirectlyServable(string url)
        {
            foreach (var unservableString in UnservableStrings)
            {
                if (url.Contains(unservableString))
                {
                    return false;
                }
            }

            return true;
        }

        public static string[] GetDirectories(string url) 
        {
            var dirs = AppDirectory.GetDirectories(ConvertToAppPath(url));
            
            var c = dirs.Length;

            for(var i = 0; i < c; i++) 
            {
                dirs[i] = ConvertAppPathToUrl(dirs[i]);    
            }

            return dirs;
        }
        public static string[] GetFiles(string url, string searchPattern = "*.*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return AppDirectory.GetFiles(ConvertToAppPath(url), searchPattern, searchOption);
        }

        public static async Task<string> ReadAllTextAsync(string url) 
        {
            return await AppFile.ReadAllTextAsync(ConvertToAppPath(url));
        }

        public static string RootUrl(string url)
        {
            // 2 bc url format: /somtehting/asd => /something/ has 2 separators
            return PartialUrl(url, 2);
        }
        public static string RootUrlPlusOne(string url) 
        {
            return PartialUrl(url, 3);
        }
        public static string PartialUrl(string url, int separatorCount) 
        {
            var separatorsFound = 0;
            var previousSeparatorIndex = -1;

            while (true) 
            {
                var separatorIndex = url.IndexOf(Separator, previousSeparatorIndex + 1);

                if (separatorIndex >= 0)
                {
                    separatorsFound++;
                    previousSeparatorIndex = separatorIndex;
                    if (separatorsFound == separatorCount) 
                    {
                        return url.Substring(0, separatorIndex);
                    }
                }
                else 
                {
                    return url;
                }
            }
        }
        public static string Join(params string[] urls) 
        {
            return string.Join(Separator, urls).Replace("//", SeparatorString);
        }
    }
}
