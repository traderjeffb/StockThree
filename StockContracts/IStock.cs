using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockThree.Models;

namespace StockContracts
{
    public interface IStock
    {
        

            bool CreateStock(StockCreate model);
            //TODO: FIND FIX FOR IEnumerable 
            IEnumerable<StockListItem> GetStocks();
            StockDetail GetStockById(int stockId);
            bool UpdateStock(StockEdit model);
            bool DeleteStock(int stockId);


    }
}
