using Microsoft.EntityFrameworkCore;
using ProductoAPIService.Models;
using System.Collections.Generic;

namespace ProductoAPIService.Data
{
    public class ProductoDbContext : DbContext
    {
        public ProductoDbContext(DbContextOptions<ProductoDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
    }
}
