using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Utils
{
    public static class ICollectionExtension
    {
        public static void Foreach<T>(this ICollection<T> collections, Action<T> action)
        {
            foreach(var item in collections)
            {
                action.Invoke(item);
            }
        }
    }
}
