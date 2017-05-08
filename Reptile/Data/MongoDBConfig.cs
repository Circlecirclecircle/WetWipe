using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class MongoDBConfig
    {
        public static string DefaultClientConnection => "mongodb://Lilith:lilithpwd@58.101.214.37:27017";

        public static string DefaultDBName => "mydb";

        private static MongoClient _defaultMongoClient;

        public static MongoClient DefaultMongoClient
        {
            get
            {
                if(_defaultMongoClient==null)
                {
                    _defaultMongoClient = new MongoClient(DefaultClientConnection);
                }

                return _defaultMongoClient;
            }
        }
    }
}
