using OrdersTest.Models;

namespace OrdersTest.Repositories.Entities;

public interface IOrderRepository
{
    Task CreateOrder(Order order);
    Task<Order?> GetOrder(long id);
    Task<IEnumerable<Order>> GetOrdersList();
    Task UpdateOrder(long id, Order order);
    Task DeleteOrder(long id);
}