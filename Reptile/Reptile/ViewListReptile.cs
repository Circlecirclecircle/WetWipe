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

                    long nid = Convert.ToInt64(auction["nid"]);
                    long userId = Convert.ToInt64(auction["user_id"]);

                    Shop shop = shopRepository.FirstOrDefault(a => a.UserId == userId);
                    Goods goods = goodsRepository.FirstOrDefault(a => a.Nid == nid);

                    if (shop == null) //原来不存在  就添加一个
                    {
                        shop = new Shop();
                        shop.UserId = userId;
                    }

                    if (goods == null) //原来不存在就 添加一个
                    {
                        goods = new Goods();
                        goods.Nid = nid;
                    }

                    shop.Nick = auction["nick"].ToString();

                    goods.Title = auction["title"].ToString();
                    goods.RawTitle = auction["raw_title"].ToString();

                }


            }


        }
    }
}
