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
        private IHttpHelper _HttpHelper;
        private IGoodsRepository _GoodsRepository;
        private IShopRepository _ShopRepository;

        public ViewListReptile()
        {
            _HttpHelper = Ioc.Get<IHttpHelper>();
            _GoodsRepository = Ioc.Get<IGoodsRepository>();
            _ShopRepository = Ioc.Get<IShopRepository>();
        }

        public void Do()
        {
            //检索列表数据，获取userId,nid,detailUrl

            int maxRequestCount = 1000;

            for (int i = 0; i < maxRequestCount; i++)
            {
                Console.Write("Request CurrentNum:{0} ",i);

                try
                {
                    Once(i);
                }
                catch
                {
                    Console.Write(" Error ");
                }
                
                Console.WriteLine();
            }


        }

        private void Once(int i)
        {
            string jsonStr = _HttpHelper.Request(UrlHelper.NextPageUrl(i));

            jsonStr = jsonStr.Trim().Replace("jsonp926(", "").TrimEnd(';').TrimEnd(')');

            JObject jobject = JObject.Parse(jsonStr);

            if (!jobject["mods"]["itemlist"]["status"].ToString().Equals("show"))
            {
                Console.Write(" itemlist_status:{0}", jobject["mods"]["itemlist"]["status"].ToString());

                return;
            }

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

                //不存在  就添加 
                if (_ShopRepository.FirstOrDefault(a => a.UserId == shop.UserId) == null)
                {
                    _ShopRepository.Add(shop);
                }

                if (_GoodsRepository.FirstOrDefault(a => a.Nid == goods.Nid) == null)
                {
                    goods.ShopUserId = shop.UserId;
                    _GoodsRepository.Add(goods);
                }
            }
        }
    }
}
