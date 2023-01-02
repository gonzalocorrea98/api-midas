using DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MidasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private AlmacenContext _context;

        public ProductoController(AlmacenContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Producto> Get() => _context.Productos.ToList();
    }
}
