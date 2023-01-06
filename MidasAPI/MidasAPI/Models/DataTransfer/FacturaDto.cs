namespace MidasAPI.Models.DataTransfer
{
    public class FacturaDto
    {
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleDto> Detalles { get; set; }
    }
}
