using OrdersTest.Models;

namespace OrdersTest.Repositories.Entities;

public interface IProductRepository
{
    Task CreateProduct(Product product);
    Task<Product?> GetProduct(long id);
    Task<IEnumerable<Product>> GetProductsList();
    Task UpdateProduct(long id, Product product);
    Task DeleteProduct(long id);
    Task<bool> ProductExists(long id);
}