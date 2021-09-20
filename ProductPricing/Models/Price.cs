using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductPricing.Models
{
    public class Price
    {
        public long ItemID { get; set; }
        public long StoreID { get; set; }

        public double PriceVal { get; set; }
    }
}
