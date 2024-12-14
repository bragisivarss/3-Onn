using Lokaverk.Data;
using Lokaverk.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lokaverk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController(IRepository<Dish> repository) : ControllerBase
    {
        private readonly IRepository<Dish> _dishRepository = repository;

        [HttpGet]
        [Route("/all-dishes")]
        public async Task<ActionResult<IEnumerable<Dish>>> GetAllDishes()
        {
            return Ok(await _dishRepository.GetAllAsync());
        }
    }
}
