using OrdersTest.Models;

namespace OrdersTest.Services.Entities;

public interface IOrderService
{
    Task CreateOrder(Order order);
    Task<Order?> GetOrder(long id);
    Task<IEnumerable<Order>> GetOrdersList();
    Task UpdateOrder(long id, Order order);
    Task DeleteOrder(long id);
}