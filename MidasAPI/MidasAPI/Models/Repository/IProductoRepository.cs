using Microsoft.AspNetCore.Mvc;
using MidasAPI.Models.Data;
using MidasAPI.Models.DataTransfer;

namespace MidasAPI.Models.Repository
{
    public interface IProductoRepository
    {

        IEnumerable<ProductoInformation> GetProductos();

        ProductoInformation GetProductoById(int id);

        Task<Producto> CreateProductoAsync(ProductoDto data);

        Producto UpdatePrecio(int id, double precio);

        Producto UpdateStock(int id, int stock);

        void DeleteProducto(int id);

        //Task<Producto> UpdateProductoAsync(int id, ProductoDto data);
    }
}
