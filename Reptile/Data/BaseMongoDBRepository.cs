using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;
using Core;

namespace Data
{
    public abstract class BaseMongoDBRepository<T,TIdType> :IMongoDBRepository<T> where T:IEntity<TIdType>
    {
        public Type ElementType => _Queryable.ElementType;

        public Expression Expression => _Queryable.Expression;

        public IQueryProvider Provider => _Queryable.Provider;

        public IMongoClient Client { get; }

        public IMongoDatabase Database { get; }

        public IMongoCollection<T> Collection { get; }

        private IMongoQueryable<T> _Queryable { get; }

        public BaseMongoDBRepository()
        {
            Client = new MongoClient(MongoDBConfig.DefaultClientConnection);
            Database = Client.GetDatabase(MongoDBConfig.DefaultDBName);
            Collection = Database.GetCollection<T>(nameof(T));

            _Queryable = Collection.AsQueryable();
        }

        public BaseMongoDBRepository(string collectionName,string dbName,string clientConnection)
        {
            Client = new MongoClient(clientConnection);
            Database = Client.GetDatabase(dbName);
            Collection = Database.GetCollection<T>(collectionName);

            _Queryable = Collection.AsQueryable();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return _Queryable.GetEnumerator();
        }

        public QueryableExecutionModel GetExecutionModel()
        {
            return _Queryable.GetExecutionModel();
        }

        public IAsyncCursor<T> ToCursor(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _Queryable.ToCursor();
        }

        public Task<IAsyncCursor<T>> ToCursorAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _Queryable.ToCursorAsync();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Queryable.GetEnumerator();
        }

        public virtual void Add(T model)
        {
            Collection.InsertOne(model);
        }

        public void Remove(T model)
        {
            var filter = Builders<T>.Filter.Eq("_id",model.Id);

            Collection.DeleteOne(filter);
        }

        public void Save(T model)
        {
            var filter = Builders<T>.Filter.Eq("_id",model.Id);

            Collection.ReplaceOne(filter,model);
        }
    }
}
