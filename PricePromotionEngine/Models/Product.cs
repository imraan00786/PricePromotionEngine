using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricePromotionEngine.Web.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SKUId { get; set; }

        public double Price { get; set; }
    }
}
