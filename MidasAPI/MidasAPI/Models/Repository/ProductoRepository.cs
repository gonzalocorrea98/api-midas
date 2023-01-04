using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidasAPI.Models.Data;
using MidasAPI.Models.Information;
using MidasAPI.Models.Repository;
using System.Linq;

namespace MidasAPI.Models.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        protected readonly AlmacenContext _context;
        public ProductoRepository(AlmacenContext context) => _context = context;

        //OBTENER PRODUCTOS
        public IEnumerable<Producto> GetProductos()
        {
            return _context.Productos.Include(t => t.oTipoProducto).ToList();
        }

        //OBTENER PRODUCTOS POR ID
        public Producto GetProductoById(int id)
        {
            //var oProducto = _context.Productos.Find(id);
            var oProducto = _context.Productos.Include(t => t.oTipoProducto).Where(p => p.Id == id).FirstOrDefault();
            return oProducto;
        }

        //CREAR PRODUCTO
        public async Task<Producto> CreateProductoAsync(ProductoInf info)
        {
            Producto oProducto = new Producto(info.Nombre,info.Precio,info.Stock,info.TipoProductoId);
            _context.Productos.Add(oProducto);
            await _context.SaveChangesAsync();

            return oProducto;
        }   

        //ACTUALIZAR PRODUCTO
        public async Task<bool> UpdateProductoAsync(Producto producto)
        {
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        //ELIMINAR PRODUCTO
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
