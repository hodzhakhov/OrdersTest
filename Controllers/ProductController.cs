using Microsoft.AspNetCore.Mvc;
using OrdersTest.Models;
using OrdersTest.Services.Entities;

namespace OrdersTest.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var orders = await _productService.GetProductsList();
        return Ok(orders);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productService.GetProduct(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        await _productService.CreateProduct(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        await _productService.UpdateProduct(id, product);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProduct(id);
        return Ok();
    }
}