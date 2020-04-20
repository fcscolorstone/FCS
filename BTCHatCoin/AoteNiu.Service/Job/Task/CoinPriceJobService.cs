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

        /// <summary>
        /// 默认构造函数：无参数
        /// </summary>
        public CoinPriceJobService(
            ICoinPriceService coinPriceService)
        {
            this._log = LogManager.GetLogger(typeof(CoinPriceJobService));
            this._coinPriceService = coinPriceService;
            this._PriceCNY = GetCNY();
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
                if (_PriceCNY > 0)
                {
                    FlushHuobiPrice("btc", "btcusdt", "0");
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }

            Running = false;
            return Task.CompletedTask;
        }

        private decimal GetCNY()
        {
            try
            {
                //get exchange rate from block.cc
                var rateUrl = "http://data.block.cc/api/v1/exchange_rate?api_key=SD9R0BVD4FDCF8UO2WXD7IYSGK3RTRG2KZTSR5U";
                var request = (HttpWebRequest)WebRequest.Create(rateUrl);

                request.Method = "GET";
                request.Accept = "*/*";
                request.ContentType = "application/json";
                request.Timeout = 3000;

                int times = AoteNiuConst.HTTP_REQUEST_TRY_TIMES;
                while (times-- >= 0)
                {
                    try
                    {
                        var rsp = (HttpWebResponse)request.GetResponse();
                        if (rsp.StatusCode != HttpStatusCode.OK)
                        {
                            _log.Error($"GetCNY rsp.StatusCode != HttpStatusCode.OK");
                            return 0;
                        }

                        BlockCCRateDataModel rate_data;
                        using (var reader = new StreamReader(rsp.GetResponseStream()))
                        {
                            rate_data = JsonConvert.DeserializeObject<BlockCCRateDataModel>(reader.ReadToEnd()) as BlockCCRateDataModel;
                            if (null == rate_data)
                            {
                                _log.Error($"GetCNY rate_data null");
                                return 0;
                            }

                            return rate_data.data.rates.CNY;
                        }
                    }
                    catch (WebException)
                    {
                        _log.Error($"try times = {times}");
                        Thread.Sleep(1000);
                        continue;
                    }
                }

                if (times < 0)
                {
                    _log.Error($"GetCNY failed !!!");
                }

                return 0;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                return 0;
            }
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
                                _log.Debug($"FlushHuobiPrice price_data null");
                                return;
                            }
                        }

                        if (null == price_data.tick.data)
                        {
                            _log.Debug($"FlushHuobiPrice price_data.data null");
                            return;
                        }

                        decimal price = price_data.tick.data[0].price;

                        var pr = _coinPriceService.GetBySymbol(key, AoteNiuConst.HUOBI);
                        if (pr == null)
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
                        if (pr == null)
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
    }
}
