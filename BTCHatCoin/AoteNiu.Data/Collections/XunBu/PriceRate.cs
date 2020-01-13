using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AoteNiu.Data
{
    /// <summary>
    /// 价格行情信息
    /// </summary>
    public class CoinPrice : Entity
    {
        public string address { get; set; }

        public string platform { get; set; }

        public string symbol {get; set;}

        public string full { get; set; }

        public decimal price { get; set; }

        public decimal price_usd { get; set; }

        public decimal price_btc { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime utime { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ctime { get; set; }
    }
}
