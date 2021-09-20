using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Models.Tests
{
    [TestClass()]
    public class JSONParseTests
    {
        [TestMethod()]
        public void deserializeJSONSelectTest()
        {
            JSONParse jp = new JSONParse();

            Dictionary<string,string> nonEmptyDict = jp.deserializeJSONSelect(new string("{\"test\":1}"), new Dictionary<string, string>());
            Assert.IsTrue(nonEmptyDict.Count > 0);
        }
    }
}