using MidasAPI.Models.Data;
using MidasAPI.Models.DataTransfer;

namespace MidasAPI.Models.Repository
{
    public interface IVentasRepository
    {

        IEnumerable<VentasInformation> GetVentas2();

        Task<Venta> CreateVentaAsync(VentaDto data);
    }
}
