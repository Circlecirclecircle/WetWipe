using Core.Repositories;
using DI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core;

namespace Reptile
{
    internal class DetailUrlReptile
    {
        private IHttpHelper _HttpHelper;
        private IGoodsRepository _Goodsrepository;
        private IShopRepository _ShopRepository;

        public DetailUrlReptile()
        {
            _HttpHelper = Ioc.Get<IHttpHelper>();
        }

        public void Do()
        {
            //https://detailskip.taobao.com/service/getData/1/p1/item/detail/sib.htm?itemId=544648516961&sellerId=616143059&modules=dynStock,qrcode,viewer,price,contract,duty,xmpPromotion,delivery,upp,activity,fqg,zjys,couponActivity,soldQuantity,tradeContract&callback=onSibRequestSuccess

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
                    //获取详细信息的Json



                }

                


            }


        }
    }
}
