using Core.Repositories;
using DI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core;
using Newtonsoft.Json.Linq;

namespace Reptile
{
    internal class DetailUrlReptile
    {
        private IHttpHelper _HttpHelper;
        private IGoodsRepository _GoodsRepository;
        private IShopRepository _ShopRepository;

        public DetailUrlReptile()
        {
            _HttpHelper = Ioc.Get<IHttpHelper>();
        }

        public void Do()
        {

            //获取详细内容
            //一次100条

            int currentPageIndex = 0;
            int currentPageSize = 100;
            int maxCount = _GoodsRepository.Count();
            int pageIndexMax = maxCount / currentPageSize + (maxCount % currentPageSize) > 0 ? 1 : 0;

            for(;currentPageIndex<pageIndexMax;currentPageIndex++)
            {
                //获取每条信息
                var goods = _GoodsRepository.Skip(currentPageIndex*currentPageSize).Take(currentPageSize);
                
                foreach(var item in goods)
                {
                    //获取详细信息的Json
                    var jsonStr = _HttpHelper.Request(UrlHelper.GetDetailUrl(item.Nid,item.ShopUserId));

                    JObject jObject = JObject.Parse(jsonStr);

                    //确认是否 获取成功 code 0
                    if(Convert.ToInt32(jObject["code"]["code"])!=0)
                    {
                        Console.Write(" Code Error");
                        continue;
                    }

                    item.Price = jObject["data"]["price"].Value<decimal>();
                    item.EvaluateCount = jObject["data"]["soldQuantity"]["soldTotalCount"].Value<uint>();

                    JArray contractList = jObject["data"]["contract"]["contractList"] as JArray;
                    string[] serviceCommitment = new string[contractList.Count];

                    for(int i=0;i<serviceCommitment.Length;i++)
                    {
                        serviceCommitment[i] = contractList[i].Value<string>("name");
                    }

                    item.ShipAddress = jObject["data"]["deliveryFee"]["data"]["sendCity"].Value<string>();

                    _GoodsRepository.Save(item);
                }
            }
        }
    }
}
