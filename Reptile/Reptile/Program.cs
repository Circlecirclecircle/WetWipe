using Core;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;
using Core.Repositories;
using DI;
using System.Linq;

namespace Reptile
{
    class Program
    {
        static void Main(string[] args)
        {
            //通过关键词获取首页
            //获取商品跳转地址
            //抓取商品页面信息
            //填入

            int maxRequestCount = 100;

            IGoodsRepository goodsRepository = Ioc.Get<IGoodsRepository>();
            IShopRepository shopRepository = Ioc.Get<IShopRepository>();


            for(int i=0;i<maxRequestCount;i++)
            {
                string jsonStr = HttpHelper.Request(UrlHelper.NextPageUrl(i));

                JObject jobject = JObject.Parse(jsonStr);

                JArray auctions = (JArray)jobject["mods"]["itemlist"]["data"]["auctions"];

                foreach(var auction in auctions)
                {

                    long nid = Convert.ToInt64(auction["nid"]);
                    long userId = Convert.ToInt64(auction["user_id"]);

                    Shop shop = shopRepository.FirstOrDefault(a=>a.UserId==userId);
                    Goods goods = goodsRepository.FirstOrDefault(a=>a.Nid==nid);

                    if(shop==null) //原来不存在  就添加一个
                    {
                        shop = new Shop();
                        shop.UserId = userId;
                    }

                    if(goods==null) //原来不存在就 添加一个
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