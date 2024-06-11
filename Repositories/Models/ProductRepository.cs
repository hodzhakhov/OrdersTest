using Microsoft.EntityFrameworkCore;
using OrdersTest.Models;
using OrdersTest.Repositories.Entities;

namespace OrdersTest.Repositories.Models;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _dataContext;

    public ProductRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task CreateProduct(Product product)
    {
        _dataContext.Products.Add(product);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<Product?> GetProduct(long id)
    {
        var product = await _dataContext.Products.FindAsync(id);
        
        return product;
    }

    public async Task<IEnumerable<Product>> GetProductsList()
    {
        return await _dataContext.Products.ToListAsync();
    }

    public async Task UpdateProduct(long id, Product product)
    {
        if (id != product.Id)
        {
            return;
        }

        _dataContext.Entry(product).State = EntityState.Modified;
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteProduct(long id)
    {
        var product = await _dataContext.Products.FindAsync(id);

        if (product == null)
        {
            return;
        }

        _dataContext.Products.Remove(product);
        await _dataContext.SaveChangesAsync();
    }
    
    public async Task<bool> ProductExists(long id)
    {
        return await _dataContext.Products.AnyAsync(p => p.Id == id);
    }
}