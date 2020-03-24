using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc;
using A1_v2._3.Models; 


namespace A1_v2._3.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]








    public class ProductsController : ControllerBase
    {
        static List<Product> _products = new List<Product>() {

            new Product(){ProductId = 1, ProductName ="Apple", ProductPrice="12lv"},
            new Product(){ProductId = 2, ProductName ="Orange", ProductPrice="17lv"},
            new Product(){ProductId = 3, ProductName ="Banana", ProductPrice="20lv"}


        };

        [HttpGet]

        public IEnumerable<Product> Get()
        {

            return _products;

        }

        [HttpGet("welcome")]

        public IActionResult GetWelcome()
        {

            return Ok("Welcome");

        }


        [HttpPost]

        public IActionResult Post([FromBody]Product product)
        {

            _products.Add(product);
            return StatusCode(StatusCodes.Status201Created); 

        }

        [HttpPut("{id}")]

        public void Put(int id, [FromBody] Product product)
        {

            _products[id] = product; 
        }

        [HttpDelete("{id}")]

        public void Delete(int id)
        {

            _products.RemoveAt(id);

        }

    }

    
}


