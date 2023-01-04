using Microsoft.AspNetCore.Mvc;
using MidasAPI.Models.Data;
using MidasAPI.Models.Information;

namespace MidasAPI.Models.Repository
{
    public interface IProductoRepository
    {

        IEnumerable<Producto> GetProductos();

        Producto GetProductoById(int id);

        Task<Producto> CreateProductoAsync(ProductoInf producto);

        Task<bool> UpdateProductoAsync(Producto producto);

        Task<bool> DeleteProductoAsync(Producto producto);

    }
}
