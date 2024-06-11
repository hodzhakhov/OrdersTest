using OrdersTest.Models;

namespace OrdersTest.Services.Entities;

public interface IProductService
{
    Task CreateProduct(Product product);
    Task<Product?> GetProduct(long id);
    Task<IEnumerable<Product>> GetProductsList();
    Task UpdateProduct(long id, Product product);
    Task DeleteProduct(long id);
}