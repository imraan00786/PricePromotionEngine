using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PricePromotionEngine.Web.Helper;
using PricePromotionEngine.Web.Models;
using PricePromotionEngine.Web.Services.Interfaces;

namespace PricePromotionEngine.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Private Variables
        private ILogger _logger;
        private readonly IOrderService _service;
        #endregion Private Variables


        #region Constrcutor
        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="service"></param>
        public OrderController(ILogger<OrderController> logger,
            IOrderService service)
        {
            _logger = logger;
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
        [HttpPost("/api/order")]
        public  ActionResult PostOrder(Order orderRequest)
        {
            _logger.LogInformation(MyLogEvents.GetResult, "PostOrder");
            try
            {
                var result =  _service.PriceCalculate(orderRequest);
                if (result == 0)
                {
                    _logger.LogWarning(MyLogEvents.ResultNotFound, "PostOrder() NOT FOUND");
                    return StatusCode(404, "Please verify the input values.");
                }
                _logger.LogInformation("PostOrder(), completed.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("PostOrder(), completed with errors: {0}.", ex.Message));
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
