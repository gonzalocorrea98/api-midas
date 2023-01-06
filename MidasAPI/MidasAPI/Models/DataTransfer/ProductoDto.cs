namespace MidasAPI.Models.DataTransfer
{
    public class ProductoDto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public int TipoProductoId { get; set; }

        public ProductoDto()
        {
            Nombre = String.Empty;
        }
    }
}
