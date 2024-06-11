using OrdersTest.Models;
using OrdersTest.Repositories.Entities;
using OrdersTest.Services.Entities;

namespace OrdersTest.Services.Models;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task CreateProduct(Product product)
    {
        await _productRepository.CreateProduct(product);
    }

    public async Task<Product?> GetProduct(long id)
    {
        return await _productRepository.GetProduct(id);
    }

    public async Task<IEnumerable<Product>> GetProductsList()
    {
        return await _productRepository.GetProductsList();
    }

    public async Task UpdateProduct(long id, Product product)
    {
        await _productRepository.UpdateProduct(id, product);
    }

    public async Task DeleteProduct(long id)
    {
        await _productRepository.DeleteProduct(id);
    }
}