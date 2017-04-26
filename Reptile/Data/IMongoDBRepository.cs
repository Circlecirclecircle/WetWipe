using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Repositories;
using MongoDB.Driver;

namespace Data
{
    public interface IMongoDBRepository<T>: IMongoQueryable<T>,ICommand<T>
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
        IMongoCollection<T> Collection { get; }
    }
}
