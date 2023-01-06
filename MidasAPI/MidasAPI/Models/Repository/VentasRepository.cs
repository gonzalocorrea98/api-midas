using Azure.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MidasAPI.Models.Data;
using MidasAPI.Models.DataTransfer;
using MidasAPI.Models.Views;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Schema;

namespace MidasAPI.Models.Repository
{
    public class VentasRepository : IVentasRepository
    {
        protected readonly AlmacenContext _context;
        public VentasRepository(AlmacenContext context) => _context = context;


        //OBTENER VENTAS CON DATOS COMPLETOS
        public IEnumerable<FacturaInformation> GetVentas()
        {
            List<DetalleInformation> listaDetalles = (from d in _context.Detalles
                                                      join p in _context.Productos on d.ProductoId equals p.Id
                                                      join t in _context.TipoProductos on p.TipoProductoId equals t.Id
                                                      select new DetalleInformation()
                                                      {
                                                          FacturaNro = d.FacturaId,
                                                          Producto = p.Nombre,
                                                          TipoProducto = t.Descripcion,
                                                          Cantidad = d.Cantidad,
                                                          PrecioUnitario = d.Precio,
                                                          Importe = d.Cantidad * d.Precio
                                                      }).ToList();

            List<FacturaInformation> listaFacturas = (from f in _context.Facturas.Where(x => x.Baja != true)
                                                      select new FacturaInformation()
                                                      {
                                                          FacturaNro = f.Id,
                                                          Cliente = f.Cliente,
                                                          Fecha = f.Fecha,
                                                      }).ToList();


            foreach (FacturaInformation item in listaFacturas)
            {
                item.Detalles = listaDetalles.Where(x => x.FacturaNro == item.FacturaNro).ToList();
                item.ImporteTotal = listaDetalles.Where(x => x.FacturaNro == item.FacturaNro).Sum(s => s.Importe);
            }

            return listaFacturas;
            //return _context.Facturas.Include(t => t.Detalles).Where(x => x.Baja != true);
        }


        //CARGAR VENTA CON DETALLES Y FACTURA
        public int CreateFactura(FacturaDto data)
        {
            Factura oFactura = new Factura(data.Cliente, data.Fecha);
            _context.Facturas.Add(oFactura);
            _context.SaveChanges();

            int id = _context.Facturas.OrderBy(f => f.Id).Last().Id;

            foreach (DetalleDto item in data.Detalles)
            {
                var oProducto = _context.Productos.Find(item.ProductoId);
                oProducto.Stock = oProducto.Stock - item.cantidad;
                Detalle oDetalle = new Detalle(id, item.ProductoId, item.cantidad, oProducto.Precio);
                _context.Detalles.Add(oDetalle);
                _context.SaveChanges();
            }

            return id;
        }


        //CARGAR DETALLE A UNA FACTURA
        public int CreateDetalle(DetalleDto data)
        {

            var oProducto = _context.Productos.Find(data.ProductoId);
            if (oProducto == null)
            {
                return 0;
            }
            Detalle oDetalle = new Detalle(data.FacturaId, data.ProductoId, data.cantidad, oProducto.Precio);
            _context.Detalles.Add(oDetalle);
            _context.SaveChanges();

            return _context.Detalles.OrderBy(d => d.Id).Last().Id;
        }


        //CANCELAR VENTA
        public string DeleteVenta(int id)
        {
            var oFactura = _context.Facturas.Find(id);
            if (oFactura == null)
            {
                return "No se encontro la venta nro: " + id;
            }
            oFactura.Baja = true;
            oFactura.FechaBaja = DateTime.Now;
            _context.SaveChanges();

            return "Se dio de baja con exito la venta nro: " + id;
        }


        //TRAER VENTAS POR FECHA
        public IEnumerable<FacturaInformation> GetVentasByFecha(DateTime fecha)
        {
            //List<FacturaInformation> oVentas = GetVentas().ToList();
            //oVentas.Where(x => x.Fecha >= fecha).ToList();
            //return oVentas;

            List<DetalleInformation> listaDetalles = (from d in _context.Detalles
                                                      join p in _context.Productos on d.ProductoId equals p.Id
                                                      join t in _context.TipoProductos on p.TipoProductoId equals t.Id
                                                      select new DetalleInformation()
                                                      {
                                                          FacturaNro = d.FacturaId,
                                                          Producto = p.Nombre,
                                                          TipoProducto = t.Descripcion,
                                                          Cantidad = d.Cantidad,
                                                          PrecioUnitario = d.Precio,
                                                          Importe = d.Cantidad * d.Precio
                                                      }).ToList();

            List<FacturaInformation> listaFacturas = (from f in _context.Facturas.Where(x => x.Baja != true)
                                                      select new FacturaInformation()
                                                      {
                                                          FacturaNro = f.Id,
                                                          Cliente = f.Cliente,
                                                          Fecha = f.Fecha,
                                                      }).ToList();


            foreach (FacturaInformation item in listaFacturas)
            {
                item.Detalles = listaDetalles.Where(x => x.FacturaNro == item.FacturaNro).ToList();
                item.ImporteTotal = listaDetalles.Where(x => x.FacturaNro == item.FacturaNro).Sum(s => s.Importe);
            }

            return listaFacturas.Where(x => x.Fecha == fecha);
        }

        //IMPORTE TOTAL POR FECHA
        public double GetVentasTotal(DateTime fecha)
        {
            var data = (from d in _context.Detalles
                        join f in _context.Facturas on d.FacturaId equals f.Id
                        where (f.Fecha == fecha)
                        select new
                        {
                            Importe = d.Cantidad * d.Precio
                        }).ToList();
            
            double total = data.Sum(x => x.Importe);

            return total;
        }
    }
}
