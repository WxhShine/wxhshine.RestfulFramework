using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace wxhshine.Infrastructure.Common.Utils
{
    public class AppDomainTypeFinder
    {
        public static IEnumerable<Type> GetSubClassType(Type type)
        {
            var resultTypes = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var count = assemblies.Count(); 
            foreach(var assembly in assemblies)
            {
                Type[] types = assembly.GetTypes();
                foreach(var t in types)
                {
                    if(t.IsClass)
                    {
                        Type interfaceType = t.GetInterface(type.Name);
                        if(interfaceType != null)
                        {
                            resultTypes.Add(t);
                        }
                    }
                };
            };

            return resultTypes;
        }
    }
}
