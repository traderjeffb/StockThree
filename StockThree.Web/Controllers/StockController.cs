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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            

        }

        var userId = Guid.Parse(User.Identity.GetUserId());
        var service = new StockService(userId);
        service.CreateStocks();

            return RedirectToAction("Index");

    }
}