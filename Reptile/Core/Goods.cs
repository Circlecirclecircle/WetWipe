using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Goods:IEntity<long>
    {
        long IEntity<long>.Id=>Nid;

        public string Title { get; set; }

        public string RawTitle { get; set; }

        /// <summary>
        /// 商品详情页面
        /// </summary>
        public string DetailUrl
        {
            get { return _detailUrl; }
            set
            {
                switch (value.IndexOf("https:"))
                {
                    case 0: //在最前面
                        _detailUrl = value;
                        break;
                    case -1: //没有找到
                    default: //在其他地方
                             //加上https
                        _detailUrl = "https:" + value;
                        break;
                }
            }
        }

        private string _detailUrl;

        /// <summary>
        /// 这个好像是商品的唯一编号
        /// </summary>
        public long Nid { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属商店
        /// </summary>
        public Shop Shop { get; }

        public long ShopUserId { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        public Dictionary<string, string> GoodsDetail { get; set; }

        /// <summary>
        /// 月销售量
        /// </summary>
        public uint MonthlySaleCount { get; set; }

        /// <summary>
        /// 累计评价
        /// </summary>
        public uint EvaluateCount { get; set; }

        /// <summary>
        /// 评价分数
        /// </summary>
        public float EvaluateGrade { get; set; }

        /// <summary>
        /// 服务承诺
        /// </summary>
        public string[] ServiceCommitment { get; set; }
        
        /// <summary>
        /// 发货地址
        /// </summary>
        public string ShipAddress { get; set; }

        /// <summary>
        /// 商品标签
        /// </summary>
        public string[] Labels { get; set; }

        
    }
}
