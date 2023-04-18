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
        public IActionResult GetPizzas()
        {
            using var ctx = new PizzeriaContext();
            IQueryable<Pizza> pizzas = ctx.Pizzas;

            return Ok(pizzas.ToList());

        }
    }
}
