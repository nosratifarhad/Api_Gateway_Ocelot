using Bogus;
using Microsoft.AspNetCore.Mvc;
using Order.API.InputModels.OrderInputModels;
using Order.API.ViewModels.OrderViewModels;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// Get Orders
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/orders")]
        public async Task<IActionResult> GetOrders()
        {
            var orderViewModels = await Task.FromResult((IEnumerable<OrderViewModel>)CreateFakerOrders());

            return Ok(orderViewModels);
        }

        /// <summary>
        /// Create Order
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost("/api/orders")]
        public async Task<IActionResult> CreateOrder(CreateOrderInputModel inputModel)
        {
            int orderId = await Task.FromResult(new Faker().Random.Number(1, 5));

            return CreatedAtRoute(nameof(GetOrder), new { orderId }, new { OrderId = orderId });
        }

        /// <summary>
        /// Get Order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("/api/orders/{orderId:int}", Name = nameof(GetOrder))]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            var orderViewModel = await Task.FromResult(CreateFakerOrder(orderId));

            return Ok(orderViewModel);
        }

        /// <summary>
        /// Update Order
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPut("/api/orders/{orderId:int}")]
        public async Task<IActionResult> UpdateOrder(int orderId, UpdateOrderInputModel inputModel)
        {
            if (orderId != inputModel.OrderId)
                return BadRequest();

            await Task.Delay(1000);

            return NoContent();
        }

        /// <summary>
        /// Delete Order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpDelete("/api/orders/{orderId:int}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await Task.Delay(1000);

            return NoContent();
        }

        #region FakeData

        private static OrderViewModel CreateFakerOrder(int orderId)
            => new Faker<OrderViewModel>()
                .CustomInstantiator(f => new OrderViewModel
                {
                    OrderId = orderId,
                    OrderDate = f.Date.Recent(),
                    TotalAmount = f.Random.Decimal(50, 500),
                    ShippingAddress = f.Address.FullAddress(),
                    BillingAddress = f.Address.FullAddress(),
                    Items = new Faker<OrderItemViewModel>()
                        .CustomInstantiator(fi => new OrderItemViewModel
                        {
                            ProductId = f.Random.Int(1, 100),
                            ProductName = f.Commerce.ProductName(),
                            Quantity = f.Random.Int(1, 5),
                            UnitPrice = f.Random.Decimal(10, 100)
                        })
                        .Generate(f.Random.Int(1, 5)), 
                    OrderStatus = f.PickRandom(new[] { "Pending", "Shipped", "Delivered", "Canceled" }),
                    PaymentMethod = f.PickRandom(new[] { "Credit Card", "PayPal", "Bank Transfer" }),
                    IsPaid = f.Random.Bool(),
                    ShippingDate = f.Date.Soon(7)
                });

        private static List<OrderViewModel> CreateFakerOrders()
            => new Faker<OrderViewModel>()
                .CustomInstantiator(f => new OrderViewModel
                {
                    OrderId = f.Random.Int(1, 1000),
                    OrderDate = f.Date.Recent(),
                    TotalAmount = f.Random.Decimal(50, 500), 
                    ShippingAddress = f.Address.FullAddress(),
                    BillingAddress = f.Address.FullAddress(),
                    Items = new Faker<OrderItemViewModel>()
                        .CustomInstantiator(fi => new OrderItemViewModel
                        {
                            ProductId = f.Random.Int(1, 100),
                            ProductName = f.Commerce.ProductName(),
                            Quantity = f.Random.Int(1, 5),
                            UnitPrice = f.Random.Decimal(10, 100)
                        })
                        .Generate(f.Random.Int(1, 5)),
                    OrderStatus = f.PickRandom(new[] { "Pending", "Shipped", "Delivered", "Canceled" }),
                    PaymentMethod = f.PickRandom(new[] { "Credit Card", "PayPal", "Bank Transfer" }),
                    IsPaid = f.Random.Bool(),
                    ShippingDate = f.Date.Soon(7) 
                })
                .Generate(20); 


        #endregion FakeData
    }
}
