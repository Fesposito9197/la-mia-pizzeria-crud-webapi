using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public IActionResult GetPizzas([FromQuery] string? title)
        {
            using var ctx = new PizzeriaContext();
            var pizzas = ctx.Pizzas.Where(p=> title ==null || p.Name.ToLower().Contains(title.ToLower()))
                .ToList();

            return Ok(pizzas);

        }

        [HttpGet("{id}")]
        public IActionResult GetPizzas(int id)
        {
            using var ctx = new PizzeriaContext();
            var pizza = ctx.Pizzas.FirstOrDefault(p => p.Id == id);

            if (pizza == null)
            {
                return NotFound();

            }
            return Ok(pizza);
        }
    }
}
