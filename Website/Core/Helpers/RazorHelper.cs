using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace CommunicatorCms.Core.Helpers
{
    public static class RazorHelper
    {
        public static IHtmlContent Body(Func<object, IHtmlContent> body)
        {
            return body(0);
        }
    }
}
