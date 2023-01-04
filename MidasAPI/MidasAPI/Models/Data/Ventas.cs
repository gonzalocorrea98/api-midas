using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MidasAPI.Models.Data
{
    public class Ventas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int cantidad { get; set; }
        public double importe { get; set; }
        
        public DateTime fecha { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto oProducto { get; set; }
    }
}
