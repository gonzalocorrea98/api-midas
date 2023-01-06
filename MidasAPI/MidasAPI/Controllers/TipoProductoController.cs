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
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("Nuevo")]
        [ActionName(nameof(CreateTipoProductoAsync))]
        public async Task<ActionResult<TipoProducto>> CreateTipoProductoAsync(TipoProducto tipoProducto)
        {
            await _tipoProductoRepository.CreateTipoProductoAsync(tipoProducto);
            return CreatedAtAction(nameof(GetTipoProductoById), new { id = tipoProducto.Id }, tipoProducto);
        }


        [HttpPut("Editar/{id}")]
        [ActionName(nameof(UpdateTipoProducto))]
        public async Task<ActionResult> UpdateTipoProducto(int id, TipoProducto tipoProducto)
        {
            tipoProducto.Id = id;
            if (id != tipoProducto.Id)
            {
                return BadRequest();
            }

            await _tipoProductoRepository.UpdateTipoProductoAsync(tipoProducto);

            return NoContent();
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
