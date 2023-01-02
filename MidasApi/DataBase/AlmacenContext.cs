using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class AlmacenContext : DbContext
    {
        public AlmacenContext(DbContextOptions<AlmacenContext> options)
            : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<TipoProducto> TiposProductos { get; set; }
        
    }
}