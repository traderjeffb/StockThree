using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockContracts;
using StockThree.Models;
using StockThree.Services;


namespace StockThree.Web.Tests.Controllers
{

    public class FakeStockService : IStock
    {

        public int CreateStockCallCount { get; private set; }
        public bool CreateStockReturnValue { private get; set; }

        public bool CreateStock(StockCreate model)
        {
            CreateStockCallCount++;

            return CreateStockReturnValue;
        }

        public IEnumerable<StockListItem> GetStocks()
        {
            throw new NotImplementedException();
        }

        public bool DeleteStock(int stockId)
        {
            throw new NotImplementedException();
        }

        public StockDetail GetStockById(int stockId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStock(StockEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
