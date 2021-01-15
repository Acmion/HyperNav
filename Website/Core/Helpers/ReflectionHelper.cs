using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CommunicatorCms.Core.Helpers
{
    public static class ReflectionHelper
    {
        public static void PopulatePublicStaticProperties(Type classType, Dictionary<string, object> propertyNamesAndValues) 
        {
            foreach (var propertyInfo in classType.GetProperties(BindingFlags.Public | BindingFlags.Static)) 
            {
                ExtractAndSetPropertyValue(null, propertyInfo, propertyNamesAndValues);
            }
        }

        public static void PopulatePublicProperties(object obj, Dictionary<string, object> propertyNamesAndValues) 
        {
            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                ExtractAndSetPropertyValue(obj, propertyInfo, propertyNamesAndValues);
            }
        }

        private static void ExtractAndSetPropertyValue(object? obj, PropertyInfo propertyInfo, Dictionary<string, object> propertyNamesAndValues) 
        {
            var contains = propertyNamesAndValues.ContainsKey(propertyInfo.Name);
            if (contains)
            {
                if (propertyInfo.CanWrite)
                {
                    try
                    {
                        var value = Convert.ChangeType(propertyNamesAndValues[propertyInfo.Name], propertyInfo.PropertyType, CultureInfo.CurrentCulture);
                        //propertyInfo.SetValue(obj, value);
                        SetValue(propertyInfo, obj, value);
                    }
                    catch (Exception e)
                    {
                        var t = propertyNamesAndValues[propertyInfo.Name];
                        var tt = t.GetType();
                    }
                }
            }
        }

        private static void SetValue(PropertyInfo info, object? instance, object value)
        {
            Type proptype = info.PropertyType;
            if (proptype.IsGenericType && proptype.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                proptype = new NullableConverter(info.PropertyType).UnderlyingType;
            }

            var convertedValue = Convert.ChangeType(value, proptype);
            info.SetValue(instance, convertedValue);
        }

    }
}
