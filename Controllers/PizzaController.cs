using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;

namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(){
            List<Pizza> ListaPizzas;
            ListaPizzas=BD.GetAll();
            return Ok(ListaPizzas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            Pizza MiPizza=BD.GetById(id);
            return Ok(MiPizza);
        }

        [HttpPost]
        public IActionResult Create(Pizza Pizza){
            BD.Create(Pizza);
            return Ok();
        }

        [HttpPut("{id}")]
         public IActionResult Update(int id, Pizza Pizza){
            BD.Update(id, Pizza);
             return Ok();
        }

        [HttpDelete("{id}")]
         public IActionResult DeleteById(int id){
             BD.DeleteById(id);
             return Ok();
        }
    }
}
