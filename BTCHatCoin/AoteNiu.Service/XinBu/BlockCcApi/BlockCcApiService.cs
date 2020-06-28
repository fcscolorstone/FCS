using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Newtonsoft.Json;

namespace AoteNiu.Service
{
    public class BlockCcApiService: IBlockCcApiService
    {
        private ILog _log;

        private static string _api_key = "ZZMWTX2UQSDUGX4KMJIIG7RIB23ZXHA8OUWK5HBF";
        private static string _base_url = "http://data.block.cc/api/v1";

        private static Dictionary<XinBu_Currency, decimal> _rateMaps = new Dictionary<XinBu_Currency, decimal>();
        private static DateTime _last_flush = DateTime.Now.AddMinutes(-5);

        public BlockCcApiService()
        {
            this._log = LogManager.GetLogger(typeof(BlockCcApiService));
        }

        public decimal GetCurrency(XinBu_Currency currency)
        {
            if (_last_flush < DateTime.Now.AddMinutes(-10) || _rateMaps.Count() == 0)
            {
                FlushRates();
            }

            if (!_rateMaps.ContainsKey(currency))
            {
                _log.Error($"can not find the currency: {currency} !!!");
                return 0;
            }

            return _rateMaps[currency];
        }

        public IList<BlockCCPriceDataModel> GetTokenPriceUsd(string tokens)
        {
            List<BlockCCPriceDataModel> model = new List<BlockCCPriceDataModel>();
            try
            {
                var url = $"{_base_url}/price?api_key={_api_key}&symbol_name={tokens}";
                var request = (HttpWebRequest)WebRequest.Create(url);

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
                            continue;
                        }

                        BlockCCPriceModel price_data;
                        using (var reader = new StreamReader(rsp.GetResponseStream()))
                        {
                            price_data = JsonConvert.DeserializeObject<BlockCCPriceModel>(reader.ReadToEnd()) as BlockCCPriceModel;
                            if (null == price_data)
                            {
                                return model;
                            }

                            return price_data.data;
                        }
                    }
                    catch (WebException)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                }

                if (times < 0)
                {
                    _log.Error($"GetTokenPriceUsd: {tokens} failed !!!");
                    return model;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }

            return model;
        }

        /// <summary>
        /// 获取刷新主要币种的汇率信息
        /// </summary>
        private bool FlushRates()
        {
            try
            {
                // rate api: 
                var rateUrl = $"{_base_url}/exchange_rate?api_key={_api_key}";
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
                            return false;
                        }

                        BlockCCRateDataModel rate_data;
                        using (var reader = new StreamReader(rsp.GetResponseStream()))
                        {
                            rate_data = JsonConvert.DeserializeObject<BlockCCRateDataModel>(reader.ReadToEnd()) as BlockCCRateDataModel;
                            if (null == rate_data)
                            {
                                return false;
                            }

                            _rateMaps[XinBu_Currency.CNY] = rate_data.data.rates.CNY;
                            _rateMaps[XinBu_Currency.USD] = rate_data.data.rates.USD;
                            _rateMaps[XinBu_Currency.JAP] = rate_data.data.rates.JPY;

                            return true;
                        }
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                }

                if (times < 0)
                {
                    _log.Error($"FlushRates failed !!!");
                }

                return false;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                return false;
            }
        }
    }
}
