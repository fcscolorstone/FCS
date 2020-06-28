using AoteNiu.Data;
using log4net;
using NBitcoin;
using Newtonsoft.Json;
using Quartz;
using Quartz.Spi;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AoteNiu.Service
{
    /// <summary>
    /// 代币价格信息
    /// </summary>
    public class CoinPriceJobService : IJob
    {
        private static bool Running = false;

        private readonly ILog _log;

        private decimal _PriceCNY = 7;

        private readonly ICoinPriceService _coinPriceService;
        private readonly IBlockCcApiService _blockCcApiService;

        /// <summary>
        /// 默认构造函数：无参数
        /// </summary>
        public CoinPriceJobService(ICoinPriceService coinPriceService, IBlockCcApiService blockCcApiService)
        {
            this._log = LogManager.GetLogger(typeof(CoinPriceJobService));
            this._coinPriceService = coinPriceService;
            this._blockCcApiService = blockCcApiService;
            this._PriceCNY = _blockCcApiService.GetCurrency(XinBu_Currency.CNY);
        }

        /// <summary>
        /// 1） 查询block.cc价格信息
        /// 2） 最新结果写入表
        /// </summary>
        /// <param name="context"></param>
        public Task Execute(IJobExecutionContext context)
        {
            if (CoinPriceJobService.Running)
            {
                return Task.CompletedTask;
            }

            Running = true;
            try
            {
                this._PriceCNY = _blockCcApiService.GetCurrency(XinBu_Currency.CNY);
                if (this._PriceCNY > 0)
                {
                    Thread.Sleep(1200);

                    FlushTokenPrice(this._PriceCNY, $"{AoteNiuConst.BLOCK_CHAIN_TOKEN_PRICE_FCS},{AoteNiuConst.BLOCK_CHAIN_TOKEN_PRICE_ETH},{AoteNiuConst.BLOCK_CHAIN_TOKEN_PRICE_BTC},{AoteNiuConst.BLOCK_CHAIN_TOKEN_PRICE_USDT}");
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }

            Running = false;
            return Task.CompletedTask;
        }

        private void FlushHuobiPrice(string key, string full, string address)
        { 
            try
            {
                // get coin price from huobi
                var priceUrl = $"https://api.huobi.pro/market/trade?symbol={key}usdt";
                var request = (HttpWebRequest)WebRequest.Create(priceUrl);

                request.Method = "GET";
                request.Accept = "*/*";
                request.ContentType = "application/json";
                request.Timeout = 2000;

                int times = AoteNiuConst.HTTP_REQUEST_TRY_TIMES;
                while (times-- >= 0)
                {
                    try
                    {
                        var rsp = (HttpWebResponse)request.GetResponse();
                        if (rsp.StatusCode != HttpStatusCode.OK)
                        {
                            _log.Error($"FlushHuobiPrice rsp.StatusCode != HttpStatusCode.OK");
                            return;
                        }

                        HuobiPriceModel price_data;
                        using (var reader = new StreamReader(rsp.GetResponseStream()))
                        {
                            price_data = JsonConvert.DeserializeObject<HuobiPriceModel>(reader.ReadToEnd()) as HuobiPriceModel;
                            if (null == price_data)
                            {
                                _log.Error($"FlushHuobiPrice price_data null");
                                return;
                            }
                        }

                        if (null == price_data.tick.data)
                        {
                            _log.Error($"FlushHuobiPrice price_data.data null");
                            return;
                        }

                        decimal price = price_data.tick.data[0].price;

                        var pr = _coinPriceService.GetBySymbol(key, AoteNiuConst.HUOBI);
                        if (null == pr)
                        {
                            pr = new CoinPrice
                            {
                                address = address,
                                platform = AoteNiuConst.HUOBI,
                                symbol = key,
                                full = full,
                                price_usd = price,
                                price = price * _PriceCNY,
                                ctime = DateTime.Now
                            };
                        }
                        else
                        {
                            pr.price = price * _PriceCNY;
                            pr.price_usd = price;
                        }

                        _coinPriceService.Update(pr);
                    }
                    catch (WebException ex)
                    {
                        _log.Error(ex.ToString());
                        Thread.Sleep(1000);
                        continue;
                    }

                    break;
                }

                if (times < 0)
                {
                    _log.Error($"FlushHuobiPrice: {key} failed !!!");
                    return;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                return;
            }
        }

        private void FlushCoinbasePrice(string key, string full, string address)
        {
            try
            {
                // price api: 
                var priceUrl = $"https://api.pro.coinbase.com/products/{key}-USD/ticker";
                var request = (HttpWebRequest)WebRequest.Create(priceUrl);

                request.Method = "GET";
                request.Accept = "*/*";
                request.ContentType = "application/json";
                request.Timeout = 2000;

                int times = AoteNiuConst.HTTP_REQUEST_TRY_TIMES;
                while (times-- >= 0)
                {
                    try
                    {
                        var rsp = (HttpWebResponse)request.GetResponse();
                        if (rsp.StatusCode != HttpStatusCode.OK)
                        {
                            _log.Debug($"FlushCoinbasePrice rsp.StatusCode != HttpStatusCode.OK");
                            return;
                        }

                        CoinbasePriceModel price_data;
                        using (var reader = new StreamReader(rsp.GetResponseStream()))
                        {
                            price_data = JsonConvert.DeserializeObject<CoinbasePriceModel>(reader.ReadToEnd()) as CoinbasePriceModel;
                            if (null == price_data)
                            {
                                _log.Debug($"FlushCoinbasePrice price_data null");
                                return;
                            }
                        }

                        decimal price = Convert.ToDecimal(price_data.price);

                        var pr = _coinPriceService.GetBySymbol(key, AoteNiuConst.COINBASE);
                        if (null == pr)
                        {
                            pr = new CoinPrice
                            {
                                address = address,
                                platform = AoteNiuConst.COINBASE,
                                symbol = key,
                                full = full,
                                price_usd = price,
                                price = price * _PriceCNY,
                                ctime = DateTime.Now
                            };
                        }
                        else
                        {
                            pr.price = price * _PriceCNY;
                            pr.price_usd = price;
                        }

                        _coinPriceService.Update(pr);
                    }
                    catch (WebException ex)
                    {
                        _log.Error(ex.ToString());
                        Thread.Sleep(1000);
                        continue;
                    }

                    break;
                }

                if (times < 0)
                {
                    _log.Error($"FlushCoinbasePrice: {key} failed !!!");
                    return;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                return;
            }
        }

        private void FlushTokenPrice(decimal cny, string tokens)
        {
            var dlist = _blockCcApiService.GetTokenPriceUsd(tokens);
            foreach (var item in dlist)
            {
                var pr = _coinPriceService.GetBySymbol(item.name, AoteNiuConst.HUOBI);
                if (pr == null)
                {
                    string contract = string.Empty;
                    if (item.name == AoteNiuConst.BLOCK_CHAIN_TOKEN_PRICE_FCS)
                    {
                        //contract = _walletService.GetFcsContract();
                    }
                    else if (item.name == AoteNiuConst.BLOCK_CHAIN_TOKEN_PRICE_ETH)
                    {
                        contract = AoteNiuConst.BLOCK_CHAIN_SYSTEM_CONTRACT_ETH;
                    }

                    pr = new CoinPrice
                    {
                        //ctype = BTChat_BlockChain_Type.Ethereum,
                        address = contract,
                        platform = AoteNiuConst.HUOBI,
                        symbol = item.name,
                        price_usd = item.price_usd,
                        price = item.price * cny,
                        ctime = DateTime.Now
                    };
                }
                else
                {
                    pr.price = item.price * cny;
                    pr.price_usd = item.price_usd;
                    pr.price_btc = item.price_btc;
                }

                _coinPriceService.Update(pr);
            }
        }
    }
}
