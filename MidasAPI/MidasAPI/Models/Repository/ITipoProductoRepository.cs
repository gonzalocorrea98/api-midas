using MidasAPI.Models.Data;

namespace MidasAPI.Models.Repository
{
    public interface ITipoProductoRepository
    {
        Task<TipoProducto> CreateTipoProductoAsync(TipoProducto tipo);

        Task<bool> DeleteTipoProductoAsync(TipoProducto tipo);

        TipoProducto GetTipoProductoById(int id);

        IEnumerable<TipoProducto> GetTipoProductos();

        Task<bool> UpdateTipoProductoAsync(TipoProducto tipo);
    }
}
