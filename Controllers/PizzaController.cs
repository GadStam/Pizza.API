using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using Pizzas.API.Services;

namespace Pizzas.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Pizza> ListaPizzas;
            ListaPizzas= BD.GetAll();
            return Ok(ListaPizzas);
        }

        [HttpGet ("{Id}")]
        public IActionResult GetById(int Id)
        {
            if(Id<=0){
                return BadRequest();
            }else{
                Pizza MiPizza;
                MiPizza=BD.GetById(Id);
                if(MiPizza==null){
                    return NotFound();
                }else{
                    return Ok(MiPizza);
                }
            }
        }

        [HttpPost]
        public IActionResult Create(Pizza MiPizza)
        {
            BD.Create(MiPizza);
            return Created("/API/Pizza", new{Id=MiPizza.Id});
        }

        [HttpPut ("{id}")]
        public IActionResult Update(int Id, Pizza MiPizza)
        {
            if(MiPizza.Id!=Id){
                return BadRequest();
            }else{
                if(BD.Update(Id,MiPizza)==null){
                    return NotFound();
                }else{
                    return Ok();
                }
            }
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete(int Id)
        {
            if(Id<=0){
                return BadRequest();
            }else{
                if(BD.DeleteById(Id)==null){
                    return NotFound();
                }else{
                    return Ok();
                }
            }
        }


    }

}