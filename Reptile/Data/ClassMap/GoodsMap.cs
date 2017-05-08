using Core;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ClassMap
{
    internal class GoodsMap:IClassMap
    {
        public void Load()
        {
            BsonClassMap.RegisterClassMap<Goods>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Nid);
            });
        }
    }
}
