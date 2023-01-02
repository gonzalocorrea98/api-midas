using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoID { get; set; }

        public string Nombre { get; set; }

        public int TipoProductoID { get; set; }
        
        [ForeignKey("TipoProductoID")]
        public virtual TipoProducto TipoProducto { get; set; }
    }
}
