using Lokaverk.Data;
using Lokaverk.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lokaverk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IRepository<Order> repository) : ControllerBase
    {
        private readonly IRepository<Order> _orderRepository = repository;

        [HttpGet]
        [Route("/all-orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            return Ok(await _orderRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("/api/order/{email}")]
        public async Task<ActionResult<Order>> GetOrderByName(string email)
        {
            return Ok(await _orderRepository.FindByConditionAsync(x => x.Email == email));
        }

        [HttpPost]
        [Route("/api/create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order is null");
            }

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveAsync();
            return CreatedAtAction(nameof(GetOrderByName), new { email = order.Email }, order);
        }

        [HttpPut]
        [Route("/api/update-order")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order updatedOrder)
        {
            if (updatedOrder == null)
            {
                return BadRequest("Order is null");
            }

            var existingOrder = await _orderRepository.FindByConditionAsync(o => o.Id == updatedOrder.Id);
            if (existingOrder == null)
            {
                return NotFound("Order not found");
            }

            // Update properties
            existingOrder.Price = updatedOrder.Price;
            existingOrder.Email = updatedOrder.Email;
            existingOrder.People = updatedOrder.People;
            existingOrder.Date = updatedOrder.Date;
            existingOrder.DishId = updatedOrder.DishId;
            existingOrder.Dish = updatedOrder.Dish;
            existingOrder.Drinks = updatedOrder.Drinks;

            await _orderRepository.UpdateAsync(existingOrder);
            await _orderRepository.SaveAsync();

            return NoContent();
        }
    }
}
