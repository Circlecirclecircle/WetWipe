using Core;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DI
{
    public static class Ioc
    {
        private static StandardKernel _kernel;

        static Ioc()
        {
            EnsureInitialized();
            _kernel.Load(typeof(Ioc).Assembly);
        }

        public static StandardKernel Kernel
        {
            get
            {
                if (_kernel == null)
                {
                    EnsureInitialized();
                }

                return _kernel;
            }
        }

        public static void EnsureInitialized()
        {
            if (_kernel == null)
            {
                _kernel = new StandardKernel();
                _kernel.Settings.Set("InjectAttribute", typeof(DependencyAttribute)); //修改属性注入
                _kernel.Settings.InjectNonPublic = true;
            }
        }
    }
}
