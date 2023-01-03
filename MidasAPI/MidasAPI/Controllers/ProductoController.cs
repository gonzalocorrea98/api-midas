using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MidasAPI.Models.Data;
using MidasAPI.Models.Repository;

namespace MidasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetProductosAsync))]
        public IEnumerable<Producto> GetProductosAsync()
        {
            return _productoRepository.GetProductos();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetProductoById))]
        public ActionResult<Producto> GetProductoById(int id)
        {
            var productoByID = _productoRepository.GetProductoById(id);
            if (productoByID == null)
            {
                return NotFound();
            }
            return productoByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateProductoAsync))]
        public async Task<ActionResult<Producto>> CreateProductoAsync(Producto producto)
        {
            await _productoRepository.CreateProductoAsync(producto);
            return CreatedAtAction(nameof(GetProductoById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateProducto))]
        public async Task<ActionResult> UpdateProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            await _productoRepository.UpdateProductoAsync(producto);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteProducto))]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = _productoRepository.GetProductoById(id);
            if (producto == null)
            {
                return NotFound();
            }

            await _productoRepository.DeleteProductoAsync(producto);

            return NoContent();
        }
    }
}
