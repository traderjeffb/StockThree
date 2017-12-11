using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockThree.Models;

namespace StockThree.Web.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            var model = new StockListItem[0];
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

            }
            return View(model);
        }

    }
}