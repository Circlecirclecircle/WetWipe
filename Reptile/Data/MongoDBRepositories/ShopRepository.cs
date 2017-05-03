using Core;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Repositories;

namespace Data.MongoDBRepositories
{
    public class ShopRepository:BaseMongoDBRepository<Shop,long>,IShopRepository
    {
    }
}
