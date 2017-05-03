using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using Core.Repositories;
using Data.MongoDBRepositories;

namespace DI.Modules
{
    public class GoodsRepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGoodsRepository>().To<GoodsRepository>();
        }
    }
}
