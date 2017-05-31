using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MongoData
{
    public class ClassMapRegisterClassMap
    {
        private static bool Loaded { get; set; }

        public static void Load()
        {
            if (Loaded) return;

            Assembly assembly = Assembly.Load(new AssemblyName(typeof(ClassMapRegisterClassMap).Namespace));

            IEnumerable<IClassMap> classMaps= assembly.DefinedTypes
                                        .Where(a => a.GetInterfaces().Contains(typeof(IClassMap)))
                                        .Select(a => (IClassMap)Activator.CreateInstance(Type.GetType(a.FullName))).ToArray();

            foreach(var map in classMaps)
            {
                map.Load();
            }

            Loaded = true;
        }
    }
}
