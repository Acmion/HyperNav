using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicatorCms.Core.Settings
{
    public static class ThemeSettings
    {
        public static string ActiveName { get; set; } = "acmion";
        public static string DefaultName { get; set; } = "default";

        public static string ThemeHeadFileName { get; } = "head.cshtml";
        public static string ThemeHeaderFileName { get; } = "header.cshtml";
        public static string ThemeMainFileName { get; } = "main.cshtml";
        public static string ThemeFooterFileName { get; } = "footer.cshtml";

    }
}
