using Microsoft.EntityFrameworkCore;
using TransaccionAPIService.Models;

namespace TransaccionAPIService.Data
{
    public class TransaccionDbContext : DbContext
    {
        public TransaccionDbContext(DbContextOptions<TransaccionDbContext> options)
            : base(options) { }

        public DbSet<Transaccion> Transacciones { get; set; }
    }
}
