using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductPricing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Models.Tests
{
    [TestClass()]
    public class LiteDBTests
    {
        [TestMethod()]
        public void GetPriceTest()
        {
            LiteDB ldb = new LiteDB();
            ldb.FillDB("test", 1, 1, 0.50);
            double p = ldb.GetPrice("test", 1, 1);
            Assert.IsTrue(p > 0);
        }
    }
}