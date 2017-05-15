using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Net;

namespace Data
{
    public class Test
    {
        public void Start()
        {
            var client = new MongoClient();

            var db=client.GetDatabase("TestDB");

            var collection = db.GetCollection<BsonDocument>("TestCollection");

        }
    }
}
