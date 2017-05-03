using Core;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.MongoDBRepositories
{
    public class GoodsRepository: BaseMongoDBRepository<Goods,long>,IGoodsRepository
    {

    }
}
