using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicatorCms.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceFirst(this string text, string oldValue, string newValue)
        {
            var index = text.IndexOf(oldValue);

            if (index < 0)
            {
                return text;
            }

            return text.Substring(0, index) + newValue + text.Substring(index + oldValue.Length);
        }
    }
}
