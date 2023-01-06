using MidasAPI.Models.Data;
using MidasAPI.Models.DataTransfer;
using MidasAPI.Models.Views;

namespace MidasAPI.Models.Repository
{
    public interface IVentasRepository
    {

        IEnumerable<FacturaInformation> GetVentas();

        IEnumerable<FacturaInformation> GetVentasByFecha(DateTime id);

        double GetVentasTotal(DateTime id);

        int CreateFactura(FacturaDto data);

        int CreateDetalle(DetalleDto data);

        string DeleteVenta(int id);

        //Task<Detalle> CreateVentaAsync(DetalleDto data);
    }
}
