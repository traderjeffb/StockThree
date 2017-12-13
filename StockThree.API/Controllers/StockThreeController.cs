using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using StockThree.Services;

namespace StockThree.API.Controllers
{   [Authorize]
    public class StockThreeController : ApiController
    {
        //Get api/stock
        public IHttpActionResult Get()
        {
            StockService  stockService = CreateStockService();
            var stocks = stockService.GetStocks();

            return Ok(stocks);

        }

        private StockService CreateStockService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var stockService = new StockService(userId);
            return stockService;

        }
    }
}
