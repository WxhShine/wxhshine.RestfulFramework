using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wxhshine.Infrastructure.Common.Utils
{
    public static class IEnumerableExtension
    {
        public static void Foreach<T>(this IEnumerable<T> collections, Action<T> action)
        {
            foreach(var item in collections)
            {
                action.Invoke(item);
            }
        }
    }
}
