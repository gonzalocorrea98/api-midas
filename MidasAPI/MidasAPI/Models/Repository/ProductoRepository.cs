using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MidasAPI.Models.Data;
using MidasAPI.Models.DataTransfer;

namespace MidasAPI.Models.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        protected readonly AlmacenContext _context;
        public ProductoRepository(AlmacenContext context) => _context = context;


        //OBTENER PRODUCTOS
        public IEnumerable<ProductoInformation> GetProductos()
        {
            var listaProductos = (from p in _context.Productos
                                  join t in _context.TipoProductos on p.TipoProductoId equals t.Id
                                  select new ProductoInformation()
                                  {
                                      ProductoId = p.Id,
                                      Nombre = p.Nombre,
                                      Precio = p.Precio,
                                      Stock = p.Stock,
                                      TipoProducto = t.Descripcion
                                  }).ToList();

            return listaProductos;
        }


        //OBTENER PRODUCTO POR ID
        public ProductoInformation GetProductoById(int id)
        {
            //var oProducto = _context.Productos.Include(t => t.oTipoProducto).Where(p => p.Id == id).FirstOrDefault();
            //return oProducto;

            var oProducto = (from p in _context.Productos
                             join t in _context.TipoProductos on p.TipoProductoId equals t.Id
                             where p.Id == id
                             select new ProductoInformation()
                             {
                                 ProductoId = p.Id,
                                 Nombre = p.Nombre,
                                 Precio = p.Precio,
                                 Stock = p.Stock,
                                 TipoProducto = t.Descripcion
                             }).FirstOrDefault();

            return oProducto;
        }


        //CREAR PRODUCTO
        public async Task<Producto> CreateProductoAsync(ProductoDto data)
        {
            Producto oProducto = new Producto(data.Nombre, data.Precio, data.Stock, data.TipoProductoId);
            _context.Productos.Add(oProducto);
            await _context.SaveChangesAsync();

            return oProducto;
        }   


        //ACTUALIZAR PRECIO
        public Producto UpdatePrecio(int id, double precio)
        {
            Producto oProducto = _context.Productos.First(p => p.Id.Equals(id));
            oProducto.Precio = precio;
            _context.SaveChanges();
            return oProducto;
        }


        //ACTUALIZAR STOCK
        public Producto UpdateStock(int id, int stock)
        {
            Producto oProducto = _context.Productos.First(p => p.Id.Equals(id));
            oProducto.Stock = stock;
            _context.SaveChanges();
            return oProducto;
        }


        //ELIMINAR PRODUCTO
        public void DeleteProducto(int id)
        {
            Producto oProducto = _context.Productos.First(p => p.Id.Equals(id));
            _context.Productos.Remove(oProducto);
            _context.SaveChanges();
        }


        //ACTUALIZAR PRODUCTO ENTERO
        //public async Task<Producto> UpdateProductoAsync(int id, ProductoDto data)
        //{
        //    Producto oProducto = new Producto(data.Nombre, data.Precio, data.Stock, data.TipoProductoId);
        //    oProducto.Id = id;
        //    _context.Productos.Update(oProducto);
        //    await _context.SaveChangesAsync();

        //    var productoAct = _context.Productos.Include(t => t.oTipoProducto).Where(p => p.Id == id).FirstOrDefault();

        //    return productoAct;
        //}
    }
}
