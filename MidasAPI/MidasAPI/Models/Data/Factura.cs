
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MidasAPI.Models.Data
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        [JsonIgnore]
        public bool Baja { get; set; }
        [JsonIgnore]
        public DateTime FechaBaja { get; set; }

        public IEnumerable<Detalle> Detalles { get; set; }

        public Factura(string cliente, DateTime fecha)
        {
            Cliente = cliente;
            Fecha = fecha;
        }
    }
}
