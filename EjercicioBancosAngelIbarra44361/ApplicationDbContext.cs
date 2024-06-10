
using Microsoft.EntityFrameworkCore;

namespace EjercicioBancosAngelIbarra44361
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bancos> Bancos { get; set; }   

        public DbSet<Clientes> Clientes { get; set; }
        
    }
}