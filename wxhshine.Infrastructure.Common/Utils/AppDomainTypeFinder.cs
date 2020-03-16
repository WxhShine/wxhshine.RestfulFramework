using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace wxhshine.Infrastructure.Common.Utils
{
    public class AppDomainTypeFinder
    {
        public static IEnumerable<Type> GetSubClassType(Type type)
        {
            var resultTypes = new List<Type>();
            var assemblies = DependencyContext.Default.CompileLibraries.Where(lib=>lib.Name.Contains("wxhshine"));
            foreach (var assembly in assemblies)
            {
                Type[] types = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(assembly.Name)).GetTypes();
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
