using Microsoft.EntityFrameworkCore;
using OrderTechnicalTest.Domain.Model.Aggregates;
using OrderTechnicalTest.Domain.Model.Entities;
using OrderTechnicalTest.Infrastructure.EFC.Configurations;

namespace OrderTechnicalTest.Infrastructure.EFC.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
    }
}