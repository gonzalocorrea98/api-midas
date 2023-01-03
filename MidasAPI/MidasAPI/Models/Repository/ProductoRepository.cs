using Microsoft.EntityFrameworkCore;
using MidasAPI.Models.Data;
using MidasAPI.Models.Repository;

namespace MidasAPI.Models.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        protected readonly AlmacenContext _context;
        public ProductoRepository(AlmacenContext context) => _context = context;

        public IEnumerable<Producto> GetProductos()
        {
            return _context.Productos.ToList();
        }

        public Producto GetProductoById(int id)
        {
            return _context.Productos.Find(id);
        }

        public async Task<Producto> CreateProductoAsync(Producto producto)
        {
            await _context.Set<Producto>().AddAsync(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<bool> UpdateProductoAsync(Producto producto)
        {
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductoAsync(Producto producto)
        {
            //var entity = await GetByIdAsync(id);
            if (producto is null)
            {
                return false;
            }
            _context.Set<Producto>().Remove(producto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
