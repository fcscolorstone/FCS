using System;

namespace AoteNiu
{
    // 应用程序级别的常量
    public class AoteNiuConst
    {
        // 基础参数
        public static readonly string WEB_SECTION = "WEB";
        public static readonly string WEB_KEEP_LIVE_BTCHAT = "keep_live_web_btchat";

        /// <summary>
        /// 网络请求失败重试次数
        /// </summary>
        public static readonly int BLOCK_REQUEST_TRY_TIMES = 3;
        public static readonly int HTTP_REQUEST_TRY_TIMES = 3;


        /// <summary>
        /// BTChat区块交易 - 标记
        /// </summary>
        public static readonly string BLOCK_CHAIN_TRANSACTION_ID = "BT";

        public static readonly string BLOCK_CHAIN_TOKEN_SYMBOL_BTC = "BTC";
        public static readonly string BLOCK_CHAIN_TOKEN_SYMBOL_FCS = "FCS";
        public static readonly string BLOCK_CHAIN_TOKEN_SYMBOL_ETH = "ETH";
        public static readonly string BLOCK_CHAIN_TOKEN_SYMBOL_USDT = "USDT";

        public static readonly string BLOCK_CHAIN_TOKEN_PRICE_FCS = "fcs";
        public static readonly string BLOCK_CHAIN_TOKEN_PRICE_ETH = "ethereum";
        public static readonly string BLOCK_CHAIN_TOKEN_PRICE_USDT = "usdt";
        public static readonly string BLOCK_CHAIN_TOKEN_PRICE_BTC = "bitcoin";

        public static readonly string BINANCE = "binance";
        public static readonly string HUOBI = "huobi";
        public static readonly string COINBASE = "coinbase";

        //// 基础冷参
        public static readonly long REGIST_INTERVEL = TimeSpan.TicksPerMinute;       // 短信发送间隔;
        public static readonly int REGISTER_REPEAT_MAX = 10;
        public static readonly int LEVEL_MAX = 10;                            // 最大等级;
        public static readonly string DATE_TIME_FOR_SOTRE = "yyyyMMddHHmmssfff";           // 毫秒级别 - 存储使用，便于比较;
        public static readonly string DATE_TIME_FOR_SHOW = "yyyy-MM-dd HH:mm:ss";         // 秒级别 - 显示使用;
        public static readonly int Max_PageSize = 100;                           // 请求到的最大分页数据数量;
        public static readonly int Default_PageSize = 20;                            // 默认分页大小;
        public static readonly int USER_TASK_LIMIT = 200;                           // 每次发布的最大任务上限；
    }

    public class Lang
    {
        public const string Chinese = "cn";
        public const string English = "en";
        public const string English_US = "en_US";

        public const string Chinese_Simple = "zh-cn";
        public const string Chinese_Traditional = "zh-tw";
        public const string Chinese_TraditionalR = "zh_tw";
    }
}
