namespace MidasAPI.Models.Views
{
    public class DetalleInformation
    {
        public int FacturaNro { get; set; }
        public string Producto { get; set; }
        public string TipoProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Importe { get; set; }
    }
}
