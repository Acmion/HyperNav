using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunicatorCms.Core.Application.FileSystem;

namespace CommunicatorCms.Core.Application.Pages
{
    public class AppPageHandler
    {
        public Dictionary<string, AppPage> AppPagesByUrl { get; } = new Dictionary<string, AppPage>();

        public async Task<AppPage> GetByUrl(string url)
        {
            // Fix concurrent access (with semaphore?)!! In all handlers.

            if (!AppPagesByUrl.ContainsKey(url))
            {
                if (url.Contains("//"))
                {
                    throw new Exception("The url can not contain several consecutive forward slashes!");
                }

                var sourcePage = await AppPage.LoadFromUrl(url);

                AppPagesByUrl[url] = sourcePage;
                AppPagesByUrl[sourcePage.PageUrl] = sourcePage;
            }

            return AppPagesByUrl[url];
        }
        public async Task<AppPage> GetByAppPath(string appPath)
        {
            var url = AppUrl.ConvertAppPathToUrl(appPath);

            return await GetByUrl(url);
        }

        public void Clear() 
        {
            AppPagesByUrl.Clear();
        }
        public void RemoveUrl(string url) 
        {
            // Remove all instances of a url, regardless of whether it ends with "/" or not

            AppPagesByUrl.Remove(url);

            if (url.EndsWith(AppUrl.Separator))
            {
                AppPagesByUrl.Remove(url.Remove(url.Length - 1));
            }
            else 
            {
                AppPagesByUrl.Remove(url + AppUrl.SeparatorString);
            }
        }
    }
}
