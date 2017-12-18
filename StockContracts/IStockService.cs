using System;
using System.Collections.Generic;
using System.Text;
using StockThree.Models;

namespace StockContracts 
{
    public interface IStockService
    {
        bool CreateStock(StockCreate model);
        //TODO: FIND FIX FOR IEnumerable 
 //       IEnumerable<StockListItem> GetStocks();
        StockDetail GetStockById(int stockId);
        bool UpdateStock(StockEdit model);
        bool DeleteStock(int stockId);
    }
}
