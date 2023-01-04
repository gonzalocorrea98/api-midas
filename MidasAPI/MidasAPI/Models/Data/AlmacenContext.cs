using Microsoft.EntityFrameworkCore;

namespace MidasAPI.Models.Data
{
    public class AlmacenContext : DbContext
    {
        public AlmacenContext(DbContextOptions<AlmacenContext> options) 
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<TipoProducto> TipoProductos { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
    }
}
