using Core;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoData.MongoDBRepositories
{
    public class GoodsRepository: BaseMongoDBRepository<Goods,long>,IGoodsRepository
    {

    }
}
