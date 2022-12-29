using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.ViewModels
{
    public static class DictionaryExtensions
    {
        public static bool ValueAsBool(this IDictionary<string, object> dictionary, string key, bool defaultValue = false) =>
            dictionary.ContainsKey(key) && dictionary[key] is bool dictValue
                ? dictValue
                : defaultValue;

        public static int ValueAsInt(this IDictionary<string, object> dictionary, string key, int defaultValue = 0) =>
            dictionary.ContainsKey(key) && dictionary[key] is int intValue
                ? intValue
                : defaultValue;
    }
}
