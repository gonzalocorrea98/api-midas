namespace MidasAPI.Models.Views
{
    public class ProductoInformation
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public string TipoProducto { get; set; }

        public ProductoInformation()
        {
            Nombre = string.Empty;
            TipoProducto = string.Empty;
        }
    }
}
