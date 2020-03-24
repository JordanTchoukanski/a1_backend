using System;
using Microsoft.EntityFrameworkCore;
using A1_v2._3.Models;





namespace A1_v2._3.Data
{
    public class ProductsDbContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }
        
    }
}
