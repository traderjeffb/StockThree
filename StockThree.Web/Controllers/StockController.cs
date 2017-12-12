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
                ViewBag.SaveResult = "Your stock was created.";
                return RedirectToAction("Index");
            }
            ;  //<<<---------------------------------*needs a semi-colon  #7 num 10.
            
            ModelState.AddModelError("","Stock could not be created.");
            
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