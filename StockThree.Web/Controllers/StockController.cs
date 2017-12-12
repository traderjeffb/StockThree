using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StockThree.Models;
using StockThree.Services;

namespace StockThree.Web.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockService(userId);
            var model = service.GetStocks();

            return View(model);
        }

        public ActionResult Create()
        { 
            var model = new StockCreate();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockCreate model)
        {

            if (!ModelState.IsValid) return View(model);
            


            var service = CreateStockService();

            if (service.CreateStock(model))
            {
                //Using TempData to store data in the session.
                //When you tead data from there, it removes it from the session.
                TempData["SaveResult"] = "Your stock was created.";
                return RedirectToAction("Index");
            }
            ;  //<<<---------------------------------*needs a semi-colon  #7 num 10.
            
            ModelState.AddModelError("","Stock could not be created.");
            
            return View(model);

        }

        public ActionResult Details(int id)
        {
            var service = CreateStockService();
            var model = service.GetStockById(id);

            return View(model);
        }

        //Remember that lc id is important because of the route.
        public ActionResult Edit(int id)
        {
            var service = CreateStockService();
            var detail = service.GetStockById(id);
            var model =
                new StockEdit
                {
                    TransactionId = detail.TransactionId,
                    Ticker = detail.Ticker,
                    Shares = detail.Shares
                };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StockEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.TransactionId != id)
            {
                ModelState.AddModelError("","ID Mismatch");
                return View(model);
            }
            var service = CreateStockService();

            if (service.UpdateStock(model))
            {
                TempData["SaveResult"] = "Your Stock was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("","Your Stock could not be Updated.");
            return View(model);
        }




        private StockService CreateStockService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockService(userId);
            return service;
        }

        private StockService StockService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockService(userId);
            return service;
        }
    }
}