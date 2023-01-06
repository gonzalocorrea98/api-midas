namespace MidasAPI.Models.DataTransfer
{
    public class VentasInformation
    {
        public int NroVenta { get; set; }
        public string Producto { get; set; }
        public string TipoProducto { get; set; }
        public int Cantidad { get; set; }
        public double Importe { get; set; }
        public DateTime Fecha { get; set; }
    }
}
