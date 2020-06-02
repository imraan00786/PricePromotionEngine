using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricePromotionEngine.Web.Models
{
    public class Order
    {
       public List<ShortlistedItem> Products { get; set; }
    }

    public class ShortlistedItem
    {
        public string SKUId { get; set; }

        public int Quantity { get; set; }
    }
}
