using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockThree.Models;

namespace StockThree.Web.Tests.Controllers.StockControllerTests
{
    [TestClass]
    public class CreatePost : StockControllerTestsBase
    {
        [TestMethod]
        public void ShouldReturnRedirectToResult()
        {
           var result = Controller.Create( new StockCreate());
            
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
        [TestMethod]
        public void ShouldCallCreateOnce()
        {
            var result = Controller.Create(new StockCreate());

            Assert.AreEqual(1,Service.CreateStockCallCount);
        }
    }
}
