using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace Data
{
    public abstract class BaseMongoDBRepository<T> : MongoQueryProvider, IMongoDBRepository
    {

        public string ConnectionStr { get => throw new NotImplementedException();}
        public string DBName { get => throw new NotImplementedException();}
        public string CollectionName { get => throw new NotImplementedException();}
    }
}
