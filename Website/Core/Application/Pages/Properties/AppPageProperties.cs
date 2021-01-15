using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicatorCms.Core.Application.Pages.Properties
{
    public class AppPageProperties
    {
        public static AppPageProperties Default { get; } = new AppPageProperties();

        public string Icon { get; set; } = "";
        public string Title { get; set; } = "Unknown";
        public string RedirectUrl { get; set; } = "";

        public string Layout { get; set; } = "";

        public bool RenderMain { get; set; } = true;
        public bool RenderHead { get; set; } = true;
        public bool RenderHeader { get; set; } = true;
        public bool RenderFooter { get; set; } = true;

        public bool ShowInNavigationMenus { get; set; } = true;
        public bool ShowTopNavigationMenu { get; set; } = true;
        public bool ShowSideNavigationMenu { get; set; } = true;

        public List<string> SubPageOrder { get; set; } = new List<string>();
        public List<string> SubPageOrderFromEnd { get; set; } = new List<string>();

        public List<string> ContentOrder { get; set; } = new List<string>();


    }
}
