using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MidasAPI.Models.Data
{
    public class Detalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }


        [ForeignKey("FacturaId")]
        public virtual Factura oFactura { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto oProducto { get; set; }


        public Detalle(int facturaId, int productoId, int cantidad, double precio)
        {
            FacturaId = facturaId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
