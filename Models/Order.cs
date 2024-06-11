using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersTest.Models;

[Table("orders")]
public class Order
{
    [Key]
    public long Id { get; set; }
    
    public long ProductId { get; set; }
    public Product? Product { get; set; }
}