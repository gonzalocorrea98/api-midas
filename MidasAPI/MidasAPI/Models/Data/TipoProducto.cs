using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MidasAPI.Models.Data
{
    public class TipoProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoProducto()
        {
            Id = 0;
            Descripcion = "Sin Descripcion";
        }
    }
}
