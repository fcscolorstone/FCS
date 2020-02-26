using System;
using System.Collections.Generic;
using AoteNiu.Data;
using AoteNiu.Service;

namespace AoteNiu.Service
{
    public interface ICoinPriceService
    {
        CoinPrice GetBySymbol(string symbol, string platform);

        void Update(CoinPrice pr);

        CoinPrice GetByAdress(string address);
    }
}
