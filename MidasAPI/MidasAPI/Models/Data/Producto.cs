using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MidasAPI.Models.Data
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public int TipoProductoId { get; set; }

        [ForeignKey("TipoProductoId")]
        public virtual TipoProducto oTipoProducto { get; set; }


        public Producto(string nombre, double precio, int stock, int tipoProductoId)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            TipoProductoId = tipoProductoId;
        }

        public Producto()
        {
            Id = 0;
            Nombre = "Sin Nombre";
            Precio = 0;
            Stock = 0;
            TipoProductoId = 0;
        }
    }
}
