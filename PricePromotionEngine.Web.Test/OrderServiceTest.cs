using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PricePromotionEngine.Web.Controllers;
using PricePromotionEngine.Web.Models;
using PricePromotionEngine.Web.Services;
using PricePromotionEngine.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PricePromotionEngine.Web.Test
{
    /// <summary>
    /// OrderServiceTest
    /// </summary>
    public class OrderServiceTest
    {
        private readonly OrderController _orderController;
        private Mock<Order> _mockPostOrder;
        public OrderServiceTest()
        {
            _mockPostOrder = new Mock<Order>();
            var orderControllerLogger = new Mock<ILogger<OrderController>>();
            var orderService = new Mock<IOrderService>();

            var service = new OrderService();
            _orderController = new OrderController(orderControllerLogger.Object, service);
        }

        [Fact]
        public void GetTest_ScenarioA()
        {

            //arrange
            var mockItems = new List<ShortlistedItem> {
                new ShortlistedItem{SKUId = "A",Quantity = 1},
               new ShortlistedItem{SKUId = "B", Quantity =1},
               new ShortlistedItem{SKUId = "C", Quantity = 1}
            };

            double resultPrice = 100;

            var mockOrder = new Order();
            mockOrder.Products = mockItems;

            //act
            var result = _orderController.PostOrder(mockOrder);

            // act
            var okResult = result as OkObjectResult;

            //assert
            Assert.Equal(resultPrice.ToString(), okResult.Value.ToString());
        }

        [Fact]
        public void GetTest_ScenarioB()
        {

            //arrange
            var mockItems = new List<ShortlistedItem> {
                new ShortlistedItem{SKUId = "A",Quantity = 5},
               new ShortlistedItem{SKUId = "B", Quantity = 5},
               new ShortlistedItem{SKUId = "C", Quantity = 1}
            };

            double resultPrice = 370;

            var mockOrder = new Order();
            mockOrder.Products = mockItems;

            //act
            var result = _orderController.PostOrder(mockOrder);

            // act
            var okResult = result as OkObjectResult;

            //assert
            Assert.Equal(resultPrice.ToString(), okResult.Value.ToString());
        }

        [Fact]
        public void GetTest_ScenarioC()
        {

            //arrange
            var mockItems = new List<ShortlistedItem> {
                new ShortlistedItem{SKUId = "A",Quantity = 3},
               new ShortlistedItem{SKUId = "B", Quantity = 5},
               new ShortlistedItem{SKUId = "C", Quantity = 1},
               new ShortlistedItem{SKUId = "D", Quantity = 1}
            };

            double resultPrice = 280;

            var mockOrder = new Order();
            mockOrder.Products = mockItems;

            //act
            var result = _orderController.PostOrder(mockOrder);

            // act
            var okResult = result as OkObjectResult;

            //assert
            Assert.Equal(resultPrice.ToString(), okResult.Value.ToString());
        }

        [Fact]
        public void Test_StatusCodeTotalPrice()
        {

            //arrange
            var mockItems = new List<ShortlistedItem> {
                new ShortlistedItem{SKUId = "A",Quantity = 3},
               new ShortlistedItem{SKUId = "B", Quantity = 5}
            };


            var mockOrder = new Order();
            mockOrder.Products = mockItems;

            //act
            var result = _orderController.PostOrder(mockOrder);

            // act
            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);

          
        }

        [Fact]
        public void Test_NullTotalPrice()
        {

            //arrange
            var mockItems = new List<ShortlistedItem>();


            var mockOrder = new Order();
            mockOrder.Products = mockItems;

            //act
            var result = _orderController.PostOrder(mockOrder);

            // act
            var okResult = result as OkObjectResult;
            // assert
            Assert.Null(okResult);
        }

        

        [Fact]
        public void GetTest_ReturnsExpectedTotalPrice()
        {

            //arrange
            var mockItems = new List<ShortlistedItem> {
                new ShortlistedItem{SKUId = "A",Quantity = 3},
               new ShortlistedItem{SKUId = "B", Quantity = 5}
            };

            double resultPrice = 130 + 90 + 30;

            var mockOrder = new Order();
            mockOrder.Products = mockItems;

            //act
            var result = _orderController.PostOrder(mockOrder);

            // act
            var okResult = result as OkObjectResult;

           

            //assert
            Assert.Equal(resultPrice.ToString(), okResult.Value.ToString());
        }

        
    } 
}
