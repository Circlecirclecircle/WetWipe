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

            int maxRequestCount = 10;

            IGoodsRepository goodsRepository = Ioc.Get<IGoodsRepository>();
            IShopRepository shopRepository = Ioc.Get<IShopRepository>();


            for (int i = 0; i < maxRequestCount; i++)
            {
                Console.WriteLine("Request Count:{0}",i);

                string jsonStr = HttpHelper.Request(UrlHelper.NextPageUrl(i));

                jsonStr=jsonStr.Trim().Replace("jsonp926(","").TrimEnd(';').TrimEnd(')');

                JObject jobject = JObject.Parse(jsonStr);

                JArray auctions = (JArray)jobject["mods"]["itemlist"]["data"]["auctions"];

                foreach (var auction in auctions)
                {
                    Shop shop = new Shop();
                    Goods goods = new Goods();

                    shop.UserId = Convert.ToInt64(auction["user_id"].ToString());
                    shop.Nick = auction["nick"].ToString();

                    goods.Nid = Convert.ToInt64(auction["nid"].ToString());
                    goods.Title = auction["title"].ToString();
                    goods.RawTitle = auction["raw_title"].ToString();
                    goods.DetailUrl = auction["detail_url"].ToString().Trim();

                    //Uri detaiUrl = new Uri(goods.DetailUrl);
                    //if(!detaiUrl.Host.Equals("item.taobao.com"))
                    //{
                    //    string currentUrl = goods.DetailUrl;
                    //    int requestNum = 10;
                    //    while(requestNum>0)
                    //    {
                    //        requestNum--;

                    //        string tempUrl = HttpHelper.GetRedirectUrl(currentUrl);
                    //        if(string.IsNullOrEmpty(tempUrl))
                    //        {
                    //            goods.DetailUrl = currentUrl;
                    //            break;
                    //        }

                    //        currentUrl = tempUrl;
                    //    }
                    //}

                    

                    //不存在  就添加 
                    if(shopRepository.FirstOrDefault(a=>a.UserId==shop.UserId)==null)
                    {
                        shopRepository.Add(shop);
                    }

                    if(goodsRepository.FirstOrDefault(a=>a.Nid==goods.Nid)==null)
                    {
                        goods.ShopUserId = shop.UserId;
                        goodsRepository.Add(goods);
                    }
                }


            }


        }
    }
}
