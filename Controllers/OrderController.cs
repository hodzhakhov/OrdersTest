using Microsoft.AspNetCore.Mvc;
using OrdersTest.Models;
using OrdersTest.Services.Entities;

namespace OrdersTest.Controllers;

[Route("api/order")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var orders = await _orderService.GetOrdersList();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _orderService.GetOrder(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<Order>> AddOrder(Order order)
    {
        try
        {
            await _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Product not found.");
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, Order order)
    {
        if (id != order.Id)
        {
            return BadRequest();
        }

        await _orderService.UpdateOrder(id, order);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        await _orderService.DeleteOrder(id);
        return NoContent();
    }
}