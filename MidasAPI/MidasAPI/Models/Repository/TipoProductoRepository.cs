using Microsoft.EntityFrameworkCore;
using MidasAPI.Models.Data;
using MidasAPI.Models.Repository;

namespace MidasAPI.Models.Repository
{
    public class TipoProductoRepository : ITipoProductoRepository
    {
        protected readonly AlmacenContext _context;
        public TipoProductoRepository(AlmacenContext context) => _context = context;

        public IEnumerable<TipoProducto> GetTipoProductos()
        {
            return _context.TipoProductos.ToList();
        }

        public TipoProducto GetTipoProductoById(int id)
        {
            return _context.TipoProductos.Find(id);
        }

        public int GetStockTotal(int id)
        {
            var result = _context.Productos.Where(x => x.TipoProductoId == id).Sum(s => s.Stock);
            return result;
        }

        public async Task<TipoProducto> CreateTipoProductoAsync(TipoProducto tipo)
        {
            await _context.Set<TipoProducto>().AddAsync(tipo);
            await _context.SaveChangesAsync();
            return tipo;
        }

        public async Task<bool> UpdateTipoProductoAsync(TipoProducto tipo)
        {
            _context.Entry(tipo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTipoProductoAsync(TipoProducto tipo)
        {
            if (tipo is null)
            {
                return false;
            }
            _context.Set<TipoProducto>().Remove(tipo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
