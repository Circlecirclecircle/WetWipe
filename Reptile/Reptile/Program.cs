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

            ViewListReptile viewListReptile = new ViewListReptile();

            viewListReptile.Do();
            
        }
    }
}