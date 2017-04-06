using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Shop
    {
        public string Name { get; set; }

        public ICollection<Goods> GoodsCollection { get; set; }
    }
}
