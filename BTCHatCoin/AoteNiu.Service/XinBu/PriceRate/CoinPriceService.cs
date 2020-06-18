using AoteNiu.Data;
using log4net;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoteNiu.Service
{
    public class CoinPriceService : ICoinPriceService
    {
        private ILog _log;

        private readonly IAltNiuRepository<CoinPrice> _coinPriceRepository;

        public CoinPriceService(IAltNiuRepository<CoinPrice> coinPriceRepository)
        {
            this._log = LogManager.GetLogger(typeof(CoinPriceService));
            this._coinPriceRepository = coinPriceRepository;
        }

        public CoinPrice GetBySymbol(string symbol, string platform)
        {
            Guard.ArgumentNotEmpty(symbol, "symbol");
            Guard.ArgumentNotEmpty(platform, "platform");

            return _coinPriceRepository.Find(x => (x.symbol.ToLower() == symbol.ToLower() && 
                                            x.platform.ToLower() == platform.ToLower()))?.FirstOrDefault();
        }

        public void Update(CoinPrice pr)
        {
            Guard.ArgumentNotNull(pr, "CoinPrice");

            pr.utime = DateTime.Now;
            _coinPriceRepository.Update(pr);
        }

        public CoinPrice GetByAddress(string address)
        {
            Guard.ArgumentNotEmpty(address, "address");

            return _coinPriceRepository.Find(x => (x.address.ToLower() == address.ToLower()))?.FirstOrDefault();
        }

        public void DelByAddress(string address)
        {
            Guard.ArgumentNotEmpty(address, "address");
            _coinPriceRepository.Delete(x => (x.address.ToLower() == address.ToLower()));
        }
    }
}
