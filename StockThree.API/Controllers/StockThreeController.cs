using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNet.Identity;
using StockThree.Models;
using StockThree.Services;

namespace StockThree.API.Controllers
{
    [Authorize]
    public class StockThreeController : ApiController
    {
        //Get api/stock
        public IHttpActionResult GetAll()
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
        //get api/stock/single stock retrival
        public IHttpActionResult Get(int id)
        {
            StockService stockService = CreateStockService();

            var stock = stockService.GetStockById(id);

            return Ok(stock);
        }

        //POST /api/stock
        public IHttpActionResult Post(StockCreate stock)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateStockService();

            if (!service.CreateStock(stock))
                return InternalServerError();

            return Ok();
        }
        //PUT /api/stock
        public IHttpActionResult Put(StockEdit stock)
        {
            if (!ModelState.IsValid)
                return BadRequest((ModelState));

            var service = CreateStockService();

            if (!service.UpdateStock(stock))
                return InternalServerError();

            return Ok();
        }
        //DELETE /api/staock
        public IHttpActionResult Delete(int id)
        {
            var service = CreateStockService();

            if (!service.DeleteStock(id))
                return InternalServerError();

            return Ok();
        }

    }
}
