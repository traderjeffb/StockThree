using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockThree.Models;

namespace StockThree.Web.Controllers
{   [Authorize]
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            var model = new StockListItem[0];
            return View(model);
        }
    }
}