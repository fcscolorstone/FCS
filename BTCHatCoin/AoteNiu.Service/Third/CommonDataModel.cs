using Nethereum.Hex.HexTypes;
using Nethereum.Util;
using System.Collections.Generic;

namespace AoteNiu.Service
{
    #region BlockCC

    public class BlockCCRateDataModel
    {
        public int code { get; set; }

        public string message { get; set; }

        public BlockCCRateDataSubModel data { get; set; }
    }

    public class BlockCCRateDataSubModel
    {
        public string timestamp { get; set; }

        public BlockCCRatesModel rates { get; set; }
    }

    public class BlockCCRatesModel
    {
        public decimal CNY { get; set; }
    }

    public class BlockCCPriceModel
    {
        public int code { get; set; }

        public string message { get; set; }

        public List<BlockCCPriceDataModel> data { get; set; }

        public BlockCCPriceModel()
        {
            data = new List<BlockCCPriceDataModel>();
        }
    }

    public class BlockCCPriceDataModel
    {
        public long timestamps { get; set; }

        public string name { get; set; }
        public string symbol { get; set; }

        // 美金
        public decimal price { get; set; }

        public decimal price_usd { get; set; }
        public decimal price_btc { get; set; }

        // 交易量：RMB
        public decimal volume { get; set; }
        // 交易量：USD
        public decimal volume_usd { get; set; }
        // 市场总量: USD
        public decimal market_cap_usd { get; set; }

        // 涨跌量： 100*
        public decimal change_hourly { get; set; }
        public decimal change_daily { get; set; }
        public decimal change_weekly { get; set; }
        public decimal change_monthly { get; set; }
    }

    #endregion

    #region binance

    public class BinancePriceModel
    {
        public string symbol { get; set; }

        public string price { get; set; }
    }

    #endregion

    #region huobi

    public class HuobiPriceModel
    {
        public string status { get; set; }

        public string ch { get; set; }

        public long ts { get; set; }

        public HuobiPriceTickModel tick { get; set; }

    }

    public class HuobiPriceTickModel
    {
        public long id { get; set; }

        public long ts { get; set; }

        public List<HuobiPriceDataModel> data { get; set; }
    }

    public class HuobiPriceDataModel
    {
        public decimal amount { get; set; }        
        public decimal price { get; set; }
        public string direction { get; set; }
    }


    #endregion

    #region coinbase

    public class CoinbasePriceModel
    {
        public int trade_id { get; set; }
        public string price { get; set; }
        public string size { get; set; }
        public string time { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string volume { get; set; }
    }

    #endregion
}
