using CommunicatorCms.Core.Application.Pages.Properties;
using CommunicatorCms.Core.Application.FileSystem;
using CommunicatorCms.Core.Helpers;
using CommunicatorCms.Core.Settings;
using Markdig;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace CommunicatorCms.Core.Application.Pages
{
    public class AppPage
    {
        private static char IgnoreContentFileStartingCharacter = '_';
        private static IDeserializer YamlDeserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().Build();
        private static MarkdownPipeline MarkdownPipeline = new MarkdownPipelineBuilder().UseAutoIdentifiers().Build();

        public string PageUrl { get; set; }
        public string PageAppPath { get; set; }

        public AppPageProperties Properties { get; set; } = AppPageProperties.Default;
        public AppPagePropertiesNavItem PropertiesNavItem { get; set; } = AppPagePropertiesNavItem.Default;
        public dynamic PropertiesExtra { get; set; } = 0;

        public List<string> ContentFileAppPaths { get => GetContentFileAppPaths(); }

        private List<AppPage>? _subPages;
        private List<string>? _contentFileAppPaths;

        public AppPage(string appPath)
        {
            PageAppPath = appPath;
            PageUrl = AppUrl.ConvertToVirtualUrl(appPath);

            if (!PageUrl.EndsWith('/'))
            {
                PageUrl += '/';
            }
        }

        public static bool IsUrlAppPage(string url) 
        {
            return IsAppPathAppPage(AppUrl.ConvertToAppPath(url));
        }
        public static bool IsAppPathAppPage(string appPath)
        {
            return AppFile.Exists(AppPath.Join(appPath, AppPageSettings.PropertiesFileName));
        }

        public static async Task<AppPage> LoadFromUrl(string url)
        {
            var appPath = AppUrl.ConvertToAppPath(url);
            var sourcePage = await LoadFromAppPath(appPath);

            return sourcePage;
        }
        public static async Task<AppPage> LoadFromAppPath(string appPath)
        {
            if (IsAppPathAppPage(appPath))
            {
                var page = new AppPage(appPath);

                await page.LoadProperties();

                return page;
            }

            throw new Exception($"The specified app path ({appPath}) is not a valid AppPage.");
        }


        public async Task Reload()
        {
            _subPages = null;
            _contentFileAppPaths = null;

            await LoadProperties();
        }

        public async Task<string> Render(RazorPageBase razorPage, IHtmlHelper htmlHelper)
        {
            return await Render(razorPage, htmlHelper, null!);
        }
        public async Task<string> Render(RazorPageBase razorPage, IHtmlHelper htmlHelper, object model)
        {
            var contentFileAppPaths = GetContentFileAppPaths();

            foreach (var cfap in contentFileAppPaths)
            {
                if (cfap.EndsWith(".cshtml"))
                {
                    await htmlHelper.RenderPartialAsync(cfap, model);
                }
                else
                {
                    var content = await AppFile.ReadAllTextAsync(cfap);

                    if (cfap.EndsWith(".md"))
                    {
                        razorPage.Output.Write(Markdown.ToHtml(content, MarkdownPipeline));
                    }
                    else
                    {
                        razorPage.Output.Write(content);
                    }
                }
            }

            return "";
        }

        public async Task<AppPage> GetParentPage()
        {
            return await App.Pages.GetByUrl(AppPath.GetDirectoryName(PageUrl));
        }
        public async Task<List<AppPage>> GetSubPages()
        {
            if (_subPages == null)
            {
                var subPageAppPaths = GetSubPageAppPaths();

                _subPages = new List<AppPage>(subPageAppPaths.Count);

                foreach (var subPagePath in subPageAppPaths)
                {
                    var subPage = await App.Pages.GetByAppPath(subPagePath);

                    _subPages.Add(subPage);
                }
            }

            return _subPages;
        }

        private async Task LoadProperties() 
        {
            var propertiesFilePath = AppPath.Join(PageAppPath, AppPageSettings.PropertiesFileName);
            var propertiesLayoutFilePath = AppPath.Join(PageAppPath, AppPageSettings.PropertiesNavItemFileName);
            var propertiesExtraFilePath = AppPath.Join(PageAppPath, AppPageSettings.PropertiesExtraFileName);

            var properties = AppPageProperties.Default;

            if (AppFile.Exists(propertiesFilePath))
            {
                var propertiesCandidate = YamlDeserializer.Deserialize<AppPageProperties>(await AppFile.ReadAllTextAsync(propertiesFilePath));
                if (propertiesCandidate != null)
                {
                    properties = propertiesCandidate;
                }
            }

            var propertiesNavItem = AppPagePropertiesNavItem.Default;

            if (AppFile.Exists(propertiesLayoutFilePath))
            {
                var propertiesNavItemCandidate = YamlDeserializer.Deserialize<AppPagePropertiesNavItem>(await AppFile.ReadAllTextAsync(propertiesLayoutFilePath));
                if (propertiesNavItemCandidate != null)
                {
                    propertiesNavItem = propertiesNavItemCandidate;
                }
            }

            var propertiesExtra = new ExpandoObject();

            if (AppFile.Exists(propertiesExtraFilePath))
            {
                var propertiesExtraCandidate = YamlDeserializer.Deserialize<ExpandoObject>(await AppFile.ReadAllTextAsync(propertiesExtraFilePath));
                if (propertiesExtraCandidate != null)
                {
                    propertiesExtra = propertiesExtraCandidate;
                }
            }

            Properties = properties;
            PropertiesNavItem = propertiesNavItem;
            PropertiesExtra = propertiesExtra;
        }

        private List<string> GetSubPageAppPaths()
        {
            var subPageAppPaths = new List<string>(Properties.SubPageOrder.Count);
            var subPageAppPathsSet = new HashSet<string>(Properties.SubPageOrder.Count);
            var subPageAppPathsAfterEllipsis = new List<string>(Properties.SubPageOrder.Count);

            var currentSubPageAppPathList = subPageAppPaths;

            foreach (var spo in Properties.SubPageOrder)
            {
                var subDirectoryPath = AppPath.Join(PageAppPath, spo);

                if (spo == AppPageSettings.SubPageOrderEllipsisIdentifier)
                {
                    currentSubPageAppPathList = subPageAppPathsAfterEllipsis;
                }
                else if (AppDirectory.Exists(subDirectoryPath) && IsAppPathAppPage(subDirectoryPath))
                {
                    currentSubPageAppPathList.Add(subDirectoryPath);
                    subPageAppPathsSet.Add(subDirectoryPath);
                }
            }

            var subDirectories = AppDirectory.GetDirectories(PageAppPath);

            foreach (var subDirectoryPath in subDirectories)
            {
                if (!subPageAppPathsSet.Contains(subDirectoryPath) && IsAppPathAppPage(subDirectoryPath))
                {
                    subPageAppPaths.Add(subDirectoryPath);
                }
            }

            subPageAppPaths.AddRange(subPageAppPathsAfterEllipsis);

            return subPageAppPaths;
        }
        private List<string> GetContentFileAppPaths()
        {
            if (_contentFileAppPaths == null)
            {
                var contentFilePathsSet = new HashSet<string>(Properties.ContentOrder.Count);

                _contentFileAppPaths = new List<string>(Properties.ContentOrder.Count);

                foreach (var co in Properties.ContentOrder)
                {
                    var contentFilePath = Path.Join(PageAppPath, co);

                    if (AppFile.Exists(contentFilePath))
                    {
                        _contentFileAppPaths.Add(contentFilePath);
                        contentFilePathsSet.Add(contentFilePath);
                    }
                }
                var allContentFilePaths = AppDirectory.GetFiles(PageAppPath);
                Array.Sort(allContentFilePaths);

                foreach (var contentFilePath in allContentFilePaths)
                {
                    var fileName = Path.GetFileName(contentFilePath);

                    if (!fileName.StartsWith(IgnoreContentFileStartingCharacter))
                    {
                        if (!contentFilePathsSet.Contains(contentFilePath))
                        {
                            _contentFileAppPaths.Add(contentFilePath);
                        }
                    }
                }
            }

            return _contentFileAppPaths;
        }

        public override string ToString()
        {
            return $"Title: {Properties.Title}, Url: {PageUrl}";
        }
    }
}
