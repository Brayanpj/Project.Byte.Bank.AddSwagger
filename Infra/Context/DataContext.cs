using Microsoft.EntityFrameworkCore;

namespace Project.Byte.Bank.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<UsuarioKey> UsuarioKey { get; set; }
    }
}
