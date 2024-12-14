using Lokaverk.Data;
using Lokaverk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lokaverk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController(IRepository<Drink> repository) : ControllerBase
    {
        private readonly IRepository<Drink> _drinkRepo = repository;

        [HttpGet]
        [Route("/all-drinks")]
        public async Task<ActionResult<IEnumerable<Drink>>> GetAllDrinks()
        {
            var drinks = await _drinkRepo.GetAllAsync();
            var result = drinks.Select(d => new
            {
            d.Id,
            d.CreatedDate,
            d.UpdatedDate,
            d.StrDrink,
            d.StrGlass,
            d.StrDrinkThumb,
            d.Price,
            d.Amount
            });

            return Ok(result);
        }
    }
}
