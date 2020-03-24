using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using A1_v2._3.Models;
using A1_v2._3.Data;

namespace A1_v2._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDbController : ControllerBase
    {

        private aApiContext aapiContext;

        public ProductsDbController(aApiContext _aapiContext)
        {
            aapiContext = _aapiContext;


        }



        // GET: api/ProductsDb
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            //return new string[] { "Jordan_db", "John_db" };
            return aapiContext.Products;
        }

        // GET: api/ProductsDb/5
        [HttpGet("{id}", Name = "Get")]

        public IActionResult Get(int id)
        {
            var product = aapiContext.Products.SingleOrDefault(obj => obj.ProductId == id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);

        }


        [HttpGet("sorting")]

        public IEnumerable<Product> GetSorting(string sortPrice, int price)
        {

            IQueryable<Product> products;
            switch (sortPrice)
            {
                case "desc":
                    products = aapiContext.Products.Where(obj => obj.Price >= price).OrderByDescending(obj => obj.Price);
                    break;

                case "asc":
                    products = aapiContext.Products.Where(obj => obj.Price >= price).OrderBy(obj => obj.Price);
                    break;
                default:

                    products = aapiContext.Products;
                    break;

            }



            return products;

        }



        [HttpGet("paging")]

        public IEnumerable<Product> GetPaging(int pageNumber, int pageSize)
        {


            var products = from p in aapiContext.Products.OrderBy(obj => obj.Price) select p;
            var items = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

           


            return items;

        }

        [HttpGet("searching")]

        public IEnumerable<Product> GetSearch(string searchProduct)
        {

          var query = aapiContext.Products.Where(obj => obj.ProductName.StartsWith(searchProduct)); 




            return query;

        }

       
        // POST: api/ProductsDb
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            aapiContext.Products.Add(product);
            aapiContext.SaveChanges(true); 

            return StatusCode(StatusCodes.Status201Created);


        }

        // PUT: api/ProductsDb/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {


            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {

                return BadRequest(ModelState);

            }

            try {
                aapiContext.Products.Update(product);
                aapiContext.SaveChanges(true);

            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound("product not found"); 


            }

            aapiContext.Products.Update(product);
            aapiContext.SaveChanges(true);
            return Ok("Product uodated"); 


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {


            var product = aapiContext.Products.SingleOrDefault(obj => obj.ProductId == id);


            if (product == null)
            {

                return NotFound("Product not found"); 

            }

          

            aapiContext.Products.Remove(product);
            aapiContext.SaveChanges(true);
            return Ok("Product removed");








        }
    }
}
