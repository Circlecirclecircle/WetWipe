using System;
using System.Text.RegularExpressions;

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

            //请求地址
            //https://s.taobao.com/api?_ksTS=1491644478993_306&callback=jsonp307&ajax=true&m=customized&rn=512e001151f0879b90ad0ed824b9a016&q=湿巾&imgfile=&commend=all&ssid=s5-e&search_type=item&sourceId=tb.index&spm=a21bo.50862.201856-taobao-item.1&ie=utf8&initiative_id=tbindexz_20170408&bcoffset=5&ntoffset=5&p4ppushleft=1,48&s=1&s=36&bcoffset=-2
            string searchPage = HttpHelper.Request("https://s.taobao.com/search?q=湿巾");

            Regex regexSearchPage = new Regex("");
        }
    }
}