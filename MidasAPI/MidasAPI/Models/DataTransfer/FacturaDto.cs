using Microsoft.Identity.Client;

namespace MidasAPI.Models.DataTransfer
{
    public class FacturaDto
    {
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleDto> Detalles { get; set; }

        public FacturaDto()
        {
            Cliente = String.Empty;
            Detalles = new List<DetalleDto>();
        }
    }
}
