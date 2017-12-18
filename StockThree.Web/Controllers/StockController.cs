using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StockContracts;
//using StockContracts;
using StockThree.Models;
using StockThree.Services;

namespace StockThree.Web.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private readonly Lazy<StockService> _stockService;
        private Lazy<IStockService> lazy;

        public StockController()
        {
            _stockService = new Lazy<StockService>(() =>
            new StockService(Guid.Parse(User.Identity.GetUserId())));
        }

        public StockController(Lazy<StockService> stockService)
        {
            _stockService = stockService;
        }

        public StockController(Lazy<IStockService> lazy)
        {
            this.lazy = lazy;
        }


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
            

            if (_stockService.Value.CreateStock(model))
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
            var model = _stockService.Value.GetStockById(id);

            return View(model);
        }

        //Remember that lc id is important because of the route.
        public ActionResult Edit(int id)
        {
  //          var service = CreateStockService();
  //          var detail = _stockService.Value.GetStockById(id);
            var service = _stockService.Value;
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


            if (_stockService.Value.UpdateStock(model))
            {
                TempData["SaveResult"] = "Your Stock was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("","Your Stock could not be Updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {

            var model = _stockService.Value.GetStockById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {

            _stockService.Value.DeleteStock(id);
            TempData["SaveResult"] = "Your Stock was deleted";
            return RedirectToAction("Index");
        }



        private StockService StockService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockService(userId);
            return service;
        }// ******
    }
}