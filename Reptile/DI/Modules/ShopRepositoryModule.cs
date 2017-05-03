using System;
using System.Collections.Generic;
using System.Text;
using Core.Repositories;
using Data.MongoDBRepositories;
using Ninject.Modules;

namespace DI.Modules
{
    public class ShopRepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IShopRepository>().To<ShopRepository>();
        }
    }
}
