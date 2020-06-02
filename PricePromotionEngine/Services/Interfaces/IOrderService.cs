using PricePromotionEngine.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricePromotionEngine.Web.Services.Interfaces
{
    /// <summary>
    /// IOrderService
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// PriceCalculate
        /// </summary>
        /// <param name="orderRequest"></param>
        /// <returns></returns>
        double PriceCalculate(Order orderRequest);
    }
}
