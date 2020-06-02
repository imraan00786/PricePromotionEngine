using PricePromotionEngine.Web.Models;
using PricePromotionEngine.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PricePromotionEngine.Web.Services
{
    public class OrderService: IOrderService
    {
        public OrderService()
        {

        }


        public double CalculateForSKU_A(Order orderRequest)
        {
            double totalPrice = 0;
            var SKU_ID_A = orderRequest.Products.Where(o => o.SKUId.ToLowerInvariant() == "a").FirstOrDefault();
            if (SKU_ID_A != null && SKU_ID_A.Quantity > 0)
            {
                int remainder1;
                int numofCount = Math.DivRem(SKU_ID_A.Quantity, 3, out remainder1);
                if (numofCount > 0)
                { totalPrice += ProductPrice.SKU_A_Price * remainder1 + 130 * numofCount; }
                else
                {
                    totalPrice += ProductPrice.SKU_A_Price * SKU_ID_A.Quantity;
                }
                    
            }
            return totalPrice;
        }

        public double CalculateForSKU_B(Order orderRequest)
        {
            double totalPrice = 0;
            var SKU_ID_B = orderRequest.Products.Where(o => o.SKUId.ToLowerInvariant() == "b").FirstOrDefault();
            if (SKU_ID_B != null && SKU_ID_B.Quantity > 0)
            {
                int remainder1;
                int numofCount = Math.DivRem(SKU_ID_B.Quantity, 2, out remainder1);
                if (numofCount > 0) {
                    totalPrice += ProductPrice.SKU_B_Price * remainder1 + 45 * numofCount;
                }
                else
                {
                    totalPrice += ProductPrice.SKU_B_Price * SKU_ID_B.Quantity;
                }

                
            }
            return totalPrice;
        }

        public double CalculateForSKU_C_D(Order orderRequest)
        {
            double totalPrice = 0;
            var SKU_ID_C = orderRequest.Products.Where(o => o.SKUId.ToLowerInvariant() == "c").FirstOrDefault();
            var SKU_ID_D = orderRequest.Products.Where(o => o.SKUId.ToLowerInvariant() == "d").FirstOrDefault();

            if (SKU_ID_C != null && SKU_ID_C.Quantity > 0 && SKU_ID_D != null && SKU_ID_D.Quantity > 0)
            {
                int c_numofCount = SKU_ID_C.Quantity;
                int d_numofCount = SKU_ID_D.Quantity;
                if (c_numofCount == d_numofCount)
                {
                    totalPrice += ProductPrice.SKU_C_D_Price * c_numofCount;
                }
                else if(c_numofCount > d_numofCount)
                {
                    totalPrice += ProductPrice.SKU_C_D_Price * d_numofCount;
                    totalPrice += ProductPrice.SKU_C_Price * (c_numofCount - d_numofCount);
                }
                else if (d_numofCount > c_numofCount)
                {
                    totalPrice += ProductPrice.SKU_C_D_Price * c_numofCount;
                    totalPrice += ProductPrice.SKU_D_Price * (d_numofCount - c_numofCount);
                }
            }
            return totalPrice;
        }

        public double CalculateForSKU_C(Order orderRequest)
        {
            double totalPrice = 0;
            var SKU_ID_C = orderRequest.Products.Where(o => o.SKUId.ToLowerInvariant() == "c").FirstOrDefault();
            if (SKU_ID_C != null && SKU_ID_C.Quantity > 0)
            {
                totalPrice += ProductPrice.SKU_C_Price * SKU_ID_C.Quantity;
            }
            return totalPrice;
        }

        public double CalculateForSKU_D(Order orderRequest)
        {
            double totalPrice = 0;
            var SKU_ID_D = orderRequest.Products.Where(o => o.SKUId.ToLowerInvariant() == "d").FirstOrDefault();
            if (SKU_ID_D != null && SKU_ID_D.Quantity > 0)
            {
                totalPrice += ProductPrice.SKU_D_Price * SKU_ID_D.Quantity;
            }
            return totalPrice;
        }

        public double PriceCalculate(Order orderRequest)
        {
            double totalPrice = 0;

            totalPrice += CalculateForSKU_A(orderRequest);
            totalPrice += CalculateForSKU_B(orderRequest);

            var SKU_ID_C = orderRequest.Products.Where(o => o.SKUId.ToLowerInvariant() == "c").FirstOrDefault();
            var SKU_ID_D = orderRequest.Products.Where(o => o.SKUId.ToLowerInvariant() == "d").FirstOrDefault();

            if (SKU_ID_C != null && SKU_ID_C.Quantity > 0 && SKU_ID_D != null && SKU_ID_D.Quantity > 0)
            {
                totalPrice += CalculateForSKU_C_D(orderRequest);
            }
            else
            {
                totalPrice += CalculateForSKU_C(orderRequest);
                totalPrice += CalculateForSKU_D(orderRequest);
            }

            return totalPrice;
        }
    }
}
