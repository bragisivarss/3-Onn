using Lokaverk.Data;
using Lokaverk.Models;
using Lokaverk.Models.DTO;
using Lokaverk.Utils;
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
        public async Task<IActionResult> GetOrderByName(string email)
        {
            var order = await _orderRepository.FindByConditionWithIncludesAsync(
                o => o.Email == email,
                o => o.Dish,
                o => o.Drinks
            );

            if (order == null)
            {
                return NotFound(new { success = false, error = $"No order found with email: {email}" });
            }

            var orderDTO = new OrderDTO
            {
                id = order.Id,
                price = order.Price,
                email = order.Email,
                people = order.People,
                dish = order.Dish == null ? null : new DishDTO
                {
                    idMeal = order.Dish.IdMeal,
                    strCategory = order.Dish.strCategory,
                    strArea = order.Dish.StrArea,
                    strMealThumb = order.Dish.StrMealThumb,
                    strIngredient1 = order.Dish.StrIngredient1,
                    strIngredient2 = order.Dish.StrIngredient2,
                    strIngredient3 = order.Dish.StrIngredient3,
                    strIngredient4 = order.Dish.StrIngredient4,
                    strIngredient5 = order.Dish.StrIngredient5,
                    strIngredient6 = order.Dish.StrIngredient6,
                    strIngredient7 = order.Dish.StrIngredient7,
                    strIngredient8 = order.Dish.StrIngredient8,
                    strIngredient9 = order.Dish.StrIngredient9,
                    strIngredient10 = order.Dish.StrIngredient10,
                    strIngredient11 = order.Dish.StrIngredient11,
                    strIngredient12 = order.Dish.StrIngredient12,
                    strIngredient13 = order.Dish.StrIngredient13,
                    strIngredient14 = order.Dish.StrIngredient14,
                    strIngredient15 = order.Dish.StrIngredient15,
                    strIngredient16 = order.Dish.StrIngredient16,
                    strIngredient17 = order.Dish.StrIngredient17,
                    strIngredient18 = order.Dish.StrIngredient18,
                    strIngredient19 = order.Dish.StrIngredient19,
                    strIngredient20 = order.Dish.StrIngredient20,
                },
                drinks = order.Drinks?.Select(d => new DrinkDTO
                {
                    idDrink = d.idDrink,
                    strDrink = d.StrDrink,
                    strDrinkThumb = d.StrDrinkThumb,
                    amount = d.Amount,
                }).ToList(),
            };

            return Ok(orderDTO);
        }

        [HttpPost]
        [Route("/api/create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest("Order is null");
                }

                await _orderRepository.AddAsync(order);
                await _orderRepository.SaveAsync();
                return CreatedAtAction(nameof(GetOrderByName), new { email = order.Email }, order);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("/api/update-order")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order updatedOrder)
        {
            if (updatedOrder == null)
            {
                return BadRequest(new { success = false, error = "Order is null" });
            }

            var existingOrder = await _orderRepository.FindByConditionAsync(o => o.Id == updatedOrder.Id);

            if (existingOrder == null)
            {
                return NotFound(new { success = false, error = "Order not found" });
            }

            existingOrder.Price = updatedOrder.Price;
            existingOrder.Email = updatedOrder.Email;
            existingOrder.People = updatedOrder.People;
            existingOrder.Date = updatedOrder.Date;
            existingOrder.DishId = updatedOrder.DishId;

            existingOrder.Dish = updatedOrder.Dish ?? existingOrder.Dish;
            existingOrder.Drinks = updatedOrder.Drinks ?? existingOrder.Drinks;

            await _orderRepository.UpdateAsync(existingOrder);
            await _orderRepository.SaveAsync();

            return Ok(new { success = true, message = "Order updated successfully" });
        }
    }
}
