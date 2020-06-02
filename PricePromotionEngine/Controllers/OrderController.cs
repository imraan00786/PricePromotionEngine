using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PricePromotionEngine.Web.Models;
using PricePromotionEngine.Web.Services.Interfaces;

namespace PricePromotionEngine.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Private Variables
        private readonly IOrderService _service;
        #endregion Private Variables


        #region Constrcutor
        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="service"></param>
        public OrderController(
            IOrderService service)
        {
            _service = service;
        }
        #endregion Constructor


        #region API Operations
        /// <summary>
		/// Post Order
		/// </summary>
		/// <param name="orderRequest"></param>
		/// <returns></returns>
		[ProducesResponseType(typeof(double), 201)]
        [ProducesResponseType(typeof(void), 500)]
        [HttpPost("/api/applicants")]
        public  IActionResult PostOrder(Order orderRequest)
        {
            try
            {

                int remainder1;
                int numBoxes = Math.DivRem(5, 3, out remainder1);

                double answer = 5.0 / 3.0;

                int remainder = 5 % 3;

                int quotient = 5 / 3;

                var result =  _service.PriceCalculate(orderRequest);

               
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
