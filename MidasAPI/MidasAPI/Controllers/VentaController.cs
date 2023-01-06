using Microsoft.AspNetCore.Mvc;
using MidasAPI.Models.Data;
using MidasAPI.Models.DataTransfer;
using MidasAPI.Models.Repository;
using MidasAPI.Models.Views;

namespace MidasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private IVentasRepository _ventasRepository;

        public VentasController(IVentasRepository ventasRepository)
        {
            _ventasRepository = ventasRepository;
        }


        [HttpGet]
        [ActionName(nameof(GetVentas))]
        public IEnumerable<FacturaInformation> GetVentas()
        {
            return _ventasRepository.GetVentas();
        }


        [HttpGet]
        [Route("VentasDelDia")]
        [ActionName(nameof(GetVentasByFecha))]
        public IEnumerable<FacturaInformation> GetVentasByFecha(DateTime fecha)
        {
            return _ventasRepository.GetVentasByFecha(fecha);
        }


        [HttpGet]
        [Route("ImporteTotalDelDia")]
        [ActionName(nameof(GetImporteTotal))]
        public IActionResult GetImporteTotal(DateTime fecha)
        {
            try
            {
                var result = _ventasRepository.GetVentasTotal(fecha);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("NuevaVenta")]
        [ActionName(nameof(CreateFactura))]
        public IActionResult CreateFactura(FacturaDto data)
        {
            try
            {
                int facturaId = _ventasRepository.CreateFactura(data);
                return Ok("se cargo con exito la venta nro: " + facturaId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("CancelarVenta")]
        [ActionName(nameof(DeleteVenta))]
        public IActionResult DeleteVenta(int id)
        {
            try
            {
                string result = _ventasRepository.DeleteVenta(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        //[Route("NuevoDetalle")]
        //[ActionName(nameof(CreateDetalle))]
        //public IActionResult CreateDetalle(DetalleDto data)
        //{
        //    try
        //    {
        //        int detalleId = _ventasRepository.CreateDetalle(data);

        //        return Ok("se creo con exito el detalle nro: " + detalleId);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
