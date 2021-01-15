using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicatorCms.Core.Settings
{
    public static class AppPageSettings
    {
        public static string SubPageOrderEllipsisIdentifier { get; } = "...";

        public static string IndexUrl { get; private set; } = "_index";
        public static string IndexFileName { get; private set; } = "_index.cshtml";

        public static string PropertiesFileNamePrefix { get; } = "_properties";
        public static string PropertiesFileName { get; private set; } = "_properties.yaml";
        public static string PropertiesNavItemFileName { get; private set; } = "_properties-nav-item.yaml";
        public static string PropertiesExtraFileName { get; private set; } = "_properties-extra.yaml";

    }

}
