using Core;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoData.ClassMap
{
    internal class ShopMap : IClassMap
    {
        public void Load()
        {
            BsonClassMap.RegisterClassMap<Shop>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.UserId);
            });
        }
    }
}
