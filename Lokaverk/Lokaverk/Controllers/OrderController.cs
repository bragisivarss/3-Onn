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
            try
            {
                return Ok(await _orderRepository.GetAllAsync());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("/api/order/{email}")]
        public async Task<IActionResult> GetOrderByName(string email)
        {
            try
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
                    Id = order.Id,
                    Price = order.Price,
                    Email = order.Email,
                    People = order.People,
                    Date = order.Date.ToString("u"),
                    Dish = order.Dish == null ? null : new DishDTO
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
                    Drinks = order.Drinks?.Select(d => new DrinkDTO
                    {
                        idDrink = d.IdDrink,
                        strDrink = d.StrDrink,
                        strDrinkThumb = d.StrDrinkThumb,
                        amount = d.Amount,
                    }).ToList(),
                };

                return Ok(orderDTO);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
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
        public async Task<IActionResult> UpdateOrder([FromBody] OrderDTO updatedOrderDto)
        {
            try
            {
                if (updatedOrderDto == null)
                {
                    return BadRequest(new { success = false, error = "Order is null" });
                }

                var existingOrder = await _orderRepository
                    .FindByConditionWithIncludesAsync(o => o.Email == updatedOrderDto.Email, o => o.Dish, o => o.Drinks);

                if (existingOrder == null)
                {
                    return NotFound(new { success = false, error = "Order not found" });
                }

                // Update scalar properties
                existingOrder.Price = updatedOrderDto.Price;
                existingOrder.Email = updatedOrderDto.Email;
                existingOrder.People = updatedOrderDto.People;

                if (DateTime.TryParse(updatedOrderDto.Date, out var parsedDate))
                {
                    existingOrder.Date = parsedDate;
                }
                else
                {
                    return BadRequest(new { success = false, error = "Invalid date format" });
                }

                // Update Dish
                existingOrder.Dish = new Dish
                {
                    IdMeal = updatedOrderDto.Dish.idMeal,
                    strCategory = updatedOrderDto.Dish.strCategory,
                    StrArea = updatedOrderDto.Dish.strArea,
                    StrMealThumb = updatedOrderDto.Dish.strMealThumb,
                    StrIngredient1 = updatedOrderDto.Dish.strIngredient1,
                    StrIngredient2 = updatedOrderDto.Dish.strIngredient2,
                    StrIngredient3 = updatedOrderDto.Dish.strIngredient3,
                    StrIngredient4 = updatedOrderDto.Dish.strIngredient4,
                    StrIngredient5 = updatedOrderDto.Dish.strIngredient5,
                    StrIngredient6 = updatedOrderDto.Dish.strIngredient6,
                    StrIngredient7 = updatedOrderDto.Dish.strIngredient7,
                    StrIngredient8 = updatedOrderDto.Dish.strIngredient8,
                    StrIngredient9 = updatedOrderDto.Dish.strIngredient9,
                    StrIngredient10 = updatedOrderDto.Dish.strIngredient10,
                    StrIngredient11 = updatedOrderDto.Dish.strIngredient11,
                    StrIngredient12 = updatedOrderDto.Dish.strIngredient12,
                    StrIngredient13 = updatedOrderDto.Dish.strIngredient13,
                    StrIngredient14 = updatedOrderDto.Dish.strIngredient14,
                    StrIngredient15 = updatedOrderDto.Dish.strIngredient15,
                    StrIngredient16 = updatedOrderDto.Dish.strIngredient16,
                    StrIngredient17 = updatedOrderDto.Dish.strIngredient17,
                    StrIngredient18 = updatedOrderDto.Dish.strIngredient18,
                    StrIngredient19 = updatedOrderDto.Dish.strIngredient19,
                    StrIngredient20 = updatedOrderDto.Dish.strIngredient20,
                };

                // Update Drinks
                existingOrder.Drinks = updatedOrderDto.Drinks
                    .Select(drinkDto => new Drink
                    {
                        IdDrink = drinkDto.idDrink,
                        StrDrink = drinkDto.strDrink,
                        StrDrinkThumb = drinkDto.strDrinkThumb,
                        Amount = drinkDto.amount
                    }).ToList();

                await _orderRepository.UpdateAsync(existingOrder);
                await _orderRepository.SaveAsync();

                return Ok(new { success = true, message = "Order updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }
    }
}
