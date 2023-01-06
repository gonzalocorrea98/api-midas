using Microsoft.EntityFrameworkCore;
using MidasAPI.Models.Data;
using MidasAPI.Models.DataTransfer;

namespace MidasAPI.Models.Repository
{
    public class VentasRepository : IVentasRepository
    {
        protected readonly AlmacenContext _context;
        public VentasRepository(AlmacenContext context) => _context = context;


        //OBTENER VENTAS CON DATOS COMPLETOS
        public IEnumerable<VentasInformation> GetVentas2()
        {
            var listaVentas = (from v in _context.Ventas
                               join p in _context.Productos on v.ProductoId equals p.Id
                               join t in _context.TipoProductos on p.TipoProductoId equals t.Id
                               select new VentasInformation()
                               {
                                   NroVenta = v.Id,
                                   Producto = p.Nombre,
                                   TipoProducto = t.Descripcion,
                                   Cantidad = v.Cantidad,
                                   Importe = v.Precio,
                                   Fecha = v.Fecha
                               }).ToList();

            return listaVentas;
        }

        //CARGAR VENTA
        public async Task<Venta> CreateVentaAsync(VentaDto data)
        {
            Producto producto = _context.Productos.Find(data.ProductoId);

            Venta oVenta = new Venta(data.ProductoId, data.cantidad, data.ProductoId);
            _context.Ventas.Add(oVenta);
            await _context.SaveChangesAsync();

            return oVenta;
        }

    }
}
