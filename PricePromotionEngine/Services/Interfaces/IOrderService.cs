using PricePromotionEngine.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricePromotionEngine.Web.Services.Interfaces
{
    public interface IOrderService
    {
        public double PriceCalculate(Order orderRequest);
    }
}
