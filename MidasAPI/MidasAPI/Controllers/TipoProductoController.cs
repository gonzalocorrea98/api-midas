using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MidasAPI.Models.Data;
using MidasAPI.Models.Repository;

namespace MidasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase
    {
        private ITipoProductoRepository _tipoProductoRepository;

        public TipoProductoController(ITipoProductoRepository tipoProductoRepository)
        {
            _tipoProductoRepository = tipoProductoRepository;
        }


        [HttpGet]
        [ActionName(nameof(GetTipoProductosAsync))]
        public IEnumerable<TipoProducto> GetTipoProductosAsync()
        {
            return _tipoProductoRepository.GetTipoProductos();
        }


        [HttpGet("{id}")]
        [ActionName(nameof(GetTipoProductoById))]
        public ActionResult<TipoProducto> GetTipoProductoById(int id)
        {
            var tipoProductoByID = _tipoProductoRepository.GetTipoProductoById(id);
            if (tipoProductoByID == null)
            {
                return NotFound();
            }
            return tipoProductoByID;
        }


        [HttpGet("StockTotal/{id}")]
        [ActionName(nameof(GetStockTotal))]
        public ActionResult<TipoProducto> GetStockTotal(int id)
        {
            var tipoProductoByID = _tipoProductoRepository.GetTipoProductoById(id);
            if (tipoProductoByID == null)
            {
                return NotFound();
            }

            try
            {
                var result = _tipoProductoRepository.GetStockTotal(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [Route("Nuevo")]
        [ActionName(nameof(CreateTipoProductoAsync))]
        public async Task<ActionResult<TipoProducto>> CreateTipoProductoAsync(string descripcion)
        {
            TipoProducto oTipoProducto = new TipoProducto();
            oTipoProducto.Descripcion = descripcion;
            await _tipoProductoRepository.CreateTipoProductoAsync(oTipoProducto);
            return CreatedAtAction(nameof(GetTipoProductoById), new { id = oTipoProducto.Id }, oTipoProducto);
        }


        [HttpPut("Editar/{id}")]
        [ActionName(nameof(UpdateTipoProducto))]
        public async Task<ActionResult> UpdateTipoProducto(int id, string descripcion)
        {
            TipoProducto oTipoProducto = new TipoProducto();
            oTipoProducto.Descripcion = descripcion;
            oTipoProducto.Id = id;

            var tipoProductoByID = _tipoProductoRepository.GetTipoProductoById(id);
            if (tipoProductoByID == null)
            {
                return NotFound();
            }

            try
            {
                await _tipoProductoRepository.UpdateTipoProductoAsync(oTipoProducto);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
            
        }

        [HttpDelete("Eliminar/{id}")]
        [ActionName(nameof(DeleteTipoProducto))]
        public async Task<IActionResult> DeleteTipoProducto(int id)
        {
            var tipoProducto = _tipoProductoRepository.GetTipoProductoById(id);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            await _tipoProductoRepository.DeleteTipoProductoAsync(tipoProducto);
            return NoContent();
        }
    }
}
