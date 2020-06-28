using System;
using System.Collections.Generic;
using AoteNiu.Data;
using AoteNiu.Service;

namespace AoteNiu.Service
{
    public interface IBlockCcApiService
    {
        decimal GetCurrency(XinBu_Currency currency);

        IList<BlockCCPriceDataModel> GetTokenPriceUsd(string tokens);
    }
}
