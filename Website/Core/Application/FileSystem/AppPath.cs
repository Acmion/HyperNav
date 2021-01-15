using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CommunicatorCms.Core.Settings;

namespace CommunicatorCms.Core.Application.FileSystem
{
    public static class AppPath
    {
        public const string DirectorySeparator = "/";

        public static string ConvertAppPathToAbsolutePath(string appPath)
        {
            return Path.Join(Program.RootPath, appPath);
        }
        public static string ConvertAbsolutePathToAppPath(string absolutePath)
        {
            return absolutePath.Replace(Program.RootPath, "");
        }

        public static string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }
        public static string GetDirectoryName(string path)
        {
            var dir = Path.GetDirectoryName(path).Replace('\\', '/');

            if (dir == null) 
            {
                throw new Exception("Error, path has no parent directory.");
            }

            return dir;
        }


        public static string Join(params string[] paths)
        {
            return string.Join('/', paths).Replace("//", "/");
        }

        public static bool IsParentUrl(string parentUrl, string childUrl) 
        {
            if (childUrl.StartsWith(parentUrl)) 
            {
                var parentDirectories = parentUrl.Split('/', StringSplitOptions.RemoveEmptyEntries);
                var childDirectories = childUrl.Split('/', StringSplitOptions.RemoveEmptyEntries);

                var c = parentDirectories.Length;
                for(var i = 0; i < c; i++)
                {
                    if (parentDirectories[i] != childDirectories[i]) 
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
        public static string GetUrlWithMaxNumberOfSlashes(string url, int maxSlashes) 
        {
            var count = 0;
            var c = url.Length;
         
            for(var i = 0; i < c; i++)
            {
                var character = url[i];

                if (character == '/') 
                {
                    count++;
                }

                if (count == maxSlashes) 
                {
                    return url.Substring(0, i);
                }
            }

            return url;
        }
        
    }
}
