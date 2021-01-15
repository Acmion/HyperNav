using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicatorCms.Core.Application.Pages.Properties
{
    public class AppPagePropertiesNavItem
    {
        public static AppPagePropertiesNavItem Default { get; } = new AppPagePropertiesNavItem();

        public SourcePagePropertiesNavItemContext Top { get; set; } = new SourcePagePropertiesNavItemContext();
        public SourcePagePropertiesNavItemContext Side { get; set; } = new SourcePagePropertiesNavItemContext();
        public SourcePagePropertiesNavItemContext Shared { get; set; } = new SourcePagePropertiesNavItemContext();

    }

    public class SourcePagePropertiesNavItemContext 
    {
        public double SpaceBefore { get; set; } = 0;
        public double SpaceAfter { get; set; } = 0;
        
        public string CssInline { get; set; } = "";
        public string CssClasses { get; set; } = "";

        public string ExpandCssInline { get; set; } = "";
        public string ExpandCssClasses { get; set; } = "";
    }
}
