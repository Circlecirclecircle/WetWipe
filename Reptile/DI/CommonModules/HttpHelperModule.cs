using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using Core;
using Common;

namespace DI.CommonModules
{
    internal class HttpHelperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHttpHelper>().To<HttpClientHelper>();
        }
    }
}
