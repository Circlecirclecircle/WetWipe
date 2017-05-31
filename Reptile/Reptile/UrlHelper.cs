using System;
using System.Collections.Generic;
using System.Text;

namespace Reptile
{
    class UrlHelper
    {
        private const string _baseUrl = "https://s.taobao.com/search?data-key=s&data-value=44&ajax=true&callback=jsonp926&q=湿巾&imgfile=&commend=all&ssid=s5-e&search_type=item&sourceId=tb.index&ie=utf8&bcoffset=2&ntoffset=0&p4ppushleft=1,48&s={0}";

        private const int _pageSize = 44;

        public static string NextPageUrl(int pageIndex)
        {
            return string.Format(_baseUrl,pageIndex*_pageSize);
        }

        private const string _DetailUrl = "https://detailskip.taobao.com/service/getData/1/p1/item/detail/sib.htm?itemId={0}&sellerId={1}&modules=dynStock,qrcode,viewer,price,contract,duty,xmpPromotion,delivery,upp,activity,fqg,zjys,couponActivity,soldQuantity,tradeContract&callback=onSibRequestSuccess";

        /// <summary>
        /// 获取页面详细信息Url
        /// </summary>
        /// <param name="itemId">商品Id</param>
        /// <param name="sellerId">卖家Id</param>
        /// <returns></returns>
        public static string GetDetailUrl(int itemId,int sellerId)
        {
            return string.Format(_DetailUrl,itemId,sellerId);
        }
    }
}
