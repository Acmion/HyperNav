using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicatorCms.Core
{
    public class Url
    {
        public static string Combine(params string[] urls) 
        {
            var combinedUrl = "";

            if (urls[0][0] == '/') 
            {
                combinedUrl += "/";
            }

            foreach (var url in urls) 
            {
                combinedUrl += url.Trim('/') + "/";
            }

            return combinedUrl;
        }
    }
}
