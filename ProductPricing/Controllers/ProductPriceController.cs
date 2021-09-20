using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductPricing.Controllers
{
    public class ProductPriceController : Controller
    {
        [HttpGet()]
        [Route("api/[controller]/{itemid}/{storeid}")]
        public Models.Price GetProductPrice(long itemid, long storeid)
        {
            //LiteDB getPrice
            Models.LiteDB liteDB = new Models.LiteDB();
            return new Models.Price { ItemID=itemid, StoreID=storeid, PriceVal = liteDB.GetPrice("test", itemid, storeid) };
        }
    }
}
