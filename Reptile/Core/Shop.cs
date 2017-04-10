using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Shop
    {
        /// <summary>
        /// 商店名字
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 商店下面的商品
        /// </summary>
        public ICollection<Goods> GoodsCollection { get; set; }

        /// <summary>
        /// 商户唯一编号
        /// </summary>
        public long UserId { get; set; }
    }
}
