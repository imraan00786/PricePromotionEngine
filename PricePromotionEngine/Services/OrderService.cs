using PricePromotionEngine.Web.Models;
using PricePromotionEngine.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricePromotionEngine.Web.Services
{
    public class OrderService: IOrderService
    {
        public OrderService()
        {

        }

        public double PriceCalculate(Order orderRequest)
        {
            return 0;
        }
    }
}
