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








    public class CustomersController : ControllerBase
    {
        static List<Customers>_customer = new List<Customers>() {


            new Customers() {Id=1, Name="Jordan", Email="jtchoukanski@mail.bg", Phone="08762880158"},
            new Customers() {Id=2, Name = "John", Email = "jordan1@mail.bg", Phone = "0876880158"},




    };

        [HttpGet]

        public IEnumerable<Customers> Get()
        {
            return _customer; 
          

        }

        [HttpGet("welcome")]

        public IActionResult GetWelcome()
        {

            return Ok("Welcome"); 

        }


        [HttpPost]

        public void Post([FromBody]Customers customer)
        {

            _customer.Add(customer);

        }

        //[HttpPut("{id}")]

        //public void Put(int id, [FromBody] Customers customer)
        //{
        //

        //}

        //[HttpDelete("{id}")]

        //public void Delete(int id)
        //{



        //}

    }


}

