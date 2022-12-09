using Microsoft.EntityFrameworkCore;

namespace API_Imcs.Models
{
    
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        { }

        public DbSet<CalculoImc> Imcs { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}