using System;
using System.Collections.Generic;
using System.Text;

namespace Reptile
{
    class UrlHelper
    {
        private const string _baseUrl = "https://s.taobao.com/search?data-key=s&data-value=44&ajax=true&_ksTS=1491790443859_925&callback=jsonp926&q=湿巾&imgfile=&commend=all&ssid=s5-e&search_type=item&sourceId=tb.index&spm=a21bo.50862.201856-taobao-item.1&ie=utf8&initiative_id=tbindexz_20170410&bcoffset=2&ntoffset=0&p4ppushleft=1,48&s={0}";

        private const int _pageSize = 44;

        public static string NextPageUrl(int pageIndex)
        {
            return string.Format(_baseUrl,pageIndex*_pageSize);
        }
    }
}
