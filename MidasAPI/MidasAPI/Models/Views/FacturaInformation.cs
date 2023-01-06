namespace MidasAPI.Models.Views
{
    public class FacturaInformation
    {
        public int FacturaNro { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleInformation> Detalles { get; set; }
        public double ImporteTotal { get; set; }

        public FacturaInformation()
        {
            Cliente = String.Empty;
            Detalles = new List<DetalleInformation>();
        }
    }
}
