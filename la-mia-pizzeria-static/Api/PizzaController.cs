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
    }
}
