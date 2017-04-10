using Newtonsoft.Json.Linq;
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

            int maxRequestCount = 100;

            for(int i=0;i<maxRequestCount;i++)
            {
                string jsonStr = HttpHelper.Request(UrlHelper.NextPageUrl(i));

                JObject jobject = JObject.Parse(jsonStr);

                JArray itemlist = (JArray)jobject["mods"]["itemlist"]["data"];

            }
            
        }
    }
}