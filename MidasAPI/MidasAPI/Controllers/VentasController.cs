using Microsoft.AspNetCore.Mvc;
using MidasAPI.Models.Data;
using MidasAPI.Models.DataTransfer;
using MidasAPI.Models.Repository;

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
        public IEnumerable<VentasInformation> GetVentas2()
        {
            return _ventasRepository.GetVentas2().ToList();
        }


        [HttpPost]
        [Route("NuevaVenta")]
        [ActionName(nameof(CreateVentaAsync))]
        public async Task<ActionResult<Venta>> CreateVentaAsync(VentaDto data)
        {
            try
            {
                var venta = await _ventasRepository.CreateVentaAsync(data);
                return Ok(venta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
