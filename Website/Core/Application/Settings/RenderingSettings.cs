using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicatorCms.Core.Settings
{
    public static class RenderingSettings
    {
        public static string CmsLayoutFileName { get; } = "cms-layout.cshtml";
        public static string WwwLayoutFileName { get; } = "www-layout.cshtml";
        public static string ActionLayoutFileName { get; } = "action-layout.cshtml";

        public static string CmsUrl { get; } = "/_rendering/cms-layout";
        public static string ContentUrl { get; } = "/_rendering/www-layout";

    }
}
