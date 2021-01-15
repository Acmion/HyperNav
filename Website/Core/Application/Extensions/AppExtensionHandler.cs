using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CommunicatorCms.Core.Application.Extensions;
using CommunicatorCms.Core.Application.FileSystem;
using CommunicatorCms.Core.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;
using CommunicatorCms.Core.Application.Settings;
using CommunicatorCms.Core.Extensions;
using System.Threading;

namespace CommunicatorCms.Core.Application.Extensions
{
    public class AppExtensionHandler
    {
        public dynamic Extensions => _appExtensionContainer;
        
        private AppExtensionContainer _appExtensionContainer = new AppExtensionContainer();

        public AppExtensionHandler() 
        {
        }

        public void RegisterAppExtension(AppExtension appExtension)
        {
            _appExtensionContainer.RegisterAppExtension(appExtension);
        }

        public async Task LoadAppExtension(string extensionDirectoryUrl, IHtmlHelper htmlHelper) 
        {
            var initializeFileUrl = AppUrl.Join(extensionDirectoryUrl, ExtensionSettings.InitializeFileRelativePath);

            if (AppUrl.Exists(initializeFileUrl))
            {
                await htmlHelper.RenderPartialAsyncFromUrl(initializeFileUrl);
            }
            
        }
        public async Task LoadAppExtensions(IHtmlHelper htmlHelper)
        {
            _appExtensionContainer.Clear();

            var extensionRootUrls = new[] { UrlSettings.CmsExtensionsUrl, UrlSettings.CmsExtensionsUrl };

            foreach (var extRootUrl in extensionRootUrls)
            {
                var extUrls = AppUrl.GetDirectories(extRootUrl);

                foreach (var extUrl in extUrls)
                {
                    await LoadAppExtension(extUrl, htmlHelper);
                }
            }
        }

        public void OnRequestStart(RequestState requestState)
        {
            foreach (var appExtension in _appExtensionContainer.AppExtensions)
            {
                appExtension.OnRequestStart(requestState);
            }
        }
        public void OnRequestEnd(RequestState requestState)
        {
            foreach (var appExtension in _appExtensionContainer.AppExtensions)
            {
                appExtension.OnRequestEnd(requestState);
            }
        }

        public void OnActionStart(RequestState requestState)
        {
            foreach (var appExtension in _appExtensionContainer.AppExtensions)
            {
                appExtension.OnActionStart(requestState);
            }
        }
        public void OnActionEnd(RequestState requestState)
        {
            foreach (var appExtension in _appExtensionContainer.AppExtensions)
            {
                appExtension.OnActionEnd(requestState);
            }
        }

        public void OnCmsStart(RequestState requestState)
        {
            foreach (var appExtension in _appExtensionContainer.AppExtensions)
            {
                appExtension.OnCmsStart(requestState);
            }
        }
        public void OnCmsEnd(RequestState requestState)
        {
            foreach (var appExtension in _appExtensionContainer.AppExtensions)
            {
                appExtension.OnCmsEnd(requestState);
            }
        }

        public void OnContentStart(RequestState requestState)
        {
            foreach (var appExtension in _appExtensionContainer.AppExtensions)
            {
                appExtension.OnContentStart(requestState);
            }
        }
        public void OnContentEnd(RequestState requestState)
        {
            foreach (var appExtension in _appExtensionContainer.AppExtensions)
            {
                appExtension.OnContentEnd(requestState);
            }
        }
    }

    class AppExtensionContainer : DynamicObject
    {
        public int AppExtensionCount => AppExtensionsById.Count;
        public ICollection<AppExtension> AppExtensions => AppExtensionsById.Values;

        public IDictionary<string, AppExtension> AppExtensionsById { get; set; } = new Dictionary<string, AppExtension>();

        private IDictionary<string, object> _members { get; set; } = new Dictionary<string, object>();

        public void Clear()
        {
            _members.Clear();
            AppExtensionsById.Clear();
        }

        public void RegisterAppExtension(AppExtension appExtension)
        {
            if (AppExtensionsById.ContainsKey(appExtension.Id))
            {
                AppExtensionsById[appExtension.Id].UnRegister();
            }

            _members[appExtension.Id] = appExtension;
            AppExtensionsById[appExtension.Id] = appExtension;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (value is AppExtension appExt)
            {
                RegisterAppExtension(appExt);

                return true;
            }

            return false;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            return _members.TryGetValue(binder.Name, out result);
        }

    }

}
