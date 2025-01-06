using System;
using apptlink.Domain.Types;

namespace apptlink.Application.Contract;

public interface IProductoContract
{
    public Task<ProductoType> GetProductoID(int id);
    public Task<List<ProductoType>> GetProductos();
    public Task<List<ProductoType>> GetFilteredProducts(int id);
    public Task<bool> PostProducto(ProductoType producto);
    public Task<bool> PutProducto(ProductoType producto);
    public Task<bool> DeleteProducto(int id);
}
