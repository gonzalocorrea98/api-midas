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
        public double Precio { get; set; }
        
        public DateTime Fecha { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto oProducto { get; set; }


        public Venta(int productoId, int cantidad, double precio)
        {
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
            Fecha = DateTime.Now;
            oProducto = new Producto();
        }
    }
}
