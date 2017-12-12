using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StockThree.Data;
using StockThree.Models;
using StockThree.Web.Models;

namespace StockThree.Services
{
    public class StockService
    {

        private readonly Guid _userId;

        public StockService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStock(StockCreate model)
            
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                new Stock()
                {
                    OwnerId = _userId,
                    Ticker = model.Ticker,
                    EntryPrice = model.EntryPrice,
                    Shares = model.Shares,
                    CreatedUtc = DateTimeOffset.Now
                };


                ctx.Stocks.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<StockListItem> GetStocks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Stocks
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e => 
                                new StockListItem
                                {
                                    TransactionId = e.TransactionId,
                                    Ticker = e.Ticker,
                                    Shares = e.Shares,
                                    EntryPrice = e.EntryPrice,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }


        }

        public StockDetail GetStockById(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stocks
                        .Single(e => e.TransactionId == transactionId);
                return  
                    new StockDetail
                {
                    TransactionId = entity.TransactionId,
                    Ticker = entity.Ticker,
                    Shares = entity.Shares,
                    EntryPrice = entity.EntryPrice,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }


    }


}


