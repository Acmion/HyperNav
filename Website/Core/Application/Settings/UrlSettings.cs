using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicatorCms.Core.Settings
{
    public static class UrlSettings
    {
        public static string CmsRootUrl { get; } = "/cms";
        public static string ContentRootUrl { get; } = "/content";
        public static string RenderingRootUrl { get; } = "/_rendering";

        public static string CmsWwwUrl { get; } = "/cms/www";
        public static string CmsThemesUrl { get; } = "/cms/themes";
        public static string CmsExtensionsUrl { get; } = "/cms/extensions";

        public static string ContentWwwUrl { get; } = "/content/www";
        public static string ContentStaticUrl { get; } = "/content/static";
        public static string ContentActionsUrl { get; } = "/content/actions";
        public static string ContentGeneralUrl { get; } = "/content/_general";
        public static string ContentCommunicatorCmsUrl { get; } = "/content/communicator-cms";

        public static string ContentCommunicatorCmsThemesUrl { get; } = "/content/communicator-cms/themes";
        public static string ContentCommunicatorCmsExtensionsUrl { get; } = "/content/communicator-cms/extensions";

        public static HashSet<string> NonVirtualRootUrls = new HashSet<string>() { RenderingRootUrl, CmsRootUrl };
        public static HashSet<string> NonVirtualContentUrls = new HashSet<string>() { ContentStaticUrl, ContentActionsUrl, ContentGeneralUrl, ContentCommunicatorCmsUrl };
    }
}
