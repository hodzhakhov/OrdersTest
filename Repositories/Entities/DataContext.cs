using Microsoft.EntityFrameworkCore;
using OrdersTest.Models;

namespace OrdersTest.Repositories.Entities;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Product)
            .WithMany()
            .HasForeignKey(o => o.ProductId);

        base.OnModelCreating(modelBuilder);
    }
}