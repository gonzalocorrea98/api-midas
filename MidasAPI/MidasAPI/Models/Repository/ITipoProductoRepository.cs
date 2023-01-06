using MidasAPI.Models.Data;

namespace MidasAPI.Models.Repository
{
    public interface ITipoProductoRepository
    {
        IEnumerable<TipoProducto> GetTipoProductos();

        TipoProducto GetTipoProductoById(int id);

        int GetStockTotal(int id);

        Task<TipoProducto> CreateTipoProductoAsync(TipoProducto tipo);

        Task<bool> UpdateTipoProductoAsync(TipoProducto tipo);

        Task<bool> DeleteTipoProductoAsync(TipoProducto tipo);

    }
}
