using OrdersTest.Models;
using OrdersTest.Repositories.Entities;
using OrdersTest.Services.Entities;

namespace OrdersTest.Services.Models;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }
    
    public async Task CreateOrder(Order order)
    {
        if (!await _productRepository.ProductExists(order.ProductId))
        {
            throw new KeyNotFoundException("Product not found.");
        }
        
        await _orderRepository.CreateOrder(order);
    }

    public async Task<Order?> GetOrder(long id)
    {
        return await _orderRepository.GetOrder(id);
    }

    public async Task<IEnumerable<Order>> GetOrdersList()
    {
        return await _orderRepository.GetOrdersList();
    }

    public async Task UpdateOrder(long id, Order order)
    {
        await _orderRepository.UpdateOrder(id, order);
    }

    public async Task DeleteOrder(long id)
    {
        await _orderRepository.DeleteOrder(id);
    }
}