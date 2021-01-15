using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CommunicatorCms.Core.Actions
{
    public static class ActionHelper
    {
        public static string AbsoluteUrl(string relativeUrl, HttpRequest httpRequest)
        {
            return httpRequest.Scheme + "://" + httpRequest.Host + relativeUrl;
        }
        public static string AbsoluteUrl(string relativeUrl, string protocolAndDomain)
        {
            return protocolAndDomain + "/" + relativeUrl;
        }

        public static string GetParameterString(Dictionary<string, object> keyValues) 
        {
            var parameterString = "?";
            foreach (var key in keyValues.Keys) 
            {
                parameterString += key + "=" + keyValues[key].ToString() + "&";
            }

            return parameterString.TrimEnd('&');
        }
    }
}
