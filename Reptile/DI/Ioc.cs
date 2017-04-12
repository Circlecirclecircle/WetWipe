using Core;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DI
{
    public static class Ioc
    {
        private static IReadOnlyKernel _readOnlyKernel;

        static Ioc()
        {
            KernelConfiguration configuration = new KernelConfiguration(GetModules());
            configuration.Settings.Set("InjectAttribute", typeof(DependencyAttribute));

            _readOnlyKernel = configuration.BuildReadonlyKernel();
        }

        private static INinjectModule[] GetModules()
        {
            Assembly assembly = Assembly.Load(new AssemblyName(typeof(DI.Ioc).Namespace));
            INinjectModule[] modules = assembly.DefinedTypes
                                        .Where(a => a.AsType().GetInterfaces().Contains(typeof(INinjectModule)))
                                        .Select(a => (INinjectModule)Activator.CreateInstance(Type.GetType(a.FullName))).ToArray();

            return modules;
        }

        public static T Get<T>()
        {
            return _readOnlyKernel.Get<T>();
        }
    }
}
