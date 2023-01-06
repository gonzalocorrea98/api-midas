using System.Text.Json.Serialization;

namespace MidasAPI.Models.DataTransfer
{
    public class DetalleDto
    {
        [JsonIgnore]
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int cantidad { get; set; }

    }
}
