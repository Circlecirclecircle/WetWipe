using Core;
using Core.Repositories;
using DI;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reptile
{
    class ViewListReptile
    {
        public void Do()
        {
            //检索列表数据，获取userId,nid,detailUrl

            int maxRequestCount = 100;

            IGoodsRepository goodsRepository = Ioc.Get<IGoodsRepository>();
            IShopRepository shopRepository = Ioc.Get<IShopRepository>();


            for (int i = 0; i < maxRequestCount; i++)
            {
                string jsonStr = HttpHelper.Request(UrlHelper.NextPageUrl(i));

                JObject jobject = JObject.Parse(jsonStr);

                JArray auctions = (JArray)jobject["mods"]["itemlist"]["data"]["auctions"];

                foreach (var auction in auctions)
                {
                    Shop shop = new Shop();
                    Goods goods = new Goods();

                    shop.UserId = Convert.ToInt64(auction["user_id"]);
                    shop.Nick = auction["nick"].ToString();

                    goods.Nid = Convert.ToInt64(auction["nid"]);
                    goods.Title = auction["title"].ToString();
                    goods.RawTitle = auction["raw_title"].ToString();
                    goods.DetailUrl = auction["detail_url"].ToString();
                    

                    //不存在  就添加 
                    if(shopRepository.FirstOrDefault(a=>a.UserId==shop.UserId)==null)
                    {
                        shopRepository.Add(shop);
                    }

                    if(goodsRepository.FirstOrDefault(a=>a.Nid==goods.Nid)==null)
                    {
                        goodsRepository.Add(goods);
                    }
                }


            }


        }
    }
}
