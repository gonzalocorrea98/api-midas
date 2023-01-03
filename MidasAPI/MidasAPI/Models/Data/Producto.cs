using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MidasAPI.Models.Data
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        [ForeignKey("TipoProductoID")]
        public int TipoProductoID { get; set; }

        //public virtual TipoProducto TipoProducto { get; set; }
    }
}
