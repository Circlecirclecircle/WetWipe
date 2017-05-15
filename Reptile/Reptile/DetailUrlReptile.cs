using Core.Repositories;
using DI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Reptile
{
    internal class DetailUrlReptile
    {
        public void Do()
        {
            IGoodsRepository goodsRepository = Ioc.Get<IGoodsRepository>();
            IShopRepository shopRepository = Ioc.Get<IShopRepository>();

            //获取详细内容
            //一次100条

            int currentPageIndex = 0;
            int currentPageSize = 100;
            int maxCount = goodsRepository.Count();
            int pageIndexMax = maxCount / currentPageSize + maxCount % currentPageSize > 0 ? 1 : 0;

            for(;currentPageIndex<pageIndexMax;currentPageIndex++)
            {
                //获取每条信息
                var goods = goodsRepository.Skip(currentPageIndex*currentPageSize).Take(currentPageSize);
                
                foreach(var item in goods)
                {
                    //请求详细地址
                    string url = item.DetailUrl.Contains("https:")?item.DetailUrl:"https:"+item.DetailUrl;
                    string html = HttpHelper.Request(url);



                }

                


            }


        }
    }
}
