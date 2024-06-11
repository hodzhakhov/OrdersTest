using Microsoft.EntityFrameworkCore;
using OrdersTest.Models;
using OrdersTest.Repositories.Entities;

namespace OrdersTest.Repositories.Models;

public class OrderRepository : IOrderRepository
{
    private readonly DataContext _dataContext;

    public OrderRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task CreateOrder(Order order)
    {
        _dataContext.Orders.Add(order);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<Order?> GetOrder(long id)
    {
        return await _dataContext.Orders
            .Include(o => o.Product)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<Order>> GetOrdersList()
    {
        return await _dataContext.Orders
            .Include(o => o.Product)
            .ToListAsync();
    }

    public async Task UpdateOrder(long id, Order order)
    {
        if (id != order.Id)
        {
            return;
        }

        _dataContext.Entry(order).State = EntityState.Modified;
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteOrder(long id)
    {
        var order = await _dataContext.Orders.FindAsync(id);

        if (order == null)
        {
            return;
        }

        _dataContext.Orders.Remove(order);
        await _dataContext.SaveChangesAsync();
    }
}