using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunicatorCms.Core.Application.FileSystem;
using CommunicatorCms.Core.Extensions;
using CommunicatorCms.Core.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CommunicatorCms.Core.UrlModification
{
    public static class UrlRewrites
    {
        public static void UseUrlRewrites(this IApplicationBuilder app) 
        {
            app.Use(async (context, next) =>
            {
                var requestedUrl = context.Request.Path.Value;
                var requestedVirtualUrl = AppUrl.ConvertToVirtualUrl(requestedUrl);
                var requestedActualUrl = AppUrl.ConvertToActualUrl(requestedUrl);

                if (!AppUrl.IsDirectlyServable(requestedActualUrl)) 
                {
                    return;
                }

                if (requestedUrl.StartsWith("/+/dist")) 
                {
                    await next();
                    return;
                }

                if (requestedUrl != requestedVirtualUrl) 
                {
                    // Permanent redirect
                    context.Response.StatusCode = 301;
                    context.Response.Redirect(requestedVirtualUrl);
                    return;
                }

                if (AppUrl.IsFile(requestedActualUrl))
                {
                    context.Request.Path = requestedActualUrl;
                }
                else
                {
                    if (!requestedVirtualUrl.EndsWith(AppUrl.Separator)) 
                    {
                        // Permanent redirect
                        context.Response.StatusCode = 301;
                        context.Response.Redirect(requestedVirtualUrl + AppUrl.Separator);
                        return;
                    }

                    context.Request.Path = requestedActualUrl + AppPageSettings.IndexUrl;
                }

                await next();
            });
        }

    }
}
