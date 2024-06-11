using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersTest.Models;

[Table("products")]
public class Product
{
    [Key]
    public long Id { get; set; }
    
    public string? Name { get; set; }
    
    public decimal Price { get; set; }
}