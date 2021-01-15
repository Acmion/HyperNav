using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace CommunicatorCms.Core.Extensions
{
    public static class IQueryCollectionExtension
    {
        public static StringValues GetOrDefault(this IQueryCollection queryCollection, string key, StringValues defaultValue)
        {
            if (queryCollection.ContainsKey(key))
            {
                return queryCollection[key];
            }

            return defaultValue;
        }

        public static int GetOrDefaultInt(this IQueryCollection queryCollection, string key, int defaultValue)
        {
            if (queryCollection.ContainsKey(key))
            {
                if (int.TryParse(queryCollection[key], out var result))
                {
                    return result;
                }
            }

            return defaultValue;
        }


        public static bool GetOrDefaultBool(this IQueryCollection queryCollection, string key, bool defaultValue)
        {
            if (queryCollection.ContainsKey(key))
            {
                if (bool.TryParse(queryCollection[key], out var result))
                {
                    return result;
                }
            }

            return defaultValue;
        }
    }
}
