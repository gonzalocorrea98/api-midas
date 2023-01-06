using Microsoft.AspNetCore.Mvc;
using MidasAPI.Models.Data;
using MidasAPI.Models.DataTransfer;
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
        public IEnumerable<ProductoInformation> GetProductosAsync()
        {
            return _productoRepository.GetProductos();
        }


        [HttpGet("{id}")]
        [ActionName(nameof(GetProductoById))]
        public ActionResult<ProductoInformation> GetProductoById(int id)
        {
            var productoByID = _productoRepository.GetProductoById(id);
            if (productoByID == null)
            {
                return NotFound();
            }

            return productoByID;
        }


        [HttpPost]
        [Route("Guardar")]
        [ActionName(nameof(CreateProductoAsync))]
        public async Task<ActionResult<Producto>> CreateProductoAsync(ProductoDto objeto)
        {
            try
            {
                var producto = await _productoRepository.CreateProductoAsync(objeto);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("EditarPrecio")]
        [ActionName(nameof(UpdatePrecio))]
        public ActionResult<Producto> UpdatePrecio(int id, double precio)
        {
            var productoByID = _productoRepository.GetProductoById(id);
            if (productoByID == null)
            {
                return NotFound();
            }

            try
            {
                var productoActualizado = _productoRepository.UpdatePrecio(id, precio);
                return Ok(productoActualizado); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("EditarStock")]
        [ActionName(nameof(UpdateStock))]
        public ActionResult<Producto> UpdateStock(int id, int stock)
        {
            var productoByID = _productoRepository.GetProductoById(id);
            if (productoByID == null)
            {
                return NotFound();
            }

            try
            {
                var productoActualizado = _productoRepository.UpdateStock(id, stock);
                return Ok(productoActualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Eliminar/{id}")]
        [ActionName(nameof(DeleteProducto))]
        public IActionResult DeleteProducto(int id)
        {
            var producto = _productoRepository.GetProductoById(id);
            if (producto == null)
            {
                return NotFound();
            }

            try
            {
                _productoRepository.DeleteProducto(id);
                return Ok("Se Elimino Correctamente el Producto: " + producto.Nombre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        //[HttpPut("Editar/{id}")]
        //[ActionName(nameof(UpdateProducto))]
        //public async Task<ActionResult> UpdateProducto(int id, ProductoDto objeto)
        //{
        //    try
        //    {
        //        var productoActualizado = await _productoRepository.UpdateProductoAsync(id, objeto);
        //        return Ok(productoActualizado);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}
    }
}
