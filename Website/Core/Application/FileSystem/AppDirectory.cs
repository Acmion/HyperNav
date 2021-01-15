using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicatorCms.Core.Application.FileSystem
{
    public static class AppDirectory
    {
        public static bool Exists(string applicationPath) 
        {
            return Directory.Exists(AppPath.ConvertAppPathToAbsolutePath(applicationPath));
        }

        public static string[] GetFiles(string applicationPath, string searchPattern = "*.*", SearchOption searchOption = SearchOption.TopDirectoryOnly) 
        {
            var paths = Directory.GetFiles(AppPath.ConvertAppPathToAbsolutePath(applicationPath), searchPattern, searchOption);

            for(var i = 0; i < paths.Length; i++) 
            {
                paths[i] = AppPath.ConvertAbsolutePathToAppPath(paths[i].Replace('\\', '/'));
            }

            return paths;
        }

        public static string[] GetDirectories(string applicationPath) 
        {
            var paths = Directory.GetDirectories(AppPath.ConvertAppPathToAbsolutePath(applicationPath));

            for (var i = 0; i < paths.Length; i++)
            {
                paths[i] = AppPath.ConvertAbsolutePathToAppPath(paths[i].Replace('\\', '/'));
            }

            return paths;
        }
    }
}
