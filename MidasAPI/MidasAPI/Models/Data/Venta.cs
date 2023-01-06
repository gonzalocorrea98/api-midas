using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MidasAPI.Models.Data
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double Importe { get; set; }
        
        public DateTime Fecha { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto oProducto { get; set; }


        public Venta(int productoId, int cantidad, double importe)
        {
            ProductoId = productoId;
            Cantidad = cantidad;
            Importe = importe * cantidad;
            Fecha = DateTime.Now;
        }
    }
}
