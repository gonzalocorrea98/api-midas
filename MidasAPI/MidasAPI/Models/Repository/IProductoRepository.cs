using MidasAPI.Models.Data;

namespace MidasAPI.Models.Repository
{
    public interface IProductoRepository
    {
        Task<Producto> CreateProductoAsync(Producto producto);

        Task<bool> DeleteProductoAsync(Producto producto);

        Producto GetProductoById(int id);

        IEnumerable<Producto> GetProductos();

        Task<bool> UpdateProductoAsync(Producto producto);
    }
}
