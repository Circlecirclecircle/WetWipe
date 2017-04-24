using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IMongoDBRepository: IMongoQueryable
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        string ConnectionStr { get;}

        /// <summary>
        /// 数据库名字
        /// </summary>
        string DBName { get;}

        /// <summary>
        /// 集合名字
        /// </summary>
        string CollectionName { get;}
    }
}
