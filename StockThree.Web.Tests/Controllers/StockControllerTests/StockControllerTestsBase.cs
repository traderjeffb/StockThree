using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockContracts;
using StockThree.Web.Controllers;

namespace StockThree.Web.Tests.Controllers.StockControllerTests
{
    [TestClass]
    public abstract class StockControllerTestsBase
    {
        protected StockController Controller;
        protected FakeStockService Service;

    [TestInitialize]
        public virtual void Arrange()
        {
            Service = new FakeStockService();

            Controller = new StockController(
                new Lazy<IStockService>(()=> Service));
        }
    }
}
